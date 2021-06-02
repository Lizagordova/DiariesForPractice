using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.Services.MapperService
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreateNotificationMappings()
        {
            AddMapping<NotificationUdt, Notification>(cfg =>
            {
                cfg.CreateMap<NotificationUdt, Notification>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));
            });

            AddMapping<Notification, NotificationUdt>(cfg =>
            {
                cfg.CreateMap<Notification, NotificationUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));
            });

            AddMapping<UserNotificationUdt, UserNotification>(cfg =>
            {
                cfg.CreateMap<UserNotificationUdt, UserNotification>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Notification, opt => opt.Ignore())
                    .ForMember(dest => dest.UserFor, opt => opt.Ignore())
                    .ForMember(dest => dest.Watched, opt => opt.MapFrom(src => src.Watched));
            });

            AddMapping<UserNotification, UserNotificationUdt>(cfg =>
            {
                cfg.CreateMap<UserNotification, UserNotificationUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.NotificationId, opt => opt.MapFrom(src => src.Notification.Id))
                    .ForMember(dest => dest.UserFor, opt => opt.Ignore())
                    .ForMember(dest => dest.Watched, opt => opt.MapFrom(src => src.Watched));
            });

        }
    }
}