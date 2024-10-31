namespace ToDoList.Persistence.Repositories;

public interface IRepository<T> where T : class
{
    void Create(T item);
    List<T> Read();
    T? ReadById(int itemId);
    T? UpdateById(int itemId, T item);
    T? DeleteById(int itemId);
}
