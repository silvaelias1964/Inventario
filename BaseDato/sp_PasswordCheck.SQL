/* Name: sp_PasswordCheck.SQL
   File: sp_PasswordCheck
   Date: May-2024
   Actualization: 13-05-2024
   Author: Elias Silva
   System: Inventario
   Note: Verificar si se puede cambiar la clave
*/

USE Inventario
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'sp_PasswordCheck' AND type = 'P')
   DROP PROCEDURE sp_PasswordCheck
GO

-- Init process
CREATE PROCEDURE sp_PasswordCheck
(
  @p_Id INT,    -- Usuario Id
  @p_PassWord  NVARCHAR(255),  -- Clave de acceso actual
  @p_PassWordNew VARCHAR(255),    -- Clave de acceso nueva  
  @o_Error VARCHAR(150) OUT
)
AS
SET @o_Error='Error, No existe el usuario con esta clave de acceso'
IF EXISTS(SELECT Id FROM Usuario WHERE Id = @p_Id AND Clave=@p_PassWord)   -- Existe
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
IF object_id('dbo.sp_PasswordCheck') IS NOT NULL
	PRINT '<<< Create procedure dbo.sp_PasswordCheck >>>'
ELSE
	PRINT '<<< The creation of the procedure failed dbo.sp_PasswordCheck >>>'

/*
SELECT * FROM Usuario
DECLARE @o_salida NVARCHAR(150),
@p_id INT,
@p_password NVARCHAR(255),
@p_passwordNew NVARCHAR(255)

SET @p_id = 1
SET @p_password = '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918'
SET @p_passwordNew = '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a919'

EXEC sp_PasswordCheck @p_id, @p_password, @p_passwordNew, @o_salida OUT
 
SELECT @o_salida
*/
