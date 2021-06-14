using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.Services.MapperService
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreatePracticeDetailsMappings()
        {
            AddMapping<PracticeDetails, PracticeDetailsUdt>(cfg =>
            {
                cfg.CreateMap<PracticeDetails, PracticeDetailsUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Student.Id))
                    .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.Organization.Id))
                    .ForMember(dest => dest.ReportingForm, opt => opt.MapFrom(src => src.ReportingForm))
                    .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
                    .ForMember(dest => dest.ResponsibleForStudent, opt => opt.MapFrom(src => src.ResponsibleForStudent))
                    .ForMember(dest => dest.SignsTheContract, opt => opt.MapFrom(src => src.SignsTheContract))
                    .ForMember(dest => dest.PracticeType, opt => opt.MapFrom(src => src.PracticeType))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                    .ForMember(dest => dest.StructuralDivision, opt => opt.MapFrom(src => src.StructuralDivision))
                    .ForMember(dest => dest.OrderOfPassingPractice, opt => opt.MapFrom(src => src.OrderOfPassingPractice));
            });
            
            AddMapping<PracticeDetailsUdt, PracticeDetails>(cfg =>
            {
                cfg.CreateMap<PracticeDetailsUdt, PracticeDetails>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Student, opt => opt.MapFrom(src => new User() { Id = src.StudentId }))
                    .ForMember(dest => dest.Organization, opt => opt.MapFrom(src => new Organization() { Id = src.OrganizationId }))
                    .ForMember(dest => dest.ReportingForm, opt => opt.MapFrom(src => src.ReportingForm))
                    .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
                    .ForMember(dest => dest.ResponsibleForStudent, opt => opt.MapFrom(src => src.ResponsibleForStudent))
                    .ForMember(dest => dest.SignsTheContract, opt => opt.MapFrom(src => src.SignsTheContract))
                    .ForMember(dest => dest.PracticeType, opt => opt.MapFrom(src => src.PracticeType))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                    .ForMember(dest => dest.StructuralDivision, opt => opt.MapFrom(src => src.StructuralDivision))
                    .ForMember(dest => dest.OrderOfPassingPractice, opt => opt.MapFrom(src => src.OrderOfPassingPractice));
            });
            
            AddMapping<CalendarPlanUdt, CalendarPlan>(cfg =>
            {
                cfg.CreateMap<CalendarPlanUdt, CalendarPlan>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CalendarPlanWeeks, opt => opt.Ignore());
            });
            
            AddMapping<CalendarPlan, CalendarPlanUdt>(cfg =>
            {
                cfg.CreateMap<CalendarPlan, CalendarPlanUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.PracticeDetailsId, opt => opt.Ignore());
            });
            
            AddMapping<CalendarPlanWeek, CalendarWeekPlanUdt>(cfg =>
            {
                cfg.CreateMap<CalendarPlanWeek, CalendarWeekPlanUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                    .ForMember(dest => dest.NameOfTheWork, opt => opt.MapFrom(src => src.NameOfTheWork))
                    .ForMember(dest => dest.Mark, opt => opt.MapFrom(src => src.Mark))
                    .ForMember(dest => dest.StructuralDivision, opt => opt.MapFrom(src => src.StructuralDivision))
                    .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));
            });
            
            AddMapping<CalendarWeekPlanUdt, CalendarPlanWeek>(cfg =>
            {
                cfg.CreateMap<CalendarWeekPlanUdt, CalendarPlanWeek>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                    .ForMember(dest => dest.NameOfTheWork, opt => opt.MapFrom(src => src.NameOfTheWork))
                    .ForMember(dest => dest.Mark, opt => opt.MapFrom(src => src.Mark))
                    .ForMember(dest => dest.StructuralDivision, opt => opt.MapFrom(src => src.StructuralDivision))
                    .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));
            });
            
            AddMapping<OrderUdt, Order>(cfg =>
            {
                cfg.CreateMap<OrderUdt, Order>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                    .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate));
            });
            
            AddMapping<Order, OrderUdt>(cfg =>
            {
                cfg.CreateMap<Order, OrderUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                    .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate));
            });
        }
    }
}