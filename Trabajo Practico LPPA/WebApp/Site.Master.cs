using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BE;
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
            user.Visible = true;
            HtmlGenericControl login = (HtmlGenericControl)this.FindControl("login");
            login.Visible = true;
            HtmlGenericControl carrito = (HtmlGenericControl)this.FindControl("carrito");
            carrito.Visible = true;
            HtmlGenericControl productos = (HtmlGenericControl)this.FindControl("productos");
            productos.Visible = true;

            if (Session["usuario"] != null)
            {
                
                LogString = "Cerrar Sesion";
                User = ((Usuario_BE)Session["usuario"]).Usuario;
                if (((Usuario_BE)Session["usuario"]).TipoUsuario.id == 1)
                {
                    //Sacamos controles de navegacion
                    //HtmlGenericControl about = (HtmlGenericControl)this.Master.FindControl("inicio");
                    about.Visible = false;
                    //HtmlGenericControl inicio = (HtmlGenericControl)this.Master.FindControl("about");
                    inicio.Visible = false;
                    //HtmlGenericControl contact = (HtmlGenericControl)this.Master.FindControl("contact");
                    contact.Visible = false;
                    //HtmlGenericControl user = (HtmlGenericControl)this.Master.FindControl("user");
                    user.Visible = false;
                    //HtmlGenericControl login = (HtmlGenericControl)this.Master.FindControl("login");
                    login.Visible = true;
                    //HtmlGenericControl carrito = (HtmlGenericControl)this.Master.FindControl("carrito");
                    carrito.Visible = false;
                    //HtmlGenericControl productos = (HtmlGenericControl)this.Master.FindControl("productos");
                    productos.Visible = false;
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