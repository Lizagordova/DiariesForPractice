using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.ReadModels;
using DiariesForPractice.ViewModels;

namespace DiariesForPractice.Services.Mapper
{
	public partial class MapperService : MapperServiceBase
	{
		private void CreateInstituteDetailsMappings()
		{
			AddMapping<InstituteReadModel, Institute>(cfg =>
			{
				cfg.CreateMap<InstituteReadModel, Institute>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
					.ForMember(dest => dest.Cafedras, opt => opt.Ignore());
			});

			AddMapping<Institute, InstituteViewModel>(cfg =>
			{
				cfg.CreateMap<Institute, InstituteViewModel>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
					.ForMember(dest => dest.Cafedras, opt => opt.Ignore());
			});

			AddMapping<CafedraReadModel, Cafedra>(cfg =>
			{
				cfg.CreateMap<CafedraReadModel, Cafedra>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.InstituteId, opt => opt.MapFrom(src => src.InstituteId))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
					.ForMember(dest => dest.Directions, opt => opt.Ignore());
			});

			AddMapping<Cafedra, CafedraViewModel>(cfg =>
			{
				cfg.CreateMap<Cafedra, CafedraViewModel>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
					.ForMember(dest => dest.InstituteId, opt => opt.MapFrom(src => src.InstituteId))
					.ForMember(dest => dest.Directions, opt => opt.Ignore());
			});

			AddMapping<DirectionReadModel, Direction>(cfg =>
			{
				cfg.CreateMap<DirectionReadModel, Direction>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.CafedraId, opt => opt.MapFrom(src => src.CafedraId))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
					.ForMember(dest => dest.Groups, opt => opt.Ignore());
			});

			AddMapping<Direction, DirectionViewModel>(cfg =>
			{
				cfg.CreateMap<Direction, DirectionViewModel>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.Groups, opt => opt.Ignore())
					.ForMember(dest => dest.CafedraId, opt => opt.MapFrom(src => src.CafedraId))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
			});

			AddMapping<GroupReadModel, Group>(cfg =>
			{
				cfg.CreateMap<GroupReadModel, Group>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
					.ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
					.ForMember(dest => dest.DirectionId, opt => opt.MapFrom(src => src.DirectionId));
			});

			AddMapping<Group, GroupViewModel>(cfg =>
			{
				cfg.CreateMap<Group, GroupViewModel>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
					.ForMember(dest => dest.DirectionId, opt => opt.MapFrom(src => src.DirectionId))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
					.ForMember(dest => dest.Responsible, opt => opt.Ignore())
					.ForMember(dest => dest.Students, opt => opt.Ignore())
					.ForMember(dest => dest.GroupDetails, opt => opt.Ignore());
			});

			AddMapping<CourseReadModel, Course>(cfg =>
			{
				cfg.CreateMap<CourseReadModel, Course>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
			});

			AddMapping<Course, CourseViewModel>(cfg =>
			{
				cfg.CreateMap<Course, CourseViewModel>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
			});

			AddMapping<DegreeReadModel, Degree>(cfg =>
			{
				cfg.CreateMap<DegreeReadModel, Degree>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
					.ForMember(dest => dest.Courses, opt => opt.Ignore());
			});

			AddMapping<Degree, DegreeViewModel>(cfg =>
			{
				cfg.CreateMap<Degree, DegreeViewModel>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
					.ForMember(dest => dest.Courses, opt => opt.Ignore());
			});
		}
	}
}