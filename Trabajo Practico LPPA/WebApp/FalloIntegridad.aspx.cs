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
    public partial class FalloIntegridad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Registros"] == null) {
                Response.Redirect("Default.aspx");
            }

            //Sacamos controles de navegacion
            HtmlGenericControl about = (HtmlGenericControl)this.Master.FindControl("inicio");
            about.Visible = false;
            HtmlGenericControl inicio = (HtmlGenericControl)this.Master.FindControl("about");
            inicio.Visible = false;
            HtmlGenericControl contact = (HtmlGenericControl)this.Master.FindControl("contact");
            contact.Visible = false;
            HtmlGenericControl user = (HtmlGenericControl)this.Master.FindControl("user");
            user.Visible = false;
            HtmlGenericControl login = (HtmlGenericControl)this.Master.FindControl("login");
            login.Visible = false;
            HtmlGenericControl carrito = (HtmlGenericControl)this.Master.FindControl("carrito");
            carrito.Visible = false;
            HtmlGenericControl productos = (HtmlGenericControl)this.Master.FindControl("productos");
            productos.Visible = false;


            List<Registro_BE> tablas = (List<Registro_BE>)Session["Registros"];
            

            if (!IsPostBack)
            {
                //(Digito Verificador) 13 - Se muestran las tablas por pantalla
                this.llenarGrid();
            }


        }
        private void llenarGrid()
        {
            GridView1.Visible = true;

            List<Registro_BE> registros = new List<Registro_BE>();

            registros = (List<Registro_BE>)Session["Registros"];
            GridView1.DataSource = registros;
            GridView1.DataBind();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.llenarGrid();
        }
    }
}