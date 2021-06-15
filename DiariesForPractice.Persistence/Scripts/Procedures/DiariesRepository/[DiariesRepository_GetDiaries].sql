CREATE PROCEDURE [DiariesRepository_GetDiaries]
	@generated BIT = NULL
AS
BEGIN
	DECLARE @diaries [UDT_Diary];

    INSERT
    INTO @diaries (
        [Id],
        [Path],
        [Generated],
        [Send],
        [Perceived],
        [Approved],
        [SendDate],
        [GeneratedDate],
        [PerceivedDate],
        [StudentId],
        [Comment],
        [Completion]
    )
    SELECT
        [Id],
        [Path],
        [Generated],
        [Send],
        [Perceived],
        [Approved],
        [SendDate],
        [GeneratedDate],
        [PerceivedDate],
        [StudentId],
        [Comment],
        [Completion]
    FROM [Diary]
    WHERE (@generated IS NULL OR [Generated] = @generated);
    
    SELECT * FROM @diaries;
END