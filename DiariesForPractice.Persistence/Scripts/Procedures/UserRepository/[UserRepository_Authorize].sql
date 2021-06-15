CREATE PROCEDURE [UserRepository_Authorize]
	@user [UDT_User] READONLY
AS
BEGIN
	DECLARE @userId INT = (
		SELECT TOP 1 [Id]
		FROM [User]
		WHERE 
			([Login] = (SELECT TOP 1 [Login] FROM @user) OR [Email] = (SELECT TOP 1 [Email] FROM @user))
			AND [Password] = (SELECT TOP 1 [Password] FROM @user)
			);

    SELECT @userId;
END