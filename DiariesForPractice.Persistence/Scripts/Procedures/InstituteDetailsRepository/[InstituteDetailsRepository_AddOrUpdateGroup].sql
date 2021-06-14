CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateGroup]
	@group [UDT_Group] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [Group] AS [dest]
        USING @group AS [src]
        ON [dest].[Id] = [src].[Id]
        OR [dest].[Name] = [src].[Name]
        WHEN NOT MATCHED THEN
        INSERT (
        [Name],
        [DirectionId],
        [CourseId]
        ) VALUES (
        [src].[Name],
        [src].[DirectionId],
        [src].[CourseId]
        )
        WHEN MATCHED THEN
    UPDATE
        SET
        [dest].[Name] = [src].[Name],
        [dest].[DirectionId] = [src].[DirectionId],
        [dest].[CourseId] = [src].[CourseId]
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @groupId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @groupId;

END