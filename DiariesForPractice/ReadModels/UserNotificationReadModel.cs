using DiariesForPractice.Configuration.Typings.Attributes;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.ReadModels
{
    [ApiReadModel]
    public class UserNotificationReadModel
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int UserFor { get; set; }
        public bool Watched { get; set; }
        public AnswerType Answer { get; set; }
    }
}