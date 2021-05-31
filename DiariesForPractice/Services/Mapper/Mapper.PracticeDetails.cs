using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.ReadModels;
using DiariesForPractice.ViewModels;

namespace DiariesForPractice.Services.Mapper
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreatePracticeMappings()
        {
            AddMapping<StudentCharacteristicReadModel, StudentCharacteristic>(cfg =>
            {
                cfg.CreateMap<StudentCharacteristicReadModel, StudentCharacteristic>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                    .ForMember(dest => dest.DescriptionByCafedraHead, opt => opt.MapFrom(src => src.DescriptionByCafedraHead))
                    .ForMember(dest => dest.DescriptionByHead, opt => opt.MapFrom(src => src.DescriptionByHead))
                    .ForMember(dest => dest.MissedDaysWithReason, opt => opt.MapFrom(src => src.MissedDaysWithReason))
                    .ForMember(dest => dest.MissedDaysWithoutReason, opt => opt.MapFrom(src => src.MissedDaysWithoutReason));
            });
            
            AddMapping<StudentCharacteristic, StudentCharacteristicViewModel>(cfg =>
            {
                cfg.CreateMap<StudentCharacteristic, StudentCharacteristicViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                    .ForMember(dest => dest.DescriptionByCafedraHead, opt => opt.MapFrom(src => src.DescriptionByCafedraHead))
                    .ForMember(dest => dest.DescriptionByHead, opt => opt.MapFrom(src => src.DescriptionByHead))
                    .ForMember(dest => dest.MissedDaysWithReason, opt => opt.MapFrom(src => src.MissedDaysWithReason))
                    .ForMember(dest => dest.MissedDaysWithoutReason, opt => opt.MapFrom(src => src.MissedDaysWithoutReason));
            });
            
            AddMapping<StudentTaskReadModel, StudentTask>(cfg =>
            {
                cfg.CreateMap<StudentTaskReadModel, StudentTask>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                    .ForMember(dest => dest.Task, opt => opt.MapFrom(src => src.Task));
            });
            
            AddMapping<StudentTask, StudentTaskViewModel>(cfg =>
            {
                cfg.CreateMap<StudentTask, StudentTaskViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                    .ForMember(dest => dest.Task, opt => opt.MapFrom(src => src.Task));
            });
        }
    }
}