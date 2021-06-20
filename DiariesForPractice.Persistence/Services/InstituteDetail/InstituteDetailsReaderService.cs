using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.InstituteDetails;

namespace DiariesForPractice.Persistence.Services.InstituteDetail
{
	public class InstituteDetailsReaderService : IInstituteDetailsReaderService
	{
		private readonly IInstituteDetailsRepository _instituteDetailsRepository;
		public InstituteDetailsReaderService(
			IInstituteDetailsRepository instituteDetailsRepository)
		{
			_instituteDetailsRepository = instituteDetailsRepository;
		}

		public IReadOnlyCollection<Institute> GetInstitutes()
		{
			var institutes = _instituteDetailsRepository.GetInstitutes();
			foreach (var institute in institutes)
			{
				institute.Cafedras = _instituteDetailsRepository.GetCafedras(institute.Id);
			}

			return institutes;
		}

		public IReadOnlyCollection<Cafedra> GetCafedras()
		{
			var cafedras = _instituteDetailsRepository.GetCafedras();
			foreach (var cafedra in cafedras)
			{
				cafedra.Directions = _instituteDetailsRepository.GetDirections(cafedra.Id);
			}

			return cafedras;
		}

		public IReadOnlyCollection<Direction> GetDirections()
		{
			var directions = _instituteDetailsRepository.GetDirections();
			foreach (var direction in directions)
			{
				direction.Groups = _instituteDetailsRepository.GetGroups(direction.Id);
			}

			return directions;
		}

		public IReadOnlyCollection<Group> GetGroups()
		{
			var groups = _instituteDetailsRepository.GetGroups();
			foreach (var group in groups)
			{
				group.Students = _instituteDetailsRepository.GetStudents(group.Id);
			}
			

			return groups;
		}

		public IReadOnlyCollection<Degree> GetDegrees()
		{
			var degrees = _instituteDetailsRepository.GetDegrees();
			foreach (var degree in degrees)
			{
				degree.Courses = _instituteDetailsRepository.GetCourses(degree.Id);
			}

			return degrees;
		}

		public IReadOnlyCollection<Course> GetCourses()
		{
			var courses = _instituteDetailsRepository.GetCourses();

			return courses;
		}

		public Institute GetInstitute(int instituteId)
		{
			return _instituteDetailsRepository.GetInstitute(instituteId);
		}

		public Cafedra GetCafedra(int cafedraId)
		{
			return _instituteDetailsRepository.GetCafedra(cafedraId);
		}

		public Direction GetDirection(int directionId)
		{
			return _instituteDetailsRepository.GetDirection(directionId);
		}

		public Group GetGroup(int groupId)
		{
			return _instituteDetailsRepository.GetGroup(groupId);
		}

		public Course GetCourse(int courseId)
		{
			return _instituteDetailsRepository.GetCourse(courseId);
		}

		public Degree GetDegree(int degreeId)
		{
			return _instituteDetailsRepository.GetDegree(degreeId);
		}
	}
}