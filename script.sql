USE [master]
GO
/****** Object:  Database [Coal]    Script Date: 24.11.2023 4:43:48 ******/
CREATE DATABASE [Coal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Cool.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Cool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Cool_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Coal] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Coal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Coal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Coal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Coal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Coal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Coal] SET ARITHABORT OFF 
GO
ALTER DATABASE [Coal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Coal] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Coal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Coal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Coal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Coal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Coal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Coal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Coal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Coal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Coal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Coal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Coal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Coal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Coal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Coal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Coal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Coal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Coal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Coal] SET  MULTI_USER 
GO
ALTER DATABASE [Coal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Coal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Coal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Coal] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Coal]
GO
/****** Object:  Table [dbo].[CIty]    Script Date: 24.11.2023 4:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CIty](
	[ID_city] [int] IDENTITY(1,1) NOT NULL,
	[city] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CIty] PRIMARY KEY CLUSTERED 
(
	[ID_city] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[City_coal]    Script Date: 24.11.2023 4:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City_coal](
	[ID_city_coal] [int] IDENTITY(1,1) NOT NULL,
	[City_coal] [varchar](50) NOT NULL,
 CONSTRAINT [PK_City_coal] PRIMARY KEY CLUSTERED 
(
	[ID_city_coal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Home]    Script Date: 24.11.2023 4:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Home](
	[ID_address] [int] IDENTITY(1,1) NOT NULL,
	[home] [varchar](5) NOT NULL,
	[ID_street] [int] NOT NULL,
 CONSTRAINT [PK_Home_1] PRIMARY KEY CLUSTERED 
(
	[ID_address] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 24.11.2023 4:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID_order] [int] IDENTITY(1,1) NOT NULL,
	[ID_fiz] [int] NOT NULL,
	[Date_order] [date] NOT NULL,
	[sum_order] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID_order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ordered_coal]    Script Date: 24.11.2023 4:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordered_coal](
	[ID_coal] [int] IDENTITY(1,1) NOT NULL,
	[ID_order] [int] NOT NULL,
	[ID_type_coal] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_Coal_grade] PRIMARY KEY CLUSTERED 
(
	[ID_coal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Physical_person]    Script Date: 24.11.2023 4:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Physical_person](
	[ID_fiz] [int] IDENTITY(1,1) NOT NULL,
	[ID_address] [int] NOT NULL,
	[FIO] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Physical_person] PRIMARY KEY CLUSTERED 
(
	[ID_fiz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Street]    Script Date: 24.11.2023 4:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Street](
	[ID_street] [int] IDENTITY(1,1) NOT NULL,
	[street] [varchar](50) NOT NULL,
	[ID_city] [int] NOT NULL,
 CONSTRAINT [PK_Street] PRIMARY KEY CLUSTERED 
(
	[ID_street] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Type_coal]    Script Date: 24.11.2023 4:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Type_coal](
	[ID_type_coal] [int] IDENTITY(1,1) NOT NULL,
	[ID_city_coal] [int] NOT NULL,
	[Name_type] [varchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Total_quantity_coal] [int] NOT NULL,
 CONSTRAINT [PK_Type_coal] PRIMARY KEY CLUSTERED 
(
	[ID_type_coal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CIty] ON 

INSERT [dbo].[CIty] ([ID_city], [city]) VALUES (1, N'Chernogorsk')
INSERT [dbo].[CIty] ([ID_city], [city]) VALUES (2, N'Abakan')
SET IDENTITY_INSERT [dbo].[CIty] OFF
SET IDENTITY_INSERT [dbo].[City_coal] ON 

INSERT [dbo].[City_coal] ([ID_city_coal], [City_coal]) VALUES (1, N'Chernogorsk')
INSERT [dbo].[City_coal] ([ID_city_coal], [City_coal]) VALUES (2, N'Balakhtinsk')
SET IDENTITY_INSERT [dbo].[City_coal] OFF
SET IDENTITY_INSERT [dbo].[Home] ON 

INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (1, N'6A', 1)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (2, N'6', 1)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (3, N'13', 1)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (4, N'41', 2)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (6, N'39', 2)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (7, N'37', 2)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (8, N'38', 3)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (9, N'40', 3)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (10, N'42', 3)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (11, N'58', 4)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (12, N'56', 4)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (13, N'9A', 4)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (14, N'11', 5)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (15, N'29A', 6)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (16, N'2A', 6)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (17, N'30', 6)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (18, N'8', 7)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (19, N'201', 8)
INSERT [dbo].[Home] ([ID_address], [home], [ID_street]) VALUES (1019, N'6A', 1008)
SET IDENTITY_INSERT [dbo].[Home] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID_order], [ID_fiz], [Date_order], [sum_order]) VALUES (33, 2, CAST(0x1F460B00 AS Date), 285500)
INSERT [dbo].[Order] ([ID_order], [ID_fiz], [Date_order], [sum_order]) VALUES (34, 9, CAST(0x1F460B00 AS Date), 80000)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Ordered_coal] ON 

INSERT [dbo].[Ordered_coal] ([ID_coal], [ID_order], [ID_type_coal], [quantity]) VALUES (51, 33, 3, 1)
INSERT [dbo].[Ordered_coal] ([ID_coal], [ID_order], [ID_type_coal], [quantity]) VALUES (52, 33, 2, 1)
INSERT [dbo].[Ordered_coal] ([ID_coal], [ID_order], [ID_type_coal], [quantity]) VALUES (53, 33, 3, 20)
INSERT [dbo].[Ordered_coal] ([ID_coal], [ID_order], [ID_type_coal], [quantity]) VALUES (54, 33, 4, 20)
INSERT [dbo].[Ordered_coal] ([ID_coal], [ID_order], [ID_type_coal], [quantity]) VALUES (55, 33, 4, 20)
INSERT [dbo].[Ordered_coal] ([ID_coal], [ID_order], [ID_type_coal], [quantity]) VALUES (56, 34, 3, 6)
INSERT [dbo].[Ordered_coal] ([ID_coal], [ID_order], [ID_type_coal], [quantity]) VALUES (57, 34, 1, 3)
INSERT [dbo].[Ordered_coal] ([ID_coal], [ID_order], [ID_type_coal], [quantity]) VALUES (58, 34, 3, 5)
INSERT [dbo].[Ordered_coal] ([ID_coal], [ID_order], [ID_type_coal], [quantity]) VALUES (59, 34, 4, 6)
SET IDENTITY_INSERT [dbo].[Ordered_coal] OFF
SET IDENTITY_INSERT [dbo].[Physical_person] ON 

INSERT [dbo].[Physical_person] ([ID_fiz], [ID_address], [FIO]) VALUES (2, 14, N'Maliakin Viktor Sergeevich')
INSERT [dbo].[Physical_person] ([ID_fiz], [ID_address], [FIO]) VALUES (3, 4, N'Bolshakova Ksenia Timofeevna')
INSERT [dbo].[Physical_person] ([ID_fiz], [ID_address], [FIO]) VALUES (4, 6, N'Zharova Alyona Kirillovna')
INSERT [dbo].[Physical_person] ([ID_fiz], [ID_address], [FIO]) VALUES (5, 1, N'Nikulina Valeria Ilyinichna')
INSERT [dbo].[Physical_person] ([ID_fiz], [ID_address], [FIO]) VALUES (8, 9, N'Titov Artem Leonovich')
INSERT [dbo].[Physical_person] ([ID_fiz], [ID_address], [FIO]) VALUES (9, 7, N'Melnikov Bogdan Dmitrievich')
INSERT [dbo].[Physical_person] ([ID_fiz], [ID_address], [FIO]) VALUES (10, 8, N'Ivanov Ruslan Alekseevich')
INSERT [dbo].[Physical_person] ([ID_fiz], [ID_address], [FIO]) VALUES (11, 18, N'Kovzalina Victoria Igorevna')
INSERT [dbo].[Physical_person] ([ID_fiz], [ID_address], [FIO]) VALUES (12, 19, N'Malakhova Vera Dmitrievna')
INSERT [dbo].[Physical_person] ([ID_fiz], [ID_address], [FIO]) VALUES (1012, 1019, N'Malyakin Sergey Nikolaevich')
SET IDENTITY_INSERT [dbo].[Physical_person] OFF
SET IDENTITY_INSERT [dbo].[Street] ON 

INSERT [dbo].[Street] ([ID_street], [street], [ID_city]) VALUES (1, N'Academic Street', 2)
INSERT [dbo].[Street] ([ID_street], [street], [ID_city]) VALUES (2, N'Biysk Street', 2)
INSERT [dbo].[Street] ([ID_street], [street], [ID_city]) VALUES (3, N'Birch Street', 2)
INSERT [dbo].[Street] ([ID_street], [street], [ID_city]) VALUES (4, N'Automobile street', 1)
INSERT [dbo].[Street] ([ID_street], [street], [ID_city]) VALUES (5, N'Bazarnaya Street', 1)
INSERT [dbo].[Street] ([ID_street], [street], [ID_city]) VALUES (6, N'Bogradsky Lane', 1)
INSERT [dbo].[Street] ([ID_street], [street], [ID_city]) VALUES (7, N'Star Street', 2)
INSERT [dbo].[Street] ([ID_street], [street], [ID_city]) VALUES (8, N'Linear Street', 2)
INSERT [dbo].[Street] ([ID_street], [street], [ID_city]) VALUES (1008, N'rainbow', 2)
SET IDENTITY_INSERT [dbo].[Street] OFF
SET IDENTITY_INSERT [dbo].[Type_coal] ON 

INSERT [dbo].[Type_coal] ([ID_type_coal], [ID_city_coal], [Name_type], [Price], [Total_quantity_coal]) VALUES (1, 1, N'concentrate', 3100, 334)
INSERT [dbo].[Type_coal] ([ID_type_coal], [ID_city_coal], [Name_type], [Price], [Total_quantity_coal]) VALUES (2, 1, N'varietal', 3000, 572)
INSERT [dbo].[Type_coal] ([ID_type_coal], [ID_city_coal], [Name_type], [Price], [Total_quantity_coal]) VALUES (3, 2, N'nut', 3500, 677)
INSERT [dbo].[Type_coal] ([ID_type_coal], [ID_city_coal], [Name_type], [Price], [Total_quantity_coal]) VALUES (4, 2, N'seed', 3700, 1162)
SET IDENTITY_INSERT [dbo].[Type_coal] OFF
ALTER TABLE [dbo].[Home]  WITH CHECK ADD  CONSTRAINT [FK_Home_Street] FOREIGN KEY([ID_street])
REFERENCES [dbo].[Street] ([ID_street])
GO
ALTER TABLE [dbo].[Home] CHECK CONSTRAINT [FK_Home_Street]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Physical_person] FOREIGN KEY([ID_fiz])
REFERENCES [dbo].[Physical_person] ([ID_fiz])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Physical_person]
GO
ALTER TABLE [dbo].[Ordered_coal]  WITH CHECK ADD  CONSTRAINT [FK_Coal_grade_Order] FOREIGN KEY([ID_order])
REFERENCES [dbo].[Order] ([ID_order])
GO
ALTER TABLE [dbo].[Ordered_coal] CHECK CONSTRAINT [FK_Coal_grade_Order]
GO
ALTER TABLE [dbo].[Ordered_coal]  WITH CHECK ADD  CONSTRAINT [FK_Coal_grade_Type_coal] FOREIGN KEY([ID_type_coal])
REFERENCES [dbo].[Type_coal] ([ID_type_coal])
GO
ALTER TABLE [dbo].[Ordered_coal] CHECK CONSTRAINT [FK_Coal_grade_Type_coal]
GO
ALTER TABLE [dbo].[Physical_person]  WITH CHECK ADD  CONSTRAINT [FK_Physical_person_Home] FOREIGN KEY([ID_address])
REFERENCES [dbo].[Home] ([ID_address])
GO
ALTER TABLE [dbo].[Physical_person] CHECK CONSTRAINT [FK_Physical_person_Home]
GO
ALTER TABLE [dbo].[Street]  WITH CHECK ADD  CONSTRAINT [FK_Street_CIty] FOREIGN KEY([ID_city])
REFERENCES [dbo].[CIty] ([ID_city])
GO
ALTER TABLE [dbo].[Street] CHECK CONSTRAINT [FK_Street_CIty]
GO
ALTER TABLE [dbo].[Type_coal]  WITH CHECK ADD  CONSTRAINT [FK_Type_coal_City_coal] FOREIGN KEY([ID_city_coal])
REFERENCES [dbo].[City_coal] ([ID_city_coal])
GO
ALTER TABLE [dbo].[Type_coal] CHECK CONSTRAINT [FK_Type_coal_City_coal]
GO
USE [master]
GO
ALTER DATABASE [Coal] SET  READ_WRITE 
GO
