using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.Domain.Models
{
    public class UserNotification
    {
        public int Id { get; set; }
        public Notification Notification { get; set; } = new Notification();
        public User UserFor { get; set; } = new User();
        public bool Watched { get; set; }
        public AnswerType Answer { get; set; } = AnswerType.None;
    }
}