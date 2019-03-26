create database ProyectoFinalAp2
go
use ProyectoFinalAp2
go

create table Usuarios(
UsuarioId int identity primary key,
Fecha date,
Usuario varchar(20),
NombreUsuario varchar(20),
TipoUsuario varchar(15),
Contraseña varchar(10)
);
go

insert into Usuarios(Fecha, Usuario,NombreUsuario, TipoUsuario, Contraseña) values ('2019/3/26','Joe','Joelyn De La Rosa','Administrador','123');
insert into Usuarios(Fecha, Usuario,NombreUsuario, TipoUsuario, Contraseña) values ('2019/3/26','Polo','Joelyn Payano','Empleado','1234');
go

create table Clientes(
ClienteId int identity primary key,
Fecha date,
Nombres varchar(30),
Edad varchar(100),
Sexo varchar(10),
Ciudad varchar(50),
Direccion varchar(50),
Telefono varchar(13),
Celular varchar(13),
Email varchar(55)
);

go

create table Productos(
ProductoId int identity primary key,
FechaRegistro date,
Descripcion varchar(30),
Ganancias decimal(16,2),
Costo decimal(16,2),
Precio decimal(16,2),
Inventario int
);

go

create table Facturas(
FacturaId int identity primary key,
Fecha date,
ClienteId int not null,
SubTotal decimal(16,2),
Itbis decimal(16,2),
Total decimal(16,2)
);

go

create table FacturasDetalles(
Id int identity primary key,
FacturaId int not null,
ProductoId int not null,
Descripcion varchar(50),
Cantidad int,
Precio decimal(16,2),
Importe decimal(16,2),
);