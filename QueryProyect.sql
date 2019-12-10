CREATE TABLE Empleado (
	EmpleadoId bigint PRIMARY KEY IDENTITY (1,1),
	Rut nvarchar(11) NOT NULL,
	Nombres nvarchar(25) NOT NULL,
	Apellidos nvarchar(25) NOT NULL,
	Genero nvarchar(15) NOT NULL,
	FechaNacimiento Date NOT NULL,
	Direccion nvarchar(100) NOT NULL,
	Telefono nvarchar(11) NOT NULL,
	Profesion nvarchar(25) NOT NULL,
	Email nvarchar(25) NOT NULL,
	ImagePath nvarchar(500) NOT NULL,
	CargasFamiliares [int] NOT NULL
);

CREATE TABLE Contrato(
	ContratoId bigint PRIMARY KEY IDENTITY(1,1), 
	EmpleadoId bigint NOT NULL,
	FechaCreacion DateTime NOT NULL,
	FechaInicio DateTime NOT NULL,
	FechaTermino DateTime NOT NULL,
	NumeroHoras [int] NOT NULL,
	ValorHoraId [int] NOT NULL,
	AfpId [int] NOT NULL,
	SaludId [int] NOT NULL,
	BonificacionID [int] NOT NULL,
	SueldoBase float NOT NULL,
	SueldoLiquido float NOT NULL,
	SueldoBruto float NOT NULL
);

ALTER TABLE Contrato 
	ADD CONSTRAINT Empleado_fk FOREIGN KEY ([EmpleadoId])
		REFERENCES Empleado ([EmpleadoId]);

ALTER TABLE Contrato
	ADD CONSTRAINT ValorHora_fk FOREIGN KEY (ValorHoraId)
		REFERENCES ValorHora (ValorHoraId);

ALTER TABLE Contrato
	ADD CONSTRAINT Afp_fk FOREIGN KEY (AfpId) 
		REFERENCES Afp (AfpId)

ALTER TABLE Contrato
	ADD CONSTRAINT Salud_fk FOREIGN KEY (SaludId)
		REFERENCES Salud (SaludId);

ALTER TABLE Contrato
	ADD CONSTRAINT Bonificacion_fk FOREIGN KEY (BonificacionID)
		REFERENCES Bonificacion (BonificacionId);

USE DefaultConnection;
INSERT INTO Empleado VALUES('20512884-0', 'Bryan','Montes', 'Masculino', '2000/07/30', 'Direccion', '123123123', 'Ingeniero informatico', 'asdasdasdsa', 'asd', 2);

SELECT * FROM Empleado;