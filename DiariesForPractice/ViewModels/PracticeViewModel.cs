using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class PracticeViewModel
    {
        public int Id { get; set; }
        public UserViewModel Student { get; set; }
        public OrganizationViewModel Organization { get; set; }
        public string ReportingForm { get; set; }
        public string ContractNumber { get; set; }
        public StaffViewModel ResponsibleForStudent { get; set; }
        public StaffViewModel SignsTheContract { get; set; }
    }
}