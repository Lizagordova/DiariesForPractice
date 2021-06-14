CREATE PROCEDURE [OrganizationRepository_AddOrUpdateOrganization]
	@organization [UDT_Organization] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [Organization] AS [dest]
        USING @organization AS [src]
        ON [dest].[Id] = [src].[Id]
        OR [dest].[Name] = [src].[Name]
        WHEN NOT MATCHED THEN
        INSERT (
        [Name],
        [LegalAddress]
        ) VALUES (
        [src].[Name],
        [src].[LegalAddress]
        )
        WHEN MATCHED THEN
    UPDATE
        SET
        [dest].[Name] = [src].[Name],
        [dest].[LegalAddress] = [src].[LegalAddress]
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @organizationId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @organizationId;
END