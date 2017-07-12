--a.
SELECT * FROM Empleados;

--b
SELECT * FROM Empleados e WHERE e.fechaNacimiento = '1977/09/19';

--c
SELECT * FROM Empleados e WHERE e.sueldo > 11000;

--d
SELECT SUM(sueldo) as sueldoTotal FROM Empleados

--e
SELECT MAX(sueldo) as sueldoMaximo FROM Empleados

--f
SELECT nombre, dirección, teléfono
FROM Empleados
WHERE sueldo = ( SELECT MIN(sueldo)
				 FROM Empleados )

--g
SELECT nombre, fechaNacimiento
FROM Empleados
WHERE nombre LIKE 'Ro%'

--h
INSERT INTO Empleados 
VALUES ('Julio Pérez', 'Calle falsa 123', '011334567', '1988/04/12', 8900, 2),
	   ('Dante Gómez', 'Siempre viva 345', '02225267765', '1986/03/18', null,3)			

--i
UPDATE Empleados
SET sueldo = 20000
WHERE fechaNacimiento BETWEEN '1980-09-01' AND '1990-09-01'

--j
DELETE FROM Empleados
WHERE nombre LIKE 'Lucia%'

--k
DELETE FROM Empleados
WHERE localidad = ( SELECT codigoLocalidad
				    FROM Localidades
					WHERE localidad = 'Presidente Perón' )

--l
DELETE FROM Empleados
WHERE sueldo = ( SELECT MIN(sueldo)
				 FROM Empleados )
