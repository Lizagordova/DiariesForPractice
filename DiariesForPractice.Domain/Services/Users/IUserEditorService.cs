using System.Collections.Generic;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Users
{
    public interface IUserEditorService
    {
        IReadOnlyCollection<int> AddOrUpdateUsers(IReadOnlyCollection<User> users);
        int AddOrUpdateUser(User student);
    }
}