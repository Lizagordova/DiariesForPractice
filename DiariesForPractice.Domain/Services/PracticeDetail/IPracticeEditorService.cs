using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.PracticeDetail
{
	public interface IPracticeEditorService
	{
		int AddOrUpdatePracticeDetails(PracticeDetails practiceDetails);
	}
}