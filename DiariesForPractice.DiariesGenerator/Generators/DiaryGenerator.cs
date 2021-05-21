using DiariesForPractice.DiariesGenerator.Services;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services.InstituteDetails;

namespace DiariesForPractice.DiariesGenerator.Generators
{
    public class DiaryGenerator
    {
        private readonly IInstituteDetailsReaderService _instituteDetailsReader;
        private readonly StudentPracticeDataService _studentPracticeDataService;
        private readonly DiaryForStudentGenerator _diaryForStudentGenerator;
        
        public DiaryGenerator(
            IInstituteDetailsReaderService instituteDetailsReader,
            StudentPracticeDataService studentPracticeDataService,
            DiaryForStudentGenerator diaryForStudentGenerator)
        {
            _instituteDetailsReader = instituteDetailsReader;
            _studentPracticeDataService = studentPracticeDataService;
            _diaryForStudentGenerator = diaryForStudentGenerator;
        }

        public void GenerateDiaries()
        {
            var groups = _instituteDetailsReader.GetGroups();
            foreach (var group in groups)
            {
                GenerateDiariesForGroups(group);
            }
        }

        private void GenerateDiariesForGroups(Group group)
        {
            foreach (var student in group.Students)
            {
                GenerateDiaryForStudent(student, group);
            }
        }

        private void GenerateDiaryForStudent(User student, Group group)
        {
            var practiceData = _studentPracticeDataService.GetPracticeDataForStudent(student, group);
            _diaryForStudentGenerator.Generate(practiceData);
        }
    }
}