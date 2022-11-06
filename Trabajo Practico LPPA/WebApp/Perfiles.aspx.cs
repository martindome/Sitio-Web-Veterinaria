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
    public partial class Perfiles : System.Web.UI.Page
    {
        Permisos_BLL mapperPermisos = new Permisos_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).TipoUsuario.id == 1) )
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).TipoUsuario.listaAcciones.Any(x => ((Accion_BE)x).detalle == "AdministrarPerfiles")))
            {
                //Sacamos controles de navegacion
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                GridView1.Items.Clear();
                GridView2.Items.Clear();
                GridView3.Items.Clear();
                GridView2.Enabled = false;
                GridView3.Enabled = false;
                ButtonAplicarAgregar.Enabled = false;
                ButtonAplicarBorrar.Enabled = false;

                List<TipoUsuario_BE> permisos = mapperPermisos.ListarPermisos();
                permisos.Sort((x, y) => x.tipo_usuario.CompareTo(y.tipo_usuario));

                foreach (TipoUsuario_BE b in permisos)
                {
                    GridView1.Items.Add(b.tipo_usuario);
                }
            }
        }

        protected void ButtonAplicarAgregar_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != "" && GridView3.SelectedValue != "")
            {
                List<Accion_BE> acciones = mapperPermisos.ListarAcciones();
                List<TipoUsuario_BE> permisos = mapperPermisos.ListarPermisos();
                TipoUsuario_BE permiso = permisos.FirstOrDefault(x => x.tipo_usuario == GridView1.SelectedValue);
                Accion_BE accion = acciones.FirstOrDefault(x => x.detalle == GridView3.SelectedValue);
                mapperPermisos.AgregarPermisoAccion(permiso.id, accion.id);
                llener_grids();
            }
        }

        protected void ButtonAplicarBorrar_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != "" && GridView2.SelectedValue != "")
            {
                List<Accion_BE> acciones = mapperPermisos.ListarAcciones();
                List<TipoUsuario_BE> permisos = mapperPermisos.ListarPermisos();
                TipoUsuario_BE permiso = permisos.FirstOrDefault(x => x.tipo_usuario == GridView1.SelectedValue);
                Accion_BE accion = acciones.FirstOrDefault(x => x.detalle == GridView2.SelectedValue);
                mapperPermisos.BorrarPermisoAccion(permiso.id, accion.id);
                llener_grids();
            }
        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (GridView1.SelectedValue != "")
            {
                GridView2.Enabled = true;
                GridView3.Enabled = true;
                ButtonAplicarAgregar.Enabled = true;
                ButtonAplicarBorrar.Enabled = true;
                llener_grids();
            }
        }

        protected void llener_grids()
        {
            GridView2.Items.Clear();
            GridView3.Items.Clear();
            List<Accion_BE> acciones = mapperPermisos.ListarAcciones();
            List<TipoUsuario_BE> permisos = mapperPermisos.ListarPermisos();
            TipoUsuario_BE permiso = permisos.FirstOrDefault(x => x.tipo_usuario == GridView1.SelectedValue);
            foreach (Accion_BE a in permiso.listaAcciones)
            {
                GridView2.Items.Add(a.detalle);
            }
            foreach (Accion_BE a in acciones)
            {
                if (!permiso.listaAcciones.Any(x => ((Accion_BE)x).detalle == a.detalle))
                {
                    GridView3.Items.Add(a.detalle);
                }
            }
        }

        protected void ButtonSeleccionarPermiso_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                GridView2.Enabled = true;
                GridView3.Enabled = true;
                ButtonAplicarAgregar.Enabled = true;
                ButtonAplicarBorrar.Enabled = true;
                llener_grids();
            }
        }

        protected void ButtonAgregarPermiso_Click(object sender, EventArgs e)
        {
            if (TextBoxAgregarPermiso.Text != "")
            {
                if(!mapperPermisos.ListarPermisos().Any(x => x.tipo_usuario == TextBoxAgregarPermiso.Text))
                {
                    mapperPermisos.AgregarPermiso(TextBoxAgregarPermiso.Text);
                    GridView1.Items.Clear();
                    GridView2.Items.Clear();
                    GridView3.Items.Clear();
                    GridView2.Enabled = false;
                    GridView3.Enabled = false;
                    ButtonAplicarAgregar.Enabled = false;
                    ButtonAplicarBorrar.Enabled = false;
                    List<TipoUsuario_BE> permisos = mapperPermisos.ListarPermisos();
                    permisos.Sort((x, y) => x.tipo_usuario.CompareTo(y.tipo_usuario));
                    foreach (TipoUsuario_BE b in permisos)
                    {
                        GridView1.Items.Add(b.tipo_usuario);
                    }
                }
            }
        }

        protected void ButtonSalir_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}