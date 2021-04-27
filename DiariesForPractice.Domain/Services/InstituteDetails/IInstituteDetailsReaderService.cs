using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.InstituteDetails
{
	public interface IInstituteDetailsReaderService
	{
		IReadOnlyCollection<Institute> GetInstitutes();
		IReadOnlyCollection<Cafedra> GetCafedras();
		IReadOnlyCollection<Direction> GetDirections();
		IReadOnlyCollection<Group> GetGroups();
		IReadOnlyCollection<Degree> GetDegrees();
		IReadOnlyCollection<Course> GetCourses();
	}
}