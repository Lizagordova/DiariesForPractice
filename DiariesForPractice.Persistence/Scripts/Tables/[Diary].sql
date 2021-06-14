CREATE TABLE [Diary]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [StudentId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
    [Path] NVARCHAR(MAX),
    [Generated] BIT,
    [Send] BIT,
    [Approved] BIT,
    [Perceived] BIT,
    [GeneratedDate] DATETIME2,
    [SendDate] DATETIME2,
    [PerceivedDate] DATETIME2,
    [Completion] INT,
    [Comment] NVARCHAR(MAX)
);