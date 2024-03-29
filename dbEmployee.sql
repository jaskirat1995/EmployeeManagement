USE [dbEmployee]
GO
/****** Object:  Table [dbo].[tblDepartment]    Script Date: 11/11/2019 3:03:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDepartment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblDepartment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 11/11/2019 3:03:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[Gender] [nvarchar](50) NULL,
	[City] [nvarchar](250) NULL,
	[State] [nvarchar](250) NULL,
	[DepartmentID] [int] NULL,
	[SalaryID] [int] NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblSalary]    Script Date: 11/11/2019 3:03:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSalary](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Salary] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tblSalary] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tblDepartment] ON 

GO
INSERT [dbo].[tblDepartment] ([ID], [Name]) VALUES (1, N'Accounts')
GO
INSERT [dbo].[tblDepartment] ([ID], [Name]) VALUES (2, N'Administration')
GO
INSERT [dbo].[tblDepartment] ([ID], [Name]) VALUES (3, N'Human Resources')
GO
INSERT [dbo].[tblDepartment] ([ID], [Name]) VALUES (4, N'Marketing')
GO
INSERT [dbo].[tblDepartment] ([ID], [Name]) VALUES (5, N'Sales')
GO
INSERT [dbo].[tblDepartment] ([ID], [Name]) VALUES (6, N'Engineering')
GO
SET IDENTITY_INSERT [dbo].[tblDepartment] OFF
GO
SET IDENTITY_INSERT [dbo].[tblEmployee] ON 

GO
INSERT [dbo].[tblEmployee] ([ID], [FirstName], [LastName], [Gender], [City], [State], [DepartmentID], [SalaryID]) VALUES (1, N'Raviinderjit', N'Kumar', NULL, N'Mohali', N'Punjab', 1, 4)
GO
INSERT [dbo].[tblEmployee] ([ID], [FirstName], [LastName], [Gender], [City], [State], [DepartmentID], [SalaryID]) VALUES (4, N'Varun', N'Mahajan', NULL, N'Jalandhar', N'Punjab', 2, 3)
GO
INSERT [dbo].[tblEmployee] ([ID], [FirstName], [LastName], [Gender], [City], [State], [DepartmentID], [SalaryID]) VALUES (6, N'Nishant', N'Khatri', NULL, N'Ambala', N'Haryana', 4, 5)
GO
SET IDENTITY_INSERT [dbo].[tblEmployee] OFF
GO
SET IDENTITY_INSERT [dbo].[tblSalary] ON 

GO
INSERT [dbo].[tblSalary] ([ID], [Salary]) VALUES (1, CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblSalary] ([ID], [Salary]) VALUES (2, CAST(15000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblSalary] ([ID], [Salary]) VALUES (3, CAST(20000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblSalary] ([ID], [Salary]) VALUES (4, CAST(25000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblSalary] ([ID], [Salary]) VALUES (5, CAST(30000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblSalary] ([ID], [Salary]) VALUES (6, CAST(40000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblSalary] ([ID], [Salary]) VALUES (7, CAST(50000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblSalary] ([ID], [Salary]) VALUES (8, CAST(70000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblSalary] ([ID], [Salary]) VALUES (9, CAST(80000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblSalary] ([ID], [Salary]) VALUES (10, CAST(90000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblSalary] ([ID], [Salary]) VALUES (11, CAST(100000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[tblSalary] OFF
GO
ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployee_tblDepartment] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[tblDepartment] ([ID])
GO
ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_tblEmployee_tblDepartment]
GO
ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployee_tblSalary] FOREIGN KEY([SalaryID])
REFERENCES [dbo].[tblSalary] ([ID])
GO
ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_tblEmployee_tblSalary]
GO
