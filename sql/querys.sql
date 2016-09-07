#Tablas Vacias
SELECT * FROM alesandb.paises;
SELECT * FROM alesandb.estados;
SELECT * FROM alesandb.ciudades;
SELECT * FROM alesandb.metodospago;
SELECT * FROM alesandb.bancos;
SELECT * FROM alesandb.empresa;
describe empresa;
SELECT * FROM alesandb.sucursales;
SELECT * FROM alesandb.empleados;
SELECT * FROM alesandb.clientes;
DESCRIBE alesandb.clientes;
SELECT * FROM alesandb.provedores;

SELECT * FROM alesandb.transacciones;
SELECT * FROM alesandb.cuentas;

#Store Procedures de la base de datos
CALL `alesandb`.`SP_CrearUsuario`('Rosendo', 'Galindo', 'Lopez', 'rosendo@alesan.mx', 'alesan', 'Sistemas',1);

CALL `alesandb`.`SP_LogInUsuario`('rosendo@alesan.mx', 'ALESAN');

CALL `alesandb`.`SP_CrearClienteProvedor`('CLIENTE', 'MNBVCXZ', 'ANARTEC CO.', 'ALDAMA', '2020','8677845129', 'PROVEDOR1@GMAIL.COM','ALEJANDRO', 'RAMIREZ', 'ELIZONDO', 1);

CALL `alesandb`.`SP_CrearCuenta`('MNBVCXZ');

CALL `alesandb`.`SP_Transaccion`('MNBVCXZ', 'Folio13', 1, 1, null, 1100.00, 'Abono');
CALL `alesandb`.`SP_Transaccion`('QWERTYUII', 'Folio5', 2, 1, null, 500.00, 'CARGO');
#CALL `alesandb`.`SP_Transaccion`(<{in SPRFC varchar(15)}>, <{IN SPFolio varchar(30)}>, <{in SPidEmpleado int}>, <{IN SPMetodoPago int}>, <{in SPidBanco int}>, <{IN SPMonto double}>, <{IN SPtipoTrans varchar(5)}>);


CALL `alesandb`.`SP_ActualizarClienteProvedor`('CLIENTE', 'QWERTYUIOPAS', 'QUINTANILLA INC.','PERU', '2020', '8677845129', 'CLIENTE1@HOTMAIL.COM', 'HILARIO', 'QUINTANILLA', 'CHAPA', 1, 'A');

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


