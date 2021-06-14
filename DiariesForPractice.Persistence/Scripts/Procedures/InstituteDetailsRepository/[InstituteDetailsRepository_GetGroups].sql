CREATE PROCEDURE [InstituteDetailsRepository_GetGroups]
	@directionId INT = NULL,
	@courseId INT = NULL
AS
BEGIN
	DECLARE @groups [UDT_Group];
	DECLARE @groupDetails [UDT_GroupDetails];
	DECLARE @studentGroups [UDT_Student_Group];
	DECLARE @students [UDT_User];

    INSERT
    INTO @groups (
    [Id],
        [Name],
        [DirectionId],
        [CourseId]
    )
    SELECT
        [Id],
        [Name],
        [DirectionId],
        [CourseId]
    FROM [Group]
    WHERE (@directionId IS NULL OR [DirectionId] = @directionId)
       OR (@courseId IS NULL OR [CourseId] = @courseId);
    
    INSERT
    INTO @groupDetails (
    [Id],
        [GroupId],
        [NumberStudentsShouldBe],
        [NumberRegisteredStudents]
    )
    SELECT
        [Id],
        [GroupId],
        [NumberStudentsShouldBe],
        [NumberRegisteredStudents]
    FROM [GroupDetails]
    WHERE [GroupId] IN (
        SELECT [Id] FROM @groups
        );
    
    INSERT
    INTO @studentGroups (
    [StudentId],
        [GroupId]
    )
    SELECT
        [StudentId],
        [GroupId]
    FROM [Student_Group]
    WHERE [GroupId] IN (
        SELECT [Id] FROM @groups
        );
    
    INSERT
    INTO @students (
    [Id],
        [FirstName],
        [SecondName],
        [LastName],
        [Email],
        [Phone],
        [Login],
        [Password],
        [Token],
        [EmailConfirmed]
    )
    SELECT
        [Id],
        [FirstName],
        [SecondName],
        [LastName],
        [Email],
        [Phone],
        [Login],
        [Password],
        [Token],
        [EmailConfirmed]
    FROM [User]
    WHERE [Id] IN (
        SELECT [StudentId] FROM @studentGroups
        );
    
    SELECT * FROM @groups;
    SELECT * FROM @groupDetails;
    SELECT * FROM @studentGroups;
    SELECT * FROM @students;
END