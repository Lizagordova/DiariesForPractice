CREATE TABLE [GroupDetails]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [GroupId] INT REFERENCES [Group]([Id]) ON DELETE CASCADE,
    [NumberStudentsShouldBe] INT,
    [NumberRegisteredStudents] INT
);