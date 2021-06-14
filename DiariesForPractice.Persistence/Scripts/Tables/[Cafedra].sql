CREATE TABLE [Cafedra]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100),
    [InstituteId] INT REFERENCES [Institute]([Id]) ON DELETE CASCADE
);