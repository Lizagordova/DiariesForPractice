using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.CalendarPlans
{
    public interface ICalendarPlanEditor
    {
        int AddOrUpdateCalendarPlan(CalendarPlan calendarPlan);//todo: внутри нужно сделать аттач к практике
        int AddOrUpdateCalendarWeekPlan(CalendarPlanWeek calendarPlanWeek);
    }
}