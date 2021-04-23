using System.Collections.Generic;
using Dapper;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.GoogleDetail;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;

namespace DiariesForPractice.Persistence.Services.GoogleDetail
{
	public class GoogleDetailsReaderService : IGoogleDetailsReaderService
	{
		private readonly IGoogleDetailsRepository _googleDetailsRepository;

		public GoogleDetailsReaderService(
			IGoogleDetailsRepository googleDetailsRepository)
		{
			_googleDetailsRepository = googleDetailsRepository;
		}

		public IReadOnlyCollection<GoogleDetails> GetGoogleDetails(GoogleDetailsQuery query)
		{
			var googleDetails = _googleDetailsRepository.GetGoogleDetails(query);

			return googleDetails;
		}
	}
}