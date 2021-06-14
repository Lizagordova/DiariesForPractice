CREATE PROCEDURE [StudentTaskRepository_GetStudentTask]
	@studentId INT
AS
BEGIN
	DECLARE @studentTask [UDT_StudentTask];

    INSERT
    INTO @studentTask (
    [Id],
        [StudentId],
        [Task]
    )
    SELECT
        [Id],
        [StudentId],
        [Task]
    FROM [StudentTask]
    WHERE [StudentId] = @studentId;
    
    SELECT * FROM @studentTask;

END