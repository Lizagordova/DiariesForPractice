using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
	public interface IDiariesRepository
	{
		int AddOrUpdateDiary(Diary diary);
		IReadOnlyCollection<Diary> GetDiaries();
	}
}