namespace ToDoList.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;

public class ToDoItemsRepository : IRepositoryAsync<ToDoItem>
{
    private readonly ToDoItemsContext context;

    public ToDoItemsRepository(ToDoItemsContext context)
    {
        this.context = context;
    }
    public async Task Create(ToDoItem item)
    {
        await context.ToDoItems.AddAsync(item);
        await context.SaveChangesAsync();
    }
    public async Task<List<ToDoItem>> Read()
    {
        return await context.ToDoItems.ToListAsync();
    }
    public async Task<ToDoItem?> ReadById(int itemId)
    {
        return await context.ToDoItems.FindAsync(itemId);

    }
    public async Task<ToDoItem?> UpdateById(int itemId, ToDoItem item)
    {
        var existingItem = await context.ToDoItems.FindAsync(itemId);
        if (existingItem != null)
        {
            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.IsCompleted = item.IsCompleted;
            existingItem.Category = item.Category;
            await context.SaveChangesAsync();
        }
        return existingItem;
    }
    public async Task<ToDoItem?> DeleteById(int itemId)
    {
        var item = await context.ToDoItems.FindAsync(itemId);
        if (item != null)
        {
            context.ToDoItems.Remove(item);
            await context.SaveChangesAsync();
        }
        return item;
    }
}
