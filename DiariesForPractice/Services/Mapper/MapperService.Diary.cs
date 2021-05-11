using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.ReadModels;
using DiariesForPractice.ViewModels;

namespace DiariesForPractice.Services.Mapper
{
	public partial class MapperService : MapperServiceBase
	{
		private void CreateDiaryMappings()
		{
			AddMapping<DiaryReadModel, Diary>(cfg =>
			{
				cfg.CreateMap<DiaryReadModel, Diary>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.Student, opt => opt.MapFrom(src => new User() { Id = src.Id }))
					.ForMember(dest => dest.Send, opt => opt.MapFrom(src => src.Send))
					.ForMember(dest => dest.Generated, opt => opt.MapFrom(src => src.Generated))
					.ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path))
					.ForMember(dest => dest.PerceivedDate, opt => opt.MapFrom(src => src.PerceivedDate))
					.ForMember(dest => dest.SendDate, opt => opt.MapFrom(src => src.SendDate))
					.ForMember(dest => dest.GeneratedDate, opt => opt.MapFrom(src => src.GeneratedDate))
					.ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));
			});

			AddMapping<Diary, DiaryViewModel>(cfg =>
			{
				cfg.CreateMap<Diary, DiaryViewModel>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Student.Id))
					.ForMember(dest => dest.Send, opt => opt.MapFrom(src => src.Send))
					.ForMember(dest => dest.Generated, opt => opt.MapFrom(src => src.Generated))
					.ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path))
					.ForMember(dest => dest.GeneratedDate, opt => opt.MapFrom(src => src.GeneratedDate))
					.ForMember(dest => dest.SendDate, opt => opt.MapFrom(src => src.SendDate))
					.ForMember(dest => dest.PerceivedDate, opt => opt.MapFrom(src => src.PerceivedDate))
					.ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));
			});
		}
	}
}