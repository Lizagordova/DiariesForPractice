using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.Persistence.DTO;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.Services.MapperService
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreateStudentTasksMappings()
        {
            AddMapping<StudentTaskUdt, StudentTask>(cfg =>
            {
                cfg.CreateMap<StudentTaskUdt, StudentTask>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                    .ForMember(dest => dest.Task, opt => opt.MapFrom(src => src.Task));
            });
            
            AddMapping<StudentTask, StudentTaskUdt>(cfg =>
            {
                cfg.CreateMap<StudentTask, StudentTaskUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                    .ForMember(dest => dest.Task, opt => opt.MapFrom(src => src.Task));
            });
        }
    }
}