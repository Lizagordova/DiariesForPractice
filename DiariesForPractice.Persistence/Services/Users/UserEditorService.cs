using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Users;

namespace DiariesForPractice.Persistence.Services.Users
{
    public class UserEditorService : IUserEditorService
    {
        private readonly IUserRepository _userRepository;

        public UserEditorService(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public IReadOnlyCollection<int> AddOrUpdateUsers(IReadOnlyCollection<User> users)
        {
            var userIds = new List<int>();
            foreach (var user in users)
            {
                var userId = AddOrUpdateUser(user);
                userIds.Add(userId);
            }

            return userIds;
        }

        public int AddOrUpdateUser(User user)
        {
            var userId = _userRepository.AddOrUpdateUser(user);

            return userId;
        }
    }
}