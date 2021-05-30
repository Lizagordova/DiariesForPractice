using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Diaries;

namespace DiariesForPractice.Persistence.Services.Diaries
{
	public class DiariesEditorService : IDiariesEditorService
	{
		private readonly IDiariesRepository _diariesRepository;
		public DiariesEditorService(
			IDiariesRepository diariesRepository)
		{
			_diariesRepository = diariesRepository;
		}

		public void GenerateDiaries(List<int> studentIds)
		{
			throw new System.NotImplementedException();
		}
		
		public int GenerateDiary(int studentId)
		{
			var diary = new Diary()
			{
				Path = "",
				Generated = false,
				Send = false,
				Student = new User() { Id = studentId },
				Comment = ""
			};
			var diaryId = _diariesRepository.AddOrUpdateDiary(diary);

			return diaryId;
		}
		
		public int AddOrUpdateDiary(Diary diary)
		{
			var diaryId = _diariesRepository.AddOrUpdateDiary(diary);

			return diaryId;
		}
	}
}