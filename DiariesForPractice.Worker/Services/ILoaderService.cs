using System.Collections.Generic;

namespace DiariesForPractice.Worker.Services
{
	public interface ILoaderService
	{
		IReadOnlyCollection<string> GetData();
	}
}