using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BE.Composite;
using BLL;
using System.Web.ModelBinding;
using System.Collections.Specialized;

namespace WebApp
{
    public partial class Stock : System.Web.UI.Page
    {
        Producto_BLL pProducto_BLL = new Producto_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Usuario_BE usuario = (Usuario_BE)Session["usuario"];
                if (! ((usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Agregar Item"))) && !((usuario.TipoUsuario.listaAcciones.Any(item => ((Accion_BE)item).detalle == "Borrar Item"))))
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        public IQueryable<Producto_BE> ObtenerProductos(
                        [QueryString("id")] int? categoryId,
                        [RouteData] string categoryName)
        {
            List<Producto_BE> aux = new List<Producto_BE>();
            List<Producto_BE> productos = pProducto_BLL.Listar_Productos();
            foreach (Producto_BE p in productos)
            {
                if (p.Borrado == "No")
                {
                    aux.Add(p);
                }
            }
            IQueryable<Producto_BE> query = aux.AsQueryable<Producto_BE>();
            return query;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            using (Producto_BLL p = new Producto_BLL())
            {
                Producto_BLL.CambiosDeProductos[] cambios = new Producto_BLL.CambiosDeProductos[ListaProductos.Rows.Count];
                for (int i = 0; i < ListaProductos.Rows.Count; i++)
                {
                    //IOrderedDictionary rowValues = new OrderedDictionary();
                    //rowValues = ObtenerValores(ListaProductos.Rows[i]);

                    //cambios[i].IdProducto = Convert.ToInt32(rowValues["IDProducto"]);
                    cambios[i].IdProducto = Convert.ToInt32(ListaProductos.Rows[i].Cells[0].Text);
                    //cambios[i].Nombre = ListaProductos.Rows[i].Cells[1].Text;
                    //cambios[i].Precio = ListaProductos.Rows[i].Cells[2].Text;
                    //cambios[i].Marca = ListaProductos.Rows[i].Cells[3].Text;
                    //cambios[i].Tipo = ListaProductos.Rows[i].Cells[4].Text;

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)ListaProductos.Rows[i].FindControl("Borrar");
                    cambios[i].Borrar = cbRemove.Checked;

                    TextBox NombreTextBox = new TextBox();
                    NombreTextBox = (TextBox)ListaProductos.Rows[i].FindControl("NombreProducto");
                    cambios[i].Nombre = NombreTextBox.Text.ToString();

                    TextBox PrecioTextBox = new TextBox();
                    PrecioTextBox = (TextBox)ListaProductos.Rows[i].FindControl("PrecioProducto");
                    cambios[i].Precio = PrecioTextBox.Text.ToString();

                    TextBox MarcaTextBox = new TextBox();
                    MarcaTextBox = (TextBox)ListaProductos.Rows[i].FindControl("MarcaProducto");
                    cambios[i].Marca = MarcaTextBox.Text.ToString();

                    TextBox TipoTextBox = new TextBox();
                    TipoTextBox = (TextBox)ListaProductos.Rows[i].FindControl("TipoProducto");
                    cambios[i].Tipo = TipoTextBox.Text.ToString();
                }
                p.ActualizarProductos(cambios);
                ListaProductos.DataBind();
            }
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            using (Producto_BLL p = new Producto_BLL())
            {
                if (IsValid)
                {
                    Producto_BE producto = new Producto_BE();
                    producto.Nombre = TextBoxNombre.Text;
                    producto.Tipo = TextBoxTipo.Text;
                    producto.Marca = TextBoxMarca.Text;
                    producto.Precio = TextBoxPrecio.Text;
                    p.NuevoProducto(producto);
                    ListaProductos.DataBind();
                    p.Dispose();
                    TextBoxNombre.Text = "";
                    TextBoxTipo.Text = "";
                    TextBoxMarca.Text = "";
                    TextBoxPrecio.Text = "";
                }
            }
        }
    }
}