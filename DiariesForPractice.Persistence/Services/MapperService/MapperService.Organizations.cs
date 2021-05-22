using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.Services.MapperService
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreateOrganizationMappings()
        {
            AddMapping<Organization, OrganizationUdt>(cfg =>
            {
                cfg.CreateMap<Organization, OrganizationUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.LegalAddress, opt => opt.MapFrom(src => src.LegalAddress));
            });

            AddMapping<OrganizationUdt, Organization>(cfg =>
            {
                cfg.CreateMap<OrganizationUdt, Organization>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.LegalAddress, opt => opt.MapFrom(src => src.LegalAddress));
            });
            
            AddMapping<StaffUdt, Staff>(cfg =>
            {
                cfg.CreateMap<StaffUdt, Staff>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job))
                    .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            });
            
            AddMapping<Staff, StaffUdt>(cfg =>
            {
                cfg.CreateMap<Staff, StaffUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.Job, opt => opt.MapFrom(src => src.Job))
                    .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            });
        }
    }
}