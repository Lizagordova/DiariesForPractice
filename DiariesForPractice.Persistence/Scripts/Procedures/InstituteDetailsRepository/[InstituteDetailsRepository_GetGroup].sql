CREATE PROCEDURE [InstituteDetailsRepository_GetGroup]
	@groupId INT
AS
BEGIN
	DECLARE @group [UDT_Group];
	DECLARE @groupDetails [UDT_GroupDetails];

    INSERT
    INTO @group (
    [Id],
        [DirectionId],
        [CourseId],
        [Name]
    )
    SELECT
        [Id],
        [DirectionId],
        [CourseId],
        [Name]
    FROM [Group]
    WHERE [Id] = @groupId;
    
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
    WHERE [GroupId] = @groupId;
    
    SELECT * FROM @group;
END