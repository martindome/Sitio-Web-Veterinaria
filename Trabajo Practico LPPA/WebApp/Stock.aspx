<%@ Page Title="Mercaderia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="WebApp.Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Manejo de stock</h1></div>
    <div style="height:400px;overflow:auto;">
        <asp:GridView ID="ListaProductos" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
            ItemType="BE.Producto_BE" SelectMethod="ObtenerProductos"
            CssClass="table table-striped table-bordered;max-height:600px;overflow-y:scroll;" >   
            <Columns>
            <asp:BoundField DataField="Id" HeaderText="IDProducto" SortExpression="IDProducto" />        
            <%--<asp:BoundField DataField="Nombre" HeaderText="Nombre" />--%>        
            <%--<asp:BoundField DataField="Precio" HeaderText="Precio (unitario)" DataFormatString="{0:c}"/>--%>     
            <asp:TemplateField   HeaderText="Nombre">            
                <ItemTemplate>
                    <asp:TextBox ID="NombreProducto" Width="350" runat="server" Text="<%#: Item.Nombre %>"></asp:TextBox> 
                </ItemTemplate>        
            </asp:TemplateField>
            <asp:TemplateField   HeaderText="Precio">            
                <ItemTemplate>
                    <asp:TextBox ID="PrecioProducto" Width="90" runat="server" Text="<%#: Item.Precio %>"></asp:TextBox> 
                </ItemTemplate>        
            </asp:TemplateField>
            <asp:TemplateField   HeaderText="Marca">            
                <ItemTemplate>
                    <asp:TextBox ID="MarcaProducto" Width="150" runat="server" Text="<%#: Item.Marca %>"></asp:TextBox> 
                </ItemTemplate>        
            </asp:TemplateField> 
            <asp:TemplateField   HeaderText="Tipo">            
                <ItemTemplate>
                    <asp:TextBox ID="TipoProducto" Width="120" runat="server" enabled="false" Text="<%#: Item.Tipo %>"></asp:TextBox> 
                </ItemTemplate>        
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Borrar Producto">            
                <ItemTemplate>
                    <asp:CheckBox id="Borrar" runat="server"></asp:CheckBox>
                </ItemTemplate>      
            </asp:TemplateField>    
            </Columns>    
        </asp:GridView>
    </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button ID="UpdateBtn" runat="server" Text="Actualizar Productos" OnClick="UpdateBtn_Click" CausesValidation="false" CssClass="btn btn-default"/>
        </div>
    </div>
    <br />
    <br />
    <hr>
    <div class="form-horizontal">
        <h3>Nuevo Producto</h3>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxNombre" CssClass="col-md-2 control-label">Nombre: </asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxNombre" runat="server" class="form-group"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" ControlToValidate="TextBoxNombre" CssClass="text-danger" ErrorMessage="Requerido"></asp:RequiredFieldValidator>--%>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Tipo: </asp:Label>
            <div class="col-md-2">
                <div class="form-item form-type-select form-item-donation-currency form-group">
                    <asp:RadioButtonList class="form-check" id="RadioButtonTipo" runat="server">
                    <asp:ListItem class="form-check-label" Selected="True">Accesorio</asp:ListItem>
                    <asp:ListItem class="form-check-label" >Mueble</asp:ListItem>
                    <asp:ListItem class="form-check-label" >Comida</asp:ListItem>
                </asp:RadioButtonList>
                </div>
                
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxMarca" CssClass="col-md-2 control-label">Marca: </asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxMarca" runat="server" class="form-group"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorMarca" runat="server" ControlToValidate="TextBoxMarca" CssClass="text-danger" ErrorMessage="Requerido"></asp:RequiredFieldValidator>--%>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxPrecio" CssClass="col-md-2 control-label">Precio: </asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxPrecio" runat="server" class="form-group"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorPrecio" runat="server" ControlToValidate="TextBoxPrecio" CssClass="text-danger" ErrorMessage="Requerido"></asp:RequiredFieldValidator>--%>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click" Text="Crear" CssClass="btn btn-default" />
                <br />
                
            </div>
        </div>
        <hr>
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Seleccionar Archivo: " CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" CssClass="btn btn-default" Width="1000px"/>  
                <br />
                <asp:Button ID="ButtonUpload" runat="server" Text="Subir" OnClick="ButtonUpload_Click1" disableValidation="true" CssClass="btn btn-default" />
            </div>
            
        </div>
    </div>


</asp:Content>
