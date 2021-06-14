CREATE TABLE [CalendarWeekPlan]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [StartDate] DATETIME2,
    [EndDate] DATETIME2,
    [NameOfTheWork] NVARCHAR(MAX),
    [Mark] INT,
    [StructuralDivision] NVARCHAR(MAX)
);