CREATE PROCEDURE [InstituteDetailsRepository_GetStudents]
	@groupId INT = NULL
AS
BEGIN
	DECLARE @students [UDT_User];

    INSERT
    INTO @students (
    [Id],
        [FirstName],
        [SecondName],
        [LastName],
        [Email],
        [Phone]
    )
    SELECT
        [Id],
        [FirstName],
        [SecondName],
        [LastName],
        [Email],
        [Phone]
    FROM [User]
    WHERE [Id] IN (
        SELECT [StudentId]
        FROM [Student_Group]
        WHERE [GroupId] = @groupId
        );
    
    SELECT * FROM @students;
END