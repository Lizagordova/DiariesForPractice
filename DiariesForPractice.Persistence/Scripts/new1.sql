

    CREATE PROCEDURE [NotificationRepository_GetUserNotifications]
        @userForId INT,
        @watched BIT = NULL
    AS
    BEGIN
        DECLARE @userNotifications [UDT_User_Notification];

        INSERT
        INTO @userNotifications (
            [Id],
            [NotificationId],
            [UserFor],
            [Watched]
        )
        SELECT
            [Id],
            [NotificationId],
            [UserFor],
            [Watched]
        FROM [User_Notification]
        WHERE [UserFor] = @userForId
          AND (@watched IS NULL OR [Watched] = @watched);


        SELECT * FROM @userNotifications;
    END





        CREATE PROCEDURE [InstituteDetailsRepository_RemoveStudentFromGroup]
            @studentId INT,
            @groupId INT
        AS
        BEGIN
            DELETE
            FROM [Student_Group]
            WHERE
                    [StudentId] = @studentId
              AND [GroupId] = @groupId;

        end


            CREATE PROCEDURE [CalendarPlanRepository_AddOrUpdateCalendarPlan]
            @calendarPlan [UDT_CalendarPlan] READONLY
            AS
            BEGIN
                DECLARE @mergedIds TABLE([Id] INT);

                MERGE
                INTO [CalendarPlan] AS [dest]
                USING @calendarPlan AS [src]
                ON [dest].[Id] = [src].[Id]
                    OR [dest].[PracticeDetailsId] = [src].[PracticeDetailsId]
                WHEN NOT MATCHED THEN
                    INSERT (
                        [PracticeDetailsId]
                    ) VALUES (
                                 [src].[PracticeDetailsId]
                             )
                    OUTPUT INSERTED.ID INTO @mergedIds;

                DECLARE @calendarPlanId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

                SELECT @calendarPlanId;
            END

                CREATE PROCEDURE [CalendarPlanRepository_AddOrUpdateCalendarWeekPlan]
                    @calendarPlanId INT,
                    @calendarWeekPlan [UDT_CalendarWeekPlan] READONLY
                AS
                BEGIN
                    DECLARE @mergedIds TABLE([Id] INT);

                    MERGE
                    INTO [CalendarWeekPlan] AS [dest]
                    USING @calendarWeekPlan AS [src]
                    ON [dest].[Id] = [src].[Id]
                    WHEN NOT MATCHED THEN
                        INSERT (
                            [StartDate],
                            [EndDate],
                            [NameOfTheWork],
                            [StructuralDivision]
                        ) VALUES (
                                     [src].[StartDate],
                                     [src].[EndDate],
                                     [src].[NameOfTheWork],
                                     [src].[StructuralDivision]
                                 )
                    WHEN MATCHED THEN
                        UPDATE
                        SET
                            [dest].[StartDate] = [src].[StartDate],
                            [dest].[EndDate] = [src].[EndDate],
                            [dest].[NameOfTheWork] = [src].[NameOfTheWork],
                            [dest].[StructuralDivision] = [src].[StructuralDivision]
                        OUTPUT INSERTED.ID INTO @mergedIds;

                    DECLARE @calendarPlanWeekId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

                    MERGE
                    INTO [CalendarPlan_CalendarWeekPlan] AS [dest]
                    USING @calendarWeekPlan AS [src]
                    ON [dest].[CalendarPlanId] = @calendarPlanId
                        OR [dest].[CalendarWeekPlanId] = @calendarPlanWeekId
                    WHEN NOT MATCHED THEN
                        INSERT (
                            [CalendarPlanId],
                            [CalendarWeekPlanId]
                        )
                        VALUES (
                                   @calendarPlanId,
                                   @calendarPlanWeekId
                               );

                    SELECT @calendarPlanWeekId;
                END

                    CREATE PROCEDURE [CalendarPlanRepository_GetCalendarPlan]
                    @practiceDetailsId INT
                    AS
                    BEGIN
                        DECLARE @calendarPlanId INT = (
                            SELECT [Id]
                            FROM [CalendarPlan]
                            WHERE [PracticeDetailsId] = @practiceDetailsId
                        );

                        DECLARE @calendarPlanWeeks [UDT_CalendarWeekPlan];

                        INSERT
                        INTO @calendarPlanWeeks (
                            [Id],
                            [StartDate],
                            [EndDate],
                            [NameOfTheWork],
                            [StructuralDivision],
                            [Order]
                        )
                        SELECT
                            [Id],
                            [StartDate],
                            [EndDate],
                            [NameOfTheWork],
                            [StructuralDivision],
                            [cp_cwp].[Order]
                        FROM [CalendarWeekPlan] AS [cp]
                                 JOIN [CalendarPlan_CalendarWeekPlan] AS [cp_cwp]
                                      ON [cp_cwp].[CalendarWeekPlanId] = [cp].[Id]
                        WHERE [Id] IN (
                            SELECT [Id]
                            FROM [CalendarPlan_CalendarWeekPlan]
                            WHERE [CalendarPlanId] = @calendarPlanId
                        );

                        SELECT @calendarPlanId;
                        SELECT * FROM @calendarPlanWeeks;
                    END


                    select * from [User]