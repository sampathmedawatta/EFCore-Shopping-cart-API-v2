using OnlineShopping.Data.Interfaces.Repository;

namespace OnlineShopping.Data.Repository.Interfaces
{
    public interface IOrderRepository<T> : IRepository<T> where T : class
    {
    }
}
