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
using System.Net;
using System.Web.Services;

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
                if (!(usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Compras")))
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

            //Aca usamos el web service
            //https://www.javatpoint.com/web-services-in-c-sharp
            List<Producto_BE> aux = new List<Producto_BE>();
            WebApp.ProductsWeb.ProductsWebServicesSoapClient client = new ProductsWeb.ProductsWebServicesSoapClient();
            ProductsWeb.Producto_BE[] products = client.ListProducts();
            foreach (ProductsWeb.Producto_BE product in products)
            {
                Producto_BE pProducto = new Producto_BE();
                pProducto.Marca = product.Marca;
                pProducto.Id = product.Id;
                pProducto.Nombre = product.Nombre;
                pProducto.Precio = product.Precio;
                pProducto.Borrado = product.Borrado;
                pProducto.Tipo = product.Tipo;
                aux.Add(pProducto);
            }

            List<Producto_BE> list = new List<Producto_BE>();
            foreach (Producto_BE p in aux)
            {
                if (p.Borrado == "No")
                {
                    list.Add(p);
                }
            }
            IQueryable<Producto_BE> query = list.AsQueryable<Producto_BE>();
            return query;

            //Esto anda
            //List<Producto_BE> aux = new List<Producto_BE>();


            //List<Producto_BE> productos = pProducto_BLL.Listar_Productos();
            //foreach(Producto_BE p in productos) { 
            //    if (p.Borrado == "No")
            //    {
            //        aux.Add(p);
            //    }
            //}
            //IQueryable<Producto_BE> query = aux.AsQueryable<Producto_BE>();
            //return query;
        }
    }
}