using DiariesForPractice.Domain.Services.PracticeDetail;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DiariesForPractice.Controllers
{
    public class PracticeController : Controller
    {
        private readonly IPracticeEditorService _practiceEditor;
        private readonly IPracticeReaderService _practiceReader;
        private readonly MapperService _mapper;

        public PracticeController(
            IPracticeEditorService practiceEditor,
            IPracticeReaderService practiceReader,
            MapperService mapper)
        {
            _practiceEditor = practiceEditor;
            _practiceReader = practiceReader;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/addorupdatepracticedetails")]
        public ActionResult AddOrUpdatePracticeDetails([FromBody]PracticeReadModel practiceReadModel)
        {
            return new OkResult();
        }
    }
}