CREATE PROCEDURE [UserRepository_GetUserById]
	@userId INT
AS
BEGIN
	DECLARE @user [UDT_User];

    INSERT
    INTO @user (
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
    WHERE [Id] = @userId;
    
    SELECT * FROM @user;
END