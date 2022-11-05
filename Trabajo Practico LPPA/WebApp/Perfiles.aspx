<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfiles.aspx.cs" Inherits="WebApp.Perfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="Profiles" runat="server" class="ContentHead"><h1>Perfiles</h1></div>
    <hr />
    <%--<div id="Usuarios Permisos Titulo" runat="server" class="ContentHead"><h1>Permisos de usuario</h1></div>--%>
    <br />
    <div class="table-responsive">
        <div class="col-md-4">
            Seleccionar el perfil: 
            <div id="Tabla Usuario" > 
                <asp:ListBox ID="GridView1" runat="server" CssClass="list-group" SelectionMode="Single" Width="300" Height="400" BackColor="#003300" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:ListBox>
            </div>
            <asp:Button ID="ButtonSeleccionarPermiso" runat="server" Text="Seleccionar" OnClick="ButtonSeleccionarPermiso_Click" /><br />
            Crear nuevo permiso: <br />
            <asp:TextBox ID="TextBoxAgregarPermiso" runat="server"></asp:TextBox> <br />
            <asp:Button ID="ButtonAgregarPermiso" runat="server" Text="Crear Permiso" OnClick="ButtonAgregarPermiso_Click" />
        </div>
    
        <div class="col-md-4">
            Acciones actuales a borrar: 
            <div id="Tabla Perfiles Borrar"> 
                <asp:ListBox ID="GridView2" runat="server" SelectionMode="Single" CssClass="list-group" Width="300" Height="400" BackColor="#003300"></asp:ListBox>
            </div>   
            <asp:Button ID="ButtonAplicarBorrar" runat="server" Text="Eliminar" OnClick="ButtonAplicarBorrar_Click" /><br />
        </div>

        <div class="col-md-4">
            Acciones a agregar: 
            <div id="Tabla Perfiles Agregar"> 
                <asp:ListBox ID="GridView3" runat="server" SelectionMode="Single" CssClass="list-group" Width="300" Height="400" BackColor="#003300"></asp:ListBox>
            </div>
            <asp:Button ID="ButtonAplicarAgregar" runat="server" Text="Agregar" OnClick="ButtonAplicarAgregar_Click" /><br />
        </div>
    </div>
    <asp:Label ID="LabelAccion" runat="server" Text=""></asp:Label> <br />
    <asp:Button ID="ButtonSalir" runat="server" Text="Salir" OnClick="ButtonSalir_Click1" />

</asp:Content>
