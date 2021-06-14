CREATE PROCEDURE [StudentTaskRepository_AddOrUpdateStudentTask]
	@studentTask [UDT_StudentTask] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [StudentTask] AS [dest]
        USING @studentTask AS [src]
        ON [dest].[Id] = [src].[Id]
        OR [dest].[StudentId] = [src].[StudentId]
    WHEN NOT MATCHED THEN
        INSERT (
        [StudentId],
        [Task]
        ) VALUES (
        [src].[StudentId],
        [src].[Task]
        )
    WHEN MATCHED THEN
        UPDATE
        SET
            [dest].[Task] = [src].[Task]
    
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @studentTaskId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @studentTaskId;

END