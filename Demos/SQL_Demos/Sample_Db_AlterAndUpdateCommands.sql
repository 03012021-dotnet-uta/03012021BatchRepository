--Change the totalAmount column Data type top to a 'MONEY' data type
ALTER TABLE Orders
ALTER COLUMN totalAmount MONEY;

--eleminate the column totalAmount
ALTER TABLE Orders
DROP COLUMN totalAmount;

--Add the column totalAmount back to the table Orders
ALTER TABLE Orders
ADD totalAmount MONEY;

-- manually change the totalAmount column to 99.99 for the first order.
UPDATE Orders
SET totalAmount = 99.99
WHERE OrderId = 1;

-- manually change the address of the address with ID 6
UPDATE Addresses
SET AddressLine1 = '444 Main''s St.'
WHERE Addressid = 6;
