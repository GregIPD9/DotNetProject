CREATE PROCEDURE [dbo].[sp_InsertUserInfo]
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

        INSERT INTO [andrei-greg.InventoryDB].[dbo].[Users]([Role],[Password],[Username],[UserId])
        VALUES(@Role, @Password, @Username, @UserId)

    SELECT SCOPE_IDENTITY() AS UserId

END