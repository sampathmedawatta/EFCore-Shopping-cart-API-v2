using AutoMapper;
using OnlineShopping.Data.Entity;
using OnlineShopping.Entity.Models.User;
using System;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Data
{
    public class UserData : BaseData
    {
        private readonly IMapper _mapper;

        public UserData(string applicationConfiguration, IMapper mapper) : base(applicationConfiguration)
        {
            _mapper = mapper;
        }

        public async Task<bool> CreateUserAsunc(UserCreateDto userCreateDto)
        {
            var customerEntry = _mapper.Map<UserCreateDto, CustomerEntry>(userCreateDto);
            customerEntry.RegisteredDate = DateTime.UtcNow;
            customerEntry.CustomerRoleId = Guid.Parse("F9B8A3F4-736E-484E-B2F7-08763339F95C");
            customerEntry.IsActive = true;

            var customerPasswordEntry = _mapper.Map<UserRegisterDto, CustomerPasswordEntry>(userCreateDto);
            customerPasswordEntry.CustomerId = customerEntry.Id;
            customerPasswordEntry.PasswordFormatId = 1;
            customerPasswordEntry.PasswordSalt = "1";
            customerPasswordEntry.Customer = customerEntry;

            int execRows = await UserPasswordRepository.Insert(customerPasswordEntry);

            if (execRows > 0)
            {
                return true;
            }

            return false;

        }
    }
}
