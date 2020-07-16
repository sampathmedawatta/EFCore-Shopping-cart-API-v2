using OnlineShopping.Common;
using System;

namespace OnlineShopping.Business.ManagerClasses
{
    public interface ICategoryManager
    {
        OperationResult GetAllCategories(Guid? id);
    }
}
