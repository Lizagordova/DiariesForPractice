using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
    public interface ICalendarPlanRepository
    {
        int AddOrUpdateCalendarPlan(int calendarPlanId, int practiceDetailsId);
        int AddOrUpdateCalendarWeekPlan(CalendarPlanWeek calendarPlanWeek, int calendarPlanId);
        CalendarPlan GetCalendarPlan(int calendarPlanId);
    }
}