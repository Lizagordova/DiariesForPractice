using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
    [ApiReadModel]
    public class UserNotificationReadModel
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int UserFor { get; set; }
        public bool Watched { get; set; }
    }
}