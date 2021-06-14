CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateInstitute]
	@institute [UDT_Institute] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [Institute] AS [dest]
        USING @institute AS [src]
        ON [dest].[Id] = [src].[Id]
        OR [dest].[Name] = [src].[Name]
        WHEN NOT MATCHED THEN
        INSERT (
        [Name]
        ) VALUES (
        [src].[Name]
        )
        WHEN MATCHED THEN
    UPDATE
        SET
        [dest].[Name] = [src].[Name]
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @instituteId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @instituteId;
END