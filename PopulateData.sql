USE [ToDoList]
GO

INSERT INTO [dbo].[TodoList]
           ([Name]
           ,[CreatedDateTime])
     VALUES
           ('Test 1',
           GETDATE())
GO

INSERT INTO [dbo].[TodoList]
           ([Name]
           ,[CreatedDateTime])
     VALUES
           ('Test 2',
           GETDATE())
GO



USE [ToDoList]
GO

INSERT INTO [dbo].[Tasks]
           ([ListId]
           ,[Detail]
           ,[IsComplete])
     VALUES
           (1
           ,'Test task 1'
           ,0)
GO

INSERT INTO [dbo].[Tasks]
           ([ListId]
           ,[Detail]
           ,[IsComplete])
     VALUES
           (1
           ,'Test task 2'
           ,1)
GO

INSERT INTO [dbo].[Tasks]
           ([ListId]
           ,[Detail]
           ,[IsComplete])
     VALUES
           (1
           ,'Test task 3'
           ,1)
GO

INSERT INTO [dbo].[Tasks]
           ([ListId]
           ,[Detail]
           ,[IsComplete])
     VALUES
           (2
           ,'Test task 3'
           ,1)
GO

