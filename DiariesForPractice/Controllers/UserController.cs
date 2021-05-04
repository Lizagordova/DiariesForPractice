using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Services.Students;
using DiariesForPractice.Domain.Services.Users;
using DiariesForPractice.ReadModels;
using DiariesForPractice.ReadModels.Queries;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
using DiariesForPractice.ViewModels;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserReaderService _userReader;
		private readonly MapperService _mapper;
		private readonly LogService _logService;
		private readonly ILogger<UserController> _logger;

		public UserController(
			IUserReaderService userReader,
			MapperService mapper,
			LogService logService,
			ILogger<UserController> logger)
		{
			_userReader = userReader;
			_mapper = mapper;
			_logService = logService;
			_logger = logger;
		}

		[HttpPost]
		[Route("/getusers")]
		public ActionResult GetStudents([FromBody]UserQueryReadModel userQuery)
		{
			
			return new OkResult();
		}

		[HttpGet]
		[Route("/getuserbyid")]
		public ActionResult GetUserById([FromQuery]int userId)
		{
			try
			{
				var user = _userReader.GetUserById(userId);
				var userViewModel = _mapper.Map<UserViewModel, User>(user);

				return new JsonResult(userViewModel);
			}
			catch (Exception e)
			{
				_logService.AddGetUserByIdLog(_logger, e, LogType.Base, userId);

				return new StatusCodeResult(500);
			}
		}
	}
}