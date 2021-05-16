using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;

namespace DiariesForPractice.Domain.Repositories
{
    public interface INotificationRepository
    {
        IReadOnlyCollection<UserNotification> GetUserNotifications(NotificationQuery query);
        int AddOrUpdateNotification(Notification notification);
        int AddOrUpdateUserNotification(UserNotification userNotification);
    }
}