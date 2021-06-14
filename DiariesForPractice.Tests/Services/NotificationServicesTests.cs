using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.MapperService;
using DiariesForPractice.Persistence.Services.Notifications;
using NUnit.Framework;

namespace DiariesForPractice.Tests.Services
{
    [TestFixture]
    public class NotificationServicesTests
    {
        private readonly NotificationEditorService _notificationEditor;
        private readonly NotificationReaderService _notificationReader;
        
        public NotificationServicesTests()
        {
            var mapper = new MapperService();
            var notificationRepository = new NotificationRepository(mapper);
            _notificationEditor = new NotificationEditorService(notificationRepository);
            _notificationReader = new NotificationReaderService(notificationRepository);
        }
        
        [Test]
        public void AddOrUpdateNotification_Test()
        {
            var notification = new Notification()
            {
                Id = 1,
                Message = "Лиза, ложись спать",
                Date = DateTime.Now,
                Type = NotificationType.Info
            };
            var notificationId = _notificationEditor.AddOrUpdateNotification(notification);
            var result = notificationId != 0;
            Console.WriteLine($"notificationId={notificationId}");
            Assert.That(result == true);
        }
        
        [Test]
        public void AddOrUpdateUserNotification_Test()
        {
            var userNotification = new UserNotification()
            {
                Notification = new Notification() { Id = 1 },
                UserFor = new User() { Id = 1 },
                Watched = false,
                Answer = AnswerType.None
            };
            var userNotificationId = _notificationEditor.AddOrUpdateUserNotification(userNotification);
            var result = userNotificationId != 0;
            Console.WriteLine($"userNotificationId={userNotificationId}");
            Assert.That(result == true);
        }

    }
}