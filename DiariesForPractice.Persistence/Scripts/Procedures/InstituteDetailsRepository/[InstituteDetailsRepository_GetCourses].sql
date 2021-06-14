CREATE PROCEDURE [InstituteDetailsRepository_GetCourses]
	@degreeId INT = NULL
AS
BEGIN
	DECLARE @courses [UDT_Course];

    INSERT
    INTO @courses (
    [Id],
        [Name]
    )
    SELECT
        [Id],
        [Name]
    FROM [Course] AS [c]
        JOIN [Course_Degree] AS [cd]
    ON [cd].[CourseId] = [c].[Id]
    WHERE (@degreeId IS NULL OR [cd].[DegreeId] = @degreeId);
    
    SELECT * FROM @courses;
END