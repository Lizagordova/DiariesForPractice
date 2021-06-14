CREATE PROCEDURE [UserRepository_AddOrUpdateUser]
	@user [UDT_User] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [User] AS [dest]
        USING @user AS [src]
        ON [dest].[Id] = [src].[Id]
        OR [dest].[Email] = [src].[Email]
        WHEN NOT MATCHED THEN
        INSERT (
            [FirstName],
            [SecondName],
            [LastName],
            [Email],
            [Phone],
            [Login],
            [Password],
            [Token],
            [EmailConfirmed]
        ) VALUES (
            [src].[FirstName],
            [src].[SecondName],
            [src].[LastName],
            [src].[Email],
            [src].[Phone],
            [src].[Login],
            [src].[Password],
            [src].[Token],
            [src].[EmailConfirmed]
        )
        WHEN MATCHED THEN
    UPDATE
    SET
        [dest].[FirstName] = [src].[FirstName],
        [dest].[SecondName] = [src].[SecondName],
        [dest].[LastName] = [src].[LastName],
        [dest].[Email] = [src].[Email],
        [dest].[Phone] = [src].[Phone],
        [dest].[Login] = [src].[Login],
        [dest].[Password] = [src].[Password],
        [dest].[Token] = [src].[Token],
        [dest].[EmailConfirmed] = [src].[EmailConfirmed]
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @userId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @userId;
END