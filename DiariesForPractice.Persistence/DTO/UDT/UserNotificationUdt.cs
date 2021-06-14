namespace DiariesForPractice.Persistence.DTO.UDT
{
    public class UserNotificationUdt
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int UserFor { get; set; }
        public bool Watched { get; set; }
        public int Answer { get; set; }
    }
}