/*
Script de Creacion inicial de Empresa generica
Sistema de Inventario

*/

USE [Inventario]
GO

INSERT INTO [dbo].[Configuracion]
           ([Empresa]
           ,[Direccion]
           ,[Ciudad]
           ,[Pais]
           ,[Telefono]
           ,[Correo]
           ,[Contacto]
           ,[Iva]
           ,[PorIva]
           ,[MonedaDefecto]
           ,[SmtpContrasena]
           ,[SmtpPuerto]
           ,[SmtpSender]
           ,[SmtpServidor]
           ,[SmtpSSL]
           ,[SmtpNombreUsuario]
           ,[SmtpContrasenaUsuario]
           ,[FechaCreacion]
           ,[CreadoPor]
           ,[FechaActualizacion]
           ,[ActualizadoPor]
           ,[TipoConfig])
     VALUES
           ('EESP Sistemas'
           ,'Caricuao'
           ,'Caracas'
           ,'Venezuela'
           ,'+99 999 9999999'
           ,'silvaeliasjj@gmail.com'
           ,'Elias Silva'
           ,'IVA'
           ,12
           ,1
           ,'1234567'
           ,456
           ,'Ninguno'
           ,'Ninguno'
           ,0
           ,'admin'
           ,'admin1234'
           ,CAST(N'2024-01-11T13:21:02.5263906' AS DateTime2)
           ,'admin'
           ,CAST(N'2024-01-11T13:21:02.5263906' AS DateTime2)
           ,'admin'
           ,'D')
GO


