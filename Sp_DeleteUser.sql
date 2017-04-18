CREATE PROCEDURE [dbo].[sp_DeleteUser]
    -- Add the parameters for the stored procedure here
    @UserId int
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    DELETE FROM [dbo].[Users]
    where UserID = @UserId

END
    