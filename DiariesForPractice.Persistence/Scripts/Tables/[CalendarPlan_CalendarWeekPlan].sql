CREATE TABLE [CalendarPlan_CalendarWeekPlan]
(
    [CalendarPlanId] INT REFERENCES [CalendarPlan]([Id]) ON DELETE CASCADE ,
    [CalendarWeekPlanId] INT REFERENCES [CalendarWeekPlan]([Id]) ON DELETE CASCADE,
    [Order] INT
);