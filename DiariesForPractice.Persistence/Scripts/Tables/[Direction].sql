﻿CREATE TABLE [Direction]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100),
    [CafedraId] INT REFERENCES [Cafedra]([Id]) ON DELETE CASCADE
);