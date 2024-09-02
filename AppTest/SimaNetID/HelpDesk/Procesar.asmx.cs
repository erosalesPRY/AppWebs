using MailKit.Search;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using NPOI.POIFS.FileSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;

namespace SIMANET_W22R.HelpDesk
{
    /// <summary>
    /// Descripción breve de Procesar
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Procesar : System.Web.Services.WebService
    {

        //https://morgantechspace.com/2013/05/ldap-search-filter-examples.html
        //https://philipm.at/2018/searching_users_in_active_directory.html

        #region Active directory
        [WebMethod]
        public DataTable ActiveDItectoryGetAllUsuarios()
        {
            string[] LstFields = { "samaccountname", "title", "mail", "usergroup", "company", "department", "telephoneNumber", "mobile", "displayname" , "memberOf", "cn", "distinguishedName", "objectguid" };
            DataTable dt = new DataTable();
            dt.TableName = "Table";
            string DomainPath = "LDAP://simaperu.com.pe";
            System.DirectoryServices.DirectoryEntry adSearchRoot = new System.DirectoryServices.DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);

            adSearcher.Filter = "(&(objectClass=user)(objectCategory=person))";

            for (int i = 0; i < LstFields.Length; i++)
            {
                dt.Columns.Add(new DataColumn(LstFields[i], typeof(string)));
                adSearcher.PropertiesToLoad.Add(LstFields[i]);
            }

            SearchResult result;
            SearchResultCollection iResult = adSearcher.FindAll();
            if (iResult != null)
            {
                for (int counter = 0; counter < iResult.Count; counter++)
                {
                    result = iResult[counter];
                    if (result.Properties.Contains(LstFields[0]))//UserName
                    {
                        DataRow dr = dt.NewRow();
                        foreach (DataColumn dc in dt.Columns)
                        {
                            string NombreField = dc.ColumnName;
                            if (result.Properties.Contains(NombreField))
                            {
                                dr[NombreField] = (String)result.Properties[NombreField][0];
                            }
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }

            adSearcher.Dispose();
            adSearchRoot.Dispose();

            return dt;
        }

        [WebMethod]
        public DataTable ListarGrupos() {
            DataTable dt = new DataTable();
            dt.TableName = "Table";
            dt.Columns.Add(new DataColumn("member", typeof(string)));

            System.DirectoryServices.DirectoryEntry ldapConnection = new System.DirectoryServices.DirectoryEntry("LDAP://simaperu.com.pe");
            ldapConnection.Username = "erosales";
            ldapConnection.Password = "ejraPelucadeLoco2021a";
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;


            DirectorySearcher searcher = new DirectorySearcher(ldapConnection);
            searcher.Filter = "(objectClass=group)";
            searcher.SearchScope = SearchScope.Subtree;
            searcher.PropertiesToLoad.Add("member");

            SearchResult group = searcher.FindOne();
            if (group != null)
            {
                foreach (string memberDN in group.Properties["member"])
                {
                    DataRow dr = dt.NewRow();
                    dr["member"] = memberDN;
                    dt.Rows.Add(dr);
                }
                dt.AcceptChanges();
            }
            return dt;

        }
       
        [WebMethod]
        public  List<Computer> GetADComputers()
        {

            /* var domain = "simaperu";
             var container = "DC=ad,DC=com";

             using (var context = new PrincipalContext(ContextType.Domain, domain, container))
             {
                 var principal = new UserPrincipal(context)
                 {
                     SamAccountName = "*"
                 };
                 using (var searcher = new PrincipalSearcher(principal))
                 {
                     PrincipalSearchResult<Principal> result1 = searcher.FindAll();
                     //result1.Dump();
                 }
             }
             */


            List<Computer> rst = new List<Computer>();

            string DomainPath = "LDAP://simaperu.com.pe";
            System.DirectoryServices.DirectoryEntry adSearchRoot = new System.DirectoryServices.DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);

            adSearcher.Filter = ("(objectClass=computer)");
            adSearcher.PropertiesToLoad.Add("description");
            adSearcher.SizeLimit = int.MaxValue;
            adSearcher.PageSize = int.MaxValue;

            SearchResult result;
            SearchResultCollection iResult = adSearcher.FindAll();

            Computer item;

            for (int counter = 0; counter < iResult.Count; counter++)
            {
                result = iResult[counter];

                string ComputerName = result.GetDirectoryEntry().Name;
                if (ComputerName.StartsWith("CN=")) ComputerName = ComputerName.Remove(0, "CN=".Length);
                item = new Computer();
                item.ComputerName = ComputerName;

                if (result.Properties.Contains("description"))
                {
                    item.Description = (String)result.Properties["description"][0];

                }
                rst.Add(item);
            }

            adSearcher.Dispose();
            adSearchRoot.Dispose();

            return rst;
        }

        public class Computer
        {
            public string ComputerName { get; set; }

            public string Description { get; set; }
        }
        #endregion






    }
}
