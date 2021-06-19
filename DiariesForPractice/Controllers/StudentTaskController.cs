using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services.StudentTasks;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
    public class StudentTaskController : Controller
    {
        private readonly ILogger<StudentTaskController> _logger;
        private readonly LogService _logService;
        private readonly MapperService _mapper;
        private readonly IStudentTaskEditorService _studentTaskEditor;
        private readonly IStudentTaskReaderService _studentTaskReader;

        public StudentTaskController(
            ILogger<StudentTaskController> logger,
            LogService logService,
            MapperService mapper,
            IStudentTaskEditorService studentTaskEditor,
            IStudentTaskReaderService studentTaskReader)
        {
            _logger = logger;
            _logService = logService;
            _mapper = mapper;
            _studentTaskEditor = studentTaskEditor;
            _studentTaskReader = studentTaskReader;
        }
        
        [HttpPost]
        [Route("/addorupdatestudenttask")]
        public ActionResult AddOrUpdateStudentTask([FromBody]StudentTaskReadModel studentTaskReadModel)
        {
            try
            {
                var studentTask = _mapper.Map<StudentTaskReadModel, StudentTask>(studentTaskReadModel);
                var studentTaskId = _studentTaskEditor.AddOrUpdateStudentTask(studentTask, studentTaskReadModel.PracticeDetailsId);

                return new JsonResult(studentTaskId);
            }
            catch (Exception e)
            {
                _logService.AddOrUpdateStudentTaskLog(_logger, e, LogType.Base);

                return new StatusCodeResult(500);
            }
        }
        
        
    }
}