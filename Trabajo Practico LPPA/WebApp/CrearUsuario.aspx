<%@ Page Title="Crear Usuario Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="WebApp.CrearUsuario" %>
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
                    <div class="form-group" id="Usuario">
                        <asp:Label runat="server" ValidationGroup="Guardar" AssociatedControlID="TextBoxUsername" CssClass="col-md-2 control-label">Usuario</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="TextBoxUsername" ValidationGroup="Guardar" runat="server" class="form-group"></asp:TextBox>
                            <br /><asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUsername" CssClass="text-danger" ErrorMessage="Debe ingresar un usuario para continuar"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group" id="Nombre">
                        <asp:Label runat="server" ValidationGroup="Guardar" AssociatedControlID="TextBoxNombre" CssClass="col-md-2 control-label">Nombre</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="TextBoxNombre" ValidationGroup="Guardar" runat="server" class="form-group"></asp:TextBox>
                            <br /><asp:RequiredFieldValidator  ValidationGroup="Guardar" ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxNombre" CssClass="text-danger" ErrorMessage="Debe ingresar un nombre para continuar"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group" id="Password">
                        <asp:Label runat="server" ValidationGroup="Guardar" AssociatedControlID="TextBoxPassword" CssClass="col-md-2 control-label">Clave</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="TextBoxPassword" ValidationGroup="Guardar" runat="server" class="form-group" TextMode="Password"></asp:TextBox>
                            <br /><asp:RequiredFieldValidator  ValidationGroup="Guardar" ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" CssClass="text-danger" ErrorMessage="Debe ingresar una contraseña para continuar"></asp:RequiredFieldValidator>
                            <br /><asp:RegularExpressionValidator ValidationGroup="Guardar" ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxPassword" CssClass="text-danger" ErrorMessage="Su password debe contener entre 8 y 20 caracteres, al menos 1 numero y 1 caracter especial" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group" id="Tipo Usuario">
                        <div class="col-md-10">
                            <asp:Label runat="server" ValidationGroup="Guardar" AssociatedControlID="TextBoxPassword" CssClass="col-md-2 control-label">Tipo Usuario: </asp:Label>
                            <div class="col-md-4">
                                <div id="Permisos"> 
                                    <asp:ListBox ID="GridView2" runat="server" SelectionMode="Single" CssClass="list-group" Width="200" Height="200" BackColor="#003300"></asp:ListBox>
                                </div>   
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="Button1" runat="server" ValidationGroup="Guardar" OnClick="Button1_Click" Text="Registrar" CssClass="btn btn-default" />
                        </div>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <asp:Button ID="ButtonSalir" runat="server" Text="Salir" OnClick="ButtonSalir_Click" />
            </section>
        </div>
    </div>
</asp:Content>
