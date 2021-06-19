CREATE PROCEDURE [StudentTaskRepository_AddOrUpdateStudentTask]
	@studentTask [UDT_StudentTask] READONLY,
    @practiceDetailsId INT
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
        [Task],
        [Mark]
        ) VALUES (
        [src].[StudentId],
        [src].[Task],
        [src].[Mark]
        )
    WHEN MATCHED THEN
        UPDATE
        SET
            [dest].[Task] = [src].[Task],
            [dest].[Mark] = [src].[Mark]
    
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @studentTaskId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

    UPDATE [PracticeDetails]
    SET [StudentTaskId] = @studentTaskId
    WHERE [Id] = @practiceDetailsId;

    SELECT @studentTaskId;

END