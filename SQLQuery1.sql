CREATE DATABASE DbJugadores
GO

USE DbJugadores
GO

CREATE TABLE Posiciones(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL,
	Activo BIT NOT NULL DEFAULT 1)
GO

CREATE TABLE Jugadores(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL,
	Equipo VARCHAR(100) NOT NULL,
	NumeroCamisa INT NOT NULL,
	PosicionId INT NOT NULL,
	Activo BIT NOT NULL DEFAULT 1

	FOREIGN KEY (PosicionId) REFERENCES Posiciones(Id))
GO

INSERT INTO Posiciones (Nombre)
VALUES
('Portero'), ('Defensor'), ('Mediocampista'), ('Delantero')
GO

INSERT INTO Jugadores
(	
	Nombre,
	Equipo,
	NumeroCamisa,
	PosicionId
)
VALUES
('Pedro Gonzalez','FC Barcelona',8,3),
('Lamine Yamal', 'FC Barcelona', 10,4),
('Lionel Messi','Inter Miami',10,4)
GO

SELECT * FROM Posiciones
GO

SELECT * FROM Jugadores
GO

DROP TABLE IF EXISTS Posiciones
DROP TABLE IF EXISTS Jugadores

