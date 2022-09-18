using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BE;
using BE.Composite;

namespace DAL
{
    public class Usuario_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();
        Integridad_DAL pIntegridad = new Integridad_DAL();
        public Usuario_BE loguear(string usuario, string contraseña)
        {

            string contraseña_encriptada = Calcular_HashMD5(contraseña); //Password default: Password1234!

            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@pass";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = contraseña_encriptada;

            DataTable Tabla = ac.EjecutarStoredProcedure("verificar_usuario", parametros);

            Usuario_BE usuarioBE = new Usuario_BE(); 

            foreach (DataRow reg in Tabla.Rows)
            {

                usuarioBE.Usuario = reg["usuario"].ToString();
                usuarioBE.Contraseña = reg["contraseña"].ToString();
                usuarioBE.IdUsuario = Convert.ToInt32(reg["id"].ToString());
                usuarioBE.Nombre = reg["nombre"].ToString();
                TipoUsuario_BE tipoUsuario = new TipoUsuario_BE(); 
                tipoUsuario.id = Convert.ToInt32(reg["id_tipo_usuario"].ToString());
                tipoUsuario.tipo_usuario = reg["tipo_usuario"].ToString();
                usuarioBE.TipoUsuario = tipoUsuario; 
                //usuarioBE.Bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());

                //user.Sesion.sesionIniciada = bool.Parse(reg["sesionIniciada"].ToString());

            }
            return usuarioBE;
        }

        
        public List<Compuesto_BE> Buscar_Acciones(int id_tipo_usuario)
        {
            List<Compuesto_BE> acciones = new List<Compuesto_BE>();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id_tipo_usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = id_tipo_usuario;
          

            DataTable Tabla = ac.EjecutarStoredProcedure("listar_acciones", parametros);
            foreach (DataRow reg in Tabla.Rows)
            {
                Accion_BE accion = new Accion_BE();
                accion.id = Convert.ToInt32(reg["id"].ToString());
                accion.detalle = reg["detalle"].ToString();

                acciones.Add(accion);
            }
            return acciones;
        }

        //Agregado para el bloqueo de usuario por reintentos de contraseña
        public void Bloquear_Usuario(string usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario;

            DataTable Tabla = ac.EjecutarStoredProcedure("bloquear_usuario", parametros);

            int id = 0;
            string pass = "";
            string nombre = "";
            int bloqueado = 0;
            int tipo_usuario = 0;

            foreach (DataRow reg in Tabla.Rows)
            {
                id = Convert.ToInt32(reg["id"].ToString());
                tipo_usuario = Convert.ToInt32(reg["tipo_usuario"].ToString());
                bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());
                pass = reg["contraseña"].ToString();
                nombre = reg["nombre"].ToString();
            }
            string cadena = id.ToString() + usuario + pass + nombre + bloqueado.ToString() + tipo_usuario.ToString();


            parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = id;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@dvh";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = pIntegridad.CalcularDVH(cadena);

            Tabla = ac.EjecutarStoredProcedure("update_usuario_dvh", parametros);
            pIntegridad.GuardarDigitoVerificador(pIntegridad.ObtenerDVHs("Usuario"), "Usuario");

        }

        public Usuario_BE validar_usuario_sinpassword(string usuario)
        {


            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario;


            DataTable Tabla = ac.EjecutarStoredProcedure("verificar_usuario_sinpassword", parametros);

            Usuario_BE usuarioBE = new Usuario_BE();

            foreach (DataRow reg in Tabla.Rows)
            {

                usuarioBE.Usuario = reg["usuario"].ToString();
                usuarioBE.Contraseña = reg["contraseña"].ToString();
                usuarioBE.IdUsuario = Convert.ToInt32(reg["id"].ToString());
                usuarioBE.Nombre = reg["nombre"].ToString();
                TipoUsuario_BE tipoUsuario = new TipoUsuario_BE();
                tipoUsuario.id = Convert.ToInt32(reg["id_tipo_usuario"].ToString());
                tipoUsuario.tipo_usuario = reg["tipo_usuario"].ToString();
                usuarioBE.TipoUsuario = tipoUsuario;
                usuarioBE.Bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());

            }
            return usuarioBE;
        }

        public void blanquear_password(string usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario;

            DataTable Tabla = ac.EjecutarStoredProcedure("blanquear_password", parametros);

            int id = 0;
            string pass = "";
            string nombre = "";
            int bloqueado = 0;
            int tipo_usuario = 0;

            foreach (DataRow reg in Tabla.Rows)
            {
                id = Convert.ToInt32(reg["id"].ToString());
                tipo_usuario = Convert.ToInt32(reg["tipo_usuario"].ToString());
                bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());
                pass = reg["contraseña"].ToString();
                nombre = reg["nombre"].ToString();
            }
            string cadena = id.ToString() + usuario + pass + nombre + bloqueado.ToString() + tipo_usuario.ToString();


            parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = id;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@dvh";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = pIntegridad.CalcularDVH(cadena);

            Tabla = ac.EjecutarStoredProcedure("update_usuario_dvh", parametros);
            pIntegridad.GuardarDigitoVerificador(pIntegridad.ObtenerDVHs("Usuario"), "Usuario");
        }

        public List<Usuario_BE> Listar_UsuariosBloqueados()
        {
            List<Usuario_BE> usuariosBloqueados = new List<Usuario_BE>();

            DataTable Tabla = ac.EjecutarStoredProcedure("listar_usuariosBloqueados", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Usuario_BE usuario = new Usuario_BE();
                usuario.Usuario = reg["usuario"].ToString();
                usuariosBloqueados.Add(usuario);
            }
            return usuariosBloqueados;
        }

        public void Desbloquear_Usuario(string usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario;

            DataTable Tabla = ac.EjecutarStoredProcedure("desbloquear_usuario", parametros);

            int id = 0;
            string pass = "";
            string nombre = "";
            int bloqueado = 0;
            int tipo_usuario = 0;

            foreach (DataRow reg in Tabla.Rows)
            {
                id = Convert.ToInt32(reg["id"].ToString());
                tipo_usuario = Convert.ToInt32(reg["tipo_usuario"].ToString());
                bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());
                pass = reg["contraseña"].ToString();
                nombre = reg["nombre"].ToString();
            }
            string cadena = id.ToString() + usuario + pass + nombre + bloqueado.ToString() + tipo_usuario.ToString();


            parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = id;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@dvh";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = pIntegridad.CalcularDVH(cadena);

            Tabla = ac.EjecutarStoredProcedure("update_usuario_dvh", parametros);
            pIntegridad.GuardarDigitoVerificador(pIntegridad.ObtenerDVHs("Usuario"), "Usuario");
        }

        #region restore
        public bool RestoreDB(string dire)
        {


            string query = @"USE master                          
                        ALTER DATABASE VeterinariaLPPA 
                        SET SINGLE_USER WITH ROLLBACK IMMEDIATE
                        RESTORE DATABASE VeterinariaLPPA  FROM DISK = '" + dire + "' WITH REPLACE " +
                        "ALTER DATABASE VeterinariaLPPA  SET MULTI_USER";

            bool status = ac.ExecuteQuery(query);

            if (status == true)
            {
                return true;
            }
            return false;
        }
        public bool TakeDB(string filename, string dire)
        {
            string query = string.Empty;

            string nomb = filename
                + "_" + Convert.ToString(DateTime.Today.Day) + "_"
                + Convert.ToString(DateTime.Today.Month)
                + "_"
                + Convert.ToString(DateTime.Today.Year);

            string texto1 = "";
            string info = "";

            texto1 += info;
            texto1 += string.Format("DISK = N'" + dire + "\\" + nomb + ".bak'");
            info = ",";

            query = @"BACKUP DATABASE["
                + "VeterinariaLPPA"
                + "] TO "
                + texto1
                + " WITH NOFORMAT, NOINIT, NAME = N'"
                + "VeterinariaLPPA"
                + "-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            ac.ExecuteQuery(query);
            return true;
        }
        #endregion

        #region private functions
        private string Calcular_HashMD5(string cadena)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] cadenaBytes = System.Text.Encoding.ASCII.GetBytes(cadena);
                byte[] hashBytes = md5.ComputeHash(cadenaBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }

        }
        private string Calcular_HashSHA256(string cadena)
        {
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] cadenaBytes = System.Text.Encoding.ASCII.GetBytes(cadena);
                byte[] hashBytes = sha256.ComputeHash(cadenaBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        #endregion
    }
}
