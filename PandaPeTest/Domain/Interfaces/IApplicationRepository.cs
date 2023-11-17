﻿using System.Linq.Expressions;

namespace PandaPeTest.Api.Domain.Interfaces
{
    public interface IApplicationRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        void DeleteRange(List<T> entity);
        void AddRange(List<T> entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      string includeProperties = "");

    }
}
