using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Diaries
{
	public interface IDiariesEditorService
	{
		void GenerateDiaries(List<int> studentIds);
		int GenerateDiary(int studentId);
		int AddOrUpdateDiary(Diary diary);
	}
}