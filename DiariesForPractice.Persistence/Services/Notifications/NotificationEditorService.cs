using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Notifications;

namespace DiariesForPractice.Persistence.Services.Notifications
{
    public class NotificationEditorService : INotificationEditorService
    {
        private readonly INotificationRepository _notificationRepository;
        
        public NotificationEditorService(
            INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        
        public int AddOrUpdateNotification(Notification notification)
        {
            var notificationId = _notificationRepository.AddOrUpdateNotification(notification);

            return notificationId;
        }

        public int AddOrUpdateUserNotification(UserNotification userNotification)
        {
            var userNotificationId = _notificationRepository.AddOrUpdateUserNotification(userNotification);

            return userNotificationId;
        }
    }
}