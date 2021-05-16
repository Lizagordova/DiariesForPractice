using System.Collections.Generic;
using DiariesForPractice.Persistence.DTO.UDT;
using Google.Apis.Drive.v3;

namespace DiariesForPractice.Persistence.DTO.Data
{
    public class UserNotificationData
    {
        public IReadOnlyCollection<UserNotificationUdt> UserNotifications { get; set; }
        public IReadOnlyCollection<NotificationUdt> Notifications { get;set; }
    }
}