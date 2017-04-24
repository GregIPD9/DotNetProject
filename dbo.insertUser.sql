CREATE PROCEDURE [dbo].[insertUser]
	@EmployeeId int,
	@EmployeeName varchar(50),
	@Password varchar(50),
	@Role varchar(50)
AS
	BEGIN
	
	INSERT INTO [dbo].[Users] VALUES (@EmployeeId,@EmployeeName,@Password,@Role)
END