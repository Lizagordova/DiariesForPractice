CREATE PROCEDURE [PracticeRepository_AttachDataToPracticeDetails]	
	@practiceDetailsId INT,
	@organizationId INT = NULL,
	@responsibleForStudentId INT = NULL,
	@signsTheContractId INT = NULL,
	@studentCharacteristicId INT = NULL,
	@studentTaskId INT = NULL
AS
BEGIN
	IF(@organizationId IS NOT NULL)
        UPDATE
            [PracticeDetails]
        SET
            [OrganizationId] = @organizationId
        WHERE [Id] = @practiceDetailsId;

    IF(@responsibleForStudentId IS NOT NULL)
        UPDATE
            [PracticeDetails]
        SET
            [ResponsibleForStudent] = @responsibleForStudentId
        WHERE [Id] = @practiceDetailsId;

    IF(@signsTheContractId IS NOT NULL)
        UPDATE
            [PracticeDetails]
        SET
            [SignsTheContract] = @signsTheContractId
        WHERE [Id] = @practiceDetailsId;

    IF(@studentCharacteristicId IS NOT NULL)
        UPDATE
            [PracticeDetails]
        SET
            [StudentCharacteristicId] = @studentCharacteristicId
        WHERE [Id] = @practiceDetailsId;

    IF(@studentTaskId IS NOT NULL)
        UPDATE
            [PracticeDetails]
        SET
            [StudentTaskId] = @studentTaskId
        WHERE [Id] = @practiceDetailsId;

END