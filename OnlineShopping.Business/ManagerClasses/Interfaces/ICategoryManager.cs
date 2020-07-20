using OnlineShopping.Common;
using System;

namespace OnlineShopping.Business.Interfaces.ManagerClasses
{
    public interface ICategoryManager
    {
        OperationResult GetAllCategories(Guid? id);
    }
}
