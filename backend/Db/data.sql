USE [agendappDb]
GO
SET IDENTITY_INSERT [dbo].[categoriasmedicas] ON 

INSERT [dbo].[categoriasmedicas] ([idCategoria], [nombre]) VALUES (1, N'Cardiología')
INSERT [dbo].[categoriasmedicas] ([idCategoria], [nombre]) VALUES (2, N'Dermatología')
INSERT [dbo].[categoriasmedicas] ([idCategoria], [nombre]) VALUES (3, N'Endocrinología')
INSERT [dbo].[categoriasmedicas] ([idCategoria], [nombre]) VALUES (4, N'Gastroenterología')
INSERT [dbo].[categoriasmedicas] ([idCategoria], [nombre]) VALUES (5, N'Geriatría')
SET IDENTITY_INSERT [dbo].[categoriasmedicas] OFF
GO
SET IDENTITY_INSERT [dbo].[horarios] ON 

INSERT [dbo].[horarios] ([idHorario], [rango]) VALUES (1, N'08:00-12:00')
INSERT [dbo].[horarios] ([idHorario], [rango]) VALUES (2, N'14:00-16:00')
INSERT [dbo].[horarios] ([idHorario], [rango]) VALUES (3, N'16:00-18:00')
INSERT [dbo].[horarios] ([idHorario], [rango]) VALUES (4, N'18:00-20:00')
INSERT [dbo].[horarios] ([idHorario], [rango]) VALUES (5, N'20:00-22:00')
SET IDENTITY_INSERT [dbo].[horarios] OFF
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
INSERT [dbo].[usuarios] ([idUsuario], [dni], [nombre], [apellido], [email], [telefono], [contrasenia], [idRol]) VALUES (3, N'1021123245', N'Minie', N'Mouse', N'minimo@gmail.com', N'3121234504', N'123456789', 2)
INSERT [dbo].[usuarios] ([idUsuario], [dni], [nombre], [apellido], [email], [telefono], [contrasenia], [idRol]) VALUES (4, N'1282342344', N'Ronald', N'Castro', N'ronica@gmail.com', N'3123123123', N'12345678', 2)
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
