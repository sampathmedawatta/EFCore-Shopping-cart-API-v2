﻿using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Interfaces.Repository;

namespace OnlineShopping.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepository<CustomerEntry>
    {
    }
}
