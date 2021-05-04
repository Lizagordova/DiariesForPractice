using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
	public interface IStudentRepository
	{
		int AddOrUpdateStudent( student);
		void AttachStudentToGroup(int studentId, int groupId);
		List<Student> GetStudents();
		List<Student> GetStudentsByIds(List<int> studentIds);
	}
}