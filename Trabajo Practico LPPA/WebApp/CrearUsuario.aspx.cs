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
    public partial class CrearUsuario : System.Web.UI.Page
    {
        Usuario_BLL usuarioBLL = new Usuario_BLL();
        Usuario_BE usuarioBE = new Usuario_BE();
        Permisos_BLL permisosBLL = new Permisos_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).TipoUsuario.listaAcciones.Any(x => ((Accion_BE)x).detalle == "CrearUsuario")))
                {
                    //Sacamos controles de navegacion
                    Response.Redirect("Default.aspx");
                }
                List<TipoUsuario_BE> permisos = permisosBLL.ListarPermisos();
                foreach(TipoUsuario_BE permiso in permisos)
                {
                    GridView2.Items.Add(permiso.tipo_usuario);
                }
            }
        }

        protected void Button1_Click(object o, EventArgs e)
        {
            if (IsValid)
            {
                usuarioBE = usuarioBLL.Verificar_Usuario_sinpassword(TextBoxUsername.Text);
                if (string.IsNullOrEmpty(usuarioBE.Usuario) && GridView2.SelectedValue != "")
                {
                    usuarioBE = new Usuario_BE();
                    usuarioBE.Nombre = TextBoxNombre.Text;
                    usuarioBE.Usuario = TextBoxUsername.Text;
                    usuarioBE.Contraseña = TextBoxPassword.Text;
                    usuarioBE.Bloqueado = 0;
                    usuarioBE.TipoUsuario = new TipoUsuario_BE();
                    usuarioBE.TipoUsuario.id = permisosBLL.ListarPermisos().FirstOrDefault(x => x.tipo_usuario == GridView2.SelectedValue).id;
                    usuarioBLL.Registar_Usuario_Admin(usuarioBE);

                    Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
                    string detalle = "Registro - Usuario: " + usuarioBE.Usuario;
                    bitacoraBLL.LLenar_Bitacora(0, detalle);
                    Label1.Text = "Usuario creado con exito";
                }
                else
                {
                    Label1.Text = "Usuario Existente";
                    Label1.Visible = true;
                }
            }
        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}