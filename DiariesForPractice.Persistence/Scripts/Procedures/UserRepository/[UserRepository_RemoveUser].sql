CREATE PROCEDURE [UserRepository_RemoveUser]
	@userId INT
AS
BEGIN
    DELETE
    FROM [User]
    WHERE [Id] = @userId;
END