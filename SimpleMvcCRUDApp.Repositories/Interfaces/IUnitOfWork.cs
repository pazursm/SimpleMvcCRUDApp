using System;
using System.Threading.Tasks;

namespace SimpleMvcCRUDApp.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}
