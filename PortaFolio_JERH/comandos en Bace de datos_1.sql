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
	Sobremi varchar(600),
	Intereses varchar(600),
	Perfil varchar(600)
);

Create table Tecnologias(
	Id_tecnologia INT Primary key identity(0,1) not null,
	Lenguaje varchar (40) unique not null,
	Nivel INT not null,
	Id_DatosPersonales int,
	constraint fk_DatosPersonales_Tecnologias foreign key (Id_DatosPersonales)
	references DatosPersonales(Id_DatosPersonales)
	
); 

create table Direccion(
	ID_Direccion INT Primary key identity (1,1)  not null,
	Calle varchar(40) not null,--
	NumeroDeCasa int  not null,--
	Coloniea varchar(40) not null,--
	CalleTrasera varchar(40) not null,--
	Ciudad varchar(40) not null,--
	Estado varchar(40) not null,--
	Id_DatosPersonales int,
	constraint fk_DatosPersonales_Direccion foreign key (Id_DatosPersonales)
	references DatosPersonales(Id_DatosPersonales)
);


create procedure SP_listar_datos 
as
begin
select * from DatosPersonales
end


INSERT INTO DatosPersonales 
VALUES (1, 'Jesus Eloy', 'Rodriguez','Hernandez','622-144-3188','jesus.tel@hotmail.com','jeelrohe@gmail.com',
'Soy una persona muy responsable, cuando se compromete con algo no lo suelta hasta ver terminado con su meta , controlo bien el estrés y se trabajar medianamente bajo presión  ',
'Normalmente cuando estoy descansando sin hacer investigaciones paso la tarde jugando videojuegos, haciendo aseo en mi casa o experimentando con conocimientos ya adquiridos normalmente esto es con hardware. ',
'Soy un estudiante apasionado y comprometido que busca crecer tanto académica como personalmente. Mi objetivo es destacar en Tecnologías de la Información, área Desarrollo de Software Multiplataforma y contribuir de manera significativa en este campo. Poseo habilidades de comunicación,de programación intermedia, estoy en constante investigación para ampliar mis conocimientos y estoy dispuesto a enfrentar desafíos y aprender constantemente.');
	

INSERT INTO Tecnologias 
VALUES ('C#', '70',1);

--update Tecnologias set Nivel='70' where Id_tecnologia=6
	
INSERT INTO Tecnologias 
VALUES ('Java', '30',1);
	
INSERT INTO Tecnologias 
VALUES ('HTML', '70',1);

INSERT INTO Tecnologias 
VALUES ('XML', '60',1);

INSERT INTO Tecnologias 
VALUES ('XAMARIN', '40',1);

INSERT INTO Tecnologias 
VALUES ('SQL SERVER ', '40',1);

INSERT INTO Tecnologias 
VALUES ('JavaScript', '40',1);
	

INSERT INTO Tecnologias 
VALUES ('CSS', '40',1);
	

	INSERT INTO Direccion 
VALUES ('Treviso', '4328','Urbi Villa del Real','Bretanga','Cd.Obregon','Sonora',1);
	

	
	
	


create view View_datosPe
as
select 
	DaPe.Nombres,
	DaPe.ApePa,
	DaPe.ApeMa,	
	DaPe.Numero_cel,
	DaPe.Correo1,
	DaPe.Correo2,
	DaPe.Sobremi,
	DaPe.Intereses,
	DaPe.Perfil,
	Tec.Id_tecnologia,
	Tec.Lenguaje,
	Tec.Nivel,
	Dic.Calle,
	Dic.NumeroDeCasa,
	Dic.Coloniea,
	Dic.CalleTrasera,
	Dic.Ciudad,
	Dic.Estado 	
from  DatosPersonales as DaPe
inner join Tecnologias as Tec
on DaPe.Id_DatosPersonales=Tec.Id_DatosPersonales 
inner join Direccion as Dic
on Tec.Id_DatosPersonales=Dic.Id_DatosPersonales




create procedure SP_listar_CMTodo 
as
begin
select *from View_datosPe
end

select * from Tecnologias