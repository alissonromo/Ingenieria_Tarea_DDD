USE [master]
GO

CREATE DATABASE [Inmobiliaria];
USE [Inmobiliaria];

CREATE TABLE Casa
(
	CasaId int IDENTITY(1,1) not null,
	Numero int not null,
	Calle varchar(300) not null,
	NumeroHabitaciones int not null,
	NumeroBaños int not null,
	Pisos int not null,
	MetrosCuadrados decimal(18,2) not null
)

INSERT INTO [dbo].[Casa]
([Numero], [Calle], [NumeroHabitaciones], [NumeroBaños], [Pisos], [MetrosCuadrados])
VALUES
(1, 'CALLE23', 2, 1, 1, 123.2),
(2, 'CALLE11', 7, 4, 2, 123.2),
(3, 'CALLE22', 3, 2, 1, 123.2),
(4, 'CALLE00', 3, 1, 1, 123.2)