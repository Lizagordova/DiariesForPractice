using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.StudentCharacteristics;

namespace DiariesForPractice.Persistence.Services.StudentCharacteristics
{
    public class StudentCharacteristicsReader : IStudentCharacteristicsReader
    {
        private readonly IStudentCharacteristicRepository _studentCharacteristicRepository;

        private StudentCharacteristicsReader(
            IStudentCharacteristicRepository studentCharacteristicRepository)
        {
            _studentCharacteristicRepository = studentCharacteristicRepository;
        }
        
        public StudentCharacteristic GetStudentCharacteristic(int studentId)
        {
            var studentCharacteristics =
                _studentCharacteristicRepository.GetStudentCharacteristic(studentId);

            return studentCharacteristics;
        }
    }
}