using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["idVenta"];
            int Id;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out Id))
            {
                IdVenta.Text = rawId.ToString();
            }
            
        }
    }
}