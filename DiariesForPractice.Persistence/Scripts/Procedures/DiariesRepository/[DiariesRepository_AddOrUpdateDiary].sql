CREATE PROCEDURE [DiariesRepository_AddOrUpdateDiary]
	@diary [UDT_Diary] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [Diary] AS [dest]
        USING @diary AS [src]
        ON [dest].[Id] = [src].[Id]
        OR [dest].[StudentId] = [src].[StudentId]
        WHEN NOT MATCHED THEN
        INSERT (
        [Path],
        [StudentId],
        [Generated],
        [Send],
        [Perceived],
        [Approved],
        [SendDate],
        [GeneratedDate],
        [PerceivedDate],
        [Comment],
        [Completion]
        ) VALUES (
        [src].[Path],
        [src].[StudentId],
        [src].[Generated],
        [src].[Send],
        [src].[Perceived],
        [src].[Approved],
        [src].[SendDate],
        [src].[GeneratedDate],
        [src].[PerceivedDate],
        [src].[Comment],
        [src].[Completion]
        )
        WHEN MATCHED THEN
    UPDATE
        SET
        [dest].[Path] = [src].[Path],
        [dest].[StudentId] = [src].[StudentId],
        [dest].[Generated] = [src].[Generated],
        [dest].[Send] = [src].[Send],
        [dest].[Perceived] = [src].[Perceived],
        [dest].[Approved] = [src].[Approved],
        [dest].[SendDate] = [src].[SendDate],
        [dest].[GeneratedDate] = [src].[GeneratedDate],
        [dest].[PerceivedDate] = [src].[PerceivedDate],
        [dest].[Comment] = [src].[Comment],
        [dest].[Completion] = [src].[Completion]
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @diaryId INT = (SELECT TOP 1 [Id] FROM [Diary]);
    
    SELECT @diaryId;
END