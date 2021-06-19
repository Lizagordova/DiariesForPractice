using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using DiariesForPractice.DiaryGenerator.Generators;

namespace DiariesForPractice.DiaryGenerator
{
    public class DiaryWorker : BackgroundService
    {
        private readonly ILogger<DiaryWorker> _logger;
        private readonly IDiaryGenerator _diaryGenerator;

        public DiaryWorker(ILogger<DiaryWorker> logger,
            IDiaryGenerator diaryGenerator)
        {
            _logger = logger;
            _diaryGenerator = diaryGenerator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _diaryGenerator.GenerateDiaries();  
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
