USE [RegisterDB]
GO
/****** Object:  Table [dbo].[TblEmployee]    Script Date: 10/25/2017 00:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblEmployee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
 CONSTRAINT [PK_TblEmployee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TblEmployee] ON
INSERT [dbo].[TblEmployee] ([Id], [Name], [City], [Address]) VALUES (1, N'Sandip Das', N'Bangalore', N'Marathalli, Bangalore-37')
INSERT [dbo].[TblEmployee] ([Id], [Name], [City], [Address]) VALUES (2, N'abc', NULL, NULL)
INSERT [dbo].[TblEmployee] ([Id], [Name], [City], [Address]) VALUES (3, N'shfdj', N'hfueiwfu', N'uriowefnd')
INSERT [dbo].[TblEmployee] ([Id], [Name], [City], [Address]) VALUES (5, N'kdfhjks', N'erowiri', N'iwryuiwre')
INSERT [dbo].[TblEmployee] ([Id], [Name], [City], [Address]) VALUES (7, N'fgh', N'dfg', N'wer')
INSERT [dbo].[TblEmployee] ([Id], [Name], [City], [Address]) VALUES (8, N'abc', N'def', N'ghi')
SET IDENTITY_INSERT [dbo].[TblEmployee] OFF
/****** Object:  StoredProcedure [dbo].[UpdateEmpDetails_SP]    Script Date: 10/25/2017 00:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateEmpDetails_SP]  
(  
   @EmpId int,  
   @Name varchar (50),  
   @City varchar (50),  
   @Address varchar (50)  
)  
as  
begin  
   Update TblEmployee   
   set Name=@Name,  
   City=@City,  
   Address=@Address  
   where Id=@EmpId  
End
GO
/****** Object:  StoredProcedure [dbo].[GetEmployees_SP]    Script Date: 10/25/2017 00:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetEmployees_SP]  
as  
begin  
   select * from TblEmployee  
End
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmpById_SP]    Script Date: 10/25/2017 00:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteEmpById_SP]  
(  
   @EmpId int  
)  
as   
begin  
   Delete from TblEmployee where Id=@EmpId  
End
GO
/****** Object:  StoredProcedure [dbo].[AddNewEmpDetails_SP]    Script Date: 10/25/2017 00:05:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddNewEmpDetails_SP]  
(  
   @Name varchar (50),  
   @City varchar (50),  
   @Address varchar (50)
)  
as  
begin  
   Insert into TblEmployee values(@Name,@City,@Address)  
End
GO
