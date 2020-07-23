using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;
using OnlineShopping.Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class UserRepository : IUserRepository<UserDto>
    {

        private readonly DbSet<CustomerEntry> table;
        private readonly IMapper _mapper;

        public UserRepository(OnlineShoppingContext context, IMapper mapper)
        {

            table = context.Set<CustomerEntry>();
            _mapper = mapper;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
