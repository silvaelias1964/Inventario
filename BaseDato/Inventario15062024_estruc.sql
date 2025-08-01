USE [Inventario]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[CategoriaProducto]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[data$]    Script Date: 15/6/2024 11:15:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[data$](
	[id] [int] NULL,
	[PrvCodigo] [nvarchar](15) NULL,
	[PrvNombreCompania] [nvarchar](100) NULL,
	[PrvContacto] [nvarchar](50) NULL,
	[PrvTituloContacto] [nvarchar](50) NULL,
	[PrvDireccion] [nvarchar](255) NULL,
	[PrvCiudad] [nvarchar](50) NULL,
	[PrvRegion] [nvarchar](50) NULL,
	[PrvCodigoPostal] [nvarchar](10) NULL,
	[PrvTelefono1] [nvarchar](25) NULL,
	[PrvTelefono2] [nvarchar](25) NULL,
	[PrvCorreoE1] [nvarchar](50) NULL,
	[PrvCorreoE2] [nvarchar](50) NULL,
	[PrvPagWeb] [nvarchar](100) NULL,
	[PrvRedSocial1] [nvarchar](100) NULL,
	[PrvEstatus] [int] NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[CreadoPor] [nvarchar](100) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ActualizadoPor] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrada]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[OrdenCompra]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
	[OccMismaDireccion] [int] NOT NULL,
	[OccNombre] [nvarchar](100) NULL,
	[OccTelefono1] [nvarchar](25) NULL,
	[OccTelefono2] [nvarchar](25) NULL,
	[OccTelefono3] [nvarchar](25) NULL,
 CONSTRAINT [PK_OrdenCompra] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenCompraDetalle]    Script Date: 15/6/2024 11:15:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenCompraDetalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[OcdCantidad] [int] NOT NULL,
	[UnidadMedidaId] [int] NOT NULL,
	[OrdenCompraId] [int] NULL,
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
/****** Object:  Table [dbo].[Producto]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[Proveedor]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[Rol]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[Salida]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[UnidadMedida]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (N'') FOR [CliCodigo]
GO
ALTER TABLE [dbo].[Entrada] ADD  DEFAULT ((0)) FOR [ProductoId]
GO
ALTER TABLE [dbo].[OrdenCompra] ADD  DEFAULT ((0)) FOR [OccMismaDireccion]
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
/****** Object:  StoredProcedure [dbo].[sp_ActEstatusEntSal]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ActInventario]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[sp_BorrarDetalleOC]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[sp_PasswordCheck]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[sp_PasswordEdit]    Script Date: 15/6/2024 11:15:36 a. m. ******/
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
