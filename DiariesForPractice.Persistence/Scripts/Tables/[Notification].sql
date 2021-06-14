CREATE TABLE [Notification]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Message] NVARCHAR(MAX),
    [Date] DATETIME2,
    [Type] INT
);