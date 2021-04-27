using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.GoogleDetail
{
	public interface IGoogleDetailsEditorService
	{
		int AddOrUpdateGoogleDetails(GoogleDetails googleDetails);
	}
}