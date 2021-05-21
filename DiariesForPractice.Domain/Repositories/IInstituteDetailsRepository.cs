using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
	public interface IInstituteDetailsRepository
	{
		int AddOrUpdateInstitute(Institute institute);
		int AddOrUpdateCafedra(Cafedra cafedra);
		int AddOrUpdateDirection(Direction direction);
		int AddOrUpdateGroup(Group @group);
		int AddOrUpdateCourse(Course course, int degreeId);
		int AddOrUpdateDegree(Degree degree);
		IReadOnlyCollection<Institute> GetInstitutes();
		IReadOnlyCollection<Cafedra> GetCafedras(int? instituteId = null);
		IReadOnlyCollection<Direction> GetDirections(int? cafedraId = null);
		IReadOnlyCollection<Group> GetGroups(int? directionId = null);
		IReadOnlyCollection<Degree> GetDegrees();
		IReadOnlyCollection<Course> GetCourses(int? degreeId = null);
		Institute GetInstitute(int instituteId);
		Cafedra GetCafedra(int cafedraId);
		Direction GetDirection(int directionId);
		Group GetGroup(int groupId);
		Course GetCourse(int courseId);
		Degree GetDegree(int degreeId);
	}
}