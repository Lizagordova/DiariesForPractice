using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;

namespace DiariesForPractice.Domain.Services.Diaries
{
	public interface IDiariesReaderService
	{
		IReadOnlyCollection<Diary> GetDiaries(DiaryQuery query);
	}
}