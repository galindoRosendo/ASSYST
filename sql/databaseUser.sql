#Crear usuario local
CREATE USER 'administrador'@'localhost' IDENTIFIED BY 'ALESAN2016sys';
GRANT ALL PRIVILEGES ON *.* TO 'administrador'@'localhost' WITH GRANT OPTION;
FLUSH PRIVILEGES;

#Crear usuario local y remoto
CREATE USER 'administrador'@'%' IDENTIFIED BY 'ALESAN2016sys';
GRANT ALL PRIVILEGES ON *.* TO 'administrador'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;

#Crear usuario local replica aduanet
CREATE USER 'admin'@'localhost' IDENTIFIED BY 'aduanet';
GRANT ALL PRIVILEGES ON *.* TO 'admin'@'localhost' WITH GRANT OPTION;
FLUSH PRIVILEGES;

#Crear usuario local y remoto replica aduanet
CREATE USER 'admin'@'%' IDENTIFIED BY 'aduanet';
GRANT ALL PRIVILEGES ON *.* TO 'admin'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;

#Lista de usuarios
SELECT * FROM mysql.`user` u;

#Borrar usuarios
DROP USER 'admin'@'localhost';
DROP USER 'admin'@'%';
DROP USER 'administrador'@'localhost';
DROP USER 'administrador'@'%';

