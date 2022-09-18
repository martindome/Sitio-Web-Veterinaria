using System;
using System.Collections.Generic;
using System.Text;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Producto_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();
        Integridad_DAL pIntegridad = new Integridad_DAL();
        public List<Producto_BE> ListarProductos()
        {
            List<Producto_BE> list = new List<Producto_BE>();
            DataTable Tabla = ac.EjecutarStoredProcedure("listar_productos", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Producto_BE producto = new Producto_BE();
                producto.Id = Convert.ToInt32(reg["id"].ToString());
                producto.Nombre = reg["nombre"].ToString();
                producto.Tipo = reg["tipo_producto"].ToString();
                producto.Marca = reg["marca"].ToString();
                producto.Precio = reg["precio"].ToString();
                producto.Borrado = reg["borrado"].ToString();
                producto.Stock = Convert.ToInt32(reg["stock"].ToString());
                list.Add(producto);
            }
            return list;
        }

        public Producto_BE ObtenerProducto(int id)
        {
            Producto_BE producto = new Producto_BE();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = id;

            DataTable Tabla = ac.EjecutarStoredProcedure("obtener_producto", parametros);
            if (Tabla.Rows.Count == 0)
            {
                return null;
            }
            foreach (DataRow reg in Tabla.Rows)
            {

                producto.Id = Convert.ToInt32(reg["id"].ToString());
                producto.Nombre = reg["nombre"].ToString();
                producto.Tipo = reg["tipo_producto"].ToString();
                producto.Marca = reg["marca"].ToString();
                producto.Precio = reg["precio"].ToString();
                producto.Borrado = reg["borrado"].ToString();
                producto.Stock = Convert.ToInt32(reg["stock"].ToString());

            }
            return producto;
        }
    }
}
