using PandaPeTest.Api.Infrastructure;

namespace PandaPeTest.Api.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext Context { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void CommitTransaction();
    }
}
