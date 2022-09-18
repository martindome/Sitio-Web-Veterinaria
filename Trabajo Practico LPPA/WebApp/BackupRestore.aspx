<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BackupRestore.aspx.cs" Inherits="WebApp.BackupRestore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="auto-style1">
        <div style="margin-left: 78px;margin-top: 40px;">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="0">BACKUP</asp:ListItem>
                <asp:ListItem Value="1">RESTORE</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />
        <br />
        <div style="margin-left: 80px">
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </div>
        <div ID="id_restore" runat="server" style="margin-left: 80px">
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="105px" Width="209px" BackColor="Black" ></asp:ListBox>
            <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
            <asp:Label ID="Label8" runat="server" Text="Debe seleccionar un archivo para continuar" ForeColor="Red" Visible="False"></asp:Label>
        </div>

        <div ID="id_backup" runat="server" style="margin-left: 80px">              
             
            <br />
            <asp:TextBox ID="TXTNombre" runat="server" ForeColor="Black"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTNombre" ErrorMessage="Debe ingresar un nombre para continuar" ValidationGroup="Realizar"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div style="margin-left: 80px">
              
            <asp:Button ID="Button1" OnClick="Accion_Click" runat="server"  ValidationGroup="Realizar" Text="Realizar" Width="97px" ForeColor="Black" CssClass="btn btn-default" /> 
                
            <asp:Button ID="Button3" runat="server" Text="Volver" OnClick="Button2_Click"  ForeColor="Black" Width="97px" style="margin-left: 30px" CssClass="btn btn-default" />

        </div>
        <div style="margin-left: 80px">
            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#33CC33"></asp:Label>
        </div>
       
    
    </div>
</asp:Content>
