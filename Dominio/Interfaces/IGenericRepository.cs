using System.Linq.Expressions;

namespace Dominio.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T,bool>> expression);
    Task<(int TotalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
}
