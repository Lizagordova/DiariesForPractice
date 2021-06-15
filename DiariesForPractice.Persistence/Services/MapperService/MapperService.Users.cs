using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.Persistence.DTO.UDT;

namespace DiariesForPractice.Persistence.Services.MapperService
{
    public partial class MapperService : MapperServiceBase
    {
        private void CreateUsersMappings()
        {
            AddMapping<UserUdt, User>(cfg =>
            {
                cfg.CreateMap<UserUdt, User>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token))
                    .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => src.EmailConfirmed))
                    .ForMember(dest => dest.Role, opt => opt.Ignore());
            });
            
            AddMapping<User, UserUdt>(cfg =>
            {
                cfg.CreateMap<User, UserUdt>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token))
                    .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => src.EmailConfirmed));
            });
        }
    }
}