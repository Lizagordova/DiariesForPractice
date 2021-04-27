using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Diaries;
using DiariesForPractice.Persistence.Generators;

namespace DiariesForPractice.Persistence.Services.Diaries
{
	public class DiariesEditorService : IDiariesEditorService
	{
		private readonly IDiariesRepository _diariesRepository;
		private readonly WordGenerator _wordGenerator;
		public DiariesEditorService(
			IDiariesRepository diariesRepository,
			WordGenerator wordGenerator)
		{
			_diariesRepository = diariesRepository;
			_wordGenerator = wordGenerator;
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
				StudentId = studentId,
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