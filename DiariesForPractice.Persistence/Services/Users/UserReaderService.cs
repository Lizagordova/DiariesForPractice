using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Users;

namespace DiariesForPractice.Persistence.Services.Users
{
    public class UserReaderService : IUserReaderService
    {
        private readonly IUserRepository _userRepository;
        
        public UserReaderService(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public User GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);

            return user;
        }
    }
}