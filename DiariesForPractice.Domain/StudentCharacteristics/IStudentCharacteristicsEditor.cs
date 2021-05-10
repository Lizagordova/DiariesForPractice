using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.StudentCharacteristics
{
    public interface IStudentCharacteristicsEditor
    {
        int AddOrUpdateStudentCharacteristic(StudentCharacteristic studentCharacteristic);
    }
}