USE [SurFeFinal]
GO
/****** Object:  Table [dbo].[categoria_productos]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria_productos](
	[id] [int] NOT NULL,
	[categoria] [varchar](50) NULL,
 CONSTRAINT [PK_categoria_productos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [varchar](50) NULL,
	[idCondicionIVA] [int] NOT NULL,
	[tipo_factura] [int] NULL,
	[cuit] [varchar](50) NULL,
	[domicilio] [varchar](50) NULL,
	[localidad] [int] NULL,
	[provincia] [int] NULL,
	[cp] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[anulado] [bit] NOT NULL,
	[dni] [varchar](50) NULL,
	[tipo_documento] [int] NULL,
	[email] [varchar](50) NULL,
	[barrio] [varchar](50) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compra]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compra](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [nvarchar](50) NULL,
	[id_proveedor] [int] NULL,
	[location] [varchar](1000) NULL,
	[factura] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[condicionIVA]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[condicionIVA](
	[idCondicionIVA] [int] NOT NULL,
	[descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_condicionIVA] PRIMARY KEY CLUSTERED 
(
	[idCondicionIVA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departamento]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departamento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombreDepartamento] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[factura]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[factura](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [varchar](50) NULL,
	[tipo_documento] [varchar](50) NULL,
	[fecha] [varchar](50) NULL,
	[total] [decimal](18, 0) NULL,
	[location] [varchar](1000) NULL,
 CONSTRAINT [PK_factura] PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[localidad]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localidad](
	[id] [int] NULL,
	[localidad] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[motivoBajaStock]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[motivoBajaStock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[barcodebaja] [int] NULL,
	[cantidadbaja] [int] NULL,
	[motivo] [varchar](50) NULL,
	[operador] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[numero_factura]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[numero_factura](
	[id_numero] [int] NULL,
	[numero] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ordendecompra]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ordendecompra](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [varchar](50) NULL,
	[id_proveedor] [int] NULL,
	[location] [varchar](1000) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[categoria] [int] NULL,
	[barcode] [int] NULL,
	[detalle] [varchar](50) NULL,
	[stock] [int] NULL,
	[precio] [decimal](18, 2) NULL,
	[fecha_alta] [datetime] NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [varchar](50) NULL,
	[cuit] [bigint] NULL,
	[direccion] [varchar](50) NULL,
	[idLocalidad] [int] NULL,
	[tel] [bigint] NULL,
	[correo] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedorpago]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedorpago](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_proveedor] [int] NULL,
	[fecha] [varchar](50) NULL,
	[numero_factura] [varchar](50) NULL,
	[monto] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provincia]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincia](
	[id] [int] NULL,
	[provincia] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reclamoproveedor]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reclamoproveedor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [varchar](50) NULL,
	[id_proveedor] [int] NULL,
	[location] [varchar](1000) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_documento]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_documento](
	[id] [int] NULL,
	[descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_factura]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_factura](
	[id] [int] NULL,
	[descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 18/6/2024 18:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NULL,
	[pass] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[dni] [int] NULL,
	[idDepartamento] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[categoria_productos] ([id], [categoria]) VALUES (1, N'Electricidad')
INSERT [dbo].[categoria_productos] ([id], [categoria]) VALUES (2, N'Plomeria')
INSERT [dbo].[categoria_productos] ([id], [categoria]) VALUES (3, N'Electronica')
INSERT [dbo].[categoria_productos] ([id], [categoria]) VALUES (4, N'Construccion')
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([id_cliente], [razon_social], [idCondicionIVA], [tipo_factura], [cuit], [domicilio], [localidad], [provincia], [cp], [telefono], [anulado], [dni], [tipo_documento], [email], [barrio]) VALUES (1, N'Facundo', 1, 1, N'2041', N'Bolivar 325', 1, 1, N'2113', N'3416082000', 0, N'41637946', 1, N'sadadasd', N'-')
INSERT [dbo].[cliente] ([id_cliente], [razon_social], [idCondicionIVA], [tipo_factura], [cuit], [domicilio], [localidad], [provincia], [cp], [telefono], [anulado], [dni], [tipo_documento], [email], [barrio]) VALUES (2, N'Facundo Paron', 1, 1, N'15641564561', N'asdasdasasda', 2, 1, N'2113', N'asdadsadsad', 0, N'41637946', 1, N'asdadsadsad', N'sadadsasd')
INSERT [dbo].[cliente] ([id_cliente], [razon_social], [idCondicionIVA], [tipo_factura], [cuit], [domicilio], [localidad], [provincia], [cp], [telefono], [anulado], [dni], [tipo_documento], [email], [barrio]) VALUES (3, N'vvvv', 2, 2, N'274553310', N'djdkdk', 3, 1, N'2323', N'45664646', 1, N'455555', 1, N'45664646', N'peru')
INSERT [dbo].[cliente] ([id_cliente], [razon_social], [idCondicionIVA], [tipo_factura], [cuit], [domicilio], [localidad], [provincia], [cp], [telefono], [anulado], [dni], [tipo_documento], [email], [barrio]) VALUES (4, N'Luis Eze', 1, 1, N'20319507289', N'Salta 33', 2, 1, N'2113', N'3416082000', 1, N'31950728', 1, N'3416082000', N'')
INSERT [dbo].[cliente] ([id_cliente], [razon_social], [idCondicionIVA], [tipo_factura], [cuit], [domicilio], [localidad], [provincia], [cp], [telefono], [anulado], [dni], [tipo_documento], [email], [barrio]) VALUES (5, N'Eze Suarez', 2, 1, N'20447742455', N'Sol de julio', 3, 1, N'5255', N'3856458018', 0, N'44774245', 1, N'3856458018', N'peligroso')
INSERT [dbo].[cliente] ([id_cliente], [razon_social], [idCondicionIVA], [tipo_factura], [cuit], [domicilio], [localidad], [provincia], [cp], [telefono], [anulado], [dni], [tipo_documento], [email], [barrio]) VALUES (6, N'Ordoñez Luis Carlos', 2, 1, N'20-42338127-3', N'San francisco del chañar', 2, 1, N'5209', N'3522459570', 0, N'42338127', 1, N'3522459570', N'Deportivo')
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[compra] ON 

INSERT [dbo].[compra] ([id], [fecha], [id_proveedor], [location], [factura]) VALUES (1, N'Jun 17 2024  9:45PM', 2, N'20240617_214506NotaDeCompra.pdf', N'0002-00000025')
INSERT [dbo].[compra] ([id], [fecha], [id_proveedor], [location], [factura]) VALUES (2, N'Jun 17 2024 10:54PM', 2, N'20240617_225414NotaDeCompra.pdf', NULL)
SET IDENTITY_INSERT [dbo].[compra] OFF
GO
INSERT [dbo].[condicionIVA] ([idCondicionIVA], [descripcion]) VALUES (0, N'No especificado')
INSERT [dbo].[condicionIVA] ([idCondicionIVA], [descripcion]) VALUES (1, N'Responsable Inscripto')
INSERT [dbo].[condicionIVA] ([idCondicionIVA], [descripcion]) VALUES (2, N'Consumidor Final')
INSERT [dbo].[condicionIVA] ([idCondicionIVA], [descripcion]) VALUES (3, N'Excento')
GO
SET IDENTITY_INSERT [dbo].[departamento] ON 

INSERT [dbo].[departamento] ([id], [nombreDepartamento]) VALUES (1, N'Administrador')
INSERT [dbo].[departamento] ([id], [nombreDepartamento]) VALUES (2, N'Ventas')
SET IDENTITY_INSERT [dbo].[departamento] OFF
GO
SET IDENTITY_INSERT [dbo].[factura] ON 

INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (9, N'2', N'1', N'Apr 13 2024  8:52PM', CAST(3993 AS Decimal(18, 0)), N'C:\Users\ParraX\Documents\GitHub\SurFe\SurFe SoftWare\SurFeFront\bin\Debug\net6.0-windows\20240413_205244.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (10, N'5', N'1', N'Apr 13 2024  8:55PM', CAST(10028 AS Decimal(18, 0)), N'20240413_205550.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (11, N'2', N'1', N'Apr 15 2024  7:49PM', CAST(3993 AS Decimal(18, 0)), N'20240415_194925.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (12, N'1', N'1', N'Apr 15 2024  8:34PM', CAST(2995 AS Decimal(18, 0)), N'20240415_203438.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (13, N'1', N'1', N'Apr 15 2024  8:37PM', CAST(2995 AS Decimal(18, 0)), N'20240415_203722.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (14, N'1', N'1', N'Apr 15 2024  8:39PM', CAST(0 AS Decimal(18, 0)), N'20240415_203922.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (15, N'1', N'1', N'Apr 15 2024 10:07PM', CAST(4991 AS Decimal(18, 0)), N'20240415_220754.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (16, N'1', N'1', N'Apr 15 2024 10:17PM', CAST(2995 AS Decimal(18, 0)), N'20240415_221728.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (17, N'6', N'1', N'Apr 15 2024 10:30PM', CAST(998 AS Decimal(18, 0)), N'20240415_223009.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (18, N'6', N'1', N'Apr 15 2024 10:33PM', CAST(998 AS Decimal(18, 0)), N'20240415_223303.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (19, N'1', N'1', N'Apr 15 2024 10:52PM', CAST(4991 AS Decimal(18, 0)), N'20240415_225209.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (20, N'1', N'1', N'Apr 15 2024 10:56PM', CAST(10980 AS Decimal(18, 0)), N'20240415_225559.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (21, N'5', N'1', N'Apr 15 2024 11:04PM', CAST(60890 AS Decimal(18, 0)), N'20240415_230412.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (22, N'2', N'1', N'Apr 15 2024 11:07PM', CAST(1996 AS Decimal(18, 0)), N'20240415_230746.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (23, N'2', N'1', N'Apr 15 2024 11:10PM', CAST(0 AS Decimal(18, 0)), N'20240415_231049.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (24, N'2', N'1', N'Apr 15 2024 11:11PM', CAST(1996 AS Decimal(18, 0)), N'20240415_231100.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (25, N'1', N'1', N'Apr 15 2024 11:14PM', CAST(1996 AS Decimal(18, 0)), N'20240415_231425.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (26, N'1', N'1', N'Apr 15 2024 11:19PM', CAST(1996 AS Decimal(18, 0)), N'20240415_231941.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (27, N'6', N'1', N'Apr 15 2024 11:20PM', CAST(5989 AS Decimal(18, 0)), N'20240415_232022.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (28, N'6', N'1', N'Apr 16 2024  2:42PM', CAST(998 AS Decimal(18, 0)), N'20240416_144251.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (29, N'5', N'1', N'May  7 2024  5:50PM', CAST(2412 AS Decimal(18, 0)), N'20240507_174956.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (30, N'1', N'1', N'May 16 2024 11:25PM', CAST(1500 AS Decimal(18, 0)), N'20240516_232502.pdf')
INSERT [dbo].[factura] ([id_factura], [id_cliente], [tipo_documento], [fecha], [total], [location]) VALUES (31, N'1', N'1', N'May 26 2024  4:48PM', CAST(0 AS Decimal(18, 0)), N'20240526_164757.pdf')
SET IDENTITY_INSERT [dbo].[factura] OFF
GO
INSERT [dbo].[localidad] ([id], [localidad]) VALUES (1, N'Peyrano')
INSERT [dbo].[localidad] ([id], [localidad]) VALUES (2, N'Santa Teresa')
INSERT [dbo].[localidad] ([id], [localidad]) VALUES (3, N'Rosario')
GO
SET IDENTITY_INSERT [dbo].[motivoBajaStock] ON 

INSERT [dbo].[motivoBajaStock] ([id], [barcodebaja], [cantidadbaja], [motivo], [operador]) VALUES (1, 123123, 21, N'nose test', 1)
SET IDENTITY_INSERT [dbo].[motivoBajaStock] OFF
GO
INSERT [dbo].[numero_factura] ([id_numero], [numero]) VALUES (1, 6)
GO
SET IDENTITY_INSERT [dbo].[ordendecompra] ON 

INSERT [dbo].[ordendecompra] ([id], [fecha], [id_proveedor], [location]) VALUES (1, N'Jun 16 2024  3:49PM', 2, N'20240616_154906NotaDePedido.pdf')
SET IDENTITY_INSERT [dbo].[ordendecompra] OFF
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (5, 4, 564456, N'Cinta Vini Tape', 456, CAST(365.00 AS Decimal(18, 2)), CAST(N'1999-09-01T00:00:00.000' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (6, 4, 456456456, N'GatoMacho333', 100, CAST(125.00 AS Decimal(18, 2)), CAST(N'1999-09-01T00:00:00.000' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (7, 2, 9, N'Codo Pvc', 4, CAST(103.00 AS Decimal(18, 2)), CAST(N'1999-09-01T00:00:00.000' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (9, 1, 1234, N'Toma 20A', 123, CAST(10.00 AS Decimal(18, 2)), CAST(N'1999-09-01T00:00:00.000' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (10, 4, 456456456, N'GatoMacho333', 100, CAST(125.00 AS Decimal(18, 2)), CAST(N'1999-09-01T00:00:00.000' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (11, 1, 13456987, N'Tulipa Vidrio', 100, CAST(100.00 AS Decimal(18, 2)), CAST(N'2024-05-22T22:13:47.317' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (12, 2, 1111, N'colres', 100, CAST(12.00 AS Decimal(18, 2)), CAST(N'2024-05-26T14:39:21.283' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (13, 2, 222, N'ttt', 100, CAST(455.00 AS Decimal(18, 2)), CAST(N'2024-05-26T14:40:20.650' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (14, 3, 11, N'rtrgrg', 100, CAST(1222.00 AS Decimal(18, 2)), CAST(N'2024-05-26T14:42:30.290' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (16, 1, 111, N'rrr', 100, CAST(235.00 AS Decimal(18, 2)), CAST(N'2024-05-26T16:00:02.017' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (17, 2, 4455, N'ttyyy', 100, CAST(78.00 AS Decimal(18, 2)), CAST(N'2024-05-26T16:07:19.360' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (18, 2, 1111, N'rrttt', 100, CAST(12.00 AS Decimal(18, 2)), CAST(N'2024-05-26T16:20:39.803' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (19, 4, 12222, N'ladrillo', 100, CAST(5000.00 AS Decimal(18, 2)), CAST(N'2024-06-01T14:07:15.393' AS DateTime))
INSERT [dbo].[producto] ([id], [categoria], [barcode], [detalle], [stock], [precio], [fecha_alta]) VALUES (20, 2, 0, N'prueba', 100, CAST(1.00 AS Decimal(18, 2)), CAST(N'2024-06-03T20:14:18.670' AS DateTime))
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
SET IDENTITY_INSERT [dbo].[proveedor] ON 

INSERT [dbo].[proveedor] ([id], [razon_social], [cuit], [direccion], [idLocalidad], [tel], [correo]) VALUES (2, N'Test2', 12123123, N'asdasd', 2, 123123, N'asdsad')
SET IDENTITY_INSERT [dbo].[proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[proveedorpago] ON 

INSERT [dbo].[proveedorpago] ([id], [id_proveedor], [fecha], [numero_factura], [monto]) VALUES (1, 2, N'Jun 17 2024  4:12PM', N'0001-0000012', 100)
SET IDENTITY_INSERT [dbo].[proveedorpago] OFF
GO
INSERT [dbo].[provincia] ([id], [provincia]) VALUES (1, N'Santa Fe')
GO
SET IDENTITY_INSERT [dbo].[reclamoproveedor] ON 

INSERT [dbo].[reclamoproveedor] ([id], [fecha], [id_proveedor], [location]) VALUES (1, N'Jun 16 2024  7:01PM', 2, N'20240616_190112ReclamoProveedor.pdf')
SET IDENTITY_INSERT [dbo].[reclamoproveedor] OFF
GO
INSERT [dbo].[tipo_documento] ([id], [descripcion]) VALUES (1, N'DNI')
INSERT [dbo].[tipo_documento] ([id], [descripcion]) VALUES (2, N'LC')
GO
INSERT [dbo].[tipo_factura] ([id], [descripcion]) VALUES (1, N'A')
INSERT [dbo].[tipo_factura] ([id], [descripcion]) VALUES (2, N'B')
INSERT [dbo].[tipo_factura] ([id], [descripcion]) VALUES (3, N'C')
INSERT [dbo].[tipo_factura] ([id], [descripcion]) VALUES (4, N'Presupuesto')
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([id], [usuario], [pass], [nombre], [apellido], [dni], [idDepartamento]) VALUES (1, N'parrax', N'gamex', N'Facundo', N'Paron', 41637946, 1)
INSERT [dbo].[usuarios] ([id], [usuario], [pass], [nombre], [apellido], [dni], [idDepartamento]) VALUES (2, N'demo', N'demo', N'demo', N'demo', 41637946, 1)
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
ALTER TABLE [dbo].[motivoBajaStock] ADD  CONSTRAINT [DEFAULT_motivoBajaStock_operador]  DEFAULT ((1)) FOR [operador]
GO
/****** Object:  StoredProcedure [dbo].[GetCompra]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCompra]
 
AS
BEGIN
 
SELECT
    compra.id,
    proveedor.razon_social as Razon_Social,
    compra.[fecha] as Fecha,
    compra.[factura] as Factura_N,
    compra.[id_proveedor] as ID_Proveedor,
    compra.[location] as Directorio
FROM [SurFeFinal].[dbo].[compra]
INNER JOIN [SurFeFinal].[dbo].[proveedor]
    ON compra.[id_proveedor] = proveedor.[id]
END;
GO
/****** Object:  StoredProcedure [dbo].[GetProducto]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProducto]
	@filtro VARCHAR(50) = NULL
AS
BEGIN
	SELECT 
      p.barcode,
	  p.detalle,
      p.stock
      ,p.precio
      
 
 FROM producto p
  WHERE 
    CONVERT(NVARCHAR, detalle) LIKE '%' + @filtro + '%';
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductos]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductos]
  -- Parámetros
  @filtro VARCHAR(50) = NULL,
  @categoriaID INT = NULL
AS
BEGIN
  -- Cuerpo del procedimiento
  SET NOCOUNT ON;

  SELECT p.id,
         p.barcode AS Barcode,
         p.detalle AS Detalle,
         
         p.precio AS Precio,
         c.categoria AS Categoria,
         p.fecha_alta as FechaAlta,
         p.categoria AS ID_Categoria
  FROM dbo.producto AS p
  JOIN dbo.categoria_productos AS c ON p.categoria = c.id

  WHERE (@filtro IS NULL OR (p.barcode LIKE '%' + @filtro + '%' OR p.detalle LIKE '%' + @filtro + '%'))
        AND (@categoriaID IS NULL OR p.categoria = @categoriaID);
END
GO
/****** Object:  StoredProcedure [dbo].[GetProveedor]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProveedor]
  @filtro NVARCHAR(255)
AS
BEGIN
  SELECT

    [razon_social],
    [cuit],
    [direccion],
    
    [tel],
    [correo],
    [idLocalidad],
    [id]
  FROM [SurFeFinal].[dbo].[proveedor]
  WHERE [razon_social] LIKE '%' + @filtro + '%'
ORDER BY [razon_social];
END;
GO
/****** Object:  StoredProcedure [dbo].[GetProveedorPagos]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProveedorPagos]
 
AS
BEGIN
 
SELECT
    proveedor.razon_social as Razon_Social,
    proveedorpago.[fecha] as Fecha,
    proveedorpago.[numero_factura] as NumeroFactura,
    proveedorpago.[monto] as Monto,
    proveedorpago.[id_proveedor] as ID_Proveedor
FROM [SurFeFinal].[dbo].[proveedorpago]
INNER JOIN [SurFeFinal].[dbo].[proveedor]
    ON proveedorpago.[id_proveedor] = proveedor.[id]
END;
GO
/****** Object:  StoredProcedure [dbo].[GetSurfe]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetSurfe]
--parametros
@filtro varchar(50) = null
AS
BEGIN
--cuerpo del procedimiento
SET NOCOUNT ON;
select c.id_cliente, c.razon_social, c.tipo_factura, c.cuit, c.domicilio, c.localidad, c.provincia, c.cp
, c.telefono, iva.descripcion CondicionIVA, c.anulado
from cliente c, condicionIVA iva
where c.idCondicionIVA =iva.idCondicionIVA and  ( Convert(nvarchar,c.id_cliente) like '%'+@filtro+'%'  or
(upper(razon_social ) like '%'+ upper(@filtro ) + '%' and anulado = 0))
END
GO
/****** Object:  StoredProcedure [dbo].[GetSurFeFinal]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Otros procedimientos, declaraciones, etc.

-- Nuevo procedimiento almacenado
CREATE PROCEDURE [dbo].[GetSurFeFinal]
    -- Parámetros
    @filtro VARCHAR(50) = NULL
AS
BEGIN
    -- Cuerpo del procedimiento
    SET NOCOUNT ON;

    SELECT 
    c.id_cliente, 
    c.razon_social, 
    c.tipo_factura, 
    c.cuit, 
    c.domicilio, 
    c.localidad, 
    c.provincia, 
    c.cp,
    c.telefono, 
    iva.descripcion AS CondicionIVA,
    c.idCondicionIVA,
    c.anulado,
    loc.localidad AS localidad_loc,
    prov.provincia AS provincia_prov,
    tf.descripcion AS tipofactura,
	td.descripcion as documento,
	c.tipo_documento,
	c.dni,
	c.email,
	c.barrio

FROM 
    cliente c
INNER JOIN 
    condicionIVA iva ON c.idCondicionIVA = iva.idCondicionIVA
LEFT JOIN 
    localidad loc ON c.localidad = loc.id
LEFT JOIN 
    provincia prov ON c.provincia = prov.id
LEFT JOIN 
    tipo_factura tf ON c.tipo_factura = tf.id
	LEFT JOIN 
	tipo_documento td on c.tipo_documento = td.id
WHERE 
    (CONVERT(NVARCHAR, c.id_cliente) LIKE '%' + @filtro + '%' AND c.anulado = 0) OR
    (UPPER(razon_social) LIKE '%' + UPPER(@filtro) + '%' AND c.anulado = 0);
END
GO
/****** Object:  StoredProcedure [dbo].[GetSurfeNuevo]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Otros procedimientos, declaraciones, etc.

-- Nuevo procedimiento almacenado
CREATE PROCEDURE [dbo].[GetSurfeNuevo]
    -- Parámetros
    @filtro VARCHAR(50) = NULL
AS
BEGIN
    -- Cuerpo del procedimiento
    SET NOCOUNT ON;

    SELECT 
        c.id_cliente, 
        c.razon_social, 
        c.tipo_factura, 
        c.cuit, 
        c.domicilio, 
        c.localidad, 
        c.provincia, 
        c.cp,
        c.telefono, 
        iva.descripcion AS CondicionIVA,
		c.idCondicionIVA,
		c.anulado
    FROM 
        cliente c
    INNER JOIN 
        condicionIVA iva ON c.idCondicionIVA = iva.idCondicionIVA
    WHERE 
        (CONVERT(NVARCHAR, c.id_cliente) LIKE '%' + @filtro + '%' AND c.anulado = 0) OR
        (UPPER(razon_social) LIKE '%' + UPPER(@filtro) + '%' AND c.anulado = 0);
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarDetalleFactura]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarDetalleFactura]
    @id_factura INT,
    @id_producto INT,
    @cantidad INT
AS
BEGIN
    -- Insertar datos en la tabla de detalle_factura
    INSERT INTO detalle_factura (id_factura, id_producto, cantidad)
    VALUES (@id_factura, @id_producto, @cantidad);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertFactura]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertFactura]
    @id_cliente varchar(50),
    @tipo_documento varchar(50),
    @fecha varchar(50),
    @total DECIMAL(18, 2)
AS
BEGIN
    

   

    -- Insertar factura
    INSERT INTO factura ([id_cliente], [tipo_documento], [fecha],[total])
    VALUES (@id_cliente, @tipo_documento, @fecha, @total);

    -- Obtener el ID generado de la factura
    select  SCOPE_IDENTITY()

    
END
GO
/****** Object:  StoredProcedure [dbo].[InsertSurfe]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertSurfe]
 @razon_social varchar(50),
 @idCondicionIVA int,
 @tipo_factura varchar(50),
@cuit varchar(50),
@domicilio varchar(50),
@localidad int,
@provincia varchar(50),
@cp varchar(50),
@telefono varchar(50),
@anulado bit,
@tipo_documento int,
@dni varchar(50),
@barrio varchar(50),
@email varchar(50)
AS
BEGIN
INSERT INTO [dbo].[cliente]
           ([razon_social]
           ,[idCondicionIVA]
           ,[tipo_factura]
           ,[cuit]
           ,[domicilio]
           ,[localidad]
           ,[provincia]
           ,[cp]
           ,[telefono]
           ,[anulado]
		   ,[tipo_documento]
		   ,[dni]
		   ,[barrio]
		   ,[email])
     VALUES
           ( @razon_social,
 @idCondicionIVA ,
 @tipo_factura,
@cuit,
@domicilio,
@localidad,
@provincia,
@cp,
@telefono,
0,
@tipo_documento,
@dni,
@barrio,
@email)
select SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[SelectProducto]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectProducto]
    @filtro NVARCHAR(255)  -- Puedes ajustar la longitud del filtro según tus necesidades
AS
BEGIN
    SET NOCOUNT ON;

    -- Tu consulta SELECT con el filtro
    SELECT *
    FROM producto -- Reemplaza "TuTabla" con el nombre de tu tabla
    WHERE CONVERT(NVARCHAR(MAX), barcode) = @filtro;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateSurfe]    Script Date: 18/6/2024 18:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateSurfe]
 @razon_social varchar(50),
 @idCondicionIVA int,
 @tipo_factura varchar(50),
@cuit varchar(50),
@domicilio varchar(50),
@localidad int,
@provincia varchar(50),
@cp varchar(50),
@telefono varchar(50),
@anulado bit,
@tipo_documento int,
@dni varchar(50),
@barrio varchar(50),
@email varchar(50)

AS
BEGIN
update cliente set
	razon_social = @razon_social,
	idCondicionIVA = @idCondicionIVA,
	tipo_factura = @tipo_factura,
	domicilio = @domicilio,
	localidad = @localidad,
	provincia = @provincia,
	cp = @cp,
	telefono = @telefono,
	anulado = @anulado,
	tipo_documento = @tipo_documento,
	dni = @dni,
	barrio = @barrio,
	email = email
where cuit = @cuit
end
GO
