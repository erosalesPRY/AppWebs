using SIMANET_W22R.srvGestionCalidad;
using SIMANET_W22R.srvGestionPersonal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIMANET_W22R.RecursosHumanos
{
    public partial class prcPersonal : PaginaBase
    {
        const int KEYPRC_FIND_PERSONA = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                switch (this.IdProceso)
                {
                    case KEYPRC_FIND_PERSONA:
                        this.DataTableToXML((new PersonalSoapClient()).BuscarPersona(this.ApellidosyNombres, this.UsuarioLogin));
                        break;
                }
            }
            catch (Exception ex) {

                this.ErrorToXML("001","prcPersonal", ex);
            }
        }
    }
}