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

			var organization = _organizationRepository.GetOrganization(practiceDetails.Organization.Id);
			var responsibleForStudent = _organizationRepository.GetStaff(practiceDetails.ResponsibleForStudent.Id);
			var signsTheContract = _organizationRepository.GetStaff(practiceDetails.SignsTheContract.Id);
			var calendarPlan = new CalendarPlan();//_calendarPlanRepository.GetCalendarPlan(practiceDetails.CalendarPlan.Id);
			var studentCharacteristic = _studentCharacteristicRepository.GetStudentCharacteristic(practiceDetails.Student.Id);
			var studentTask = _studentTaskRepository.GetStudentTask(practiceDetails.Student.Id);
			practiceDetails.Organization = organization ?? new Organization();
			practiceDetails.ResponsibleForStudent = responsibleForStudent ?? new Staff { Role = StaffRole.Responsible };
			practiceDetails.SignsTheContract = signsTheContract ?? new Staff { Role = StaffRole.SignsTheContract };
			practiceDetails.CalendarPlan = calendarPlan ?? new CalendarPlan();
			practiceDetails.StudentCharacteristic = studentCharacteristic ?? new StudentCharacteristic { StudentId = studentId };
			practiceDetails.StudentTask = studentTask ?? new StudentTask { StudentId = studentId };

			return practiceDetails;
		}
	}
}