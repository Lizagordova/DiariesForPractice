using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.ReadModels;
using DiariesForPractice.ViewModels;

namespace DiariesForPractice.Services.Mapper
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreateOrganizationMappings()
        {
            AddMapping<OrganizationReadModel, Organization>(cfg =>
            {
                cfg.CreateMap<OrganizationReadModel, Organization>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.LegalAddress, opt => opt.MapFrom(src => src.LegalAddress));
            });
            
            AddMapping<Organization, OrganizationViewModel>(cfg =>
            {
                cfg.CreateMap<Organization, OrganizationViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.LegalAddress, opt => opt.MapFrom(src => src.LegalAddress));
            });
            
            AddMapping<StaffReadModel, Staff>(cfg =>
            {
                cfg.CreateMap<StaffReadModel, Staff>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                    .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
            });
            
            AddMapping<Staff, StaffViewModel>(cfg =>
            {
                cfg.CreateMap<Staff, StaffViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                    .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
            });
        }
    }
}