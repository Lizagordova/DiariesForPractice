using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services.Authorization;
using DiariesForPractice.Domain.Services.Users;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
using DiariesForPractice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly MapperService _mapper;
        private readonly LogService _logService;
        private readonly ILogger<AuthorizationController> _logger;

        public AuthorizationController(
            IAuthorizationService authorizationService,
            MapperService mapper,
            ILogger<AuthorizationController> logger,
            LogService logService)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _logger = logger;
            _logService = logService;
        }

        [HttpPost]
        [Route("/authorize")]
        public ActionResult Authorize([FromBody]UserReadModel userViewModel)
        {
            try
            {
                var user = _mapper.Map<UserReadModel, User>(userViewModel);
                var userId = _authorizationService.Authorize(user);

                return new JsonResult(userId);
            }
            catch (Exception e)
            {
                _logService.AddAuthorizationLog(_logger, e, LogType.Base);

                return new StatusCodeResult(500);
            }
        }
        
        [HttpPost]
        [Route("/register")]
        public ActionResult Register([FromBody]UserReadModel userReadModel)
        {
            try
            {
                var user = _mapper.Map<UserReadModel, User>(userReadModel);
                var userId = _authorizationService.Register(user);

                return new JsonResult(userId);
            }
            catch (Exception e)
            {
                _logService.AddRegistrationLog(_logger, e, LogType.Base);

                return new StatusCodeResult(500);
            }   
        }
    }
}