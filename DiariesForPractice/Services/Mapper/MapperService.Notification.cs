using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.ReadModels;
using DiariesForPractice.ViewModels;

namespace DiariesForPractice.Services.Mapper
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreateNotificationMappings()
        {
            AddMapping<NotificationReadModel, Notification>(cfg =>
            {
                cfg.CreateMap<NotificationReadModel, Notification>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));
            });
            
            AddMapping<Notification, NotificationViewModel>(cfg =>
            {
                cfg.CreateMap<Notification, NotificationViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));
            });
            
            AddMapping<UserNotificationReadModel, UserNotification>(cfg =>
            {
                cfg.CreateMap<UserNotificationReadModel, UserNotification>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Notification, opt => opt.MapFrom(src => new Notification(){ Id = src.Id}))
                    .ForMember(dest => dest.UserFor, opt => opt.MapFrom(src => src.UserFor))
                    .ForMember(dest => dest.Watched, opt => opt.MapFrom(src => src.Watched))
                    .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer));
            });
            
            AddMapping<UserNotification, UserNotificationViewModel>(cfg =>
            {
                cfg.CreateMap<UserNotification, UserNotificationViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Notification, opt => opt.MapFrom(src => new Notification(){ Id = src.Id}))
                    .ForMember(dest => dest.UserFor, opt => opt.MapFrom(src => src.UserFor))
                    .ForMember(dest => dest.Watched, opt => opt.MapFrom(src => src.Watched))
                    .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer));
            });
        }
    }
}