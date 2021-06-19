using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.StudentTasks
{
    public interface IStudentTaskEditorService
    {
        int AddOrUpdateStudentTask(StudentTask studentTask, int practiceDetailsId);
    }
}