#!/usr/bin/env dotnet-script
#load "Configs.csx"
#load "src/Data/TodoListRepository.csx"
#load "src/Services/TodoListService.csx"
#load "src/Controller/TodoListController.csx"
using Microsoft.Extensions.Configuration;


await Run(Args.ToArray());

async Task Run(string[] args)
{
    using TodoListRepository repository = new(Configs.Configuration.GetConnectionString("db"));
    TodoListService service = new(repository);
    TodoListController controller = new(service);
    await controller.ExecuteCommand(args);
}
