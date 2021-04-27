using DiariesForPractice.Domain.Services.Students;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DiariesForPractice.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudentEditorService _editorService;
		private readonly IStudentReaderService _readerService;
		private readonly MapperService _mapper;

		public StudentController(
			IStudentEditorService editorService,
			IStudentReaderService readerService,
			MapperService mapper)
		{
			_editorService = editorService;
			_readerService = readerService;
			_mapper = mapper;
		}

		[HttpPost]
		[Route("/getstudents")]
		public ActionResult GetStudents([FromBody]StudentsQueryReadModel studentsQuery)
		{
			
			return new OkResult();
		}
	}
}