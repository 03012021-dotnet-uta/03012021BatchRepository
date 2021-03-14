--- Scalar Functions
CREATE FUNCTION dbo.GetNetSale(
	@quantity INT,	
	@unitprice dec(10,2),
	@discount dec(10,2)
)
RETURNS dec(10,2)
as 
begin
	return @quantity*@unitprice*(1-@discount);
end

-- call function (dbo means DataBase Owner)
SELECT dbo.GetNetSale(10,100.00,0.1) as netSale;
