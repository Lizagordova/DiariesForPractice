﻿using System.Collections.Generic;
using DiariesForPractice.Domain.enums;
using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        List<User> GetUsers();
        int AddOrUpdateUser(User user);
        List<User> GetUsersByIds(List<int> ids);
        int Authorize(User user);
        void AddOrUpdateUserRole(int userId, UserRole userRole);
        UserRole GetUserRole(int userId);
        void RemoveUser(int userId);
    }
}