using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.StudentCharacteristics;

namespace DiariesForPractice.Persistence.Services.StudentCharacteristics
{
    public class StudentCharacteristicsEditor : IStudentCharacteristicsEditor
    {
        private readonly IStudentCharacteristicRepository _studentCharacteristicRepository;

        public StudentCharacteristicsEditor(
            IStudentCharacteristicRepository studentCharacteristicRepository)
        {
            _studentCharacteristicRepository = studentCharacteristicRepository;
        }
        
        public int AddOrUpdateStudentCharacteristic(StudentCharacteristic studentCharacteristic)
        {
            var studentCharacteristicsId =
                _studentCharacteristicRepository.AddOrUpdateStudentCharacteristic(studentCharacteristic);

            return studentCharacteristicsId;
        }
    }
}