using System;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.MapperService;
using DiariesForPractice.Persistence.Services.StudentCharacteristics;
using NUnit.Framework;

namespace DiariesForPractice.Tests.Services
{
    [TestFixture]
    public class StudentCharacteristicServicesTests
    {
        private readonly StudentCharacteristicsEditor _studentCharacteristicsEditor;
        private readonly StudentCharacteristicsReader _studentCharacteristicsReader;
        
        public StudentCharacteristicServicesTests()
        {
            var mapper = new MapperService();
            var practiceRepository = new StudentCharacteristicRepository(mapper);
            _studentCharacteristicsEditor = new StudentCharacteristicsEditor(practiceRepository);
            _studentCharacteristicsReader = new StudentCharacteristicsReader(practiceRepository);
        }

        [Test]
        public void AddOrUpdateStudentCharacteristic_Test()
        {
            var studentCharacteristic = new StudentCharacteristic()
            {
                StudentId = 1,
                DescriptionByHead = "Всё прошло хорошо: катались на теплоходах",
                DescriptionByCafedraHead = "Ну в целом ок",
                MissedDaysWithReason = 5,
                MissedDaysWithoutReason = 15
            };
            var studentCharacteristicId = _studentCharacteristicsEditor.AddOrUpdateStudentCharacteristic(studentCharacteristic, 1);
            var result = studentCharacteristicId != 0;
            Console.WriteLine($"studentCharacteristicId={studentCharacteristicId}");
            Assert.That(result == true);
        }
        
        [Test]
        public void GetStudentCharacteristic_Test()
        {
            var studentCharacteristic = _studentCharacteristicsReader.GetStudentCharacteristic(1);
            Console.WriteLine($"Id={studentCharacteristic.Id};StudentId={studentCharacteristic.StudentId};DescriptionByCafedraHead={studentCharacteristic.DescriptionByCafedraHead};DescriptionByHead={studentCharacteristic.DescriptionByHead}");
        }
    }
}