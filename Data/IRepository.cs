namespace TodoApp.Data{

public interface IRepository<T> where T : class{

    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveAsync();

}

}
