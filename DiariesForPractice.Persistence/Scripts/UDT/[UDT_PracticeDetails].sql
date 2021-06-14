CREATE TYPE [UDT_PracticeDetails] AS TABLE
(
    [Id] INT,
    [StudentId] INT,
    [OrganizationId] INT,
    [ReportingForm] INT,
    [ContractNumber] NVARCHAR(100),
    [ResponsibleForStudent] INT,
    [SignsTheContract] INT,
    [PracticeType] INT,
    [StartDate] DATETIME2,
    [EndDate] DATETIME2,
    [StructuralDivision] NVARCHAR(MAX),
    [OrderId] INT,
    [StudentCharacteristicId] INT,
    [StudentTaskId] INT
);