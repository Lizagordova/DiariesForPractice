using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Diaries
{
	public interface IDiariesReaderService
	{
		IReadOnlyCollection<Diary> GetDiaries();
	}
}