using System;
using System.Collections.Generic;
using System.Text;

namespace BE.Composite
{
    public abstract class Compuesto_BE
    {
        public string Nombre { get; set; }
        public int ID_Compuesto { get; set; }
        public string Descripcion { get; set; }

        public abstract void AgregarAccion(Compuesto_BE p);

        public abstract void QuitarAccion(Compuesto_BE p);

        public abstract List<Compuesto_BE> ObtenerHijos();

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
