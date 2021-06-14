using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.Services.MapperService
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreateInstituteDetailsMappings()
        {
            AddMapping<InstituteUdt, Institute>(cfg =>
            {
                cfg.CreateMap<InstituteUdt, Institute>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Cafedras, opt => opt.Ignore());
            });
            
            AddMapping<Institute, InstituteUdt>(cfg =>
            {
                cfg.CreateMap<Institute, InstituteUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            });
            
            AddMapping<CafedraUdt, Cafedra>(cfg =>
            {
                cfg.CreateMap<CafedraUdt, Cafedra>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.InstituteId, opt => opt.MapFrom(src => src.InstituteId))
                    .ForMember(dest => dest.Directions, opt => opt.Ignore());
            });
            
            AddMapping<Cafedra, CafedraUdt>(cfg =>
            {
                cfg.CreateMap<Cafedra, CafedraUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.InstituteId, opt => opt.MapFrom(src => src.InstituteId));
            });
            
            AddMapping<DirectionUdt, Direction>(cfg =>
            {
                cfg.CreateMap<DirectionUdt, Direction>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.CafedraId, opt => opt.MapFrom(src => src.CafedraId))
                    .ForMember(dest => dest.Groups, opt => opt.Ignore());
            });
            
            AddMapping<Direction, DirectionUdt>(cfg =>
            {
                cfg.CreateMap<Direction, DirectionUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CafedraId, opt => opt.MapFrom(src => src.CafedraId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            });
            
            AddMapping<GroupUdt, Group>(cfg =>
            {
                cfg.CreateMap<GroupUdt, Group>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.DirectionId, opt => opt.MapFrom(src => src.DirectionId))
                    .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.GroupDetails, opt => opt.Ignore())
                    .ForMember(dest => dest.Students, opt => opt.Ignore());
            });
            
            
            AddMapping<Group, GroupUdt>(cfg =>
            {
                cfg.CreateMap<Group, GroupUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.DirectionId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            });
            
            AddMapping<Course, CourseUdt>(cfg =>
            {
                cfg.CreateMap<Course, CourseUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            });
            
            AddMapping<CourseUdt, Course>(cfg =>
            {
                cfg.CreateMap<CourseUdt, Course>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            });
            
            AddMapping<Course, CourseUdt>(cfg =>
            {
                cfg.CreateMap<Course, CourseUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.DegreeId, opt => opt.Ignore())
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            });
            
            AddMapping<Degree, DegreeUdt>(cfg =>
            {
                cfg.CreateMap<Degree, DegreeUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            });
            
            AddMapping<DegreeUdt, Degree>(cfg =>
            {
                cfg.CreateMap<DegreeUdt, Degree>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Courses, opt => opt.Ignore());
            });
            
            AddMapping<GroupDetails, GroupDetailsUdt>(cfg =>
            {
                cfg.CreateMap<GroupDetails, GroupDetailsUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                    .ForMember(dest => dest.NumberStudentsShouldBe, opt => opt.MapFrom(src => src.NumberStudentsShouldBe))
                    .ForMember(dest => dest.NumberRegisteredStudents, opt => opt.MapFrom(src => src.NumberRegisteredStudents));
            });
            
            AddMapping<GroupDetailsUdt, GroupDetails>(cfg =>
            {
                cfg.CreateMap<GroupDetailsUdt, GroupDetails>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                    .ForMember(dest => dest.NumberStudentsShouldBe, opt => opt.MapFrom(src => src.NumberStudentsShouldBe))
                    .ForMember(dest => dest.NumberRegisteredStudents, opt => opt.MapFrom(src => src.NumberRegisteredStudents));
            });

        }
    }
}