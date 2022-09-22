using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NewChat.DAL;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _entities = null!;
    public ChatsContext Context { get; set; } = null!;

    public IEnumerable<T> GetAll()
    {
        return _entities.ToList();
    }

    public T? GetById(int id)
    {
        return _entities.Find(id);
    }

    public void Insert(T obj)
    {
        _entities.Add(obj);
    }

    public void Update(T obj)
    {
        _entities.Attach(obj);
        Context.Entry(obj).State = EntityState.Modified;
    }

    public void Delete(T obj)
    {
        _entities.Remove(obj);
    }
}