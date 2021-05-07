using System.Collections.Generic;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.Services.MapperService;

namespace DiariesForPractice.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string GetUserByIdSp = "UserRepository_GetUserById";
        private const string GetUsersSp = "UserRepository_GetUsers";
        private readonly MapperService _mapper;
        public UserRepository(
            MapperService mapper
            )
        {
            _mapper = mapper;
        }
        
        public User GetUserById(int userId)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public int AddOrUpdateUser(User student)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetUsersByIds(List<int> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}