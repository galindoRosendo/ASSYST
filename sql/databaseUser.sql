#Crear usuario local
CREATE USER 'administrador'@'localhost' IDENTIFIED BY 'ALESAN2016sys';
GRANT ALL PRIVILEGES ON *.* TO 'administrador'@'localhost';
FLUSH PRIVILEGES;

#Crear usuario local y remoto
CREATE USER 'administrador'@'%' IDENTIFIED BY 'ALESAN2016sys';
GRANT ALL PRIVILEGES ON *.* TO 'administrador'@'%';
FLUSH PRIVILEGES;

#Lista de usuarios
SELECT * FROM mysql.`user` u;

#Borrar usuarios
DROP USER 'administrador'@'localhost';

