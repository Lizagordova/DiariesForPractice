using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class UserNotificationViewModel
    {
        public int Id { get; set; }
        public NotificationViewModel Notification { get; set; }
        public UserViewModel UserFor { get; set; }
        public bool Watched { get; set; }
    }
}