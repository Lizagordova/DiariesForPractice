using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Models.Data;
using DiariesForPractice.Domain.Services.Diaries;
using DiariesForPractice.Domain.Services.InstituteDetails;
using DiariesForPractice.Domain.Services.PracticeDetail;
using DiariesForPractice.Domain.Services.StudentCharacteristics;
using DiariesForPractice.Domain.Services.StudentTasks;

namespace DiariesForPractice.DiaryGenerator.Services
{
    public class StudentPracticeDataService
    {
        private readonly IInstituteDetailsReaderService _instituteDetailsReader;
        private readonly IPracticeReaderService _practiceReader;
        private readonly IStudentCharacteristicsReader _studentCharacteristicsReader;
        private readonly IStudentTaskReaderService _studentTaskReader;
        private readonly IDiariesReaderService _diariesReader;
        
        private readonly string _comment = "";

        public StudentPracticeDataService(
            IInstituteDetailsReaderService instituteDetailsReader,
            IPracticeReaderService practiceReader,
            IStudentCharacteristicsReader studentCharacteristicsReader,
            IStudentTaskReaderService studentTaskReader,
            IDiariesReaderService diariesReader
            )
        {
            _instituteDetailsReader = instituteDetailsReader;
            _practiceReader = practiceReader;
            _studentTaskReader = studentTaskReader;
            _studentCharacteristicsReader = studentCharacteristicsReader;
            _diariesReader = diariesReader;
        }
        
        public PracticeData GetPracticeDataForStudent(User student, Group group)
        {
            var practiceData = new PracticeData();
            practiceData.Student = student;
            practiceData.PracticeDetails = GetPracticeDetailsForStudent(student);
            practiceData.Group = group;
            var direction = GetDirection(group.DirectionId);
            practiceData.Direction = direction;
            var cafedra = GetCafedra(direction.CafedraId);
            practiceData.Cafedra = cafedra;
            practiceData.Institute = GetInstitute(cafedra.InstituteId);
            practiceData.Course = GetCourse(group.CourseId);
            practiceData.StudentCharacteristic = GetStudentCharacteristic(student.Id);
            practiceData.StudentTask = GetStudentTask(student.Id);
            practiceData.Comment = _comment;
            practiceData.Order = GetOrder();
            practiceData.Diary = GetDiary(student.Id);

            return practiceData;
        }

        private PracticeDetails GetPracticeDetailsForStudent(User student)
        {
            //todo: здесь можно добавлять какие-то данные в комментарий
            return _practiceReader.GetPracticeDetails(student.Id);
        }

        private Institute GetInstitute(int instituteId)
        {
            return _instituteDetailsReader.GetInstitute(instituteId);
        }
        
        private Cafedra GetCafedra(int cafedraId)
        {
            return _instituteDetailsReader.GetCafedra(cafedraId);
        }
        
        private Course GetCourse(int courseId)
        {
            return _instituteDetailsReader.GetCourse(courseId);
        }
        
        private Direction GetDirection(int directionId)
        {
            return _instituteDetailsReader.GetDirection(directionId);
        }

        private StudentCharacteristic GetStudentCharacteristic(int studentId)
        {
            var studentCharacteristic = _studentCharacteristicsReader.GetStudentCharacteristic(studentId) ?? new StudentCharacteristic { StudentId = studentId };

            return studentCharacteristic;
        }
        
        private StudentTask GetStudentTask(int studentId)
        {
            var studentTask = _studentTaskReader.GetStudentTask(studentId) ??
                new StudentTask
                {
                    StudentId = studentId
                };
            
            return studentTask;
        }

        private Order GetOrder()
        {
            return new Order();
        }

        private Diary GetDiary(int studentId)
        {
            var diary = _diariesReader.GetDiary(studentId) ?? new Diary()
            {
                Student = new User { Id = studentId }
            };
            diary.Signatures = GetSignatures();

            return diary;
        }
        
        private Signatures GetSignatures()
        {
            return new Signatures();
        }
    }
}