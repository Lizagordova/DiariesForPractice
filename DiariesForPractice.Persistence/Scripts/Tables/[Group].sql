﻿CREATE TABLE [Group]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100),
    [DirectionId] INT REFERENCES [Direction]([Id]) ON DELETE CASCADE,
    [CourseId] INT REFERENCES [Course]([Id]) ON DELETE CASCADE
);