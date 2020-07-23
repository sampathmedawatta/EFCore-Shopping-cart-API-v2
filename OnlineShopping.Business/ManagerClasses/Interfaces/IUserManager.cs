﻿using OnlineShopping.Common;
using OnlineShopping.Entity.Models.User;
using System.Threading.Tasks;

namespace OnlineShopping.Business.ManagerClasses.Interfaces
{
    public interface IUserManager
    {
        Task<OperationResult> CreateUserAsunc(CustomerDto customerDto);
        OperationResult GetAllUsersAsunc();
    }
}
