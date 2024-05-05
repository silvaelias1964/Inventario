/* Name: sp_ActInventario.SQL
   File: sp_ActInventario
   Date: May-2024
   Actualization: 02-05-2024
   Author: Elias Silva
   System: Inventario
   Note: Actualización de Inventario     
*/

USE Inventario
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'sp_ActInventario' AND type = 'P')
   DROP PROCEDURE sp_ActInventario
GO

-- Init process
CREATE PROCEDURE sp_ActInventario
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
IF object_id('dbo.sp_ActInventario') IS NOT NULL
	PRINT '<<< Create procedure dbo.sp_ActInventario >>>'
ELSE
	PRINT '<<< The creation of the procedure failed dbo.sp_ActInventario >>>'



/*
SELECT * FROM Producto
Exec sp_ActInventario 1002,10,'E','Elias'
Exec sp_ActInventario 1002,11,'S','Elias'
*/ 