using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;

namespace BLL
{
    public class Bitacora_BLL
    {
        Bitacora_DAL mapper = new Bitacora_DAL();

        public void LLenar_Bitacora(int id_usuario, string detalle)
        {
            mapper.LLenar_Bitacora(id_usuario, detalle);
        }

        public List<DetalleBitacora_BE> Cargar_Bitacora()
        {
            return mapper.Listar_Bitacora();
        }
    }
}
