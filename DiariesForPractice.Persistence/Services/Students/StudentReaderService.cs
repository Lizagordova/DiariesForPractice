using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Students;

namespace DiariesForPractice.Persistence.Services.Students
{
	public class StudentReaderService : IStudentReaderService
	{
		private readonly IStudentRepository _studentRepository;
		public StudentReaderService(
			IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}

		public List<Student> GetStudents()
		{
			var students = _studentRepository.GetStudents();

			return students;
		}
	}
}