using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
    public interface IStudentCharacteristicRepository
    {
        int AddOrUpdateStudentCharacteristic(StudentCharacteristic studentCharacteristic, int practiceDetailsId);
        StudentCharacteristic GetStudentCharacteristic(int studentId);
    }
}