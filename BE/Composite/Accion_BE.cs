using System;
using System.Collections.Generic;
using System.Text;

namespace BE.Composite
{
    public class Accion_BE: Compuesto_BE
    {
        public int id { get; set; }
        public string detalle { get; set; }

        public override void AgregarAccion(Compuesto_BE p)
        {
            throw new NotImplementedException();
        }

        public override void QuitarAccion(Compuesto_BE p)
        {
            throw new NotImplementedException();
        }

        public override List<Compuesto_BE> ObtenerHijos()
        {
            return new List<Compuesto_BE>();
        }
    }
}
