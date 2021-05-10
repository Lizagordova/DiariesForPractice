using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class StudentTaskViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Task { get; set; }
    }
}