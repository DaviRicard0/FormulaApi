namespace FormulaApi.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(Guid id);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
}
