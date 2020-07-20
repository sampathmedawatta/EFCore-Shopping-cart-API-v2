using OnlineShopping.Common;

namespace OnlineShopping.Business.Interfaces.ManagerClasses
{
    public interface IProductManager
    {
        OperationResult GetProducts();
        OperationResult GetProductsByOptions(string option);
        OperationResult GetProductsByCategoryName(string Name);
    }
}
