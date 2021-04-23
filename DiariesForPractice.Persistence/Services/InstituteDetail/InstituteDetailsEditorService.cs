using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.InstituteDetails;

namespace DiariesForPractice.Persistence.Services.InstituteDetail
{
	public class InstituteDetailsEditorService : IInstituteDetailsEditorService
	{
		private readonly IInstituteDetailsRepository _instituteDetailsRepository;
		public InstituteDetailsEditorService(
			IInstituteDetailsRepository instituteDetailsRepository)
		{
			_instituteDetailsRepository = instituteDetailsRepository;
		}

		public int AddOrUpdateInstitute(Institute institute)
		{
			var instituteId = _instituteDetailsRepository.AddOrUpdateInstitute(institute);

			return instituteId;
		}

		public int AddOrUpdateCafedra(Cafedra cafedra)
		{
			var cafedraId = _instituteDetailsRepository.AddOrUpdateCafedra(cafedra);

			return cafedraId;
		}

		public int AddOrUpdateDirection(Direction direction)
		{
			var directionId = _instituteDetailsRepository.AddOrUpdateDirection(direction);

			return directionId;
		}

		public int AddOrUpdateGroup(Group group)
		{
			var groupId = _instituteDetailsRepository.AddOrUpdateGroup(group);

			return groupId;
		}

		public int AddOrUpdateCourse(Course course, int degreeId)
		{
			var courseId = _instituteDetailsRepository.AddOrUpdateCourse(course, degreeId);

			return courseId;
		}

		public int AddOrUpdateDegree(Degree degree)
		{
			var degreeId = _instituteDetailsRepository.AddOrUpdateDegree(degree);

			return degreeId;
		}
	}
}