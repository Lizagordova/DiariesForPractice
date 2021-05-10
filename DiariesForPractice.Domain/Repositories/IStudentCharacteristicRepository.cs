using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
    public interface IStudentCharacteristicRepository
    {
        int AddOrUpdateStudentCharacteristic(StudentCharacteristic studentCharacteristic);
        StudentCharacteristic GetStudentCharacteristic(int studentId);
    }
}