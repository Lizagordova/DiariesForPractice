CREATE TABLE [Student_Group]
(
    [StudentId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
    [GroupId] INT REFERENCES [Group]([Id]) ON DELETE CASCADE
);