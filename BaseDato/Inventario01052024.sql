USE [master]
GO
/****** Object:  Database [Inventario]    Script Date: 1/5/2024 9:46:34 a. m. ******/
CREATE DATABASE [Inventario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventario', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Inventario.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Inventario_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Inventario_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/5/2024 9:46:34 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/5/2024 9:46:34 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/5/2024 9:46:34 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/5/2024 9:46:34 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/5/2024 9:46:34 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/5/2024 9:46:34 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/5/2024 9:46:34 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/5/2024 9:46:34 a. m. ******/
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
/****** Object:  Table [dbo].[CategoriaProducto]    Script Date: 1/5/2024 9:46:34 a. m. ******/
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 1/5/2024 9:46:34 a. m. ******/
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
/****** Object:  Table [dbo].[Entrada]    Script Date: 1/5/2024 9:46:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrada](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EntPrecioUnidad] [decimal](18, 2) NOT NULL,
	[EntStock] [int] NOT NULL,
	[EntDetalles] [nvarchar](255) NOT NULL,
	[EntFecha] [datetime2](7) NOT NULL,
	[EntEstatus] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
	[ProductoId] [int] NULL,
 CONSTRAINT [PK_Entrada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 1/5/2024 9:46:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrdCodigo] [nvarchar](15) NOT NULL,
	[PrdNombre] [nvarchar](100) NOT NULL,
	[CatId] [int] NULL,
	[PrvId] [int] NULL,
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
/****** Object:  Table [dbo].[Proveedor]    Script Date: 1/5/2024 9:46:34 a. m. ******/
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
/****** Object:  Table [dbo].[Salida]    Script Date: 1/5/2024 9:46:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salida](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SalPrecioUnidad] [decimal](18, 2) NOT NULL,
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 1/5/2024 9:46:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](max) NULL,
	[Clave] [nvarchar](255) NOT NULL,
	[Foto] [nvarchar](255) NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230829182435_Inicial', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230902173756_IndicesCodigo', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230902174244_IndicesCodigoObligatorio', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230908194354_Entrada', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231024205452_UrlFotoProducto', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231024210921_CamposFotosProducto', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240131012155_Usuario', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240217183007_Salida', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240218145447_EntradaSalida', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428001355_CambioIdEntrada', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240501134331_CambioSalida', N'7.0.10')
GO
SET IDENTITY_INSERT [dbo].[CategoriaProducto] ON 

INSERT [dbo].[CategoriaProducto] ([Id], [CatNombreCategoria], [CatDescripcion], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (1, N'Harinas', N'Harina de Maiz', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-01-21T13:21:02.5263906' AS DateTime2), N'system')
INSERT [dbo].[CategoriaProducto] ([Id], [CatNombreCategoria], [CatDescripcion], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (2, N'Pastas', N'Pasta Larga', CAST(N'2023-08-22T16:46:46.9871459' AS DateTime2), N'system', NULL, NULL)
INSERT [dbo].[CategoriaProducto] ([Id], [CatNombreCategoria], [CatDescripcion], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (3, N'Pastas', N'Pasta Corta', CAST(N'2023-08-22T16:47:02.4197373' AS DateTime2), N'system', NULL, NULL)
SET IDENTITY_INSERT [dbo].[CategoriaProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [CliCodigo], [CliTipo], [CliRazonSocial], [CliContacto], [CliTitulo], [CliDireccion], [CliTelefono1], [CliTelefono2], [CliCorreoE], [CliEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (1, N'7069553', N'1', N'Elias Silva Sistemas', N'Elias ', N'EESP', N'Caricuao, Zoologico', N'223111', N'2222', N'silvaelias@hotmail.com', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-04-17T22:53:55.9664262' AS DateTime2), N'Elias Silva')
INSERT [dbo].[Cliente] ([Id], [CliCodigo], [CliTipo], [CliRazonSocial], [CliContacto], [CliTitulo], [CliDireccion], [CliTelefono1], [CliTelefono2], [CliCorreoE], [CliEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (2, N'12345367', N'2', N'Almacenes La Solución', N'Pablo', N'Pablo', N'Zona Industrial Los Ruices', N'223412344', NULL, NULL, 1, CAST(N'2023-08-30T13:59:11.0275373' AS DateTime2), N'system', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Entrada] ON 

INSERT [dbo].[Entrada] ([Id], [EntPrecioUnidad], [EntStock], [EntDetalles], [EntFecha], [EntEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor], [ProductoId]) VALUES (1, CAST(26.00 AS Decimal(18, 2)), 10, N'sasass', CAST(N'2024-02-18T00:00:00.0000000' AS DateTime2), 1, CAST(N'2024-02-18T00:00:00.0000000' AS DateTime2), N'admin', NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Entrada] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [PrdCodigo], [PrdNombre], [CatId], [PrvId], [PrdCantPorUnidad], [PrdPrecioUnidad], [PrdStockMinimo], [PrdStock], [PrdEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor], [PrdFoto1], [PrdFoto2]) VALUES (1, N'HP1', N'Harina Pan', 1, 2, N'12xBulto', CAST(25.00 AS Decimal(18, 2)), 12, 100, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2024-01-21T13:22:07.5538709' AS DateTime2), N'system', N'2.jpg', N'3.jpg')
INSERT [dbo].[Producto] ([Id], [PrdCodigo], [PrdNombre], [CatId], [PrvId], [PrdCantPorUnidad], [PrdPrecioUnidad], [PrdStockMinimo], [PrdStock], [PrdEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor], [PrdFoto1], [PrdFoto2]) VALUES (2, N'HP2', N'Pasta Larga Veluchini', 2, 2, N'6', CAST(25.00 AS Decimal(18, 2)), 10, 100, 1, CAST(N'2023-10-26T22:50:12.8960251' AS DateTime2), N'system', NULL, NULL, N'10.jpg', N'19.jpg')
INSERT [dbo].[Producto] ([Id], [PrdCodigo], [PrdNombre], [CatId], [PrvId], [PrdCantPorUnidad], [PrdPrecioUnidad], [PrdStockMinimo], [PrdStock], [PrdEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor], [PrdFoto1], [PrdFoto2]) VALUES (1002, N'PastaCor1', N'Pasta corta ', 3, 2, N'20', CAST(25.00 AS Decimal(18, 2)), 1, 10, 1, CAST(N'2024-03-24T11:43:46.8829396' AS DateTime2), N'Elias Silva', NULL, NULL, N'4Generaciones.jpg', N'5FormulasdeExcel.jpg')
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([Id], [PrvCodigo], [PrvNombreCompania], [PrvContacto], [PrvTituloContacto], [PrvDireccion], [PrvCiudad], [PrvRegion], [PrvCodigoPostal], [PrvTelefono1], [PrvTelefono2], [PrvTelefono3], [PrvCorreoE1], [PrvCorreoE2], [PrvPagWeb], [PrvRedSocial1], [PrvRedSocial2], [PrvEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (1, N'PROV1', N'Fabrica La Lucha', N'Jose', N'El jefe', N'Antimano', N'Caracas', N'Capital', N'1000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-10-24T16:11:59.8016521' AS DateTime2), N'system')
INSERT [dbo].[Proveedor] ([Id], [PrvCodigo], [PrvNombreCompania], [PrvContacto], [PrvTituloContacto], [PrvDireccion], [PrvCiudad], [PrvRegion], [PrvCodigoPostal], [PrvTelefono1], [PrvTelefono2], [PrvTelefono3], [PrvCorreoE1], [PrvCorreoE2], [PrvPagWeb], [PrvRedSocial1], [PrvRedSocial2], [PrvEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (2, N'PROV2', N'Alimentos Pan', N'Pablo Gonzalez', N'Pablo', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-08-29T15:00:58.8472039' AS DateTime2), N'system', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [NombreUsuario], [Correo], [Clave], [Foto], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (1, N'Elias Silva', N'silvaeliasjj@gmail.com', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'/avatar/img009.jpg', CAST(N'2024-01-30T21:46:00.6595504' AS DateTime2), N'system', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 1/5/2024 9:46:34 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 1/5/2024 9:46:34 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Cliente_CliCodigo]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cliente_CliCodigo] ON [dbo].[Cliente]
(
	[CliCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cliente_Id]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cliente_Id] ON [dbo].[Cliente]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Entrada_Id]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Entrada_Id] ON [dbo].[Entrada]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Entrada_ProductoId]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Entrada_ProductoId] ON [dbo].[Entrada]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_CatId]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Producto_CatId] ON [dbo].[Producto]
(
	[CatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_Id]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Producto_Id] ON [dbo].[Producto]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Producto_PrdCodigo]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Producto_PrdCodigo] ON [dbo].[Producto]
(
	[PrdCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Producto_PrvId]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Producto_PrvId] ON [dbo].[Producto]
(
	[PrvId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Proveedor_Id]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Proveedor_Id] ON [dbo].[Proveedor]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Proveedor_PrvCodigo]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Proveedor_PrvCodigo] ON [dbo].[Proveedor]
(
	[PrvCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Salida_Id]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Salida_Id] ON [dbo].[Salida]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Salida_ProductoId]    Script Date: 1/5/2024 9:46:35 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Salida_ProductoId] ON [dbo].[Salida]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (N'') FOR [CliCodigo]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT (N'') FOR [PrdCodigo]
GO
ALTER TABLE [dbo].[Proveedor] ADD  DEFAULT (N'') FOR [PrvCodigo]
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
GO
ALTER TABLE [dbo].[Entrada] CHECK CONSTRAINT [FK_Entrada_Producto_ProductoId]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_CategoriaProducto_CatId] FOREIGN KEY([CatId])
REFERENCES [dbo].[CategoriaProducto] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_CategoriaProducto_CatId]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Proveedor_PrvId] FOREIGN KEY([PrvId])
REFERENCES [dbo].[Proveedor] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Proveedor_PrvId]
GO
ALTER TABLE [dbo].[Salida]  WITH CHECK ADD  CONSTRAINT [FK_Salida_Producto_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Salida] CHECK CONSTRAINT [FK_Salida_Producto_ProductoId]
GO
USE [master]
GO
ALTER DATABASE [Inventario] SET  READ_WRITE 
GO
