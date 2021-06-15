using System;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.Diaries;
using DiariesForPractice.Persistence.Services.MapperService;
using NUnit.Framework;

namespace DiariesForPractice.Tests.Services
{
    [TestFixture]
    public class DiaryServiceTests
    {
        private readonly DiariesEditorService _diariesEditor;
        private readonly DiariesReaderService _diariesReader;
        
        public DiaryServiceTests()
        {
            var mapper = new MapperService();
            var diariesRepository = new DiariesRepository(mapper);
            _diariesEditor = new DiariesEditorService(diariesRepository);
            _diariesReader = new DiariesReaderService(diariesRepository);
        }
        
        [Test]
        public void AddOrUpdateDiary_Test()
        {
            var diary = new Diary()
            {
                Student = new User() { Id = 1 },
                Path = @"C:\books\storage-concepts-storing-and-managing-digital-data.pdf",
                Generated = true,
                Send = false,
                Perceived = false,
                SendDate = DateTime.Now,
                GeneratedDate = DateTime.Now,
                Comment = "Заполни дневник тварь"
                
            };
            var diaryId = _diariesEditor.AddOrUpdateDiary(diary);
            var result = diaryId != 0;
            Console.WriteLine($"diaryId={diaryId}");
            Assert.That(result == true);
        }
    }
}