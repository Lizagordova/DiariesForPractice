CREATE TYPE [UDT_Cafedra] AS TABLE
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100),
    [InstituteId] INT
);