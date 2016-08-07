#Crear usuario local
CREATE USER 'administrador'@'localhost' IDENTIFIED BY 'ALESAN2016sys';
GRANT ALL PRIVILEGES ON *.* TO 'administrador'@'localhost';
FLUSH PRIVILEGES;

#Crear usuario local y remoto
CREATE USER 'administrador'@'%' IDENTIFIED BY 'ALESAN2016sys';
GRANT ALL PRIVILEGES ON *.* TO 'administrador'@'%';
FLUSH PRIVILEGES;

#Crear usuario local replica aduanet
CREATE USER 'admin'@'localhost' IDENTIFIED BY 'aduanet';
GRANT ALL PRIVILEGES ON *.* TO 'admin'@'localhost';
FLUSH PRIVILEGES;

#Crear usuario local y remoto replica aduanet
CREATE USER 'admin'@'%' IDENTIFIED BY 'aduanet';
GRANT ALL PRIVILEGES ON *.* TO 'admin'@'%';
FLUSH PRIVILEGES;

#Lista de usuarios
SELECT * FROM mysql.`user` u;

#Borrar usuarios
DROP USER 'administrador'@'localhost';

