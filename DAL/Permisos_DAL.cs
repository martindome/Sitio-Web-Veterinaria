using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Composite;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Permisos_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();
        Integridad_DAL pIntegridad = new Integridad_DAL();
        public List<TipoUsuario_BE> ListarPermisos()
        {
            List<TipoUsuario_BE> tipos = new List<TipoUsuario_BE>();

            DataTable Tabla = ac.EjecutarStoredProcedure("listar_tipos", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                TipoUsuario_BE detalle = new TipoUsuario_BE();
                detalle.id = Convert.ToInt32(reg["id"].ToString());
                detalle.tipo_usuario = reg["tipo_usuario"].ToString();
                detalle.listaAcciones = this.Buscar_Acciones(detalle.id);
                tipos.Add(detalle);
            }
            return tipos;
        }

        public List<Compuesto_BE> Buscar_Acciones(int id_tipo_usuario)
        {
            List<Compuesto_BE> acciones = new List<Compuesto_BE>();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id_tipo_usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = id_tipo_usuario;


            DataTable Tabla = ac.EjecutarStoredProcedure("listar_acciones", parametros);
            foreach (DataRow reg in Tabla.Rows)
            {
                Accion_BE accion = new Accion_BE();
                accion.id = Convert.ToInt32(reg["id"].ToString());
                accion.detalle = reg["detalle"].ToString();
                acciones.Add(accion);
            }
            return acciones;
        }

        public List<Accion_BE> Listar_Acciones()
        {

            List<Accion_BE> acciones = new List<Accion_BE>();
            DataTable Tabla = ac.EjecutarStoredProcedure("listar_acciones_todas", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Accion_BE accion = new Accion_BE();
                accion.id = Convert.ToInt32(reg["id"].ToString());
                accion.detalle = reg["detalle"].ToString();
                acciones.Add(accion);
            }
            return acciones;
        }

        public void Eliminar_Accion_Permiso(int permiso, int accion)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@permiso";
            parametros[0].DbType = DbType.Int16;
            parametros[0].Value = permiso;
            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@accion";
            parametros[1].DbType = DbType.Int16;
            parametros[1].Value = accion;
            DataTable Tabla = ac.EjecutarStoredProcedure("eliminar_permiso_accion", parametros);
        }

        public void Agregar_Accion_Permiso(int permiso, int accion)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@permiso";
            parametros[0].DbType = DbType.Int16;
            parametros[0].Value = permiso;
            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@accion";
            parametros[1].DbType = DbType.Int16;
            parametros[1].Value = accion;
            DataTable Tabla = ac.EjecutarStoredProcedure("agregar_permiso_accion", parametros);
        }

        public void Agregar_Permiso(string nombre)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@nombre";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = nombre;
            DataTable Tabla = ac.EjecutarStoredProcedure("agregar_permiso", parametros);
        }
    }
}
