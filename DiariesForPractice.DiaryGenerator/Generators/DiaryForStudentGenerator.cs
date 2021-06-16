using DiariesForPractice.DiariesGenerator.Builders;
using DiariesForPractice.DiaryGenerator.Builders;
using DiariesForPractice.Domain.Models.Data;
using DiariesForPractice.Domain.Services.Diaries;

namespace DiariesForPractice.DiaryGenerator.Generators
{
    public class DiaryForStudentGenerator
    {
        private readonly IDiaryBuilder _builder;
        private readonly IDiariesEditorService _diariesEditor;
        private readonly IDiariesReaderService _diariesReader;
        
        public DiaryForStudentGenerator(
            IDiaryBuilder builder,
            IDiariesEditorService diariesEditor,
            IDiariesReaderService diariesReader)
        {
            _builder = builder;
            _diariesEditor = diariesEditor;
            _diariesReader = diariesReader;
        }

        public void Generate(PracticeData practiceData)
        {
            var diaryDocument = _builder.BuildDiary(practiceData);
            AddOrUpdateDiary(practiceData);
        }

        private void AddOrUpdateDiary(PracticeData practiceData)
        {
            var diary = _diariesReader.GetDiary(practiceData.Student.Id);
            //todo: дополнить
            diary.Generated = true;
            _diariesEditor.AddOrUpdateDiary(diary);
        }
    }
}