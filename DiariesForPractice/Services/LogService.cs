using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
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

        public void GetDiaryLog(ILogger logger, Exception exception, LogType logType, int studentId)
        {
            var customMessage = $"Не удалось получить дневник для студента {studentId}";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateDiaryLog(ILogger logger, Exception exception, LogType logType, int diaryId)
        {
            var customMessage = $"Не удалось обновить дневник с diaryId={diaryId}";
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
        
        public void AddOrUpdateStudentCharacteristicsLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = $"Не удалось обновить характеристику пользователя";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void GetStudentCharacteristicsLog(ILogger logger, Exception exception, LogType logType, int studentId)
        {
            var customMessage = $"Не удалось получить характеристику для студента {studentId}";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddGetUserNotificationsLog(ILogger logger, Exception exception, LogType logType, int userId)
        {
            var customMessage = $"Не удалось получить уведомления для пользователя userId={userId}";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateNotificationLog(ILogger logger, Exception exception, LogType logType, int notificationId)
        {
            var customMessage = $"Не удалось добавить или удалить уведомление";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateOrganizationLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = $"Не удалось добавить или обновить организацию ";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateStaffLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = $"Не удалось добавить или обновить сотрудника";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void GetPracticeDetailsLog(ILogger logger, Exception exception, LogType logType, PracticeDetailsQuery query)
        {
            var customMessage = $"Не удалось получить данные о практике для studentId={query.StudentId} или groupId={query.GroupId}";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdatePracticeDetailsLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = $"Не удалось добавить или обновить данные по практике";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateCalendarPlanLog(ILogger logger, Exception exception, LogType logType, int practiceDetailsId)
        {
            var customMessage = $"Не удалось добавить или обновить календарный план для practiceDetailsId={practiceDetailsId}";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateCommentLog(ILogger logger, Exception exception, LogType logType, int userId, int commmentId, int groupId)
        {
            var customMessage = $"Пользователь с id={userId} не смог добавить комментарий с id={commmentId} в группе с id={groupId}";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateCommentGroup(ILogger logger, Exception exception, LogType logType, CommentGroup commentGroup)
        {
            var customMessage = $"Не удалось добавить или обновить группу комментариев id={commentGroup.Id}, userId={commentGroup.UserId}," +
                                $" commentedEntityId={commentGroup.CommentedEntityId}, " +
                                $"commentedEntityType={commentGroup.CommentedEntityType}";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void RemoveCommentLog(ILogger logger, Exception exception, LogType logType, int commentId)
        {
            var customMessage = $"Не удалось удалить комментарий id={commentId}";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void GetCommentGroupLog(ILogger logger, Exception exception, LogType logType, CommentGroup commentGroup)
        {
            var customMessage = $"Не удалось получить группу комментариев id={commentGroup.Id}, userId={commentGroup.UserId}," +
                                $" commentedEntityId={commentGroup.CommentedEntityId}, " +
                                $"commentedEntityType={commentGroup.CommentedEntityType}";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateInstituteLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = "Не удалось добавить институт";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateCafedraLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = "Не удалось добавить кафедру";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateDirectionLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = "Не удалось добавить направление";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateGroupLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = "Не удалось добавить группу";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateCourseLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = "Не удалось добавить курс";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void GetGroupLog(ILogger logger, Exception exception, LogType logType, int groupId)
        {
            var customMessage = $"Не удалось получить группу с id={groupId}";
            AddLog(logger, exception, customMessage, logType);
        }
        
        public void AddOrUpdateDegreeLog(ILogger logger, Exception exception, LogType logType)
        {
            var customMessage = "Не удалось добавить степень";
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