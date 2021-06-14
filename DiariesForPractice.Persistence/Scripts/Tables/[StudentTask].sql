CREATE TABLE [StudentTask]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [StudentId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
    [Task] NVARCHAR(MAX),
    [Mark] INT
);