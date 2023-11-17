using PandaPeTest.Api.Domain.Interfaces;

namespace PandaPeTest.Api.Infrastructure.Repository
{
    public class ApplicationUnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }

        public ApplicationUnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }

        void IDisposable.Dispose()
        {
            Context.Dispose();
        }

        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }

        void IUnitOfWork.CommitTransaction()
        {
            Context.SaveChanges();
        }
    }
}
