/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[PrdCodigo]
      ,[PrdNombre]
      ,[CatId]
      ,[PrvId]
      ,[PrdCantPorUnidad]
      ,[PrdPrecioUnidad]
      ,[PrdStockMinimo]
      ,[PrdStock]
      ,[PrdEstatus]
      ,[FechaCreacion]
      ,[CreadoPor]
      ,[FechaActualizacion]
      ,[ActualizadoPor]
      ,[PrdFoto1]
      ,[PrdFoto2]
  FROM [Inventario].[dbo].[Producto]

SELECT E.Id, E.ProductoId, P.PrdCodigo, P.PrdNombre, E.EntPrecioUnidad, E.EntStock, E.EntFecha, E.EntEstatus
            FROM Entrada E INNER JOIN Producto P ON P.Id = E.ProductoId 

DELETE FROM Entrada WHERE Id=4
