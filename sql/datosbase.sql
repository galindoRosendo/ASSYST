INSERT INTO `alesandb`.`empresa` 
(`idempresa`, `nombre`, `rfc`, `telefono`, `calle`, `numExt`) 
VALUES 
('1', 'A. A. Alejandro Sanchez e Hijos', 'AA12345678912', '8677151014', 'Maclovio Herrera', '2524');

INSERT INTO `alesandb`.`sucursales`
(`idsucursal`,`ciudad`,`calle`,`numExt`,`telefono`,`estado`,`idempresa`)
VALUES
(1,'Nuevo Laredo','Maclovio Herrera','3212','8674578126','A',1);

INSERT INTO `alesandb`.`empleados`
(`idempleado`,`nombre_s`,`apPaterno`,`apMaterno`,`correoElectronico`,`contrasenia`,`estado`,`idsucursal`)
VALUES
(0,'Rosendo','Galindo','Lopez','rosendo_galindo@hotmail.com','alesan','A',1);

INSERT INTO `alesandb`.`clientes`
(`rfc`,`nombre`,`calle`,`numExt`,`telefono`,`estado`,`contactoEmail`,`contactoNombre_s`,`contactoApPaterno`,`contactoApMaterno`)
VALUES
('MNBVCXZ','CLIENTE2','PERU','2122','8675421647','A','CLIENTE1@GMAIL.COM','DIANA','MARTINEZ','DIAZ');


INSERT INTO `alesandb`.`provedores`
(`rfc`,`nombre`,`calle`,`numExt`,`telefono`,`estado`,`contactoEmail`,`contactoNombre_s`,`contactoApPaterno`,`contactoApMaterno`)
VALUES
('KJHGFDS1','PROVEDOR2','PERU','2122','8675421647','A','PROVEDOR1@GMAIL.COM','PATRICIA','OLAY','DIAZ');

INSERT INTO `alesandb`.`cuentas`
(`idCP`,`saldo`,`estado`)
VALUES
('QWERASDF12',0.00,'A');

INSERT INTO `alesandb`.`cuentas`
(`idCP`,`saldo`,`estado`)
VALUES
('ASDFQQWE1',0.00,'A');

INSERT INTO `alesandb`.`cuentas`
(`idCP`,`saldo`,`estado`)
VALUES
('MNBVCXZ',0.00,'A');

INSERT INTO `alesandb`.`cuentas`
(`idCP`,`saldo`,`estado`)
VALUES
('KJHGFDS1',0.00,'A');

CALL `alesandb`.`cargo_cliente`('QWERASDF12','Folio1', 0, 'EFECTIVO' , '', 7000.00);
CALL `alesandb`.`cargo_provedor`('MNBVCXZ','Folio1', 0, 'EFECTIVO' , '', 500.00);
CALL `alesandb`.`pagos_cliente`('ASDFQQWE1','Folio1', 0, 'EFECTIVO' , '', 2500.00);
CALL `alesandb`.`pagos_provedor`('QWERASDF12','Folio1', 0, 'EFECTIVO' , '', 3500.00);

SELECT * FROM CUENTAS;
SELECT * FROM PAGOS;
SELECT * FROM CARGOS;


SELECT SUM(MONTO)
FROM PAGOS 
WHERE idCP='QWERASDF12';

SELECT SUM(MONTO)
FROM CARGOS 
WHERE idCP='QWERASDF12';

SELECT CL.NOMBRE AS NOMBRE, CL.RFC AS RFC, COUNT(P.idPagos) AS NUMERO_PAGOS,SUM(C.MONTO),SUM(P.MONTO), (SUM(C.MONTO)-SUM(P.MONTO)) AS SALDO 
FROM CARGOS C 
JOIN PAGOS P ON(C.idCP = P.idCP)
JOIN CLIENTES CL ON (P.IDCP = CL.RFC)
WHERE CL.RFC='QWERASDF12';

SELECT *
FROM CARGOS C 
JOIN PAGOS P ON(C.idCP = P.idCP)
JOIN CLIENTES CL ON (P.IDCP = CL.RFC);

