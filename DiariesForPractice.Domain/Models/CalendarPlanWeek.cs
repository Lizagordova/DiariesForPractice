using System;

namespace DiariesForPractice.Domain.Models
{
    public class CalendarPlanWeek
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string NameOfTheWork { get; set; }
        public int Mark { get; set; }
        public string StructuralDivision { get; set; }
        public int Order { get; set; }
    }
}