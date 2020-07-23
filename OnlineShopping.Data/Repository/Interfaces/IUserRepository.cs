using OnlineShopping.Data.Interfaces.Repository;

namespace OnlineShopping.Data.Repository.Interfaces
{
    public interface IUserRepository<T> : IRepository<T> where T : class
    {
    }
}
