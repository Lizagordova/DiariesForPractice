CREATE TABLE [CommentGroup]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [CommentedEntityType] INT,
    [CommentedEntityId] INT,
    [UserId] INT REFERENCES [User]([Id]) ON DELETE CASCADE
);