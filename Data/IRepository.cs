namespace TodoApp.Data{

public interface IRepository<T> where T : class{

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task Update(T entity);
    void Delete(T entity);
    Task SaveAsync();

}

}
