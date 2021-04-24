using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services;
using DiariesForPractice.ReadModels;
using DiariesForPractice.ViewModels;

namespace DiariesForPractice.Services.Mapper
{
	public partial class MapperService : MapperServiceBase
	{
		private void CreateGoogleDetailsMappings()
		{
			AddMapping<GoogleDetails, GoogleDetailsViewModel>(cfg =>
			{
				cfg.CreateMap<GoogleDetails, GoogleDetailsViewModel>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
					.ForMember(dest => dest.SpreadSheetId, opt => opt.MapFrom(src => src.SpreadSheetId))
					.ForMember(dest => dest.SheetName, opt => opt.MapFrom(src => src.SheetName))
					.ForMember(dest => dest.FirstCell, opt => opt.MapFrom(src => src.FirstCell))
					.ForMember(dest => dest.LastCell, opt => opt.MapFrom(src => src.LastCell));
			});

			AddMapping<GoogleDetailsReadModel, GoogleDetails>(cfg =>
			{
				cfg.CreateMap<GoogleDetailsReadModel, GoogleDetails>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
					.ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
					.ForMember(dest => dest.SpreadSheetId, opt => opt.MapFrom(src => src.SpreadSheetId))
					.ForMember(dest => dest.SheetName, opt => opt.MapFrom(src => src.SheetName))
					.ForMember(dest => dest.FirstCell, opt => opt.MapFrom(src => src.FirstCell))
					.ForMember(dest => dest.LastCell, opt => opt.MapFrom(src => src.LastCell));
			});
		}
	}
}