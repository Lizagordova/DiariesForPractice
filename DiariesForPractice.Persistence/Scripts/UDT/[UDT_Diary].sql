CREATE TYPE [UDT_Diary] AS TABLE
(
    [Id] INT,
    [StudentId] INT,
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