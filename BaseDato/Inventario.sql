USE [Inventario]
GO
SET IDENTITY_INSERT [dbo].[CategoriaProducto] ON 

INSERT [dbo].[CategoriaProducto] ([Id], [CatNombreCategoria], [CatDescripcion], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (1, N'Harinas', N'Harina de Maiz', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-08-22T16:49:12.1802562' AS DateTime2), N'system')
INSERT [dbo].[CategoriaProducto] ([Id], [CatNombreCategoria], [CatDescripcion], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (2, N'Pastas', N'Pasta Larga', CAST(N'2023-08-22T16:46:46.9871459' AS DateTime2), N'system', NULL, NULL)
INSERT [dbo].[CategoriaProducto] ([Id], [CatNombreCategoria], [CatDescripcion], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (3, N'Pastas', N'Pasta Corta', CAST(N'2023-08-22T16:47:02.4197373' AS DateTime2), N'system', NULL, NULL)
SET IDENTITY_INSERT [dbo].[CategoriaProducto] OFF
GO
