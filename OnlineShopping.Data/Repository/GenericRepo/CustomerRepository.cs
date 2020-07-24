using AutoMapper;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Entity;
using OnlineShopping.Entity.Models.User;

namespace OnlineShopping.Data.Repository.GenericRepo
{
    public class CustomerRepository : GenericRepository<CustomerEntry, UserGenericDto>
    {

        public CustomerRepository(OnlineShoppingContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }

}
