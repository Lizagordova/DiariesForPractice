using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;

namespace DiariesForPractice.Domain.Services.GoogleDetail
{
	public interface IGoogleDetailsReaderService
	{
		IReadOnlyCollection<GoogleDetails> GetGoogleDetails(GoogleDetailsQuery query);
	}
}