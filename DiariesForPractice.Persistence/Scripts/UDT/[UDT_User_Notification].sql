CREATE TYPE [UDT_User_Notification] AS TABLE
(
    [Id] INT,
    [NotificationId] INT,
    [UserFor] INT,
    [Watched] BIT,
    [Answer] INT
);