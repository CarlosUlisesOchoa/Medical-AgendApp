USE [agendappDb]
GO
SET IDENTITY_INSERT [dbo].[roles] ON 

INSERT [dbo].[roles] ([idRol], [nombre]) VALUES (1, N'usuario')
INSERT [dbo].[roles] ([idRol], [nombre]) VALUES (2, N'medico')
INSERT [dbo].[roles] ([idRol], [nombre]) VALUES (3, N'admin')
SET IDENTITY_INSERT [dbo].[roles] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([idUsuario], [dni], [nombre], [apellido], [email], [telefono], [contrasenia], [idRol]) VALUES (1, N'1092653324', N'Maria', N'Pasoca', N'mapaso@gmail.com', N'3012345632', N'12345678', 1)
INSERT [dbo].[usuarios] ([idUsuario], [dni], [nombre], [apellido], [email], [telefono], [contrasenia], [idRol]) VALUES (2, N'1072123123', N'Pepe', N'Grillo', N'pegri@outlook.com', N'3221231231', N'12345', 1)
INSERT [dbo].[usuarios] ([idUsuario], [dni], [nombre], [apellido], [email], [telefono], [contrasenia], [idRol]) VALUES (3, N'1021123245', N'Minie', N'Mouse', N'minimo@gmail.com', N'3121234504', N'123456789', 1)
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
