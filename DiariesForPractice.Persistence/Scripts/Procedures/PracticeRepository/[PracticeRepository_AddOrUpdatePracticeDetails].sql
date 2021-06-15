CREATE PROCEDURE [PracticeRepository_AddOrUpdatePracticeDetails]
	@practiceDetails [UDT_PracticeDetails] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [PracticeDetails] AS [dest]
        USING @practiceDetails AS [src]
        ON [dest].[Id] = [src].[Id]
        OR [dest].[StudentId] = [src].[StudentId]
        WHEN NOT MATCHED THEN
        INSERT (
        [StudentId],
        [OrganizationId],
        [ReportingForm],
        [ContractNumber],
        [ResponsibleForStudent],
        [SignsTheContract],
        [PracticeType],
        [StartDate],
        [EndDate],
        [StructuralDivision],
        [OrderId],
        [StudentCharacteristicId],
        [StudentTaskId]
        ) VALUES (
        [src].[StudentId],
        [src].[OrganizationId],
        [src].[ReportingForm],
        [src].[ContractNumber],
        [src].[ResponsibleForStudent],
        [src].[SignsTheContract],
        [src].[PracticeType],
        [src].[StartDate],
        [src].[EndDate],
        [src].[StructuralDivision],
        [src].[OrderId],
        [src].[StudentCharacteristicId],
        [src].[StudentTaskId]
        )
        WHEN MATCHED THEN
    UPDATE
        SET
        [dest].[StudentId] = [src].[StudentId],
        [dest].[OrganizationId] = [src].[OrganizationId],
        [dest].[ReportingForm] = [src].[ReportingForm],
        [dest].[ContractNumber] = [src].[ContractNumber],
        [dest].[ResponsibleForStudent] = [src].[ResponsibleForStudent],
        [dest].[SignsTheContract] = [src].[SignsTheContract],
        [dest].[PracticeType] = [src].[PracticeType],
        [dest].[StartDate] = [src].[StartDate],
        [dest].[EndDate] = [src].[EndDate],
        [dest].[StructuralDivision] = [src].[StructuralDivision],
        [dest].[OrderId] = [src].[OrderId],
        [dest].[StudentCharacteristicId] = [src].[StudentCharacteristicId],
        [dest].[StudentTaskId] = [src].[StudentTaskId]
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @practiceDetailsId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @practiceDetailsId;
END