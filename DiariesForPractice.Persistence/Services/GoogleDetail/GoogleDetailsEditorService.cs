using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.GoogleDetail;

namespace DiariesForPractice.Persistence.Services.GoogleDetail
{
	public class GoogleDetailsEditorService : IGoogleDetailsEditorService
	{
		private readonly IGoogleDetailsRepository _googleDetailsRepository;
		public GoogleDetailsEditorService(
			IGoogleDetailsRepository googleDetailsRepository)
		{
			_googleDetailsRepository = googleDetailsRepository;
		}

		public int AddOrUpdateGoogleDetails(GoogleDetails googleDetails)
		{
			var googleDetailsId = _googleDetailsRepository.AddOrUpdateGoogleDetails(googleDetails);

			return googleDetailsId;
		}
	}
}