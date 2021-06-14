CREATE TYPE [UDT_Staff] AS TABLE
(
    [Id] INT,
    [OrganizationId] INT,
    [FullName] NVARCHAR(MAX),
    [Job] NVARCHAR(100),
    [Email] NVARCHAR(MAX),
    [Phone] NVARCHAR(100)
);