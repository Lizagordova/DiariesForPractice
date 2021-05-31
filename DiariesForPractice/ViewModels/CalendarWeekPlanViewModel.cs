using System;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class CalendarWeekPlanViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string NameOfTheWork { get; set; }
        public string StructuralDivision { get; set; }
        public int Order { get; set; }
    }
}