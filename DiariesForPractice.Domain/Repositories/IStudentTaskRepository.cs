using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
    public interface IStudentTaskRepository
    {
        int AddOrUpdateStudentTask(StudentTask studentTask, int practiceDetailsId);
        StudentTask GetStudentTask(int studentId);
        List<StudentTask> GetStudentTasks();
    }
}