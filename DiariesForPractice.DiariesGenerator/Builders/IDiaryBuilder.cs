using DiariesForPractice.Domain.Models.Data;
using Syncfusion.DocIO.DLS;

namespace DiariesForPractice.DiariesGenerator.Builders
{
    public interface IDiaryBuilder
    {
        WordDocument BuildDiary(PracticeData practiceData);
    }
}