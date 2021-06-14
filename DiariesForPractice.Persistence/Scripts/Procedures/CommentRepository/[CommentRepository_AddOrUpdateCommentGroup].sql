
CREATE PROCEDURE [CommentRepository_AddOrUpdateCommentGroup]
	@commentGroup [UDT_CommentGroup] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [CommentGroup] AS [dest]
        USING @commentGroup AS [src]
        ON [dest].[Id] = [src].[Id]
        OR
        ([dest].[CommentedEntityType] = [src].[CommentedEntityType]
        AND [dest].[CommentedEntityId] = [src].[CommentedEntityId]
        AND [dest].[UserId] = [src].[UserId]
        )
        WHEN NOT MATCHED THEN
        INSERT (
        [CommentedEntityType],
        [CommentedEntityId],
        [UserId]
        ) VALUES (
        [src].[CommentedEntityType],
        [src].[CommentedEntityId],
        [src].[UserId]
        )
        WHEN MATCHED THEN
    UPDATE
        SET
        [dest].[CommentedEntityType] = [src].[CommentedEntityType],
        [dest].[CommentedEntityId] = [src].[CommentedEntityId],
        [dest].[UserId] = [src].[UserId]
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @commentGroupId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @commentGroupId;
END