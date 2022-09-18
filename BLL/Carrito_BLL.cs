using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Carrito_BLL : IDisposable
    {
        Carrito_DAL mapper = new Carrito_DAL();
        public struct CambiosDelCarrito
        {
            public int IdProducto;
            public int Cantidad;
            public bool Borrar;
        }

        public List<DetalleCarrito_BE> ObtenerProductos(Carrito_BE carrito)
        {
            return carrito.Productos;
        }

        public void ActualizarCarrito(Carrito_BE carrito, CambiosDelCarrito[] cambios)
        {
            List<DetalleCarrito_BE> borrar= new List<DetalleCarrito_BE>();
            foreach (DetalleCarrito_BE detalle in carrito.Productos)
            {
                for (int i = 0; i < cambios.Length; i++)
                {
                    if (detalle.Producto.Id == cambios[i].IdProducto)
                    {
                        if (cambios[i].Cantidad < 1 || cambios[i].Borrar == true)
                        {
                            borrar.Add(detalle);
                            //this.Eliminar(carrito, detalle.Producto);
                        }
                        else
                        {
                            this.ActualizarProducto(carrito, detalle, cambios[i].Cantidad);
                        }
                    }
                }
            }
            foreach (DetalleCarrito_BE d in borrar)
            {
                this.Eliminar(carrito, d.Producto);
            }
        }

        public void ActualizarProducto(Carrito_BE carrito, DetalleCarrito_BE detalle, int Cantidad)
        {
            detalle.Cantidad = Cantidad;
        }

        public void Agregar(Carrito_BE carrito, Producto_BE producto, int Cantidad)
        {
            DetalleCarrito_BE detalle = new DetalleCarrito_BE();
            detalle.Producto = producto;
            detalle.Cantidad = 1;
            carrito.Productos.Add(detalle);
        }

        public void Agregar(Carrito_BE carrito, int id)
        {
            Producto_BE producto;
            using (Producto_BLL p = new Producto_BLL())
            {
                producto = p.ObtenerProducto(id);
            }
            DetalleCarrito_BE detalle = new DetalleCarrito_BE();
            detalle.Producto = producto;
            detalle.Cantidad = 1;
            carrito.Productos.Add(detalle);
        }

        public void Quitar(Carrito_BE carrito, Producto_BE producto, int Cantidad)
        {
            DetalleCarrito_BE detalle = carrito.Productos.Find(i => i.Producto.Id == producto.Id);
            if (detalle != null)
            {
                detalle.Cantidad -= Cantidad;
            }
        }

        public void Eliminar(Carrito_BE carrito, Producto_BE producto)
        {
            DetalleCarrito_BE detalle = carrito.Productos.Find(i => i.Producto.Id == producto.Id);
            if (detalle != null)
            {
                carrito.Productos.Remove(detalle);
            }
        }

        public void Vaciar(Carrito_BE carrito)
        {
            carrito.Productos.Clear();
        }

        public int Total(Carrito_BE carrito)
        {
            int acum = 0;
            foreach (DetalleCarrito_BE d in carrito.Productos)
            {
                acum += int.Parse(d.Producto.Precio) * d.Cantidad;
            }
            return acum;
        }

        public int CheckOut(Carrito_BE carrito, int usuario)
        {
            return mapper.PersistirVenta(carrito, usuario);
        }

        public void Dispose()
        {

        }
    }
}
