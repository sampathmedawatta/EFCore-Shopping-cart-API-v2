using OnlineShopping.Common;
using System;

namespace OnlineShopping.Business.Interfaces.ManagerClasses
{
    public interface IProductManager : IBaseManager
    {
        OperationResult GetAllProducts(Guid? id);
        OperationResult GetProductsByOptions(string option);
        OperationResult GetProductsByCategoryName(string Name);
    }
}
