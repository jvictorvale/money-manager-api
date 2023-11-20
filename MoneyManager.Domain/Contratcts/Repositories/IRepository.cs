using System.Linq.Expressions;
using MoneyManager.Domain.Contratcts.Interfaces;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Contratcts.Repositories;

public interface IRepository<T> : IDisposable where T : Entity
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    
    public IUnitOfWork UnitOfWork { get; }
    Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression);
}