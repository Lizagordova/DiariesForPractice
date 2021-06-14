CREATE TYPE [UDT_Notification] AS TABLE
(
    [Id] INT,
    [Message] NVARCHAR(MAX),
    [Date] DATETIME2,
    [Type] INT
);