using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.Services.MapperService
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreateStudentCharacteristicsMappings()
        {
            AddMapping<StudentCharacteristicUdt, StudentCharacteristic>(cfg =>
            {
                cfg.CreateMap<StudentCharacteristicUdt, StudentCharacteristic>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                    .ForMember(dest => dest.DescriptionByHead, opt => opt.MapFrom(src => src.DescriptionByHead))
                    .ForMember(dest => dest.DescriptionByCafedraHead, opt => opt.MapFrom(src => src.DescriptionByCafedraHead))
                    .ForMember(dest => dest.MissedDaysWithoutReason, opt => opt.MapFrom(src => src.MissedDaysWithoutReason))
                    .ForMember(dest => dest.MissedDaysWithReason, opt => opt.MapFrom(src => src.MissedDaysWithReason));
            });
            
            AddMapping<StudentCharacteristic, StudentCharacteristicUdt>(cfg =>
            {
                cfg.CreateMap<StudentCharacteristic, StudentCharacteristicUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                    .ForMember(dest => dest.DescriptionByHead, opt => opt.MapFrom(src => src.DescriptionByHead))
                    .ForMember(dest => dest.DescriptionByCafedraHead, opt => opt.MapFrom(src => src.DescriptionByCafedraHead))
                    .ForMember(dest => dest.MissedDaysWithoutReason, opt => opt.MapFrom(src => src.MissedDaysWithoutReason))
                    .ForMember(dest => dest.MissedDaysWithReason, opt => opt.MapFrom(src => src.MissedDaysWithReason));
            });
        }
    }
}