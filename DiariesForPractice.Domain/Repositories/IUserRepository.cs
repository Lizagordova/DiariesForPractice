using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        List<User> GetUsers();
    }
}