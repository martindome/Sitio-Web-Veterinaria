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
            <asp:ListBox ID="ListBoxPermisosUsuario" runat="server" class="list-group" BackColor="Black" CssClass="list-group"></asp:ListBox>
        </div>
    </div>

    <div>
        <h1 style="background-color: gray;">Usuarios</h1>
            <div style="padding: 1%;">
                <asp:Label ID="LabelUsuarios" runat="server" Text="Para registrar un nuevo usuario administrador, seleccione el sigueinte boton"></asp:Label>
                <br />
            </div>
            <div style="margin-left: 80px">
                <asp:Button ID="ButtonCrearUsuario" runat="server" OnClick="CrearUsuario_Click" Text="Crear Usuario" Width="168px" ForeColor="Black" CssClass="btn-default" /> 
            </div>
        <br />
    </div>

    <div>
        <h1 style="background-color: gray;">Backup y Restore</h1>
            <div style="padding: 1%;">
                <asp:Label ID="Label8" runat="server" Text="Para realizar Backup o Restore seleccione el siguiente boton: "></asp:Label>
                <br />
            </div>
            <div style="margin-left: 80px">
                <asp:Button ID="ButtonRestore" runat="server" OnClick="Accion_Click" Text="Backup & Restore" Width="168px" ForeColor="Black" CssClass="btn-default" /> 
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
            <asp:ListBox ID="ListBoxUsuariosBloqueados" runat="server" Height="105px" Width="209px" class="list-group" BackColor="Black" CssClass="list-group"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="ButtonDesbloquearUsuario" runat="server" Height="23px" OnClick="Button4_Click" Text="Desbloquear" Width="168px" ForeColor="Black" CssClass="btn-default" />         
        </div>
        <br />
        </div>
    </div>
   

    <div>
        <h1 style="background-color: gray;">Bitacora</h1>
        <%--<asp:Label ID="Label5" runat="server" Visible="True" Text="Presione enter para filtrar."></asp:Label>--%>
<%--        <br />
        <br />    --%>   
        <div id="popup" style="max-height:600px;overflow-y:scroll;">
            <asp:GridView class="table" ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
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
        <div>
            <h3 style="background-color: gray;">Filtros</h3>
            <div>
            <asp:Label ID="LabelFecha" runat="server" Text="Fecha: "></asp:Label>
            <asp:Calendar class="input-group date" ID="CalendarBitacora" 
                selectionmode="DayWeekMonth"
                onselectionchanged="seleccionFecha"
                runat="server" Height="58px" Width="326px" BackColor="#666666" ForeColor="Black" NextPrevFormat="ShortMonth"></asp:Calendar>
            <asp:Label ID="lblFechas" runat="server" Text=""></asp:Label>
            <br />
        </div>
            <asp:Label ID="Label3" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="TextBoxUsuarioFiltro" runat="server" ForeColor="Black" Width="222px" Height="21px"></asp:TextBox>
            <%--<asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" Width="222px" Height="21px" OnTextChanged="textBox1_TextChanged">></asp:TextBox>--%>
            <%--<br />--%>
            <%--<asp:Label ID="Label5" runat="server" Visible="True" Text="Presione enter para filtrar."></asp:Label>--%>
            <br />
            <asp:Button ID="ButtonFiltrarBitacora" runat="server" OnClick="Button_Filtrar" Text="Filtrar" Visible="True" Width="168px" ForeColor="Black" Height="23px" CssClass="btn-default" />
            <br />
            <asp:Button ID="ButtonLimpiarFiltros" runat="server" OnClick="ButtonLimpiarFiltros_Click" Text="Limpiar Filtros" Visible="True" Width="168px" ForeColor="Black" Height="23px" CssClass="btn-default" />
        </div>
        
        <br />
        <br />
        
    </div>

</asp:Content>
