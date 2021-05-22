namespace DiariesForPractice.Domain.Models
{
    public class GroupDetails
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int NumberStudentsShouldBe { get; set; }
        public int NumberRegisteredStudents { get; set; }
    }
}