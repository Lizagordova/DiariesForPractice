using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.StudentCharacteristics
{
    public interface IStudentCharacteristicsReader
    {
        StudentCharacteristic GetStudentCharacteristic(int studentId);
    }
}