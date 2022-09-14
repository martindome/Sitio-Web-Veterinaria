using System;
using System.Collections.Generic;
using BE;
using BLL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public partial class Respuesta : System.Web.UI.Page
{
    Usuario_BE usuarioRespuesta = new Usuario_BE();
    Usuario_BLL usuarioRespuestaBLL = new Usuario_BLL();
    Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fechas"] == null)
        {
            Session["fechas"] = new List<DateTime>();
        }
        usuarioRespuesta = (Usuario_BE)Session["usuario"];

        if (usuarioRespuesta != null)
        {
            if (!IsPostBack)
            {
                //recuperamos variables de sesion para instanciar un objeto usuario
                Label5.Visible = false;
                if (usuarioRespuesta.TipoUsuario.id == 1)
                {
                    Button2.Visible = true;
                    TextBox1.Visible = false;
                    Label3.Visible = false;
                    Label9.Visible = false;
                    Label10.Visible = false;
                    Calendar1.Visible = false;
                    Button4.Visible = true;
                    ListBox2.Visible = true;
                    Label4.Visible = true;
                    divcito.Visible = true;
                    Button1.Visible = true;


                }
                else
                {
                    TextBox1.Visible = false;
                    Label3.Visible = false;
                    Label9.Visible = false;
                    Label10.Visible = false;
                    Calendar1.Visible = false;
                    Label5.Visible = false;
                    Button3.Visible = false;
                    Button4.Visible = false;
                    ListBox2.Visible = false;
                    Label4.Visible = false;
                    divcito.Visible = false;
                    Button1.Visible = false;

                }

                string detalle = "Inicio de Sesion - Usuario: " + usuarioRespuesta.Usuario;
                //se genera un registro en bitacora
                bitacoraBLL.LLenar_Bitacora(usuarioRespuesta.IdUsuario, detalle);
                Label1.Text = "Bienvenido " + usuarioRespuesta.Nombre + " Usted tiene permisos de: " + usuarioRespuesta.TipoUsuario.tipo_usuario;
                //listado de roles
                foreach (Accion_BE accion in usuarioRespuesta.TipoUsuario.listaAcciones)
                {
                    ListBox1.Items.Add(accion.detalle);
                }
                //listado de usuarios bloqueados
                foreach (Usuario_BE usuario in usuarioRespuestaBLL.Usuarios_Bloquedos())
                {
                    ListBox2.Items.Add(usuario.Usuario);
                }


            }
        }
        else 
        {
            Response.Redirect("/Error404.aspx");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Label2.Text = "Bitacora de actividades: ";
        Label3.Visible = true;
        Label5.Visible = true;
        Label9.Visible = true;
        Label10.Visible = true;
        Calendar1.Visible = true;
        Button3.Visible = true;
        TextBox1.Visible = true;
        Label3.Text = "Usuario: ";
        Button2.Visible = false;
        this.llenarGrid();
        
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        ((List<DateTime>)Session["fechas"]).Clear();
        Calendar1.SelectedDates.Clear();
        this.llenarGrid();
    }

    private void llenarGrid()
    {
        string detalle = "Consulta de bitacora - Usuario: " + usuarioRespuesta.Usuario;
        bitacoraBLL.LLenar_Bitacora(usuarioRespuesta.IdUsuario, detalle);
        GridView1.Visible = true;

        List<DetalleBitacora_BE> bitacora = new List<DetalleBitacora_BE>();

        bitacora = bitacoraBLL.Cargar_Bitacora();
        if (TextBox1.Text != "")
        {
            bitacora = bitacora.FindAll(FilterFunc);
        }
        if (((List<DateTime>)Session["fechas"]).Count > 0)
        {
            bitacora = bitacora.FindAll(FilterFuncFecha);
        }
        GridView1.DataSource = bitacora;
        GridView1.DataBind();
    }

    protected void seleccionFecha(object sender, EventArgs e)
    {
        if (null != Calendar1.SelectedDates)
        {
            ((List<DateTime>)Session["fechas"]).Clear();
            foreach (DateTime fecha in Calendar1.SelectedDates)
            {
                ((List<DateTime>)Session["fechas"]).Add(fecha);
            }
        }
        llenarGrid();
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.llenarGrid();
    }

    protected void textBox1_TextChanged(object sender, EventArgs e)
    {
        llenarGrid();
    }

    private bool FilterFunc(DetalleBitacora_BE detalle)
    {
        if (detalle.Usuario.Contains(TextBox1.Text) || TextBox1.Text.Contains(detalle.Usuario))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool FilterFuncFecha(DetalleBitacora_BE detalle)
    {
        DateTime fechaInicio = ((List<DateTime>)Session["fechas"])[0];
        DateTime fechaFin = ((List<DateTime>)Session["fechas"])[((List<DateTime>)Session["fechas"]).Count - 1].AddDays(1);
        DateTime f = new DateTime(detalle.Fecha.Year, detalle.Fecha.Month, detalle.Fecha.Day);
        if (f >= fechaInicio && f < fechaFin)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    protected void Accion_Click(object sender, EventArgs e)
    {
        Response.Redirect("/BackupRestore.aspx");
    }
  
    protected void Button4_Click(object sender, EventArgs e)
    {
        string usuarioBq = ListBox2.SelectedValue.ToString(); 
        usuarioRespuestaBLL.Desbloquear_Usuario(usuarioBq);
        ListBox2.Items.Remove(usuarioBq);
    }


    //Control de visual

    
  
}