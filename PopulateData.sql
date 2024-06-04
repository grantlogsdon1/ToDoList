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
		   ,[CreatedDateTime]
           ,[IsComplete])
     VALUES
           (1
           ,'Test task 1'
		   ,GetDate()
           ,0)
GO
