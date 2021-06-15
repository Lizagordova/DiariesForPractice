using System;
using System.Collections.Generic;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.MapperService;
using DiariesForPractice.Persistence.Services.Users;
using NUnit.Framework;

namespace DiariesForPractice.Tests.Services.Users
{
    public class UsersReaderServiceTests
    {
        private readonly UserReaderService _userReader;
        
        public UsersReaderServiceTests()
        {
            var mapper = new MapperService();
            var userRepository = new UserRepository(mapper);
            _userReader = new UserReaderService(userRepository);
        }

        [Test]
        public void GetUserById_Test()
        {
            var user = _userReader.GetUserById(1);
            Console.WriteLine($"Id={user.Id}; FullName={user.FullName}; Email={user.Email}; Login={user.Login}");
        }
        
        [Test]
        public void GetUsers_Test()
        {
            var users = _userReader.GetUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"Id={user.Id}; FullName={user.FullName}; Email={user.Email}; Login={user.Login}; Role={user.Role}");
            }
        }
        
        [Test]
        public void GetUsersByIds_Test()
        {
            var ids = new List<int>();
            ids.Add(1);
            var users = _userReader.GetUsersByIds(ids);
            foreach (var user in users)
            {
                Console.WriteLine($"Id={user.Id}; FullName={user.FullName}; Email={user.Email}; Login={user.Login}");
            }
        }
    }
}