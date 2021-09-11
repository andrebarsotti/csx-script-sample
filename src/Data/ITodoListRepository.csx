#load "../Model/TodoTask.csx"

public interface ITodoListRepository
{
    Task<IEnumerable<TodoTask>> GetTasks();

    Task<TodoTask> GetTask(string locator);

    Task AddTask(TodoTask task);

    Task UpdateTask(TodoTask task);

    Task DeleteTask(string locator);
}