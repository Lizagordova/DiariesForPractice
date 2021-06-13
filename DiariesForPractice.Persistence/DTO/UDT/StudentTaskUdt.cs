namespace DiariesForPractice.Persistence.DTO.UDT
{
    public class StudentTaskUdt
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Task { get; set; }
        public int Mark { get; set; }
    }
}