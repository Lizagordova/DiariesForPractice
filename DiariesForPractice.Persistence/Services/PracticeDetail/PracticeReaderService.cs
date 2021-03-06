using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.PracticeDetail;

namespace DiariesForPractice.Persistence.Services.PracticeDetail
{
	public class PracticeReaderService : IPracticeReaderService
	{
		private readonly IPracticeRepository _practiceRepository;
		public PracticeReaderService(
			IPracticeRepository practiceRepository)
		{
			_practiceRepository = practiceRepository;
		}

		public IReadOnlyCollection<PracticeDetails> GetPracticeDetails(PracticeDetailsQuery query)
		{
			var practiceDetails = _practiceRepository.GetPracticeDetails(query);

			return practiceDetails;
		}
	}
}