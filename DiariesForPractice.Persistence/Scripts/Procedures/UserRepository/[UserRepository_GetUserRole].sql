CREATE PROCEDURE [UserRepository_GetUserRole]
	@userId INT
AS
    BEGIN
        DECLARE @role INT = (
            SELECT 
            TOP 1 [UserId] 
            FROM [User_Role]
            WHERE [UserId] = @userId
            );
        IF(@role IS NULL)
            SET @role = 0
    
    SELECT @role;
END