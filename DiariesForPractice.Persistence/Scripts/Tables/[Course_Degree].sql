CREATE TABLE [Course_Degree]
(
    [CourseId] INT REFERENCES [Course]([Id]) ON DELETE CASCADE,
    [DegreeId] INT REFERENCES [Degree]([Id]) ON DELETE CASCADE
);