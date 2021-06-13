﻿using System;
using System.Collections.Generic;
using System.Linq;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services.InstituteDetails;
using DiariesForPractice.Helpers;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
using DiariesForPractice.ViewModels;
using DiariesForPractice.ViewModels.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
	public class InstituteDetailsController : Controller
	{
		private readonly IInstituteDetailsEditorService _instituteDetailsEditor;
		private readonly IInstituteDetailsReaderService _instituteDetailsReader;
		private readonly MapperService _mapper;
		private readonly ILogger<InstituteDetailsController> _logger;
		private readonly LogService _logService;
		private readonly MapHelper _mapHelper;

		public InstituteDetailsController(
			IInstituteDetailsEditorService instituteDetailsEditor,
			IInstituteDetailsReaderService instituteDetailsReader,
			MapperService mapper,
			ILogger<InstituteDetailsController> logger,
			LogService logService,
			MapHelper mapHelper)
		{
			_instituteDetailsEditor = instituteDetailsEditor;
			_instituteDetailsReader = instituteDetailsReader;
			_mapper = mapper;
			_logger = logger;
			_logService = logService;
			_mapHelper = mapHelper;
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
				_logService.AddGetInstituteDataLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}

		[HttpPost]
		[Route("/addorupdateinstitute")]
		public ActionResult AddOrUpdateInstitute([FromBody]InstituteReadModel instituteReadModel)
		{
			try
			{
				var institute = _mapHelper.MapInstitute(instituteReadModel);
				var instituteId = _instituteDetailsEditor.AddOrUpdateInstitute(institute);

				return new JsonResult(instituteId);
			}
			catch (Exception e)
			{
				_logService.AddOrUpdateInstituteLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}
		
		[HttpPost]
		[Route("/addorupdategroup")]
		public ActionResult AddOrUpdateGroup([FromBody]GroupReadModel groupReadModel)
		{
			try
			{
				var group = _mapper.Map<GroupReadModel, Group>(groupReadModel);
				var groupId = _instituteDetailsEditor.AddOrUpdateGroup(group);

				return new JsonResult(groupId);
			}
			catch (Exception e)
			{
				_logService.AddOrUpdateInstituteLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}
		
		[HttpPost]
		[Route("/addorupdatecafedra")]
		public ActionResult AddOrUpdateCafedra([FromBody]CafedraReadModel cafedraReadModel)
		{
			try
			{
				var cafedra = _mapHelper.MapCafedra(cafedraReadModel);
				var cafedraId = _instituteDetailsEditor.AddOrUpdateCafedra(cafedra);

				return new JsonResult(cafedraId);
			}
			catch (Exception e)
			{
				_logService.AddOrUpdateCafedraLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}
		
		[HttpPost]
		[Route("/addorupdatedirection")]
		public ActionResult AddOrUpdateDirection([FromBody]DirectionReadModel directionReadModel)
		{
			try
			{
				var direction = _mapHelper.MapDirection(directionReadModel);
				var directionId = _instituteDetailsEditor.AddOrUpdateDirection(direction);

				return new JsonResult(directionId);
			}
			catch (Exception e)
			{
				_logService.AddOrUpdateDirectionLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}
		
		[HttpPost]
		[Route("/addorupdatecourse")]
		public ActionResult AddOrUpdateCourse([FromBody]CourseReadModel courseReadModel)
		{
			try
			{
				var course = _mapper.Map<CourseReadModel, Course>(courseReadModel);
				var courseId = _instituteDetailsEditor.AddOrUpdateCourse(course, courseReadModel.DegreeId);

				return new JsonResult(courseId);
			}
			catch (Exception e)
			{
				_logService.AddOrUpdateCourseLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}
		
		[HttpPost]
		[Route("/addorupdatedegree")]
		public ActionResult AddOrUpdateDegree([FromBody]DegreeReadModel degreeReadModel)
		{
			try
			{
				var degree = _mapHelper.MapDegree(degreeReadModel);
				var degreeId = _instituteDetailsEditor.AddOrUpdateDegree(degree);

				return new JsonResult(degreeId);
			}
			catch (Exception e)
			{
				_logService.AddOrUpdateDegreeLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}
		
		[HttpPost]
		[Route("/attachstudenttogroup")]
		public ActionResult AttachStudentToGroup([FromBody]int studentId, [FromBody]int groupId)
		{
			try
			{
				_instituteDetailsEditor.AttachStudentToGroup(studentId, groupId);

				return new OkResult();
			}
			catch (Exception e)
			{
				_logService.AddOrUpdateCourseLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}
		
		[HttpPost]
		[Route("/removestudentfromgroup")]
		public ActionResult RemoveStudentFromGroup([FromBody]int studentId, [FromBody]int groupId)
		{
			try
			{
				_instituteDetailsEditor.AttachStudentToGroup(studentId, groupId);

				return new OkResult();
			}
			catch (Exception e)
			{
				_logService.AddOrUpdateCourseLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}
		
		[HttpPost]
		[Route("/getgroup")]
		public ActionResult GetGroup([FromBody]GroupReadModel groupReadModel)
		{
			try
			{
				var group = _instituteDetailsReader.GetGroup(groupReadModel.Id);
				var groupViewModel = _mapper.Map<Group, GroupViewModel>(group);

				return new JsonResult(groupViewModel);
			}
			catch (Exception e)
			{
				_logService.GetGroupLog(_logger, e, LogType.Base, groupReadModel.Id);

				return new StatusCodeResult(500);
			}
		}
		
		private InstituteDataViewModel GetInstituteDataViewModel()
		{
			var institutes = _instituteDetailsReader.GetInstitutes();
			var cafedras = _instituteDetailsReader.GetCafedras();
			var directions = _instituteDetailsReader.GetDirections();
			var groups = _instituteDetailsReader.GetGroups();
			var courses = _instituteDetailsReader.GetCourses();
			var degrees = _instituteDetailsReader.GetDegrees();
			var instituteDataViewModel = new InstituteDataViewModel()
			{
				Institutes = institutes.Select(_mapHelper.MapInstituteViewModel).ToList(),
				Cafedras = cafedras.Select(_mapHelper.MapCafedraViewModel).ToList(),
				Directions = directions.Select(_mapHelper.MapDirectionViewModel).ToList(),
				Groups = groups.Select(_mapper.Map<Group, GroupViewModel>).ToList(),
				Courses = courses.Select(_mapper.Map<Course, CourseViewModel>).ToList(),
				Degrees = degrees.Select(_mapHelper.MapDegreeViewModel).ToList(),
			};

			return instituteDataViewModel;
		}
	}
}