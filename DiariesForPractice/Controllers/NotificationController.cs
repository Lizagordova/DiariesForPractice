using DiariesForPractice.Domain.Services.Notifications;
using DiariesForPractice.Services.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationEditorService _notificationEditor;
        private readonly INotificationReaderService _notificationReader;
        private readonly MapperService _mapper;
        private readonly ILogger<NotificationController> _logger;
        public NotificationController(
            INotificationEditorService notificationEditor,
            INotificationReaderService notificationReader,
            MapperService mapper,
            ILogger<NotificationController> logger)
        {
            _notificationEditor = notificationEditor;
            _notificationReader = notificationReader;
            _mapper = mapper;
            _logger = logger;
        }
    }
}