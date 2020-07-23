using OnlineShopping.Data.Interfaces.Repository;

namespace OnlineShopping.Data.Repository.Interfaces
{
    public interface ICategoryRepository<T> : IRepository<T> where T : class
    {
    }
}