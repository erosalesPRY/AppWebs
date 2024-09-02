﻿using SIMANET_W22R.srvGestionLogistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SIMANET_W22R.GestionLogistica.Requerimientos
{
    /// <summary>
    /// Descripción breve de Requerimientos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Requerimientos : System.Web.Services.WebService
    {
        DataTable dt;

        [WebMethod]
        public DataTable Presupuesto(string PERIODO_PRESUPUESTO, string TIPO_DE_RECURSO, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_Presupuesto(PERIODO_PRESUPUESTO, TIPO_DE_RECURSO, UserName);
            dt.TableName = "SP_Presupuesto";

            return dt;
        }
    }
}
