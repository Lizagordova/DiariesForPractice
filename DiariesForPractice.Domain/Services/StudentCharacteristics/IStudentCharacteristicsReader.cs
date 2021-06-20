using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.StudentCharacteristics
{
    public interface IStudentCharacteristicsReader
    {
        StudentCharacteristic GetStudentCharacteristic(int studentId);
    }
}