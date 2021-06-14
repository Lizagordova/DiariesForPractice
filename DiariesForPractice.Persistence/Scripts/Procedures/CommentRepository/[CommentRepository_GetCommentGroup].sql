CREATE PROCEDURE [CommentRepository_GetCommentGroup]
	@commentGroup [UDT_CommentGroup] READONLY
AS
BEGIN
	DECLARE @perceivedCommentGroup [UDT_CommentGroup];
	DECLARE @comments [UDT_Comment];

INSERT
INTO @perceivedCommentGroup (
[Id],
    [CommentedEntityType],
    [CommentedEntityId],
    [UserId]
)
SELECT
    [Id],
    [CommentedEntityType],
    [CommentedEntityId],
    [UserId]
FROM [CommentGroup]
WHERE ([Id] = (SELECT TOP 1[Id] FROM @commentGroup))
   OR ([CommentedEntityType] = (SELECT TOP 1 [CommentedEntityType] FROM @commentGroup)
  AND [CommentedEntityId] = (SELECT TOP 1 [CommentedEntityId] FROM @commentGroup)
  AND [UserId] = (SELECT TOP 1 [UserId] FROM @commentGroup)
    );

INSERT
INTO @comments (
[Id],
    [UserId],
    [Text],
    [PublishDate],
    [GroupId]
)
SELECT
    [Id],
    [UserId],
    [Text],
    [PublishDate],
    [GroupId]
FROM [Comment]
WHERE [GroupId] = (SELECT TOP 1 [Id] FROM @perceivedCommentGroup);

SELECT * FROM @perceivedCommentGroup;
SELECT * FROM @comments;
END