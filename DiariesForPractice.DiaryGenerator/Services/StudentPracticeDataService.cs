using System.Linq;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Models.Data;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Services.InstituteDetails;
using DiariesForPractice.Domain.Services.PracticeDetail;
using DiariesForPractice.Domain.Services.StudentTasks;
using DiariesForPractice.Domain.StudentCharacteristics;

namespace DiariesForPractice.DiaryGenerator.Services
{
    public class StudentPracticeDataService
    {
        private readonly IInstituteDetailsReaderService _instituteDetailsReader;
        private readonly IPracticeReaderService _practiceReader;
        private readonly IStudentCharacteristicsReader _studentCharacteristicsReader;
        private readonly IStudentTaskReaderService _studentTaskReader;
        private readonly string _comment = "";

        public StudentPracticeDataService(
            IInstituteDetailsReaderService instituteDetailsReader,
            IPracticeReaderService practiceReader,
            IStudentCharacteristicsReader studentCharacteristicsReader,
            IStudentTaskReaderService studentTaskReader
            )
        {
            _instituteDetailsReader = instituteDetailsReader;
            _practiceReader = practiceReader;
            _studentTaskReader = studentTaskReader;
            _studentCharacteristicsReader = studentCharacteristicsReader;
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

            return practiceData;
        }

        private PracticeDetails GetPracticeDetailsForStudent(User student)
        {
            var query = new PracticeDetailsQuery()
            {
                StudentId = student.Id
            };
            //todo: здесь можно добавлять какие-то данные в комментарий
            return _practiceReader.GetPracticeDetails(query).FirstOrDefault();
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
           return _studentCharacteristicsReader.GetStudentCharacteristic(studentId);
        }
        
        private StudentTask GetStudentTask(int studentId)
        {
            return _studentTaskReader.GetStudentTask(studentId);
        }
    }
}