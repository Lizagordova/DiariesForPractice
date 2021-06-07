using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.CalendarPlans
{
    public interface ICalendarPlanEditor
    {
        CalendarPlan AddOrUpdateCalendarPlan(CalendarPlan calendarPlan,int calendarPlanId);//todo: внутри нужно сделать аттач к практике
    }
}