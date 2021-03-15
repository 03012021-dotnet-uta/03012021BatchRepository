<<<<<<< HEAD
--- Scalar Functions
CREATE FUNCTION dbo.GetNetSale(
	@quantity INT,	
	@unitprice dec(10,2),
	@discount dec(10,2)
)
=======
-- Scalar 
-- takes the 3 parameters and multiplies them. It returns the total price.
CREATE FUNCTION dbo.GetNetSale( @quantity INT,@unitprice dec(10,2),@discount dec(10,2) )
>>>>>>> main
RETURNS dec(10,2)
as 
begin
	return @quantity*@unitprice*(1-@discount);
end

-- call function (dbo means DataBase Owner)
SELECT dbo.GetNetSale(11,9.00,0.1) as netSale;/*should return 89.10*/

--run the procedure wiht a subquery
SELECT dbo.GetNetSale(11,(SELECT totalAmount FROM Orders WHERE totalAmount = 265.31),0.1) as netSale

SELECT * FROM Orders;
