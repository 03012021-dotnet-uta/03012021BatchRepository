--Get all customers with addresses (RIGHT JOIN)
SELECT firstName, lastName, Addresses.city
FROM Customers
RIGHT JOIN Addresses 
ON addressID = Addresses.id
WHERE Addresses.city = 'city3'
ORDER BY lastName;

--Get all customers with addresses (LEFT JOIN)
SELECT firstName, lastName, Addresses.city
FROM Customers
LEFT JOIN Addresses 
ON addressID = Addresses.id
WHERE Addresses.city = 'city3'
ORDER BY lastName;

--Get all customers with addresses (INNER JOIN)
SELECT firstName, lastName, Addresses.city
FROM Customers
INNER JOIN Addresses 
ON addressID = Addresses.id
WHERE Addresses.city = 'city3'
ORDER BY lastName;