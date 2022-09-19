using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BE.Composite;
using BLL;
using System.Web.ModelBinding;

namespace WebApp
{
    public partial class Productos : System.Web.UI.Page
    {
        Producto_BLL pProducto_BLL = new Producto_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //https://learn.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/display_data_items_and_details
            if (Session["usuario"]!= null)
            {
                Usuario_BE usuario = (Usuario_BE)Session["usuario"];
                if (!(usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Comprar")))
                {
                    Session["carrito"] = null;
                    Response.Redirect("Default.aspx");
                }
            }
        }

        public IQueryable<Producto_BE> GetProducts(
                        [QueryString("id")] int? categoryId,
                        [RouteData] string categoryName)
        {
            List<Producto_BE> aux = new List<Producto_BE>();
            List<Producto_BE> productos = pProducto_BLL.Listar_Productos();
            foreach(Producto_BE p in productos) { 
                if (p.Borrado == "No")
                {
                    aux.Add(p);
                }
            }
            IQueryable<Producto_BE> query = aux.AsQueryable<Producto_BE>();
            return query;
        }
    }
}