using System;
using System.Linq;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services.InstituteDetails;
using DiariesForPractice.Services.Mapper;
using DiariesForPractice.ViewModels;
using DiariesForPractice.ViewModels.Data;
using Microsoft.AspNetCore.Mvc;

namespace DiariesForPractice.Controllers
{
	public class InstituteDetailsController : Controller
	{
		private readonly IInstituteDetailsEditorService _detailsEditor;
		private readonly IInstituteDetailsReaderService _detailsReader;
		private readonly MapperService _mapper;

		public InstituteDetailsController(
			IInstituteDetailsEditorService detailsEditor,
			IInstituteDetailsReaderService detailsReader,
			MapperService mapper)
		{
			_detailsEditor = detailsEditor;
			_detailsReader = detailsReader;
			_mapper = mapper;
		}
		
		[HttpGet]
		[Route("/getinstitutedata")]
		public ActionResult GetInstituteData()
		{
			try
			{
				var instituteDataViewModel = GetInstituteDataViewModel();

				return new JsonResult(instituteDataViewModel);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);//todo: СЮДА

				return new StatusCodeResult(500);
			}
		}

		private InstituteDataViewModel GetInstituteDataViewModel()
		{
			var institutes = _detailsReader.GetInstitutes();
			var cafedras = _detailsReader.GetCafedras();
			var directions = _detailsReader.GetDirections();
			var groups = _detailsReader.GetGroups();
			var courses = _detailsReader.GetCourses();
			var degrees = _detailsReader.GetDegrees();
			var instituteDataViewModel = new InstituteDataViewModel()
			{
				Institutes = institutes.Select(_mapper.Map<Institute, InstituteViewModel>).ToList(),
				Cafedras = cafedras.Select(_mapper.Map<Cafedra, CafedraViewModel>).ToList(),
				Directions = directions.Select(_mapper.Map<Direction, DirectionViewModel>).ToList(),
				Groups = groups.Select(_mapper.Map<Group, GroupViewModel>).ToList(),
				Courses = courses.Select(_mapper.Map<Course, CourseViewModel>).ToList(),
				Degrees = degrees.Select(_mapper.Map<Degree, DegreeViewModel>).ToList(),
			};

			return instituteDataViewModel;
		}
	}
}