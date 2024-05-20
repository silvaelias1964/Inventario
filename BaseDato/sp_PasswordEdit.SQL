/* Name: sp_PasswordEdit.SQL
   File: sp_PasswordEdit
   Date: May-2024
   Actualization: 13-05-2024
   Author: Elias Silva
   System: Inventario
   Note: Agregar/Cambiar clave
*/

USE Inventario
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'sp_PasswordEdit' AND type = 'P')
   DROP PROCEDURE sp_PasswordEdit
GO

-- Init process
CREATE PROCEDURE sp_PasswordEdit
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
IF object_id('dbo.sp_PasswordEdit') IS NOT NULL
	PRINT '<<< Create procedure dbo.sp_PasswordEdit >>>'
ELSE
	PRINT '<<< The creation of the procedure failed dbo.sp_PasswordEdit >>>'


