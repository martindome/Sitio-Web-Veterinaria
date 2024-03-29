﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Respuesta.aspx.cs" Inherits="Respuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
		<link rel="stylesheet" href="css/templatemo-style.css"/>
		<script src="js/jquery.js"></script>
		<script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.singlePageNav.min.js"></script>
		<script src="js/typed.js"></script>
		<script src="js/wow.min.js"></script>
		<script src="js/custom.js"></script>
        <script> 
            protected void OnPaging(object sender, GridViewPageEventArgs e)
            {
                GridView1.PageIndex = e.NewPageIndex;
                this.BindGrid();
            }
        </script>
</head>
<body style="height: 522px">
    <!-- start preloader -->
    <form id="form1" runat="server">
		<div class="preloader">
			<div class="sk-spinner sk-spinner-wave">
     	 		
     		    
     		</div>
    	</div>
    	<!-- end preloader -->

        <!-- start header -->
      <header style="padding: 1%;">
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

        
        <div style="padding: 1%;
">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Las acciones que el usuario puede realizar son:<br />
            <br />
        </div>
        <div style="margin-left: 80px">
            <asp:ListBox ID="ListBox1" runat="server" Height="105px" Width="209px" BackColor="Black"  ></asp:ListBox>
  
        </div>
            
        <div style="padding: 1%;">
            
                <br />
                <br />
                <asp:Label ID="Label8" runat="server" Text="Para realizar Backup o Restore seleccione el siguiente boton: "></asp:Label>
                <br />
            </div>

          <div style="margin-left: 80px">
              
              <asp:Button ID="Button1" runat="server" OnClick="Accion_Click" Text="Backup & Restore" Width="168px" ForeColor="Black" /> 
              
          </div>

        <br />
        <br />
        <div ID="divcito" runat="server">
            <div style="background-color: gray;">
            <div style="padding: 1%;">
            
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Para desbloquear un usuario debe seleccionarlo y pulsar el boton 'Desbloquear'"></asp:Label>
                <br />
            </div>
            <div style="margin-left: 80px">
               <asp:ListBox ID="ListBox2" runat="server" Height="105px" Width="209px" BackColor="Black"></asp:ListBox>
                <br />
                <br />
               <asp:Button ID="Button4" runat="server" Height="23px" OnClick="Button4_Click" Text="Desbloquear" Width="168px" ForeColor="Black" />
                
            </div>
            <br />
            </div>
                
            <div style="padding: 1%";>
            <asp:Label ID="Label2" runat="server" Text="Presione el boton para observar la bitacora"></asp:Label>
        </div>
       
        <div style="margin-left: 80px">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Mostar Bitacora" Visible="False" Width="168px" ForeColor="Black" Height="23px" />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Limpiar Filtros" Visible="False" Width="168px" ForeColor="Black" Height="23px" />
            <br />
            <br />
             <div>
                <br />
                <asp:Label ID="Label10" runat="server" Text="Filtros"></asp:Label>
                <br />
                <asp:Label ID="Label9" runat="server" Text="Fecha: "></asp:Label>
                <asp:Calendar ID="Calendar1" 
                selectionmode="DayWeekMonth"
                onselectionchanged="seleccionFecha"
                runat="server" Height="58px" Width="326px" BackColor="#666666" ForeColor="Black" NextPrevFormat="ShortMonth"></asp:Calendar>
            <asp:Label ID="lblFechas" runat="server" Text=""></asp:Label>
                <br />
            </div>



            <div>
                    <asp:Label ID="Label3" runat="server" Text="Usuario: "></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" ForeColor="Black" Width="222px" Height="21px" OnTextChanged="textBox1_TextChanged"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Text="Presione enter para filtrar."></asp:Label>
                </div>
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
        </div>
    
        
    </form>
</body>
</html>