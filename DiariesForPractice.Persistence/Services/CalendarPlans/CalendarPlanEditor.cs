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
            ICalendarPlanRepository calendarPlanRepository)
        {
            _calendarPlanRepository = calendarPlanRepository;
        }
        
        public CalendarPlan AddOrUpdateCalendarPlan(CalendarPlan calendarPlan, int practiceDetailsId)
        {
            var calendarPlanId = _calendarPlanRepository.AddOrUpdateCalendarPlan(calendarPlan.Id, practiceDetailsId);
            foreach (var calendarPlanWeek in calendarPlan.CalendarPlanWeeks)
            {
               calendarPlanWeek.Id = _calendarPlanRepository.AddOrUpdateCalendarWeekPlan(calendarPlanWeek, calendarPlanId);
            }

            var updatedCalendarPlan = _calendarPlanRepository.GetCalendarPlan(calendarPlan.Id);
            return updatedCalendarPlan;
        }
    }
}