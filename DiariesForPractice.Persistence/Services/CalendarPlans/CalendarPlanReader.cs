using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.CalendarPlans;

namespace DiariesForPractice.Persistence.Services.CalendarPlans
{
    public class CalendarPlanReader : ICalendarPlanReader
    {
        private readonly ICalendarPlanRepository _calendarPlanRepository;
        
        public CalendarPlanReader(
            ICalendarPlanRepository calendarPlanRepository)
        {
            _calendarPlanRepository = calendarPlanRepository;
        }
        
        public CalendarPlan GetCalendarPlan(int calendarPlanId)
        {
            var calendarPlan = _calendarPlanRepository.GetCalendarPlan(calendarPlanId);

            return calendarPlan;
        }
    }
}