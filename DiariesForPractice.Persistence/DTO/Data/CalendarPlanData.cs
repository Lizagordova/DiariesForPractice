using System;
using System.Collections.Generic;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.DTO.Data
{
    public class CalendarPlanData
    {
        public int CalendarPlanId { get; set; }

        public IReadOnlyCollection<CalendarWeekPlanUdt> CalendarPlanWeeks { get; set; } =
            Array.Empty<CalendarWeekPlanUdt>();
    }
}