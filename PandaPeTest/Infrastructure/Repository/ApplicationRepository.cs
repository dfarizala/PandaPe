using Microsoft.EntityFrameworkCore;
using PandaPeTest.Api.Domain.Interfaces;
using System.Linq.Expressions;

namespace PandaPeTest.Api.Infrastructure.Repository
{
    public class ApplicationRepository<T> : IApplicationRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task IApplicationRepository<T>.AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _unitOfWork.Context.Set<T>().AddAsync(entity);
        }

        void IApplicationRepository<T>.AddRange(List<T> entity, CancellationToken cancellationToken)
        {
            _unitOfWork.Context.Set<T>().AddRange(entity.ToArray());
        }

        async Task IApplicationRepository<T>.DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _unitOfWork.Context.Set<T>().Remove(entity);
        }

        void IApplicationRepository<T>.DeleteRange(List<T> entity)
        {
            _unitOfWork.Context.Set<T>().RemoveRange(entity.ToArray());
        }
        
        async Task IApplicationRepository<T>.UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _unitOfWork.Context.Set<T>().Entry(entity).State = EntityState.Modified;
        }

        IEnumerable<T> IApplicationRepository<T>.GetAll()
        {
            return (IQueryable<T>)_unitOfWork.Context.Set<T>().ToList();
        }

        async Task<IEnumerable<T>> IApplicationRepository<T>.GetAsync()
        {
            return await _unitOfWork.Context.Set<T>().ToListAsync();
        }

        async Task<IEnumerable<T>> IApplicationRepository<T>.GetAsync(Expression<Func<T, bool>> whereCondition, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();

            if (whereCondition != null) query = query.Where(whereCondition);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
    }
}
