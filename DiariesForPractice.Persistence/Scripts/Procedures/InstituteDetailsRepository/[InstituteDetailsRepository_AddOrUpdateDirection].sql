CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateDirection]
	@direction [UDT_Direction] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [Direction] AS [dest]
        USING @direction AS [src]
        ON [dest].[Id] = [src].[Id]
        OR [dest].[Name] = [src].[Name]
        WHEN NOT MATCHED THEN
        INSERT (
        [Name],
        [CafedraId]
        ) VALUES (
        [src].[Name],
        [src].[CafedraId]
        )
        WHEN MATCHED THEN
    UPDATE
        SET
        [dest].[Name] = [src].[Name],
        [dest].[CafedraId] = [src].[CafedraId]
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @directionId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @directionId;
END