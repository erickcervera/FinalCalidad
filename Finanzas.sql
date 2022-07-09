USE [master]
GO
/****** Object:  Database [Finanzas]    Script Date: 8/07/2022 21:12:58 ******/
CREATE DATABASE [Finanzas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Finanzas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Finanzas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Finanzas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Finanzas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Finanzas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Finanzas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Finanzas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Finanzas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Finanzas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Finanzas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Finanzas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Finanzas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Finanzas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Finanzas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Finanzas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Finanzas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Finanzas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Finanzas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Finanzas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Finanzas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Finanzas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Finanzas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Finanzas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Finanzas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Finanzas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Finanzas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Finanzas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Finanzas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Finanzas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Finanzas] SET  MULTI_USER 
GO
ALTER DATABASE [Finanzas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Finanzas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Finanzas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Finanzas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Finanzas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Finanzas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Finanzas] SET QUERY_STORE = OFF
GO
USE [Finanzas]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 8/07/2022 21:12:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NULL,
	[Nombre] [nvarchar](25) NULL,
	[Saldo] [decimal](10, 2) NULL,
	[Limite] [decimal](10, 2) NULL,
	[IdMoneda] [int] NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaccion]    Script Date: 8/07/2022 21:12:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCuenta] [int] NULL,
	[IdTipo] [int] NULL,
	[Fecha] [date] NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Monto] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Transaccion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Finanzas] SET  READ_WRITE 
GO
