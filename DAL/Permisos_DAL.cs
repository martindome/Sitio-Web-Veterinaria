using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Composite;
using System.Data;

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
                tipos.Add(detalle); 
            }
            return tipos;
        }
    }
}
