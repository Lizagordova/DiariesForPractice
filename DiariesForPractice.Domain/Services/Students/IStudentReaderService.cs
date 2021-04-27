using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Students
{
	public interface IStudentReaderService
	{
		List<Student> GetStudents();
	}
}