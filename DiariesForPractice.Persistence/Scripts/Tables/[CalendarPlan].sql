CREATE TABLE [CalendarPlan]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [PracticeDetailsId]INT REFERENCES [PracticeDetails]([Id]) ON DELETE CASCADE
);