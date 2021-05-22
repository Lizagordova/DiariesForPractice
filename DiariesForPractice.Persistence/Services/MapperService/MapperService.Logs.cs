using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.Services.MapperService
{
     public partial class MapperService : MapperServiceBase
    {
        private void CreateLogMappings()
        {
            AddMapping<LogUdt, Log>(cfg =>
            {
                cfg.CreateMap<LogUdt, Log>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.CustomMessage, opt => opt.MapFrom(src => src.CustomMessage))
                    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                    .ForMember(dest => dest.LogType, opt => opt.MapFrom(src => src.LogType))
                    .ForMember(dest => dest.LogLevel, opt => opt.MapFrom(src => src.LogLevel));
            });
            
            AddMapping<Log, LogUdt>(cfg =>
            {
                cfg.CreateMap<Log, LogUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                    .ForMember(dest => dest.CustomMessage, opt => opt.MapFrom(src => src.CustomMessage))
                    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                    .ForMember(dest => dest.LogType, opt => opt.MapFrom(src => src.LogType))
                    .ForMember(dest => dest.LogLevel, opt => opt.MapFrom(src => src.LogLevel));
            });
        }
    }
}