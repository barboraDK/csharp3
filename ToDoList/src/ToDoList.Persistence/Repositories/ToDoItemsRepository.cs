namespace ToDoList.Persistence.Repositories;

using ToDoList.Domain.Models;

public class ToDoItemsRepository : IRepository<ToDoItem>
{
    private readonly ToDoItemsContext context;

    public ToDoItemsRepository(ToDoItemsContext context)
    {
        this.context = context;
    }
    public void Create(ToDoItem item)
    {
        context.ToDoItems.Add(item);
        context.SaveChanges();
    }
    public List<ToDoItem> Read()
    {
        return context.ToDoItems.ToList();
    }
    public ToDoItem? ReadById(int itemId)
    {
        return context.ToDoItems.Find(itemId);

    }
    public ToDoItem? UpdateById(int itemId, ToDoItem item)
    {
        var existingItem = context.ToDoItems.Find(itemId);
        if (existingItem != null)
        {
            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.IsCompleted = item.IsCompleted;
            context.SaveChanges();
        }
        return existingItem;
    }
    public ToDoItem? DeleteById(int itemId)
    {
        var item = context.ToDoItems.Find(itemId);
        if (item != null)
        {
            context.ToDoItems.Remove(item);
            context.SaveChanges();
        }
        return item;
    }
}
