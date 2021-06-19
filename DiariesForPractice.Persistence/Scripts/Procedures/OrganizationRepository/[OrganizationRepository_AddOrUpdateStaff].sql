CREATE PROCEDURE [OrganizationRepository_AddOrUpdateStaff]
	@staff [UDT_Staff] READONLY
AS
BEGIN
    DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [Staff] AS [dest]
        USING @staff AS [src]
        ON [dest].[Id] = [src].[Id]
        OR (
        [dest].[OrganizationId] = [src].[OrganizationId]
        AND [dest].[FullName] = [src].[FullName]
        )
        WHEN NOT MATCHED THEN
        INSERT (
        [OrganizationId],
        [FullName],
        [Job],
        [Email],
        [Phone]
        ) VALUES (
        [src].[OrganizationId],
        [src].[FullName],
        [src].[Job],
        [src].[Email],
        [src].[Phone]
        )
        WHEN MATCHED THEN
    UPDATE
        SET
        [dest].[OrganizationId] = [src].[OrganizationId],
        [dest].[FullName] = [src].[FullName],
        [dest].[Job] = [src].[Job],
        [dest].[Email] = [src].[Email],
        [dest].[Phone] = [src].[Phone]
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @staffId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @staffId;
END