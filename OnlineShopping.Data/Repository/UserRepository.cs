﻿using AutoMapper;
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
    public class UserRepository : IUserRepository<CustomerDto>
    {
        private readonly OnlineShoppingContext context;
        private readonly DbSet<CustomerEntry> table;
        private readonly IMapper _mapper;

        public UserRepository(OnlineShoppingContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<CustomerEntry>();
            _mapper = mapper;
        }

        public async Task<int> Insert(CustomerDto entity)
        {

            CustomerPasswordEntry customerPasswordEntry;
            customerPasswordEntry = _mapper.Map<UserDto, CustomerPasswordEntry>(entity);

            this.context.Set<CustomerPasswordEntry>().Add(customerPasswordEntry);
            int excecutedRows = await this.context.SaveChangesAsync();

            entity.Id = customerPasswordEntry.CustomerId;

            return excecutedRows;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }



        public void Update(CustomerDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
