USE [Inventario]
GO
SET IDENTITY_INSERT [dbo].[CategoriaProducto] ON 

INSERT [dbo].[CategoriaProducto] ([Id], [CatNombreCategoria], [CatDescripcion], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (1, N'Harinas', N'Harina de Maiz', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-08-22T16:49:12.1802562' AS DateTime2), N'system')
INSERT [dbo].[CategoriaProducto] ([Id], [CatNombreCategoria], [CatDescripcion], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (2, N'Pastas', N'Pasta Larga', CAST(N'2023-08-22T16:46:46.9871459' AS DateTime2), N'system', NULL, NULL)
INSERT [dbo].[CategoriaProducto] ([Id], [CatNombreCategoria], [CatDescripcion], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (3, N'Pastas', N'Pasta Corta', CAST(N'2023-08-22T16:47:02.4197373' AS DateTime2), N'system', NULL, NULL)
SET IDENTITY_INSERT [dbo].[CategoriaProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([Id], [PrvCodigo], [PrvNombreCompania], [PrvContacto], [PrvTituloContacto], [PrvDireccion], [PrvCiudad], [PrvRegion], [PrvCodigoPostal], [PrvTelefono1], [PrvTelefono2], [PrvTelefono3], [PrvCorreoE1], [PrvCorreoE2], [PrvPagWeb], [PrvRedSocial1], [PrvRedSocial2], [PrvEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (1, N'PROV1', N'Fabrica La Lucha', N'Jose', N'El jefe', N'Antimano', N'Caracas', N'Capital', N'1000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-08-30T15:03:01.3635765' AS DateTime2), N'system')
INSERT [dbo].[Proveedor] ([Id], [PrvCodigo], [PrvNombreCompania], [PrvContacto], [PrvTituloContacto], [PrvDireccion], [PrvCiudad], [PrvRegion], [PrvCodigoPostal], [PrvTelefono1], [PrvTelefono2], [PrvTelefono3], [PrvCorreoE1], [PrvCorreoE2], [PrvPagWeb], [PrvRedSocial1], [PrvRedSocial2], [PrvEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (2, N'PROV2', N'Alimentos Pan', N'Pablo Gonzalez', N'Pablo', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-08-29T15:00:58.8472039' AS DateTime2), N'system', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [PrdCodigo], [PrdNombre], [CatId], [PrvId], [PrdCantPorUnidad], [PrdPrecioUnidad], [PrdStockMinimo], [PrdStock], [PrdEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (1, N'HP1', N'Harina Pan', 1, 2, N'12xBulto', CAST(25.00 AS Decimal(18, 2)), 12, 100, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-08-30T15:01:50.2966691' AS DateTime2), N'system')
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230829182435_Inicial', N'7.0.10')
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [CliCodigo], [CliTipo], [CliRazonSocial], [CliContacto], [CliTitulo], [CliDireccion], [CliTelefono1], [CliTelefono2], [CliCorreoE], [CliEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (1, N'7069553', N'0', N'Elias Silva Sistemas', N'Elias ', N'EESP', N'Caricuao, Zoologico', N'223111', N'2222', N'silvaelias@hotmail.com', 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-09-01T15:33:47.5766189' AS DateTime2), N'system')
INSERT [dbo].[Cliente] ([Id], [CliCodigo], [CliTipo], [CliRazonSocial], [CliContacto], [CliTitulo], [CliDireccion], [CliTelefono1], [CliTelefono2], [CliCorreoE], [CliEstatus], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (2, N'12345367', N'2', N'Almacenes La Solución', N'Pablo', N'Pablo', N'Zona Industrial Los Ruices', N'223412344', NULL, NULL, 1, CAST(N'2023-08-30T13:59:11.0275373' AS DateTime2), N'system', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
