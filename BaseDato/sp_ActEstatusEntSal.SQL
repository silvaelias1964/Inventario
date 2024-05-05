/* Name: sp_ActEstatusEntSal.SQL
   File: sp_ActEstatusEntSal
   Date: May-2024
   Actualization: 04-05-2024
   Author: Elias Silva
   System: Inventario
   Note: Actualizar estatus de Entradas o Salidas
     
     
*/

USE Inventario
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'sp_ActEstatusEntSal' AND type = 'P')
   DROP PROCEDURE sp_ActEstatusEntSal
GO

-- Init process
CREATE PROCEDURE sp_ActEstatusEntSal
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
IF object_id('dbo.sp_ActEstatusEntSal') IS NOT NULL
	PRINT '<<< Create procedure dbo.sp_ActEstatusEntSal >>>'
ELSE
	PRINT '<<< The creation of the procedure failed dbo.sp_ActEstatusEntSal >>>'



/*
SELECT * FROM Producto
SELECT * FROM Entrada
Exec sp_ActEstatusEntSal 5,'E','Elias'
Exec sp_ActEstatusEntSal 1002,11,'S','Elias'
*/ 