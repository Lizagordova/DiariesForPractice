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
            
            AddMapping<PracticeReadModel, PracticeDetails>(cfg =>
            {
                cfg.CreateMap<PracticeReadModel, PracticeDetails>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Student, opt => opt.Ignore())//todo: либо хелпер, либо узнать как это делается по человечески
                    .ForMember(dest => dest.Organization, opt => opt.Ignore())
                    .ForMember(dest => dest.ReportingForm, opt => opt.MapFrom(src => src.ReportingForm))
                    .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
                    .ForMember(dest => dest.ResponsibleForStudent, opt => opt.Ignore())
                    .ForMember(dest => dest.SignsTheContract, opt => opt.Ignore())
                    .ForMember(dest => dest.PracticeType, opt => opt.MapFrom(src => src.PracticeType))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                    .ForMember(dest => dest.StructuralDivision, opt => opt.MapFrom(src => src.StructuralDivision))
                    .ForMember(dest => dest.OrderOfPassingPractice, opt => opt.MapFrom(src => src.OrderOfPassingPractice))
                    .ForMember(dest => dest.CalendarPlan, opt => opt.Ignore())
                    .ForMember(dest => dest.StudentCharacteristic, opt => opt.Ignore());
            });
            
            AddMapping<PracticeDetails, PracticeViewModel>(cfg =>
            {
                cfg.CreateMap<PracticeDetails, PracticeViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Student, opt => opt.Ignore())//todo: либо хелпер, либо узнать как это делается по человечески
                    .ForMember(dest => dest.Organization, opt => opt.Ignore())
                    .ForMember(dest => dest.ReportingForm, opt => opt.MapFrom(src => src.ReportingForm))
                    .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
                    .ForMember(dest => dest.ResponsibleForStudent, opt => opt.Ignore())
                    .ForMember(dest => dest.SignsTheContract, opt => opt.Ignore())
                    .ForMember(dest => dest.PracticeType, opt => opt.MapFrom(src => src.PracticeType))
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                    .ForMember(dest => dest.StructuralDivision, opt => opt.MapFrom(src => src.StructuralDivision))
                    .ForMember(dest => dest.OrderOfPassingPractice, opt => opt.MapFrom(src => src.OrderOfPassingPractice))
                    .ForMember(dest => dest.CalendarPlan, opt => opt.Ignore())
                    .ForMember(dest => dest.StudentCharacteristic, opt => opt.Ignore());
            });
        }
    }
}