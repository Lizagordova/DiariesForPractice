using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;

namespace DiariesForPractice.Domain.Repositories
{
	public interface IPracticeRepository
	{
		int AddOrUpdatePracticeDetails(PracticeDetails practiceDetails);
		IReadOnlyCollection<PracticeDetails> GetPracticeDetails(PracticeDetailsQuery query);
	}
}