using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Organizations;

namespace DiariesForPractice.Persistence.Services.Organizations
{
	public class OrganizationEditorService : IOrganizationEditorService
	{
		private readonly IOrganizationRepository _organizationRepository;
		public OrganizationEditorService(
			IOrganizationRepository organizationRepository)
		{
			_organizationRepository = organizationRepository;
		}

		public int AddOrUpdateOrganization(Organization organization)
		{
			var organizationId = _organizationRepository.AddOrUpdateOrganization(organization);

			return organizationId;
		}

		public int AddOrUpdateStaff(Staff staff)
		{
			var staffId = _organizationRepository.AddOrUpdateStaff(staff);

			return staffId;
		}
	}
}