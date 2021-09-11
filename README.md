# Todo List em C# script (CSX)

## Introdução

Esse é um simples _todo list_ desenvolvido como os script em C#. A proposta foi validar a utilização de script para no desenvolvimento de uma
aplicação simples, porém com certo nível de complexidade.

Esse aplicativo aplica o padrão de projeto MVC e também de repositórios.

## Requisitos para execução

Para a execução desse aplicativo é preciso ter:

- Sdk .Net 5.0 instalado na máquina;
- Sql Server 2019 / LocalDB instalado na máquina;
- Ter instalado o pacote dotnet-script;
- Visual Studio Code e Docker são opcionais.

## Configuração do ambiente

Se você tiver Docker e um Visual Studio Code com os plugins do _[Remote Develpment](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack)_ instalados basta abrir o diretório do projeto dentro de um cotainer e um ambiente de desenvolvimento será preparado.

Caso você queira montar um ambiente local siga os passos abaixo:

1. Execute o script scripts/setup.sql em sua instalação de SQL Server.
2. Em um prompt de comando (PowerShell, bash, etc) executar o comando abaixo

    ~~~ Shell
    > dotnet tool install -g dotnet-script
    ~~~

3. Vá para os caminhos de seus user-screts conforme abaixo

    No Windows
    ~~~ PowerShell
    cd Env:APPDATA\Microsoft\UserSecrets\
    ~~~

    No Linux
    ~~~ Shell
    cd ~/.microsoft/usersecrets/
    ~~~

4. Crie um diretório chamado _csx-script-app_

    No Windows
    ~~~ PowerShell
    mkdir csx-script-app
    ~~~

    No Linux
    ~~~ Shell
    mkdir csx-script-app
    ~~~

4. Crie um arquivo chamado _secrets.json_ com o confrome o exemplo abaixo

    ~~~ JSON
    {
        "ConnectionStrings": {
            "db": "Server=localhost;Database=todo-list;User Id=sa;Password=P@ssw0rd"
        }
    }
    ~~~

## Execução

Para executar o projeto basta executar algum dos comando abaixo na raiz do projeto:

    ~~~ Shell
    dotnet script Main.csx 
    ~~~

No caso de ambientes linux também é possível executar da seguinte forma:

    ~~~ Shell
    ./Main.csx 
    ~~~

### Exemplos de comandos

#### Listar

Para listar todas as tarefas cadastradas:

    ~~~ Shell
    ./Main.csx 
    ~~~

Ou


    ~~~ Shell
    ./Main.csx ls
    ~~~

#### Adicionar

Para adicionar uma tarefa:

    ~~~ Shell
    ./Main.csx add --locator teste --title "Tarefa de Teste"
    ~~~

#### Concluir

Para concluir uma tarefa:

    ~~~ Shell
    ./Main.csx done --locator teste
    ~~~

#### Apagar

Para apagar uma tarefa:

    ~~~ Shell
    ./Main.csx del --locator teste
    ~~~


## Referências

Mark Michaelis
https://docs.microsoft.com/en-us/archive/msdn-magazine/2016/january/essential-net-csharp-scripting

Ali Bahraminezhad
https://itnext.io/hitchhikers-guide-to-the-c-scripting-13e45f753af9

Peter Vogel
https://visualstudiomagazine.com/articles/2021/06/14/csharp-scripting.aspx

Shinigami 
https://blog.bitscry.com/2017/05/30/appsettings-json-in-net-core-console-app/

Alexandre Zollinger Chohfi 
https://devblogs.microsoft.com/ifdef-windows/command-line-parser-on-net5/