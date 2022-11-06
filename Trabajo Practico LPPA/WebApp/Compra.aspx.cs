using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BE.Composite;

namespace WebApp
{
    public partial class Compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Usuario_BE usuario = (Usuario_BE)Session["usuario"];
                if (!(((Usuario_BE)Session["usuario"]).TipoUsuario.listaAcciones.Any(x => ((Accion_BE)x).detalle == "Compras")))
                {
                    Session["carrito"] = null;
                    Response.Redirect("Default.aspx");
                }
            }

            string rawId = Request.QueryString["idVenta"];
            int Id;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out Id))
            {
                IdVenta.Text = rawId.ToString();
            }
            
        }
    }
}