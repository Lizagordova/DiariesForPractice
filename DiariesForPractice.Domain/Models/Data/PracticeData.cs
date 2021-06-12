namespace DiariesForPractice.Domain.Models.Data
{
    public class PracticeData
    {
        public User Student { get; set; }
        public PracticeDetails PracticeDetails { get; set; }
        public Group Group { get; set; }
        public Institute Institute { get; set; }
        public Cafedra Cafedra { get; set; }
        public Direction Direction { get; set; }
        public Course Course { get; set; }
        public StudentCharacteristic StudentCharacteristic { get; set; }
        public StudentTask StudentTask { get; set; }
        public Order Order { get; set; }
        public string Comment { get; set; }
    }
}