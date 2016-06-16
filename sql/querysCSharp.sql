#Querys Clientes
SELECT *
FROM alesandb.clientes;

SELECT *
FROM alesandb.clientes
WHERE RFC = '';

SELECT *
FROM alesandb.clientes
WHERE nombre = '';

#Querys Provedores
SELECT *
FROM alesandb.provedores;

SELECT *
FROM alesandb.provedores
WHERE RFC = '';

SELECT *
FROM alesandb.provedores
WHERE nombre = '';

#Querys Todos
SELECT *,'PROVEDOR' AS Tipo
FROM alesandb.provedores
UNION
SELECT * ,'CLIENTE' AS Tipo
FROM alesandb.clientes;

SELECT *,'PROVEDOR' AS Tipo
FROM alesandb.provedores
WHERE RFC = ''
UNION
SELECT *,'CLIENTE' AS Tipo
FROM alesandb.clientes
WHERE RFC = '';

SELECT *,'PROVEDOR' AS Tipo
FROM alesandb.provedores
WHERE nombre = ''
UNION
SELECT *,'CLIENTE' AS Tipo
FROM alesandb.clientes
WHERE nombre = '';



