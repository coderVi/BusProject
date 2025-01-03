USE [master]
GO
/****** Object:  Database [BusesDB]    Script Date: 1.01.2025 23:57:36 ******/
CREATE DATABASE [BusesDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BusesDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BusesDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BusesDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BusesDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BusesDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BusesDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BusesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BusesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BusesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BusesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BusesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BusesDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BusesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BusesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BusesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BusesDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BusesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BusesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BusesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BusesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BusesDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BusesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BusesDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BusesDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BusesDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BusesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BusesDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BusesDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BusesDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BusesDB] SET  MULTI_USER 
GO
ALTER DATABASE [BusesDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BusesDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BusesDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BusesDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BusesDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BusesDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BusesDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [BusesDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BusesDB]
GO
/****** Object:  Table [dbo].[GunlukArsiv]    Script Date: 1.01.2025 23:57:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GunlukArsiv](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KayitId] [int] NULL,
	[plaka] [nvarchar](50) NULL,
	[tarih] [datetime] NULL,
	[hasilat] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kayit]    Script Date: 1.01.2025 23:57:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kayit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[plaka] [nvarchar](50) NULL,
	[tarih] [datetime] NULL,
	[hasilat] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_otobus]    Script Date: 1.01.2025 23:57:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_otobus](
	[otobusID] [int] IDENTITY(1,1) NOT NULL,
	[otobusAdi] [nvarchar](30) NULL,
	[resim] [nvarchar](max) NULL,
	[plaka] [char](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[otobusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sefer]    Script Date: 1.01.2025 23:57:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sefer](
	[seferID] [int] IDENTITY(1,1) NOT NULL,
	[otobusID] [int] NULL,
	[yolcuID] [int] NULL,
	[seferKalkis] [nvarchar](17) NULL,
	[seferVaris] [nvarchar](17) NULL,
	[Tutar] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[seferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sehirler]    Script Date: 1.01.2025 23:57:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sehirler](
	[SehirID] [int] IDENTITY(1,1) NOT NULL,
	[SehirAdi] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SehirID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_yolcu]    Script Date: 1.01.2025 23:57:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_yolcu](
	[YolcuID] [int] IDENTITY(1,1) NOT NULL,
	[yolcuAdi] [nvarchar](30) NULL,
	[yolcuSoyad] [nvarchar](20) NULL,
	[otobusNo] [int] NULL,
	[koltukNo] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[YolcuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GunlukArsiv]  WITH CHECK ADD FOREIGN KEY([KayitId])
REFERENCES [dbo].[kayit] ([ID])
GO
ALTER TABLE [dbo].[tbl_sefer]  WITH CHECK ADD FOREIGN KEY([otobusID])
REFERENCES [dbo].[tbl_otobus] ([otobusID])
GO
ALTER TABLE [dbo].[tbl_sefer]  WITH CHECK ADD FOREIGN KEY([yolcuID])
REFERENCES [dbo].[tbl_yolcu] ([YolcuID])
GO
ALTER TABLE [dbo].[tbl_yolcu]  WITH CHECK ADD FOREIGN KEY([otobusNo])
REFERENCES [dbo].[tbl_otobus] ([otobusID])
GO
USE [master]
GO
ALTER DATABASE [BusesDB] SET  READ_WRITE 
GO
