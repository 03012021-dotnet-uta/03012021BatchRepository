--SELECT * from Addresses;
--SELECT * from Customers;
--SELECT * from Orders;

INSERT INTO Addresses 
(addressLine1, city, countryCode)
VALUES ('432 Millbrook Ln.', 'Crowley', 'CY');

--CROSS JOIN
SELECT Addresses.Addressid, AddressLine1, FirstName, LastName
FROM Addresses CROSS JOIN Customers;
