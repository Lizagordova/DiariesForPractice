namespace DiariesForPractice.Persistence.DTO.UDT
{
    public class GroupDetailsUdt
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int NumberStudentsShouldBe { get; set; }
        public int NumberRegisteredStudents { get; set; }
    }
}