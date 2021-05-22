using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO.Data;
using DiariesForPractice.Persistence.DTO.UDT;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;
using DiariesForPractice.Persistence.Services.MapperService;

namespace DiariesForPractice.Persistence.Repositories
{
	public class InstituteDetailsRepository : IInstituteDetailsRepository
	{
		private readonly MapperService _mapper;
		private const string AddOrUpdateInstituteSp = "InstituteDetailsRepository_AddOrUpdateInstitute";
		private const string AddOrUpdateCafedraSp = "InstituteDetailsRepository_AddOrUpdateCafedra";
		private const string AddOrUpdateDirectionSp = "InstituteDetailsRepository_AddOrUpdateDirection";
		private const string AddOrUpdateGroupSp = "InstituteDetailsRepository_AddOrUpdateGroup";
		private const string AddOrUpdateCourseSp = "InstituteDetailsRepository_AddOrUpdateCourse";
		private const string AddOrUpdateDegreeSp = "InstituteDetailsRepository_AddOrUpdateDegree";
		private const string GetInstitutesSp = "InstituteDetailsRepository_GetInstitutes";
		private const string GetCafedrasSp = "InstituteDetailsRepository_GetCafedras";
		private const string GetDirectionsSp = "InstituteDetailsRepository_GetDirections";
		private const string GetGroupsSp = "InstituteDetailsRepository_GetGroups";
		private const string GetDegreesSp = "InstituteDetailsRepository_GetDegrees";
		private const string GetCoursesSp = "InstituteDetailsRepository_GetCourses";
		private const string GetInstituteSp = "InstituteDetailsRepository_GetInstitute";
		private const string GetCafedraSp = "InstituteDetailsRepository_GetCafedra";
		private const string GetDirectionSp = "InstituteDetailsRepository_GetDirection";
		private const string GetGroupSp = "InstituteDetailsRepository_GetGroup";
		private const string GetDegreeSp = "InstituteDetailsRepository_GetDegree";
		private const string GetCourseSp = "InstituteDetailsRepository_GetCourse";
		private const string AttachStudentToGroupSp = "InstituteDetailsRepository_AttachStudentToGroup";
		public InstituteDetailsRepository(
			MapperService mapper)
		{
			_mapper = mapper;
		}

		public int AddOrUpdateInstitute(Institute institute)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = AddOrUpdateInstituteParam(institute);
			var instituteId = conn.Query<int>(AddOrUpdateInstituteSp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
			DatabaseHelper.CloseConnection(conn);

			return instituteId;
		}

		public int AddOrUpdateCafedra(Cafedra cafedra)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = AddOrUpdateCafedraParam(cafedra);
			var cafedraId = conn.Query<int>(AddOrUpdateCafedraSp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
			DatabaseHelper.CloseConnection(conn);

			return cafedraId;
		}

		public int AddOrUpdateDirection(Direction direction)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = AddOrUpdateDirectionParam(direction);
			var directionId = conn.Query<int>(AddOrUpdateDirectionSp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
			DatabaseHelper.CloseConnection(conn);

			return directionId;
		}

		public int AddOrUpdateGroup(Group @group)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = AddOrUpdateGroupParam(@group);
			var groupId = conn.Query<int>(AddOrUpdateGroupSp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
			DatabaseHelper.CloseConnection(conn);

			return groupId;
		}

		public int AddOrUpdateCourse(Course course, int degreeId)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = AddOrUpdateCourseParam(course, degreeId);
			var courseId = conn.Query<int>(AddOrUpdateCourseSp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
			DatabaseHelper.CloseConnection(conn);

			return courseId;
		}

		public int AddOrUpdateDegree(Degree degree)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = AddOrUpdateDegreeParam(degree);
			var instituteId = conn.Query<int>(AddOrUpdateDegreeSp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
			DatabaseHelper.CloseConnection(conn);

			return instituteId;
		}

		public IReadOnlyCollection<Institute> GetInstitutes()
		{
			var conn = DatabaseHelper.OpenConnection();
			var instituteUdts = conn.Query<InstituteUdt>(GetInstitutesSp, commandType: CommandType.StoredProcedure);
			var institutes = instituteUdts.Select(_mapper.Map<InstituteUdt, Institute>).ToList();
			DatabaseHelper.CloseConnection(conn);

			return institutes;
		}

		public IReadOnlyCollection<Cafedra> GetCafedras(int? instituteId = null)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetInstituteEntityParam(InstituteEntity.Institute, instituteId);
			var cafedraUdts = conn.Query<CafedraUdt>(GetCafedrasSp, param, commandType: CommandType.StoredProcedure);
			var cafedras = cafedraUdts.Select(_mapper.Map<CafedraUdt, Cafedra>).ToList();
			DatabaseHelper.CloseConnection(conn);

			return cafedras;
		}

		public IReadOnlyCollection<Direction> GetDirections(int? cafedraId = null)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetInstituteEntityParam(InstituteEntity.Cafedra, cafedraId);
			var directionUdts = conn.Query<DirectionUdt>(GetDirectionsSp, commandType: CommandType.StoredProcedure);
			var directions = directionUdts.Select(_mapper.Map<DirectionUdt, Direction>).ToList();
			DatabaseHelper.CloseConnection(conn);

			return directions;
		}

		public IReadOnlyCollection<Group> GetGroups(int? directionId = null)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetInstituteEntityParam(InstituteEntity.Direction, directionId);
			var response = conn.QueryMultiple(GetGroupsSp, param, commandType: CommandType.StoredProcedure);
			var groupData = GetGroupData(response);
			var groups = MapGroups(groupData);
			DatabaseHelper.CloseConnection(conn);

			return groups;
		}

		private GroupData GetGroupData(SqlMapper.GridReader reader)
		{
			var groupData = new GroupData()
			{
				Groups = reader.Read<GroupUdt>().ToList(),
				GroupsDetails = reader.Read<GroupDetailsUdt>().ToList(),
				Students = reader.Read<UserUdt>().ToList(),
				StudentGroups = reader.Read<StudentGroupUdt>().ToList(),
			};

			return groupData;
		}

		private IReadOnlyCollection<Group> MapGroups(GroupData groupData)
		{
			var groups = groupData.Groups
				.Join(groupData.GroupsDetails,
					g => g.Id,
					gd => gd.GroupId,
					MapGroup)
				.Join(groupData.StudentGroups,
					g => g.Id,
					sg => sg.GroupId,
					MapGroup
					)
				// todo: дописать
				// .Join(groupData.Students,
				// 	g => g.Students,
				// 	s => s.Id,
				// 	(g, s) =>
				// 	{
				// 		if(g.Students.Select(u => u.Id).Contains(s.Id))
				// 		{
				// 			MapGroup(g, s);
				// 		}
				// 	})
				.ToList();

			return groups;
		}

		private Group MapGroup(GroupUdt groupUdt, GroupDetailsUdt groupDetailsUdt)
		{
			var group = _mapper.Map<GroupUdt, Group>(groupUdt);
			group.GroupDetails = _mapper.Map<GroupDetailsUdt, GroupDetails>(groupDetailsUdt);

			return group;
		}

		private Group MapGroup(Group group, StudentGroupUdt studentGroupUdt)
		{
			group.Students.Add(new User()
			{
				Id = studentGroupUdt.StudentId
			});

			return group;
		}
		
		private Group MapGroup(Group group, UserUdt studentUdt)
		{
			group.Students = @group.Students.Select(u =>
			{
				if (u.Id == studentUdt.Id)
				{
					u = _mapper.Map<UserUdt, User>(studentUdt);
				}

				return u;
			}).ToList();

			return group;
		}
		public IReadOnlyCollection<Degree> GetDegrees()
		{
			var conn = DatabaseHelper.OpenConnection();
			var reader = conn.QueryMultiple(GetDegreesSp, commandType: CommandType.StoredProcedure);
			var degreeData = GetDegreesData(reader);
			var degrees = MapDegrees(degreeData);
			DatabaseHelper.CloseConnection(conn);

			return degrees;
		}

		public IReadOnlyCollection<Course> GetCourses(int? degreeId = null)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetInstituteEntityParam(InstituteEntity.Degree, degreeId);
			var courseUdts = conn.Query<CourseUdt>(GetCoursesSp, param, commandType: CommandType.StoredProcedure);
			var courses = courseUdts.Select(_mapper.Map<CourseUdt, Course>).ToList();
			DatabaseHelper.CloseConnection(conn);

			return courses;
		}

		public Institute GetInstitute(int instituteId)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetInstituteEntityParam(InstituteEntity.Institute, instituteId);
			var instituteUdt = conn
				.Query<InstituteUdt>(GetInstituteSp, param, commandType: CommandType.StoredProcedure)
				.FirstOrDefault();
			var institute = _mapper.Map<InstituteUdt, Institute>(instituteUdt);
			DatabaseHelper.CloseConnection(conn);

			return institute;
		}

		public Cafedra GetCafedra(int cafedraId)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetInstituteEntityParam(InstituteEntity.Cafedra, cafedraId);
			var cafedraUdt = conn
				.Query<CafedraUdt>(GetCafedraSp, param, commandType: CommandType.StoredProcedure)
				.FirstOrDefault();
			var cafedra = _mapper.Map<CafedraUdt, Cafedra>(cafedraUdt);
			DatabaseHelper.CloseConnection(conn);

			return cafedra;
		}

		public Direction GetDirection(int directionId)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetInstituteEntityParam(InstituteEntity.Direction, directionId);
			var directionUdt = conn
				.Query<DirectionUdt>(GetDirectionSp, param, commandType: CommandType.StoredProcedure)
				.FirstOrDefault();
			var direction = _mapper.Map<DirectionUdt, Direction>(directionUdt);
			DatabaseHelper.CloseConnection(conn);

			return direction;
		}

		public Group GetGroup(int groupId)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetInstituteEntityParam(InstituteEntity.Group, groupId);
			var groupUdt = conn
				.Query<GroupUdt>(GetGroupSp, param, commandType: CommandType.StoredProcedure)
				.FirstOrDefault();
			var group = _mapper.Map<GroupUdt, Group>(groupUdt);
			DatabaseHelper.CloseConnection(conn);

			return group;
		}

		public Course GetCourse(int courseId)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetInstituteEntityParam(InstituteEntity.Course, courseId);
			var courseUdt = conn
				.Query<CourseUdt>(GetCourseSp, param, commandType: CommandType.StoredProcedure)
				.FirstOrDefault();
			var course = _mapper.Map<CourseUdt, Course>(courseUdt);
			DatabaseHelper.CloseConnection(conn);

			return course;
		}

		public Degree GetDegree(int degreeId)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetInstituteEntityParam(InstituteEntity.Institute, degreeId);
			var degreeUdt = conn
				.Query<DegreeUdt>(GetDegreeSp, param, commandType: CommandType.StoredProcedure)
				.FirstOrDefault();
			var degree = _mapper.Map<DegreeUdt, Degree>(degreeUdt);
			DatabaseHelper.CloseConnection(conn);

			return degree;
		}

		public void AttachStudentToGroup(int studentId, int groupId)
		{
			var conn = DatabaseHelper.OpenConnection();
			var param = GetStudentGroupParam(studentId, groupId);
			conn.Query(AttachStudentToGroupSp, param, commandType: CommandType.StoredProcedure);
			DatabaseHelper.CloseConnection(conn);
		}

		private DegreeData GetDegreesData(SqlMapper.GridReader reader)
		{
			var degreesData = new DegreeData()
			{
				Degrees = reader.Read<DegreeUdt>().ToList(),
				Courses = reader.Read<CourseUdt>().ToList()
			};

			return degreesData;
		}

		private IReadOnlyCollection<Degree> MapDegrees(DegreeData data)
		{
			var degrees = data.Degrees
				.GroupJoin(data.Courses,
					d => d.Id,
					c => c.DegreeId,
					MapDegree)
				.ToList();

			return degrees;
		}

		private Degree MapDegree(DegreeUdt degreeUdt, IEnumerable<CourseUdt> courseUdt)
		{
			var degree = _mapper.Map<DegreeUdt, Degree>(degreeUdt);
			degree.Courses = courseUdt.Select(_mapper.Map<CourseUdt, Course>).ToList();

			return degree;
		}

		private DynamicTvpParameters AddOrUpdateInstituteParam(Institute institute)
		{
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("institute", "UDT_Institute");
			var udt = _mapper.Map<Institute, InstituteUdt>(institute);
			tvp.AddObjectAsRow(udt);
			param.Add(tvp);

			return param;
		}
		
		private DynamicTvpParameters AddOrUpdateCafedraParam(Cafedra cafedra)
		{
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("cafedra", "UDT_Cafedra");
			var udt = _mapper.Map<Cafedra, CafedraUdt>(cafedra);
			tvp.AddObjectAsRow(udt);
			param.Add(tvp);

			return param;
		}
		
		private DynamicTvpParameters AddOrUpdateDirectionParam(Direction direction)
		{
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("direction", "UDT_Direction");
			var udt = _mapper.Map<Direction, DirectionUdt>(direction);
			tvp.AddObjectAsRow(udt);
			param.Add(tvp);

			return param;
		}
		
		private DynamicTvpParameters AddOrUpdateGroupParam(Group group)
		{
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("group", "UDT_Group");
			var udt = _mapper.Map<Group, GroupUdt>(group);
			tvp.AddObjectAsRow(udt);
			param.Add(tvp);

			return param;
		}
		
		private DynamicTvpParameters AddOrUpdateCourseParam(Course course, int degreeId)
		{
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("course", "UDT_Course");
			var udt = _mapper.Map<Course, CourseUdt>(course);
			tvp.AddObjectAsRow(udt);
			param.Add(tvp);
			param.Add("degreeId", degreeId);

			return param;
		}
		
		private DynamicTvpParameters AddOrUpdateDegreeParam(Degree degree)
		{
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("degree", "UDT_Degree");
			var udt = _mapper.Map<Degree, DegreeUdt>(degree);
			tvp.AddObjectAsRow(udt);
			param.Add(tvp);

			return param;
		}

		private DynamicTvpParameters GetInstituteEntityParam(InstituteEntity entity, int? entityId = null)
		{
			var param = new DynamicTvpParameters();
			if (entityId != null)
			{
				switch (entity)
				{
					case InstituteEntity.Cafedra:
						param.Add("cafedraId", entityId);
						return param;
					case InstituteEntity.Direction:
						param.Add("directionId", entityId);
						return param;
					case InstituteEntity.Group:
						param.Add("groupId", entityId);
						return param;
					case InstituteEntity.Course:
						param.Add("courseId", entityId);
						return param;
				}
			}

			return param;
		}

		private DynamicTvpParameters GetStudentGroupParam(int studentId, int groupId)
		{
			var param = new DynamicTvpParameters();
			var tvp = new TableValuedParameter("studentGroup", "UDT_Student_Group");
			var udt = new StudentGroupUdt()
			{
				StudentId = studentId,
				GroupId = groupId
			};
			tvp.AddObjectAsRow(udt);
			param.Add(tvp);

			return param;
		}
	}
}