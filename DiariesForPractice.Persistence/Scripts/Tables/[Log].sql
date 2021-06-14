CREATE TABLE [Log]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Message] NVARCHAR(MAX),
    [CustomMessage] NVARCHAR(MAX),
    [Date] DATETIME2,
    [LogType] INT,
    [LogLevel] INT
);
