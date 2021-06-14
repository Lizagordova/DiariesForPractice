using System;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.MapperService;
using DiariesForPractice.Persistence.Services.StudentTasks;
using NUnit.Framework;

namespace DiariesForPractice.Tests.Services
{
    public class StudentTaskServices
    {
        private readonly StudentTaskEditorService _studentTaskEditor;
        private readonly StudentTaskReaderService _studentTaskReader;
        public StudentTaskServices()
        {
            var mapper = new MapperService();
            var studentTaskRepository = new StudentTaskRepository(mapper);
            _studentTaskEditor = new StudentTaskEditorService(studentTaskRepository);
            _studentTaskReader = new StudentTaskReaderService(studentTaskRepository);
        }
        
        [Test]
        public void AddOrUpdateStudentTask_Test()
        {
            var studentTask = new StudentTask()
            {
                StudentId = 1,
                Task = "Задание всех выиграть!"
            };
            var studentTaskId = _studentTaskEditor.AddOrUpdateStudentTask(studentTask);
            var result = studentTaskId != 0;
            Console.WriteLine($"studentTaskId={studentTaskId}");
            Assert.That(result == true);
        }
        
        [Test]
        public void GetStudentTask_Test()
        {
            var studentTask = _studentTaskReader.GetStudentTask(1);
            Console.WriteLine($"Id={studentTask.Id};Mark={studentTask.Mark};Task={studentTask.Task};StudentId={studentTask.StudentId}");
        }
    }
}