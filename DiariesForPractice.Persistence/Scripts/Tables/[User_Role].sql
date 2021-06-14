CREATE TABLE [User_Role]
(
    [UserId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
    [Role] INTEGER
);