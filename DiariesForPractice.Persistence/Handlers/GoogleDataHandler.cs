using System.Collections.Generic;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Handlers;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Models.Data;
using DiariesForPractice.Domain.Services.Diaries;
using DiariesForPractice.Domain.Services.Organizations;
using DiariesForPractice.Domain.Services.PracticeDetail;
using DiariesForPractice.Domain.Services.Students;

namespace DiariesForPractice.Persistence.Handlers
{
	public class GoogleDataHandler : IGoogleDataHandler
	{
		private readonly IStudentEditorService _studentEditor;
		private readonly IOrganizationEditorService _organizationEditor;
		private readonly IPracticeEditorService _practiceEditor;
		private readonly IDiariesEditorService _diariesEditor;

		public GoogleDataHandler(
			IStudentEditorService studentEditor,
			IOrganizationEditorService organizationEditor,
			IPracticeEditorService practiceEditor,
			IDiariesEditorService diariesEditor)
		{
			_studentEditor = studentEditor;
			_organizationEditor = organizationEditor;
			_practiceEditor = practiceEditor;
			_diariesEditor = diariesEditor;
		}

		public void HandlerGoogleData(IReadOnlyCollection<GoogleStudentPracticeData> data, int groupId)
		{
			foreach (var element in data)
			{
				var studentId = AddOrUpdateStudent(element, groupId);
				var organizationId = AddOrUpdateOrganization(element);
				var responsibleId = AddOrUpdateStaff(element, StaffRole.Responsible, organizationId);
				var signsTheContractId = AddOrUpdateStaff(element, StaffRole.Responsible, organizationId);
				AddOrUpdatePracticeDetails(element, organizationId, responsibleId, signsTheContractId, studentId);
				AddOrUpdateDiary(studentId);
			}
		}

		private int AddOrUpdateStudent(GoogleStudentPracticeData data, int groupId)
		{
			var student = MapStudent(data);
			var studentId = _studentEditor.AddOrUpdateStudent(student, groupId);

			return studentId;
		}

		private Student MapStudent(GoogleStudentPracticeData data)
		{
			var studentPersonalData = data.FullName.Split(" ");
			var student = new Student()
			{
				FirstName = studentPersonalData[0] ?? "",
				SecondName = studentPersonalData[1] ?? "",
				LastName = studentPersonalData[2] ?? "",
				Email = data.Email,
				Phone = data.Phone
			};

			return student;
		}

		private int AddOrUpdateOrganization(GoogleStudentPracticeData data)
		{
			var organization = new Organization()
			{
				Name = data.OrganizationName,
				LegalAddress = data.LegalAddress
			};
			var organizationId = _organizationEditor.AddOrUpdateOrganization(organization);

			return organizationId;
		}

		private int AddOrUpdateStaff(GoogleStudentPracticeData data, StaffRole staffRole, int organizationId)
		{
			var staffData = new string[0];
			switch (staffRole)
			{
				case StaffRole.Responsible:
					staffData = data.ResponsibleForStudent.Split(",");
					break;
				case StaffRole.SignsTheContract:
					staffData = data.SignsTheContract.Split(",");
					break;
			}

			var staff = new Staff()
			{
				OrganizationId = organizationId,
				FullName = staffData[0] ?? "",
				Job = staffData[1] ?? "",
				Email = staffData[2] ?? "",
				Phone = staffData[3] ?? ""
			};

			var staffId = _organizationEditor.AddOrUpdateStaff(staff);

			return staffId;
		}

		private void AddOrUpdatePracticeDetails(GoogleStudentPracticeData data, int organizationId, int responsibleId, int signsTheContractId, int studentId)
		{
			var practiceDetails = new PracticeDetails()
			{
				OrganizationId = organizationId,
				ReportingForm = data.ReportingForm,
				ContractNumber = data.ContractNumber,
				ResponsibleForStudent = responsibleId,
				SignsTheContract = signsTheContractId,
				StudentId = studentId
			};
			_practiceEditor.AddOrUpdatePracticeDetails(practiceDetails);
		}

		private void AddOrUpdateDiary(int studentId)
		{
			_diariesEditor.GenerateDiary(studentId);
		}
	}
}