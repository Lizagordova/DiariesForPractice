using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.StudentCharacteristics;
using DiariesForPractice.Persistence.Services.MapperService;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services;
using DiariesForPractice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
    public class StudentCharacteristicsController : Controller
    {
        private readonly IStudentCharacteristicsEditor _studentCharacteristicsEditor;
        private readonly IStudentCharacteristicsReader _studentCharacteristicsReader;
        private readonly MapperService _mapper;
        private readonly ILogger<StudentCharacteristicsController> _logger;
        private readonly LogService _logService;
        
        public StudentCharacteristicsController(
            IStudentCharacteristicsEditor studentCharacteristicsEditor,
            IStudentCharacteristicsReader studentCharacteristicsReader,
            MapperService mapper,
            ILogger<StudentCharacteristicsController> logger,
            LogService logService)
        {
            _studentCharacteristicsEditor = studentCharacteristicsEditor;
            _studentCharacteristicsReader = studentCharacteristicsReader;
            _mapper = mapper;
            _logger = logger;
            _logService = logService;
        }

        [HttpPost]
        [Route("/addorupdatestudentcharacteristics")]
        public ActionResult AddOrUpdateStudentCharacteristics([FromBody]StudentCharacteristicReadModel studentCharacteristicReadModel)
        {
            try
            {
                var studentCharacteristic =
                    _mapper.Map<StudentCharacteristicReadModel, StudentCharacteristic>(studentCharacteristicReadModel);
                var studentCharacteristicId = _studentCharacteristicsEditor.AddOrUpdateStudentCharacteristic(studentCharacteristic, studentCharacteristicReadModel.PracticeDetailsId);

                return new JsonResult(studentCharacteristicId);
            }
            catch (Exception e)
            {
                _logService.AddOrUpdateStudentCharacteristicsLog(_logger,e, LogType.Base);

                return new StatusCodeResult(500);
            }
        }
        
        [HttpPost]
        [Route("/getstudentcharacteristics")]
        public ActionResult GetStudentCharacteristics([FromBody]StudentCharacteristicReadModel studentCharacteristicReadModel)
        {
            var studentId = studentCharacteristicReadModel.StudentId;
            try
            {
                var studentCharacteristic = _studentCharacteristicsReader.GetStudentCharacteristic(studentId);
                var studentCharacteristicViewModel =
                    _mapper.Map<StudentCharacteristic, StudentCharacteristicViewModel>(studentCharacteristic);

                return new JsonResult(studentCharacteristicViewModel);
            }
            catch (Exception e)
            {
                _logService.GetStudentCharacteristicsLog(_logger,e, LogType.Base, studentId);

                return new StatusCodeResult(500);
            }
        }
    }
}