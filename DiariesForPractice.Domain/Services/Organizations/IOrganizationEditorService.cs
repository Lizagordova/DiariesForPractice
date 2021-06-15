using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Organizations
{
	public interface IOrganizationEditorService
	{
		int AddOrUpdateOrganization(Organization organization, int practiceDetaislId);
		int AddOrUpdateStaff(Staff staff, int practiceDetailsId);
	}
}