using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

namespace WebApp
{
    public partial class _Default : Page
    {
        //Integridad_BLL pIntegridad = new Integridad_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["Registros"] == null)
            //{
            //    // (Digito Verificador) 1 - Se chequea que la integridad DVH
            //    List<Registro_BE> RegistrosDVH = pIntegridad.ChequearDVH();
            //    //(Digito Verificador) 7 - Se obtienen las tablas con errores de verificacion
            //    List<Registro_BE> RegistrosDVV = pIntegridad.ChequearDVV();
            //    //(Digito Verificador) 12 - Si hay tablas con errores se envian para mostrar por pantalla
            //    if (null != RegistrosDVH || null != RegistrosDVV)
            //    {
            //        List<Registro_BE> Registros = new List<Registro_BE>();
            //        if (null != RegistrosDVH) { Registros.AddRange(RegistrosDVH); }
            //        if (null != RegistrosDVV) { Registros.AddRange(RegistrosDVV); }
            //        Session["Registros"] = Registros;
            //        Response.Redirect("FalloIntegridad.aspx");
            //    }
            //    else
            //    {
            //        // No hay registros que se encontraron maliciosos en la session
            //        Session["Registros"] = new List<Registro_BE>();
            //    }
            //}
        }

        [System.Web.Services.WebMethod]
        public static string GetCurrentTime(string name)
        {
            return "Hello " + name + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
        }
    }
}