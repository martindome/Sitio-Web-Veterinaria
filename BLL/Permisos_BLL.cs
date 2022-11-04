using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using BE.Composite;

namespace BLL
{
    public class Permisos_BLL
    {
        Permisos_DAL mapper = new Permisos_DAL();
        public List<TipoUsuario_BE> ListarPermisos()
        {
            return mapper.ListarPermisos();
        }
    }
}
