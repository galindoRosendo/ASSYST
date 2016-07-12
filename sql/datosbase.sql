#Datos base 
INSERT INTO `alesandb`.`paises` (`idPais`, `nombrePais`, `abrevPais`) VALUES ('1', 'México', 'MEX');
INSERT INTO `alesandb`.`paises` (`idPais`, `nombrePais`, `abrevPais`) VALUES ('2', 'Estados Unidos', 'USA');

INSERT INTO `alesandb`.`estados` (`idEstado`, `idPais`, `nombreEstado`, `abrevEstado`) VALUES ('1', '1', 'Tamaulipas', 'Tamps');
INSERT INTO `alesandb`.`estados` (`idEstado`, `idPais`, `nombreEstado`, `abrevEstado`) VALUES ('2', '2', 'Texas', 'TX');

INSERT INTO `alesandb`.`ciudades` (`idCiudad`, `idEstado`, `nombreCiudad`, `abrevCiudad`) VALUES ('1', '1', 'Nuevo Laredo', 'Nvo Ldo');
INSERT INTO `alesandb`.`ciudades` (`idCiudad`, `idEstado`, `nombreCiudad`, `abrevCiudad`) VALUES ('2', '2', 'Laredo', 'Ldo');

INSERT INTO `alesandb`.`metodospago` (`idMP`, `descripcion`) VALUES ('1', 'Efectivo');
INSERT INTO `alesandb`.`metodospago` (`idMP`, `descripcion`) VALUES ('2', 'Banco');
INSERT INTO `alesandb`.`metodospago` (`idMP`, `descripcion`) VALUES ('3', 'Cheque');

INSERT INTO `alesandb`.`bancos` (`idBanco`, `nombre`, `estado`) VALUES ('1', 'BANAMEX', 'A');
INSERT INTO `alesandb`.`bancos` (`idBanco`, `nombre`, `estado`) VALUES ('2', 'HSBC', 'A');
INSERT INTO `alesandb`.`bancos` (`idBanco`, `nombre`, `estado`) VALUES ('3', 'BANORTE', 'A');
INSERT INTO `alesandb`.`bancos` (`idBanco`, `nombre`, `estado`) VALUES ('4', 'BBVA', 'A');

INSERT INTO `alesandb`.`empresa` 
(`idempresa`, `nombre`, `rfc`, `telefono`, `calle`, `numExt`,`idCiudad`) 
VALUES 
('1', 'A. A. Alejandro Sanchez e Hijos', 'AA12345678912', '8677151014', 'Maclovio Herrera', '2524',1);

INSERT INTO `alesandb`.`sucursales` (`idsucursal`, `calle`, `numExt`, `telefono`, `estado`, `idempresa`, `idCiudad`) VALUES ('1', 'Maclovio Herrera', '2015', '8674578124', 'A', '1', '1');

INSERT INTO `alesandb`.`empleados`
(`idempleado`,`nombre_s`,`apPaterno`,`apMaterno`,`correoElectronico`,`contrasenia`,`departamento`,`estadoEmpleado`,`idsucursal`)
VALUES
(0,'Rosendo','Galindo','Lopez','rosendo_galindo@hotmail.com','alesan','Sistemas','A',1);

INSERT INTO `alesandb`.`clientes`
(`rfc`,`nombre`,`calle`,`numExt`,`telefono`,`estadoCliente`,`contactoEmail`,`contactoNombre_s`,`contactoApPaterno`,`contactoApMaterno`,`idCiudad`)
VALUES
('MNBVCXZ','CLIENTE2','PERU','2122','8675421647','A','CLIENTE1@GMAIL.COM','DIANA','MARTINEZ','DIAZ',1);


INSERT INTO `alesandb`.`provedores`
(`rfc`,`nombre`,`calle`,`numExt`,`telefono`,`estadoProvedor`,`contactoEmail`,`contactoNombre_s`,`contactoApPaterno`,`contactoApMaterno`,`idCiudad`)
VALUES
('KJHGFDS1','PROVEDOR2','PERU','2122','8675421647','A','PROVEDOR1@GMAIL.COM','PATRICIA','OLAY','DIAZ',1);



