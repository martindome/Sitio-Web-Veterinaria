using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BE;
using BE.Composite;
using BLL;
using System.IO;

namespace WebApp
{
    public partial class BackupRestore : System.Web.UI.Page
    {
        Usuario_BE usuarioRespuesta = new Usuario_BE();
        Usuario_BLL usuarioRespuestaBLL = new Usuario_BLL();
        Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
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

            usuarioRespuesta = (Usuario_BE)Session["usuario"];
            if (usuarioRespuesta == null || !(((Usuario_BE)Session["usuario"]).TipoUsuario.listaAcciones.Any(x => ((Accion_BE)x).detalle == "BackupRestore")))
            {
                Response.Redirect("Default.aspx");
            }
            id_restore.Visible = false;
            Label6.Text = "Ingrese el nombre que asignará al Backup";
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // BACKUP
            if (RadioButtonList1.SelectedValue == "0")
            {
                Label8.Visible = false;
                Label7.Visible = false;
                Label6.Text = "Ingrese el nombre que asignará al Backup";
                id_restore.Visible = false;
                id_backup.Visible = true;
            }
            else
            {
                // RESTORE
                string ruta = Server.MapPath("~/" + "//Backups");
                ListBox1.Items.Clear();
                foreach (string file in Directory.GetFiles(ruta))
                {

                    ListBox1.Items.Add(Path.GetFileName(file));
                }

                Label7.Visible = false;
                Label6.Text = "Seleccione el archivo para realizar el Restore";
                id_restore.Visible = true;
                id_backup.Visible = false;
            }
        }

        protected void Accion_Click(object sender, EventArgs e)
        {
            // Restore
            if (RadioButtonList1.SelectedValue == "1")
            {
                if (ListBox1.SelectedValue.ToString() != null && ListBox1.SelectedValue.ToString() != "")
                {
                    GetParam(ListBox1.SelectedValue.ToString());
                    Label8.Visible = false;
                    usuarioRespuestaBLL.RestoreDB(Session["Ruta"].ToString());
                    Label7.Text = "El Restore se ha realizado correctamente!";
                    Label7.Visible = true;
                    Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
                    string detalle = "Restauracion realizada con exito por: " + ((Usuario_BE)Session["usuario"]).Usuario;
                    bitacoraBLL.LLenar_Bitacora(((Usuario_BE)Session["usuario"]).IdUsuario, detalle);
                }
                else
                {
                    Label8.Visible = true;
                }

            }
            //Backup
            if (RadioButtonList1.SelectedValue == "0" && TXTNombre.Text != null)
            {
                string nombre = TXTNombre.Text;
                Guardar(nombre);
                usuarioRespuestaBLL.TakeDB(nombre, Convert.ToString(Session["Ruta"]));
                Label7.Text = "El Backup se ha realizado correctamente! el mismo se guardó en raiz del proyecto/Trabajo Practico LPPA/Backups";
                Label7.Visible = true;
                Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
                string detalle = "Backup realizado con exito por: " + ((Usuario_BE)Session["usuario"]).Usuario;
                bitacoraBLL.LLenar_Bitacora(((Usuario_BE)Session["usuario"]).IdUsuario, detalle);
            }

        }
        protected void GetParam(string nombre)
        {
            //Nombre path
            string ruta = Server.MapPath("~/" + "\\Backups\\" + nombre);
            Session["Ruta"] = ruta;
            Session["Nombre"] = nombre;
        }

        //Guardo en el raiz del servidor /Backup el archivo generado en la BD
        protected void Guardar(string nombre)
        {
            if (nombre != null)
            {
                //Nombre Archivo
                Session["Nombre"] = nombre;

                //Nombre path
                string ruta = Server.MapPath("~/" + "//Backups");
                FileUpload1.SaveAs(ruta + nombre);
                Session["Ruta"] = ruta;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin.aspx");
        }
    }

}