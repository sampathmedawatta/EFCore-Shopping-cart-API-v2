using OnlineShopping.Common;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Interfaces.ManagerClasses
{
    public interface ICategoryManager
    {
        Task<OperationResult> GetCategoriesAsync();
    }
}
