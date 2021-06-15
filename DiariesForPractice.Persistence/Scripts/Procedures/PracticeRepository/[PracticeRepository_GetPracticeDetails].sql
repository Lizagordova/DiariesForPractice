CREATE PROCEDURE [PracticeRepository_GetPracticeDetails]
	@groupId INT = NULL,
	@studentId INT = NULL
AS
BEGIN
	DECLARE @practiceDetails [UDT_PracticeDetails];

	IF @groupId IS NOT NULL
        BEGIN
        
                    DECLARE @studentIds TABLE([Id] INT);
        
        INSERT
        INTO @studentIds (
        [Id]
        )
        SELECT
            [StudentId]
        FROM [Student_Group]
        WHERE [GroupId] = @groupId;
        
        INSERT
        INTO @practiceDetails (
        [Id],
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
        )
        SELECT
            [Id],
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
        FROM [PracticeDetails]
        WHERE [StudentId] IN (SELECT [Id] FROM @studentIds);
        
        END
        ELSE
        BEGIN
        INSERT
        INTO @practiceDetails (
        [Id],
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
        )
        SELECT
            [Id],
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
        FROM [PracticeDetails]
        WHERE (@studentId IS NULL OR [StudentId] = @studentId);
        END
        
        
    SELECT * FROM @practiceDetails;

END