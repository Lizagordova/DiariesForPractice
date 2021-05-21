using DiariesForPractice.Domain.Models.Data;
using Microsoft.Office.Interop.Word;

namespace DiariesForPractice.DiariesGenerator.Builders
{
    public interface IDiaryBuilder
    {
        Document BuildDiary(PracticeData practiceData);
    }
}