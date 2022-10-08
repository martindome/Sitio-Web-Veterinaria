using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BE.Composite;
using BLL;

namespace WebApp
{
    public partial class Registrarse : System.Web.UI.Page
    {
        Usuario_BLL usuarioBLL = new Usuario_BLL();
        Usuario_BE usuarioBE = new Usuario_BE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session["usuario"] = null;
                Response.Redirect("Default.aspx");
            }
            Label1.Visible = false;
        }

        protected void Button1_Click(object o, EventArgs e)
        {
            if (IsValid)
            {
                usuarioBE = usuarioBLL.Verificar_Usuario_sinpassword(TextBoxUsername.Text);
                if (string.IsNullOrEmpty(usuarioBE.Usuario))
                {
                    usuarioBE = new Usuario_BE();
                    usuarioBE.Nombre = TextBoxNombre.Text;
                    usuarioBE.Usuario = TextBoxUsername.Text;
                    usuarioBE.Contraseña = TextBoxPassword.Text;
                    usuarioBE.Bloqueado = 0;
                    usuarioBLL.Registar_Cliente(usuarioBE);

                    Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
                    string detalle = "Registro - Usuario: " + usuarioBE.Usuario;
                    bitacoraBLL.LLenar_Bitacora(0, detalle);
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Label1.Text = "Usuario Existente";
                    Label1.Visible = true;
                }
            }
        }
    }
}