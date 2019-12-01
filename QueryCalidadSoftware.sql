Use DefaultConnection;

CREATE TABLE Empleado (
	EmpleadoId [int] NOT NULL,
	Rut nvarchar(50) NOT NULL,
	Nombres nvarchar(50) NOT NULL,
	Apellidos nvarchar(50) NOT NULL,
	Genero nvarchar(10) NOT NULL,
	FechaNacimiento DateTime NOT NULL,
	Direccion nvarchar(50) NOT NULL,
	Telefono [int] NOT NULL,
	Profesion nvarchar(50) NOT NULL,
	Email nvarchar(80) NOT NULL,
	ImagePath nvarchar(500) NOT NULL,
	CargasFamiliares [int] NULL
);

ALTER TABLE Empleado
	ADD CONSTRAINT Empleado_pk PRIMARY KEY (EmpleadoId);

CREATE TABLE Contrato (
	ContratoId [int] NOT NULL,
	EmpleadoId [int] NOT NULL,
	FechaCreacion DateTime NOT NULL,
	FechaInicio DateTime NOT NULL,
	FechaTermino DateTime NOT NULL,
	NumeroHoras [int] NOT NULL,
	ValorHoraId [int] NOT NULL,
	AfpId [int] NOT NULL,
	SaludId [int] NOT NULL,
	BonificacionId [int] NOT NULL,
	SueldoBase float NOT NULL,
	SueldoLiquido float NOT NULL,
	SueldoBruto float NOT NULL
);

ALTER TABLE Contrato
	ADD CONSTRAINT Contrato_pk PRIMARY KEY (ContratoId);

CREATE TABLE Afp(
	AfpId [int] NOT NULL,
	Nombre nvarchar(30) NOT NULL,
	Valor float NOT NULL
);

ALTER TABLE Afp 
	ADD CONSTRAINT Afp_pk PRIMARY KEY (AfpId);

CREATE TABLE Salud( 
	SaludId [int] NOT NULL,
	Nombre nvarchar(25) NOT NULL,
	Valor float NOT NULL
);

ALTER TABLE Salud 
	ADD CONSTRAINT Salud_pk PRIMARY KEY (SaludId);

CREATE TABLE Bonificacion (
	BonificacionId [int] NOT NULL,
	Nombre nvarchar(50) NOT NULL,
	Descripcion nvarchar(50) NULL,
	Valor float NOT NULL
);

ALTER TABLE Bonificacion
	ADD CONSTRAINT Bonificacion_pk PRIMARY KEY (BonificacionId);

CREATE TABLE ValorHora(
	ValorHoraId [int] NOT NULL,
	Tipo nvarchar(50) NOT NULL,
	Valor float NOT NULL
);

ALTER TABLE ValorHora
	ADD CONSTRAINT ValorHora_pk PRIMARY KEY (ValorHoraId);

--FOREING KEY'S

ALTER TABLE Contrato
	ADD CONSTRAINT Contrato_Empleado_fk FOREIGN KEY (EmpleadoId)
		REFERENCES Empleado (EmpleadoId);

ALTER TABLE Contrato
	ADD CONSTRAINT Contrato_ValorHora_fk FOREIGN KEY (ValorHoraId)
		REFERENCES ValorHora (ValorHoraId);

ALTER TABLE Contrato
	ADD CONSTRAINT Contrato_Afp_fk FOREIGN KEY (AfpId)
		REFERENCES Afp (AfpId);

ALTER TABLE Contrato
	ADD CONSTRAINT Contrato_Salud_fk FOREIGN KEY (SaludId)
		REFERENCES Salud (SaludId);

ALTER TABLE Contrato
	ADD CONSTRAINT Contrato_Bonificacion_fk FOREIGN KEY (BonificacionId)
		REFERENCES Bonificacion (BonificacionId);


       ----------        INSERT INTO       ----------        
INSERT INTO dbo.Empleado VALUES (1, '20512884-0', 'Bryan', 'Montes', 'Masculino', 2000-06-30, 'Av. marihueno 032', 12345678, 'Ingeniero Informatico', 'bryanm@lagash.com', 'asdasd', 2)

INSERT INTO dbo.ValorHora VALUES (0,'Novato', 8500);
INSERT INTO dbo.ValorHora VALUES (1,'Experimentado', 12000);
INSERT INTO dbo.ValorHora VALUES (2,'Profesional', 17000);

INSERT INTO dbo.Bonificacion VALUES (0, 'Bonificacion principiantes', 'Bonificacion personal recien ingresado', 50000)
INSERT INTO dbo.Bonificacion VALUES (1, 'Bonificacion Mensual', null, 10000);

INSERT INTO Afp VALUES (1, 'Modelo', 0.1);
INSERT INTO Afp VALUES (2, 'Cuprum', 0.1);
INSERT INTO Afp VALUES (3, 'Provida', 0.1);
INSERT INTO Afp VALUES (4, 'Habitat', 0.1);
INSERT INTO Afp VALUES (5, 'Capital', 0.1);

INSERT INTO Salud VALUES (0, 'Isapre', 0.07);
INSERT INTO Salud VALUES (1, 'Fonasa', 0.07);