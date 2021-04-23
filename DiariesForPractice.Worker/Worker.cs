using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiariesForPractice.Worker.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Worker
{
	public class LoaderWorker : BackgroundService
	{
		private readonly ILogger<LoaderWorker> _logger;
		private readonly ILoaderService _loader;

		public LoaderWorker(
			ILogger<LoaderWorker> logger,
			ILoaderService loader)
		{
			_logger = logger;
			_loader = loader;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
				Console.WriteLine("Worker running at: {0}", DateTimeOffset.Now);
			//	_loader.GetData();
				await Task.Delay(1000000000, stoppingToken);
			}
		}
	}
}