CREATE PROCEDURE [dbo].[sp_UpdateUser]
    -- Add the parameters for the stored procedure here
    @UserId int,
    @Username varchar(50),
	@Password varchar(50),
	@Role varchar(50)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    Update [andrei-greg.InventoryDB].[dbo].[Users] 
    set Username = @Username, Password = @Password, Role = @Role
    where UserId = @UserId;

END