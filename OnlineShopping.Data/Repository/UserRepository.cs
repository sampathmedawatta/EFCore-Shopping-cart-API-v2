using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Repository.Interfaces;
using OnlineShopping.Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<CustomerDto> GetByIdAsync(Guid id)
        {
            var customer = await table.FindAsync(id);

            return _mapper.Map<CustomerEntry, CustomerDto>(customer);
        }

        public async Task<CustomerDto> GetByEmailAsync(string Email)
        {
            var customer = await table.Where(c => c.Email == Email).FirstOrDefaultAsync();

            return _mapper.Map<CustomerEntry, CustomerDto>(customer);
        }

        public async Task<bool> CheckPasswordAsync(Guid id, string password)
        {
            var customerPassword = await this.context.CustomerPasswords.Where(c => c.CustomerId == id).FirstOrDefaultAsync();
            if (customerPassword == null)
            {
                return false;
            }

            if (!VerifyPassword(password, customerPassword.PasswordHash, customerPassword.PasswordSalt))
                return false;

            return true;
        }

        public async Task<int> Insert(CustomerDto entity)
        {
            CustomerPasswordEntry customerPasswordEntry;
            customerPasswordEntry = _mapper.Map<UserDto, CustomerPasswordEntry>(entity);

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(entity.Password, out passwordHash, out passwordSalt);

            customerPasswordEntry.PasswordHash = passwordHash;
            customerPasswordEntry.PasswordSalt = passwordSalt;

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


        public void Update(CustomerDto entity)
        {
            throw new NotImplementedException();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); // Create hash using password salt.
                for (int i = 0; i < computedHash.Length; i++)
                { // Loop through the byte array
                    if (computedHash[i] != passwordHash[i]) return false; // if mismatch
                }
            }
            return true; //if no mismatches.
        }

    }
}
