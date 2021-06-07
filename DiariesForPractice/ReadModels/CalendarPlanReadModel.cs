using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
    [ApiReadModel]
    public class CalendarPlanReadModel
    {
        public int Id { get; set; }
        public int PracticeDetailsId { get; set; }

        public IReadOnlyCollection<CalendarWeekPlanReadModel> CalendarWeekPlans { get; set; } = Array.Empty<CalendarWeekPlanReadModel>();
    }
}