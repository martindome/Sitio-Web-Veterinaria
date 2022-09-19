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

            }
            return producto;
        }

        public void BorrarProducto(Producto_BE p)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = p.Id;
            DataTable Tabla = ac.EjecutarStoredProcedure("borrar_producto", parametros);
        }

        public void NuevoProducto(Producto_BE p)
        {
            SqlParameter[] parametros = new SqlParameter[4];

            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@nombre";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = p.Nombre;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@precio";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = p.Precio;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@marca";
            parametros[2].DbType = DbType.String;
            parametros[2].Value = p.Marca;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@tipo";
            parametros[3].DbType = DbType.String;
            parametros[3].Value = p.Tipo;

            DataTable Tabla = ac.EjecutarStoredProcedure("persistir_producto", parametros);
        }

        public void ActualizarProducto(Producto_BE p, string nombre, string precio, string marca, string tipo)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = p.Id;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@nombre";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = nombre;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@precio";
            parametros[2].DbType = DbType.String;
            parametros[2].Value = precio;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@marca";
            parametros[3].DbType = DbType.String;
            parametros[3].Value = marca;

            parametros[4] = new SqlParameter();
            parametros[4].ParameterName = "@tipo";
            parametros[4].DbType = DbType.String;
            parametros[4].Value = tipo;

            DataTable Tabla = ac.EjecutarStoredProcedure("modificar_producto", parametros);

        }
    }
}
