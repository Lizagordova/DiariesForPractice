using System;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.MapperService;
using DiariesForPractice.Persistence.Services.Organizations;
using DiariesForPractice.Persistence.Services.PracticeDetail;
using NUnit.Framework;

namespace DiariesForPractice.Tests.Services
{
    public class PracticeTests
    {
        private readonly PracticeEditorService _practiceEditor;
        private readonly PracticeReaderService _practiceReader;
        public PracticeTests()
        {
            var mapper = new MapperService();
            var practiceRepository = new PracticeRepository(mapper);
            _practiceEditor = new PracticeEditorService(practiceRepository);
            _practiceReader = new PracticeReaderService(practiceRepository);

        }
        
        [Test]
        public void AddOrUpdateOrganization_Test()
        {
            var practiceDetails = new PracticeDetails()
            {
                
            };
            var organizationId = _practiceEditor.AddOrUpdatePracticeDetails(practiceDetails);
            var result = organizationId != 0;
            Console.WriteLine($"organizationId={organizationId}");
            Assert.That(result == true);
        }
    }
}