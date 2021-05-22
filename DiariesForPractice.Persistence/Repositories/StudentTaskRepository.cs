using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO;
using DiariesForPractice.Persistence.DTO.UDT;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;
using DiariesForPractice.Persistence.Services.MapperService;

namespace DiariesForPractice.Persistence.Repositories
{
    public class StudentTaskRepository : IStudentTaskRepository
    {
        private readonly string AddOrUpdateStudentTaskSp = "StudentTaskRepository_AddOrUpdateStudentTask";
        private readonly string GetStudentTaskSp = "StudentTaskRepository_GetStudentTask";
        private readonly string GetStudentTasksSp = "StudentTaskRepository_GetStudentTasks";
        private readonly MapperService _mapper;

        public StudentTaskRepository(
            MapperService mapper)
        {
            _mapper = mapper;
        }
        
        public int AddOrUpdateStudentTask(StudentTask studentTask)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = GetStudentTaskParam(studentTask);
            var studentTaskId = conn
                .Query<int>(AddOrUpdateStudentTaskSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return studentTaskId;
        }

        public StudentTask GetStudentTask(int studentId)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = GetStudentTaskParam(studentId);
            var studentTaskUdt = conn
                .Query<StudentTaskUdt>(GetStudentTaskSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            var studentTask = _mapper.Map<StudentTaskUdt, StudentTask>(studentTaskUdt);
            DatabaseHelper.CloseConnection(conn);

            return studentTask;
        }

        public List<StudentTask> GetStudentTasks()
        {
            var conn = DatabaseHelper.OpenConnection();
            var studentTaskUdts = conn
                    .Query<StudentTaskUdt>(GetStudentTasksSp, commandType: CommandType.StoredProcedure)
                    .ToList();
            var studentTasks = studentTaskUdts.Select(_mapper.Map<StudentTaskUdt, StudentTask>).ToList();
            DatabaseHelper.CloseConnection(conn);

            return studentTasks;
        }

        private DynamicTvpParameters GetStudentTaskParam(int studentId)
        {
            var param = new DynamicTvpParameters();
            param.Add("studentId", studentId);
            
            return param;
        }

        private DynamicTvpParameters GetStudentTaskParam(StudentTask studentTask)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("studentTask", "UDT_StudentTask");
            var udt = _mapper.Map<StudentTask, StudentTaskUdt>(studentTask);
            tvp.AddObjectAsRow(udt);
            
            return param;
        }
    }
}