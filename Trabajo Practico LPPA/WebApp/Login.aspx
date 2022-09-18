<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            Usuario: <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="text-center"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="Debe ingresar un usuario para continuar"></asp:RequiredFieldValidator>
            <br />
            Clave: <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="text-center" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Debe ingresar una contraseña para continuar"></asp:RequiredFieldValidator>
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Su pasword debe contener al menos 6 letras , dos numeros y un caracter especial" ValidationExpression="[a-zA-Z]{6}\w*\d{2}\W{1}"></asp:RegularExpressionValidator>--%>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ingresar" CssClass="btn btn-default" />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </section>
</asp:Content>
