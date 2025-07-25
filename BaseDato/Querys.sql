/****** Script for SelectTopNRows command from SSMS  ******/
SELECT *  FROM [Inventario].[dbo].[data$]

  select UPPER(substring(PrvNombreCompania,1,10))+LTRIM(STR(id)) FROM [Inventario].[dbo].[data$]
/*
  UPDATE [Inventario].[dbo].[data$] SET PrvCodigo=UPPER(substring(PrvNombreCompania,1,10))+LTRIM(STR(id))
  UPDATE [Inventario].[dbo].[data$] SET PrvEstatus=1
  UPDATE [Inventario].[dbo].[data$] SET FechaCreacion='2023-08-29 15:00:58.8472039'
  UPDATE [Inventario].[dbo].[data$] SET CreadoPor='system'


  select PrvCodigo FROM [Inventario].[dbo].[data$]
*/




/****** Script for SelectTopNRows command from SSMS  ******/
SELECT DISTINCT [Id]
      ,[Code]
      ,[Description]
      ,[Existence]
      ,[Minimum]
      ,[Cost]
      ,[SubCategoryId]
      ,[UnitMeasureId]
      ,[ProductFeatureId],
	  ConcurrencyToken
  FROM [SystemERP_DB].[dbo].[Products] 
--order by ConcurrencyToken

SELECT distinct * FROM [dbo].[Prices] WHERE Prices.PriceMxDate='2022-05-24' ORDER BY StructureId

SELECT DISTINCT 
  Products.Id, Products.Code, Products.Description, Products.Existence, Products.Minimum, Products.Cost, Products.SubCategoryId, 
  Products.UnitMeasureId, Products.ProductFeatureId, Products.ConcurrencyToken, 
  Prices.PriceAll, Prices.ProductId, Prices.PriceArg, Prices.PriceArgDate, Prices.PriceArgObservations, Prices.PriceMx, 
  Prices.PriceMxObservations, SubCategories.Description AS SubCategoria, Categories.Description AS Categoria
FROM            Products INNER JOIN
                         Prices ON Products.Id = Prices.ProductId INNER JOIN
                         SubCategories ON Products.SubCategoryId = SubCategories.Id INNER JOIN
                         Categories ON SubCategories.CategoryId = Categories.Id
WHERE        (Prices.PriceAllDate = '2022-05-24')



GO
SET IDENTITY_INSERT [dbo].[OrdenCompraDetalle] ON 

INSERT [dbo].[OrdenCompraDetalle] ([Id], [ProductoId], [OcdCantidad], [UnidadMedidaId], [OrdenCompraId], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (1, 1, 20, 2, 2, CAST(N'2024-06-14T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL)
INSERT [dbo].[OrdenCompraDetalle] ([Id], [ProductoId], [OcdCantidad], [UnidadMedidaId], [OrdenCompraId], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (2, 2, 15, 2, 2, CAST(N'2024-06-14T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL)
INSERT [dbo].[OrdenCompraDetalle] ([Id], [ProductoId], [OcdCantidad], [UnidadMedidaId], [OrdenCompraId], [FechaCreacion], [CreadoPor], [FechaActualizacion], [ActualizadoPor]) VALUES (3, 3, 10, 2, 2, CAST(N'2024-06-14T00:00:00.0000000' AS DateTime2), N'Admin', NULL, NULL)
SET IDENTITY_INSERT [dbo].[OrdenCompraDetalle] OFF

