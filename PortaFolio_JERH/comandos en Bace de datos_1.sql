create database Mini_Proyecto
go

use Mini_Proyecto
go

create table DatosPersonales (
	Id_DatosPersonales INT Primary key  not null,
	Nombres varchar(40) not null,
	ApePa varchar(40) not null,
	ApeMa varchar(40),	
	Numero_cel varchar(16) null,
	Correo1 varchar(30)null,
	Correo2 varchar(30) not null,
	Id_Tecnologia int null
);

Create table Tecnologias(
	Id_tecnologia INT Primary key identity(0,1) not null,
	Lenguaje varchar (40) not null,
	Nivel INT not null,
	Id_DatosPersonales int,
	constraint fk_DatosPersonales_Tecnologias foreign key (Id_DatosPersonales)
	references DatosPersonales(Id_DatosPersonales)
	
); 

create table Direccion(
	ID_Direccion INT Primary key identity (1,1)  not null,
	Calle varchar(40) not null,
	NumeroDeCasa int  not null,
	Coloniea varchar(40) not null,
	CalleTrasera varchar(40) not null,
	Ciudad varchar(40) not null,
	Estado varchar(40) not null,
	Id_DatosPersonales int
	constraint fk_DatosPersonales_Direccion foreign key (Id_DatosPersonales)
	references DatosPersonales(Id_DatosPersonales)
	
);

