using OnlineShopping.Entity.Models.Category;
using OnlineShopping.Entity.Models.Product;
using OnlineShopping.Entity.Models.User;
using System;

namespace OnlineShopping.Data.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository<ProductDto> Products { get; }
        ICategoryRepository<CategoryDto> Categories { get; }
        IUserRepository<CustomerDto> Users { get; }
        int Complete();
    }
}
