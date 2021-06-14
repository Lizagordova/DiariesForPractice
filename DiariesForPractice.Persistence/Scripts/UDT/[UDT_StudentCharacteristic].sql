CREATE TYPE [UDT_StudentCharacteristic] AS TABLE
(
    [Id] INT,
    [StudentId] INT,
    [DescriptionByHead] NVARCHAR(MAX),
    [DescriptionByCafedraHead] NVARCHAR(MAX),
    [MissedDaysWithReason] INT,
    [MissedDaysWithoutReason] INT
);