using System;
using DiariesForPractice.Configuration.Typings.Attributes;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class PracticeViewModel
    {
        public int Id { get; set; }
        public UserViewModel Student { get; set; } = new UserViewModel();
        public OrganizationViewModel Organization { get; set; } = new OrganizationViewModel();
        public ReportingForm ReportingForm { get; set; }
        public string ContractNumber { get; set; }
        public StaffViewModel ResponsibleForStudent { get; set; } = new StaffViewModel();
        public StaffViewModel SignsTheContract { get; set; } = new StaffViewModel();
        public PracticeType PracticeType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StructuralDivision { get; set; }
        public CalendarPlanViewModel CalendarPlan { get; set; } = new CalendarPlanViewModel();
        public StudentTaskViewModel StudentTask { get; set; } = new StudentTaskViewModel();

        public StudentCharacteristicViewModel StudentCharacteristic { get; set; } = new StudentCharacteristicViewModel();
    }
}