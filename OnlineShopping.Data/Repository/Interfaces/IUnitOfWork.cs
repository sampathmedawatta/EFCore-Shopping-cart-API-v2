using System;

namespace OnlineShopping.Data.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IUserRepository Users { get; }
        IUserPasswordRepository UserPasswords { get; }
        int Complete();
    }
}
