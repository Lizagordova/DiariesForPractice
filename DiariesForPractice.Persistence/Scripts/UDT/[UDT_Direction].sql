CREATE TYPE [UDT_Direction] AS TABLE
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100),
    [CafedraId] INT
);