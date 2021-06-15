using System;
using System.Linq;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services.Users;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
using DiariesForPractice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserReaderService _userReader;
		private readonly IUserEditorService _userEditor;
		private readonly MapperService _mapper;
		private readonly LogService _logService;
		private readonly ILogger<UserController> _logger;
		//todo: добавить отслеживание по ip-шникам,кто заходит
		public UserController(
			IUserReaderService userReader,
			IUserEditorService userEditor,
			MapperService mapper,
			LogService logService,
			ILogger<UserController> logger)
		{
			_userReader = userReader;
			_userEditor = userEditor;
			_mapper = mapper;
			_logService = logService;
			_logger = logger;
		}

		[HttpGet]
		[Route("/getuserbyid")]
		public ActionResult GetUserById([FromQuery]int userId)
		{
			try
			{
				var user = _userReader.GetUserById(userId);
				var userViewModel = _mapper.Map<User, UserViewModel>(user);

				return new JsonResult(userViewModel);
			}
			catch (Exception e)
			{
				_logService.AddGetUserByIdLog(_logger, e, LogType.Base, userId);

				return new StatusCodeResult(500);
			}
		}
		
		[HttpGet]
		[Route("/getusers")]
		public ActionResult GetUsers()
		{
			try
			{
				var users = _userReader.GetUsers();
				var userViewModels = users.Select(_mapper.Map<User, UserViewModel>).ToList();

				return new JsonResult(userViewModels);
			}
			catch (Exception e)
			{
				_logService.GetUsersLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}
		
		[HttpPost]
		[Route("/addorupdateuser")]
		public ActionResult AddOrUdpateUser([FromBody]UserReadModel userReadModel)
		{
			try
			{
				var user = _mapper.Map<UserReadModel, User>(userReadModel);
				var userId = _userEditor.AddOrUpdateUser(user);

				return new JsonResult(userId);
			}
			catch (Exception e)
			{
				_logService.AddOrUpdateUserLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}
		[HttpPost]
		[Route("/removeuser")]
		public ActionResult RemoveUser([FromBody]UserReadModel userReadModel)
		{
			try
			{
				 _userEditor.RemoveUser(userReadModel.Id);

				return new OkResult();
			}
			catch (Exception e)
			{
				_logService.AddOrUpdateUserLog(_logger, e, LogType.Base);

				return new StatusCodeResult(500);
			}
		}
		
	}
}