
CREATE TABLE [PracticeDetails]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [StudentId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
    [OrganizationId] INT REFERENCES [Organization]([Id]) ON DELETE CASCADE,
    [ReportingForm] INT,
    [ContractNumber] NVARCHAR(100),
    [ResponsibleForStudent] INT,
    [SignsTheContract] INT,
    [PracticeType] INT,
    [StartDate] DATETIME2,
    [EndDate] DATETIME2,
    [StructuralDivision] NVARCHAR(MAX),
    [OrderId] INT REFERENCES [Order]([Id]),
    [StudentCharacteristicId] INT,
    [StudentTaskId] INT
);