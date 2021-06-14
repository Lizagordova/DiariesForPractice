CREATE TYPE [UDT_Log] AS TABLE
(
    [Id] INT,
    [Message] NVARCHAR(MAX),
    [CustomMessage] NVARCHAR(MAX),
    [Date] DATETIME2,
    [LogType] INT,
    [LogLevel] INT
);