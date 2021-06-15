CREATE PROCEDURE [StudentCharacteristicRepository_GetStudentCharacteristic]
	@studentId INT
AS
BEGIN
	DECLARE @studentCharacteristic [UDT_StudentCharacteristic];

    INSERT
    INTO @studentCharacteristic (
    [Id],
        [StudentId],
        [DescriptionByHead],
        [DescriptionByCafedraHead],
        [MissedDaysWithReason],
        [MissedDaysWithoutReason]
    )
    SELECT
        [Id],
        [StudentId],
        [DescriptionByHead],
        [DescriptionByCafedraHead],
        [MissedDaysWithReason],
        [MissedDaysWithoutReason]
    FROM [StudentCharacteristics]
    WHERE [StudentId] = @studentId;
    
    SELECT * FROM @studentCharacteristic;
END
