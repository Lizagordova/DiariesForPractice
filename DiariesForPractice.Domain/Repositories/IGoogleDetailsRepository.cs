using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;

namespace DiariesForPractice.Domain.Repositories
{
	public interface IGoogleDetailsRepository
	{
		int AddOrUpdateGoogleDetails(GoogleDetails googleDetails);
		IReadOnlyCollection<GoogleDetails> GetGoogleDetails(GoogleDetailsQuery query);
	}
}