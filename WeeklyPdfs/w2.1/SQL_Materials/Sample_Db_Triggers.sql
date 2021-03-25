--Create a table to log all the changes made
CREATE TABLE Customer_audits
(
ChangeId INT IDENTITY PRIMARY KEY,--record a unique id of the change
CustomerId INT NOT NULL,
FirstName VARCHAR(255),
LastName VARCHAR(255),
AddressID INT,
LastOrderDate DATE,
Remarks VARCHAR(255),
UpdatedAt DATETIME NOT NULL,--record when the operation happened
Operation CHAR(3) NOT NULL,--Record what type of operation it is.
CHECK(operation = 'INS' or operation='DEL')
);

--Select * FROM Customers;

--Create a Trigger
CREATE TRIGGER WhenCustomerAdded
ON Customers
AFTER INSERT, DELETE
AS 
BEGIN
-- to suppress the number of rows affected 
-- messages from being returned (@@ROWCOUNT)
	SET NOCOUNT ON;
	INSERT INTO Customer_audits
	(
		CustomerId,FirstName,LastName,AddressID,
		LastOrderDate,Remarks,UpdatedAt,Operation
	)
	SELECT
		CustomerId,FirstName,LastName,AddressID,
		LastOrderDate,Remarks,GETDATE(),'INS'
	FROM
		inserted
	UNION ALL
	SELECT
		CustomerId,FirstName,LastName,AddressID,
		LastOrderDate,Remarks,GETDATE(),'DEL'
	FROM
		deleted
END

--test the trigger to verify that it works.
INSERT INTO Customers (FirstName, LastName, AddressID, LastOrderDate, Remarks) 
VALUES ('Test', 'Testerson', 6, '0999-12-31', 'Testing for the first millennium');
		
SELECT * FROM Customer_audits;
