CREATE DATABASE CASO_PRACTICO_2
gO

CREATE TABLE PRODUCTO(
	ID int identity (1,1) not null,
	Nombre varchar (50) not null,
	Descripcion varchar(200),
	Precio decimal not null,
	Stock int not null,
	Categoria varchar(20) not null

);
GO

ALTER TABLE PRODUCTO
ADD CONSTRAINT PRODUCTO_PK PRIMARY KEY (ID)
GO
