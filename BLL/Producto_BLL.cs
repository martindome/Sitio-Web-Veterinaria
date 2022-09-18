using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Producto_BLL: IDisposable
    {
        Producto_DAL mapper = new Producto_DAL();

        public List<Producto_BE> Listar_Productos()
        {
            return mapper.ListarProductos();
        }

        public Producto_BE ObtenerProducto(int id)
        {
            return mapper.ObtenerProducto(id);
        }

        public void Dispose()
        {

        }
    }
}
