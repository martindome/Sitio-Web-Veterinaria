using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BE;
using BLL;

namespace WebApp
{
    /// <summary>
    /// Descripción breve de ProductsWebServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductsWebServices : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Producto_BE> ListProducts()
        {
            return new Producto_BLL().Listar_Productos();
        }
    }
}
