using System;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.MapperService;
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
            _practiceReader = new PracticeReaderService(practiceRepository,
                new OrganizationRepository(mapper),
                new StudentCharacteristicRepository(mapper),
                new StudentTaskRepository(mapper),
                new CalendarPlanRepository(mapper));
        }
        
        [Test]
        public void AddOrUpdatePracticeDetails_Test()
        {
            var practiceDetails = new PracticeDetails()
            {
                Student = new User() { Id = 1 },
                Organization = new Organization() { Id = 1 },
                ReportingForm = ReportingForm.Dogovor,
                ContractNumber = "123456789",
                PracticeType = PracticeType.Production,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(25),
                StructuralDivision = "Android development",
                
            };
            var practiceDetailsId = _practiceEditor.AddOrUpdatePracticeDetails(practiceDetails);
            var result = practiceDetailsId != 0;
            Console.WriteLine($"practiceDetailsId={practiceDetailsId}");
            Assert.That(result == true);
        }
        
        [Test]
        public void GetPracticeDetails_Test()
        {
            var practiceDetails = _practiceReader.GetPracticeDetails(1);
            Console.WriteLine($"practiceDetailsId={practiceDetails.Id}, {practiceDetails.StartDate};{practiceDetails.StructuralDivision}");
        }
    }
}