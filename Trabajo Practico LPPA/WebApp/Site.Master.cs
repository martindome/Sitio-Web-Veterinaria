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
        Integridad_BLL pIntegridad = new Integridad_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Chequeamos integridad
            if (Session["Registros"] == null)
            {
                // (Digito Verificador) 1 - Se chequea que la integridad DVH
                List<Registro_BE> RegistrosDVH = pIntegridad.ChequearDVH();
                //(Digito Verificador) 7 - Se obtienen las tablas con errores de verificacion
                List<Registro_BE> RegistrosDVV = pIntegridad.ChequearDVV();
                //(Digito Verificador) 12 - Si hay tablas con errores se envian para mostrar por pantalla
                if (null != RegistrosDVH || null != RegistrosDVV)
                {
                    List<Registro_BE> Registros = new List<Registro_BE>();
                    if (null != RegistrosDVH) { Registros.AddRange(RegistrosDVH); }
                    if (null != RegistrosDVV) { Registros.AddRange(RegistrosDVV); }
                    Session["Registros"] = Registros;
                    Response.Redirect("FalloIntegridad.aspx");
                }
                else
                {
                    // No hay registros que se encontraron maliciosos en la session
                    Session["Registros"] = new List<Registro_BE>();
                }
            }


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


            //Control de redireccion para integridad
            if (Session["Registros"] != null && ((List<Registro_BE>)Session["Registros"]).Count > 0 && Page.Title != "FalloIntegridad")
            {
                if (Session["usuario"] == null){
                    if (Page.Title != "LogIn") 
                    { 
                        Response.Redirect("FalloIntegridad.aspx"); 
                    }
                }
                else
                {
                    if (((Usuario_BE)Session["usuario"]).TipoUsuario.id != 1)
                    {
                        Response.Redirect("FalloIntegridad.aspx");
                    }
                    else
                    {
                        if (Page.Title != "FalloIntegridad" && Page.Title != "Admin")
                        {
                            Response.Redirect("FalloIntegridad.aspx");
                        }
                    }
                }
            }

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