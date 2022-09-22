namespace NewChat.DAL;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    void Insert(T obj);
    void Update(T obj);
    void Delete(T obj);
}