namespace MoneyManager.Domain.Contratcts.Interfaces;

public interface IUnitOfWork
{
    Task<bool> Commit();
}