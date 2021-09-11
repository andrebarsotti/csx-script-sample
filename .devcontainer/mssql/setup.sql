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

PRINT 'Criando a tabela [dbo].[Task]'
CREATE TABLE [dbo].[Task]
(
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT 'NEWSEQUENTIALID()',
    [Locator] NVARCHAR(10) NOT NULL,
    [Title] NVARCHAR(256) NOT NULL,
    [Done] BIT NOT NULL
    CONSTRAINT [PK_Task] PRIMARY KEY([Id]),
    CONSTRAINT [IX_Task_Locator] UNIQUE([Locator])
);
GO
