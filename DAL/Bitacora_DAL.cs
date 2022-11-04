using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BE;


namespace DAL
{
    public class Bitacora_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();
        Integridad_DAL pIntegridad = new Integridad_DAL();

        public void LLenar_Bitacora(int id_usuario, string detalle)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id_usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = id_usuario;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@detalle";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = detalle;

            DataTable Tabla = ac.EjecutarStoredProcedure("llenar_bitacora", parametros);
            string fecha = "";
            int id = 0;
            foreach (DataRow reg in Tabla.Rows)
            {
                fecha = ((DateTime)reg["fecha"]).ToString("dd/MM/yyyy hh:mm:ss");
                id = Convert.ToInt32(reg["id"].ToString());
            }
            string cadena = id.ToString() + detalle + fecha.ToString() + id_usuario.ToString();


            parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = id;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@dvh";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = pIntegridad.CalcularDVH(cadena);

            Tabla = ac.EjecutarStoredProcedure("update_bitacora_dvh", parametros);
            pIntegridad.GuardarDigitoVerificador(pIntegridad.ObtenerDVHs("Bitacora"), "Bitacora");
        }

        public List<DetalleBitacora_BE> Listar_Bitacora()
        {
            List<DetalleBitacora_BE> bitacora = new List<DetalleBitacora_BE>();

            DataTable Tabla = ac.EjecutarStoredProcedure("listar_bitacora", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                DetalleBitacora_BE detalle = new DetalleBitacora_BE();
                detalle.Id = Convert.ToInt32(reg["id"].ToString());
                detalle.Id_Usuario = Convert.ToInt32(reg["id_usuario"].ToString());
                detalle.Detalle = reg["detalle"].ToString();
                detalle.Usuario = reg["usuario"].ToString();
                detalle.Fecha = Convert.ToDateTime(reg["Fecha"].ToString());
                detalle.FechaString = detalle.Fecha.ToString(("MM/dd/yyyy HH:mm:ss"));
                bitacora.Add(detalle);
            }
            return bitacora;
        }
    }
}
