using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BE;
using BE.Composite;
using System.Web.UI.HtmlControls;

namespace WebApp
{
    public partial class SiteMaster : MasterPage
    {
        public string User;
        public string LogString;
        protected void Page_Load(object sender, EventArgs e)
        {

            //Sacamos controles de navegacion
            HtmlGenericControl about = (HtmlGenericControl)this.FindControl("inicio");
            about.Visible = true;
            HtmlGenericControl inicio = (HtmlGenericControl)this.FindControl("about");
            inicio.Visible = true;
            HtmlGenericControl contact = (HtmlGenericControl)this.FindControl("contact");
            contact.Visible = true;
            HtmlGenericControl user = (HtmlGenericControl)this.FindControl("user");
            user.Visible = false;
            HtmlGenericControl login = (HtmlGenericControl)this.FindControl("login");
            login.Visible = true;
            HtmlGenericControl carrito = (HtmlGenericControl)this.FindControl("carrito");
            carrito.Visible = true;
            HtmlGenericControl productos = (HtmlGenericControl)this.FindControl("productos");
            productos.Visible = true;
            HtmlGenericControl stock = (HtmlGenericControl)this.FindControl("stock");
            stock.Visible = false;
            HtmlGenericControl admin = (HtmlGenericControl)this.FindControl("admin");
            admin.Visible = false;

            if (Session["usuario"] != null)
            {
                
                LogString = "Cerrar Sesion";
                User = ((Usuario_BE)Session["usuario"]).Usuario;
                user.Visible = true;
                if (((Usuario_BE)Session["usuario"]).TipoUsuario.id == 1)
                {
                    //Sacamos controles de navegacion
                    admin.Visible = true;
                    login.Visible = true;
                    Session["carrito"] = null;
                }
                Usuario_BE usuario = (Usuario_BE)Session["usuario"];
                if ((usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Comprar")))
                {
                    productos.Visible = true;
                    carrito.Visible = true;
                }
                if ((usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Consultar")))
                {
                    productos.Visible = true;
                }
                if ((usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Agregar Item")))
                {
                    stock.Visible = true;
                }
                if ((usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Borrar Item")))
                {
                    stock.Visible = true;
                }
                if ((usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Cancelar Compra")))
                {
                    productos.Visible = true;
                    carrito.Visible = true;
                }
                if ((usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Backup")))
                {
                    admin.Visible = true;
                }
                if ((usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Restore")))
                {
                    admin.Visible = true;
                }
                if ((usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Desbloqueo de usuario")))
                {
                    admin.Visible = true;
                }
                if ((usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Ver Bitacora")))
                {
                    admin.Visible = true;
                }
            }
            else
            {
                LogString = "Acceder";
                User = null;
            }
            
        }
    }
}