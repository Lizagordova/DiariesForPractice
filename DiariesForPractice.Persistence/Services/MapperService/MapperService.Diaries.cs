using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.Services.MapperService
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreateDiariesMappings()
        {
            AddMapping<DiaryUdt, Diary>(cfg =>
            {
                cfg.CreateMap<DiaryUdt, Diary>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Student, opt => opt.MapFrom(src => new User() {Id = src.StudentId}))
                    .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path))
                    .ForMember(dest => dest.Generated, opt => opt.MapFrom(src => src.Generated))
                    .ForMember(dest => dest.Send, opt => opt.MapFrom(src => src.Send))
                    .ForMember(dest => dest.Perceived, opt => opt.MapFrom(src => src.Perceived))
                    .ForMember(dest => dest.Approved, opt => opt.MapFrom(src => src.Approved))
                    .ForMember(dest => dest.SendDate, opt => opt.MapFrom(src => src.SendDate))
                    .ForMember(dest => dest.GeneratedDate, opt => opt.MapFrom(src => src.GeneratedDate))
                    .ForMember(dest => dest.Completion, opt => opt.MapFrom(src => src.Completion))
                    .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                    .ForMember(dest => dest.Signatures, opt => opt.Ignore());
            });
            
            AddMapping<Diary, DiaryUdt>(cfg =>
            {
                cfg.CreateMap<Diary, DiaryUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Student.Id ))
                    .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path))
                    .ForMember(dest => dest.Generated, opt => opt.MapFrom(src => src.Generated))
                    .ForMember(dest => dest.Send, opt => opt.MapFrom(src => src.Send))
                    .ForMember(dest => dest.Perceived, opt => opt.MapFrom(src => src.Perceived))
                    .ForMember(dest => dest.Approved, opt => opt.MapFrom(src => src.Approved))
                    .ForMember(dest => dest.SendDate, opt => opt.MapFrom(src => src.SendDate))
                    .ForMember(dest => dest.GeneratedDate, opt => opt.MapFrom(src => src.GeneratedDate))
                    .ForMember(dest => dest.Completion, opt => opt.MapFrom(src => src.Completion))
                    .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));
            });
        }
    }
}