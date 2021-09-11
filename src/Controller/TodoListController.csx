#r "nuget: ConsoleTables, 2.4.2"
#load "../Services/ITodoListService.csx"
using ConsoleTables;

public class TodoListController
{
    private readonly ITodoListService _service;
    
    public TodoListController(ITodoListService service)
    {
        _service = service;
    }

    public async Task AddTask(string locator, string title)
        => PrintMessage(await _service.AddTask(locator, title));
    
    private static void PrintMessage(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine();
    }

    public async Task MarkHasDone(string locator) 
        => PrintMessage(await _service.MarkHasDone(locator));

    public async Task GetTasks()
    {
        var tasks = await _service.GetTasks();
        var table = new ConsoleTable("Locator", "Title", "Done");

        foreach(TodoTask item in tasks)
        {
            table.AddRow(item.Locator, item.Title, item.Done);
        }

        table.Write();        
    }
}