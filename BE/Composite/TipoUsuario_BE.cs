using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BE.Composite
{
    public class TipoUsuario_BE : Compuesto_BE
    {

        //private List<Compuesto_BE> listaAcciones;
        public int id { get; set; }
        public string tipo_usuario { get; set; }
        public List<Compuesto_BE> listaAcciones { get; set; }

        public TipoUsuario_BE()
        {
            listaAcciones = new List<Compuesto_BE>();
        }

        public override void AgregarAccion(Compuesto_BE p)
        {
            if (!listaAcciones.Contains(p))
            {
                listaAcciones.Add(p);
            }
        }

        public override List<Compuesto_BE> ObtenerHijos()
        {
            return this.listaAcciones;
        }

        public override void QuitarAccion(Compuesto_BE p)
        {
            if (this.listaAcciones.Any(item => item.ID_Compuesto == p.ID_Compuesto && item.Nombre == p.Nombre))
            {
                List<Compuesto_BE> aux = new List<Compuesto_BE>();
                foreach (Compuesto_BE comp in this.ObtenerHijos())
                {
                    if (comp.ID_Compuesto != p.ID_Compuesto)
                    {
                        aux.Add(comp);
                    }
                }
                this.listaAcciones = aux;
            }
        }

    }
}
