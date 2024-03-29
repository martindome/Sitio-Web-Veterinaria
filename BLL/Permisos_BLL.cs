﻿using System;
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

        public List<Accion_BE> ListarAcciones()
        {
            return mapper.Listar_Acciones();
        }

        public void AgregarPermisoAccion(int permiso, int accion)
        {
            mapper.Agregar_Accion_Permiso(permiso, accion);
        }

        public void BorrarPermisoAccion(int permiso, int accion)
        {
            mapper.Eliminar_Accion_Permiso(permiso, accion);
        }

        public void AgregarPermiso(string nombre)
        {
            mapper.Agregar_Permiso(nombre);
        }
    }
}
