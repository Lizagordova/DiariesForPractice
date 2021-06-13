using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Services.CalendarPlans;
using DiariesForPractice.Helpers;
using DiariesForPractice.ReadModels;
using DiariesForPractice.Services;
using DiariesForPractice.Services.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Controllers
{
    public class CalendarPlanController : Controller
    {
        private readonly MapperService _mapper;
        private readonly ILogger<CalendarPlanController> _logger;
        private readonly LogService _logService;
        private readonly ICalendarPlanEditor _calendarPlanEditor;
        private readonly ICalendarPlanReader _calendarPlanReader;
        private readonly MapHelper _mapHelper;
        
        public CalendarPlanController(
            MapperService mapper,
            ILogger<CalendarPlanController> logger,
            LogService logService,
            ICalendarPlanEditor calendarPlanEditor,
            ICalendarPlanReader calendarPlanReader,
            MapHelper mapHelper)
        {
            _mapper = mapper;
            _logger = logger;
            _logService = logService;
            _calendarPlanEditor = calendarPlanEditor;
            _calendarPlanReader = calendarPlanReader;
            _mapHelper = mapHelper;
        }
        
        [HttpPost]
        [Route("/addorupdatecalendarplan")]
        public ActionResult AddOrUpdateCalendarPlan([FromBody]CalendarPlanReadModel calendarPlanReadModel)
        {
            try
            {
                var calendarPlan = _mapHelper.MapCalendarPlan(calendarPlanReadModel);
                var calendarPlanId = _calendarPlanEditor.AddOrUpdateCalendarPlan(calendarPlan, calendarPlanReadModel.PracticeDetailsId);

                return new JsonResult(calendarPlanId);
            }
            catch (Exception e)
            {
                _logService.AddOrUpdateCalendarPlanLog(_logger, e, LogType.Base, calendarPlanReadModel.PracticeDetailsId);

                return new StatusCodeResult(500);
            }
        }
    }
}