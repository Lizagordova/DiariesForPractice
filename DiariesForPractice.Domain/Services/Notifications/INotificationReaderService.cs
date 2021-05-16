using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;

namespace DiariesForPractice.Domain.Services.Notifications
{
    public interface INotificationReaderService
    {
        IReadOnlyCollection<UserNotification> GetUserNotifications(NotificationQuery query);
    }
}