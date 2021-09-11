#load "../Data/ITodoListRepository.csx"
#load "ITodoListService.csx"

public class TodoListService : ITodoListService
{
    public readonly ITodoListRepository _repository;

    public TodoListService(ITodoListRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<TodoTask>> GetTasks() => _repository.GetTasks();

    public async Task<string> AddTask(string locator, string title)
    {
        if (string.IsNullOrWhiteSpace(locator))
            return "A locator is required.";

        if (locator.Length > 10)
            return "A locator must be have until 10 characters.";

        if (string.IsNullOrWhiteSpace(title))
            return "A title is required.";

        if (locator.Length > 256)
            return "A title must be have until 256 characters.";


        TodoTask task = new()
        {
            Locator = locator,
            Title = title,
            Done = false
        };

        await _repository.AddTask(task);

        return "Task added.";
    }

    public async Task<string> MarkHasDone(string locator)
    {
        TodoTask task = await _repository.GetTask(locator);

        if (task is null)
            return "Task not found.";

        task.Done = true;

        await _repository.UpdateTask(task);
        return "Task marked has done.";
    }

    public async Task DeleteTask(string locator)
    {
        await _repository.DeleteTask(locator);
    }
}
