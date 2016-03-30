using System;
namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        void Complete();
    }
}
