CREATE PROCEDURE [StudentCharacteristicRepository_AddOrUpdateStudentCharacteristic]
	@studentCharacteristic [UDT_StudentCharacteristic] READONLY,
	@practiceDetailsId INT
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
    INTO [StudentCharacteristics] AS [dest]
    USING @studentCharacteristic AS [src]
    ON [dest].[Id] = [src].[Id]
    OR [dest].[StudentId] = [src].[StudentId]
    WHEN NOT MATCHED THEN
    INSERT (
        [StudentId],
        [DescriptionByHead],
        [DescriptionByCafedraHead],
        [MissedDaysWithReason],
        [MissedDaysWithoutReason]
    ) VALUES (
        [src].[StudentId],
        [src].[DescriptionByHead],
        [src].[DescriptionByCafedraHead],
        [src].[MissedDaysWithReason],
        [src].[MissedDaysWithoutReason]
    )
    WHEN MATCHED THEN
    UPDATE
        SET
        [dest].[StudentId] = [src].[StudentId],
        [dest].[DescriptionByHead] = [src].[DescriptionByHead],
        [dest].[DescriptionByCafedraHead] = [src].[DescriptionByCafedraHead],
        [dest].[MissedDaysWithReason] = [src].[MissedDaysWithReason],
        [dest].[MissedDaysWithoutReason] = [src].[MissedDaysWithoutReason]
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @studentCharacteristicId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    UPDATE [PracticeDetails]
    SET [StudentCharacteristicId] = @studentCharacteristicId
    WHERE [Id] = @practiceDetailsId;
    
    SELECT @studentCharacteristicId;
END