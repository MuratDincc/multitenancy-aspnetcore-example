CREATE DATABASE [MultiTenantMainDB]
GO
CREATE DATABASE [MultiTenantDB_1]
GO
CREATE DATABASE [MultiTenantDB_2]
GO
CREATE DATABASE [MultiTenantDB_3]
GO
USE [MultiTenantMainDB]
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] NOT NULL,
	[PoolId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DatabaseName] [nvarchar](50) NOT NULL,
	[ApiKey] [nvarchar](50) NOT NULL,
	[SecretKey] [nvarchar](50) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
	[UpdatedOnUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company_User_Mapping]    Script Date: 7.12.2021 02:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_User_Mapping](
	[Id] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Company_User_Mapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pool]    Script Date: 7.12.2021 02:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pool](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Host] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[MaxDatabaseCount] [int] NOT NULL,
 CONSTRAINT [PK_Table_2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7.12.2021 02:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Company] ([Id], [PoolId], [Name], [DatabaseName], [ApiKey], [SecretKey], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (1, 1, N'Test Company 1', N'MultiTenantDB_1', N'21724cb5-3e75-4066-9935-82796a39f7f0', N'ugUC6L2UTmTKz2jT==', 0, CAST(N'2021-12-05T00:00:00.000' AS DateTime), CAST(N'2021-12-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Company] ([Id], [PoolId], [Name], [DatabaseName], [ApiKey], [SecretKey], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, 1, N'Test Company 2', N'MultiTenantDB_2', N'2ddf94b7-bbed-4610-a4b7-d68ca378fac3', N'RA6qwWQJvtg3v6p5==', 0, CAST(N'2021-12-05T00:00:00.000' AS DateTime), CAST(N'2021-12-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Company] ([Id], [PoolId], [Name], [DatabaseName], [ApiKey], [SecretKey], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (3, 1, N'Test Company 3', N'MultiTenantDB_3', N'12d6b3c8-d8bb-444a-8e66-cb100d0c4dc4', N'AkLuC5bX9F2KezGY==', 0, CAST(N'2021-12-05T00:00:00.000' AS DateTime), CAST(N'2021-12-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Company_User_Mapping] ([Id], [CompanyId], [UserId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[Company_User_Mapping] ([Id], [CompanyId], [UserId]) VALUES (2, 2, 2)
GO
INSERT [dbo].[Company_User_Mapping] ([Id], [CompanyId], [UserId]) VALUES (3, 3, 3)
GO
INSERT [dbo].[Pool] ([Id], [Name], [Host], [Username], [Password], [MaxDatabaseCount]) VALUES (1, N'Local Server', N'db', N'sa', N'MultiTenantAppP@ssword!!', 10)
GO
INSERT [dbo].[User] ([Id], [Email], [Password]) VALUES (1, N'testcompany1@gmail.com', N'df869476b3c530917855cc889d5d4776e0e66a5f01e013ed18d3af917bb58362')
GO
INSERT [dbo].[User] ([Id], [Email], [Password]) VALUES (2, N'testcompany2@gmail.com', N'df869476b3c530917855cc889d5d4776e0e66a5f01e013ed18d3af917bb58362')
GO
INSERT [dbo].[User] ([Id], [Email], [Password]) VALUES (3, N'testcompany3@gmail.com', N'df869476b3c530917855cc889d5d4776e0e66a5f01e013ed18d3af917bb58362')
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_Pool] FOREIGN KEY([PoolId])
REFERENCES [dbo].[Pool] ([Id])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_Pool]
GO
ALTER TABLE [dbo].[Company_User_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Company_User_Mapping_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Company_User_Mapping] CHECK CONSTRAINT [FK_Company_User_Mapping_Company]
GO
ALTER TABLE [dbo].[Company_User_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Company_User_Mapping_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Company_User_Mapping] CHECK CONSTRAINT [FK_Company_User_Mapping_User]
GO

-- [MultiTenantDB_1] Init Script

USE [MultiTenantDB_1]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
	[UpdatedOnUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
	[UpdatedOnUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, N'e3a64e76-b79b-49b3-b5df-0e7e8191301e', N'Jaiden', N'Randolph', N'jaiden@randolph.com', 0, CAST(N'2021-12-07T02:07:13.610' AS DateTime), CAST(N'2021-12-07T02:07:13.610' AS DateTime))
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (3, N'5f86f00a-a034-4ed1-a857-ec109292e08c', N'Youssef', N'Kaye', N'youssef@kaye.com', 0, CAST(N'2021-12-07T02:07:32.450' AS DateTime), CAST(N'2021-12-07T02:07:32.450' AS DateTime))
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (4, N'6e82f4b5-a8ec-49e8-9e8d-e702bb816c33', N'Chantal', N'Lara', N'chantal@lara.com', 0, CAST(N'2021-12-07T02:07:43.500' AS DateTime), CAST(N'2021-12-07T02:07:43.500' AS DateTime))
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (5, N'1754bb12-dc3c-463e-bc32-f98f65d713ef', N'Aviana', N'Cowan', N'aviana@cowan.com', 0, CAST(N'2021-12-07T02:08:44.627' AS DateTime), CAST(N'2021-12-07T02:08:44.627' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [Code], [Name], [Price], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (1, N'b96bf642-16da-493e-97fd-8f666cb31bfb', N'Chai', CAST(18.00 AS Decimal(18, 2)), 0, CAST(N'2021-12-07T02:10:27.457' AS DateTime), CAST(N'2021-12-07T02:10:27.457' AS DateTime))
GO
INSERT [dbo].[Product] ([Id], [Code], [Name], [Price], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, N'45847528-cab8-4482-abc7-1053b6480f21', N'Chang', CAST(19.00 AS Decimal(18, 2)), 0, CAST(N'2021-12-07T02:10:35.310' AS DateTime), CAST(N'2021-12-07T02:10:35.310' AS DateTime))
GO
INSERT [dbo].[Product] ([Id], [Code], [Name], [Price], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (3, N'0ad63110-eea7-4eae-9b54-882dee9f9706', N'Aniseed Syrup', CAST(10.00 AS Decimal(18, 2)), 0, CAST(N'2021-12-07T02:10:42.570' AS DateTime), CAST(N'2021-12-07T02:10:42.570' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CreatedOnUtc]  DEFAULT (getdate()) FOR [CreatedOnUtc]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_UpdatedOnUtc]  DEFAULT (getdate()) FOR [UpdatedOnUtc]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreatedOnUtc]  DEFAULT (getdate()) FOR [CreatedOnUtc]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_UpdatedOnUtc]  DEFAULT (getdate()) FOR [UpdatedOnUtc]
GO

-- [MultiTenantDB_2] Init Script

USE [MultiTenantDB_2]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
	[UpdatedOnUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
	[UpdatedOnUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, N'70b17bd3-bf99-45ad-9744-522d0e8bfc3f', N'Danika', N'Patterson', N'danika@patterson.com', 0, CAST(N'2021-12-07T02:07:13.610' AS DateTime), CAST(N'2021-12-07T02:07:13.610' AS DateTime))
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (3, N'b630001b-81d4-476a-9446-5043d119001a', N'Aiesha', N'Forrest', N'aiesha@forrest.com', 0, CAST(N'2021-12-07T02:07:32.450' AS DateTime), CAST(N'2021-12-07T02:07:32.450' AS DateTime))
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (4, N'd204924a-2b21-4385-8e95-544cb6027152', N'Allegra', N'Greig', N'allegra@greig.com', 0, CAST(N'2021-12-07T02:07:43.500' AS DateTime), CAST(N'2021-12-07T02:07:43.500' AS DateTime))
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (5, N'95a4fb38-bfe7-47b0-ae43-c80296e0a1ee', N'Dani', N'Browne', N'dani@browne.com', 0, CAST(N'2021-12-07T02:08:44.627' AS DateTime), CAST(N'2021-12-07T02:08:44.627' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [Code], [Name], [Price], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (1, N'4ab48e7e-fa6c-4d22-914f-3aeb16c2aff6', N'Chef Anton Cajun Seasoning', CAST(22.00 AS Decimal(18, 2)), 0, CAST(N'2021-12-07T02:10:27.457' AS DateTime), CAST(N'2021-12-07T02:10:27.457' AS DateTime))
GO
INSERT [dbo].[Product] ([Id], [Code], [Name], [Price], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, N'c5d9c5d4-51ed-469e-a7ce-9fba9166a27b', N'Chef Anton Gumbo Mix', CAST(34.00 AS Decimal(18, 2)), 0, CAST(N'2021-12-07T02:10:35.310' AS DateTime), CAST(N'2021-12-07T02:10:35.310' AS DateTime))
GO
INSERT [dbo].[Product] ([Id], [Code], [Name], [Price], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (3, N'260c0a0c-18dc-476a-bf9c-c588a4e5cc74', N'Boysenberry Spread', CAST(11.00 AS Decimal(18, 2)), 0, CAST(N'2021-12-07T02:10:42.570' AS DateTime), CAST(N'2021-12-07T02:10:42.570' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CreatedOnUtc]  DEFAULT (getdate()) FOR [CreatedOnUtc]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_UpdatedOnUtc]  DEFAULT (getdate()) FOR [UpdatedOnUtc]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreatedOnUtc]  DEFAULT (getdate()) FOR [CreatedOnUtc]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_UpdatedOnUtc]  DEFAULT (getdate()) FOR [UpdatedOnUtc]
GO

-- [MultiTenantDB_3] Init Script

USE [MultiTenantDB_3]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
	[UpdatedOnUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
	[UpdatedOnUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, N'efd86c70-ddf9-42be-8817-3fa8f241536d', N'Cem', N'Andersen', N'cem@andersen.com', 0, CAST(N'2021-12-07T02:07:13.610' AS DateTime), CAST(N'2021-12-07T02:07:13.610' AS DateTime))
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (3, N'4d34f0b1-8688-4a7b-813e-9215ac246aba', N'Aisha', N'Rees', N'aisha@rees.com', 0, CAST(N'2021-12-07T02:07:32.450' AS DateTime), CAST(N'2021-12-07T02:07:32.450' AS DateTime))
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (4, N'9a6bdc1c-ed82-4d7b-8abd-be632bf7919d', N'Iosif', N'Duffy', N'iosif@duffy.com', 0, CAST(N'2021-12-07T02:07:43.500' AS DateTime), CAST(N'2021-12-07T02:07:43.500' AS DateTime))
GO
INSERT [dbo].[Customer] ([Id], [Code], [FirstName], [LastName], [Email], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (5, N'5c61ff09-4a14-43c7-85f3-77aeb65a5e91', N'Poppy', N'Dunlap', N'poppy@dunlap.com', 0, CAST(N'2021-12-07T02:08:44.627' AS DateTime), CAST(N'2021-12-07T02:08:44.627' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [Code], [Name], [Price], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (1, N'09ff4d13-d531-4e75-b5c5-15062852bf23', N'Mishi Kobe Niku', CAST(97.00 AS Decimal(18, 2)), 0, CAST(N'2021-12-07T02:10:27.457' AS DateTime), CAST(N'2021-12-07T02:10:27.457' AS DateTime))
GO
INSERT [dbo].[Product] ([Id], [Code], [Name], [Price], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, N'd6cab77c-579e-4d49-8140-dcb35bef828e', N'Ikura', CAST(40.00 AS Decimal(18, 2)), 0, CAST(N'2021-12-07T02:10:35.310' AS DateTime), CAST(N'2021-12-07T02:10:35.310' AS DateTime))
GO
INSERT [dbo].[Product] ([Id], [Code], [Name], [Price], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (3, N'd86588d0-0c24-469e-87f3-5aad2e36f369', N'Queso Cabrales', CAST(64.00 AS Decimal(18, 2)), 0, CAST(N'2021-12-07T02:10:42.570' AS DateTime), CAST(N'2021-12-07T02:10:42.570' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CreatedOnUtc]  DEFAULT (getdate()) FOR [CreatedOnUtc]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_UpdatedOnUtc]  DEFAULT (getdate()) FOR [UpdatedOnUtc]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreatedOnUtc]  DEFAULT (getdate()) FOR [CreatedOnUtc]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_UpdatedOnUtc]  DEFAULT (getdate()) FOR [UpdatedOnUtc]
GO