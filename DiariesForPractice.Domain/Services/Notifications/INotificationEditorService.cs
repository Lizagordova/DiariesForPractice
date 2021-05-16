using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Notifications
{
    public interface INotificationEditorService
    {
        int AddOrUpdateNotification(Notification notification);
        int AddOrUpdateUserNotification(UserNotification userNotification);
    }
}