using EasyControlWeb;
using EasyControlWeb.Form.Controls;
using SIMANET_W22R.srvGestionPersonal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SIMANET_W22R.RecursosHumanos
{
    /// <summary>
    /// Descripción breve de Personal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Personal : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable BuscarPersona(string ApellidosyNombres,int PSIma,string UserName)
        {
            DataTable dt = new DataTable();
            try
            {                
                PersonalSoapClient oPersonal = new PersonalSoapClient();
                if (PSIma == 1)
                {
                    dt = oPersonal.BuscarPersona(ApellidosyNombres, UserName);
                }
                else
                {
                    dt = oPersonal.BuscarTrabajadorContratista(ApellidosyNombres, UserName);
                }
                dt.TableName = "Table";
            }
            catch (Exception ex)
            {
                return EasyControlWeb.EasyUtilitario.Helper.Data.Error("Personal.asmx", ex.Message);

            }
            return dt;
        }


    }
}
