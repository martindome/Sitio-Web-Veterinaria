using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BE.Composite;
using BLL;

namespace WebApp
{
    public partial class AgregarAlCarrito : System.Web.UI.Page
    {
        Carrito_BLL pCarrito = new Carrito_BLL(); 
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
            //Se puede agregar al carro sin estar logueado
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new Carrito_BE();
            }
            Carrito_BE carrito = (Carrito_BE)Session["Carrito"];
            string rawId = Request.QueryString["ProductID"];
            int Id;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out Id))
            {
                if(!(carrito.Productos.Any(item => item.Producto.Id == Id)))
                {
                    //Solo agregamos el producto si no esta en el carrito
                    pCarrito.Agregar(carrito, Convert.ToInt16(rawId));
                }
            }
            Response.Redirect("Carrito.aspx");
        }
    }
}