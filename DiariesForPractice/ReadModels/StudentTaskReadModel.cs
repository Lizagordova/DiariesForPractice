using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
    [ApiReadModel]
    public class StudentTaskReadModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Task { get; set; }
    }
}