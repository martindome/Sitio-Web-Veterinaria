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
    public partial class Permisos : System.Web.UI.Page
    {
        Usuario_BLL mapperUsuarios = new Usuario_BLL();
        Permisos_BLL mapperPermisos = new Permisos_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).TipoUsuario.id == 1))
            {
                //Sacamos controles de navegacion
                Response.Redirect("Default.aspx");
            }
            
            if (!IsPostBack)
            {
                GridView1.Items.Clear();
                GridView2.Items.Clear();

                List<TipoUsuario_BE> permisos = mapperPermisos.ListarPermisos();
                List<Usuario_BE> usuarios = mapperUsuarios.ListarUsuarios();
                usuarios.Sort((x,y) => x.Usuario.CompareTo(y.Usuario));
                permisos.Sort((x, y) => x.tipo_usuario.CompareTo(y.tipo_usuario));

                foreach(Usuario_BE u in usuarios)
                {
                    GridView1.Items.Add(u.Usuario);
                }
                foreach (TipoUsuario_BE b in permisos)
                {
                    GridView2.Items.Add(b.tipo_usuario);
                }
            }
        }

        protected void ButtonAplicar_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != "" && GridView2.SelectedValue != "")
            {
                string usuario = GridView1.SelectedValue;
                string tipo_usuario = GridView2.SelectedValue;
                TipoUsuario_BE p = mapperPermisos.ListarPermisos().FirstOrDefault(permiso => permiso.tipo_usuario == tipo_usuario);

                mapperUsuarios.CambiarPerfil(usuario, p.id);
                LabelAccion.Text = "Perfil cambiado cerrectamente";
            }
            else
            {
                LabelAccion.Text = "Error al cambiar perfil";
            }
        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin.aspx");
        }
    }
}