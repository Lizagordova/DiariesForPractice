using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.StudentTasks
{
    public interface IStudentTaskReaderService
    {
        StudentTask GetStudentTask(int studentId);
        List<StudentTask> GetStudentTasks();
    }
}