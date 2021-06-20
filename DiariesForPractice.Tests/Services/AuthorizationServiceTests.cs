﻿using System;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.Authorization;
using DiariesForPractice.Persistence.Services.MapperService;
using NUnit.Framework;

namespace DiariesForPractice.Tests.Services
{
    [TestFixture]
    public class AuthorizationServiceTests
    {
        private readonly AuthorizationService _authorizationService;
        
        public AuthorizationServiceTests()
        {
            var mapper = new MapperService();
            var userRepository = new UserRepository(mapper);
            _authorizationService = new AuthorizationService(userRepository);
        }

        [Test]
        public void Register_Test()
        {
            var user = new User()
            {
                FirstName = "Леша",
                Login = "leshamakarov",
                SecondName = "Евгеньевич",
                LastName = "Макаров",
                Email = "lesha@gmail.com",
                Phone = "89237484299",
                Token = "4837ygrb4sdjflk",
                Password = "lesha",
                EmailConfirmed = true
            };
            var userId = _authorizationService.Register(user);
            var result = userId != 0;
            Console.WriteLine($"userId={userId}");
            Assert.That(result == true);
        }
    }
}