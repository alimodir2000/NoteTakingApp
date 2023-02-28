using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.EntityFrameworkCore;
using NoteTakingAppSolution.Application.Common.Persistence;
using NoteTakingAppSolution.Domain.Common;

namespace NoteTakingAppSolution.Infrastructure.Persistence.Repository;
/// <summary>
/// Implementation of IAsyncRepository
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
{

    protected readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken = default)
    {
        var allData = _dbContext.Set<T>();
        _dbContext.Set<T>().RemoveRange(allData);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Expression<Func<T, bool>> predition, CancellationToken cancellationToken = default)
    {
        var data = _dbContext.Set<T>().Where(predition);
        _dbContext.Set<T>().RemoveRange(data);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predition, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().Where(predition).ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        if (disableTracking)
            query = query.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(includeString))
            query = query.Include(includeString);
        if (predicate != null)
            query = query.Where(predicate);
        if (orderBy != null)
            return await orderBy(query).ToListAsync(cancellationToken);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        if (disableTracking)
            query = query.AsNoTracking();

        if (includes != null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null)
            query = query.Where(predicate);
        if (orderBy != null)
            return await orderBy(query).ToListAsync(cancellationToken);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().FindAsync(id, cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}





