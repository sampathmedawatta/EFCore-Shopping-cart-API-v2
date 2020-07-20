using OnlineShopping.Common;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Interfaces.ManagerClasses
{
    public interface IProductManager
    {
        Task<OperationResult> GetProductsAsunc();
        Task<OperationResult> GetProductsByOptionsAsunc(string option);
        Task<OperationResult> GetProductsByCategoryNameAsunc(string Name);

    }
}
