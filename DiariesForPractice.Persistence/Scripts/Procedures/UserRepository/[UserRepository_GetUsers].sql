CREATE PROCEDURE [UserRepository_GetUsers]
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
    FROM [User];
    
    SELECT * FROM @users;
END