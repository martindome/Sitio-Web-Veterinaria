<%@ Page Title="LogIn" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-8">
            <section id="LoginForm">
                <div class="form-horizontal">
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TextBoxUsername" CssClass="col-md-2 control-label">Usuario</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="TextBoxUsername" runat="server" class="form-group"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TextBoxPassword" CssClass="col-md-2 control-label">Clave</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="TextBoxPassword" runat="server" class="form-group" TextMode="Password"></asp:TextBox>   
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ingresar" CssClass="btn btn-default" />
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Registarse" CssClass="btn btn-default" CausesValidation="false"/>
                            <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" CssClass="text-danger" ErrorMessage="Debe ingresar una contraseña para continuar"></asp:RequiredFieldValidator>
                            <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxPassword" CssClass="text-danger" ErrorMessage="Su password debe contener entre 8 y 20 caracteres, al menos 1 numero y 1 caracter especial" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"></asp:RegularExpressionValidator>
                            <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUsername" CssClass="text-danger" ErrorMessage="Debe ingresar un usuario para continuar"></asp:RequiredFieldValidator>
                        </div>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </section>
        </div>
    </div>
    
</asp:Content>
