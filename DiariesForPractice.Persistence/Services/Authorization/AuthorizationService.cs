using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Authorization;
using DiariesForPractice.Persistence.Helpers;

namespace DiariesForPractice.Persistence.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;
        
        public AuthorizationService(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public int Authorize(User user)
        {
            user.Password = user.Password.GetPasswordHash();
            var userId = _userRepository.Authorize(user);

            return userId;
        }

        public int Register(User user)
        {
            user.Password = user.Password.GetPasswordHash();
            var userId = _userRepository.AddOrUpdateUser(user);

            return userId;
        }
    }
}