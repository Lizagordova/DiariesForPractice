using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class StudentCharacteristicViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string DescriptionByHead { get; set; }
        public string DescriptionByCafedraHead { get; set; }
        public int MissedDaysWithReason { get; set; }
        public int MissedDaysWithoutReason { get; set; }
    }
}