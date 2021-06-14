CREATE TABLE [User_Notification]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [NotificationId] INT REFERENCES [Notification]([Id]) ON DELETE CASCADE,
    [UserFor] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
    [Watched] BIT,
    [Answer] INT
);