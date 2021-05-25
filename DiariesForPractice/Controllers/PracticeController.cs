using System;
using System.Linq;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Services.PracticeDetail;
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
        private readonly MapperService _mapper;
        private readonly ILogger<PracticeController> _logger;
        private readonly LogService _logService;

        public PracticeController(
            IPracticeEditorService practiceEditor,
            IPracticeReaderService practiceReader,
            MapperService mapper,
            ILogger<PracticeController> logger,
            LogService logService)
        {
            _practiceEditor = practiceEditor;
            _practiceReader = practiceReader;
            _mapper = mapper;
            _logger = logger;
            _logService = logService;
        }

        [HttpPost]
        [Route("/addorupdatepracticedetails")]
        public ActionResult AddOrUpdatePracticeDetails([FromBody]PracticeReadModel practiceReadModel)
        {
            try
            {
                var practiceDetails = _mapper.Map<PracticeReadModel, PracticeDetails>(practiceReadModel);
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
        [Route("/getpracticedetailsbystudentid")]//todo: мб и не так это делается для get
        public ActionResult GetPracticeDetails([FromQuery]PracticeReadModel practiceReadModel)
        {
            var query = new PracticeDetailsQuery()
            {
                StudentId = practiceReadModel.StudentId
            };
            try
            {
                var practiceDetails = _practiceReader.GetPracticeDetails(practiceReadModel.StudentId);
                var practiceDetailsViewModel = _mapper.Map<PracticeDetails, PracticeViewModel>(practiceDetails);

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