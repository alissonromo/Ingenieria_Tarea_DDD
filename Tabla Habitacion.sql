USE [master]
GO

CREATE DATABASE [Inmobiliaria];
USE [Inmobiliaria];

CREATE TABLE Habitacion
(
	HabitacionID int IDENTITY(1,1) not null,
	Numero int not null,
	Descripcion varchar(300) not null,
	NumeroHabitacion int not null
)