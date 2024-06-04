﻿using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Dtos;

namespace PeopleSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserDto user);
        User ReadUserById(int id);
    }
}