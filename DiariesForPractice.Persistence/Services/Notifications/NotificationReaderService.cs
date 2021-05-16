using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Notifications;

namespace DiariesForPractice.Persistence.Services.Notifications
{
    public class NotificationReaderService : INotificationReaderService
    {
        private readonly INotificationRepository _notificationRepository;
        
        public NotificationReaderService(
            INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        
        public IReadOnlyCollection<UserNotification> GetUserNotifications(NotificationQuery query)
        {
            var userNotifications = _notificationRepository.GetUserNotifications(query);

            return userNotifications;
        }
    }
}