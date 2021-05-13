using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class GroupDetailsViewModel
    {
        public int NumberStudentsShouldBe { get; set; }
        public int NumberRegisteredStudents { get; set; }
    }
}