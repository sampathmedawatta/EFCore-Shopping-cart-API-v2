using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository.Interfaces
{
    public interface IProductRepository : IRepository<ProductEntiry>
    {
        Task<IEnumerable<ProductEntiry>> GetAllProductsAsunc();
        Task<IEnumerable<ProductEntiry>> GetAllByFilterAsunc(string FilterBy);
        Task<IEnumerable<ProductEntiry>> GetAllByCategoryNameAsunc(string CategoryName);
    }
}
