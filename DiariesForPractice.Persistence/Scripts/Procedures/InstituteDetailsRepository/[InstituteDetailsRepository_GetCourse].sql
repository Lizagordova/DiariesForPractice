CREATE PROCEDURE [InstituteDetailsRepository_GetCourse]
	@courseId INT
AS
BEGIN
	DECLARE @course [UDT_Course];

    INSERT
    INTO @course (
    [Id],
        [Name]
    )
    SELECT
        [Id],
        [Name]
    FROM [Course]
    WHERE [Id] = @courseId;
    
    SELECT * FROM @course;
END