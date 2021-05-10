namespace DiariesForPractice.Domain.Models
{
    public class StudentCharacteristic
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string DescriptionByHead { get; set; }
        public string DescriptionByCafedraHead { get; set; }
        public int MissedDaysWithReason { get; set; }
        public int MissedDaysWithoutReason { get; set; }
    }
}