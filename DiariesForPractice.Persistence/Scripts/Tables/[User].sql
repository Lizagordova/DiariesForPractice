﻿CREATE TABLE [User]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] NVARCHAR(100),
    [SecondName] NVARCHAR(100),
    [LastName] NVARCHAR(100),
    [Email] NVARCHAR(100),
    [Phone] NVARCHAR(100),
    [Token] NVARCHAR(MAX),
    [Login] NVARCHAR(100),
    [Password] NVARCHAR(100),
    [EmailConfirmed] BIT
);