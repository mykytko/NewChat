using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace NewChat.DAL;

public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
{
    private IDbContextTransaction _objTran = null!;
    private Dictionary<string, object>? _repositories;

    public TContext Context { get; }

    public UnitOfWork()
    {
        Context = new TContext();
    }

    public void CreateTransaction()
    {
        _objTran = Context.Database.BeginTransaction();
    }

    public void Commit()
    {
        _objTran.Commit();
    }

    public void Rollback()
    {
        _objTran.Rollback();
        _objTran.Dispose();
    }

    public void Save()
    {
        Context.SaveChanges();
    }

    public GenericRepository<T> GenericRepository<T>() where T : class
    {
        _repositories ??= new Dictionary<string, object>();

        var type = typeof(T).Name;

        if (_repositories.ContainsKey(type))
        {
            return (GenericRepository<T>) _repositories[type];
        }
        
        var repositoryType = typeof(GenericRepository<T>);
        var repositoryInstance = 
            Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), Context)!;
        _repositories.Add(type, repositoryInstance);
        return (GenericRepository<T>) _repositories[type];
    }
}