namespace ToDoList.Persistence.Repositories;

public interface IRepositoryAsync<T> where T : class
{
    Task Create(T item);
    Task<List<T>> Read();
    Task<T>? ReadById(int itemId);
    Task<T>? UpdateById(int itemId, T item);
    Task<T>? DeleteById(int itemId);
}
