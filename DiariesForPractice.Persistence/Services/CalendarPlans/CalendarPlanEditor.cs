using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.CalendarPlans;
using DiariesForPractice.Persistence.Repositories;

namespace DiariesForPractice.Persistence.Services.CalendarPlans
{
    public class CalendarPlanEditor : ICalendarPlanEditor
    {
        private readonly ICalendarPlanRepository _calendarPlanRepository;
        
        public CalendarPlanEditor(
            CalendarPlanRepository calendarPlanRepository)
        {
            _calendarPlanRepository = calendarPlanRepository;
        }
        
        public int AddOrUpdateCalendarPlan(CalendarPlan calendarPlan)
        {
            var calendarPlanId = _calendarPlanRepository.AddOrUpdateCalendarPlan(calendarPlan);

            return calendarPlanId;
        }

        public int AddOrUpdateCalendarWeekPlan(CalendarPlanWeek calendarPlanWeek)
        {
            var calendarPlanWeekId = _calendarPlanRepository.AddOrUpdateCalendarWeekPlan(calendarPlanWeek);

            return calendarPlanWeekId;
        }
    }
}