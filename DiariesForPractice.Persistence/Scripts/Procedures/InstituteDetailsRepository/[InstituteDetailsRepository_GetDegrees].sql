CREATE PROCEDURE [InstituteDetailsRepository_GetDegrees]
AS
BEGIN
	DECLARE @degrees [UDT_Degree];
	DECLARE @courses [UDT_Course];

    INSERT
    INTO @degrees (
    [Id],
        [Name]
    )
    SELECT
        [Id],
        [Name]
    FROM [Degree];
    
    INSERT
    INTO @courses (
    [Id],
        [Name],
        [DegreeId]
    )
    SELECT
        [c].[Id],
        [c].[Name],
        [cd].[DegreeId]
    FROM [Course] AS [c]
        JOIN [Course_Degree] AS [cd]
    ON [cd].[CourseId] = [c].[Id]
    WHERE [cd].[DegreeId] IN (SELECT [Id] FROM @degrees);
    
    SELECT * FROM @degrees;
    SELECT * FROM @courses;
END