using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Organizations;

namespace DiariesForPractice.Persistence.Services.Organizations
{
	public class OrganizationEditorService : IOrganizationEditorService
	{
		private readonly IOrganizationRepository _organizationRepository;
		private readonly IPracticeRepository _practiceRepository;
		public OrganizationEditorService(
			IOrganizationRepository organizationRepository,
			IPracticeRepository practiceRepository)
		{
			_organizationRepository = organizationRepository;
			_practiceRepository = practiceRepository;
		}

		public int AddOrUpdateOrganization(Organization organization)
		{
			var organizationId = _organizationRepository.AddOrUpdateOrganization(organization);

			return organizationId;
		}

		public int AddOrUpdateStaff(Staff staff, int practiceDetailsId)
		{
			var staffId = _organizationRepository.AddOrUpdateStaff(staff);
			if (staff.Role == StaffRole.Responsible)
			{
				_practiceRepository.AttachDataToPracticeDetails(staffId, practiceDetailsId, PracticeDetailsDataType.ResponsibleForStudent);

			}
			else if (staff.Role == StaffRole.SignsTheContract)
			{
				_practiceRepository.AttachDataToPracticeDetails(staffId, practiceDetailsId, PracticeDetailsDataType.SignsTheContract);
			}
			return staffId;
		}
	}
}