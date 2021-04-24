using System;
using System.Linq;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services.Diaries;
using DiariesForPractice.Persistence.Services.MapperService;
using DiariesForPractice.ReadModels;
using DiariesForPractice.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiariesForPractice.Controllers
{
	public class DiariesController : Controller
	{
		private readonly MapperService _mapper;
		private readonly IDiariesReaderService _diariesReader;
		private readonly IDiariesEditorService _diariesEditor;
		public DiariesController(
			MapperService mapper,
			IDiariesEditorService diariesEditor,
			IDiariesReaderService diariesReader)
		{
			_mapper = mapper;
			_diariesEditor = diariesEditor;
			_diariesReader = diariesReader;
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
				var diaries = _diariesReader.GetDiaries();
				var diaryViewModels = diaries.Select(_mapper.Map<Diary, DiaryViewModel>).ToList();

				return new JsonResult(diaryViewModels);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}