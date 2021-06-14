CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateDegree]
	@degree [UDT_Degree] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [Degree] AS [dest]
        USING @degree AS [src]
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
    
    DECLARE @degreeId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @degreeId;
END