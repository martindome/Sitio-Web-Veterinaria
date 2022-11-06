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
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.IO;
using System.Xml;
using System.Threading.Tasks;

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
            TextBoxUsuarioBitacora.Attributes["onchange"] = "getBitacoraFiltrado()";
            TextBoxFechaDesde.Attributes["onchange"] = "getBitacoraFiltrado()";
            TextBoxFechaHasta.Attributes["onchange"] = "getBitacoraFiltrado()";
            TextBoxFechaHasta.Text = DateTime.Now.ToString("yyyy-MM-dd");
            TextBoxFechaDesde.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");



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
                if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).TipoUsuario.listaAcciones.Any(x => ((Accion_BE)x).detalle == "Administrador")))
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
            GridViewDigitosVerificadores.Visible = true;
            List<Registro_BE> registros = new List<Registro_BE>();
            registros = (List<Registro_BE>)Session["Registros"];
            GridViewDigitosVerificadores.DataSource = registros;
            GridViewDigitosVerificadores.DataBind();
        }

        protected void Accion_Click_Digitos(object sender, EventArgs e)
        {

            Integridad_BLL pIntegridad = new Integridad_BLL();
            pIntegridad.ReestablecerDVH();
            pIntegridad.ReestablecerDVV();
            Session["Registros"] = null;
            llenarGridVerificacion();
            Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
            string detalle = "Digitos de verificacion reestablecidos: " + ((Usuario_BE)Session["usuario"]).Usuario;
            bitacoraBLL.LLenar_Bitacora(((Usuario_BE)Session["usuario"]).IdUsuario, detalle);
            ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Restauracion realizada correctamente');", true);
        }
        #endregion

        #region Bitacora
        [WebMethod]
        public static List<DetalleBitacora_BE> ListarBitacora()
        {

            DateTime Hasta = DateTime.Now.AddDays(1);
            DateTime Desde = DateTime.Now.AddDays(-7);
            var query = from c in new Bitacora_BLL().Cargar_Bitacora() where (c.Fecha > Desde && c.Fecha < Hasta) select c;
            List<DetalleBitacora_BE> aux = query.ToList();
            aux.Sort((x, y) => DateTime.Compare(x.Fecha, y.Fecha));
            return aux;
        }

        [WebMethod]
        public static List<DetalleBitacora_BE> ListarBitacoraFiltrado(string nombre, string fechaDesde, string fechaHasta)
        {

            List<DetalleBitacora_BE> aux = new Bitacora_BLL().Cargar_Bitacora();

            DateTime Desde = DateTime.Parse(fechaDesde);
            DateTime Hasta = DateTime.Parse(fechaHasta).AddDays(1);
            var query = from c in aux where (c.Fecha >= Desde && c.Fecha <= Hasta) select c;
            aux = query.ToList();
            
            if (nombre.Length != 0) {
                query = from c in aux where (c.Usuario.Contains(nombre) || nombre.Contains(c.Usuario)) select c;
                aux = query.ToList();
            }
            
            aux.Sort((x, y) => DateTime.Compare(x.Fecha, y.Fecha));
            return aux;
        }

        protected void ButtonExportar_Click(object sender, EventArgs e)
        {
            //ACA USAMOS XML ESCRITURA
            string fechadesde = Request.Form["ctl00$MainContent$TextBoxFechaDesde"];
            string fechahasta = Request.Form["ctl00$MainContent$TextBoxFechaHasta"];

            //TextBox pTextBox = (TextBox)Admin.FindControl("TextBoxFechaDesde");
            //TextBox pTextBox = this.FindControl("TextBoxFechaDesde") as TextBox;
            //string value = pTextBox.Text;
            List <DetalleBitacora_BE> bitacora = ListarBitacoraFiltrado(TextBoxUsuarioBitacora.Text, fechadesde, fechahasta);
            //string tempPath = Path.GetTempFileName();
            string path = System.IO.Path.GetTempPath() + "bitacora.xml";
            //System.Xml.XmlTextWriter miEscritor = new System.Xml.XmlTextWriter(Server.MapPath("files//bitacora.xml"), null);
            System.Xml.XmlTextWriter miEscritor = new System.Xml.XmlTextWriter(path, null);

            miEscritor.Formatting = Formatting.Indented;
            miEscritor.WriteStartDocument();
            miEscritor.WriteStartElement("Bitacora");

            foreach (DetalleBitacora_BE b in bitacora)
            {

                miEscritor.WriteStartElement("Entrada");
                miEscritor.WriteAttributeString("ID", b.Id.ToString());
                miEscritor.WriteStartElement("ID");
                miEscritor.WriteString(b.Id.ToString());
                miEscritor.WriteEndElement();
                miEscritor.WriteStartElement("Usuario");
                miEscritor.WriteString(b.Usuario);
                miEscritor.WriteEndElement();
                miEscritor.WriteStartElement("ID Usuario");
                miEscritor.WriteString(b.Id_Usuario.ToString());
                miEscritor.WriteEndElement();
                miEscritor.WriteStartElement("Detalle");
                miEscritor.WriteString(b.Detalle);
                miEscritor.WriteEndElement();
                miEscritor.WriteStartElement("Fecha");
                miEscritor.WriteString(b.FechaString);
                miEscritor.WriteEndElement();
                miEscritor.WriteEndElement();
            }
            miEscritor.WriteEndElement();
            miEscritor.WriteEndDocument();
            miEscritor.Flush();
            miEscritor.Close();

            Response.ContentType = "xml";
            //Response.ContentType = "image/jpeg";
            string filename = "Bitacora-" + DateTime.Now.ToString("ddmmyyyyhhmmss") + ".xml";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.TransmitFile(path);
            //string path = Server.MapPath("files//bitacora.xml");
            //FileInfo file = new FileInfo(path);
            //file.Delete();
            //var deletionTask = Task.Run(() => file.Delete());
            Response.End();

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

        protected void ButtonAdministarUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Permisos.aspx");
        }

        protected void ButtonAdministrarPermisos_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Perfiles.aspx");
        }

        #endregion

        #region Desbloqueo usuario
        protected void Button4_Click(object sender, EventArgs e)
        {
            string usuarioBq = ListBoxUsuariosBloqueados.SelectedValue.ToString();
            usuarioRespuestaBLL.Desbloquear_Usuario(usuarioBq);
            ListBoxUsuariosBloqueados.Items.Remove(usuarioBq);
            Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
            string detalle = "Usuario " + usuarioBq + "  debloqueado con exito por: " + ((Usuario_BE)Session["usuario"]).Usuario;
            bitacoraBLL.LLenar_Bitacora(((Usuario_BE)Session["usuario"]).IdUsuario, detalle);
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