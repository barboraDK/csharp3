namespace ToDoList.Domain.DTOs;
public record class ToDoItemUpdateRequestDto(string Name, string Description, bool IsCompleted)
{
}
