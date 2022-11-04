using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Linq;
using BE;
using BLL;


namespace WebApp
{

    /// <summary>
    /// Descripción breve de BitacoraService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
    [ScriptService]
    public class BitacoraService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<DetalleBitacora_BE> ListarBitacora()
        {
            
            DateTime Hasta = DateTime.Now.AddDays(1);
            DateTime Desde = DateTime.Now.AddDays(-7);
            var query = from c in new Bitacora_BLL().Cargar_Bitacora() where (c.Fecha > Desde && c.Fecha < Hasta) select c;
            List<DetalleBitacora_BE> aux = query.ToList();
            aux.Sort((x, y) => DateTime.Compare(x.Fecha, y.Fecha));
            return aux;
        }

        [WebMethod]
        public List<DetalleBitacora_BE> ListarBitacoraFiltrado(string nombre, string fechaDesde, string fechaHasta)
        {
            var query = from c in new Bitacora_BLL().Cargar_Bitacora() where (c.Usuario.Contains(nombre) || nombre.Contains(c.Usuario)) select c;
            DateTime Desde = DateTime.Parse(fechaDesde);
            DateTime Hasta = DateTime.Parse(fechaHasta).AddDays(1);
            List<DetalleBitacora_BE> aux =  query.ToList();
            query = from c in aux where (c.Fecha >= Desde && c.Fecha <= Hasta) select c;
            aux = query.ToList();
            aux.Sort((x, y) => DateTime.Compare(x.Fecha, y.Fecha));
            return aux;
        }
    }
}
