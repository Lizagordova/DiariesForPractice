using System;
using System.Linq;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Services.PracticeDetail;
using DiariesForPractice.Helpers;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
using DiariesForPractice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
    public class PracticeController : Controller
    {
        private readonly IPracticeEditorService _practiceEditor;
        private readonly IPracticeReaderService _practiceReader;
        private readonly ILogger<PracticeController> _logger;
        private readonly LogService _logService;
        private readonly MapHelper _mapHelper;

        public PracticeController(
            IPracticeEditorService practiceEditor,
            IPracticeReaderService practiceReader,
            ILogger<PracticeController> logger,
            LogService logService,
            MapHelper mapHelper)
        {
            _practiceEditor = practiceEditor;
            _practiceReader = practiceReader;
            _logger = logger;
            _logService = logService;
            _mapHelper = mapHelper;
        }

        [HttpPost]
        [Route("/addorupdatepracticedetails")]
        public ActionResult AddOrUpdatePracticeDetails([FromBody]PracticeReadModel practiceReadModel)
        {
            try
            {
                var practiceDetails = _mapHelper.MapPracticeDetails(practiceReadModel);
                var practiceDetailsId = _practiceEditor.AddOrUpdatePracticeDetails(practiceDetails);

                return new JsonResult(practiceDetailsId);
            }
            catch (Exception e)
            {
                _logService.AddOrUpdatePracticeDetailsLog(_logger, e, LogType.Base);

                return new StatusCodeResult(500);
            }
        }
        
        [HttpGet]
        [Route("/getpracticedetailsbystudentid")]
        public ActionResult GetPracticeDetails([FromQuery]PracticeReadModel practiceReadModel)
        {
            var query = new PracticeDetailsQuery()
            {
                StudentId = practiceReadModel.StudentId
            };
            try
            {
                var practiceDetails = _practiceReader.GetPracticeDetails(practiceReadModel.StudentId);
                var practiceDetailsViewModel = _mapHelper.MapPracticeViewModel(practiceDetails);

                return new JsonResult(practiceDetailsViewModel);
            }
            catch (Exception e)
            {
                _logService.GetPracticeDetailsLog(_logger, e, LogType.Base, query);

                return new StatusCodeResult(500);
            }
        }
    }
}