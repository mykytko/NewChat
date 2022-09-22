using Microsoft.EntityFrameworkCore;

namespace NewChat.DAL;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ChatsContext _context;
    private readonly DbSet<T> _entities;

    public GenericRepository(ChatsContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

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
        _context.Entry(obj).State = EntityState.Modified;
    }

    public void Delete(T obj)
    {
        _entities.Remove(obj);
    }
}