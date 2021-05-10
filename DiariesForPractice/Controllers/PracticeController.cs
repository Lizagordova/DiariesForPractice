using DiariesForPractice.Domain.Services.PracticeDetail;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
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
            return new OkResult();
        }
    }
}