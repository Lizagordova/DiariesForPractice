using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Users
{
    public interface IUserReaderService
    {
        User GetUserById(int userId);
        List<User> GetUsers();
        List<User> GetUsersByIds(List<int> ids);
    }
}