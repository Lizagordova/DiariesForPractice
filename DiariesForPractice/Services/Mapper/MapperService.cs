using DiariesForPractice.Domain.Services;

namespace DiariesForPractice.Services.Mapper
{
	public partial class MapperService : MapperServiceBase
	{
		protected override void CreateMappings()
		{
			CreateGoogleDetailsMappings();
			CreateDiaryMappings();
		}
	}
}