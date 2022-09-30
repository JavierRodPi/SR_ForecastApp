CREATE PROCEDURE dbo.GetSalesyYearAndState
    @Year int
AS   

    SET NOCOUNT ON;  
    select 
		o.State,
		sum(p.Sales) as TotalSales
	from 
		Orders o
		left join OrdersReturns oor
		on o.OrderId = oor.OrderId
		inner join Products p 
		on o.OrderId = p.OrderId
	where 
		oor.OrderId is null
		and year(o.OrderDate) = @Year
	group by o.State 
GO  