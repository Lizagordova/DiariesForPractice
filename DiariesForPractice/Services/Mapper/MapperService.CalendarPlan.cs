using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.ReadModels;
using DiariesForPractice.ViewModels;

namespace DiariesForPractice.Services.Mapper
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreateCalendarPlanMappings()
        {
            AddMapping<CalendarPlanReadModel, CalendarPlan>(cfg =>
            {
                cfg.CreateMap<CalendarPlanReadModel, CalendarPlan>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CalendarPlanWeeks, opt => opt.Ignore());//TODO: выяснить, как здесь можно мапить коллекцию
            });
            
            AddMapping<CalendarPlan, CalendarPlanViewModel>(cfg =>
            {
                cfg.CreateMap<CalendarPlan, CalendarPlanViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CalendarWeekPlans, opt => opt.Ignore());;//TODO: выяснить, как здесь можно мапить коллекцию
            });
            
            AddMapping<CalendarWeekPlanReadModel, CalendarPlanWeek>(cfg =>
            {
                cfg.CreateMap<CalendarWeekPlanReadModel, CalendarPlanWeek>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                    .ForMember(dest => dest.NameOfTheWork, opt => opt.MapFrom(src => src.NameOfTheWork))
                    .ForMember(dest => dest.StructuralDivision, opt => opt.MapFrom(src => src.StructuralDivision))
                    .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));
            });
            
            AddMapping<CalendarPlanWeek, CalendarWeekPlanViewModel>(cfg =>
            {
                cfg.CreateMap<CalendarPlanWeek, CalendarWeekPlanViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                    .ForMember(dest => dest.NameOfTheWork, opt => opt.MapFrom(src => src.NameOfTheWork))
                    .ForMember(dest => dest.StructuralDivision, opt => opt.MapFrom(src => src.StructuralDivision))
                    .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));
            });
        }
    }
}