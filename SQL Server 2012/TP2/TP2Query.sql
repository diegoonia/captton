--1
SELECT *
FROM Productos
ORDER BY pNombre

--2
SELECT *
FROM Proveedores
WHERE Localidad = 'Capital'

--3
SELECT *
FROM Envios
WHERE Cantidad BETWEEN 200 AND 300

--4
SELECT SUM(Cantidad) as CantidadTotal
FROM Envios

--5
SELECT AVG(Precio) as PrecioPromedio
FROM Productos

--6
SELECT e.Numero, e.pNumero, (e.Cantidad * p.Precio) as PrecioPromedio
FROM Envios e INNER JOIN Productos p ON p.pNumero = e.pNumero

--7
SELECT SUM(Cantidad) as CantidadTotal
FROM Envios
WHERE Numero = 102

--8
SELECT e.pNumero as ProdEnviadosPorProvAvellaneda
FROM Envios e INNER JOIN Proveedores p ON p.Numero = e.Numero
WHERE p.Localidad = 'Avellaneda'

--9
SELECT domicilio, localidad
FROM Proveedores
WHERE Nombre = '%i%'

--10
INSERT INTO Productos
VALUES (4, 'Chocolate', 0.35, 'Chico')

--11
INSERT INTO Proveedores
VALUES (103, 'Diego', null, null)

--12
INSERT INTO Proveedores
VALUES (107, 'Rosales', null, 'La Plata')

--13
UPDATE Productos
SET Precio = 7.50
WHERE Tamaño = 'Grande'

--14
UPDATE Productos
SET Tamaño = 'Mediano'
FROM Productos p INNER JOIN Envios e ON p.pNumero = e.pNumero
WHERE p.Tamaño = 'Chico' AND e.Cantidad >= 300

--15
DELETE FROM Productos
WHERE pNumero = 1

--16
DELETE FROM Proveedores
WHERE Numero NOT IN ( SELECT e.Numero
					  FROM Envios e LEFT JOIN Proveedores p ON e.Numero = p.Numero)
					  

