USE [master]
GO

IF EXISTS (SELECT 1 FROM sys.databases WHERE name = N'todo-list')
    BEGIN
    PRINT 'Apagando o database [todo-list]'
    DROP DATABASE [todo-list]
    END
GO

PRINT 'Criando o database [todo-list]'
CREATE DATABASE [todo-list]
GO

USE [todo-list]
GO

PRINT 'Criando a tabela [dbo].[TodoTask]'
CREATE TABLE [dbo].[TodoTask]
(
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
    [Locator] NVARCHAR(10) NOT NULL,
    [Title] NVARCHAR(256) NOT NULL,
    [Done] BIT NOT NULL
    CONSTRAINT [PK_TodoTask] PRIMARY KEY([Id]),
    CONSTRAINT [IX_TodoTask_Locator] UNIQUE([Locator])
);
GO
