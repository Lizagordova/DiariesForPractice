using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.MapperService;
using DiariesForPractice.Persistence.Services.Organizations;
using NUnit.Framework;

namespace DiariesForPractice.Tests.Services
{
    [TestFixture]
    public class OrganizationServicesTests
    {
        private readonly OrganizationReaderService _organizationReader;
        private readonly OrganizationEditorService _organizationEditor;
        
        public OrganizationServicesTests()
        {
            var mapper = new MapperService();
            var organizationRepository = new OrganizationRepository(mapper);
            var practiceRepository = new PracticeRepository(mapper);
            _organizationReader = new OrganizationReaderService(organizationRepository);
            _organizationEditor = new OrganizationEditorService(organizationRepository, practiceRepository);
        }
        
        [Test]
        public void AddOrUpdateOrganization_Test()
        {
            var organization = new Organization()
            {
                Name = "Яндекс",
                LegalAddress = "Москва"
            };
            var organizationId = _organizationEditor.AddOrUpdateOrganization(organization, 1);
            var result = organizationId != 0;
            Console.WriteLine($"organizationId={organizationId}");
            Assert.That(result == true);
        }
        
        [Test]
        public void AddOrUpdateStaff_Test()
        {
            var staff = new Staff()
            {
                OrganizationId = 1,
                Email = "fromAbuDabi@gmail.com",
                FullName = "Иванов Иван Иванович",
                Job = "Директор нефтяной компании",
                Phone = "83938204943",
                Role = StaffRole.Responsible
            };
            var staffId = _organizationEditor.AddOrUpdateStaff(staff, 1);
            var result = staffId != 0;
            Console.WriteLine($"staffId={staffId}");
            Assert.That(result == true);
        }

        [Test]
        public void GetOrganizations_Test()
        {
            var organizations = _organizationReader.GetOrganizations();
            foreach (var organization in organizations)
            {
                Console.WriteLine($"Id={organization.Id};Name={organization.Name};LegalAddress={organization.LegalAddress}");
            }
        }
    }
}