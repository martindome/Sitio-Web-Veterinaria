use master;
Go
ALTER DATABASE VeterinariaLPPA SET SINGLE_USER WITH ROLLBACK IMMEDIATE
go
DROP DATABASE VeterinariaLPPA;
Go
USE [master]
GO
/****** Object:  Database [VeterinariaLPPA]    Script Date: 5/7/2022 03:16:57 ******/
CREATE DATABASE [VeterinariaLPPA]
 ON  PRIMARY 
( NAME = N'VeterinariaLPPA', FILENAME = N'C:\Users\marti\MCGA\MCGA-TP\Base De Datos\VeterinariaLPPA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VeterinariaLPPA_log', FILENAME = N'C:\Users\marti\MCGA\MCGA-TP\Base De Datos\VeterinariaLPPA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VeterinariaLPPA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VeterinariaLPPA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VeterinariaLPPA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET ARITHABORT OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VeterinariaLPPA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VeterinariaLPPA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VeterinariaLPPA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VeterinariaLPPA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VeterinariaLPPA] SET  MULTI_USER 
GO
ALTER DATABASE [VeterinariaLPPA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VeterinariaLPPA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VeterinariaLPPA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VeterinariaLPPA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VeterinariaLPPA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VeterinariaLPPA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [VeterinariaLPPA] SET QUERY_STORE = OFF
GO
USE [VeterinariaLPPA]
GO
/****** Object:  Table [dbo].[Accion]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accion]( --Patente
	[id] [int] NULL,
	[detalle] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[id] [int] NULL,
	[detalle] [varchar](500) NULL,
	[fecha] [varchar](500) NULL,
	[id_usuario] [int] NULL,
	[dvh] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Digito_Verificador]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Digito_Verificador](
	[ID_Digito_Verificador] [bigint] NOT NULL,
	[Tabla] [varchar](50) NOT NULL,
	[DVV] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Usuario]( --Familia
	[id] [int] NULL,
	[tipo_usuario] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario_Accion]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario_Accion]( --Familia Patente
	[id_tipousuario] [int] NULL,
	[id_accion] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] NULL,
	[usuario] [varchar](100) NULL,
	[contraseña] [varchar](100) NULL,
	[nombre] [varchar](100) NULL,
	[bloqueado] [int] NULL,
	[id_tipo_usuario] [int] NULL,
	[dvh] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] not null primary key,
	[nombre] [varchar](100) NULL,
	[tipo_producto] [varchar](100) NULL,
	[marca] [varchar](100) NULL,
	[precio] [varchar](100) NULL,
	[borrado] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venta]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[id] [int] not null primary key,
	[fecha] [varchar](500) NULL,
	[id_usuario] [int] NULL,
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle](
	[id] [int] not null,
	[id_venta] [int] FOREIGN KEY REFERENCES [dbo].[Venta]([id]),
	[id_producto] [int] FOREIGN KEY REFERENCES [dbo].[Producto]([id]),
	[cantidad] [int] NULL,
	primary key(id, id_venta, id_producto)
) ON [PRIMARY]
GO

INSERT [dbo].[Producto] ([id], [nombre], [tipo_producto], [marca], [precio], [borrado]) VALUES 
(1, 'Alimento para perros 5KG', 'Comida', 'Pro Plan', '2000', 'No'),
(2, 'Alimento para gatos 5KG', 'Comida', 'Whiskas', '2500', 'No'),
(3, 'Collar para perro', 'Accesorio', 'Collarin', '900', 'No'),
(4, 'Collar para gato', 'Accesorio', 'Coqueto', '1000', 'No'),
(5, 'Moises para perro', 'Mueble', 'Cannon', '3500', 'No'),
(6, 'Moises para gato', 'Mueble', 'Sommier Center', '4000', 'No')
GO

INSERT [dbo].[Accion] ([id], [detalle]) VALUES (1, N'Administrador')
INSERT [dbo].[Accion] ([id], [detalle]) VALUES (2, N'BackupRestore')
INSERT [dbo].[Accion] ([id], [detalle]) VALUES (3, N'CrearUsuario')
INSERT [dbo].[Accion] ([id], [detalle]) VALUES (4, N'AdministrarUsuarios')
INSERT [dbo].[Accion] ([id], [detalle]) VALUES (5, N'AdministrarPerfiles')
INSERT [dbo].[Accion] ([id], [detalle]) VALUES (6, N'Compras')
INSERT [dbo].[Accion] ([id], [detalle]) VALUES (7, N'Stock')

GO
INSERT [dbo].[Tipo_Usuario] ([id], [tipo_usuario]) VALUES (1, N'Webmaster')
INSERT [dbo].[Tipo_Usuario] ([id], [tipo_usuario]) VALUES (2, N'Cliente')
INSERT [dbo].[Tipo_Usuario] ([id], [tipo_usuario]) VALUES (3, N'Control Stock')
GO
--Permisos webmaster
INSERT [dbo].[TipoUsuario_Accion] ([id_tipousuario], [id_accion]) VALUES (1, 1)
INSERT [dbo].[TipoUsuario_Accion] ([id_tipousuario], [id_accion]) VALUES (1, 2)
INSERT [dbo].[TipoUsuario_Accion] ([id_tipousuario], [id_accion]) VALUES (1, 3)
INSERT [dbo].[TipoUsuario_Accion] ([id_tipousuario], [id_accion]) VALUES (1, 4)
INSERT [dbo].[TipoUsuario_Accion] ([id_tipousuario], [id_accion]) VALUES (1, 5)
INSERT [dbo].[TipoUsuario_Accion] ([id_tipousuario], [id_accion]) VALUES (1, 6)
INSERT [dbo].[TipoUsuario_Accion] ([id_tipousuario], [id_accion]) VALUES (1, 7)
--permisos cliente
INSERT [dbo].[TipoUsuario_Accion] ([id_tipousuario], [id_accion]) VALUES (2, 6)
--permisos control stock
INSERT [dbo].[TipoUsuario_Accion] ([id_tipousuario], [id_accion]) VALUES (3, 7)

GO
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (1, N'Inicio de Sesion - Usuario: admin', N'25/06/2020 21:45:51', 1, N'94255')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (2, N'Inicio de Sesion - Usuario: prueba', N'25/06/2020 21:46:06', 2, N'99239')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (3, N'Inicio de Sesion - Usuario: prueba', N'25/06/2020 22:08:16', 2, N'99242')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (4, N'Inicio de Sesion - Usuario: admin', N'25/06/2020 22:43:33', 1, N'94205')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (5, N'Inicio de Sesion - Usuario: admin', N'01/07/2022 10:17:56', 1, N'94294')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (6, N'Inicio de Sesion - Usuario: admin', N'01/07/2022 10:19:47', 1, N'94393')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (7, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 02:00:57', 1, N'94072')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (8, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 02:02:51', 1, N'93858')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (9, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 02:06:11', 1, N'93850')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (15, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 02:26:39', 1, N'98475')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (16, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 02:59:35', 1, N'98561')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (17, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:04:02', 1, N'97893')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (18, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:05:13', 1, N'98049')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (19, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:05:43', 1, N'98206')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (20, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:10:32', 1, N'97891')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (21, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:12:46', 1, N'98256')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (22, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:12:48', 1, N'98363')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (23, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:16:05', 1, N'98197')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (24, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:16:56', 1, N'98511')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (25, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:18:51', 1, N'98347')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (26, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:20:26', 1, N'98106')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (27, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:30:57', 1, N'98365')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (28, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:32:49', 1, N'98520')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (29, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:36:28', 1, N'98564')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (30, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:38:01', 1, N'98180')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (31, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:38:55', 1, N'98653')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (32, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:40:00', 1, N'97778')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (33, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:40:34', 1, N'98147')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (34, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:41:52', 1, N'98196')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (35, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:42:15', 1, N'98198')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (36, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:44:37', 1, N'98509')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (37, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:45:51', 1, N'98346')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (38, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:46:39', 1, N'98717')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (39, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:47:18', 1, N'98611')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (40, N'Inicio de Sesion - Usuario: cliente', N'03/07/2022 05:47:32', 2, N'108188')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (41, N'Inicio de Sesion - Usuario: cliente', N'03/07/2022 05:49:23', 2, N'108294')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (42, N'Inicio de Sesion - Usuario: cliente', N'03/07/2022 05:50:44', 2, N'108041')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (43, N'Inicio de Sesion - Usuario: cliente', N'03/07/2022 05:52:03', 2, N'107875')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (44, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 05:52:15', 1, N'98246')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (10, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 02:08:22', 1, N'98049')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (11, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 02:09:43', 1, N'98257')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (12, N'Consulta de bitacora - Usuario: admin', N'03/07/2022 02:10:28', 1, N'115835')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (13, N'Consulta de bitacora - Usuario: admin', N'03/07/2022 02:10:48', 1, N'115948')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (14, N'Inicio de Sesion - Usuario: admin', N'03/07/2022 02:12:59', 1, N'98329')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (45, N'Inicio de Sesion - Usuario: admin', N'05/07/2022 01:02:56', 1, N'98147')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (46, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:03:20', 1, N'115521')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (47, N'Inicio de Sesion - Usuario: admin', N'05/07/2022 01:05:55', 1, N'98246')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (48, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:06:00', 1, N'115573')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (49, N'Inicio de Sesion - Usuario: admin', N'05/07/2022 01:08:26', 1, N'98295')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (50, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:08:29', 1, N'116298')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (51, N'Inicio de Sesion - Usuario: admin', N'05/07/2022 01:12:41', 1, N'97875')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (52, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:12:42', 1, N'115742')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (53, N'Inicio de Sesion - Usuario: admin', N'05/07/2022 01:18:03', 1, N'98075')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (54, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:18:06', 1, N'116072')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (55, N'Inicio de Sesion - Usuario: admin', N'05/07/2022 01:19:39', 1, N'98601')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (56, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:19:41', 1, N'116067')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (57, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:21:17', 1, N'115863')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (58, N'Inicio de Sesion - Usuario: admin', N'05/07/2022 01:26:37', 1, N'98397')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (59, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:26:39', 1, N'116361')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (60, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:26:48', 1, N'116351')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (61, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:26:52', 1, N'116066')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (62, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:27:00', 1, N'115727')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (63, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:27:15', 1, N'116069')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (64, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:27:15', 1, N'116070')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (65, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:27:20', 1, N'115842')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (66, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:27:26', 1, N'116185')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (67, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:27:28', 1, N'116300')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (68, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:27:34', 1, N'116129')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (69, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:27:49', 1, N'116471')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (70, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:27:49', 1, N'116462')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (71, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:27:50', 1, N'116006')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (72, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:28:01', 1, N'115838')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (73, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:28:02', 1, N'115896')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (74, N'Inicio de Sesion - Usuario: admin', N'05/07/2022 01:31:19', 1, N'98194')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (75, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:31:23', 1, N'115742')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (76, N'Inicio de Sesion - Usuario: cliente', N'05/07/2022 01:33:10', 2, N'107597')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (77, N'Inicio de Sesion - Usuario: admin', N'05/07/2022 01:33:33', 1, N'98083')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (78, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:33:35', 1, N'116023')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (79, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:34:09', 1, N'116138')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (80, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:35:09', 1, N'116183')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (81, N'Consulta de bitacora - Usuario: admin', N'05/07/2022 01:35:15', 1, N'116012')
INSERT [dbo].[Bitacora] ([id], [detalle], [fecha], [id_usuario], [dvh]) VALUES (82, N'Inicio de Sesion - Usuario: admin', N'05/07/2022 03:03:00', 1, N'97710')
GO
INSERT [dbo].[Digito_Verificador] ([ID_Digito_Verificador], [Tabla], [DVV]) VALUES (1, N'Usuario', 182886)
INSERT [dbo].[Digito_Verificador] ([ID_Digito_Verificador], [Tabla], [DVV]) VALUES (2, N'Bitacora', 8594336)
GO
INSERT [dbo].[Usuario] ([id], [usuario], [contraseña], [nombre], [bloqueado], [id_tipo_usuario], [dvh]) VALUES (1, N'admin', N'bb68b7232bb4fcba4cd6bd26b29b544f', N'Juancito', 0, 1, N'92237')
INSERT [dbo].[Usuario] ([id], [usuario], [contraseña], [nombre], [bloqueado], [id_tipo_usuario], [dvh]) VALUES (2, N'cliente', N'bb68b7232bb4fcba4cd6bd26b29b544f', N'Patito', 0, 2, N'90649')
GO
/****** Object:  StoredProcedure [dbo].[blanquear_password]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[blanquear_password]
@usu varchar(100)
as 
begin
UPDATE dbo.Usuario SET bloqueado = 0 where usuario = @usu
end 
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.id_tipo_usuario as tipo_usuario From Usuario u where usuario = @usu
GO
/****** Object:  StoredProcedure [dbo].[cambiar_perfil]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[cambiar_perfil]
@usu varchar(100),
@tipo_usuario varchar(100)
as 
begin
UPDATE dbo.Usuario SET id_tipo_usuario = @tipo_usuario where usuario = @usu
end 
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.id_tipo_usuario as tipo_usuario From Usuario u where usuario = @usu
GO
/****** Object:  StoredProcedure [dbo].[bloquear_usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[bloquear_usuario]
@usu varchar(100)
as 
begin
UPDATE dbo.Usuario SET bloqueado = bloqueado + 1 where usuario = @usu
end 
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.id_tipo_usuario as tipo_usuario From Usuario u where usuario = @usu
GO
/****** Object:  StoredProcedure [dbo].[borrar_digito_verificador]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[borrar_digito_verificador]
@tabla varchar(100), @dvv varchar(500)
as 
begin
declare @id int
set @id = isnull((Select max(ID_Digito_Verificador) from Digito_Verificador),0 ) +1

DELETE [dbo].[Digito_Verificador] WHERE Tabla = @tabla
end
GO
/****** Object:  StoredProcedure [dbo].[desbloquear_usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[desbloquear_usuario]
@usu varchar(100)
as 
begin

UPDATE Usuario
SET bloqueado = 0
WHERE usuario = @usu;
end
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.id_tipo_usuario as tipo_usuario From Usuario u where usuario = @usu
GO

/****** Object:  StoredProcedure [dbo].[registrar_usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[registrar_usuario]
@usu varchar(100),
@pass varchar(100),
@nom varchar(100),
@tipo int
as 
begin
declare @id int
set @id = isnull((Select max(id) from Usuario),0 ) +1
INSERT INTO Usuario (id, usuario, contraseña, nombre, bloqueado, id_tipo_usuario)
VALUES (@id, @usu, @pass, @nom, 0, @tipo)
end
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.id_tipo_usuario as tipo_usuario From Usuario u where usuario = @usu
GO

/****** Object:  StoredProcedure [dbo].[listar_acciones]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_acciones]
@id_tipo_usu varchar(50)
as 
begin
select b.id, b.detalle
from TipoUsuario_Accion a 
inner join Accion b 
on a.id_accion= b.id 
where a.id_tipousuario = @id_tipo_usu
end 
GO

/****** Object:  StoredProcedure [dbo].[listar_acciones_todas]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_acciones_todas]
as 
begin
select b.id, b.detalle
from Accion b 
end 
GO

/****** Object:  StoredProcedure [dbo].[eliminar_permiso_accion]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[eliminar_permiso_accion]
@permiso int,
@accion int
as 
begin
delete TipoUsuario_Accion
where id_tipousuario = @permiso and id_accion = @accion
end 
GO

/****** Object:  StoredProcedure [dbo].[agregar_permiso_accion]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[agregar_permiso_accion]
@permiso int,
@accion int
as 
begin
insert into TipoUsuario_Accion (id_tipousuario, id_accion)
values (@permiso, @accion)
end
GO

/****** Object:  StoredProcedure [dbo].[agregar_permiso]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[agregar_permiso]
@nombre varchar(100)
as 
begin
declare @id int
set @id = isnull((Select max(id) from Tipo_Usuario),0 ) +1
insert into Tipo_Usuario (id, tipo_usuario)
values (@id, @nombre)
end
GO

/****** Object:  StoredProcedure [dbo].[listar_bitacora]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[listar_bitacora]
as 
begin
select a.*, b.nombre, b.usuario 
from Bitacora a
inner join Usuario b
on a.id_usuario = b.id
ORDER BY a.fecha DESC
end 
GO
/****** Object:  StoredProcedure [dbo].[listar_usuariosBloqueados]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[listar_usuariosBloqueados]
as 
begin
select *
from Usuario
where bloqueado = 3
end 
GO
/****** Object:  StoredProcedure [dbo].[listar_usuarios]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[listar_usuarios]
as 
begin
select *
from Usuario
end 
GO
/****** Object:  StoredProcedure [dbo].[llenar_bitacora]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[llenar_bitacora]
@id_usu varchar(100), @detalle varchar(500)
as 
begin
declare @id int
declare @fecha datetime
set @id = isnull((Select max(id) from Bitacora),0 ) +1

INSERT INTO [dbo].[Bitacora]
           ([id]
           ,[detalle]
           ,[fecha]
           ,[id_usuario])
     VALUES
           (@id,
           @detalle,
           FORMAT(SYSDATETIME(), 'dd/MM/yyyy hh:mm:ss', 'en-gb'),
           @id_usu)
end
select @id as id, @detalle as detalle, SYSDATETIME() as fecha, @id_usu as id_usu
GO


/****** Object:  StoredProcedure [dbo].[persistir_venta]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[persistir_venta]
@usu int
as 
begin
declare @id int
declare @fecha datetime
set @id = isnull((Select max(id) from Venta),0 ) +1

INSERT INTO [dbo].[Venta]
           ([id]
           ,[id_usuario]
           ,[fecha])
     VALUES
           (@id,
           @usu,
           FORMAT(SYSDATETIME(), 'dd/MM/yyyy hh:mm:ss', 'en-gb'))
end
select @id as id, @usu as id_usuario, SYSDATETIME() as fecha
GO

/****** Object:  StoredProcedure [dbo].[persistir_detalle]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[persistir_detalle]
@idventa int, @idproducto int, @cant int
as 
begin
declare @id int
declare @fecha datetime
set @id = isnull((Select max(id) from Detalle),0 ) +1

INSERT INTO [dbo].[Detalle]
           ([id]
		   ,[id_venta]
           ,[id_producto]
           ,[cantidad])
     VALUES
           (@id,
           @idventa,
		   @idproducto,
		   @cant)
end
select @id as id, @idventa as id_venta, @idproducto as id_producto, @cant as cantidad
GO

/****** Object:  StoredProcedure [dbo].[listar_productos]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_productos]
as 
begin
select *
from Producto
end
GO

/****** Object:  StoredProcedure [dbo].[listar_permisos]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_tipos]
as 
begin
select *
from Tipo_Usuario
end
GO

/****** Object:  StoredProcedure [dbo].[listar_productos]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[obtener_producto]
@id int
as 
begin
select *
from Producto
where id=@id
end
GO

/****** Object:  StoredProcedure [dbo].[crear_venta]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[crear_venta]
@id_usu int
as 
begin
declare @id int
declare @fecha datetime
set @id = isnull((Select max(id) from Venta),0 ) +1

INSERT INTO [dbo].[Venta]
           ([id]
           ,[fecha]
           ,[id_usuario])
     VALUES
           (@id,
           FORMAT(SYSDATETIME(), 'dd/MM/yyyy hh:mm:ss', 'en-gb'),
           @id_usu)
end
select @id as id, SYSDATETIME() as fecha, @id_usu as id_usu
GO

/****** Object:  StoredProcedure [dbo].[crear_detalle]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[crear_detalle]
@id_venta int, @id_producto int, @cantidad int
as 
begin
declare @id int
set @id = isnull((Select max(id) from Venta),0 ) +1

INSERT INTO [dbo].[Detalle]
           ([id]
           ,[id_venta]
		   ,[id_producto]
           ,[cantidad])
     VALUES
           (@id,
           @id_venta,
		   @id_producto,
		   @cantidad)
end
select @id as id, @id_venta as id_venta, @id_producto as id_producto, @cantidad as cantidad
GO

/****** Object:  StoredProcedure [dbo].[modificar_producto]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[modificar_producto]
@id varchar(100), @nombre varchar(100), @precio varchar(100), @marca varchar(100), @tipo varchar(100)
as 
begin

UPDATE Producto
SET nombre = @nombre, precio = @precio, marca = @marca, tipo_producto = @tipo
WHERE id = @id;
end
select u.id as id, u.nombre as nombre, u.precio as precio, u.nombre as nombre, u.marca as marca, u.tipo_producto as tipo_usuario, u.borrado as borrado From Producto u where id = @id
GO

/****** Object:  StoredProcedure [dbo].[borrar_producto]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[borrar_producto]
@id varchar(100)
as 
begin

UPDATE Producto
SET borrado = 'Si'
WHERE id = @id;
end
select u.id as id, u.nombre as nombre, u.precio as precio, u.nombre as nombre, u.marca as marca, u.tipo_producto as tipo_usuario, u.borrado as borrado From Producto u where id = @id
GO


/****** Object:  StoredProcedure [dbo].[persistir_producto]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[persistir_producto]
@nombre varchar(100), @precio varchar(100), @marca varchar(100), @tipo varchar(100)
as 
begin
declare @id int
set @id = isnull((Select max(id) from Producto),0 ) +1

INSERT INTO [dbo].[Producto]
           ([id]
		   ,[nombre]
           ,[tipo_producto]
		   ,[precio]
           ,[marca]
		   ,[borrado])
     VALUES
           (@id,
           @nombre,
		   @tipo,
		   @precio,
		   @marca,
		   'No')
end
select @id as id, @nombre as nombre, @tipo as tipo, @precio as precio, @marca as marca
GO

/****** Object:  StoredProcedure [dbo].[llenar_digito_verificador]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[llenar_digito_verificador]
@tabla varchar(100), @dvv varchar(500)
as 
begin
declare @id int
set @id = isnull((Select max(ID_Digito_Verificador) from Digito_Verificador),0 ) +1

INSERT INTO [dbo].[Digito_Verificador]
           ([ID_Digito_Verificador]
           ,[Tabla]
           ,[DVV])
     VALUES
           (@id,
           @tabla,
           @dvv)
end
GO
/****** Object:  StoredProcedure [dbo].[modificar_digito_verificador]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[modificar_digito_verificador]
@tabla varchar(100), @dvv varchar(500)
as 
begin
declare @id int
set @id = isnull((Select max(ID_Digito_Verificador) from Digito_Verificador),0 ) +1

UPDATE [dbo].[Digito_Verificador] SET DVV = @dvv WHERE Tabla = @tabla
end
GO
/****** Object:  StoredProcedure [dbo].[update_bitacora_dvh]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[update_bitacora_dvh]
@id varchar(100), @dvh varchar(500)
as 
begin

UPDATE [dbo].[Bitacora] SET dvh = @dvh WHERE id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[update_usuario_dvh]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[update_usuario_dvh]
@id varchar(100), @dvh varchar(500)
as 
begin

UPDATE [dbo].[Usuario] SET dvh = @dvh WHERE id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[verificar_usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[verificar_usuario]
@usu varchar(100), @pass varchar(100)
as 
begin
select a.id, a.nombre, a.usuario, a.contraseña, a.id_tipo_usuario, b.tipo_usuario
from Usuario a 
inner join Tipo_Usuario b 
on a.id_tipo_usuario = b.id 
where a.usuario = @usu and a.contraseña = @pass
end 
GO
/****** Object:  StoredProcedure [dbo].[verificar_usuario_sinpassword]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[verificar_usuario_sinpassword]
@usu varchar(100)
as 
begin
select a.id, a.nombre, a.usuario, a.contraseña, a.id_tipo_usuario,a.bloqueado, b.tipo_usuario
from Usuario a 
inner join Tipo_Usuario b 
on a.id_tipo_usuario = b.id 
where a.usuario = @usu
end 
GO
USE [master]
GO
ALTER DATABASE [VeterinariaLPPA] SET  READ_WRITE 
GO
