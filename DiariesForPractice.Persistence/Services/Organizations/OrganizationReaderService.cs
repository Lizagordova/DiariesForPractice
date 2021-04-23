using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Organizations;

namespace DiariesForPractice.Persistence.Services.Organizations
{
	public class OrganizationReaderService : IOrganizationReaderService
	{
		private readonly IOrganizationRepository _organizationRepository;
		public OrganizationReaderService(
			IOrganizationRepository organizationRepository)
		{
			_organizationRepository = organizationRepository;
		}

		public IReadOnlyCollection<Organization> GetOrganizations()
		{
			var organizations = _organizationRepository.GetOrganizations();

			return organizations;
		}
	}
}