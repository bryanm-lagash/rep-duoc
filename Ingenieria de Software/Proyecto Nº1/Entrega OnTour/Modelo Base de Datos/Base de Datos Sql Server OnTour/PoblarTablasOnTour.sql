USE OnTour

--Insert de los tipos de colegio
INSERT [dbo].[tipcole] ([idtipo], [nombre]) VALUES (1, 'Municipal')
INSERT [dbo].[tipcole] ([idtipo], [nombre]) VALUES (2, 'Particular')

TRUNCATE TABLE OnTour.dbo.pais;

--Insert Pais
INSERT INTO pais VALUES (1, 'Chile');
INSERT INTO pais VALUES (2, 'Brazil');
INSERT INTO pais VALUES (3, 'Peru');
INSERT INTO pais VALUES (4, 'Argentina');
INSERT INTO pais VALUES (5, 'Estados Unidos');
INSERT INTO pais VALUES (6, 'España');
INSERT INTO pais VALUES (7, 'Argentina');
INSERT INTO pais VALUES (8, 'Mexico');

--Insert de los beneficios
INSERT [dbo].[beneficio] ([idbenefico], [nombre], [porcdescuento]) VALUES (1, 'Desc.por cantidad de personas', 15)
INSERT [dbo].[beneficio] ([idbenefico], [nombre], [porcdescuento]) VALUES (2, 'Desc.para colegio municipal', 25)
INSERT [dbo].[beneficio] ([idbenefico], [nombre], [porcdescuento]) VALUES (3, 'Desc.para colegio particular', 20)

--Insert de las actividades
INSERT [dbo].[actividad] ([idactividad], [nombre], [costo]) VALUES (1, 'Tour Nocturno', 25000)
INSERT [dbo].[actividad] ([idactividad], [nombre], [costo]) VALUES (2, 'Visita a parque tematico', 30000)
INSERT [dbo].[actividad] ([idactividad], [nombre], [costo]) VALUES (3, 'Visita a museo', 40000)

--Insert de la modalidad de los aportes
INSERT [dbo].[modaporte] ([idmod], [nombre]) VALUES (1, 'Apoderados')
INSERT [dbo].[modaporte] ([idmod], [nombre]) VALUES (2, 'Apoderados y Curso')

--Insert de los tipos de actividades
INSERT [dbo].[tipactividad] ([idtipoact], [nombre], [modaporte_idmod]) VALUES (1, 'No aplica', 1)
INSERT [dbo].[tipactividad] ([idtipoact], [nombre], [modaporte_idmod]) VALUES (2, 'Fiestas y Rifas', 2)

--Insert de los tipos de usuarios
INSERT [dbo].[tipcuenta] ([idtipocta], [nombre]) VALUES (1, 'Apoderado')
INSERT [dbo].[tipcuenta] ([idtipocta], [nombre]) VALUES (2, 'Adm. de Sistema')
INSERT [dbo].[tipcuenta] ([idtipocta], [nombre]) VALUES (3, 'Ejecutivo de Ventas')
INSERT [dbo].[tipcuenta] ([idtipocta], [nombre]) VALUES (4, 'Dueño')

--Insert de las tasa de interes por dias de atraso
INSERT [dbo].[tasa_interes] ([idinteres], [diasini], [diasterm], [porcmulta]) VALUES (1, 1, 7, 10)
INSERT [dbo].[tasa_interes] ([idinteres], [diasini], [diasterm], [porcmulta]) VALUES (2, 8, 15, 20)
INSERT [dbo].[tasa_interes] ([idinteres], [diasini], [diasterm], [porcmulta]) VALUES (3, 16, 30, 30)

INSERT INTO ciudad VALUES (1, 'Concepcion', 1);
INSERT INTO contrato VALUES (321, '12-21-12', '12-12-12', 30, '12-12-12', '12-12-12', '30 de cada mes', 123,123,123,123,123, 2, '3ºB', 1, '')
INSERT INTO usuario VALUES('1234','Bryan', 'Montes','Gatica', 'Tuscachetes', 'hola@comotai.cl')