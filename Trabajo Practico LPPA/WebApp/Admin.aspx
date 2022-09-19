<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApp.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1 style="background-color: gray;">Permisos</h1>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        Las acciones que el usuario puede realizar son:<br />
        <br />
        <div style="margin-left: 80px">
            <asp:ListBox ID="ListBox1" runat="server" class="list-group" BackColor="Black" CssClass="list-group"></asp:ListBox>
        </div>
    </div>
    
    <div>
        <h1 style="background-color: gray;">Backup y Restore</h1>
            <div style="padding: 1%;">
                <asp:Label ID="Label8" runat="server" Text="Para realizar Backup o Restore seleccione el siguiente boton: "></asp:Label>
                <br />
            </div>
            <div style="margin-left: 80px">
                <asp:Button ID="Button1" runat="server" OnClick="Accion_Click" Text="Backup & Restore" Width="168px" ForeColor="Black" CssClass="btn-default" /> 
            </div>
        <br />
    </div>
    <div>
        <h1 style="background-color: gray;">Digitos Verificadores</h1>
            <div style="padding: 1%;">
                <asp:Label ID="Label6" runat="server" Text="Seleccione el siguiente boton para recalcular los digitos verificadores: "></asp:Label>
                <br />
            </div>
            <div style="margin-left: 80px">
                <asp:Button ID="ButtonDigitos" runat="server" OnClick="Accion_Click_Digitos" Text="Restaurar" Width="168px" ForeColor="Black" CssClass="btn-default" /> 
            </div>
        <br />
    </div>
    <div>
        <h1 style="background-color: gray;">Desbloqueo</h1>
        <div ID="divcito" runat="server">
        <div>
            <div style="padding: 1%;">
                <asp:Label ID="Label4" runat="server" Text="Para desbloquear un usuario debe seleccionarlo y pulsar el boton 'Desbloquear'"></asp:Label>
                <br />
            </div>
        </div>
        <div style="margin-left: 80px">
            <asp:ListBox ID="ListBox2" runat="server" Height="105px" Width="209px" class="list-group" BackColor="Black" CssClass="list-group"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Height="23px" OnClick="Button4_Click" Text="Desbloquear" Width="168px" ForeColor="Black" CssClass="btn-default" />         
        </div>
        <br />
        </div>
    </div>
   

    <div>
        <h1 style="background-color: gray;">Bitacora</h1>
        <div style="margin-left: 80px">
            <asp:Label ID="Label2" runat="server" Text="Presione el boton para observar la bitacora"></asp:Label>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Mostar Bitacora" Visible="True" Width="168px" ForeColor="Black" Height="23px" CssClass="btn-default" />
        </div>
        <br />
        <br />       
        <div>
            <h3 style="background-color: gray;">Filtros</h3>
            <div>
            <asp:Label ID="Label9" runat="server" Text="Fecha: "></asp:Label>
            <asp:Calendar ID="Calendar1" 
                selectionmode="DayWeekMonth"
                onselectionchanged="seleccionFecha"
                runat="server" Height="58px" Width="326px" BackColor="#666666" ForeColor="Black" NextPrevFormat="ShortMonth"></asp:Calendar>
            <asp:Label ID="lblFechas" runat="server" Text=""></asp:Label>
            <br />
        </div>
            <asp:Label ID="Label3" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" Width="222px" Height="21px" OnTextChanged="textBox1_TextChanged"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Visible="True" Text="Presione enter para filtrar."></asp:Label>
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Limpiar Filtros" Visible="True" Width="168px" ForeColor="Black" Height="23px" CssClass="btn-default" />
        </div>
        
        <br />
        <br />
        <div id="popup" style="max-height:600px;overflow-y:scroll;">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
            OnPageIndexChanging="OnPaging" PageSize="10" Font-Names="Arial" BackColor="#999999" BorderColor="Black" BorderStyle="Dashed" ForeColor="Black" >
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="Fecha" HeaderText="Fecha" >
                <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="Usuario" HeaderText="Usuario" >
                <ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="80px" DataField="Id_Usuario" HeaderText="Id_Usuario" >
                <ItemStyle Width="80px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="400px" DataField="Detalle" HeaderText="Detalle" >
                <ItemStyle Width="400px"></ItemStyle>
                </asp:BoundField>  
            </Columns>
                <HeaderStyle BackColor="#999999" BorderColor="Black" />
                <PagerStyle CssClass="gridpager" />
                <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="&nbsp;<<&nbsp;" PreviousPageText="&nbsp;<&nbsp;" NextPageText="&nbsp;>&nbsp;" LastPageText="&nbsp;>>&nbsp;"  Position="Bottom" />
                <RowStyle BackColor="#CCCCCC" />
        </asp:GridView>
      </div>
    </div>

</asp:Content>
