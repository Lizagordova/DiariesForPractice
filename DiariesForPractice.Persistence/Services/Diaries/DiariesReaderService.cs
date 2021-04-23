using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Diaries;

namespace DiariesForPractice.Persistence.Services.Diaries
{
	public class DiariesReaderService : IDiariesReaderService
	{
		private readonly IDiariesRepository _diariesRepository;

		public DiariesReaderService(
			IDiariesRepository diariesRepository)
		{
			_diariesRepository = diariesRepository;
		}

		public IReadOnlyCollection<Diary> GetDiaries()
		{
			var diaries = _diariesRepository.GetDiaries();

			return diaries;
		}
	}
}