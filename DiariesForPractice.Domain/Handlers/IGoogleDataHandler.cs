using System.Collections.Generic;
using DiariesForPractice.Domain.Models.Data;

namespace DiariesForPractice.Domain.Handlers
{
	public interface IGoogleDataHandler
	{
		void HandlerGoogleData(IReadOnlyCollection<GoogleStudentPracticeData> data, int groupId);
	}
}