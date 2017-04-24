CREATE PROCEDURE [dbo].[getEmployeeNameById]
	@EmployeeId int
AS
    SET NOCOUNT ON;
	SELECT EmployeeName, Password, Role
	FROM [dbo].[Users]
	WHERE EmployeeId = @EmployeeId
RETURN 
