using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Carrito_BE
    {
        public List<DetalleCarrito_BE> Productos;

        public Carrito_BE()
        {
            Productos = new List<DetalleCarrito_BE>();
        }
    }

}
