USE alesandb;

#Crear usuario
DELIMITER $$
CREATE PROCEDURE `SP_CrearUsuario`(IN SPnombre varchar(15),IN SPapPaterno varchar(15), IN SPapMaterno varchar(15), IN SPcorreoE varchar(35),IN SPcontrasenia varchar(20), IN SPdepartamento varchar(15), IN SPidSucursal int)
BEGIN

IF((select count(*) from empleados where correoElectronico=SPcorreoE)=0) THEN
	INSERT INTO empleados(idEmpleado,nombre_s,apPaterno,apMaterno,correoElectronico,contrasenia,departamento,estadoEmpleado,idsucursal) VALUES	(0,SPnombre,SPapPaterno,SPapMaterno,SPcorreoE,SPcontrasenia,SPdepartamento,'A',SPidSucursal);
    select 'NUEVO' as 'RESULTADO', concat(nombre_s,' ',apPaterno,' ',apMaterno) as 'Nombre Completo',correoElectronico as Usuario from empleados where correoElectronico=SPcorreoE AND contrasenia = SPcontrasenia;
ELSEIF((select count(*) from empleados where correoElectronico=SPcorreoE)=1) THEN
	select 'EXISTENTE' as 'RESULTADO',  concat(nombre_s,' ',apPaterno,' ',apMaterno) as 'Nombre Completo',correoElectronico as Usuario from empleados where correoElectronico=SPcorreoE AND contrasenia = SPcontrasenia;
END IF;

END$$
DELIMITER ;

#Crear cliente/provedor
DELIMITER $$
CREATE PROCEDURE `SP_CrearClienteProvedor`(IN SPtipoCliente varchar(10),IN SPRFC varchar(15),IN SPnombre varchar(50), IN SPcalle varchar(40), IN SPnumExt varchar(10),IN SPtelefono varchar(15),IN SPcorreoCont varchar(40),IN SPnombreCont varchar(15),IN SPapPaternoCont varchar(15),IN SPapMaternoCont varchar(15),IN SPciudad int)
BEGIN

IF(SPtipocliente = 'CLIENTE') THEN
	IF((SELECT count(*) FROM clientes WHERE rfc=SPRFC)=0) THEN
		INSERT INTO `alesandb`.`clientes` (`rfc`, `nombre`, `calle`, `numExt`, `telefono`, `estadoCliente`, `contactoEmail`, `contactoNombre_s`, `contactoApPaterno`, `contactoApMaterno`, `idCiudad`) 
				VALUES (SPRFC,SPnombre , SPcalle, SPnumExt, SPtelefono, 'A',SPcorreoCont ,SPnombreCont , SPapPaternoCont, SPapMaternoCont, SPciudad);
            SELECT 'NUEVO' as MENSAJE, RFC,nombre from alesandb.clientes where rfc=SPRFC;
            
    ELSEIF((SELECT count(*) FROM clientes WHERE rfc=SPRFC)=1) THEN
			SELECT 'EXISTENTE' as MENSAJE, RFC,nombre from alesandb.clientes where rfc=SPRFC;
    END IF;
    
ELSEIF(SPtipoCliente='PROVEDOR') THEN
	IF((SELECT count(*) FROM provedores WHERE rfc=SPRFC)=0) THEN
		INSERT INTO `alesandb`.`provedores` (`rfc`, `nombre`, `calle`, `numExt`, `telefono`, `estadoProvedor`, `contactoEmail`, `contactoNombre_s`, `contactoApPaterno`, `contactoApMaterno`, `idCiudad`) 
				VALUES (SPRFC,SPnombre , SPcalle, SPnumExt, SPtelefono, 'A',SPcorreoCont ,SPnombreCont , SPapPaternoCont, SPapMaternoCont, SPciudad);
            SELECT 'NUEVO' as MENSAJE, RFC,nombre from alesandb.provedores where rfc=SPRFC;
            
    ELSEIF((SELECT count(*) FROM provedores WHERE rfc=SPRFC)=1) THEN
			SELECT 'EXISTENTE' as MENSAJE, RFC,nombre from alesandb.provedores where rfc=SPRFC;
    END IF;
END IF;

END$$
DELIMITER ;

#Cuentas cliente/provedor
DELIMITER $$
CREATE PROCEDURE `SP_CrearCuenta`(in SPRFC varchar(15))
BEGIN

DECLARE SPfecha DATETIME;
SET SPfecha = now();

IF((select count(*) from cuentas where RFC=SPRFC)=0) THEN
	INSERT INTO cuentas(RFC,saldo,estadoCuenta,ultimoPago,fechaCreacion) VALUES	(SPRFC,0.0,'A',null,SPfecha);
ELSEIF((select count(*) from cuentas where RFC=SPRFC)=1) THEN
	select * from cuentas where RFC=SPRFC;
END IF;

END$$
DELIMITER ;

#Transacciones cliente/provedor
DELIMITER $$
CREATE PROCEDURE `SP_Transaccion`(in SPRFC varchar(15),IN SPFolio varchar(30),in SPidEmpleado int,IN SPMetodoPago int,in SPidBanco int,IN SPMonto double,IN SPtipoTrans varchar(5))
BEGIN

DECLARE SPfecha DATETIME;
SET SPfecha = now();

#Creacion/validacion de cuenta
CALL `alesandb`.`SP_CrearCuenta`(SPRFC);

#Retira la cantidad a la cuenta
IF(SPtipoTrans='CARGO') THEN
	INSERT INTO transacciones(idTransaccion,RFC,folio,idEmpleado,fechaTransaccion,idMP,idBanco,monto,estadoTransaccion,tipoTransaccion) values (0,SPRFC,SPFolio,SPidEmpleado,SPfecha,SPMetodoPago,SPidBanco,SPMonto,'A',SPtipoTrans);

	IF (SELECT count(*) FROM transacciones WHERE RFC=SPRFC AND fechaTransaccion=SPfecha AND idEmpleado = SPidEmpleado AND monto=SPMonto AND tipoTransaccion=SPtipoTrans)=1 THEN
		UPDATE cuentas SET saldo=saldo-SPMonto,ultimoPago=SPfecha WHERE RFC=SPRFC;
		SELECT count(*) FROM transacciones WHERE RFC=SPRFC AND fechaTransaccion=SPfecha AND idEmpleado = SPidEmpleado AND monto=SPMonto AND tipoTransaccion=SPtipoTrans;
	ELSE 
		SELECT count(*) FROM transacciones WHERE RFC=SPRFC AND fechaTransaccion=SPfecha AND idEmpleado = SPidEmpleado AND monto=SPMonto AND tipoTransaccion=SPtipoTrans;
	END IF;
#Agrega la cantidad a la cuenta
ELSEIF(SPtipoTrans='ABONO') THEN
		INSERT INTO transacciones(idTransaccion,RFC,folio,idEmpleado,fechaTransaccion,idMP,idBanco,monto,estadoTransaccion,tipoTransaccion) values (0,SPRFC,SPFolio,SPidEmpleado,SPfecha,SPMetodoPago,SPidBanco,SPMonto,'A',SPtipoTrans);

	IF (SELECT count(*) FROM transacciones WHERE RFC=SPRFC AND fechaTransaccion=SPfecha AND idEmpleado = SPidEmpleado AND monto=SPMonto AND tipoTransaccion=SPtipoTrans)=1 THEN
		UPDATE cuentas SET saldo=saldo+SPMonto,ultimoPago=SPfecha WHERE RFC=SPRFC;
		SELECT count(*) FROM transacciones WHERE RFC=SPRFC AND fechaTransaccion=SPfecha AND idEmpleado = SPidEmpleado AND monto=SPMonto AND tipoTransaccion=SPtipoTrans;
	ELSE 
		SELECT count(*) FROM transacciones WHERE RFC=SPRFC AND fechaTransaccion=SPfecha AND idEmpleado = SPidEmpleado AND monto=SPMonto AND tipoTransaccion=SPtipoTrans;
	END IF;
END IF;

END$$
DELIMITER ;

SELECT 'CLIENTE SIN CUENTA' as MENSAJE;

#Log in usuario
DELIMITER $$
CREATE PROCEDURE `SP_LogInUsuario`(IN SPcorreoE varchar(35),IN SPcontrasenia varchar(20))
BEGIN

IF((select count(*) from empleados where correoElectronico=SPcorreoE)=0) THEN
	select 'USUARIO INEXISTENTE' as 'Mensaje',0 AS idempleado,'Error' AS nombre_s, 'Error' AS apPaterno,'Eror' AS apMaterno, SPcorreoE AS correoElectronico,'Error' AS contrasenia,'Error' AS departamento, 'E' AS estadoEmpleado,0 AS idsucursal;
ELSEIF((select count(*) from empleados where correoElectronico=SPcorreoE)=1) THEN
	IF((select count(*) from empleados where correoElectronico=SPcorreoE AND contrasenia=SPcontrasenia)=1) THEN
		select 'EXITO' as 'Mensaje',  idempleado,nombre_s,apPaterno,apMaterno,correoElectronico,contrasenia,departamento,estadoEmpleado,idsucursal from empleados where correoElectronico=SPcorreoE AND contrasenia = SPcontrasenia limit 1;
    ELSE 
		select 'CONTRASEÑA ERRONEA' as 'Mensaje',  idempleado,nombre_s,apPaterno,apMaterno,correoElectronico,'' AS contrasenia,departamento,estadoEmpleado,idsucursal from empleados where correoElectronico=SPcorreoE limit 1;
    END IF;
END IF;

END$$
DELIMITER ;

#Actualizar cliente/provedor
DELIMITER $$
CREATE PROCEDURE `SP_ActualizarClienteProvedor`(IN SPtipoCliente varchar(10),IN SPRFC varchar(15),IN SPnombre varchar(50), IN SPcalle varchar(40), IN SPnumExt varchar(10),IN SPtelefono varchar(15),IN SPcorreoCont varchar(40),IN SPnombreCont varchar(15),IN SPapPaternoCont varchar(15),IN SPapMaternoCont varchar(15),IN SPciudad int,IN SPEstado varchar(1))
BEGIN

IF(SPtipocliente = 'CLIENTE') THEN
	IF((SELECT count(*) FROM clientes WHERE rfc=SPRFC)=1) THEN
		UPDATE `alesandb`.`clientes`
		SET RFC= SPRFC,NOMBRE= SPnombre , CALLE= SPcalle,numExt= SPnumExt, telefono=SPtelefono,estadoCliente= SPEstado,contactoEmail=SPcorreoCont ,contactoNombre_s=SPnombreCont ,contactoApPaterno= SPapPaternoCont,contactoApMaterno= SPapMaternoCont,idCiudad= SPciudad
        WHERE rfc=SPRFC;
		SELECT 'CLIENTE ACTUALIZADO' as MENSAJE, RFC,NOMBRE from alesandb.clientes where rfc=SPRFC;
            
    ELSE
			SELECT 'CLIENTE INEXISTENTE' as MENSAJE, SPRFC,SPnombre;
    END IF;
    
ELSEIF(SPtipoCliente='PROVEDOR') THEN
	IF((SELECT count(*) FROM provedores WHERE rfc=SPRFC)=0) THEN
		UPDATE `alesandb`.`provedores`
		SET RFC= SPRFC,NOMBRE= SPnombre , CALLE= SPcalle,numExt= SPnumExt, telefono=SPtelefono,estadoCliente= SPEstado,contactoEmail=SPcorreoCont ,contactoNombre_s=SPnombreCont ,contactoApPaterno= SPapPaternoCont,contactoApMaterno= SPapMaternoCont,idCiudad= SPciudad
        WHERE rfc=SPRFC;
		SELECT 'PROVEDOR ACTUALIZADO' as MENSAJE, RFC,NOMBRE from alesandb.clientes where rfc=SPRFC;
            
    ELSE
			SELECT 'PROVEDOR INEXISTENTE' as MENSAJE, SPRFC,SPnombre;
    END IF;
END IF;

END$$
DELIMITER ;
