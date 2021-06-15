using System;
using System.Collections.Generic;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Queries;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.PracticeDetail;

namespace DiariesForPractice.Persistence.Services.PracticeDetail
{
	public class PracticeReaderService : IPracticeReaderService
	{
		private readonly IPracticeRepository _practiceRepository;
		private readonly IOrganizationRepository _organizationRepository;
		private readonly IStudentCharacteristicRepository _studentCharacteristicRepository;
		private readonly IStudentTaskRepository _studentTaskRepository;
		private readonly ICalendarPlanRepository _calendarPlanRepository;
		public PracticeReaderService(
			IPracticeRepository practiceRepository,
			IOrganizationRepository organizationRepository,
			IStudentCharacteristicRepository studentCharacteristicRepository,
			IStudentTaskRepository studentTaskRepository,
			ICalendarPlanRepository calendarPlanRepository)
		{
			_practiceRepository = practiceRepository;
			_organizationRepository = organizationRepository;
			_studentCharacteristicRepository = studentCharacteristicRepository;
			_studentTaskRepository = studentTaskRepository;
			_calendarPlanRepository = calendarPlanRepository;
		}

		public IReadOnlyCollection<PracticeDetails> GetPracticeDetails(PracticeDetailsQuery query)
		{
			var practiceDetails = _practiceRepository.GetPracticeDetails(query);

			return practiceDetails;
		}

		public PracticeDetails GetPracticeDetails(int studentId)
		{
			var practiceDetails = _practiceRepository.GetPracticeDetails(studentId);
			if (practiceDetails == null || practiceDetails.Id == 0)
			{
				practiceDetails = new PracticeDetails()
				{
					Student = new User() { Id = studentId },
					StartDate = DateTime.Now,
					EndDate = DateTime.Now
				};
				practiceDetails.Id = _practiceRepository.AddOrUpdatePracticeDetails(practiceDetails);
			}

			practiceDetails.Organization = _organizationRepository.GetOrganization(practiceDetails.Organization.Id);
			practiceDetails.ResponsibleForStudent = _organizationRepository.GetStaff(practiceDetails.ResponsibleForStudent.Id);
			practiceDetails.SignsTheContract = _organizationRepository.GetStaff(practiceDetails.SignsTheContract.Id);
			practiceDetails.CalendarPlan = _calendarPlanRepository.GetCalendarPlan(practiceDetails.CalendarPlan.Id);
			practiceDetails.StudentCharacteristic = _studentCharacteristicRepository.GetStudentCharacteristic(practiceDetails.Student.Id);
			practiceDetails.StudentTask = _studentTaskRepository.GetStudentTask(practiceDetails.Student.Id);

			return practiceDetails;
		}
	}
}