using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
    public interface ICalendarPlanRepository
    {
        int AddOrUpdateCalendarPlan(CalendarPlan calendarPlan);
        int AddOrUpdateCalendarWeekPlan(CalendarPlanWeek calendarPlanWeek);
        CalendarPlan GetCalendarPlan(int calendarPlanId);
        void AttachCalendarPlanToPractice(int calendarPlanId, int practiceDetailsId);
    }
}