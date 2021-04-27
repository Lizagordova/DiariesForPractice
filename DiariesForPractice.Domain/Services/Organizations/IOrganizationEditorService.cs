using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Organizations
{
	public interface IOrganizationEditorService
	{
		int AddOrUpdateOrganization(Organization organization);
		int AddOrUpdateStaff(Staff staff);
	}
}