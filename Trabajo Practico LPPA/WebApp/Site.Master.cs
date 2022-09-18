using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BE;

namespace WebApp
{
    public partial class SiteMaster : MasterPage
    {
        public string User;
        public string LogString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                
                LogString = "Cerrar Sesion";
                User = ((Usuario_BE)Session["usuario"]).Usuario;
            }
            else
            {
                LogString = "Acceder";
                User = null;
            }
        }
    }
}