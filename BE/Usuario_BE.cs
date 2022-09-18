using System;
using System.Collections.Generic;
using System.Text;
using BE;
using BE.Composite;

namespace BE
{
    public class Usuario_BE
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public TipoUsuario_BE TipoUsuario { get; set; }
        // Agregado para el bloqueo por reintentos
        public int Bloqueado { get; set; }
        //Composite
        public List<Compuesto_BE> Acciones { get; set; }

        public Usuario_BE()
        {
            Acciones = new List<Compuesto_BE>();
        }

        public Usuario_BE(int pId)
        {
            IdUsuario = pId;
            Acciones = new List<Compuesto_BE>();
        }

    }
}
