using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class Carrito_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();
        public int PersistirVenta(Carrito_BE carrito, int idUsuario)
        {
            int idventa = 0;
            SqlParameter[] parametrosVenta = new SqlParameter[1];
            parametrosVenta[0] = new SqlParameter();
            parametrosVenta[0].ParameterName = "@usu";
            parametrosVenta[0].DbType = DbType.Int32;
            parametrosVenta[0].Value = idUsuario;

            DataTable Tabla = ac.EjecutarStoredProcedure("persistir_venta", parametrosVenta);

            foreach (DataRow reg in Tabla.Rows)
            {
                idventa = Convert.ToInt32(reg["id"].ToString());
            }

            foreach (DetalleCarrito_BE detalle in carrito.Productos)
            {
                SqlParameter[] parametrosDetalle = new SqlParameter[3];
                parametrosVenta[0] = new SqlParameter();
                parametrosVenta[0].ParameterName = "@idventa";
                parametrosVenta[0].DbType = DbType.Int32;
                parametrosVenta[0].Value = idventa;

                parametrosVenta[1] = new SqlParameter();
                parametrosVenta[1].ParameterName = "@idproducto";
                parametrosVenta[1].DbType = DbType.Int32;
                parametrosVenta[1].Value = detalle.Producto.Id;

                parametrosVenta[2] = new SqlParameter();
                parametrosVenta[2].ParameterName = "@cant";
                parametrosVenta[2].DbType = DbType.Int32;
                parametrosVenta[2].Value = detalle.Cantidad;

                Tabla = ac.EjecutarStoredProcedure("persistir_detalle", parametrosVenta);
            }
            return idventa;
        }
    }
}
