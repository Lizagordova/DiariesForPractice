using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Students
{
	public interface IStudentEditorService
	{
		IReadOnlyCollection<int> AddOrUpdateStudents(IReadOnlyCollection<Student> students, int groupId);
		int AddOrUpdateStudent(Student student, int groupId);
	}
}