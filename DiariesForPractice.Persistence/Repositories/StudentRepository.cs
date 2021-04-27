using System.Collections.Generic;
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
	public class StudentRepository : IStudentRepository
	{
		private readonly MapperService _mapper;
		private const string AddOrUpdateStudentSp = "StudentRepository_AddOrUpdateStudent";
		private const string GetStudentsSp = "StudentRepository_GetStudents";
		private const string AttachStudentToGroupSp = "StudentRepository_AttachStudentToGroup";
		private const string GetStudentsByIdsSp = "StudentRepository_GetStudentsByIds";
		public StudentRepository(
			MapperService mapper)
		{
			_mapper = mapper;
		}

		public int AddOrUpdateStudent(Student student)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = AddOrUpdateStudentParam(student);
			var studentId = conn.Query<int>(AddOrUpdateStudentSp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
			DatabaseHelper.CloseConnection(conn);

			return studentId;
		}

		public void AttachStudentToGroup(int studentId, int groupId)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = AttachStudentToGroupParam(studentId, groupId);
			conn.Query(AttachStudentToGroupSp, param, commandType: CommandType.StoredProcedure);
			DatabaseHelper.CloseConnection(conn);
		}

		public List<Student> GetStudents()
		{
			var conn = DatabaseHelper.OpenConnection();
			var studentUdts = conn.Query<StudentUdt>(GetStudentsSp, commandType: CommandType.StoredProcedure).ToList();
			var students = studentUdts.Select(_mapper.Map<StudentUdt, Student>).ToList();
			DatabaseHelper.CloseConnection(conn);

			return students;
		}

		private DynamicTvpParameters AddOrUpdateStudentParam(Student student)
		{
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("student", "UDT_Student");
			var udt = _mapper.Map<Student, StudentUdt>(student);
			tvp.AddObjectAsRow(udt);
			param.Add(tvp);

			return param;
		}

		private DynamicTvpParameters AttachStudentToGroupParam(int studentId, int groupId)
		{
			var param = new DynamicTvpParameters();
			param.Add("studentId", studentId);
			param.Add("groupId", groupId);

			return param;
		}

        public List<Student> GetStudentsByIds(List<int> studentIds)
        {
			var conn = DatabaseHelper.OpenConnection();
			var param = GetStudentsByIdsParam(studentIds);
			var studentUdts = conn.Query<StudentUdt>(GetStudentsByIdsSp, param, commandType: CommandType.StoredProcedure).ToList();
			var students = studentUdts.Select(_mapper.Map<StudentUdt, Student>).ToList();
			DatabaseHelper.CloseConnection(conn);

			return students;
        }

		private DynamicTvpParameters GetStudentsByIdsParam(List<int> studentsIds)
        {
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("UDT_Integer", "studentIds");
			var udt = studentsIds.Select(sId => new IntegerUdt() { Id = sId }).ToList();
			tvp.AddGenericList(udt);
			param.Add(tvp);

			return param;
        }

	}
}