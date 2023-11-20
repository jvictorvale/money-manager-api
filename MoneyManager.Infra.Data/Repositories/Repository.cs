using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Contratcts.Interfaces;
using MoneyManager.Domain.Contratcts.Repositories;
using MoneyManager.Domain.Entities;
using MoneyManager.Infra.Data.Context;

namespace MoneyManager.Infra.Data.Repositories;

public abstract class Repository<T> : IRepository<T> where T : Entity
{
    private bool _isDisposed;
    private readonly DbSet<T> _dbSet;
    protected readonly ApplicationDbContext Context;
    
    protected Repository(ApplicationDbContext context)
    {
        Context = context;
        _dbSet = context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public IUnitOfWork UnitOfWork => Context;
    
    public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AsNoTrackingWithIdentityResolution().Where(expression).FirstOrDefaultAsync();
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed)
        {
            return;
        }

        if (disposing)
        {
            Context.Dispose();
        }

        _isDisposed = true;
    }
    
    ~Repository()
    {
        Dispose(false);
    }
}