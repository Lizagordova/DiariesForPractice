using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
	public interface IOrganizationRepository
	{
		int AddOrUpdateOrganization(Organization organization);
		int AddOrUpdateStaff(Staff staff);
		IReadOnlyCollection<Organization> GetOrganizations();
	}
}