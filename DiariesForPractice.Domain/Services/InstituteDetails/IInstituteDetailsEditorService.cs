using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.InstituteDetails
{
	public interface IInstituteDetailsEditorService
	{
		int AddOrUpdateInstitute(Institute institute);
		int AddOrUpdateCafedra(Cafedra cafedra);
		int AddOrUpdateDirection(Direction direction);
		int AddOrUpdateGroup(Group @group);
		int AddOrUpdateCourse(Course course, int degreeId);
		int AddOrUpdateDegree(Degree degree);
		void AttachStudentToGroup(int studentId, int groupId);
	}
}