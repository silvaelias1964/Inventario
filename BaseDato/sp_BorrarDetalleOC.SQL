/* Name: sp_BorrarDetalleOC.SQL
   File: sp_BorrarDetalleOC
   Date: Jun-2024
   Actualization: 03-06-2024
   Author: Elias Silva
   System: Inventario
   Note: Borrado de items de OC de Inventario     
*/

USE Inventario
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'sp_BorrarDetalleOC' AND type = 'P')
   DROP PROCEDURE sp_BorrarDetalleOC
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
IF object_id('dbo.sp_BorrarDetalleOC') IS NOT NULL
	PRINT '<<< Create procedure dbo.sp_BorrarDetalleOC >>>'
ELSE
	PRINT '<<< The creation of the procedure failed dbo.sp_BorrarDetalleOC >>>'




