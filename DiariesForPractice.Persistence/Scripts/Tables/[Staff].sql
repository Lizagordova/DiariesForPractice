CREATE TABLE [Staff]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [OrganizationId] INT REFERENCES [Organization]([Id]) ON DELETE CASCADE,
    [FullName] NVARCHAR(MAX),
    [Job] NVARCHAR(100),
    [Email] NVARCHAR(MAX),
    [Phone] NVARCHAR(100)
);