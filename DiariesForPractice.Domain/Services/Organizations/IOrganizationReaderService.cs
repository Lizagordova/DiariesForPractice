using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Organizations
{
	public interface IOrganizationReaderService
	{
		IReadOnlyCollection<Organization> GetOrganizations();
	}
}