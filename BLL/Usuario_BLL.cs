using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using BE;
using BE.Composite;



namespace BLL
{
    public class Usuario_BLL
    {
        Usuario_DAL mapper = new Usuario_DAL();

        public List<Usuario_BE> ListarUsuarios()
        {
            return mapper.Listar_Usuarios();
        }

        public Usuario_BE Verificar_Usuario(string usuario, string contraseña)
        {
            return mapper.loguear(usuario, contraseña);
        }

        public List<Compuesto_BE> Buscar_Acciones(int id_tipousuario)
        {
           return mapper.Buscar_Acciones(id_tipousuario);
        }

        //public void LLenar_Bitacora(int id_usuario, string detalle)
        //{
        //    mapper.LLenar_Bitacora(id_usuario, detalle);
        //}

        //public List<DetalleBitacora_BE> Cargar_Bitacora()
        //{
        //    return mapper.Listar_Bitacora();
        //}

        //Agregado bloqueo por intentos fallidos
        public void Bloquear_usuario(string usuario)
        {
             mapper.Bloquear_Usuario(usuario);
        }

        public Usuario_BE Verificar_Usuario_sinpassword(string usuario)
        {
            return mapper.validar_usuario_sinpassword(usuario);
        }

        public void Registar_Cliente(Usuario_BE usuarioBE)
        {
            mapper.registrar_usuario_cliente(usuarioBE);
        }

        public void Registar_Usuario_Admin(Usuario_BE usuarioBE)
        {
            mapper.registrar_usuario_admin(usuarioBE);
        }

        public void blanquear_password(string usuario)
        {
             mapper.blanquear_password(usuario);
        }

        public void CambiarPerfil(string usuario, int tipo_usuario)
        {
            mapper.cambiar_perfil(usuario, tipo_usuario);
        }

        public bool TakeDB(string filename, string dire)
        {
            return mapper.TakeDB(filename, dire);
        }
        public bool RestoreDB(string dire)
        {
            return mapper.RestoreDB(dire);
        }

        public List<Usuario_BE> Usuarios_Bloquedos() 
        {
            return mapper.Listar_UsuariosBloqueados();
        }

        public void Desbloquear_Usuario(string usuario)
        {
            mapper.Desbloquear_Usuario(usuario);
        }

    }
}

