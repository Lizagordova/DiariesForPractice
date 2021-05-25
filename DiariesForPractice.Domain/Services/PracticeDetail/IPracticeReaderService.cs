using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;

namespace DiariesForPractice.Domain.Services.PracticeDetail
{
	public interface IPracticeReaderService
	{
		IReadOnlyCollection<PracticeDetails> GetPracticeDetails(PracticeDetailsQuery query);
		PracticeDetails GetPracticeDetails(int studentId);
	}
}