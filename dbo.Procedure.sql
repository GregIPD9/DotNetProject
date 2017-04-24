CREATE PROCEDURE [dbo].[InsertNewEmployee]
	@EmployeeName nvarchar(50),
	@Password nvarchar(50),
	@Role nvarchar(50),
	@EmployeeId int output
AS
BEGIN
	INSERT [dbo].[Users](EmployeeName,Password,Role) Values(@EmployeeName,@Password,@Role)

	set @EmployeeId=SCOPE_IDENTITY()
END

