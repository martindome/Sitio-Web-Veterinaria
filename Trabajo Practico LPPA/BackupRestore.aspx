<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BackupRestore.aspx.cs" Inherits="BackupRestore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
		<meta charset="utf-8">
		<title>Veterinaria Cachorros SA</title>
		<meta name="keywords" content="">
		<meta name="description" content="">
		<meta http-equiv="X-UA-Compatible" content="IE=Edge">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		
		<link rel="stylesheet" href="css/animate.min.css">
		<link rel="stylesheet" href="css/bootstrap.min.css">
		<link rel="stylesheet" href="css/font-awesome.min.css">
		<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700' rel='stylesheet' type='text/css'>
		<link rel="stylesheet" href="css/templatemo-style.css">
		<script src="js/jquery.js"></script>
		<script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.singlePageNav.min.js"></script>
		<script src="js/typed.js"></script>
		<script src="js/wow.min.js"></script>
		<script src="js/custom.js"></script>
	</head>
<body>
	<!-- start preloader -->
    <form id="form1" runat="server">
		<div class="preloader">
			<div class="sk-spinner sk-spinner-wave">
     	    </div>
    	</div>
    	<!-- end preloader -->

        <!-- start header -->
        <header style="padding: 3%;">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 col-sm-4 col-xs-12">
                        <p><i class="fa fa-phone"></i><span> Telefono</span>4955-3789</p>
                    </div>
                    <div class="col-md-3 col-sm-4 col-xs-12">
                        <div style="display: flex;"><i class="fa fa-envelope-o"></i><span> Email</span><a href="#">info@cachorros.com.ar</a></div>
                    </div>
                    <div class="col-md-5 col-sm-4 col-xs-12">
                        <ul class="social-icon">
                            <li><span>Conocenos</span></li>
                            <li><a href="#" class="fa fa-facebook"></a></li>
                            <li><a href="#" class="fa fa-twitter"></a></li>
                            <li><a href="#" class="fa fa-instagram"></a></li>
                            <li><a href="#" class="fa fa-apple"></a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </header>
        <!-- end header -->

    	<!-- start navigation -->
		<nav class="navbar navbar-default templatemo-nav" style="display: inline-table;" role="navigation">
			<div class="container">
				<div class="navbar-header">
					<button class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
						<span class="icon icon-bar"></span>
						<span class="icon icon-bar"></span>
						<span class="icon icon-bar"></span>
					</button>
					<a href="#" class="navbar-brand">Cachorros</a>
				</div>
				<div class="collapse navbar-collapse">
					<ul class="nav navbar-nav navbar-right">
						<li><a href="#top" onclick="window.open('/Default.aspx#top','_self')">INICIO</a></li>
                        <li><a href="#about" onclick="window.open('/Default.aspx#about','_self')">SOBRE NOSOTROS</a></li>
						<li><a href="#team" onclick="window.open('/Default.aspx#team','_self')">EQUIPO</a></li>
						<li><a href="#service" onclick="window.open('/Default.aspx#service','_self')">SERVICIOS</a></li>
						<li><a href="#portfolio" onclick="window.open('/Default.aspx#portfolio','_self')">PRODUCTOS</a></li>
						<li><a href="#contact" onclick="window.open('/Default.aspx#contact','_self')">CONTACTO</a></li>
					</ul>
				</div>
			</div>
		</nav>
		<!-- end navigation -->
    <div class="auto-style1">
    
       <!-- PARTE QUE NO HIZO GASTON -->
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
              
              <asp:Button ID="Button1" OnClick="Accion_Click" runat="server"  ValidationGroup="Realizar" Text="Realizar" Width="52px" ForeColor="Black" /> 
                
              <asp:Button ID="Button3" runat="server" Text="Volver" OnClick="Button2_Click"  ForeColor="Black" Width="52px" style="margin-left: 30px" />

          </div>
        <div style="margin-left: 80px">
            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#33CC33"></asp:Label>
        </div>
          

    
    </div>
    </form>

</body>
</html>

