CREATE TABLE [Comment]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [UserId] INT REFERENCES [User]([Id]),
    [Text] NVARCHAR(MAX),
    [PublishDate] DATETIME2,
    [GroupId] INT REFERENCES [CommentGroup]([Id]) ON DELETE CASCADE
);