using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BE.Composite;
using BLL;
using System.Collections;
using System.Collections.Specialized;

namespace WebApp
{
    public partial class Carrito : System.Web.UI.Page
    {
        Carrito_BLL pCarrito = new Carrito_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Usuario_BE usuario = (Usuario_BE)Session["usuario"];
                if (!(((Usuario_BE)Session["usuario"]).TipoUsuario.listaAcciones.Any(x => ((Accion_BE)x).detalle == "Compras")))
                {
                    Session["carrito"] = null;
                    Response.Redirect("Default.aspx");
                }
            }

            //Se puede agregar al carro sin estar logueado
            decimal totalCarrito = 0;
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new Carrito_BE();
            }
            Carrito_BE carrito = (Carrito_BE)Session["Carrito"];
            totalCarrito = pCarrito.Total(carrito);
            if (totalCarrito > 0)
            {
                lblTotal.Text = String.Format("{0:c}", totalCarrito);
            }
            else
            {
                //carrito esta vacio
                LabelTotalText.Text = "";
                lblTotal.Text = "";
                ShoppingCartTitle.InnerText = "El carrito esta vacio";
                UpdateBtn.Visible = false;
                CheckoutImageBtn.Visible = false;
            }
        }

        public List<DetalleCarrito_BE> ObtenerItems()
        {
            if(Session["Carrito"] == null)
            {
                Session["Carrito"] = new Carrito_BE();
            }
            Carrito_BE carrito = (Carrito_BE)Session["Carrito"];
            return pCarrito.ObtenerProductos(carrito);
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new Carrito_BE();
            }
            Carrito_BE carrito = (Carrito_BE)Session["Carrito"];
            using (Carrito_BLL p = new Carrito_BLL())
            {
                Carrito_BLL.CambiosDelCarrito[] cambios = new Carrito_BLL.CambiosDelCarrito[ListaArticulos.Rows.Count];
                for (int i = 0; i < ListaArticulos.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = ObtenerValores(ListaArticulos.Rows[i]);

                    //cambios[i].IdProducto = Convert.ToInt32(rowValues["IDProducto"]);
                    cambios[i].IdProducto = Convert.ToInt32(ListaArticulos.Rows[i].Cells[0].Text);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)ListaArticulos.Rows[i].FindControl("Borrar");
                    cambios[i].Borrar = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)ListaArticulos.Rows[i].FindControl("Cantidad");
                    cambios[i].Cantidad = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                p.ActualizarCarrito(carrito, cambios);
                ListaArticulos.DataBind();
                lblTotal.Text = String.Format("{0:c}", p.Total(carrito));

            }
                
        }

        public static IOrderedDictionary ObtenerValores(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        protected void CheckoutBtn_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
                string detalle = "Compra realizada correctamento por: " + ((Usuario_BE)Session["usuario"]).Usuario;
                bitacoraBLL.LLenar_Bitacora(((Usuario_BE)Session["usuario"]).IdUsuario, detalle);
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["Carrito"] == null)
                {
                    Session["Carrito"] = new Carrito_BE();
                }
                Carrito_BE carrito = (Carrito_BE)Session["Carrito"];
                using (Carrito_BLL c = new Carrito_BLL())
                {
                    if (c.ObtenerProductos(carrito).Count != 0)
                    {
                        int idVenta = c.CheckOut(carrito, ((Usuario_BE)Session["usuario"]).IdUsuario);
                        Session["Carrito"] = new Carrito_BE();
                        Response.Redirect("Compra.aspx?idVenta=" + idVenta.ToString());
                    }
                }
            }
        }
    }
}