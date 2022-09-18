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
    public partial class AgregarAlCarrito : System.Web.UI.Page
    {
        Carrito_BLL pCarrito = new Carrito_BLL(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new Carrito_BE();
            }
            Carrito_BE carrito = (Carrito_BE)Session["Carrito"];
            string rawId = Request.QueryString["ProductID"];
            int Id;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out Id))
            {
                pCarrito.Agregar(carrito, Convert.ToInt16(rawId));
            }
            Response.Redirect("Carrito.aspx");
        }
    }
}