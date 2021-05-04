using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Users
{
    public interface IUserReaderService
    {
        User GetUserById(int userId);
    }
}