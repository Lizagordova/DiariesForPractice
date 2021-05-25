using System.Collections.Generic;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;

namespace DiariesForPractice.Domain.Repositories
{
	public interface IPracticeRepository
	{
		int AddOrUpdatePracticeDetails(PracticeDetails practiceDetails);
		IReadOnlyCollection<PracticeDetails> GetPracticeDetails(PracticeDetailsQuery query);
		void AttachDataToPracticeDetails(int dataId, int practiceDetailsId, PracticeDetailsDataType type);
		PracticeDetails GetPracticeDetails(int studentId);
	}
}