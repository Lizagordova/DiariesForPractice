using System.Data;
using System.Linq;
using Dapper;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO.UDT;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;
using DiariesForPractice.Persistence.Services.MapperService;

namespace DiariesForPractice.Persistence.Repositories
{
    public class CalendarPlanRepository : ICalendarPlanRepository
    {
        private const string AddOrUpdateCalendarPlanSp = "CalendarPlanRepository_AddOrUpdateCalendarPlan";
        private const string AddOrUpdateCalendarWeekPlanSp = "CalendarPlanRepository_AddOrUpdateCalendarWeekPlan";
        private const string GetCalendarPlanSp = "CalendarPlanRepository_GetCalendarPlan";
        private readonly MapperService _mapper;
        public CalendarPlanRepository(
            MapperService mapper)
        {
            _mapper = mapper;
        }
        
        public int AddOrUpdateCalendarPlan(CalendarPlan calendarPlan)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = CalendarPlanParam(calendarPlan);
            var calendarPlanId = conn
                .Query<int>(AddOrUpdateCalendarPlanSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return calendarPlanId;
        }

        public int AddOrUpdateCalendarWeekPlan(CalendarPlanWeek calendarPlanWeek)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = CalendarPlanWeekParam(calendarPlanWeek);
            var calendarPlanWeekId = conn
                .Query<int>(AddOrUpdateCalendarWeekPlanSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return calendarPlanWeekId;
        }

        public CalendarPlan GetCalendarPlan(int calendarPlanId)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = CalendarPlanIdParam(calendarPlanId);
            var calendarWeekPlanUdts = conn
                .Query<CalendarWeekPlanUdt>(GetCalendarPlanSp, param, commandType: CommandType.StoredProcedure)
                .ToList();
            DatabaseHelper.CloseConnection(conn);
            var calendarPlan = new CalendarPlan()
            {
                Id = calendarPlanId,
                CalendarPlanWeeks = calendarWeekPlanUdts.Select(_mapper.Map<CalendarWeekPlanUdt, CalendarPlanWeek>)
                    .ToList()
            };

            return calendarPlan;
        }

        private DynamicTvpParameters CalendarPlanParam(CalendarPlan calendarPlan)
        {
            var param = new DynamicTvpParameters();
            param.Add("calendarPlanId", calendarPlan.Id);
            var tvp = new TableValuedParameter("calendarWeeksPlan", "UDT_CalendarWeekPlan");
            var udt = calendarPlan.CalendarPlanWeeks
                .Select(_mapper.Map<CalendarPlanWeek, CalendarWeekPlanUdt>)
                .ToList();
            tvp.AddGenericList(udt);
            param.Add(tvp);
            
            return param;
        }

        private DynamicTvpParameters CalendarPlanWeekParam(CalendarPlanWeek calendarPlanWeek)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("calendarWeekPlan", "UDT_CalendarWeekPlan");
            var udt = _mapper.Map<CalendarPlanWeek, CalendarWeekPlanUdt>(calendarPlanWeek);
            tvp.AddObjectAsRow(udt);
            param.Add(tvp);
            
            return param;
        }

        private DynamicTvpParameters CalendarPlanIdParam(int calendarPlanId)
        {
            var param = new DynamicTvpParameters();
            param.Add("calendarPlanId", calendarPlanId);

            return param;
        }
    }
}