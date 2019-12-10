CREATE DATABASE DBAbraham;
USE DBAbraham;

CREATE TABLE Alumno (
	IdAlumno bigint PRIMARY KEY IDENTITY(1,1),
	Rut nvarchar(11) NOT NULL,
	Nombres nvarchar(30) NOT NULL,
	ApPaterno nvarchar(15) NOT NULL,
	ApMaterno nvarchar(15) NOT NULL,
	FechaNacimiento Date NOT NULL,
	IdCurso bigint NOT NULL
);

CREATE TABLE Curso (
	IdCurso bigint PRIMARY KEY IDENTITY(1,1),
	Codigo nvarchar(6) NOT NULL,
);

ALTER TABLE Alumno
	ADD CONSTRAINT Curso_fk FOREIGN KEY (IdCurso)
		REFERENCES Curso (IdCurso);

--INSERT INTO
INSERT INTO Curso VALUES('1°A')
INSERT INTO Curso VALUES('1°B')
INSERT INTO Curso VALUES('1°C')

INSERT INTO Alumno VALUES('20512884-0', 'Bryan David','Montes','Gatica', '2000-06-30', 3);

SELECT * FROM Curso;