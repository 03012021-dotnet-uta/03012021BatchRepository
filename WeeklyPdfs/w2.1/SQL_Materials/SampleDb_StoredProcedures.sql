
--rename table using the Built-in Stored Procedure
EXEC sp_rename 'Customers', 'Customers_1';

--Stored Procedure to get all Customers with addressId = 1
CREATE PROCEDURE GetAllCustomerNames
AS 
SELECT CustomerId, FirstName 
FROM Customers
WHERE addressID = 1;

EXEC GetAllCustomerNames;
DROP PROCEDURE GetAllCustomerNames;


--Stored Procedure with variables to get a Customer with the param names
CREATE PROCEDURE GetCustomerShe   
    @LastName nvarchar(50),   
    @FirstName nvarchar(50)   
AS     
    SELECT FirstName, LastName, Remarks  
    FROM Customers  
    WHERE FirstName = @FirstName 
	AND 
	LastName = @LastName;
   /* AND 
	Remarks LIKE '%S_e%';  */

--execute the procedure
EXEC GetCustomerShe 
	@LastName = 'Moore', 
	@FirstName = 'Maya';

--Drop the procedure
DROP PROCEDURE GetCustomerShe;