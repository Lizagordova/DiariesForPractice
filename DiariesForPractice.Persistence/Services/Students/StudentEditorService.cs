using System.Collections.Generic;
using System.Linq;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Students;

namespace DiariesForPractice.Persistence.Services.Students
{
	public class StudentEditorService : IStudentEditorService
	{
		private readonly IStudentRepository _studentRepository;
		public StudentEditorService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}

		public IReadOnlyCollection<int> AddOrUpdateStudents(IReadOnlyCollection<Domain.Models.Student> students, int groupId)
		{
			return students.Select(student => AddOrUpdateStudent(student, groupId)).ToList();
		}

		public int AddOrUpdateStudent(Student student, int groupId)
		{
			var studentId = _studentRepository.AddOrUpdateStudent(student);
			_studentRepository.AttachStudentToGroup(studentId, groupId);

			return studentId;
		}
	}
}