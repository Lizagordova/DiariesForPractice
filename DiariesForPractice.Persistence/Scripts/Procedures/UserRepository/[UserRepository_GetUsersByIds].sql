CREATE PROCEDURE [UserRepository_GetUsersByIds]
	@ids [UDT_Integer] READONLY
AS
BEGIN
	DECLARE @users [UDT_User];

    INSERT
    INTO @users (
    [Id],
        [FirstName],
        [SecondName],
        [LastName],
        [Email],
        [Phone],
        [EmailConfirmed]
    )
    SELECT
        [Id],
        [FirstName],
        [SecondName],
        [LastName],
        [Email],
        [Phone],
        [EmailConfirmed]
    FROM [User]
    WHERE [Id] IN (
        SELECT [Id] FROM @ids
        );
    
    SELECT * FROM @users;
END