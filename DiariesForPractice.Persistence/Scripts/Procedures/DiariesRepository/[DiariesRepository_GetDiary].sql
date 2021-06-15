CREATE PROCEDURE [DiariesRepository_GetDiary]
	@studentId INT
AS
BEGIN
	DECLARE @diary [UDT_Diary];

    INSERT
    INTO @diary (
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
        [Comment]
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
        [Comment]
    FROM [Diary]
    WHERE [StudentId] = @studentId;
    
    SELECT * FROM @diary;
END