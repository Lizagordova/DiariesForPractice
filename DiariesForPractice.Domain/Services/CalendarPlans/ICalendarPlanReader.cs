using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.CalendarPlans
{
    public interface ICalendarPlanReader
    {
        CalendarPlan GetCalendarPlan(int calendarPlanId);
    }
}