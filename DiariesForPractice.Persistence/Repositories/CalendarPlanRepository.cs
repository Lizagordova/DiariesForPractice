using System.Data;
using System.Linq;
using Dapper;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO.Data;
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

        public int AddOrUpdateCalendarPlan(int calendarPlanId, int practiceDetailsId)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = CalendarPlanPracticeParam(calendarPlanId, practiceDetailsId);
            var updatedCalendarPlanId = conn
                .Query<int>(AddOrUpdateCalendarPlanSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return updatedCalendarPlanId;
        }

        public int AddOrUpdateCalendarWeekPlan(CalendarPlanWeek calendarPlanWeek, int calendarPlanId)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = CalendarPlanWeekParam(calendarPlanWeek, calendarPlanId);
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
            var reader = conn.QueryMultiple(GetCalendarPlanSp, param, commandType: CommandType.StoredProcedure);
            var calendarPlanData = GetCalendarPlanData(reader);
            DatabaseHelper.CloseConnection(conn);
            var calendarPlan = MapCalendarPlan(calendarPlanData);

            return calendarPlan;
        }

        private CalendarPlanData GetCalendarPlanData(SqlMapper.GridReader reader)
        {
            var calendarPlanData = new CalendarPlanData()
            {
                CalendarPlanId = reader.Read<int>().FirstOrDefault(),
                CalendarPlanWeeks = reader.Read<CalendarWeekPlanUdt>().ToList()
            };

            return calendarPlanData;
        }

        private CalendarPlan MapCalendarPlan(CalendarPlanData calendarPlanData)
        {
            var calendarPlan = new CalendarPlan()
            {
                Id = calendarPlanData.CalendarPlanId,
                CalendarPlanWeeks = calendarPlanData.CalendarPlanWeeks
                    .Select(_mapper.Map<CalendarWeekPlanUdt, CalendarPlanWeek>)
                    .ToList()

            };

            return calendarPlan;
        }

        private DynamicTvpParameters CalendarPlanWeekParam(CalendarPlanWeek calendarPlanWeek, int calendarPlanId)
        {
            var param = new DynamicTvpParameters();
            param.Add("calendarPlanId", calendarPlanId);
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

        private DynamicTvpParameters CalendarPlanPracticeParam(int calendarPlanId, int practiceDetailsId)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("calendarPlan", "UDT_CalendarPlan");
            var udt = new CalendarPlanUdt()
            {
                Id = calendarPlanId,
                PracticeDetailsId = practiceDetailsId
            };
            tvp.AddObjectAsRow(udt);
            param.Add(tvp);

            return param;
        }
    }
}