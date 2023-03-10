USE [master]
GO
/****** Object:  Database [db_reservation]    Script Date: 12/14/2022 7:28:19 PM ******/
CREATE DATABASE [db_reservation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_reservation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\db_reservation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_reservation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\db_reservation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_reservation] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_reservation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_reservation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_reservation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_reservation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_reservation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_reservation] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_reservation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_reservation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_reservation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_reservation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_reservation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_reservation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_reservation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_reservation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_reservation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_reservation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_reservation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_reservation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_reservation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_reservation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_reservation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_reservation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_reservation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_reservation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_reservation] SET  MULTI_USER 
GO
ALTER DATABASE [db_reservation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_reservation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_reservation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_reservation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_reservation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_reservation] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db_reservation] SET QUERY_STORE = OFF
GO
USE [db_reservation]
GO
/****** Object:  Table [dbo].[t_profile]    Script Date: 12/14/2022 7:28:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_profile](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_station]    Script Date: 12/14/2022 7:28:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_station](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_ticket]    Script Date: 12/14/2022 7:28:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_ticket](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[chauffeur] [int] NULL,
	[passager] [int] NULL,
	[date] [date] NULL,
	[station_depart] [nvarchar](50) NULL,
	[station_arrive] [nvarchar](50) NULL,
	[prix] [real] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_user]    Script Date: 12/14/2022 7:28:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [nvarchar](50) NULL,
	[login] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[profile] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_ticket]  WITH CHECK ADD FOREIGN KEY([chauffeur])
REFERENCES [dbo].[t_user] ([id])
GO
ALTER TABLE [dbo].[t_ticket]  WITH CHECK ADD FOREIGN KEY([passager])
REFERENCES [dbo].[t_user] ([id])
GO
ALTER TABLE [dbo].[t_user]  WITH CHECK ADD FOREIGN KEY([profile])
REFERENCES [dbo].[t_profile] ([id])
GO
USE [master]
GO
ALTER DATABASE [db_reservation] SET  READ_WRITE 
GO
