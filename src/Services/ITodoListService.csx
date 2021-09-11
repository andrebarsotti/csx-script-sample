#load "../Model/TodoTask.csx"

public interface ITodoListService
{
    Task<string> AddTask(string locator, string title);
    Task DeleteTask(string locator);
    Task<IEnumerable<TodoTask>> GetTasks();
    Task<string> MarkHasDone(string locator);
}