using OnlineShopping.Common;
using OnlineShopping.Entity.Models.Order;
using System;
using System.Threading.Tasks;

namespace OnlineShopping.Business.ManagerClasses.Interfaces
{
    public interface IOrderManager
    {
        Task<OperationResult> CreateOrderAsync(OrderDto orderDto);
        Task<OperationResult> GetOrderByIdAsync(Guid Id);
    }
}
