CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateCafedra]
	@cafedra [UDT_Cafedra] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [Cafedra] AS [dest]
        USING @cafedra AS [src]
        ON [dest].[Id] = [src].[Id]
        OR [dest].[Name] = [src].[Name]
        WHEN NOT MATCHED THEN
        INSERT (
            [Name],
            [InstituteId]
        ) VALUES (
            [src].[Name],
            [src].[InstituteId]
        )
        WHEN MATCHED THEN
    UPDATE
        SET
        [dest].[Name] = [src].[Name],
        [dest].[InstituteId] = [src].[InstituteId]
    
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @cafedraId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @cafedraId;

END