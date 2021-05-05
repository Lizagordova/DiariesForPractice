using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Services
{
    public class LogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(
            ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void AddAuthorizationLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = $"Не удалось авторизоваться";
            AddLog(logger, exception, customMessage, logType);
        }

        public void AddRegistrationLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = $"Не удалось зарегестрироваться";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddGetUserByIdLog(ILogger logger, Exception exception, LogType logType, int userId)
        {
            var customMessage = $"Не удалось получить пользователя по id={userId}";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void GetUsersLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = $"Не удалось получить пользователей";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateUserLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = $"Не удалось обновить пользователя";
            AddLog(logger, exception, customMessage, logType);
        }
        
        private void AddLog(ILogger logger, Exception e, string customMessage, LogType logType)
        {
            logger.Log(LogLevel.Error, $"{customMessage}. Error: {e.Message}");
            _logRepository.AddLog(new Log()
            {
                Message = e.Message, 
                CustomMessage = customMessage,
                LogLevel = LogLevel.Error,
                LogType = logType,
                Date = DateTime.Now
            });
        }
    }
}