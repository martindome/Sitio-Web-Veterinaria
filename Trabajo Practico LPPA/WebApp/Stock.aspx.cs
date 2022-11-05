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
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

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
                    //switch (RadioButtonTipo.SelectedItem.Text)
                    //{
                    //    case "Collar":
                    //        cambios[i].Tipo = "Collar";
                    //        break;
                    //    case "Moises":
                    //        cambios[i].Tipo = "Moises";
                    //        break;
                    //    case "Comida":
                    //        cambios[i].Tipo = "Comida";
                    //        break;
                    //}

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
                    //producto.Tipo = TextBoxTipo.Text;
                    producto.Tipo = RadioButtonTipo.SelectedItem.Text;
                    producto.Marca = TextBoxMarca.Text;
                    producto.Precio = TextBoxPrecio.Text;
                    p.NuevoProducto(producto);
                    ListaProductos.DataBind();
                    p.Dispose();
                    TextBoxNombre.Text = "";
                    //TextBoxTipo.Text = "";
                    TextBoxMarca.Text = "";
                    TextBoxPrecio.Text = "";
                }
            }
        }

        

        protected void ButtonUpload_Click1(object sender, EventArgs e)
        {
            try {
                foreach (var file in FileUpload1.PostedFiles)
                {
                    Response.Write(file.FileName + " - " + file.ContentLength + " Bytes. <br />");
                    using (Producto_BLL p = new Producto_BLL())
                    {
                        List<Producto_BE> productos = p.Listar_Productos();
                        List<Producto_BE> lista = new List<Producto_BE>();
                        //upload logic  

                        file.SaveAs(Server.MapPath("~/") + "temp.xml");
                        XPathDocument docu = new XPathDocument(Server.MapPath("temp.xml"));
                        XPathNavigator navi = docu.CreateNavigator();
                        XPathNodeIterator ite = navi.Select("productos/producto/nombre");
                        int i = 0;
                        while (ite.MoveNext())
                        {
                            lista.Add(new Producto_BE());
                            lista[i].Nombre = ite.Current.Value;
                            i++;
                        }
                        i = 0;
                        ite = navi.Select("productos/producto/precio");
                        while (ite.MoveNext())
                        {
                            lista[i].Precio = ite.Current.Value;
                            i++;
                        }
                        i = 0;
                        ite = navi.Select("productos/producto/marca");
                        while (ite.MoveNext())
                        {
                            lista[i].Marca = ite.Current.Value;
                            i++;
                        }
                        i = 0;
                        ite = navi.Select("productos/producto/tipo");
                        while (ite.MoveNext())
                        {
                            lista[i].Tipo = ite.Current.Value;
                            i++;
                        }
                        foreach (Producto_BE producto in lista)
                        {
                            if(!productos.Any(item => item.Nombre == producto.Nombre && item.Tipo == producto.Tipo))
                            {
                                p.NuevoProducto(producto);
                                ListaProductos.DataBind();
                                p.Dispose();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
            
        }
    }
}