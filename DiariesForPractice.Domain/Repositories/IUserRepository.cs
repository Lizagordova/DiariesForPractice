﻿using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
    }
}