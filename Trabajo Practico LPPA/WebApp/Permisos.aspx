<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Permisos.aspx.cs" Inherits="WebApp.Permisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="Permiso" runat="server" class="ContentHead"><h1>Perfiles</h1></div>
    <hr />
    <%--<div id="Usuarios Permisos Titulo" runat="server" class="ContentHead"><h1>Permisos de usuario</h1></div>--%>
    <br />
    <div class="table-responsive">
        <div class="col-md-4">
            Seleccionar el usuario: 
            <div id="Tabla Usuario" > 
                <asp:ListBox ID="GridView1" runat="server" CssClass="list-group" SelectionMode="Single" Width="300" Height="400" BackColor="#003300"></asp:ListBox>
            </div>
        </div>
    
        <div class="col-md-4">
            Seleccionar el nuevo perfil: 
            <div id="Tabla Perfiles Agregar"> 
                <asp:ListBox ID="GridView2" runat="server" SelectionMode="Single" CssClass="list-group" Width="300" Height="400" BackColor="#003300"></asp:ListBox>
            </div>
        </div>
    </div>
    <asp:Label ID="LabelAccion" runat="server" Text=""></asp:Label> <br />
    <asp:Button ID="ButtonAplicar" runat="server" Text="Aplicar" OnClick="ButtonAplicar_Click" /><br />
    <asp:Button ID="ButtonSalir" runat="server" Text="Salir" OnClick="ButtonSalir_Click" />
</asp:Content>

