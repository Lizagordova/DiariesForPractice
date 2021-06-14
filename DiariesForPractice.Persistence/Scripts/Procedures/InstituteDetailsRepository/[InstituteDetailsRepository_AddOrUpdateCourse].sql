CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateCourse]
	@course [UDT_Course] READONLY,
	@degreeId INT
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

MERGE
    INTO [Course] AS [dest]
    USING @course AS [src]
    ON [dest].[Id] = [src].[Id]
    OR [dest].[Name] = [src].[Name]
    WHEN NOT MATCHED THEN
    INSERT (
        [Name]
    ) VALUES (
        [src].[Name]
    )
    WHEN MATCHED THEN
    UPDATE
    SET
    [dest].[Name] = [src].[Name]
    OUTPUT INSERTED.ID INTO @mergedIds;

    DECLARE @courseId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

    MERGE
    INTO [Course_Degree] AS [dest]
    USING @course AS [src]
    ON [dest].[CourseId] = @courseId
    AND [dest].[DegreeId] = @degreeId
    WHEN NOT MATCHED THEN
    INSERT (
        [CourseId],
        [DegreeId]
    ) VALUES (
        @courseId,
        @degreeId
    );

SELECT @courseId;
END
