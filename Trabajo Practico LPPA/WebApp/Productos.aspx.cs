using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
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
        }

        public IQueryable<Producto_BE> GetProducts(
                        [QueryString("id")] int? categoryId,
                        [RouteData] string categoryName)
        {
            IQueryable<Producto_BE> query = pProducto_BLL.Listar_Productos().AsQueryable<Producto_BE>();

            return query;
        }
    }
}