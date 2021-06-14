using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO.Data;
using DiariesForPractice.Persistence.DTO.UDT;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;
using DiariesForPractice.Persistence.Services.MapperService;

namespace DiariesForPractice.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private const string GetUserNotificationsSp = "NotificationRepository_GetUserNotifications";
        private const string AddOrUpdateNotificationSp = "NotificationRepository_AddOrUpdateNotification";
        private const string AddOrUpdateUserNotificationSp = "NotificationRepository_AddOrUpdateUserNotification";

        private readonly MapperService _mapper;
        
        public NotificationRepository(
            MapperService mapper)
        {
            _mapper = mapper;
        }
        
        public IReadOnlyCollection<UserNotification> GetUserNotifications(NotificationQuery query)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = GetUserNotificationsParam(query);
            var reader = conn
                .QueryMultiple(GetUserNotificationsSp, param, commandType: CommandType.StoredProcedure);
            var data = GetUserNotificationData(reader);
            var userNotifications = MapUserNotifications(data);
            DatabaseHelper.CloseConnection(conn);

            return userNotifications;
        }

        public int AddOrUpdateNotification(Notification notification)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = GetNotificationParam(notification);
            var notificationId = conn
                .Query<int>(AddOrUpdateNotificationSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return notificationId;
        }

        public int AddOrUpdateUserNotification(UserNotification userNotification)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = GetUserNotificationParam(userNotification);
            var userNotificationId = conn
                .Query<int>(AddOrUpdateUserNotificationSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return userNotificationId;
        }
        
        private UserNotificationData GetUserNotificationData(SqlMapper.GridReader reader)
        {
            var userNotificationData = new UserNotificationData()
            {
                UserNotifications = reader.Read<UserNotificationUdt>().ToList(),
                Notifications = reader.Read<NotificationUdt>().ToList()
            };

            return userNotificationData;
        }

        private IReadOnlyCollection<UserNotification> MapUserNotifications(UserNotificationData data)
        {
            var userNotifications = data.UserNotifications
                .Join(data.Notifications,
                    un => un.NotificationId,
                    n => n.Id,
                    MapUserNotification)
                .ToList();

            return userNotifications;
        }

        private DynamicTvpParameters GetUserNotificationsParam(NotificationQuery query)
        {
            var param = new DynamicTvpParameters();
            param.Add("userForId", query.UserForId);
            param.Add("watched", query.Watched);
            
            return param;
        }

        private DynamicTvpParameters GetUserNotificationParam(UserNotification userNotification)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("userNotification", "UDT_User_Notification");
            var udt = _mapper.Map<UserNotification, UserNotificationUdt>(userNotification);
            tvp.AddObjectAsRow(udt);
            param.Add(tvp);
            
            return param;
        }
        
        private DynamicTvpParameters GetNotificationParam(Notification notification)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("notification", "UDT_Notification");
            var udt = _mapper.Map<Notification, NotificationUdt>(notification);
            tvp.AddObjectAsRow(udt);
            param.Add(tvp);

            return param;
        }
        
        private UserNotification MapUserNotification(UserNotificationUdt userNotificationUdt, NotificationUdt notificationUdt)
        {
            var userNotification = _mapper.Map<UserNotificationUdt, UserNotification>(userNotificationUdt);
            userNotification.Notification = _mapper.Map<NotificationUdt, Notification>(notificationUdt);

            return userNotification;
        }
    }
}