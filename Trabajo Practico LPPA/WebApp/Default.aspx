<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Cachorros</h1>
        <p class="lead">Tenemos todo para su mascota</p>
        <p><a href="Productos.aspx" class="btn btn-primary btn-lg">Comprar ahora</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2 id="Admin-Titulo">Consola de administrador</h2>
            <p>
                <a class="btn btn-default" href="Admin.aspx">Entrar</a>
            </p>
        </div>
    </div>

</asp:Content>
