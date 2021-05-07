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
        }
    }
}