using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class CalendarPlanViewModel
    { 
        public int Id { get; set; }
        public IReadOnlyCollection<CalendarWeekPlanViewModel> CalendarWeekPlans { get; set; } = Array.Empty<CalendarWeekPlanViewModel>();

    }
}