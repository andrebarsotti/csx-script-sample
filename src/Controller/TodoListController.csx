#r "nuget: CommandLineParser, 2.8.0"
#r "nuget: ConsoleTables, 2.4.2"
#load "../Services/ITodoListService.csx"
using CommandLine;
using ConsoleTables;

public class TodoListController
{
    private readonly ITodoListService _service;
    
    public TodoListController(ITodoListService service)
    {
        _service = service;
    }

    public async Task ExecuteCommand(string[] args)
        => await Parser.Default.ParseArguments<AddOption, DoneOption, DeleteOption, ListOption>(args)
                        .MapResult(
                        async (AddOption options) => await AddTask(options.Locator, options.Title),
                        async (DoneOption options) => await MarkHasDone(options.Locator),
                        async (DeleteOption options) => await Delete(options.Locator),
                        async (ListOption options) => await GetTasks(),
                        errors => Task.FromResult(1));  

    private async Task AddTask(string locator, string title)
        => PrintMessage(await _service.AddTask(locator, title));
    
    private static void PrintMessage(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine();
    }

    private async Task MarkHasDone(string locator) 
        => PrintMessage(await _service.MarkHasDone(locator));
    
    private async Task Delete(string locator)
        => await _service.DeleteTask(locator);

    private async Task GetTasks()
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


[Verb(name: "add", isDefault: false, HelpText = "Add a task to list.")]
public class AddOption
{

    [Option(shortName: 'l', longName: "locator", Required = true, HelpText = "The locator code of the task", Default = "")]
    public string Locator { get; set;}

    [Option(shortName: 't', longName: "title", Required = true, HelpText = "The tile of the task", Default = "")]
    public string Title { get; set;}
}

[Verb(name: "del", isDefault: false, HelpText = "Delete the task.")]
public class DeleteOption
{

    [Option(shortName: 'l', longName: "locator", Required = true, HelpText = "The locator code of the task", Default = "")]
    public string Locator { get; set;}
}

[Verb(name: "done", isDefault: false, HelpText = "Mark the task as done.")]
public class DoneOption
{

    [Option(shortName: 'l', longName: "locator", Required = true, HelpText = "The locator code of the task", Default = "")]
    public string Locator { get; set;}
}

[Verb(name: "ls", isDefault: true, HelpText = "List the tasks.")]
public class ListOption
{
}