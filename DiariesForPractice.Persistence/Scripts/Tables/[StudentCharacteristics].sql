CREATE TABLE [StudentCharacteristics]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [StudentId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
    [DescriptionByHead] NVARCHAR(MAX),
    [DescriptionByCafedraHead] NVARCHAR(MAX),
    [MissedDaysWithReason] INT,
    [MissedDaysWithoutReason] INT
);