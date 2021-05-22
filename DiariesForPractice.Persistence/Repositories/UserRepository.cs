using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DiariesForPractice.Domain.Models;
using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Persistence.DTO.UDT;
using DiariesForPractice.Persistence.Extensions;
using DiariesForPractice.Persistence.Helpers;
using DiariesForPractice.Persistence.Services.MapperService;

namespace DiariesForPractice.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string GetUserByIdSp = "UserRepository_GetUserById";
        private const string GetUsersSp = "UserRepository_GetUsers";
        private const string AddOrUpdateUserSp = "UserRepository_AddOrUpdateUser";
        private const string GetUsersByIdsSp = "UserRepository_GetUsersByIds";
        
        private readonly MapperService _mapper;
        public UserRepository(
            MapperService mapper
            )
        {
            _mapper = mapper;
        }
        
        public User GetUserById(int userId)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = GetIdParam(userId);
            var userUdt = conn
                .Query<UserUdt>(GetUserByIdSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            var user = _mapper.Map<UserUdt, User>(userUdt);
            DatabaseHelper.CloseConnection(conn);

            return user;
        }

        public List<User> GetUsers()
        {
            var conn = DatabaseHelper.OpenConnection();
            var userUdts = conn
                .Query<UserUdt>(GetUsersSp, commandType: CommandType.StoredProcedure)
                .ToList();
            var users = userUdts
                .Select(_mapper.Map<UserUdt, User>)
                .ToList();
            DatabaseHelper.CloseConnection(conn);

            return users;
        }

        public int AddOrUpdateUser(User user)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = GetUserParam(user);
            var userId = conn.
                Query<int>(AddOrUpdateUserSp, param, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
            DatabaseHelper.CloseConnection(conn);

            return userId;
        }

        public List<User> GetUsersByIds(List<int> ids)
        {
            var conn = DatabaseHelper.OpenConnection();
            var param = GetUsersByIdsParam(ids);
            var userUdts = conn
                .Query<UserUdt>(GetUsersByIdsSp, param, commandType: CommandType.StoredProcedure)
                .ToList();
            var users = userUdts.Select(_mapper.Map<UserUdt, User>).ToList();
            DatabaseHelper.CloseConnection(conn);

            return users;
        }

        private DynamicTvpParameters GetUsersByIdsParam(List<int> ids)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("ids", "UDT_Integer");
            var udt = ids.Select(id => new IntegerUdt() {Id = id}).ToList();
            tvp.AddGenericList(udt);
            param.Add(tvp);

            return param;
        }
        
        private DynamicTvpParameters GetUserParam(User user)
        {
            var param = new DynamicTvpParameters();
            var tvp = new TableValuedParameter("user", "UDT_User");
            var udt = _mapper.Map<User, UserUdt>(user);
            tvp.AddObjectAsRow(udt);
            param.Add(tvp);

            return param;
        }

        private DynamicTvpParameters GetIdParam(int userId)
        {
            var param = new DynamicTvpParameters();
            param.Add("userId", userId);

            return param;
        }
    }
}