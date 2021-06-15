using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.ReadModels;
using DiariesForPractice.ViewModels;

namespace DiariesForPractice.Services.Mapper
{
     public partial class MapperService : MapperServiceBase
    {
        private void CreateUserMappings()
        {
            AddMapping<UserReadModel, User>(cfg =>
            {
                cfg.CreateMap<UserReadModel, User>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token))
                    .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
            });
            
            AddMapping<User, UserViewModel>(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.SecondName, opt => opt.MapFrom(src => src.SecondName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token))
                    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
            });
        }
    }
}