USE [TP]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 12/07/2017 12:12:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleados](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[dirección] [varchar](50) NOT NULL,
	[teléfono] [varchar](20) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[sueldo] [float] NULL,
	[localidad] [int] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 12/07/2017 12:12:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localidades](
	[codigoLocalidad] [int] IDENTITY(1,1) NOT NULL,
	[localidad] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[codigoLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [dirección], [teléfono], [fechaNacimiento], [sueldo], [localidad]) VALUES (1, N'Roberto Pérez', N'Av. Mitre 750', N'0112234223', CAST(0xEF130B00 AS Date), 20000, 1)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [dirección], [teléfono], [fechaNacimiento], [sueldo], [localidad]) VALUES (2, N'Luis Rodríguez', N'Azcuénaga 233', N'02223332223', CAST(0x64080B00 AS Date), 10500, 2)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [dirección], [teléfono], [fechaNacimiento], [sueldo], [localidad]) VALUES (3, N'Rosa Gómez', N'Olivera 393', N'02224452678 ', CAST(0x3C040B00 AS Date), 16920, 1)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [dirección], [teléfono], [fechaNacimiento], [sueldo], [localidad]) VALUES (4, N'José Luis Perales', N'Calle 483 entre 41 y 43', N'0111588339280', CAST(0xF7F90A00 AS Date), 19000, 1)
INSERT [dbo].[Empleados] ([idEmpleado], [nombre], [dirección], [teléfono], [fechaNacimiento], [sueldo], [localidad]) VALUES (11, N'Julio Pérez', N'Calle falsa 123', N'011334567', CAST(0x4E130B00 AS Date), 20000, 2)
SET IDENTITY_INSERT [dbo].[Empleados] OFF
SET IDENTITY_INSERT [dbo].[Localidades] ON 

INSERT [dbo].[Localidades] ([codigoLocalidad], [localidad]) VALUES (1, N'Avellaneda')
INSERT [dbo].[Localidades] ([codigoLocalidad], [localidad]) VALUES (2, N'Lanús')
INSERT [dbo].[Localidades] ([codigoLocalidad], [localidad]) VALUES (3, N'Presidente Perón')
SET IDENTITY_INSERT [dbo].[Localidades] OFF
