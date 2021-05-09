using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
    [ApiReadModel]
    public class PracticeReadModel
    {
        public int Id { get; set; }
        public UserReadModel Student { get; set; }
        public OrganizationReadModel Organization { get; set; }
        public string ReportingForm { get; set; }
        public string ContractNumber { get; set; }
        public StaffReadModel ResponsibleForStudent { get; set; }
        public StaffReadModel SignsTheContract { get; set; }
    }
}