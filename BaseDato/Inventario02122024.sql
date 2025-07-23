USE [master]
GO
/****** Object:  Database [Inventario]    Script Date: 2/12/2024 11:26:36 a. m. ******/
CREATE DATABASE [Inventario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventario', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Inventario.mdf' , SIZE = 11264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Inventario_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Inventario_log.ldf' , SIZE = 2816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Inventario] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inventario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inventario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Inventario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Inventario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Inventario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Inventario] SET ARITHABORT OFF 
GO
ALTER DATABASE [Inventario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Inventario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Inventario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Inventario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Inventario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Inventario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Inventario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Inventario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Inventario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Inventario] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Inventario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Inventario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Inventario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Inventario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Inventario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Inventario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Inventario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Inventario] SET RECOVERY FULL 
GO
ALTER DATABASE [Inventario] SET  MULTI_USER 
GO
ALTER DATABASE [Inventario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Inventario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Inventario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Inventario] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Inventario]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriaProducto]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaProducto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CatNombreCategoria] [nvarchar](20) NULL,
	[CatDescripcion] [nvarchar](50) NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
 CONSTRAINT [PK_CategoriaProducto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CliCodigo] [nvarchar](15) NOT NULL,
	[CliTipo] [nvarchar](1) NOT NULL,
	[CliRazonSocial] [nvarchar](100) NOT NULL,
	[CliContacto] [nvarchar](50) NULL,
	[CliTitulo] [nvarchar](50) NULL,
	[CliDireccion] [nvarchar](500) NULL,
	[CliTelefono1] [nvarchar](25) NULL,
	[CliTelefono2] [nvarchar](25) NULL,
	[CliCorreoE] [nvarchar](50) NULL,
	[CliEstatus] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuracion]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuracion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [nvarchar](100) NULL,
	[Direccion] [nvarchar](250) NULL,
	[Ciudad] [nvarchar](50) NULL,
	[Pais] [nvarchar](50) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Correo] [nvarchar](100) NULL,
	[Contacto] [nvarchar](100) NULL,
	[Iva] [nvarchar](20) NULL,
	[PorIva] [decimal](18, 2) NOT NULL,
	[MonedaDefecto] [int] NOT NULL,
	[SmtpContrasena] [nvarchar](100) NULL,
	[SmtpPuerto] [int] NOT NULL,
	[SmtpSender] [nvarchar](200) NULL,
	[SmtpServidor] [nvarchar](200) NULL,
	[SmtpSSL] [bit] NOT NULL,
	[SmtpNombreUsuario] [nvarchar](100) NULL,
	[SmtpContrasenaUsuario] [nvarchar](100) NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
	[TipoConfig] [nvarchar](1) NULL,
 CONSTRAINT [PK_Configuracion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrada]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrada](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EntPrecioUnidad] [decimal](18, 2) NOT NULL,
	[EntStock] [int] NOT NULL,
	[EntDetalles] [nvarchar](255) NULL,
	[EntFecha] [datetime2](7) NOT NULL,
	[EntEstatus] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
	[ProductoId] [int] NOT NULL,
 CONSTRAINT [PK_Entrada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenCompra]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenCompra](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OccNroOrden] [nvarchar](15) NOT NULL,
	[OccFechaEmision] [datetime2](7) NOT NULL,
	[OccFechaOrden] [datetime2](7) NOT NULL,
	[OccFechaVencimiento] [datetime2](7) NULL,
	[ProveedorId] [int] NOT NULL,
	[OccIVA] [decimal](18, 2) NOT NULL,
	[OccDescuento] [decimal](18, 2) NOT NULL,
	[OccGasto] [decimal](18, 2) NOT NULL,
	[OccEstatus] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
	[OccDireccion] [nvarchar](500) NULL,
	[OccMismaDireccion] [bit] NOT NULL,
	[OccTelefonos] [nvarchar](100) NULL,
	[OccCorreosElec] [nvarchar](100) NULL,
	[OccObservaciones] [nvarchar](255) NULL,
 CONSTRAINT [PK_OrdenCompra] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenCompraDetalle]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenCompraDetalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[OcdCantidad] [int] NOT NULL,
	[UnidadMedidaId] [int] NULL,
	[OrdenCompraId] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
 CONSTRAINT [PK_OrdenCompraDetalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrmNombre] [nvarchar](50) NULL,
	[PrmValor] [nvarchar](100) NULL,
	[PrmTipo] [nvarchar](20) NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
 CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrdCodigo] [nvarchar](15) NOT NULL,
	[PrdNombre] [nvarchar](100) NOT NULL,
	[CategoriaProductoId] [int] NULL,
	[ProveedorId] [int] NULL,
	[PrdCantPorUnidad] [nvarchar](20) NULL,
	[PrdPrecioUnidad] [decimal](18, 2) NOT NULL,
	[PrdStockMinimo] [int] NOT NULL,
	[PrdStock] [int] NOT NULL,
	[PrdEstatus] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
	[PrdFoto1] [nvarchar](100) NULL,
	[PrdFoto2] [nvarchar](100) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrvCodigo] [nvarchar](15) NOT NULL,
	[PrvNombreCompania] [nvarchar](100) NOT NULL,
	[PrvContacto] [nvarchar](50) NULL,
	[PrvTituloContacto] [nvarchar](50) NULL,
	[PrvDireccion] [nvarchar](500) NULL,
	[PrvCiudad] [nvarchar](50) NULL,
	[PrvRegion] [nvarchar](50) NULL,
	[PrvCodigoPostal] [nvarchar](10) NULL,
	[PrvTelefono1] [nvarchar](25) NULL,
	[PrvTelefono2] [nvarchar](25) NULL,
	[PrvTelefono3] [nvarchar](25) NULL,
	[PrvCorreoE1] [nvarchar](50) NULL,
	[PrvCorreoE2] [nvarchar](50) NULL,
	[PrvPagWeb] [nvarchar](100) NULL,
	[PrvRedSocial1] [nvarchar](100) NULL,
	[PrvRedSocial2] [nvarchar](100) NULL,
	[PrvEstatus] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RolCodigo] [nvarchar](10) NOT NULL,
	[RolNombre] [nvarchar](100) NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salida]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salida](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SalStock] [int] NOT NULL,
	[SalDetalles] [nvarchar](255) NOT NULL,
	[SalFecha] [datetime2](7) NOT NULL,
	[SalEstatus] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
	[ProductoId] [int] NULL,
 CONSTRAINT [PK_Salida] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadMedida]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadMedida](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UniCodigo] [nvarchar](15) NOT NULL,
	[UniDescripcion] [nvarchar](100) NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
 CONSTRAINT [PK_UnidadMedida] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](255) NOT NULL,
	[Clave] [nvarchar](255) NULL,
	[Foto] [nvarchar](255) NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
	[RolId] [int] NULL,
	[EstatusUsuario] [int] NOT NULL,
	[IsNotificacion] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WatchDog_Logs]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WatchDog_Logs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[eventId] [varchar](100) NULL,
	[message] [varchar](max) NULL,
	[timestamp] [varchar](100) NOT NULL,
	[callingFrom] [varchar](100) NULL,
	[callingMethod] [varchar](100) NULL,
	[lineNumber] [int] NULL,
	[logLevel] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WatchDog_WatchExceptionLog]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WatchDog_WatchExceptionLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[message] [varchar](max) NULL,
	[stackTrace] [varchar](max) NULL,
	[typeOf] [varchar](max) NULL,
	[source] [varchar](max) NULL,
	[path] [varchar](max) NULL,
	[method] [varchar](30) NULL,
	[queryString] [varchar](max) NULL,
	[requestBody] [varchar](max) NULL,
	[encounteredAt] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WatchDog_WatchLog]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WatchDog_WatchLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[responseBody] [varchar](max) NULL,
	[responseStatus] [int] NOT NULL,
	[requestBody] [varchar](max) NULL,
	[queryString] [varchar](max) NULL,
	[path] [varchar](max) NULL,
	[requestHeaders] [varchar](max) NULL,
	[responseHeaders] [varchar](max) NULL,
	[method] [varchar](30) NULL,
	[host] [varchar](max) NULL,
	[ipAddress] [varchar](30) NULL,
	[timeSpent] [varchar](100) NULL,
	[startTime] [varchar](100) NOT NULL,
	[endTime] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Cliente_CliCodigo]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cliente_CliCodigo] ON [dbo].[Cliente]
(
	[CliCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cliente_Id]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cliente_Id] ON [dbo].[Cliente]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Configuracion_Id]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Configuracion_Id] ON [dbo].[Configuracion]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Entrada_Id]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Entrada_Id] ON [dbo].[Entrada]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Entrada_ProductoId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Entrada_ProductoId] ON [dbo].[Entrada]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrdenCompra_Id]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_OrdenCompra_Id] ON [dbo].[OrdenCompra]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrdenCompra_ProveedorId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_OrdenCompra_ProveedorId] ON [dbo].[OrdenCompra]
(
	[ProveedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrdenCompraDetalle_Id]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_OrdenCompraDetalle_Id] ON [dbo].[OrdenCompraDetalle]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrdenCompraDetalle_OrdenCompraId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_OrdenCompraDetalle_OrdenCompraId] ON [dbo].[OrdenCompraDetalle]
(
	[OrdenCompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrdenCompraDetalle_ProductoId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_OrdenCompraDetalle_ProductoId] ON [dbo].[OrdenCompraDetalle]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrdenCompraDetalle_UnidadMedidaId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_OrdenCompraDetalle_UnidadMedidaId] ON [dbo].[OrdenCompraDetalle]
(
	[UnidadMedidaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_CategoriaProductoId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Producto_CategoriaProductoId] ON [dbo].[Producto]
(
	[CategoriaProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_Id]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Producto_Id] ON [dbo].[Producto]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Producto_PrdCodigo]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Producto_PrdCodigo] ON [dbo].[Producto]
(
	[PrdCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Producto_PrdNombre]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Producto_PrdNombre] ON [dbo].[Producto]
(
	[PrdNombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_ProveedorId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Producto_ProveedorId] ON [dbo].[Producto]
(
	[ProveedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Proveedor_Id]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Proveedor_Id] ON [dbo].[Proveedor]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Proveedor_PrvCodigo]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Proveedor_PrvCodigo] ON [dbo].[Proveedor]
(
	[PrvCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Salida_Id]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Salida_Id] ON [dbo].[Salida]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Salida_ProductoId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Salida_ProductoId] ON [dbo].[Salida]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuario_Clave]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuario_Clave] ON [dbo].[Usuario]
(
	[Clave] ASC
)
WHERE ([Clave] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuario_Id]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuario_Id] ON [dbo].[Usuario]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuario_RolId]    Script Date: 2/12/2024 11:26:37 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Usuario_RolId] ON [dbo].[Usuario]
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (N'') FOR [CliCodigo]
GO
ALTER TABLE [dbo].[Entrada] ADD  DEFAULT ((0)) FOR [ProductoId]
GO
ALTER TABLE [dbo].[OrdenCompraDetalle] ADD  DEFAULT ((0)) FOR [OrdenCompraId]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT (N'') FOR [PrdCodigo]
GO
ALTER TABLE [dbo].[Proveedor] ADD  DEFAULT (N'') FOR [PrvCodigo]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (N'') FOR [Correo]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((0)) FOR [EstatusUsuario]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsNotificacion]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Entrada]  WITH CHECK ADD  CONSTRAINT [FK_Entrada_Producto_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Entrada] CHECK CONSTRAINT [FK_Entrada_Producto_ProductoId]
GO
ALTER TABLE [dbo].[OrdenCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompra_Proveedor_ProveedorId] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[Proveedor] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrdenCompra] CHECK CONSTRAINT [FK_OrdenCompra_Proveedor_ProveedorId]
GO
ALTER TABLE [dbo].[OrdenCompraDetalle]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompraDetalle_OrdenCompra_OrdenCompraId] FOREIGN KEY([OrdenCompraId])
REFERENCES [dbo].[OrdenCompra] ([Id])
GO
ALTER TABLE [dbo].[OrdenCompraDetalle] CHECK CONSTRAINT [FK_OrdenCompraDetalle_OrdenCompra_OrdenCompraId]
GO
ALTER TABLE [dbo].[OrdenCompraDetalle]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompraDetalle_Producto_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrdenCompraDetalle] CHECK CONSTRAINT [FK_OrdenCompraDetalle_Producto_ProductoId]
GO
ALTER TABLE [dbo].[OrdenCompraDetalle]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompraDetalle_UnidadMedida_UnidadMedidaId] FOREIGN KEY([UnidadMedidaId])
REFERENCES [dbo].[UnidadMedida] ([Id])
GO
ALTER TABLE [dbo].[OrdenCompraDetalle] CHECK CONSTRAINT [FK_OrdenCompraDetalle_UnidadMedida_UnidadMedidaId]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_CategoriaProducto_CategoriaProductoId] FOREIGN KEY([CategoriaProductoId])
REFERENCES [dbo].[CategoriaProducto] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_CategoriaProducto_CategoriaProductoId]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Proveedor_ProveedorId] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[Proveedor] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Proveedor_ProveedorId]
GO
ALTER TABLE [dbo].[Salida]  WITH CHECK ADD  CONSTRAINT [FK_Salida_Producto_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Salida] CHECK CONSTRAINT [FK_Salida_Producto_ProductoId]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_RolId] FOREIGN KEY([RolId])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol_RolId]
GO
/****** Object:  StoredProcedure [dbo].[sp_ActEstatusEntSal]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActEstatusEntSal]
(
  @p_Id INT =0,   -- Id del producto
  @p_Modo CHAR(1),         -- Modo (E)ntrada (S)alida
  @usuario VARCHAR(100)    -- Usuario
  
)

AS

DECLARE     
	@fecha DATE     -- Date server  
	SET @fecha=GETDATE()  -- Init with date server
 
IF @p_Modo='E' 
BEGIN
	IF NOT EXISTS(SELECT Id FROM Entrada WHERE Id = @p_Id)
		RETURN 1
	ELSE
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION
					UPDATE Entrada SET EntEstatus=1, FechaActualizacion=@fecha, ActualizadoPor=@usuario WHERE Id = @p_Id
				COMMIT TRANSACTION
			END TRY
			BEGIN CATCH
				IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRANSACTION;
				END			
			END CATCH
		END
	RETURN 0
END
ELSE
BEGIN
	IF NOT EXISTS(SELECT Id FROM Salida WHERE Id = @p_Id)
		RETURN 1
	ELSE
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION
					UPDATE Salida SET SalEstatus=1, FechaActualizacion=@fecha, ActualizadoPor=@usuario WHERE Id = @p_Id
				COMMIT TRANSACTION
			END TRY
			BEGIN CATCH
				IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRANSACTION;
				END			
			END CATCH
		END
	RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ActInventario]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Init process
CREATE PROCEDURE [dbo].[sp_ActInventario]
(
  @p_ProductoId INT =0,   -- Id del producto
  @p_Cantidad INT = 0,    -- Cantidad a agregar o restar
  @p_Modo CHAR(1),         -- Modo (E)ntrada (S)alida
  @p_Usuario VARCHAR(100),    -- Usuario
  @p_EntSalId INT = 0      -- Id de la entrada/salida 
  
)

AS

DECLARE     
	@fecha DATE,     -- Date server  
	@cantAct MONEY,   -- Cantidad actual
	@cantTot MONEY	-- Total 
	

	SET @fecha=GETDATE()  -- Init with date server
 
IF NOT EXISTS(SELECT Id FROM Producto WHERE Id = @p_ProductoId)
	RETURN 1
ELSE
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
			IF @p_Modo='E' 
				BEGIN
					-- Actualización de inventario
					UPDATE Producto SET PrdStock= PrdStock + @p_Cantidad, FechaActualizacion=@fecha, ActualizadoPor=@p_Usuario WHERE Id = @p_ProductoId
					-- Actualización de estatus de Entrada
					UPDATE Entrada SET EntEstatus=1, FechaActualizacion=@fecha, ActualizadoPor=@p_Usuario WHERE Id = @p_EntSalId
				END
			ELSE
				BEGIN
					SELECT @cantAct=PrdStock FROM Producto WHERE Id = @p_ProductoId
					IF (@cantAct) > 0 
						BEGIN
							SET @cantTot = @cantAct - @p_Cantidad
							IF @cantTot<0 
								SET @cantTot=0									
							-- Actualización de inventario
							UPDATE Producto SET PrdStock=@cantTot, FechaActualizacion=@fecha, ActualizadoPor=@p_Usuario   WHERE Id = @p_ProductoId										
							-- Actualización de estatus de Salida
							UPDATE Salida SET SalEstatus=1, FechaActualizacion=@fecha, ActualizadoPor=@p_Usuario WHERE Id = @p_EntSalId
						END
				END
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION;
			END			
		END CATCH
	END
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[sp_BorrarDetalleOC]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Init process
CREATE PROCEDURE [dbo].[sp_BorrarDetalleOC]
(  
  @id  INT = NULL,
  @mode INT = NULL 
)

AS
BEGIN
	BEGIN TRANSACTION 
		BEGIN TRY

			IF @mode IS NULL
				BEGIN
					DELETE FROM [dbo].[OrdenCompraDetalle] WHERE Id=@id 
				END
			ELSE
				BEGIN
					DELETE FROM [dbo].[OrdenCompraDetalle] WHERE OrdenCompraId=@id
				END
			/* Confirmamos la transaccion*/
			COMMIT TRANSACTION 
		END TRY
	BEGIN CATCH
		/* Ocurrió un error, deshacemos los cambios*/ 
		ROLLBACK TRANSACTION
		PRINT 'Ha ocurrido un error!'
	END CATCH

END

GO
/****** Object:  StoredProcedure [dbo].[sp_PasswordCheck]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Init process
CREATE PROCEDURE [dbo].[sp_PasswordCheck]
(
  @p_Id INT,    -- Usuario Id
  @p_PassWord  NVARCHAR(255),  -- Clave de acceso actual
  @p_PassWordNew VARCHAR(255),    -- Clave de acceso nueva  
  @o_Error VARCHAR(150) OUT
)
AS
SET @o_Error='Error, No existe el usuario con esta clave de acceso'
IF @p_Id>0 
BEGIN
	IF EXISTS(SELECT Id FROM Usuario WHERE Id = @p_Id AND Clave=@p_PassWord)   -- Existe
	BEGIN
		SET @o_Error='Ok'
		IF EXISTS(SELECT Id FROM Usuario WHERE Clave=@p_PassWordNew)   -- Buscar clave repetida
		BEGIN
			SET @o_Error='Error, la clave de acceso ya está asignada'
			RETURN 0
		END
	END
END
ELSE
BEGIN
	SET @o_Error='Ok'
	IF EXISTS(SELECT Id FROM Usuario WHERE Clave=@p_PassWordNew)   -- Buscar clave repetida
	BEGIN
		SET @o_Error='Error, la clave de acceso ya está asignada'
		RETURN 0
	END
END
RETURN 1

GO
/****** Object:  StoredProcedure [dbo].[sp_PasswordEdit]    Script Date: 2/12/2024 11:26:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Init process
CREATE PROCEDURE [dbo].[sp_PasswordEdit]
(
  @p_PassWord  NVARCHAR(255),  -- Clave de acceso
  @p_Correo VARCHAR(255),    -- Correo del Usuario    
  @p_Usuario VARCHAR(100),    -- Usuario
  @o_Error VARCHAR(150) OUT
)

AS

DECLARE     
	@fecha DATE     -- Date server  		

	SET @fecha=GETDATE()  -- Init with date server
 
IF EXISTS(SELECT Id FROM Usuario WHERE Correo = @p_Correo AND Clave=@p_PassWord)   -- Existe
	BEGIN
		SET @o_Error='Ok'
		IF EXISTS(SELECT Id FROM Usuario WHERE Clave=@p_PassWord)   -- Buscar clave repetida
		BEGIN
			SET @o_Error='Error, la clave ya está asignada'
			RETURN @o_Error
		END
		BEGIN TRY
			BEGIN TRANSACTION
			-- Actualización de password
			UPDATE Usuario SET Clave= @p_PassWord, FechaActualizacion=@fecha, ActualizadoPor=@p_Usuario WHERE Correo = @p_Correo AND Clave=@p_PassWord			
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION;
			END			
		END CATCH
	END
RETURN @o_Error

GO
USE [master]
GO
ALTER DATABASE [Inventario] SET  READ_WRITE 
GO
