using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiariesForPractice.DiariesGenerator.Generators;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.DiariesGenerator
{
    public class DiaryWorker : BackgroundService
    {
        private readonly ILogger<DiaryWorker> _logger;
        private readonly DiaryGenerator _diaryGenerator;

        public DiaryWorker(ILogger<DiaryWorker> logger,
            DiaryGenerator diaryGenerator)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}