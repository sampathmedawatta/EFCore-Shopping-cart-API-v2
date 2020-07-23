using OnlineShopping.Data.Interfaces.Repository;
using OnlineShopping.Entity.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository.Interfaces
{
    public interface IProductRepository<T> : IRepository<T> where T : class
    {
        Task<IEnumerable<ProductDto>> GetAllByFilterAsunc(string FilterBy);
        Task<IEnumerable<ProductDto>> GetAllByCategoryNameAsunc(string CategoryName);
    }
}
