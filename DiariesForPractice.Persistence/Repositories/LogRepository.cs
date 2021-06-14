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
    public class LogRepository : ILogRepository
    {
        private readonly MapperService _mapper;
        private const string AddLogSp = "LogRepository_AddLog";

        public LogRepository(
            MapperService mapper)
        {
            _mapper = mapper;
        }
        
        public void AddLog(Log log)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = AddLogParam(log);
            conn.Query(AddLogSp, param, commandType: CommandType.StoredProcedure);
            DatabaseHelper.CloseConnection(conn);
        }

        private DynamicTvpParameters AddLogParam(Log log)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("log", "UDT_Log");
            var udt = _mapper.Map<Log, LogUdt>(log);
            tvp.AddObjectAsRow(udt);
            param.Add(tvp);

            return param;
        }
    }
}