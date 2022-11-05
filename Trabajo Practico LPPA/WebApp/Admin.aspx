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
                <asp:GridView ID="GridViewDigitosVerificadores" runat="server" AutoGenerateColumns="false"
                    Font-Names="Arial" BackColor="#999999" BorderColor="Black" BorderStyle="Dashed" ForeColor="Black">
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
            <asp:ListBox ID="ListBoxUsuariosBloqueados" runat="server" Height="105px" Width="209px" BackColor="Black"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="ButtonDesbloquearUsuario" runat="server" Height="23px" OnClick="Button4_Click" Text="Desbloquear" Width="168px" ForeColor="Black" CssClass="btn-default" />         
        </div>
        <br />
        </div>
    </div>
        
    <div id="Bitacora" style="form-group">
        <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
        <script>
            window.onload = getBitacora;
            $(document).ready(getBitacora);
            function getBitacora() {
                $.ajax({
                    type: "POST",
                    url: "Admin.aspx/ListarBitacora",
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        //Limpiamos tabla
                        var table = document.getElementById('<%=TablaBitacoraHTML.ClientID %>')
                        table.innerHTML = "";
                        //Parseamos datos
                        var cars = response.d;
                        //Creamos headers
                        let row = document.createElement('tr');
                        let data = document.createElement('td');
                        data.appendChild(document.createTextNode('Usuario'))
                        row.appendChild(data);
                        data = document.createElement('td');
                        data.appendChild(document.createTextNode('Detalle'))
                        row.appendChild(data);
                        data = document.createElement('td');
                        data.appendChild(document.createTextNode('Fecha (MM-DD-YYYY)'))
                        row.appendChild(data);
                        table.appendChild(row);
                        //Iteramos
                        for (let entry of cars) {
                            row = document.createElement('tr');
                            data = document.createElement('td');
                            data.appendChild(document.createTextNode(entry.Usuario));
                            row.appendChild(data);
                            data = document.createElement('td');
                            data.appendChild(document.createTextNode(entry.Detalle));
                            row.appendChild(data);
                            data = document.createElement('td');
                            data.appendChild(document.createTextNode(entry.FechaString));
                            row.appendChild(data);
                            table.appendChild(row);
                        }
                        $('#output').append(table);

                    },
                    failure: function (msg) {
                        $('#output').text(msg);
                    }
                });
            }
        </script>

        <script>
            function getBitacoraFiltrado() {
                var data = JSON.stringify({
                    'nombre': $('#<%= TextBoxUsuarioBitacora.ClientID %>').val(),
                    'fechaDesde': $('#<%= TextBoxFechaDesde.ClientID %>').val(),
                    'fechaHasta': $('#<%= TextBoxFechaHasta.ClientID %>').val(),
                })
                $.ajax({
                    type: "POST",
                    url: "Admin.aspx/ListarBitacoraFiltrado",
                    data: data,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        //Limpiamos tabla
                        var table = document.getElementById('<%=TablaBitacoraHTML.ClientID %>')
                        table.innerHTML = "";
                        //Parseamos datos
                        var cars = response.d;
                        //Creamos headers
                        let row = document.createElement('tr');
                        let data = document.createElement('td');
                        data.appendChild(document.createTextNode('Usuario'))
                        row.appendChild(data);
                        data = document.createElement('td');
                        data.appendChild(document.createTextNode('Detalle'))
                        row.appendChild(data);
                        data = document.createElement('td');
                        data.appendChild(document.createTextNode('Fecha (MM-DD-YYYY)'))
                        row.appendChild(data);
                        table.appendChild(row);
                        //Iteramos
                        for (let entry of cars) {
                            row = document.createElement('tr');
                            data = document.createElement('td');
                            data.appendChild(document.createTextNode(entry.Usuario));
                            row.appendChild(data);
                            data = document.createElement('td');
                            data.appendChild(document.createTextNode(entry.Detalle));
                            row.appendChild(data);
                            data = document.createElement('td');
                            data.appendChild(document.createTextNode(entry.FechaString));
                            row.appendChild(data);
                            table.appendChild(row);
                        }
                        $('#output').append(table);

                    },
                    failure: function (msg) {
                        $('#output').text(msg);
                    }
                });
            }
        </script>

        <h1 style="background-color: gray;">Bitacora</h1>
        <div class="col-md-10">
            <br/> 
            <asp:Label ID="LabelUsuarioBitacora" runat="server" Text="Usuario: " CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxUsuarioBitacora" runat="server"></asp:TextBox>
            </div>
            <script src="//code.jquery.com/jquery-1.10.2.js"></script>
            <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
            <link rel="stylesheet" href="/resources/demos/style.css">
            <asp:Label ID="LabelFechaDesdeBitacora" runat="server" Text="Desde: " CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxFechaDesde" runat="server" class="datepicker"></asp:TextBox>
            </div>
            <asp:Label ID="LabelFechaHastaBitacora" runat="server" Text="Hasta: " CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxFechaHasta" runat="server" class="datepicker"></asp:TextBox>
            </div>
            <script>
                $(document).on('ready', function () {
                    $(".datepicker").datepicker({ dateFormat: 'dd-mm-yy' });
                });
            </script>
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonExportar" runat="server" Text="Exportar XML" OnClick="ButtonExportar_Click" />
            <br />
            <br />
            <br />
        </div>

        <div id="output">
            <asp:table runat="server" id="TablaBitacoraHTML" style="width: 100%;max-height:600px;overflow-y:scroll;">
            </asp:table>    
        </div>
    </div>
</asp:Content>
