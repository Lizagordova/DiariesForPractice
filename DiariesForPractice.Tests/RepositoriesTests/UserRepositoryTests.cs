using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.MapperService;
using NUnit.Framework;

namespace DiariesForPractice.Tests.RepositoriesTests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private readonly UserRepository _userRepository;
        
        public UserRepositoryTests()
        {
            var mapperService = new MapperService();
            _userRepository = new UserRepository(mapperService);
        }
    }
}