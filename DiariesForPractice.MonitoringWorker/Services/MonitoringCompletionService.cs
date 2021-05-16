using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;

namespace DiariesForPractice.MonitoringWorker.Services
{
    public class MonitoringCompletionService
    {
        private readonly IInstituteDetailsRepository _instituteDetailsRepository; 
        public MonitoringCompletionService(
            IInstituteDetailsRepository instituteDetailsRepository)
        {
            _instituteDetailsRepository = instituteDetailsRepository;
        }

        public void Monitor()
        {
            var groups = _instituteDetailsRepository.GetGroups();
            foreach (var group in groups)
            {
                MonitorGroup(group);
            }
        }

        public void MonitorGroup(Group group)
        {
            var message = GenerateMessageForTeacher();
        }

        private string GenerateMessageForTeacher()
        {
            var message = "";
            return message;
        }
    }
}