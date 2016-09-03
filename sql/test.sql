SELECT 
    *

FROM
    transacciones T 
    
JOIN empleados E on (E.idEmpleado=T.idempleado);
    


SELECT cl.nombre,cl.RFC,cl.estadoCliente,c.saldo,c.ultimoPago,c.fechaCreacion #cl.nombre,C.RFC
FROM cuentas c
JOIN clientes cl on (c.rfc=cl.rfc)
UNION
SELECT p.nombre,p.RFC,p.estadoProvedor,c.saldo,c.ultimoPago,c.fechaCreacion #cl.nombre,C.RFC
FROM cuentas c
JOIN provedores p on (c.rfc=p.rfc);


select *
from empleados e 
join sucursales s on(e.idSucursal=s.idSucursal);