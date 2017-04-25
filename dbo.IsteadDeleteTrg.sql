CREATE TRIGGER trgInsteadOfDelete ON [dbo].[Products] 
INSTEAD OF DELETE
AS
	declare @ProductId int;
	declare @ProductName varchar(50);
	declare @Category varchar(50);
	declare @Description varchar(200);
	declare @Price decimal;
	declare @SCU int;
	declare @Quantity int;
	declare @Location varchar(10);
	declare @SupplierName varchar(50);
	declare @Audit_Action varchar(200);
	
	select @ProductId=d.ProductId from deleted d;
	select @ProductName=d.ProductName from deleted d;
	select @Category=d.Category from deleted d;
	select @Description=d.Description from deleted d;
	select @Price=d.Price from deleted d;
	select @SCU=d.SCU from deleted d;
	select @Quantity=d.Quantity from deleted d;
	select @Location=d.Location from deleted d;
	select @SupplierName=d.SupplierName from deleted d;
	set @Audit_Action='DELETED -- Instead Of Delete Trigger.';

	BEGIN
		if(@Quantity<10)
		begin
			RAISERROR('Cannot delete where Quantity less than 10',16,1);
			ROLLBACK;
		end
		else
		begin
			delete from Products where ProductId=@ProductId;
			COMMIT;
			insert into Products_Audit(ProductId,ProductName,Category,Description,Price,SCU,Quantity,Location,SupplierName,Audit_Action,Audit_Timestamp)
			values(@ProductId,@ProductName,@Category,@Description,@Price,@SCU,@Quantity,@Location,@SupplierName,@Audit_Action,getdate());
			PRINT 'Record Deleted -- Instead Of Delete Trigger fired.'
		end
	END
