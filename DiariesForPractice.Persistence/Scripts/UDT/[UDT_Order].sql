﻿CREATE TYPE [UDT_Order] AS TABLE
(
    [Id] INT PRIMARY KEY IDENTITY,
    [OrderDate] DATETIME2,
    [Number] NVARCHAR(MAX)
);