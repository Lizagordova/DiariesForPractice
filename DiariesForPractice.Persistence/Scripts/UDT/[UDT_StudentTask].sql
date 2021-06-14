CREATE TYPE [UDT_StudentTask] AS TABLE
(
    [Id] INT,
    [StudentId] INT,
    [Task] NVARCHAR(MAX),
    [Mark] INT
);