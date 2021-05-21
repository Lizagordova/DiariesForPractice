using System;
using System.Collections.Generic;

namespace DiariesForPractice.Domain.Models
{
    public class CalendarPlan
    {
        public int Id { get; set; }
        public IReadOnlyCollection<CalendarPlanWeek> CalendarPlanWeeks { get; set; } = Array.Empty<CalendarPlanWeek>();
    }
}