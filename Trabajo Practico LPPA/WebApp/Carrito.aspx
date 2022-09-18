<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebApp.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Carrito de compras</h1></div>
    <asp:GridView ID="ListaArticulos" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="BE.DetalleCarrito_BE" SelectMethod="ObtenerItems"
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="Producto.Id" HeaderText="IDProducto" SortExpression="IDProducto" />        
        <asp:BoundField DataField="Producto.Nombre" HeaderText="Nombre" />        
        <asp:BoundField DataField="Producto.Precio" HeaderText="Precio (unitario)" DataFormatString="{0:c}"/>     
        <asp:TemplateField   HeaderText="Cantidad">            
                <ItemTemplate>
                    <asp:TextBox ID="Cantidad" Width="40" runat="server" Text="<%#: Item.Cantidad %>"></asp:TextBox> 
                </ItemTemplate>        
        </asp:TemplateField>    
        <asp:TemplateField HeaderText="Total item">            
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Cantidad)) *  Convert.ToDouble(Item.Producto.Precio)))%>
                </ItemTemplate>        
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Borrar Producto">            
                <ItemTemplate>
                    <asp:CheckBox id="Borrar" runat="server"></asp:CheckBox>
                </ItemTemplate>      
        </asp:TemplateField>    
        </Columns>    
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Compra Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
    </div>
    <br />
    <table> 
    <tr>
      <td>
        <asp:Button ID="UpdateBtn" runat="server" Text="Actualizar Carrito" OnClick="UpdateBtn_Click" />
      </td>
      <td>
          <br/>
        <asp:ImageButton ID="CheckoutImageBtn" runat="server" 
                      ImageUrl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" 
                      Width="145" AlternateText="Check out with PayPal" 
                      OnClick="CheckoutBtn_Click" 
                      BackColor="Transparent" BorderWidth="0" />
      </td>
    </tr>
    </table>


</asp:Content>
