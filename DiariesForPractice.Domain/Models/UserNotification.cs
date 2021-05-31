using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.Domain.Models
{
    public class UserNotification
    {
        public int Id { get; set; }
        public Notification Notification { get; set; }
        public User UserFor { get; set; }
        public bool Watched { get; set; }
        public AnswerType Answer { get; set; }
    }
}