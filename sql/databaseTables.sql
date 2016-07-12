#Creacion de la base de datos 
DROP DATABASE IF EXISTS alesandb;
CREATE DATABASE alesandb;

#Uso de la base de datos alesandb
USE alesandb;

#Paises aceptados para la base de datos
CREATE TABLE paises(
idPais int auto_increment primary key,
nombrePais varchar(30),
abrevPais varchar(5)
);

#Estados aceptadas para la base de datos
CREATE TABLE estados(
idEstado int auto_increment primary key,
idPais int,
nombreEstado varchar(30),
abrevEstado varchar(5),
foreign key(idPais) references paises(idPais)on update cascade on delete cascade
);

#Ciudades/localidades aceptadas para la base de datos
CREATE TABLE ciudades(
idCiudad int auto_increment primary key,
idEstado int,
nombreCiudad varchar(30),
abrevCiudad varchar(10),
foreign key(idEstado) references estados(idEstado)on update cascade on delete cascade
);


#Tabla con los datos generales de la empresa
CREATE TABLE empresa(
idempresa int auto_increment primary key,
nombre varchar(50),
rfc varchar(15),
telefono varchar(15),
calle varchar(40),
numExt varchar(10),
idCiudad int,
foreign key(idCiudad)references ciudades(idCiudad)on update cascade on delete cascade
);

#Tabla con la informacion de las sucursales de la empresa
CREATE TABLE sucursales(
idsucursal int auto_increment primary key,
calle varchar(40),
numExt varchar(10),
telefono varchar(15),
estado varchar(1),
idempresa int,
idCiudad int,
foreign key(idCiudad)references ciudades(idCiudad)on update cascade on delete cascade,
foreign key (idempresa) references empresa(idempresa)on update cascade on delete cascade
);

#Tabla con la informacion de los emeplados
CREATE TABLE empleados(
idempleado INT auto_increment PRIMARY KEY,
nombre_s varchar(15),
apPaterno varchar(15),
apMaterno varchar(15),
correoElectronico varchar(35),
contrasenia varchar(20),
departamento varchar(15),
estadoEmpleado varchar(1),
idsucursal int,
foreign key (idsucursal) references sucursales(idsucursal)on update cascade on delete cascade
);

#Tabla con los clientes de la empresa
CREATE TABLE clientes(
rfc varchar(15),
nombre varchar(50),
calle varchar(40),
numExt varchar(10),
telefono varchar(15),
estadoCliente varchar(1),
contactoEmail varchar(40),
contactoNombre_s varchar(15),
contactoApPaterno varchar(15),
contactoApMaterno varchar(15),
idCiudad int,
primary key (rfc),
foreign key(idCiudad)references ciudades(idCiudad)on update cascade on delete cascade

);

#Tabla con los provedores de la empresa
CREATE TABLE provedores (
rfc varchar(15),
nombre varchar(50),
calle varchar(40),
numExt varchar(10),
telefono varchar(15),
estadoProvedor varchar(1),
contactoEmail varchar(40),
contactoNombre_s varchar(15),
contactoApPaterno varchar(15),
contactoApMaterno varchar(15),
idCiudad int,
primary key (rfc),
foreign key(idCiudad) references ciudades(idCiudad)on update cascade on delete cascade
);

#Cuentas de los clientes/provedores de la empresa
CREATE TABLE cuentas(
RFC varchar(15), #RFC cliente o provedor
saldo double,
estadoCuenta varchar(1),
ultimoPago datetime,
fechaCreacion datetime,
primary key (RFC)
);

#Transacciones de las cuentas de los clientes/Provedores
CREATE TABLE transacciones(
idTransaccion int auto_increment primary key,
RFC varchar(15),
folio varchar(25),
idEmpleado int,
fechaTransaccion datetime,
idMP int,
idBanco int,
monto double,
estadoTransaccion varchar(1),
tipoTransaccion varchar(5),
foreign key(RFC) references cuentas(RFC) on update cascade,
foreign key(idEmpleado) references empleados(idEmpleado) on update cascade
);

#Metodos de pago autorizados
CREATE TABLE metodosPago(
idMP int auto_increment primary key,
descripcion varchar(30)
);

#Registro de los bancos autorizados
CREATE TABLE bancos(
idBanco int auto_increment primary key,
nombre varchar(50),
estado varchar(1)
);