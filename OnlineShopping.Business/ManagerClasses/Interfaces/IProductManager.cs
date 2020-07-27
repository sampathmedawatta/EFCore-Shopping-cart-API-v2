using OnlineShopping.Common;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Interfaces.ManagerClasses
{
    public interface IProductManager
    {
        Task<OperationResult> GetProductsAsync();
        Task<OperationResult> GetProductsByOptionsAsync(string option);
        Task<OperationResult> GetProductsByCategoryNameAsync(string Name);

    }
}
