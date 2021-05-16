using System;
using System.Linq;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Services.Notifications;
using DiariesForPractice.ReadModels.Queries;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
using DiariesForPractice.ViewModels;
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
        private readonly LogService _logService;
        
        public NotificationController(
            INotificationEditorService notificationEditor,
            INotificationReaderService notificationReader,
            MapperService mapper,
            ILogger<NotificationController> logger,
            LogService logService)
        {
            _notificationEditor = notificationEditor;
            _notificationReader = notificationReader;
            _mapper = mapper;
            _logger = logger;
            _logService = logService;
        }

        [HttpPost]
        [Route("/getusernotifications")]
        public ActionResult GetUserNotifications([FromBody]NotificationQueryReadModel queryReadModel)
        {
            try
            {
                var query = _mapper.Map<NotificationQueryReadModel, NotificationQuery>(queryReadModel);
                var userNotifications = _notificationReader.GetUserNotifications(query);
                var userNotificationViewModels = userNotifications
                    .Select(_mapper.Map<UserNotification, UserNotificationViewModel>)
                    .ToList();

                return new JsonResult(userNotificationViewModels);
            }
            catch (Exception e)
            {
                _logService.AddGetUserNotificationsLog(_logger, e, LogType.Base, queryReadModel.UserForId.Value);
                
                return new StatusCodeResult(500);
            }
        }
    }
}