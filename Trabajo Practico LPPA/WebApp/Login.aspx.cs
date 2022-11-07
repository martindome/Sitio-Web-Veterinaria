using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using BLL;
using BE;
using BE.Composite;


namespace WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        Usuario_BLL usuarioBLL = new Usuario_BLL();
        Usuario_BE usuarioBE = new Usuario_BE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    Session["usuario"] = null;
                    Response.Redirect("Default.aspx");
                }
                if (Request.Cookies["UserName"] != null)
                {
                    LoginControl.UserName = Request.Cookies["UserName"].Value;
                }
                LoginControl.CreateUserText = "Registrarse";
                LoginControl.CreateUserUrl = "Registrarse.aspx";
            }
            
        }

        protected void Button2_Click(object o, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }

        protected void LoginControl_Authenticate(object sender, AuthenticateEventArgs e)
        {
            usuarioBE = usuarioBLL.Verificar_Usuario_sinpassword(LoginControl.UserName.ToString());
            //Verificar si existe y si esta bloqueado
            if (!string.IsNullOrEmpty(usuarioBE.Usuario) && (usuarioBE.Bloqueado < 3))
            {
                //Verificar si la password esta correcta
                usuarioBE = usuarioBLL.Verificar_Usuario(LoginControl.UserName.ToString(), LoginControl.Password.ToString());
                if (!string.IsNullOrEmpty(usuarioBE.Usuario))
                {
                    //Trae el perfil del usuario de la base (con composite)
                    usuarioBE.TipoUsuario.listaAcciones = usuarioBLL.Buscar_Acciones(usuarioBE.TipoUsuario.id);
                    //Bloqueado se pone 0
                    usuarioBLL.blanquear_password(LoginControl.UserName.ToString());
                    //Guardamos el objeto usuario en la variables de sesion
                    Session["usuario"] = usuarioBE;
                    //Llenamos la bitacora
                    Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
                    string detalle = "Inicio de Sesion - Usuario: " + usuarioBE.Usuario;
                    bitacoraBLL.LLenar_Bitacora(usuarioBE.IdUsuario, detalle);
                    if (LoginControl.RememberMeSet)
                    {

                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["UserName"].Value = LoginControl.UserName.ToString();
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    }
                    if (usuarioBE.TipoUsuario.id == 1)
                    {
                        Response.Redirect("Admin.aspx");
                    }
                    Response.Redirect("Default.aspx");
                }
                //contraseña incorrecta aumentar contador bloqueado en 1
                else
                {
                    usuarioBLL.Bloquear_usuario(LoginControl.UserName.ToString());
                    Label1.Text = "Usuario o clave invalida";
                    Label1.Visible = true;
                }
            }
            else if (usuarioBE.Bloqueado == 3)
            {
                Label1.Text = "Su usuario esta bloqueado. Contactar administrador.";
                Label1.Visible = true;
            }

            else
            {
                //Usuario o contraseña invalidos
                Label1.Text = "Usuario o clave invalida";
                Label1.Visible = true;
            }
        }

        //protected void Button1_Click(object o, EventArgs e)
        //{
        //    usuarioBE = usuarioBLL.Verificar_Usuario_sinpassword(LoginControl.UserName.ToString());
        //    //Verificar si existe y si esta bloqueado
        //    if (!string.IsNullOrEmpty(usuarioBE.Usuario) && (usuarioBE.Bloqueado < 3))
        //    {
        //        //Verificar si la password esta correcta
        //        usuarioBE = usuarioBLL.Verificar_Usuario(LoginControl.UserName.ToString(), LoginControl.Password.ToString());
        //        if (!string.IsNullOrEmpty(usuarioBE.Usuario))
        //        {
        //            //Trae el perfil del usuario de la base (con composite)
        //            usuarioBE.TipoUsuario.listaAcciones = usuarioBLL.Buscar_Acciones(usuarioBE.TipoUsuario.id);
        //            //Bloqueado se pone 0
        //            usuarioBLL.blanquear_password(LoginControl.UserName.ToString());
        //            //Guardamos el objeto usuario en la variables de sesion
        //            Session["usuario"] = usuarioBE;
        //            //Llenamos la bitacora
        //            Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
        //            string detalle = "Inicio de Sesion - Usuario: " + usuarioBE.Usuario;
        //            bitacoraBLL.LLenar_Bitacora(usuarioBE.IdUsuario, detalle);
        //            if (usuarioBE.TipoUsuario.id == 1)
        //            {
        //                Response.Redirect("Admin.aspx");
        //            }
        //            Response.Redirect("Default.aspx");
        //        }
        //        //contraseña incorrecta aumentar contador bloqueado en 1
        //        else
        //        {
        //            usuarioBLL.Bloquear_usuario(LoginControl.UserName.ToString());
        //            Label1.Text = "Usuario o clave invalida";
        //            Label1.Visible = true;
        //        }
        //    }
        //    else if (usuarioBE.Bloqueado == 3)
        //    {
        //        Label1.Text = "Su usuario esta bloqueado. Contactar administrador.";
        //        Label1.Visible = true;
        //    }

        //    else
        //    {
        //        //Usuario o contraseña invalidos
        //        Label1.Text = "Usuario o clave invalida";
        //        Label1.Visible = true;
        //    }
        //}
    }
}