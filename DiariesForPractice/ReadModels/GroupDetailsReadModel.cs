using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
    [ApiReadModel]
    public class GroupDetailsReadModel
    {
        public int GroupId { get; set; }
        public int NumberStudentsShouldBe { get; set; }
        public int NumberRegisteredStudents { get; set; }
    }
}