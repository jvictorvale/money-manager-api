using System.Linq.Expressions;
using MoneyManager.Domain.Contratcts.Interfaces;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Contratcts.Repositories;

public interface IRepository<T> : IDisposable where T : Entity, IAggregateRoot
{
    public IUnitOfWork UnitOfWork { get; }
    Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression);
}