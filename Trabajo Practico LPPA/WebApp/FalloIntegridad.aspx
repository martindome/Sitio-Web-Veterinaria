<%@ Page Title="FalloIntegridad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FalloIntegridad.aspx.cs" Inherits="WebApp.FalloIntegridad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script> 
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        </script>

    <div style="padding: 1%;">
        Ha ocurrido un fallo en la integridad de los registros de la base de datos, por lo que el programa no puede ser iniciado.
        Por favor, espere a que el problema sea resulto por un administrador.
        <br />
        <br />
        Las tablas que tienen fallo de integridad son:<br />
        <br />
     </div>

    <div style="margin-left: 80px">
            <%--<asp:ListBox ID="ListBox1" runat="server" Height="105px" Width="209px" BackColor="Black"></asp:ListBox>--%>
        </div>
        <div style="margin-left: 80px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
            OnPageIndexChanging="OnPaging" PageSize="10" Font-Names="Arial" BackColor="#999999" BorderColor="Black" BorderStyle="Dashed" ForeColor="Black">
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="Tabla" HeaderText="Tabla" >
                <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="ID_Registro" HeaderText="Registro" >
                <ItemStyle Width="100px"></ItemStyle>   
                </asp:BoundField>  
            </Columns>
                <HeaderStyle BackColor="#999999" BorderColor="Black" />
                <PagerStyle CssClass="gridpager" />
                <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="&nbsp;<<&nbsp;" PreviousPageText="&nbsp;<&nbsp;" NextPageText="&nbsp;>&nbsp;" LastPageText="&nbsp;>>&nbsp;"  Position="Bottom" />
                <RowStyle BackColor="#CCCCCC" />
        </asp:GridView>
        </div>
</asp:Content>
