<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="WebApp.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h2 id="Admin-Titulo">Compra realizada con exito</h2>
            <p>
                El numero de venta es: 
                <asp:Label runat="server" id="IdVenta" Text=""></asp:Label>
            </p>
            <p>
                <a class="btn btn-default" href="Default.aspx">Continuar</a>
            </p>
        </div>
    </div>
</asp:Content>
