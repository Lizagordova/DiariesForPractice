using System;
using System.Linq;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Services.Diaries;
using DiariesForPractice.Persistence.Services.MapperService;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services;
using DiariesForPractice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
	public class DiariesController : Controller
	{
		private readonly MapperService _mapper;
		private readonly IDiariesReaderService _diariesReader;
		private readonly IDiariesEditorService _diariesEditor;
		private readonly ILogger<DiariesController> _logger;
		private readonly LogService _logService;
		
		public DiariesController(
			MapperService mapper,
			IDiariesEditorService diariesEditor,
			IDiariesReaderService diariesReader,
			ILogger<DiariesController> logger,
			LogService logService)
		{
			_mapper = mapper;
			_diariesEditor = diariesEditor;
			_diariesReader = diariesReader;
			_logger = logger;
			_logService = logService;
		}

		[HttpPost]
		[Route("/generatediary")]
		public ActionResult GenerateDiary([FromBody]DiaryReadModel diaryViewModel)
		{
			try
			{
				var diaryId = _diariesEditor.GenerateDiary(diaryViewModel.StudentId);
				
				return new JsonResult(diaryId);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		[HttpPost]
		[Route("/getdiaries")]
		public ActionResult GetDiaries()
		{
			try
			{
				var query = new DiaryQuery();
				var diaries = _diariesReader.GetDiaries(query);
				var diaryViewModels = diaries.Select(_mapper.Map<Diary, DiaryViewModel>).ToList();

				return new JsonResult(diaryViewModels);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
		
		[HttpGet]
		[Route("/getdiary")]//todo: мб и не так это делается для get
		public ActionResult GetDiaries([FromQuery]int studentId)
		{
			try
			{
				var diary = _diariesReader.GetDiary(studentId);
				var diaryViewModel = _mapper.Map<Diary, DiaryViewModel>(diary);
				
				return new JsonResult(diaryViewModel);
			}
			catch (Exception e)
			{
				_logService.GetDiaryLog(_logger, e, LogType.Base, studentId);

				return new StatusCodeResult(500);
			}
		}
	}
}