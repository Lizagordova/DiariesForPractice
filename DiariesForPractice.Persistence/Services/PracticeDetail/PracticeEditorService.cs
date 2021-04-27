using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.PracticeDetail;

namespace DiariesForPractice.Persistence.Services.PracticeDetail
{
	public class PracticeEditorService : IPracticeEditorService
	{
		private readonly IPracticeRepository _practiceRepository;

		public PracticeEditorService(
			IPracticeRepository practiceRepository)
		{
			_practiceRepository = practiceRepository;
		}

		public int AddOrUpdatePracticeDetails(PracticeDetails practiceDetails)
		{
			var practiceDetaisId = _practiceRepository.AddOrUpdatePracticeDetails(practiceDetails);

			return practiceDetaisId;
		}
	}
}