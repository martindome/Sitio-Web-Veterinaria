﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BE.Composite;
using BLL;

namespace WebApp
{
    public partial class CrearUsuario : System.Web.UI.Page
    {
        Usuario_BLL usuarioBLL = new Usuario_BLL();
        Usuario_BE usuarioBE = new Usuario_BE();
        Permisos_BLL permisosBLL = new Permisos_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).TipoUsuario.id == 1))
                {
                    //Sacamos controles de navegacion
                    Response.Redirect("Default.aspx");
                }
                List<TipoUsuario_BE> permisos = permisosBLL.ListarPermisos();
                foreach(TipoUsuario_BE permiso in permisos)
                {
                    RadioButtonTipo.Items.Add(new ListItem(permiso.tipo_usuario, permiso.id.ToString()));
                }
            }
            

        }

        protected void Button1_Click(object o, EventArgs e)
        {
            if (IsValid)
            {
                usuarioBE = usuarioBLL.Verificar_Usuario_sinpassword(TextBoxUsername.Text);
                if (string.IsNullOrEmpty(usuarioBE.Usuario))
                {
                    usuarioBE = new Usuario_BE();
                    usuarioBE.Nombre = TextBoxNombre.Text;
                    usuarioBE.Usuario = TextBoxUsername.Text;
                    usuarioBE.Contraseña = TextBoxPassword.Text;
                    usuarioBE.Bloqueado = 0;
                    usuarioBE.TipoUsuario = new TipoUsuario_BE();
                    switch (RadioButtonTipo.SelectedItem.Text)
                    {
                        case "Webmaster":
                            usuarioBE.TipoUsuario.id =1;
                            break;
                        case "Control Stock":
                            usuarioBE.TipoUsuario.id=3;
                            break;
                        case "Cliente":
                            usuarioBE.TipoUsuario.id = 2;
                            break;
                    }
                    usuarioBLL.Registar_Usuario_Admin(usuarioBE);

                    Bitacora_BLL bitacoraBLL = new Bitacora_BLL();
                    string detalle = "Registro - Usuario: " + usuarioBE.Usuario;
                    bitacoraBLL.LLenar_Bitacora(0, detalle);
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    Label1.Text = "Usuario Existente";
                    Label1.Visible = true;
                }
            }
        }
    }
}