CREATE PROCEDURE [UserRepository_AddOrUpdateUserRole]
	@userRole [UDT_User_Role] READONLY
AS
BEGIN
    MERGE
    INTO [User_Role] AS [dest]
    USING @userRole AS [src]
    ON [dest].[UserId] = [src].[UserId]
    AND [dest].[Role] = [src].[Role]
    WHEN NOT MATCHED THEN
    INSERT (
        [UserId],
        [Role]
     ) VALUES (
        [src].[UserId],
        [src].[Role]
    );
END