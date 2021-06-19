using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.StudentTasks;

namespace DiariesForPractice.Persistence.Services.StudentTasks
{
    public class StudentTaskEditorService : IStudentTaskEditorService
    {
        private readonly IStudentTaskRepository _studentTaskRepository;

        public StudentTaskEditorService(
            IStudentTaskRepository studentTaskRepository)
        {
            _studentTaskRepository = studentTaskRepository;
        }
        
        public int AddOrUpdateStudentTask(StudentTask studentTask, int practiceDetailsId)
        {
            var studentTaskId = _studentTaskRepository.AddOrUpdateStudentTask(studentTask, practiceDetailsId);

            return studentTaskId;
        }
    }
}