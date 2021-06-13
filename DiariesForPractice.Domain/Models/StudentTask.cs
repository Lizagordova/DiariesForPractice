namespace DiariesForPractice.Domain.Models
{
    public class StudentTask
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Task { get; set; }
        public int Mark { get; set; }
    }
}