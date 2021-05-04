using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
    public interface ILogRepository
    {
        void AddLog(Log log);
    }
}