using System.Linq.Expressions;
using MoneyManager.Domain.Contratcts.Interfaces;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Contratcts.Repositories;

public interface IRepository<T> : IDisposable where T : Entity
{ 
    public IUnitOfWork UnitOfWork { get; } 
    void Adicionar(T entity);
    void Atualizar(T entity);
    Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression);
}