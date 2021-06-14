CREATE PROCEDURE [NotificationRepository_AddOrUpdateUserNotification]
	@userNotification [UDT_User_Notification] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

    MERGE
        INTO [User_Notification] AS [dest]
        USING @userNotification AS [src]
        ON [dest].[Id] = [src].[Id]
        OR ([dest].[NotificationId] = [src].[NotificationId]
        AND [dest].[UserFor] = [src].[UserFor])
        WHEN NOT MATCHED THEN
        INSERT (
        [NotificationId],
        [UserFor],
        [Watched],
        [Answer]
        ) VALUES (
        [src].[NotificationId],
        [src].[UserFor],
        [src].[Watched],
        [src].[Answer]
        )
        WHEN MATCHED THEN
    UPDATE
        SET
        [dest].[NotificationId] = [src].[NotificationId],
        [dest].[UserFor] = [src].[UserFor],
        [dest].[Watched] = [src].[Watched],
        [dest].[Answer] = [src].[Answer]
    
        OUTPUT INSERTED.ID INTO @mergedIds;
    
    DECLARE @userNotificationId INT = (SELECT TOP 1 [Id] FROM @mergedIds);
    
    SELECT @userNotificationId;
END