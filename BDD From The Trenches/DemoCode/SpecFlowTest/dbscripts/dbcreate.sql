/****** Create the Test Database **********/

USE [master]
GO

/****** Object:  Database [testdb]    Script Date: 03/14/2011 09:54:30 ******/
CREATE DATABASE [testdb] ON  PRIMARY 
( NAME = N'testdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\testdb.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'testdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\testdb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [testdb] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [testdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [testdb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [testdb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [testdb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [testdb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [testdb] SET ARITHABORT OFF 
GO

ALTER DATABASE [testdb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [testdb] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [testdb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [testdb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [testdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [testdb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [testdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [testdb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [testdb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [testdb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [testdb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [testdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [testdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [testdb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [testdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [testdb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [testdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [testdb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [testdb] SET  READ_WRITE 
GO

ALTER DATABASE [testdb] SET RECOVERY FULL 
GO

ALTER DATABASE [testdb] SET  MULTI_USER 
GO

ALTER DATABASE [testdb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [testdb] SET DB_CHAINING OFF 
GO

/****** Create the Test Database login on the server **********/
/****** Object:  Login [db-user]    Script Date: 03/14/2011 09:53:30 ******/
CREATE LOGIN [db-user] WITH PASSWORD=N'db-pass', DEFAULT_DATABASE=[testdb], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO


/****** Create the Test Database user **********/
USE [testdb]
GO

/****** Object:  User [db-user]    Script Date: 03/14/2011 09:55:19 ******/
GO

CREATE USER [db-user] FOR LOGIN [db-user] WITH DEFAULT_SCHEMA=[dbo]
GO


/****** Create Authentication Schema *********/
/****** Object:  Schema [Authentication]    Script Date: 03/14/2011 09:58:01 ******/
CREATE SCHEMA [Authentication] AUTHORIZATION [dbo]
GO
EXEC sp_addrolemember 'db_owner', 'db-user'
GO
