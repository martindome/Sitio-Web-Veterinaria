using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BE;
using BLL;
using BE.Composite;
using System.Data;

namespace WebApp
{
    public partial class Admin : System.Web.UI.Page
    {
        Usuario_BE usuarioRespuesta = new Usuario_BE();
        Usuario_BLL usuarioRespuestaBLL = new Usuario_BLL();
        Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            TextBoxUsuarioBitacora.Attributes["onkeydown"] = "getBitacoraFiltrado()";


            //Sacamos controles de navegacion
            HtmlGenericControl about = (HtmlGenericControl)this.Master.FindControl("inicio");
            about.Visible = false;
            HtmlGenericControl inicio = (HtmlGenericControl)this.Master.FindControl("about");
            inicio.Visible = false;
            HtmlGenericControl contact = (HtmlGenericControl)this.Master.FindControl("contact");
            contact.Visible = false;
            HtmlGenericControl user = (HtmlGenericControl)this.Master.FindControl("user");
            user.Visible = false;
            HtmlGenericControl carrito = (HtmlGenericControl)this.Master.FindControl("carrito");
            carrito.Visible = false;
            HtmlGenericControl productos = (HtmlGenericControl)this.Master.FindControl("productos");
            productos.Visible = false;

            if (!IsPostBack) {
                if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).TipoUsuario.id == 1))
                {
                    //Sacamos controles de navegacion
                    Response.Redirect("Default.aspx");
                }


                if (Session["fechas"] == null)
                {
                    Session["fechas"] = new List<DateTime>();
                }

                usuarioRespuesta = (Usuario_BE)Session["usuario"];
                Label1.Text = "Bienvenido " + usuarioRespuesta.Nombre + " Usted tiene permisos de: " + usuarioRespuesta.TipoUsuario.tipo_usuario;

                if (usuarioRespuesta == null || usuarioRespuesta.TipoUsuario.id != 1)
                {
                    Response.Redirect("Default.aspx");
                }
                ListBoxPermisosUsuario.Items.Clear();
                foreach (Accion_BE accion in usuarioRespuesta.TipoUsuario.listaAcciones)
                {
                    ListBoxPermisosUsuario.Items.Add(accion.detalle);
                }
                //listado de usuarios bloqueados
                ListBoxUsuariosBloqueados.Items.Clear();
                foreach (Usuario_BE usuario in usuarioRespuestaBLL.Usuarios_Bloquedos())
                {
                    ListBoxUsuariosBloqueados.Items.Add(usuario.Usuario);
                }
                //this.llenarGrid();
                if (!IsPostBack)
                {
                    //(Digito Verificador) 13 - Se muestran las tablas por pantalla
                    this.llenarGridVerificacion();
                }
            }

        }

        #region Verificacion
        private void llenarGridVerificacion()
        {
            GridView1.Visible = true;

            List<Registro_BE> registros = new List<Registro_BE>();

            registros = (List<Registro_BE>)Session["Registros"];
            GridViewDigitosVerificadores.DataSource = registros;
            GridViewDigitosVerificadores.DataBind();
        }

        //protected void OnPaging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    this.llenarGridVerificacion();
        //}
        protected void Accion_Click_Digitos(object sender, EventArgs e)
        {
            Integridad_BLL pIntegridad = new Integridad_BLL();
            pIntegridad.ReestablecerDVH();
            pIntegridad.ReestablecerDVV();
            Session["Registros"] = null;
            llenarGridVerificacion();
            ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Restauracion realizada correctamente');", true);
        }
        #endregion

        #region Bitacora
        protected void ButtonLimpiarFiltros_Click(object sender, EventArgs e)
        {
            TextBoxUsuarioFiltro.Text = "";
            ((List<DateTime>)Session["fechas"]).Clear();
            CalendarBitacora.SelectedDates.Clear();
            this.llenarGrid();
        }

        protected void Button_Filtrar(object sender, EventArgs e)
        {
            
            this.llenarGrid();
        }

        private void llenarGrid()
        {
            string detalle = "Consulta de bitacora - Usuario: " + usuarioRespuesta.Usuario;
            bitacoraBLL.LLenar_Bitacora(usuarioRespuesta.IdUsuario, detalle);
            GridView1.Visible = true;

            List<DetalleBitacora_BE> bitacora = new List<DetalleBitacora_BE>();

            bitacora = bitacoraBLL.Cargar_Bitacora();
            if (TextBoxUsuarioFiltro.Text != "")
            {
                bitacora = bitacora.FindAll(FilterFunc);
            }
            if (((List<DateTime>)Session["fechas"]).Count > 0)
            {
                bitacora = bitacora.FindAll(FilterFuncFecha);
            }
            bitacora.Sort((X, Y) => DateTime.Compare(X.Fecha, Y.Fecha));
            GridView1.DataSource = bitacora;
            GridView1.DataBind();
            if (bitacora.Count == 0)
            {

            }
            else
            {

            }
               
        }

        [System.Web.Services.WebMethod]
        public static void llenarGridAJAX()
        {
            System.Console.WriteLine("Si");

        }

        protected void seleccionFecha(object sender, EventArgs e)
        {
            if (null != CalendarBitacora.SelectedDates)
            {
                ((List<DateTime>)Session["fechas"]).Clear();
                foreach (DateTime fecha in CalendarBitacora.SelectedDates)
                {
                    ((List<DateTime>)Session["fechas"]).Add(fecha);
                }
            }
            llenarGrid();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.llenarGrid();
        }

        protected void textBox1_TextChanged(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private bool FilterFunc(DetalleBitacora_BE detalle)
        {
            if (detalle.Usuario.Contains(TextBoxUsuarioFiltro.Text) || TextBoxUsuarioFiltro.Text.Contains(detalle.Usuario))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool FilterFuncFecha(DetalleBitacora_BE detalle)
        {
            DateTime fechaInicio = ((List<DateTime>)Session["fechas"])[0];
            DateTime fechaFin = ((List<DateTime>)Session["fechas"])[((List<DateTime>)Session["fechas"]).Count - 1].AddDays(1);
            DateTime f = new DateTime(detalle.Fecha.Year, detalle.Fecha.Month, detalle.Fecha.Day);
            if (f >= fechaInicio && f < fechaFin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Realizar Backup
        protected void Accion_Click(object sender, EventArgs e)
        {
            Response.Redirect("/BackupRestore.aspx");
        }
        #endregion

        #region Nuevo usuario
        protected void CrearUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CrearUsuario.aspx");
        }
        #endregion

        #region Desbloqueo usuario
        protected void Button4_Click(object sender, EventArgs e)
        {
                string usuarioBq = ListBoxUsuariosBloqueados.SelectedValue.ToString();
                usuarioRespuestaBLL.Desbloquear_Usuario(usuarioBq);
                ListBoxUsuariosBloqueados.Items.Remove(usuarioBq);
        }

        protected void ListBoxUsuariosBloqueados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string usuarioBq = ListBoxUsuariosBloqueados.SelectedValue.ToString();
            usuarioRespuestaBLL.Desbloquear_Usuario(usuarioBq);
            ListBoxUsuariosBloqueados.Items.Remove(usuarioBq);
        }
        #endregion
    }
}