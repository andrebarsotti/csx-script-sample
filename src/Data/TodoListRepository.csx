#r "nuget: Microsoft.Data.SqlClient, 3.0.0"
#r "nuget: Dapper, 2.0.90"
#load "ITodoListRepository.csx"
using System;
using Dapper;
using Microsoft.Data.SqlClient;

public class TodoListRepository: ITodoListRepository, IDisposable
{
    private bool _disposedValue;
    private SqlConnection _connection;

    public TodoListRepository(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _connection.Dispose();
            }

            _disposedValue = true;
        }
    }

    ~TodoListRepository()
    {
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public Task<IEnumerable<TodoTask>> GetTasks()
        => _connection.QueryAsync<TodoTask>("SELECT Locator, Title, Done FROM [dbo].[TodoTask]");

    public Task<TodoTask> GetTask(string locator)
        => _connection.QueryFirstOrDefaultAsync<TodoTask>("SELECT Locator, Title, Done FROM [dbo].[TodoTask] WHERE Locator = @Locator",
                                                          new {Locator = locator});

    public async Task AddTask(TodoTask task)
    {
        string insert = "INSERT INTO [dbo].[TodoTask](Locator, Title, Done) ";
        insert += "Values(@Locator, @Title, @Done)";

        await _connection.ExecuteAsync(insert, task);
    }

    public async Task UpdateTask(TodoTask task)
    {
        string update = "UPDATE [dbo].[TodoTask] ";
        update += "SET Title = @Title, Done = @Done ";
        update += "WHERE Locator = @Locator";

        await _connection.ExecuteAsync(update, task);
    }

    public async Task DeleteTask(string locator)
    {
        string delete = "DELETE FROM [dbo].[TodoTask] ";
        delete += "WHERE Locator = @Locator";

        await _connection.ExecuteAsync(delete, new { Locator = locator});
    }
}
