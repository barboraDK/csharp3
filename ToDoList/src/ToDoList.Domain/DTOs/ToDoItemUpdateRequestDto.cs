namespace ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

//ma to byt string? Category
public record class ToDoItemUpdateRequestDto(string Name, string Description, bool IsCompleted, string Category)
{
    public ToDoItem ToDomain() => new() { Name = Name, Description = Description, IsCompleted = IsCompleted, Category = Category };
}
