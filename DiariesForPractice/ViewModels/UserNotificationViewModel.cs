using DiariesForPractice.Configuration.Typings.Attributes;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class UserNotificationViewModel
    {
        public int Id { get; set; }
        public NotificationViewModel Notification { get; set; }
        public UserViewModel UserFor { get; set; }
        public bool Watched { get; set; }
        public AnswerType Answer { get; set; }
    }
}