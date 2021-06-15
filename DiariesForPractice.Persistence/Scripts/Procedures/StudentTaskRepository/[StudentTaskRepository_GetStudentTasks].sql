CREATE PROCEDURE [StudentTaskRepository_GetStudentTasks]
AS
BEGIN
	DECLARE @studentTasks [UDT_StudentTask];

    INSERT
    INTO @studentTasks (
    [Id],
        [StudentId],
        [Task]
    )
    SELECT
        [Id],
        [StudentId],
        [Task]
    FROM [StudentTask];
    
    SELECT * FROM @studentTasks;
END