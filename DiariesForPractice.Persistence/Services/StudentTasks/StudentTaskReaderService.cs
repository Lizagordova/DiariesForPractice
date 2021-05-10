using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.StudentTasks;

namespace DiariesForPractice.Persistence.Services.StudentTasks
{
    public class StudentTaskReaderService : IStudentTaskReaderService
    {
        private readonly IStudentTaskRepository _studentTaskRepository;
        public StudentTaskReaderService(
            IStudentTaskRepository studentTaskRepository)
        {
            _studentTaskRepository = studentTaskRepository;
        }
        
        public StudentTask GetStudentTask(int studentId)
        {
            var studentTask = _studentTaskRepository.GetStudentTask(studentId);

            return studentTask;
        }

        public List<StudentTask> GetStudentTasks()
        {
            var studentTasks = _studentTaskRepository.GetStudentTasks();

            return studentTasks;
        }
    }
}