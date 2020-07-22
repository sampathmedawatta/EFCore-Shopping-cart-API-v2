using OnlineShopping.Data.Entity;
using OnlineShopping.Data.Interfaces.Repository;
using OnlineShopping.Entity.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository.Interfaces
{
    public interface IProductRepository : IRepository<ProductEntiry>
    {
        Task<IEnumerable<ProductReadDto>> GetAllProductsAsunc();
        Task<IEnumerable<ProductReadDto>> GetAllByFilterAsunc(string FilterBy);
        Task<IEnumerable<ProductReadDto>> GetAllByCategoryNameAsunc(string CategoryName);
    }
}
