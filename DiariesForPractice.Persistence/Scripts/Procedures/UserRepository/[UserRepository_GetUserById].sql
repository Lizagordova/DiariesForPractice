CREATE PROCEDURE [UserRepository_GetUserById]
	@userId INT
AS
BEGIN
	DECLARE @user [UDT_User];
	DECLARE @role INT;

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
    
    SET @role = (SELECT TOP 1 [Role] FROM [User_Role] WHERE [UserId] = @userId);
    
    SELECT * FROM @user;
    SELECT @role;
END