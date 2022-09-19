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

        public struct CambiosDeProductos
        {
            public int IdProducto;
            public string Nombre;
            public string Marca;
            public string Tipo;
            public string Precio;
            public bool Borrar;
        }

        public List<Producto_BE> Listar_Productos()
        {
            return mapper.ListarProductos();
        }

        public Producto_BE ObtenerProducto(int id)
        {
            return mapper.ObtenerProducto(id);
        }

        public void ActualizarProductos(CambiosDeProductos[] cambios)
        {
            List<Producto_BE> borrar = new List<Producto_BE>();
            foreach (Producto_BE producto in Listar_Productos())
            {
                for (int i = 0; i < cambios.Length; i++)
                {
                    if (producto.Id == cambios[i].IdProducto)
                    {
                        if (cambios[i].Borrar == true)
                        {
                            this.BorrarProducto(producto);
                            //this.Eliminar(carrito, detalle.Producto);
                        }
                        else
                        {
                            this.ActualizarProducto(producto, cambios[i].Nombre, cambios[i].Precio, cambios[i].Marca, cambios[i].Tipo);
                        }
                    }
                }

            }
            
            //}
            //foreach (DetalleCarrito_BE d in borrar)
            //{
            //    this.Eliminar(carrito, d.Producto);
            //}
        }

        public void ActualizarProducto(Producto_BE p, string nombre, string precio, string marca, string tipo)
        {
            mapper.ActualizarProducto(p, nombre, precio, marca, tipo);
        }

        public void BorrarProducto(Producto_BE p)
        {
            mapper.BorrarProducto(p);
        }

        public void Dispose()
        {

        }

        public void NuevoProducto(Producto_BE producto)
        {
            mapper.NuevoProducto(producto);
        }
    }
}
