USE [vesisgestiontfhka]
GO
/****** Object:  User [IIS APPPOOL\Access]    Script Date: 25/02/2021 5:02:18 p. m. ******/
CREATE USER [IIS APPPOOL\Access] FOR LOGIN [IIS APPPOOL\Access] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\Clients]    Script Date: 25/02/2021 5:02:19 p. m. ******/
CREATE USER [IIS APPPOOL\Clients] FOR LOGIN [IIS APPPOOL\Clients] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\DefaultAppPool]    Script Date: 25/02/2021 5:02:19 p. m. ******/
CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\Employees]    Script Date: 25/02/2021 5:02:19 p. m. ******/
CREATE USER [IIS APPPOOL\Employees] FOR LOGIN [IIS APPPOOL\Employees] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\Operations]    Script Date: 25/02/2021 5:02:19 p. m. ******/
CREATE USER [IIS APPPOOL\Operations] FOR LOGIN [IIS APPPOOL\Operations] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\Products]    Script Date: 25/02/2021 5:02:19 p. m. ******/
CREATE USER [IIS APPPOOL\Products] FOR LOGIN [IIS APPPOOL\Products] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\Utilities]    Script Date: 25/02/2021 5:02:19 p. m. ******/
CREATE USER [IIS APPPOOL\Utilities] FOR LOGIN [IIS APPPOOL\Utilities] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\WorksOrders]    Script Date: 25/02/2021 5:02:19 p. m. ******/
CREATE USER [IIS APPPOOL\WorksOrders] FOR LOGIN [IIS APPPOOL\WorksOrders] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Access]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Clients]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Employees]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Operations]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Products]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\Utilities]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [IIS APPPOOL\Utilities]
GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\WorksOrders]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Accessories]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Accessories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Accessories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_AccessoriesOrders]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_AccessoriesOrders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[accesoryId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_AccessoriesOrders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Accessroles]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Accessroles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[level] [int] NOT NULL,
	[description] [nvarchar](max) NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Accessroles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Activities]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Activities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[process] [varchar](150) NOT NULL,
	[operation] [varchar](150) NOT NULL,
	[serial] [varchar](13) NOT NULL,
	[detail] [varchar](150) NOT NULL,
	[operationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_Activities] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Alienations]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Alienations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[serial] [varchar](13) NOT NULL,
	[providerId] [int] NOT NULL,
	[distributorId] [int] NOT NULL,
	[finalclientId] [int] NOT NULL,
	[status] [varchar](20) NOT NULL,
	[observations] [varchar](350) NULL,
	[alienationDate] [datetime] NOT NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_Alienations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_CasesProducts]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_CasesProducts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[caseSoftwareHouseId] [int] NULL,
	[productId] [int] NULL,
 CONSTRAINT [PK_Sisg_CasesProducts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_CasesSoftwareHouses]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_CasesSoftwareHouses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[contactShape] [varchar](100) NULL,
	[page] [varchar](255) NULL,
	[systemAdmin] [varchar](255) NOT NULL,
	[versionSystemAdmin] [varchar](20) NOT NULL,
	[descriptionCase] [varchar](max) NOT NULL,
	[otherLanguage] [varchar](100) NULL,
	[employeeId] [int] NULL,
	[developersClientsId] [int] NOT NULL,
	[systemOperId] [int] NOT NULL,
	[statusId] [int] NOT NULL,
	[programLanguageId] [int] NOT NULL,
	[dateRegister] [datetime] NULL,
	[dateLastContact] [datetime] NOT NULL,
	[clientType] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_CasesSoftwareHouses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Categories]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Chargues]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Chargues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](150) NOT NULL,
	[rolId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_Chargues] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Countries]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Countries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](60) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_DeliveryOrder]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_DeliveryOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[deliveryMode] [int] NOT NULL,
	[liableId] [int] NULL,
	[liableName] [varchar](40) NULL,
	[liablePhone] [varchar](100) NULL,
	[guideNumber] [varchar](25) NULL,
	[companyName] [varchar](50) NULL,
	[address] [varchar](150) NULL,
	[observation] [varchar](150) NULL,
	[dispatchDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_DeliveryOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Departaments]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Departaments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Sisg_Departaments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_DevelopersClients]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_DevelopersClients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[document] [varchar](12) NOT NULL,
	[description] [varchar](100) NOT NULL,
	[address] [varchar](150) NOT NULL,
	[country] [varchar](100) NOT NULL,
	[state] [varchar](100) NOT NULL,
	[city] [varchar](100) NOT NULL,
	[phone] [varchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[enable] [int] NOT NULL,
	[creation_date] [datetime] NULL,
 CONSTRAINT [PK_Sisg_Developers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_DevelopersClientsUsers]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_DevelopersClientsUsers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[developersclientsId] [int] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_DevelopersClientsUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Distributors]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Distributors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idSA] [int] NOT NULL,
	[rif] [varchar](12) NOT NULL,
	[description] [nvarchar](max) NULL,
	[represent] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[country] [nvarchar](max) NULL,
	[state] [nvarchar](max) NULL,
	[city] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[email] [varchar](150) NOT NULL,
	[nit] [nvarchar](max) NULL,
	[codeZone] [nvarchar](max) NULL,
	[nameSeller] [nvarchar](max) NULL,
	[rifSeller] [nvarchar](max) NULL,
	[phoneSeller] [nvarchar](max) NULL,
	[typeAgreement] [nvarchar](max) NULL,
	[enable] [int] NOT NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Distributors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_DistributorsProviders]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_DistributorsProviders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DistributorsId] [int] NOT NULL,
	[ProviderId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_DistributorsProviders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_DistributorsUsers]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_DistributorsUsers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DistributorsId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_DistributorsUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Employees]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[supervitorId] [int] NOT NULL,
	[rif] [varchar](12) NOT NULL,
	[code] [varchar](20) NOT NULL,
	[description] [varchar](150) NOT NULL,
	[departamentId] [int] NOT NULL,
	[chargueId] [int] NOT NULL,
	[email] [varchar](100) NOT NULL,
	[phone] [varchar](100) NOT NULL,
	[enable] [int] NOT NULL,
	[creation_date] [datetime] NULL,
 CONSTRAINT [PK_Sisg_Employees] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_EmployeesUsers]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_EmployeesUsers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_EmployeesUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_File_ProgramLenguages]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_File_ProgramLenguages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[infoFileId] [int] NOT NULL,
	[programLenguagesId] [int] NULL,
 CONSTRAINT [PK_Sisg_File_ProgramLenguages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_File_SystemOpers]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_File_SystemOpers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[infoFileId] [int] NULL,
	[systemOpersId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_File_SystemOpers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_FileSection]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_FileSection](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](150) NOT NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_FileSection] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_FileStatus]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_FileStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](150) NOT NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_FileStatus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_FinalsClients]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_FinalsClients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rif] [varchar](10) NOT NULL,
	[description] [varchar](100) NOT NULL,
	[name] [varchar](100) NULL,
	[lastName] [varchar](100) NULL,
	[phone] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[fiscalAddress] [varchar](150) NULL,
	[enable] [int] NOT NULL,
	[creation_date] [datetime] NULL,
 CONSTRAINT [PK_Sisg_FinalsClients] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_FinalsClientsUsers]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_FinalsClientsUsers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[finalsclientsId] [int] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_FinalsClientsUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_FiscalsOperations]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_FiscalsOperations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fiscalOperation] [varchar](30) NOT NULL,
	[fiscalMode] [varchar](30) NOT NULL,
	[providerId] [int] NOT NULL,
	[distributorId] [int] NOT NULL,
	[technicianId] [int] NOT NULL,
	[finalClientId] [int] NOT NULL,
	[serial] [varchar](13) NOT NULL,
	[initSeal] [varchar](20) NOT NULL,
	[finalSeal] [varchar](20) NOT NULL,
	[fiscalAddress] [varchar](200) NOT NULL,
	[fiscalResult] [int] NOT NULL,
	[serialRetative] [varchar](13) NOT NULL,
	[codeOperation] [varchar](9) NOT NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_FiscalsOperations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Idiom]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Idiom](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](150) NOT NULL,
	[visible] [int] NOT NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Idiom] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_InfoFile]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_InfoFile](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[description] [varchar](255) NOT NULL,
	[additionalInformation] [varchar](255) NOT NULL,
	[idiomId] [int] NULL,
	[path_file] [varchar](255) NULL,
	[typefileId] [int] NULL,
	[productId] [int] NOT NULL,
	[markId] [int] NOT NULL,
	[file_SystemOperId] [int] NULL,
	[file_ProgramLenguageId] [int] NULL,
	[fileSectionId] [int] NOT NULL,
	[fileStatusId] [int] NOT NULL,
	[visible_status] [int] NOT NULL,
	[minVersion] [varchar](45) NULL,
	[lastVersion] [varchar](45) NULL,
	[statusServer] [varchar](100) NULL,
	[isGetMns] [int] NULL,
	[msnServer] [varchar](255) NULL,
	[descriptionVersion] [varchar](255) NULL,
	[urlDownload] [varchar](255) NULL,
	[creation_date] [datetime] NULL,
	[publication_date] [datetime] NOT NULL,
	[development_comment] [varchar](255) NULL,
	[test_commentary] [varchar](255) NULL,
 CONSTRAINT [PK_Sisg_File] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Marks]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Marks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Marks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Menus]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Menus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[parentId] [int] NOT NULL,
	[view] [nvarchar](max) NULL,
	[level] [int] NOT NULL,
	[order] [int] NOT NULL,
	[url] [nvarchar](max) NULL,
	[visible] [int] NOT NULL,
	[path_icon] [nvarchar](max) NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Menus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Models]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Models](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[markId] [int] NOT NULL,
	[name] [varchar](150) NOT NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Models] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_PhotographsOrder]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_PhotographsOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[imageUrl] [varchar](150) NOT NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_PhotographsOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Prefixes]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Prefixes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[initCorrelative] [varchar](4) NOT NULL,
	[initAlphaNum] [varchar](4) NOT NULL,
	[creation_date] [datetime] NULL,
 CONSTRAINT [PK_Sisg_Prefixes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Products]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prefixId] [int] NULL,
	[categoryId] [int] NOT NULL,
	[modelId] [int] NOT NULL,
	[name] [varchar](100) NOT NULL,
	[description] [varchar](150) NULL,
	[code] [varchar](45) NOT NULL,
	[state] [int] NOT NULL,
	[imageUrl] [varchar](150) NULL,
	[creation_date] [datetime] NULL,
 CONSTRAINT [PK_Sisg_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_ProductsAccessories]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_ProductsAccessories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NOT NULL,
	[accessoryId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_ProductsAccessories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_ProductsReplacements]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_ProductsReplacements](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NOT NULL,
	[replacementId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_ProductsReplacements] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Profiles]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Profiles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Profiles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_ProgramLenguages]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_ProgramLenguages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[visible] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_ProgramLenguages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Providers]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Providers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rif] [varchar](12) NOT NULL,
	[description] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[email] [varchar](150) NULL,
	[image] [nvarchar](max) NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Providers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Replacements]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Replacements](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prefixId] [int] NULL,
	[modelId] [int] NOT NULL,
	[name] [varchar](100) NOT NULL,
	[description] [varchar](150) NULL,
	[code] [varchar](45) NULL,
	[parts] [varchar](45) NOT NULL,
	[state] [int] NOT NULL,
	[imageUrl] [varchar](150) NULL,
	[creation_date] [datetime] NULL,
 CONSTRAINT [PK_Sisg_Replacements] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_ReplacementsOpetechs]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_ReplacementsOpetechs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[operationTechId] [int] NOT NULL,
	[replacementId] [int] NOT NULL,
	[serial] [varchar](13) NOT NULL,
	[date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_ReplacementsOpetechs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_ReplacementsOrders]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_ReplacementsOrders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[replacementId] [int] NOT NULL,
	[enable] [int] NOT NULL,
	[employeeId] [int] NOT NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_ReplacementsOrders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Roles]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](max) NULL,
	[accessId] [int] NOT NULL,
	[profileId] [int] NOT NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Rolesmenus]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Rolesmenus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NOT NULL,
	[RolId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_Rolesmenus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_SerialsProducts]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_SerialsProducts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[serial] [varchar](13) NOT NULL,
	[productId] [int] NOT NULL,
	[distributorId] [int] NOT NULL,
	[providerId] [int] NOT NULL,
	[dateSale] [datetime] NOT NULL,
	[observations] [varchar](150) NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_SerialsProducts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_SerialsReplacements]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_SerialsReplacements](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[serial] [varchar](25) NOT NULL,
	[replacementId] [int] NOT NULL,
	[distributorId] [int] NOT NULL,
	[providerId] [int] NOT NULL,
	[dateSale] [datetime] NOT NULL,
	[observations] [varchar](150) NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_SerialsReplacements] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_States]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_States](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NOT NULL,
	[countryId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_StatesOrder]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_StatesOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](150) NOT NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_StatesOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_StatesWarranty]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_StatesWarranty](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](150) NOT NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_StatesWarranty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_StatusIntegrations]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_StatusIntegrations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[visible] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_StatusIntegrations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_SystemOpers]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_SystemOpers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[visible] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_SystemOpers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_TechnicalsOperations]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_TechnicalsOperations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[providerId] [int] NOT NULL,
	[distributorId] [int] NOT NULL,
	[finalClientId] [int] NOT NULL,
	[technicianId] [int] NOT NULL,
	[typeOperationTechId] [int] NOT NULL,
	[serial] [varchar](13) NOT NULL,
	[observation] [varchar](100) NULL,
	[status] [varchar](50) NOT NULL,
	[operation_date] [datetime] NOT NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_TechnicalsOperations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Technicians]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Technicians](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rif] [varchar](12) NOT NULL,
	[description] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[email] [varchar](150) NOT NULL,
	[enable] [int] NOT NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Technicians] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_TechniciansDistributors]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_TechniciansDistributors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[techniciansId] [int] NOT NULL,
	[distributorsId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_TechniciansDistributors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_TechniciansUsers]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_TechniciansUsers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[techniciansId] [int] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_Sisg_TechniciansUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_TypeFile]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_TypeFile](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](150) NOT NULL,
	[visible] [int] NOT NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_TypeFile] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_TypeOperationsTechs]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_TypeOperationsTechs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](100) NOT NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_Sisg_TypeOperationsTechs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_TypesFailures]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_TypesFailures](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](150) NOT NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_TypesFailures] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_Users]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rolId] [int] NOT NULL,
	[username] [varchar](150) NOT NULL,
	[password] [varchar](150) NOT NULL,
	[enable] [int] NOT NULL,
	[creation_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sisg_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_WorkshopBinnacles]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_WorkshopBinnacles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[statusId] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[creation_date] [datetime] NOT NULL,
	[observation] [varchar](500) NULL,
 CONSTRAINT [PK_Sisg_WorkshopBinnacles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sisg_WorkshopOrders]    Script Date: 25/02/2021 5:02:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sisg_WorkshopOrders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numerOrder] [varchar](30) NOT NULL,
	[kindEquipment] [int] NOT NULL,
	[equipment] [int] NOT NULL,
	[serial] [varchar](13) NOT NULL,
	[warrantyId] [int] NOT NULL,
	[distributorId] [int] NOT NULL,
	[typeFailurId] [int] NOT NULL,
	[stateOrderId] [int] NOT NULL,
	[deliveryOrderId] [int] NULL,
	[employeeId] [int] NOT NULL,
	[firmwareVersion] [varchar](45) NULL,
	[deliverDate] [datetime] NULL,
	[receptionDate] [datetime] NULL,
	[alienationDate] [datetime] NULL,
	[expirationDate] [datetime] NULL,
	[address] [varchar](150) NOT NULL,
	[contact] [varchar](150) NOT NULL,
	[phone] [varchar](50) NULL,
	[insertionOrigin] [int] NOT NULL,
	[workDone] [varchar](150) NULL,
	[customerReview] [varchar](150) NOT NULL,
	[observationTechnical] [varchar](150) NULL,
	[extraObservation] [varchar](150) NULL,
	[creation_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Sisg_WorkshopOrders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190705203644_InitialCreate', N'2.1.8-servicing-32085')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190705204339_InitialCreate', N'2.1.8-servicing-32085')
SET IDENTITY_INSERT [dbo].[Sisg_Accessories] ON 

INSERT [dbo].[Sisg_Accessories] ([id], [name], [description], [creation_date]) VALUES (1, N'Manual de Usuario', NULL, CAST(N'2019-10-23T15:57:40.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessories] ([id], [name], [description], [creation_date]) VALUES (2, N'Cable de alimentación', N'3 metro', CAST(N'2019-10-23T15:58:05.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessories] ([id], [name], [description], [creation_date]) VALUES (3, N'Cable de prueba', N'3 metro', CAST(N'2019-10-23T17:31:25.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessories] ([id], [name], [description], [creation_date]) VALUES (4, N'Scanner Lector', N'EAN13', CAST(N'2019-10-23T15:57:40.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessories] ([id], [name], [description], [creation_date]) VALUES (5, N'Display Aclas', N'4 lineas', CAST(N'2019-10-23T15:58:05.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessories] ([id], [name], [description], [creation_date]) VALUES (6, N'Gaveta de Dinero', N'Aclas con cerradura electrica', CAST(N'2019-10-25T15:21:54.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessories] ([id], [name], [description], [creation_date]) VALUES (7, N'Hand Help', N'Dispositivo de lectura y extracción de datos', CAST(N'2019-10-25T15:23:05.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Accessories] OFF
SET IDENTITY_INSERT [dbo].[Sisg_AccessoriesOrders] ON 

INSERT [dbo].[Sisg_AccessoriesOrders] ([id], [orderId], [accesoryId]) VALUES (1, 2, 2)
INSERT [dbo].[Sisg_AccessoriesOrders] ([id], [orderId], [accesoryId]) VALUES (2, 4, 4)
INSERT [dbo].[Sisg_AccessoriesOrders] ([id], [orderId], [accesoryId]) VALUES (3, 4, 7)
INSERT [dbo].[Sisg_AccessoriesOrders] ([id], [orderId], [accesoryId]) VALUES (4, 5, 4)
INSERT [dbo].[Sisg_AccessoriesOrders] ([id], [orderId], [accesoryId]) VALUES (5, 6, 7)
SET IDENTITY_INSERT [dbo].[Sisg_AccessoriesOrders] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Accessroles] ON 

INSERT [dbo].[Sisg_Accessroles] ([id], [level], [description], [creation_date]) VALUES (1, 10, N'Super Usuario', CAST(N'2019-04-08T12:04:09.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessroles] ([id], [level], [description], [creation_date]) VALUES (2, 9, N'Avanzado', CAST(N'2019-04-08T12:04:21.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessroles] ([id], [level], [description], [creation_date]) VALUES (3, 8, N'Intermedio 3', CAST(N'2019-04-08T12:04:21.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessroles] ([id], [level], [description], [creation_date]) VALUES (4, 7, N'Intermedio 2', CAST(N'2019-04-08T12:04:21.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessroles] ([id], [level], [description], [creation_date]) VALUES (5, 6, N'Intermedio 1', CAST(N'2019-04-08T12:04:21.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessroles] ([id], [level], [description], [creation_date]) VALUES (6, 5, N'Básico 3', CAST(N'2019-04-08T12:04:21.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessroles] ([id], [level], [description], [creation_date]) VALUES (7, 4, N'Básico 2', CAST(N'2019-04-08T12:04:21.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessroles] ([id], [level], [description], [creation_date]) VALUES (8, 3, N'Básico 1', CAST(N'2019-04-08T12:04:21.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessroles] ([id], [level], [description], [creation_date]) VALUES (9, 2, N'Invitado', CAST(N'2019-04-08T12:04:21.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Accessroles] ([id], [level], [description], [creation_date]) VALUES (10, 1, N'Sin Privilegios', CAST(N'2019-04-08T12:04:21.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Accessroles] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Activities] ON 

INSERT [dbo].[Sisg_Activities] ([id], [employeeId], [process], [operation], [serial], [detail], [operationDate]) VALUES (1, 1, N'Seriales de Productos', N'Borrado', N'Z1B3332211', N'Se efectuo el cambio porque se importo un serial incorrecto', CAST(N'2020-06-04T13:40:00.000' AS DateTime))
INSERT [dbo].[Sisg_Activities] ([id], [employeeId], [process], [operation], [serial], [detail], [operationDate]) VALUES (2, 1, N'Seriales de Productos', N'Carga Manual', N'Z1B1234567', N'Para uso interno', CAST(N'2020-11-20T11:55:12.627' AS DateTime))
INSERT [dbo].[Sisg_Activities] ([id], [employeeId], [process], [operation], [serial], [detail], [operationDate]) VALUES (3, 1, N'Seriales de Productos', N'Carga Manual', N'DLA7000001', N'Para Distribudor partcular por Nota de Entrega', CAST(N'2020-11-24T15:02:06.403' AS DateTime))
INSERT [dbo].[Sisg_Activities] ([id], [employeeId], [process], [operation], [serial], [detail], [operationDate]) VALUES (4, 1, N'Seriales de Productos', N'Carga Manual', N'DLA7000002', N'Para Distribudor partcular por Nota de Entrega', CAST(N'2020-11-26T13:30:52.117' AS DateTime))
INSERT [dbo].[Sisg_Activities] ([id], [employeeId], [process], [operation], [serial], [detail], [operationDate]) VALUES (5, 1, N'Seriales de Productos', N'Carga Manual', N'Z1D9999999', N'Para uso interno', CAST(N'2020-11-30T15:55:15.377' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_Activities] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Alienations] ON 

INSERT [dbo].[Sisg_Alienations] ([id], [serial], [providerId], [distributorId], [finalclientId], [status], [observations], [alienationDate], [creation_date]) VALUES (1, N'Z1B1234567', 1, 9, 10, N'PROCESADO', N'Enajenación Manual', CAST(N'2020-11-20T11:57:55.143' AS DateTime), CAST(N'2020-11-20T11:58:02.623' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_Alienations] OFF
SET IDENTITY_INSERT [dbo].[Sisg_CasesProducts] ON 

INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (1, 1, 1)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (2, 1, 2)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (3, 2, 3)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (4, 5, 1)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (5, 5, 2)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (6, 6, 2)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (7, 8, 3)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (8, 9, 9)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (9, 3, 12)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (10, 3, 2)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (11, 4, 5)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (12, 4, 7)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (13, 4, 1)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (14, 2, 6)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (15, 6, 1)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (20, 8, 2)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (22, 8, 3)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (23, 9, 6)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (24, 9, 3)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (25, 11, 1)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (26, 11, 2)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (27, 11, 3)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (28, 12, 2)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (29, 12, 3)
INSERT [dbo].[Sisg_CasesProducts] ([id], [caseSoftwareHouseId], [productId]) VALUES (30, 13, 2)
SET IDENTITY_INSERT [dbo].[Sisg_CasesProducts] OFF
SET IDENTITY_INSERT [dbo].[Sisg_CasesSoftwareHouses] ON 

INSERT [dbo].[Sisg_CasesSoftwareHouses] ([id], [contactShape], [page], [systemAdmin], [versionSystemAdmin], [descriptionCase], [otherLanguage], [employeeId], [developersClientsId], [systemOperId], [statusId], [programLanguageId], [dateRegister], [dateLastContact], [clientType]) VALUES (1, N'Telefono', N'www.galac.com', N'GALAC ERP', N'6.9.87', N'Necesito SDK y Documentacion para integrar Impresora Fiscal a mi Sistema Administrativo', N'PL/SQL', 0, 1, 37, 1, 78, CAST(N'2020-11-30T10:00:39.000' AS DateTime), CAST(N'2020-11-30T10:00:39.000' AS DateTime), 1)
INSERT [dbo].[Sisg_CasesSoftwareHouses] ([id], [contactShape], [page], [systemAdmin], [versionSystemAdmin], [descriptionCase], [otherLanguage], [employeeId], [developersClientsId], [systemOperId], [statusId], [programLanguageId], [dateRegister], [dateLastContact], [clientType]) VALUES (2, N'Correo Electronico', N'www.saa.com', N'SAA Premium', N'7.9.57', N'Necesito integrar Impresora Fiscal a mi SAA de Peluqueria', N'C++', 0, 2, 38, 2, 18, CAST(N'2020-11-30T10:00:39.000' AS DateTime), CAST(N'2020-11-30T10:00:39.000' AS DateTime), 2)
INSERT [dbo].[Sisg_CasesSoftwareHouses] ([id], [contactShape], [page], [systemAdmin], [versionSystemAdmin], [descriptionCase], [otherLanguage], [employeeId], [developersClientsId], [systemOperId], [statusId], [programLanguageId], [dateRegister], [dateLastContact], [clientType]) VALUES (3, N'Telefono', N'www.deca.com', N'DECA POS', N'1.2.3', N'Necesito SDK', N'Go', 0, 29, 12, 1, 19, CAST(N'2020-12-23T23:13:40.000' AS DateTime), CAST(N'2020-12-23T23:13:40.000' AS DateTime), 3)
INSERT [dbo].[Sisg_CasesSoftwareHouses] ([id], [contactShape], [page], [systemAdmin], [versionSystemAdmin], [descriptionCase], [otherLanguage], [employeeId], [developersClientsId], [systemOperId], [statusId], [programLanguageId], [dateRegister], [dateLastContact], [clientType]) VALUES (4, N'Telefono', N'www.hpos.com', N'HERNAN POS', N'1.2.3', N'Necesito SDK', N'Go', 0, 32, 16, 1, 5, CAST(N'2020-12-28T20:48:49.000' AS DateTime), CAST(N'2020-12-28T20:48:49.000' AS DateTime), 3)
INSERT [dbo].[Sisg_CasesSoftwareHouses] ([id], [contactShape], [page], [systemAdmin], [versionSystemAdmin], [descriptionCase], [otherLanguage], [employeeId], [developersClientsId], [systemOperId], [statusId], [programLanguageId], [dateRegister], [dateLastContact], [clientType]) VALUES (5, N'Correo_Eletronico', N'www.pepita.com', N'Openbravo POS System', N'3.7.8', N'Requiero SDK Java', N'Java SE', 0, 33, 12, 1, 282, CAST(N'2021-01-07T20:20:57.000' AS DateTime), CAST(N'2021-01-07T20:20:57.000' AS DateTime), 1)
INSERT [dbo].[Sisg_CasesSoftwareHouses] ([id], [contactShape], [page], [systemAdmin], [versionSystemAdmin], [descriptionCase], [otherLanguage], [employeeId], [developersClientsId], [systemOperId], [statusId], [programLanguageId], [dateRegister], [dateLastContact], [clientType]) VALUES (6, N'Telefono', N'www.saa.com', N'SAA POST System', N'1.2.3', N'Bla bla bla bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', N'Go', 0, 34, 18, 1, 1, CAST(N'2021-01-07T21:40:48.000' AS DateTime), CAST(N'2021-01-07T21:40:48.000' AS DateTime), 2)
INSERT [dbo].[Sisg_CasesSoftwareHouses] ([id], [contactShape], [page], [systemAdmin], [versionSystemAdmin], [descriptionCase], [otherLanguage], [employeeId], [developersClientsId], [systemOperId], [statusId], [programLanguageId], [dateRegister], [dateLastContact], [clientType]) VALUES (8, N'Correo_Eletronico', N'www.decati.com', N'DECATI POS', N'8.2.2', N'Blablablla blabla', N'C++', 0, 36, 2, 1, 4, CAST(N'2021-01-07T21:58:57.000' AS DateTime), CAST(N'2021-01-07T21:58:57.000' AS DateTime), 2)
INSERT [dbo].[Sisg_CasesSoftwareHouses] ([id], [contactShape], [page], [systemAdmin], [versionSystemAdmin], [descriptionCase], [otherLanguage], [employeeId], [developersClientsId], [systemOperId], [statusId], [programLanguageId], [dateRegister], [dateLastContact], [clientType]) VALUES (9, N'Correo_Eletronico', N'www.isaa.com', N'ISAT POS', N'3.4.5', N'Necesito integra con un SDK de .NET con el lenguaje C para una Impresora Térmica', N'VB', 0, 37, 8, 1, 78, CAST(N'2021-01-12T16:53:45.000' AS DateTime), CAST(N'2021-01-12T16:53:45.000' AS DateTime), 1)
INSERT [dbo].[Sisg_CasesSoftwareHouses] ([id], [contactShape], [page], [systemAdmin], [versionSystemAdmin], [descriptionCase], [otherLanguage], [employeeId], [developersClientsId], [systemOperId], [statusId], [programLanguageId], [dateRegister], [dateLastContact], [clientType]) VALUES (11, N'Telefono', N'www.softehc.com', N'Profit PLUSS', N'3.4.5', N'Blabla bla bla bl a SKA bla nbla', N'C++', 0, 39, 20, 1, 155, CAST(N'2021-01-14T01:50:44.000' AS DateTime), CAST(N'2021-01-14T01:50:44.000' AS DateTime), 1)
INSERT [dbo].[Sisg_CasesSoftwareHouses] ([id], [contactShape], [page], [systemAdmin], [versionSystemAdmin], [descriptionCase], [otherLanguage], [employeeId], [developersClientsId], [systemOperId], [statusId], [programLanguageId], [dateRegister], [dateLastContact], [clientType]) VALUES (12, N'Correo_Eletronico', N'www.a2sof.com', N'A2 Softway', N'5.4.9', N'Bla blaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa vvvvvvvvv', N'F#', 0, 40, 2, 1, 4, CAST(N'2021-01-15T21:40:11.000' AS DateTime), CAST(N'2021-01-15T21:40:11.000' AS DateTime), 3)
INSERT [dbo].[Sisg_CasesSoftwareHouses] ([id], [contactShape], [page], [systemAdmin], [versionSystemAdmin], [descriptionCase], [otherLanguage], [employeeId], [developersClientsId], [systemOperId], [statusId], [programLanguageId], [dateRegister], [dateLastContact], [clientType]) VALUES (13, N'Telefono', N'www.enter23.com', N'Galac Pluss', N'1.2.3', N'Blablablablabla', N'C++', 0, 41, 2, 1, 18, CAST(N'2021-01-20T21:34:07.000' AS DateTime), CAST(N'2021-01-20T21:34:07.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Sisg_CasesSoftwareHouses] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Categories] ON 

INSERT [dbo].[Sisg_Categories] ([id], [name], [description], [creation_date]) VALUES (1, N'Impresoras Fiscales', N'Dispositivo que permite registrar y controlar la información que se imprime en un comprobante fiscal (factura)', CAST(N'2019-10-16T16:41:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Categories] ([id], [name], [description], [creation_date]) VALUES (2, N'Impresoras Fiscales para Apuestas', NULL, CAST(N'2019-10-03T09:53:41.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Categories] ([id], [name], [description], [creation_date]) VALUES (3, N'Cajas Registradoras', NULL, CAST(N'2019-10-03T09:53:41.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Categories] ([id], [name], [description], [creation_date]) VALUES (4, N'Perifericos y otros', NULL, CAST(N'2019-10-03T09:53:41.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Categories] ([id], [name], [description], [creation_date]) VALUES (5, N'Balanzas', N'Dispositivo de capacidad', CAST(N'2020-02-19T19:31:10.3087401' AS DateTime2))
INSERT [dbo].[Sisg_Categories] ([id], [name], [description], [creation_date]) VALUES (6, N'Dispositivo de Transmision', NULL, CAST(N'2019-10-03T09:53:41.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Categories] ([id], [name], [description], [creation_date]) VALUES (11, N'Impresoras Estandar', N'Impresor laser para múltiples usos', CAST(N'2020-02-19T20:00:57.9352964' AS DateTime2))
INSERT [dbo].[Sisg_Categories] ([id], [name], [description], [creation_date]) VALUES (12, N'Factura Electrónica', NULL, CAST(N'2019-10-10T14:24:38.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Categories] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Chargues] ON 

INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (1, N'Gerente de Servicios', 2)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (2, N'Coordinador HelpDesk', 3)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (3, N'Gerente de Soporte y Tecnología', 4)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (4, N'Coordinador de Integración', 3)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (5, N'Coordinador de Soporte Fiscal', 3)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (6, N'Especialista de Integración', 5)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (7, N'Analista de Soporte I', 5)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (8, N'Lider de Prooyecto', 3)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (9, N'Gerente Facturación y Cobranza', 7)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (10, N'Analista de Facturación y Cobranza', 6)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (11, N'Jefe de Taller de Equipos', 3)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (12, N'Técnico de Taller de Equipos', 8)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (13, N'Analista HelpDesk', 5)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (14, N'Coordinador de Laboratorio', 3)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (15, N'Analista de Pruebas', 5)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (16, N'Receptor de Equipos', 14)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (17, N'Analista Administativo', 6)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (18, N'Gerente de Ventas', 7)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (19, N'Ejecutivo de Ventas', 6)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (20, N'Gerente General Administrativo', 7)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (21, N'Gerente de Despacho', 7)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (22, N'Operador de Despacho', 12)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (23, N'Gerente Producción', 7)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (24, N'Operador de Producción', 6)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (25, N'Gerente de Operaciones', 7)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (26, N'Asistente de Operaciones', 6)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (27, N'Gerente de Desarrollo Software', 4)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (28, N'Desarrollador de Software', 5)
INSERT [dbo].[Sisg_Chargues] ([id], [description], [rolId]) VALUES (29, N'Presidente', 1)
SET IDENTITY_INSERT [dbo].[Sisg_Chargues] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Countries] ON 

INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (1, N'Afganistán')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (2, N'Islas Gland')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (3, N'Albania')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (4, N'Alemania')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (5, N'Andorra')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (6, N'Angola')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (7, N'Anguilla')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (8, N'AntÃ¡rtida')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (9, N'Antigua y Barbuda')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (10, N'Antillas Holandesas')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (11, N'Arabia SaudÃ­')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (12, N'Argelia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (13, N'Argentina')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (14, N'Armenia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (15, N'Aruba')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (16, N'Australia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (17, N'Austria')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (18, N'AzerbaiyÃ¡n')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (19, N'Bahamas')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (20, N'Bahréin')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (21, N'Bangladesh')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (22, N'Barbados')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (23, N'Bielorrusia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (24, N'BÃ©lgica')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (25, N'Belice')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (26, N'Benin')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (27, N'Bermudas')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (28, N'Bhután')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (29, N'Bolivia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (30, N'Bosnia y Herzegovina')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (31, N'Botsuana')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (32, N'Isla Bouvet')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (33, N'Brasil')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (34, N'Brunéi')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (35, N'Bulgaria')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (36, N'Burkina Faso')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (37, N'Burundi')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (38, N'Cabo Verde')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (39, N'Islas Caimán')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (40, N'Camboya')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (41, N'CamerÃºn')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (42, N'CanadÃ¡')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (43, N'República Centroafricana')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (44, N'Chad')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (45, N'República Checa')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (46, N'Chile')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (47, N'China')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (48, N'Chipre')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (49, N'Isla de Navidad')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (50, N'Ciudad del Vaticano')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (51, N'Islas Cocos')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (52, N'Colombia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (53, N'Comoras')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (54, N'República Democrática del Congo')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (55, N'Congo')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (56, N'Islas Cook')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (57, N'Corea del Norte')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (58, N'Corea del Sur')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (59, N'Costa de Marfil')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (60, N'Costa Rica')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (61, N'Croacia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (62, N'Cuba')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (63, N'Dinamarca')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (64, N'Dominica')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (65, N'República Dominicana')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (66, N'Ecuador')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (67, N'Egipto')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (68, N'El Salvador')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (69, N'Emiratos Ãrabes Unidos')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (70, N'Eritrea')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (71, N'Eslovaquia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (72, N'Eslovenia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (73, N'España')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (74, N'Islas ultramarinas de Estados Unidos')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (75, N'Estados Unidos')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (76, N'Estonia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (77, N'Etiopía')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (78, N'Islas Feroe')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (79, N'Filipinas')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (80, N'Finlandia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (81, N'Fiyi')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (82, N'Francia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (83, N'Gabón')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (84, N'Gambia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (85, N'Georgia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (86, N'Islas Georgias del Sur y Sandwich del Sur')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (87, N'Ghana')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (88, N'Gibraltar')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (89, N'Granada')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (90, N'Grecia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (91, N'Groenlandia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (92, N'Guadalupe')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (93, N'Guam')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (94, N'Guatemala')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (95, N'Guayana Francesa')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (96, N'Guinea')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (97, N'Guinea Ecuatorial')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (98, N'Guinea-Bissau')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (99, N'Guyana')
GO
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (100, N'Haití')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (101, N'Islas Heard y McDonald')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (102, N'Honduras')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (103, N'Hong Kong')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (104, N'Hungría')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (105, N'India')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (106, N'Indonesia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (107, N'Irán')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (108, N'Iraq')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (109, N'Irlanda')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (110, N'Islandia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (111, N'Israel')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (112, N'Italia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (113, N'Jamaica')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (114, N'Japón')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (115, N'Jordania')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (116, N'Kazajstán')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (117, N'Kenia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (118, N'Kirguistán')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (119, N'Kiribati')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (120, N'Kuwait')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (121, N'Laos')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (122, N'Lesotho')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (123, N'Letonia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (124, N'Líbano')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (125, N'Liberia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (126, N'Libia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (127, N'Liechtenstein')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (128, N'Lituania')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (129, N'Luxemburgo')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (130, N'Macao')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (131, N'ARY Macedonia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (132, N'Madagascar')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (133, N'Malasia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (134, N'Malawi')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (135, N'Maldivas')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (136, N'Malí')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (137, N'Malta')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (138, N'Islas Malvinas')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (139, N'Islas Marianas del Norte')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (140, N'Marruecos')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (141, N'Islas Marshall')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (142, N'Martinica')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (143, N'Mauricio')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (144, N'Mauritania')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (145, N'Mayotte')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (146, N'México')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (147, N'Micronesia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (148, N'Moldavia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (149, N'Mónaco')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (150, N'Mongolia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (151, N'Montserrat')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (152, N'Mozambique')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (153, N'Myanmar')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (154, N'Namibia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (155, N'Nauru')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (156, N'Nepal')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (157, N'Nicaragua')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (158, N'Níger')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (159, N'Nigeria')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (160, N'Niue')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (161, N'Isla Norfolk')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (162, N'Noruega')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (163, N'Nueva Caledonia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (164, N'Nueva Zelanda')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (165, N'Omán')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (166, N'Países Bajos')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (167, N'Pakistán')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (168, N'Palau')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (169, N'Palestina')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (170, N'Panamá')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (171, N'Papúa Nueva Guinea')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (172, N'Paraguay')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (173, N'Perú')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (174, N'Islas Pitcairn')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (175, N'Polinesia Francesa')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (176, N'Polonia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (177, N'Portugal')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (178, N'Puerto Rico')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (179, N'Qatar')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (180, N'Reino Unido')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (181, N'Reunión')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (182, N'Ruanda')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (183, N'Rumania')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (184, N'Rusia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (185, N'Sahara Occidental')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (186, N'Islas Salomón')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (187, N'Samoa')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (188, N'Samoa Americana')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (189, N'San Cristóbal y Nevis')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (190, N'San Marino')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (191, N'San Pedro y Miquelón')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (192, N'San Vicente y las Granadinas')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (193, N'Santa Helena')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (194, N'Santa Lucía')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (195, N'Santo Tomé y Príncipe')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (196, N'Senegal')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (197, N'Serbia y Montenegro')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (198, N'Seychelles')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (199, N'Sierra Leona')
GO
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (200, N'Singapur')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (201, N'Siria')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (202, N'Somalia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (203, N'Sri Lanka')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (204, N'Suazilandia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (205, N'SudÃ¡frica')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (206, N'Sudán')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (207, N'Suecia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (208, N'Suiza')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (209, N'Surinam')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (210, N'Svalbard y Jan Mayen')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (211, N'Tailandia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (212, N'Taiwán')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (213, N'Tanzania')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (214, N'Tayikistán')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (215, N'Territorio Británico del Océano Índico')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (216, N'Territorios Australes Franceses')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (217, N'Timor Oriental')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (218, N'Togo')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (219, N'Tokelau')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (220, N'Tonga')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (221, N'Trinidad y Tobago')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (222, N'Túnez')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (223, N'Islas Turcas y Caicos')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (224, N'Turkmenistán')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (225, N'Turquía')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (226, N'Tuvalu')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (227, N'Ucrania')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (228, N'Uganda')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (229, N'Uruguay')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (230, N'UzbekistÃ¡n')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (231, N'Vanuatu')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (232, N'Venezuela')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (233, N'Vietnam')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (234, N'Islas Vírgenes Británicas')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (235, N'Islas Vírgenes de los Estados Unidos')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (236, N'Wallis y Futuna')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (237, N'Yemen')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (238, N'Yibuti')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (239, N'Zambia')
INSERT [dbo].[Sisg_Countries] ([id], [description]) VALUES (240, N'Zimbabue')
SET IDENTITY_INSERT [dbo].[Sisg_Countries] OFF
SET IDENTITY_INSERT [dbo].[Sisg_DeliveryOrder] ON 

INSERT [dbo].[Sisg_DeliveryOrder] ([id], [deliveryMode], [liableId], [liableName], [liablePhone], [guideNumber], [companyName], [address], [observation], [dispatchDate]) VALUES (0, 0, 0, N'No Definido', N'00000000', N'0000', N'NONE', NULL, NULL, CAST(N'2020-09-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_DeliveryOrder] ([id], [deliveryMode], [liableId], [liableName], [liablePhone], [guideNumber], [companyName], [address], [observation], [dispatchDate]) VALUES (1, 1, 12321328, N'Pablo Moya', N'04148491448', NULL, NULL, NULL, NULL, CAST(N'2020-11-20T12:29:46.610' AS DateTime))
INSERT [dbo].[Sisg_DeliveryOrder] ([id], [deliveryMode], [liableId], [liableName], [liablePhone], [guideNumber], [companyName], [address], [observation], [dispatchDate]) VALUES (2, 1, 1232132, N'Pablo Moya', N'04148491448', NULL, NULL, NULL, NULL, CAST(N'2020-11-24T15:03:06.713' AS DateTime))
INSERT [dbo].[Sisg_DeliveryOrder] ([id], [deliveryMode], [liableId], [liableName], [liablePhone], [guideNumber], [companyName], [address], [observation], [dispatchDate]) VALUES (3, 1, 3442463, N'Maria Velota', N'04148491448', NULL, NULL, NULL, NULL, CAST(N'2020-11-26T13:36:36.833' AS DateTime))
INSERT [dbo].[Sisg_DeliveryOrder] ([id], [deliveryMode], [liableId], [liableName], [liablePhone], [guideNumber], [companyName], [address], [observation], [dispatchDate]) VALUES (4, 1, 12321328, N'Pablo Moya', N'04148491448', NULL, NULL, NULL, NULL, CAST(N'2020-11-30T15:57:53.993' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_DeliveryOrder] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Departaments] ON 

INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (1, N'Soporte')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (2, N'Laboratorio')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (3, N'Taller de Equipos')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (4, N'HelpDesk')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (5, N'Facturación y Cobranza')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (6, N'Ventas')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (7, N'Integración')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (8, N'Almacen')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (9, N'Producción')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (10, N'Operaciones')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (11, N'Servicio al Cliente')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (12, N'Desarrollo e Insvestigación')
INSERT [dbo].[Sisg_Departaments] ([id], [description]) VALUES (13, N'Presidencia')
SET IDENTITY_INSERT [dbo].[Sisg_Departaments] OFF
SET IDENTITY_INSERT [dbo].[Sisg_DevelopersClients] ON 

INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (1, N'J308056014', N'SOLUCIONES EN INFORMATICA C.A.', N'AV. LIBERTADOR ENTRE CALLES 17 Y 18, NRO S/N, A MEDIA CUADRA DEL CC BABILON', N'Venezuela', N'Lara', N'Barquisimeto', N'0251-2374212', N'seinca.opera.arodriguez@hotmail.com', 1, CAST(N'2019-06-26T15:31:22.000' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (2, N'J309056016', N'SISMEXICO C.A.', N'AV. MEXICO ENTRE CALLES 17 Y 18, NRO S/N', N'Venezuela', N'Carabobo', N'Valencia', N'0256-2374212', N'sismex@gmail.com', 1, CAST(N'2019-07-16T15:24:34.000' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (3, N'52894646464', N'TEST Sistem S.A', N'CL 323 Nro 45', N'Cundinamarca', N'Cundinamarca', N'Bogota', N'3228491444', N'dev54@tfhka.com', 1, CAST(N'2019-12-27T19:17:46.920' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (4, N'D456241636', N'Consulting HG', N'CL 21 con 56722', N'Ecuador', N'Guayas', N'Guayaquil', N'+59 3228491444', N'carloy77@tfhka.com', 1, CAST(N'2020-01-02T19:13:56.807' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (6, N'845754545', N'Soluciones 2020 POS', N'Cl 85-#24-96', N'Colombia', N'Tolima', N'Ibagué', N'+57 322 8491444', N'sol76@tfhka.com', 1, CAST(N'2020-01-22T16:43:54.513' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (7, N'12639930', N'Bits Americas SAS', N'Cua', N'Venezuela', N'Miranda', N'Cua', N'04242701914', N'andrescamperos@gmail.com', 1, CAST(N'2020-01-22T17:07:23.147' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (11, N'E784545444', N'Soft Tech S.A', N'Calle luna Calle Sol', N'Costa Rica', N'Colone', N'Colón', N'2123123121', N'sthec_23@tfhka.com', 1, CAST(N'2020-01-22T21:26:06.343' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (22, N'v16357835', N'Jennifer Bordones', N'Coche - Caracas', N'Venezuela', N'Dtto - Capital', N'Caracas', N'04163332258', N'jenniferbordones2@gmail.com', 1, CAST(N'2020-01-23T14:31:58.960' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (23, N'11210132321', N'Starts Sotf S.A', N'Cl 443 # 2100', N'Italia', N'Providencia', N'Milanni', N'000215454574', N'str43@tfhka.com', 1, CAST(N'2020-01-24T15:23:08.843' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (24, N'234231111222', N'DECA Tecnologies L.T.A', N'Av Pereira con Cali', N'Colombia', N'Valle del Cauca', N'Cali', N'322 4658774', N'decatech@tfhka.com', 1, CAST(N'2020-01-24T16:39:40.273' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (27, N'J-4444444444', N'Desarrollos de Prueba ERP ', N'Av. Principal Los Ruices, Edificio Mohedano, piso 5 ofic 5-c ', N'Venezuela', N'Dto Capital', N'Caracas', N'0212-5786745', N'desaprueba@gmail.com', 1, CAST(N'2020-01-27T15:37:36.330' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (28, N'12329172', N'María Gabriela', N'Kr11', N'Colombia', N'Bogotá', N'Bogotá', N'11111111', N'gagjsk@gmail.com', 1, CAST(N'2020-02-03T21:20:17.293' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (29, N'J000171111', N'DECA POS', N'Calle luna calle sol', N'Venezuela', N'Vargas', N'Caraballeda', N'3216879089', N'pablin@tfhka.com', 1, CAST(N'2020-12-23T17:13:40.690' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (32, N'J000171112', N'HERNAN POS', N'Calle luna calle sol', N'Venezuela', N'Vargas', N'Caraballeda', N'3216879089', N'gviloria@bitsamericas.com', 1, CAST(N'2020-12-28T14:48:49.537' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (33, N'V234555432', N'Pepito Méndez', N'Callejon Gutierrez 34', N'Venezuela', N'Miranda', N'Caracas', N'04128491432', N'pepita43@tfhka.com', 1, CAST(N'2021-01-07T14:20:58.220' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (34, N'J222171111', N'Micro SAA C.A', N'Calle luna calle sol', N'Venezuela', N'Vargas', N'Caraballeda', N'3216879084', N'saa23@tfhka.com', 1, CAST(N'2021-01-07T15:40:53.167' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (36, N'J555171112', N'DETIME SAS', N'Calle luna calle sol', N'Venezuela', N'Vargas', N'Caraballeda', N'3216879089', N'pablin23@tfhka.com', 1, CAST(N'2021-01-07T15:58:57.427' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (37, N'V188880677', N'ISAT 2010 SAS', N'Callejon Gutierrez', N'Venezuela', N'Miranda', N'Caracas', N'04148491447', N'isac_23@tfhka.com', 1, CAST(N'2021-01-12T10:53:52.063' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (39, N'J321987130', N'Profit Gentes', N'Callejon Gutierrez', N'Venezuela', N'Miranda', N'Caracas', N'04148491444', N'ppaol76@tfhka.com', 1, CAST(N'2021-01-13T19:50:44.520' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (40, N'J777009499', N'A2 Consultores S.A.S', N'Callejon Gutierrez 56', N'Venezuela', N'Lara', N'Barquisimeto', N'04148491476', N'a2consulting@tfhka.com', 1, CAST(N'2021-01-15T15:40:20.197' AS DateTime))
INSERT [dbo].[Sisg_DevelopersClients] ([id], [document], [description], [address], [country], [state], [city], [phone], [email], [enable], [creation_date]) VALUES (41, N'J155171112', N'Enterprice C.A', N'Calle luna calle sol', N'Venezuela', N'Vargas', N'Caraballeda', N'3216879044', N'enter54@tfhka.com', 1, CAST(N'2021-01-20T15:34:11.923' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_DevelopersClients] OFF
SET IDENTITY_INSERT [dbo].[Sisg_DevelopersClientsUsers] ON 

INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (1, 3, 56)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (2, 4, 58)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (3, 6, 63)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (4, 7, 64)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (5, 11, 68)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (7, 22, 79)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (8, 23, 80)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (9, 24, 81)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (10, 27, 82)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (11, 28, 83)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (13, 32, 89)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (14, 33, 90)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (15, 34, 91)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (17, 36, 93)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (18, 37, 94)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (20, 39, 96)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (21, 40, 97)
INSERT [dbo].[Sisg_DevelopersClientsUsers] ([id], [developersclientsId], [userId]) VALUES (22, 41, 98)
SET IDENTITY_INSERT [dbo].[Sisg_DevelopersClientsUsers] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Distributors] ON 

INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (1, 234, N'J293904862', N'Sistemas CRB, C.A.', N'Osorio', N'Ciudad Barina, Estado Barina', N'Venezuela', N'Barina', N'Barina', N'58 04241114943', N'edominguez@bitsamericas.com', N'J293904862', N'4002', N'Maria Meji', N'J301920255', N'58 2613541160', N'Transporte Express 21', 1, CAST(N'2019-06-10T11:09:20.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (2, 110008, N'J293781434', N'Sistemas de Informatica Pos 232, C.A.', N'Ana Gimenez', N'Av. Libertador Cruce con Bogota Edif. Los Lanceros piso', N'VENEZUELA', N'Dtto Fed./Miranda', N'Caracas', N'0426 9134792', N'pmmoyapablo2@gmail.com', N'', N'', N'CAROL HERNANDEZ', N'23', N'', N'', 1, CAST(N'2019-06-17T15:45:41.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (3, 110144, N'J293855802', N'Sofnet Plus Computer, C.A.', N'Eugenio Vilera Herrera', N'Calle Deleite Nro.25 Entre Av. Romulo Gallegos y Calle', N'VENEZUELA', N'Guarico', N'Valle La Pascua', N'0235 3422746/0416-239-4020', N'gnoguera@bitsamericas.com', N'', N'', N'Vielka Ortega', N'03', N'', N'', 1, CAST(N'2019-06-17T16:15:15.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (4, 110078, N'J293987130', N'Impresoras 421 Fiscales, C.A.', N'Domingo Pereira/Carolina Lozano', N'CR 2 entre calles 2A y 3 casa nro. 2A-13', N'VENEZUELA', N'Lara', N'', N'0251-714.47.24/0414-9954583', N'japonte@bitsamericas.com', N'', N'', N'CAROL HERNANDEZ', N'23', N'', N'', 1, CAST(N'2019-06-18T11:05:25.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (5, 110380, N'J555222001', N'Factory Inter C.A', N'Hugo Tovar', N'Calle Callejón Gutierrez Edf. Riva Piso P.B Ofic. 2-1', N'VENEZUELA', N'Dtto Fed./Miranda', N'Caracas', N'0212-237-5132/237-5010', N'mmarcano@bitsamericas.com', N'', N'', N'Oficina', N'01', N'', N'', 1, CAST(N'2019-06-18T13:34:54.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (6, 110024, N'J312283270', N'Tecni Universo, C.A.', N'Rafael Urbina/', N'Carrera 11 con calle 14 Edf. Estela PB. Local 2', N'VENEZUELA', N'Monagas', N'Maturin', N'0291 6424672    3153424', N'pmmoyapablo1@hotmail.com', N'', N'', N'CAROL HERNANDEZ', N'23', N'', N'', 1, CAST(N'2019-06-18T15:50:04.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (7, 110133, N'J314743058', N'Soporte informatico, C.A.', N'MARCO CARRERO', N'CALLE 11 ENTRE CARRERAS 19 Y 20 EDIF. Nro.19-64, PISO', N'VENEZUELA', N'Tachira', N'San Cristobal', N'0276 356.83.13/355.10.72', N'rgudino@bitsamericas.com', N'', N'', N'ALIX II', N'22', N'', N'', 1, CAST(N'2019-06-25T09:26:19.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (8, 110007, N'J090218548', N'ROGELIO FERNANDEZ, C.A.', N'Rogelio Fernandez', N'7ta. Av. Nº10-88 Edf. San Miguel', N'VENEZUELA', N'Tachira', N'San Cristobal', N'0276-3436971 /3420782', N'rgudino@bitsamericas.com', N'0008032602', N'', N'Maria Mejia', N'02', N'', N'123456', 1, CAST(N'2019-07-01T15:40:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (9, 22000, N'J312171197', N'Bits Americas SAS Distribuidor II', N'Oficina Admin', N'Av Fco. Miranda Callejon Gutierrez', N'Venezuela', N'Miranda', N'Caracas', N'212 2564742', N'pmoya@bitsamericas.com', N'0000001', N'123', N'Oficina', N'000', N'00000', N'NA', 1, CAST(N'2019-06-26T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (10, 16038, N'J295248520', N'LIGHT SYSTEM, C.A', N'LUEZNAY CONTRERAS', N'AV 4 EDIF LA SUIZA PISO P/B LOCAL P/B SECTOR BELLA', N'VENEZUELA', N'Zulia', N'Maracaibo', N'0261-7418870 / 0261-7439181', N'pmmoyapablo1@gmail.com', N'', N'', N'Maria Mejia', N'02', N'', N'', 1, CAST(N'2019-06-26T17:48:43.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (11, 110030, N'J307906863', N'Tecnologias A.V.M., S.A.', N'Ernesto Moreno', N'Av. Sucre Cruce Con Urdaneta, Qta. Morichalito, San Fernando', N'VENEZUELA', N'Apure', N'', N'0416 547 9030', N'rgudino@bitsamericas.com', N'', N'', N'CAROL HERNANDEZ', N'23', N'', N'', 1, CAST(N'2019-06-27T09:51:15.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (12, 110009, N'J308726273', N'Distribuidora Tecnologia y Oficina, C.A.', N'Constantino', N'Carrera 17 Nº26 Frente Al Mercado Nuevo', N'VENEZUELA', N'Monagas', N'San Felix De Monagas', N'0291-6414766', N'enmanuelboscan10@gmail.com', N'0223708803', N'', N'Maria Mejia', N'02', N'', N'', 1, CAST(N'2019-06-27T10:23:25.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (13, 110307, N'J300156648', N'Mecanografica CP, C.A', N'Barrios de Perez Nelia', N'Calle INDEPENDENCIA no. 104-21-21 Sector Centro', N'VENEZUELA', N'Aragua', N'Cagua', N'0244-4479591/(414)598-0031', N'rgudino8@rgudino8@bitsamericas.com', N'', N'', N'Natali II', N'21', N'', N'', 1, CAST(N'2019-06-27T11:36:21.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (14, 15631, N'J400529980', N'Ofiservicios Cagua, C.A', N'KARLA PEREZ', N'Calle Comercio Entre Sabana Larga y Hugo Olivero Local', N'VENEZUELA', N'Aragua', N'La Victoria', N'0244-3961418/ 0414-4606418', N'rgudino@bitsamericas.com', N'', N'', N'Vielka Ortega', N'03', N'', N'', 1, CAST(N'2019-06-27T12:20:33.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (15, 110240, N'J295614179', N'Solintech, C.A', N'Ricardo Caterino', N'Av. Country Club. CC Caribbean Country Nivel 1 Local B-10', N'VENEZUELA', N'Anzoategui', N'Barcelona', N'0281-2750951/0424-8742700', N'rgudino@bitsamericas.com', N'', N'', N'CAROL HERNANDEZ', N'23', N'', N'', 1, CAST(N'2019-06-27T17:45:42.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (16, 110083, N'J295370300', N'FJ Soluciones Tecnologicas, C.A', N'Roni', N'CALLE MIRANDA CON CALLE BALDOMERO DELGADO', N'VENEZUELA', N'Nueva Esparta', N'Porlamar', N'0295-2634138/4175384', N'rgudino@bitsamericas.com', N'', N'', N'CAROL HERNANDEZ', N'23', N'', N'', 1, CAST(N'2019-06-28T08:36:32.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (17, 110110, N'J317093631', N'JP Seguridad y Sistemas, C.A.', N'Javier Pulgar', N'Av.Montes de Oca CC Caribbean PLaza Modulo 3 Nivel 1', N'VENEZUELA', N'Carabobo', N'Valencia', N'0241-8247944 / 8263656', N'rgudino@bitsamericas.com', N'', N'', N'CAROL HERNANDEZ', N'23', N'', N'', 1, CAST(N'2019-06-28T14:34:47.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (18, 110490, N'J302119162', N'SAL-GAR International traiding, C.A.', N'IRMA GARCIA SALGADO', N'AV Libertador Edf EXA Piso PH Of 5 El Rosal', N'VENEZUELA', N'Dtto Fed./Miranda', N'Caracas', N'952-4084/952-2618', N'rvalderrama2@bitsamericas.com', N'', N'', N'Vielka Ortega', N'03', N'', N'', 1, CAST(N'2019-07-02T15:01:23.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (19, 110027, N'J306295895', N'TECNICA DE SERVICIOS YUT, C.A.', N'JAIME BOUTUREIRA', N'Avda Ppal de Mariperez. Qta La Milagrosa a 50 mts de', N'VENEZUELA', N'Dtto Fed./Miranda', N'Caracas', N'0212-7823266/ 793-0778', N'pmmoyapablo@gmail.com', N'', N'', N'CAROL HERNANDEZ', N'23', N'', N'', 1, CAST(N'2019-07-04T14:17:14.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (20, 6068, N'J402576463', N'IRS TECNOLOGY, C.A', N'JESUS MORA', N'CR 3 ENTRE CALLES 17 Y 18 CASA S/N SECTOR PUEBLO', N'Venezuela', N'Barinas', N'Santa Barbara', N'0278-222-1064 /0424-706-8476', N'client06068@tfhka.com', N'', N'', N'Oficina Venta TFHKA', N'22', N'0212-2020811', N'', 1, CAST(N'2019-12-27T20:03:41.2243319' AS DateTime2))
INSERT [dbo].[Sisg_Distributors] ([id], [idSA], [rif], [description], [represent], [address], [country], [state], [city], [phone], [email], [nit], [codeZone], [nameSeller], [rifSeller], [phoneSeller], [typeAgreement], [enable], [creation_date]) VALUES (21, 15584, N'J310061297', N'WHITE HAT, C.A.', N'Santiago J. Merlos', N'CALLE CALLE 1 CASA D-06 URB CLUB HIPICO LAS TRINITARIAS', N'Venezuela', N'Lara', N'Cabure', N'0251- 4350883 / 4351838', N'client15584@tfhka.com', N'', N'', N'Oficina Venta TFHKA', N'22', N'0212-2020811', N'', 1, CAST(N'2020-02-19T20:44:30.6116991' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Distributors] OFF
SET IDENTITY_INSERT [dbo].[Sisg_DistributorsProviders] ON 

INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (6, 2, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (7, 3, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (9, 4, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (12, 7, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (11, 8, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (2, 12, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (3, 13, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (4, 15, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (5, 16, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (13, 17, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (16, 18, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (15, 19, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (17, 20, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (18, 21, 1)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (1, 1, 2)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (8, 4, 2)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (10, 5, 2)
INSERT [dbo].[Sisg_DistributorsProviders] ([id], [DistributorsId], [ProviderId]) VALUES (14, 15, 2)
SET IDENTITY_INSERT [dbo].[Sisg_DistributorsProviders] OFF
SET IDENTITY_INSERT [dbo].[Sisg_DistributorsUsers] ON 

INSERT [dbo].[Sisg_DistributorsUsers] ([id], [DistributorsId], [UserId]) VALUES (1, 1, 4)
INSERT [dbo].[Sisg_DistributorsUsers] ([id], [DistributorsId], [UserId]) VALUES (16, 3, 6)
INSERT [dbo].[Sisg_DistributorsUsers] ([id], [DistributorsId], [UserId]) VALUES (15, 4, 2)
INSERT [dbo].[Sisg_DistributorsUsers] ([id], [DistributorsId], [UserId]) VALUES (17, 7, 13)
INSERT [dbo].[Sisg_DistributorsUsers] ([id], [DistributorsId], [UserId]) VALUES (2, 12, 24)
INSERT [dbo].[Sisg_DistributorsUsers] ([id], [DistributorsId], [UserId]) VALUES (3, 13, 9)
INSERT [dbo].[Sisg_DistributorsUsers] ([id], [DistributorsId], [UserId]) VALUES (4, 15, 25)
INSERT [dbo].[Sisg_DistributorsUsers] ([id], [DistributorsId], [UserId]) VALUES (5, 16, 28)
INSERT [dbo].[Sisg_DistributorsUsers] ([id], [DistributorsId], [UserId]) VALUES (14, 19, 31)
INSERT [dbo].[Sisg_DistributorsUsers] ([id], [DistributorsId], [UserId]) VALUES (18, 20, 57)
INSERT [dbo].[Sisg_DistributorsUsers] ([id], [DistributorsId], [UserId]) VALUES (19, 21, 85)
SET IDENTITY_INSERT [dbo].[Sisg_DistributorsUsers] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Employees] ON 

INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (0, 0, N'V00000000', N'0001', N'Indefinido', 13, 29, N'presidente@bitsamericas.com', N'000 0000000', 1, CAST(N'2020-01-02T19:46:47.170' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (1, 0, N'V145264614', N'10001', N'Pablo Moya', 12, 27, N'pmoya@bitsamericas.com', N'+57 322 8491444', 1, CAST(N'2019-08-09T09:57:09.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (2, 1, N'V123456789', N'10051', N'Luis Marchan', 12, 28, N'lmarchan@bitsamericas.com', N'+58 414 7491454', 1, CAST(N'2019-08-09T09:57:20.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (3, 0, N'V124567005', N'10002', N'Raul Moreno', 1, 3, N'rmoreno@bitsamericas.com', N'+58 414 5491477', 1, CAST(N'2019-08-14T17:17:26.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (4, 0, N'V114567009', N'10003', N'Raul Valderrama', 11, 1, N'rvalderrama@bitsamericas.com', N'+58 414 3451478', 1, CAST(N'2019-08-14T17:25:27.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (5, 3, N'V123456987', N'10088', N'Jonner Serrano', 7, 6, N'jserrano@bitsamericas.com', N'+58 414 5691498', 1, CAST(N'2019-08-14T17:19:58.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (6, 5, N'V253456984', N'10098', N'Paloa Aguirre', 7, 6, N'paguirre@bitsamericas.com', N'+58 412 9691468', 1, CAST(N'2019-08-14T17:24:45.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (7, 3, N'V103456933', N'10102', N'Mayra Ramirez', 1, 7, N'mramirez@bitsamericas.com', N'+58 414 7691468', 1, CAST(N'2019-08-14T17:26:03.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (8, 4, N'V133456956', N'10012', N'Nelida Salazar', 4, 2, N'nsalazar@bitsamericas.com', N'+58 414 7191434', 1, CAST(N'2019-08-15T09:21:00.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (9, 8, N'V233456959', N'10212', N'Zoraliz Bolivar', 4, 13, N'zbolivar@bitsamericas.com', N'+58 412 7191438', 1, CAST(N'2019-08-15T09:25:27.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (10, 4, N'V133456950', N'10013', N'Isleye Martinez', 3, 11, N'ycmartinez@bitsamericas.com', N'+58 412 9991438', 1, CAST(N'2019-08-15T09:31:35.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (11, 10, N'V233456950', N'10313', N'Jesus Leal', 3, 12, N'jlealz@bitsamericas.com', N'+58 416 2991438', 1, CAST(N'2019-08-15T09:34:37.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (12, 0, N'V133457750', N'10113', N'Douglas Montilla', 8, 21, N'dmontilla@bitsamericas.com', N'+58 412 3991438', 1, CAST(N'2019-08-15T09:37:41.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (14, 10, N'V283457752', N'10317', N'Yordano Gil', 3, 16, N'ygil@bitsamericas.com', N'+58 412 5991439', 1, CAST(N'2019-08-15T09:45:56.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (15, 0, N'V183457752', N'10127', N'Jackeline Centeno', 5, 9, N'jcenteno@bitsamericas.com', N'+58 414 5991436', 1, CAST(N'2019-08-15T09:49:33.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (16, 15, N'V173457752', N'10129', N'Pedro Fanay', 5, 10, N'pfanay@bitsamericas.com', N'+58 414 1991436', 1, CAST(N'2019-08-15T09:55:07.000' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (17, 0, N'V055343088', N'54210', N'Vielka Ortega', 6, 18, N'vortega2@bitsamericas.com', N'+58 414 7691441', 1, CAST(N'2020-01-02T19:30:24.527' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (18, 17, N'V155343077', N'3054', N'Carol Hernandez', 6, 19, N'chernandez123@bitsamericas.com', N'+58 414 4491448', 1, CAST(N'2020-01-02T19:37:39.557' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (19, 12, N'V230012101', N'2003', N'Evelyn Daza', 8, 22, N'edaza@bitsamericas.com', N'+58 412 8491449', 1, CAST(N'2020-01-02T19:42:20.913' AS DateTime))
INSERT [dbo].[Sisg_Employees] ([id], [supervitorId], [rif], [code], [description], [departamentId], [chargueId], [email], [phone], [enable], [creation_date]) VALUES (20, 8, N'V255343079', N'11107', N'Kevin Tejada', 4, 13, N'ktejada234@bitsamericas.com', N'412 8491455', 1, CAST(N'2020-01-02T19:46:47.170' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_Employees] OFF
SET IDENTITY_INSERT [dbo].[Sisg_EmployeesUsers] ON 

INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (1, 1, 1)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (5, 2, 47)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (6, 3, 46)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (2, 4, 5)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (7, 5, 45)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (8, 6, 44)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (9, 7, 43)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (4, 8, 19)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (10, 9, 48)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (11, 10, 49)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (12, 11, 50)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (13, 12, 51)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (15, 14, 53)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (16, 15, 54)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (17, 16, 55)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (18, 17, 59)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (19, 18, 60)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (20, 19, 61)
INSERT [dbo].[Sisg_EmployeesUsers] ([id], [employeeId], [userId]) VALUES (21, 20, 62)
SET IDENTITY_INSERT [dbo].[Sisg_EmployeesUsers] OFF
SET IDENTITY_INSERT [dbo].[Sisg_FinalsClients] ON 

INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (1, N'J309568590', N'Cosmeticos Lolita C.A', N'Erika', N'Dominguez', N'0251-2374212', N'seinca.opera.arodriguez@hotmail.com', N'Calle Miranda, esquina 8. Los Castores. San Antonio los Altos. Edo. Miranda', 1, CAST(N'2019-07-30T13:19:40.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (2, N'V123456789', N'Contribuyente Ejemplo S.A', N'Pepito', N'Bolsa Amarilla', N'23528454500', N'clientp23@tfhka.com', N'AV Barath con punto 9', 1, CAST(N'2019-07-31T17:00:01.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (3, N'J000999888', N'Calzados Pelua C.A', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2019-07-31T17:01:01.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (4, N'J333999848', N'La Taguarita del Este', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2019-07-31T17:01:24.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (6, N'J314956701', N'COMERCIAL MARLON,C.A. ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2019-08-06T16:50:05.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (7, N'E821911691', N'MERCEDES J. PALMA M. DE ALAVA', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2019-08-06T16:51:41.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (8, N'J294966802', N'FUNDACION SANITAS VENEZUELA ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2019-12-27T19:21:18.840' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (10, N'J075324374', N'LANTA DE VENEZUELA C.A. ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2019-12-31T17:52:48.877' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (11, N'J411405680', N'ALDANA INM, C.A ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2019-12-31T17:54:31.077' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (12, N'J301420608', N'EXCELSIOR GAMA SUPERMERCADOS, C.A. ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-01-02T14:08:18.387' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (13, N'J070007508', N'FARMACIAS UNIDAS, S.A. ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-01-03T15:34:35.320' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (14, N'G200116609', N'COMPLEJO EDITORIAL BATALLA DE CARABOBO, S.A ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-01-07T22:16:30.177' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (15, N'V138880636', N'SKARLET MARINA ALVARADO CEDILLO', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-01-13T21:51:48.303' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (18, N'J102293179', N'SALCHICHAS Oscar Mayers', NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2020-01-17T21:16:16.807' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (19, N'J000062757', N'CENTRAL MADEIRENSE, C.A ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-01-18T15:49:31.883' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (20, N'J407259644', N'UNICOMP IT SOLUTIONS, C.A. ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-01-18T18:13:15.433' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (21, N'J306842675', N'MERCADOLIBRE VENEZUELA S.R.L. ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-01-27T21:39:49.560' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (22, N'J001842977', N'Coca Cola LTD', NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2020-02-04T14:28:21.433' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (24, N'J294105807', N'OPTICLAR C.A. ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-02-19T22:13:39.137' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (27, N'V145264614', N'PABLO EUGENIO MOYA PINANGO ', NULL, NULL, NULL, NULL, N' AV NO INDICA EDIF 2 BLOQUE 16 PISO 2 APT 0207 URB RUIZ PINEDA, SECTOR UD7 CARACAS DISTRITO CAPITAL ZONA POSTAL 1100  18/03/2019', 1, CAST(N'2020-02-24T21:08:34.977' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (29, N'V163578359', N'JENNIFER JOSEFINA BORDONES CARRY ', NULL, NULL, NULL, NULL, N' CALLE GUZMAN BLANCO QTA 35 URB CARLOS DELGADO CHALBAUD CARACAS DISTRITO CAPITAL ZONA POSTAL 1090  16/08/2022', 1, CAST(N'2020-02-24T21:12:53.763' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (31, N'V030110508', N'EZEQUIELA ELVIGIA PINANGO DE MOYA ', N'EZEQUIELA', NULL, N'+58 212 3725216', N'pmmoyapablo@hotmail.com', NULL, 1, CAST(N'2020-02-25T20:17:54.987' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (36, N'V205405662', N'GLORIA ELENA NOGUERA ASUAJE ', NULL, NULL, NULL, NULL, N' AV LECUNA EDIF TORRION PISO 1 APT 4 URB EL CONDE CARACAS DISTRITO CAPITAL ZONA POSTAL 1010  09/07/2021', 1, CAST(N'2020-02-26T14:48:03.867' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (37, N'J413145766', N'ILUMI LIFE C.A ', NULL, NULL, NULL, NULL, N' CALLE LOPEZ AVELEDO C/C CUARTA TRANSVERSAL QTA JAMBAL NRO 1 URB CALICANTO MARACAY ARAGUA ZONA POSTAL 2102  24/10/2022', 1, CAST(N'2020-02-26T14:50:04.113' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (38, N'J401604196', N'PROSEIN ACARIGUA C.A ', NULL, NULL, NULL, NULL, N' AV CIRCUNVALACION 1 SUR, ENTRE CALLES 3 Y 4 LOCAL PROSEIN NRO S/N BARRIO SAN ANTONIO ACARIGUA PORTUGUESA ZONA  30/07/2022', 1, CAST(N'2020-02-26T14:51:26.023' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (41, N'J403306257', N'GADEL ADVENTURE C.A ', NULL, NULL, NULL, NULL, N' AV LOS AVIADORES CC LOS AVIADORES NIVEL B LOCAL L-250 v u ACION SECTOR PALO NEGRO PALO NEGRO ARAGUA ZONA POSTAL 2117  05/11/2022', 1, CAST(N'2020-02-26T16:20:57.757' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (42, N'V126399304', N'ANDRES ELOY CAMPEROS TORREALBA ', NULL, NULL, NULL, NULL, N' AV PERIMETRAL DE CUA, ANTERIORMENTE LLAMADA AV LOS PROCERES, CARRETERA CUA-OCUMARE DEL TUY EDIF A-6 PISO 4 APT A-6 P42  04/04/2022', 1, CAST(N'2020-02-26T16:21:44.360' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (43, N'J313882216', N'ARV ALIMENTOS, C.A. ', NULL, NULL, NULL, NULL, N' AV PRICA CC CIUDAD TRAKI NIVEL PB LOCAL F-13 SECTOR CONEJEROS PORLAMAR NUEVA ESPARTA ZONA POSTAL 6301  18/06/2022', 1, CAST(N'2020-02-26T19:17:26.770' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (44, N'J308222852', N'ACCEL EXPRESS C A (ACCEL EXPRESS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (45, N'J296022062', N'CASCANUECES C.A. (CASCANUECES C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (46, N'J311622454', N'OPTICA MIS OJOS CA (ÓPTICA MIS OJOS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (47, N'J306545603', N'CONSULTORIO OPTOMETRICO OFTALMOLOGICO BEHRENS, C.A. (CONSULTORIO OPTOMETRICO OFTALMOLÓGICO BEHRENS, ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (48, N'J307812486', N'ALMA CERAMICA, C.A. (ALMA CERAMICA, C.A.     )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (49, N'J293717957', N'VARIEDADES SALOMON,C.A (VARIEDADES SALOMON, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (50, N'J301111419', N'EL BODEGON DE WILLIAM C.A (ELBODEGON DE WILLIAM COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (51, N'J316936236', N'MISTER SHAWARMA,C.A. (MISTER SHAWARMA,C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (52, N'V158395777', N'GIOVANNI OROZCO DE QUINTERO ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (53, N'J070418800', N'ELECTRONICA SUEM C.A (ELECTRONICA SUEM, COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (54, N'J297523537', N'INVERSIONES MULTIPLES HC, SOCIEDAD ANONIMA (INVERSIONES MULTIPLES HC, SOCIEDAD ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (55, N'J296934304', N'INVERSIONES DIGNA RIQUETH SPA,C.A. (INVERSIONES DIGNA RIQUETH SPA,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (56, N'J311178988', N'TASCA RESTAURANT LA GRAN VICTORIA, C.A. (TASCA RESTAURANT A GRAN VICTORIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (57, N'J297872701', N'DISTRIBUIDORA Y COMERCIALIZADORA MARACAIBO C.A. (DISTRIBUIDORA Y COMERCIALIZADORA MARACAIBO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (58, N'V128478694', N'JAIRO ALEXANDER HEVIA URBINA', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (59, N'V130983681', N'MARIA ENRIQUETA LEON PEREZ  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (60, N'J312443499', N'CONFECCIONES AG, C.A. (DF)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (61, N'J312492449', N'ESPACIO CORPORAL, C.A.   ASOCIADOS (KJJ)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (62, N'J306685758', N'SUPER CONFITERIA NUEVA POPULAR,C.A. (SUPER CONFITERIA LA NUEVA POPULAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (63, N'J297615768', N'AUTOMERCADO LU, C.A. (AUTOMERCADO LU,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (64, N'J308609528', N'COMERCIAL FENG C A (COMERCIAL FENG, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (65, N'J297679618', N'FERREAUTOS MIKI C.A (FERREAUTOS MIKI C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (66, N'J303485596', N'COMERCIAL LOS TACHINES CA (COMERCIAL LOS TACHINES C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (67, N'J297915524', N'PIÑATERIA Y CONFITERIA LA FIESTA C.A (PIÑATERIA Y CONFITERIA LA FIESTA C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (68, N'J296320110', N'AUTOREPUESTOS PLAZARAURE C.A. (AUTOREPUESTOS PLAZARAURE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (69, N'J316181413', N'BELLA DAMA BOUTIQUE CA (BELLA DAMA BOUTIQUE C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (70, N'J316647340', N'ATUENDOS, C.A. (ATUENDOS, C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (71, N'J311058214', N'AFLORA FLOWER MARKET C.A. (AFLORA FLOWER MARKET,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (72, N'J294241727', N'ALE BIJOUX, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (73, N'J003265683', N'AMATO CAÑIZALEZ PRODUCCIONES 35 C.A. (AMATO CAÑIZALEZ PRODUCCIONES 35 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (74, N'J312763434', N'OKEY FOTOS 21 C.A. (X)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (75, N'J308525294', N'EVENTOS LOS ROTA C.A (EVENTOS LOS ROTA, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (76, N'J295515103', N'FERREPUNTO  2008 C.A. (FERREPUNTO  2008 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (77, N'J001102540', N'COCINAS KAPECAL, C.A (COCINAS KAPECAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (78, N'J002248440', N'INVERSIONES LA CITA SRL (INVERSIONES LA CITA, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (79, N'V076835183', N'ALEX R COHEN C ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (80, N'J311862609', N'DECORACIONES DECO HIPPO 19, C.A. (DECORACIONES DECO HIPPO 19 C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (81, N'V098062641', N'ENRIQUE FERNANDO DE FREITAS RODRIGUEZ    ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (82, N'J085015027', N'CONCRETERA FALCON C.A (CONCRETERA FALCON C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (83, N'J307128461', N'MULTISERVICIOS DON EUSEBIO, C.A. (MULTISERVICIO  DON EUSEBIO C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (84, N'J300640019', N'CAUCHOS LOS OLIVARES C A (CAUCHOS LOS OLIVARES C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (85, N'J300878015', N'MI CAUCHO C A (MI CAUCHO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (86, N'J308647578', N'SUPLID DE MATER Y SERV INDUSTRIALES SUMASI, C.A (SUPLID DE MATER Y SERV INDUSTRIALES SUMASI, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (87, N'J309188127', N'DISTRIBUIDORA RODRIGUEZ Y FREITAS DE PARAGUANA, C.A. (DISTRIBUIDORA RODRIGUEZ Y FREITAS DE PARAGUANA', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (88, N'J095043347', N'DISTRIBUIDORA INDUSTRIAL DEL SUR C A (DISTRIBUIDORA INDUSTRIAL DEL SUR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (89, N'J309481371', N'SERVICIOS DE TRANSPORTE Y MTTO.RUBYS, C.A. (SERVICIOS DE TRANSPORTE Y MANTENIMIENTO RUBYS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (90, N'J296950482', N'"SUPER PAPEL GUAYANA, C.A." (SUPER PAPEL GUAYANA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (91, N'J294929630', N'CAUCHOS LA EXCELENCIA, C.A (CAUCHOS LA EXCELENCIA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (92, N'J295251556', N'AMORTIGUADORES Y REPUESTOS 3.J.CA (AMORTIGUADORES Y REPUESTOS 3.J.CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (93, N'J306011072', N'ABRAS, CA (ABRAS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (94, N'J296020019', N'J.J  AMORTIGUADORES COMPAÑIA ANONIMA. (J.J. AMORTIGUADORES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (95, N'J305715106', N'REPUESTOS Y ACCESORIOS EL VENDEDOR, C.A. (REPUESTOS Y ACCESORIOS EL VENDEDOR,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (96, N'J306052410', N'SUMEQUI CA (SUMEQUI CA  )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (97, N'J306434046', N'COMERCIAL SUMECO CA (COMERCIAL SUMECO C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (98, N'J308597376', N'DISTRIBUIDORA GREBETT, C.A. (DISTRIBUIDORA GREBETT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (99, N'J295360703', N'FARMAEXITO, C.A (FARMAEXITO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (100, N'J312018267', N'IMPORTADORA TELEROBLE MOTOR S C.A (IMPORTADORA TELEROBLE MOTORS C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (101, N'J095024296', N'UNICO MOTOR C A (UNICO MOTOR C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (102, N'J095017184', N'RECTI MOTORES GUAYANA REMOGUACA (REMOGUACA C A     )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (103, N'J304763581', N'MULTISERVICIOS EL PASEO CA (MULTISERVICIOS EL PASEO CA    )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (104, N'J316718255', N'INVERSIONES DAVID CAR,C.A. (INVERSIONES DAVID CAR,C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (105, N'J306131426', N'INVERSIONES RUTA UNO, CA (INVERSIONES RUTA UNO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (106, N'J294362052', N'ZONA INFANTIL,C.A. (ZONA INFANTIL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (107, N'J313759830', N'PINTURAS A.G., C.A. (PINTURAS AG, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (108, N'J304184921', N'INVERSIONES LA FERIA SAN FELIX ,C.A. (LA FERIA DE LA PINTURA C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (109, N'J296286167', N'"INVERSIONES AUSTRAL, C.A." (INVERSIONES AUSTRAL, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (110, N'J294996175', N'REPUESTOS TAXICAR C.A (REPUESTOS TAXICAR C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (111, N'J310207798', N'DRY WALL, C,A (DRY WALL, C.A     )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (112, N'J303225586', N'BIG SHOP, CA (BIG SHOP, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (113, N'J309539957', N'TOYO CENTER, C.A (TOYO CENTER, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (114, N'J293618797', N'EL GLAMOUR DE YENNY C.A ("EL GLAMOUR DE YENNY, C.A.")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
GO
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (115, N'J304712308', N'"TORNILLOS DE  GRADO DI  BERARDINIS, C.A.", (TORNILLOS D G DI BERARDINIS CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (116, N'J306427244', N'FARMACIA SAN PEDRO, C.A (FARMACIA SAN PEDRO C.A  )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (117, N'J305090734', N'REPRESENTACIONES C E A CA (REPRESENTACIONES C E A CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (118, N'J300964299', N'PAPELERIA EL CREYON C A (PAPELERIA EL CREYON C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (119, N'J095161790', N'FERRETERIA SAN JUDAS TADEO C A (FERRETERIA SAN JUDAS TADEO C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (120, N'J301947371', N'STAR SPORT C A (STAR SPORT, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (121, N'J313537152', N'INVERSIONES CABARELA COMPAÑIA ANONIMA (INVERSIONES CABARELA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (122, N'J095116816', N'"ORINOCO INDUSTRIAL S A" (ORINOCO INDUSTRIAL SA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (123, N'J095020789', N'TORNILLERIA DEL SUR SRL (TORNILLERIA DEL SUR SRL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (124, N'J309292633', N'ME CONSULTORIA Y CAPACITACION EMPRESARIAL, C.A (ME CONSULTORIA Y CAPACITACION EMPRESARIAL, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (125, N'J095111750', N'ALTECA, C.A. (ALTECA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (126, N'J312591404', N'INVERSIONES FERREMONCA, C.A (INVERSIONES FERREMONCA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (127, N'J312592818', N'INVERSIONES AFIANSSA, S.A (INVERSIONES AFIANSSA,S.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (128, N'J303793266', N'"CRISIMAR FLORES Y ESTILOS, C.A." (CRISIMAR FLORES Y ESTILOS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (129, N'J315962560', N'INVERSIONES BLUE, C.A. (INVERSIONES BLUE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (130, N'J308176087', N'AUTOPARTES REICAR RACING, C.A. (AUTOPARTES REICAR RACING, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (131, N'J315891514', N'SERVICIOS Y REPUESTOS ENMANUEL, C.A. (SERVICIOS Y REPUESTOS ENMANUEL C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (132, N'J307283637', N'"COMERCIAL LOS CACIQUES, COMPAÑIA ANONIMA" ("COMERCIAL LOS CACIQUES, COMPAÑIA ANONIMA")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (133, N'J303699740', N'CALZADOS MARIANGEL CA (CALZADOS MARIANGEL CA   )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (134, N'J303114300', N'"AGROPECUARIA LOS NARANJOS, C.A." ("AGROPECUARIA LOS NARANJOS, C.A.")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (135, N'J308452378', N'AUTOS REPUESTOS AFAMIA CA (AUTO REPUESTOS AFAMIA CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (136, N'J300901858', N'"RESTAURANT CLUB CAMPESTRE MARHUANTA, C.A. ("RESTAURANT CLUB CAMPESTRE MARHUANTA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (137, N'J306867872', N'DISTRIBUIDORA Y SERVICIO TECNICO PUNTO SHOP, C.A. (DISTRIBUIDORA Y SERVICIO TECNICO PUNTO SHOP, C.A.', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (138, N'J303252273', N'TORNILLERIA VISTA AL SOL C.A. (TORNILLERIA VISTA AL SOL C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (139, N'J305189790', N'LAFONF AUTO PARTS, C.A. (LAFONF AUTOPARTS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (140, N'J293873770', N'PITSTOP RECARGADO, C.A. (PITSTOP RECARGADO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (141, N'V053406013', N'CARMEN MARIA APONTE DE AULAR', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (142, N'E822468791', N'WEIZHAN LIANG  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (143, N'J295807694', N'FERRETERIA EL CINCEL,C.A (FERRETERIA EL CINCEL,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (144, N'J315718960', N'VERBANO, C.A. (VERBANO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (145, N'J309812297', N'REPUESTOS BELLATRIX C.A (REPUESTOS BELLATRIX C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (146, N'J314972340', N'SUMINISTROS DE MATERIALES BUENA VISTA CA (SUMINISTROS DE MATERIALES BUENA VISTA CA', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (147, N'J316057720', N'BOGOTA MODA, C.A (BOGOTA MODA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (148, N'J296442207', N'READY TO WEAR, C.A (READY TO WEAR, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (149, N'J095130061', N'"AUTOREPUESTOS CARIBE, COMPAÑIA ANONIMA" ("AUTOSREPUESTOS CARIBE,  COMPAÑIA ANONIMA")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (150, N'J303913733', N'INVERSIONES TWISTER CA (INVERSIONES TWISTER, C.A. (BAR RESTAURANT GRAN FURAMA))', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (151, N'J095124819', N'ELECTRO REPUESTOS CARONI C A (ELECTRO REPUESTOS CARONI C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (152, N'J310490996', N'GRUPO GUAYANA, S.A. (GRUPO GUAYANA C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (153, N'J302464633', N'CORPORACION Z.L.G.,S.A. (CORPORACION Z.L.G S.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (154, N'J294794610', N'DECO-ORIENTE, C.A. (DEOCA) (DECO-ORIENTE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (155, N'J293938929', N'FERRETERIA GEORGES C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (156, N'V118968332', N'MORAIMA COROMOTO UTILLA  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (157, N'J310129703', N'COMERCIALIZADORA GPB VALERA, C.A. (COMERCIALIZADORA GPB VALERA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (158, N'J316353796', N'ACCESORIOS VALERA C A (ACCESORIOS VALERA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (159, N'V205317097', N'FABIO CARVAJAL QUINTERO  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (160, N'J301332920', N'INVERSIONES 127 C.A. (INVERSIONES 127, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (161, N'J308295493', N'INVERSIONES VILLA PARAISO,  C.A (AGROPECUARIA ENKIDU C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (162, N'J090161635', N'CAUCHOS MIRO, C.A. (CAUCHOS MIROS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (163, N'J305841519', N'DISTRIBUIDORA AGRICOLA EL RESGUARDO, SOCIEDAD ANONIMA (DISTRIBUIDORA AGRICOLA EL RESGUARDO, SOCIEDAD', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (164, N'J317146298', N'FERRETERIA EL MEJOR PRECIO, C.A. (FERRETERIA EL MEJOR PRECIO C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (165, N'J315336510', N'"J.J.  BARRON, C.A." ("J.J  BARRON, C.A."    )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (166, N'J313280178', N'AGRO CORDILLERA C A (AGRO CORDILLERA C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (167, N'J310837821', N'PENCO TRUJILLO, C.A (PENCO TRUJILLO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (168, N'J090051287', N'FERRETERIA PENSO SRL (FERRETERIA PENSO SRL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (169, N'J306792139', N'CAPINTOR LA PLATA, C.A (CAPINTOR LA PLATA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (170, N'J304774443', N'PENCO LA PLATA COMPAÑIA ANONIMA (PENCO LA PLATA CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (171, N'J304065426', N'SUPLIDORA PENSO BOCONO CA (SUPLIDORA PENSO BOCONO CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (172, N'J302319900', N'SUPLIDORA PENSO, C.A. (PENCO CA) (SUPLIDORA PENSO,C.A.(PENCO CA))', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (173, N'J307789050', N'PENCO  CARS COMPAÑIA ANONIMA (PENCO  CARS COMPAÑIA ANONIMA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (174, N'J306280235', N'CAPINTOR EL VIGIA  COMPAÑIA ANONIMA (CAPINTOR EL VIGIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (175, N'J090026452', N'FERREACRILICOS VALERA C A (FERREACRILICOS VALERA C A     )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (176, N'J090012010', N'CASA DEL PINTOR VALERA C A (CASA DEL PINTOR VALERA C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (177, N'J311082212', N'PENCO TIMOTES, C.A. (PENCO TIMOTES, C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (178, N'J311674659', N'CONSTRUPENCO, C.A. (CONSTRUPENCO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (179, N'J312748117', N'PLANET IMPORT, C.A. (PLANET IMPORT, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (180, N'J293840155', N'INVERSIONES J.M. 96,C.A. (INVERSIONES J.M.96,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (181, N'J304008066', N'DISTRIBUIDORA DE LUBRICANTES LOS GALLEGOS, C.A. (DISTRIBUIDORA DE LUBRICANTES LOS GALLEGOS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (182, N'J302621135', N'DISTRIBUIDORA ZIMAFER CA (DISTRIBUIDORA ZIMAFER, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (183, N'J296010021', N'FERRETERIA EL CONSEJO 2008, C.A. (FERRETERIA EL CONSEJO 2008, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (184, N'J294257704', N'AUTO REPUESTOS MI JEEP 2.000, C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (185, N'J310473129', N'LA LLAVE DORADA, C.A. (LA LLAVE DORADA, C.A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (186, N'J309153595', N'COSMETICOS PROFESIONALES CARLA C.A. (COSMETICOS PROFESIONALES CARLA, CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (187, N'J302468795', N'QUIROVIC S.R.L. (QUIROVIC S.R.L.   )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (188, N'J306088261', N'MONIX C.A (MONIX C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (189, N'V120618845', N'JOAO MANUEL DE ABREU GONCALVES\r\n', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (190, N'J295267924', N'COMERCIAL PATRONA DE ORIENTE C.A. (COMERCIAL PATRONA DE ORIENTE C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (191, N'J315216035', N'AUTO LAVADO VICTORIA SPLASH, C.A (AUTOLAVADO VICTORIA SPLASH, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (192, N'V111774184', N'JOSEFINA GOMEZ ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (193, N'J312729791', N'CERAMICA DON JOSE,C.A. (CERAMICA DON JOSE,C.A.  )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (194, N'J295655681', N'BUONA PASTA RESTAURANT,  C.A (BUONA PASTA RESTAURENT C.A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (195, N'J309961659', N'" LCA SOLUTIONS, C.A. " (" LCA SOLUTIONS, C.A. ")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (196, N'J075249720', N'NOVEDADES JENNYMAR S R L ("NOVEDADES JENNI MAR S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (197, N'J294631401', N'DESECHABLES DONDE MIGUEL, C.A. (DESECHABLES DONDE MIGUEL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (198, N'V132404786', N'JULIETA ALVAREZ ALFONSO  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (199, N'J314669893', N'INVERSIONES ROMACA 72, C.A. (INVERSIONES ROMACA 72, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (200, N'J313125849', N'INVERSIONES MI RETIRO C.A (INVERSIONES MI RETIRO )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (201, N'V085872687', N'"BAZAR SURTI HOGAR F.P." JACINTO DE BAPTISTA MARIA NELLY   ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (202, N'J305294291', N'INVERSIONES GOMEZ,C.A. (INVERSIONES GOMEZ,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (203, N'J302720958', N'AUTO ALARMAS VICTORIA CAR`S C A (AUTO ALARMAS VICTORIA CARS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (204, N'V122330288', N'DALILA VANESSA MORILLO NAVAS', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (205, N'J295775440', N'COMERCIALIZADORA T.S. C.A. (COMERCIALIZADORA T.S. C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (206, N'V103610733', N'YULYMAR RODRIGUEZ ARGUETA', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (207, N'V061198055', N'MARIA INMACULADA ACOSTA PADRON\r\n', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (208, N'J296706816', N'"JUANCHO´S  CAFÉ, C.A" (¿JUANCHO´S  CAFÉ, C.A¿  )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (209, N'V036535055', N'TAMES DE VILLARROEL ARSELINA', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (210, N'J294940218', N'INVERSIONES PACARAIMA,C.A. (INVERSIONES PACARAIMA,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (211, N'J296756350', N'INVERSIONES L Y M 2009 S.R.L. (INVERSIONES L Y M 2009 S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (212, N'J308108030', N'EL OSO FELIZ, C.A. (EL OSO FELIZ)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (213, N'V056244073', N'HERMENEGILDO ALCANTARA CAMACHO\r\n', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (214, N'J296677557', N'CONTRALUZ,  C.A. (CONTRALUZ,  C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
GO
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (215, N'J294710085', N'FRENOS JULIO, C. A. (FRENOS JULIO, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (216, N'V003254042', N'JESUS RAMON BRITO \r', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (217, N'J308296023', N'"INVERSIONES BOHORQUEZ C.A." (INVERSIONES BOHORQUEZ C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (218, N'J295598670', N'INVERSIONES CHARCUPLAZA C.A (INVERSIONES CHARCUPLAZA C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (219, N'J293779286', N'ROCHA CARS, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (220, N'J301833082', N'VIVERO Y RATAN EL RECREO C.A. (VIVERO Y RATAN EL RECREO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (221, N'J314780301', N'MUNDO DEL PC BARQUISIMETO, C.A (MUNDO DEL PC BARQUISIMETO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (222, N'J307871407', N'EL PAJARO SHOP C.A. (EL PAJARO SHOP C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (223, N'J308336874', N'CENTRO TEXTIL V.M.B, CA (CENTRO TEXTIL V.M.B., C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (224, N'J306939865', N'INVERSION DIGITAL C.A. (INVERSION DIGITAL C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (225, N'V122634600', N'FIRAS HOUMAIDAN HOUMAIDAN', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (226, N'J309053523', N'FRUIT CANDY CA (FRUIT CANDY C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (227, N'J300483797', N'REPRESENTACIONES JADIH C A (REPRESENTACIONES JADIH CA )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (228, N'J294762689', N'FERREMATERIALES SAN ROQUE, C.A. (FERREMATERIALES SAN ROQUE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (229, N'J296532850', N'DISTRIBUIDORA ROCER C.A (DISTRIBUIDORA ROCER C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (230, N'J313725862', N'SHOCK INVERSIONES, C.A. (SHOCK INVERSIONES, C. A. )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (231, N'J315535807', N'COPYVARGAS 2006 CA (COPYVARGAS 2006 CA )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (232, N'J295571631', N'MARYOS MANOS DE LUXE CENTRO DE ESTÉTICA INTEGRAL C.A. (MARYOS MANOS DE LUXE CENTRO DE ESTÉTICA INTEG', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (233, N'V074544130', N'NORIS JOSEFINA HERNANDEZ ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (234, N'J309292722', N'"CALZADOS ZARA, C.A". ("CALZADOS ZARA, C.A".)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (235, N'J301768213', N'FARMACIA CORAZON DE JESUS, S.R.L (FARMACIA CORAZON DE JESUS, S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (236, N'J296659214', N'FINCA HOGAR, C.A. (FINCA HOGAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (237, N'J305373728', N'CENTRO OPTICO SALAS, C.A (CENTRO OPTICO SALAS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (238, N'J303798110', N'DONA SHOP, C.A (DONA SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (239, N'J300256103', N'AUTO ACCESORIOS Y PERIQUITOS DANIEL S.R.L. (AUTO ACCESORIOS Y PERIQUITOS DANIEL S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (240, N'J315291169', N'FERRETERIA SAN MIGUEL 2006, C.A. (FERRETERIA SAN MIGUEL 2006, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (241, N'J308828734', N'HOTEL KATUCA, C.A (HOTEL KATUCA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (242, N'J314797620', N'DISTRIBUIDORA LAS TRES A C.A. (DISTRIBUIDORA LAS TRES A CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (243, N'J314774115', N'COMERCIALIZADORA LAS TRES H C.A. (COMERCIALIZADORA LAS TRES H, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (244, N'J296702683', N'"AUTO REACABADOS GUAYANA ,COMPAÑIA ANONIMA" ("AUTO REACABADOS GUAYANA, COMPÑIA ANONIMA")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (245, N'J095077861', N'ALMACEN EL HINDU, C.A. (ALMACEN EL HINDU C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (246, N'J307664827', N'"AUTOREPUESTO ECHEGARAY MOTORS,C.A." (AUTO REPUESTOS ECHEGARAY MOTORS, CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (247, N'J306964509', N'AUTOREPUESTOS DON RAMON, C.A. (AUTO RESPUESTO DON RAMON C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (248, N'J311959947', N'"AUTOREPUESTOS Y ELECTROAUTO MILA, COMPAÑIA ANONIMA". ("AUTOREPUESTOS Y ELECTROAUTO MILA, COMPAÑIA A', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (249, N'J311480650', N'AUTO ACCESORIOS JHON,C.A (AUTO ACCESORIOS JHON,C.A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (250, N'J305978000', N'AGROVENSER,C.A. (AGROVENSER, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (251, N'J304826613', N'COMERCIAL MI CASA, C.A (COMERCIAL MI CASA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (252, N'J306282440', N'COMERCIAL CONTINENTAL, C.A. (COMERCIAL CONTINENTAL, C.A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (253, N'J294355269', N'CRISTALERIA MONAGA, C.A. (CRISTALERIA MONAGA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (254, N'J306562729', N'CRISTALAUTO UPATA S.R.L (CRISTALAUTO UPATA SRL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (255, N'J295843640', N'CONFITERIA SUPER GOLOSINA, C.A. (CONFITERIA SUPER GOLOSINA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (256, N'J303219128', N'COMPUTER SHOP CA (COMPUTER SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (257, N'J314082604', N'"CONFECCIONES YUSTIN, C.A" (CONFECCIONES YUSTIN,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (258, N'J296133468', N'CENTRO DE CONEXIONES EL REY, C.A. (CENTRO DE CONEXIONES EL REY, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (259, N'J313944262', N'COMERCIAL SONRISA TAN, C.A (COMERCIAL SONRISA TAN, C.A    )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (260, N'J293990475', N'CRIST-CHILDREN, COMPAÑIA ANONIMA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (261, N'J314560220', N'CORPORACION LATINOAMERICANA DEL CAUCHO S.A. (CORPORACION LATINOAMERICANA DEL CAUCHO SA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (262, N'J296694915', N'CRIST-CHILD, C.A., (CRIST-CHILD, C.A.,)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (263, N'J311328416', N'COMPUTADORAS RAM,C.A (COMPUTADORAS RAM C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (264, N'J295036515', N'CRIST CHILDREN CA (CRIST CHILDREN CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (265, N'J312706252', N'CASA FIAT C A (CASA FIAT, CA.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (266, N'J312926333', N'DIGITAL WORLD, C.A., (DIGITAL WORLD, C.A.,)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (267, N'J308513725', N'DISTRIBUIDORA JADIL, C.A. (DISTRIBUIDORA JADIL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (268, N'J294509312', N'EL MUNDO DE LAS GORDITAS CA (EL MUNDO DE LAS GORDITAS CA )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (269, N'J295537000', N'FARMACIA RASHALINDA C A ( FARMACIA RASHALINDA C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (270, N'J309857290', N'"FARMA MUNDO, C.A." (FARMA MUNDO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (271, N'J296236623', N'FERREAGRO LA VICTORIA, C.A. (FERREAGRO LA VICTORIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (272, N'J095187772', N'"FERRETERIA DINSA, COMPAÑIA ANONIMA" ("FERRETERIA DINSA, COMPAÑIA ANONIMA")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (273, N'J307012315', N'FIESTA CASINOS GUAYANA C.A. (FIESTA CASINOS GUAYANA C.A.   )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (274, N'J095191427', N'FERRETERIA ELECTRICA CARONI C A (FERRETERIA ELECTRICA CARONI, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (275, N'J316874478', N'FOTO ESTUDIO ROMA DISEñO E IMPRESIONES C.A ("FOTO ESTUDIO ROMA DISEÑO E IMPRESIONES C.A")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (276, N'J296779767', N'"FASHION  STYLE YASMIRA C.A" ("FASHION  STYLE YASMIRA C.A")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (277, N'J307897686', N'GALEARTE  C.A (GALEARTE C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (278, N'J317091507', N'GLOBAL SYSTEM COMPUTER C.A (GLOBAL SYSTEM COMPUTER C.A    )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (279, N'J313120553', N'GRUPO 3H,C.A (GRUPO 3H, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (280, N'J295868847', N'GRUPO ATLANTICO S.A (GRUPO ATLANTICO C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (281, N'J316695409', N'GORDYS` PLUS,C.A. (GORDYS´PLUS, C.A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (282, N'J294134025', N'HARDWARE KING, C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (283, N'J300998398', N'¨HOTEL TUMEREMO CITY, C.A.¨ (TUMEREMO CITY, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (284, N'J295449976', N'INVERSIONES ELECTRONICA ARFA,C.A (INVERSIONES ELECTRONICA ARFA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (285, N'J313416401', N'INVERSIONES PEDRO-JOSE, C.A. (INVERSIONES PEDRO-JOSE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (286, N'J296751935', N'INVERSIONES Y REPRESENTACIONES COMPU MARKETING COMPAÑIA ANONIMA (INVERSIONES Y REPRESENTACIONES COMP', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (287, N'J295675577', N'SYSCOMP DE VENEZUELA, C.A (SYSCOMP DE VENEZUELA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (288, N'J296692475', N'"INVERSIONES Y JOYERIA CENTER,C.A" (INVERSIONES Y JOYERIA CENTER,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (289, N'J316401928', N'INVERSIONES HEDI, C.A. (INVERSIONES HEDI C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (290, N'J295441568', N'INVERSIONES DOBLE PICA C.A. (INVERSIONES DOBLE PICA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (291, N'J295786409', N'"JOYERIA FESTINA", C.A. ("JOYERIA FESTINA", C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (292, N'J294607039', N'JACK POLO, C.A. (JACK POLO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (293, N'J294568807', N'JOYERIA VICTORIA, C.A. (JOYERIA VICTORIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (294, N'J303532411', N'JOYERIA "ISIDORA COMPAÑIA ANONIMA" (JOYERIA  "ISIDORA COMPAÑIA ANONIMA")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (295, N'J296331111', N'JOYERIA LA FERIA DEL ORO, C.A. (JOYERIA LA FERIA DEL ORO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (296, N'J303412831', N'JOYERIA E INVERSIONES ZULIA, C.A. (JOYERIA E INVERSIONES ZULIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (297, N'J308256170', N'JOYERIA OMEGA C.A (JOYERIA OMEGA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (298, N'J293600421', N'JOYERIA EL AGUILA, C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (299, N'J302391814', N'"METAL -MACA GUAYANA, C.A." (METAL MACA GUAYANA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (300, N'J313620599', N'MICROEMPRESA LOS DETALLES (MICROEMPRESA "LOS DETALLES")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (301, N'J312513632', N'MICROEMPRESA INVERSIONES EL BACHIR (MICROEMPRESA "INVERSIONES EL BACHIR")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (302, N'J295690347', N'MICROEMPRESA "MILI MOTO" (MICROEMPRESA "MILI MOTO")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (303, N'J293979021', N'NOVO AUTO, C.A (SERAGROPEC,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (304, N'J308600270', N'ORO DISEÑOS NUR BELEN, COMPAÑIA ANONIMA. (ORO DISENOS NUR BELEN, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (305, N'J297025618', N'RENÉ ORINOCO, C.A. (RENÉ ORINOCO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (306, N'J314851365', N'REPRESENTACIONES ZAPATA, C.A (REPRESENTACIONES ZAPATA, C.A  )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (307, N'J294940226', N'REPRESENTACIONES EL PROGRESO,CA (REPRESENTACIONES EL PROGRESO)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (308, N'J303869416', N'REPRESENTACIONES RAFOMAR II,C.A (REPRESENTACIONES RAFOMAR II,  )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (309, N'J313902888', N'"REAL DE MINAS COMPAÑIA ANONIMA". ("REAL DE MINAS, COMPAÑIA ANONIMA")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (310, N'J294024440', N'SILPECA CA (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (311, N'J305543542', N'SLENDER CENTER GUAYANA C.A. (SLENDER CENTER GUAYANA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (312, N'J312325348', N'SUPERMERCADO CASATODO,C.A (SUPERMERCADO CASATODO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (313, N'J314670743', N'SUMINISTROS COMPUGRAFIC C.A (SUMINISTROS COMPUGRAFIC CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (314, N'J310210128', N'SISTEMAS AM3 CA (SISTEMAS AM3, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
GO
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (315, N'J302543983', N'MOTORES, C.A. (MOTORES,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (316, N'J312969539', N'SUPERMERCADO EL PERFECTO,C.A (SUPERMERCADO EL PERFECTO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (317, N'J295628200', N'SUPERMERCADO LA HERMOSA C.A (SUPERMERCADO LA HERMOSA C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (318, N'J305998019', N'SHOP WAVE, C.A. (SHOP WAVE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (319, N'J295090919', N'"TK TECHNOLOGYS, C.A" (TK TECHNOLOGYS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (320, N'J296424535', N'"TIRE EXPRESS EL GUAMO C.A" ("TIRE EXPRESS EL GUAMO C.A")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (321, N'J302661021', N'TALLER Y JOYERIA EL CORAL, S.R.L. (TALLER Y JOYERIA EL CORAL, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (322, N'J316787699', N'VIVERES PARIA, C.A (VIVERES PARIA, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (323, N'J316353346', N'VIVERES LA MINA, C.A (VIVERES LA MINA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (324, N'J295662840', N'WHITE, C,A (WHITE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (325, N'J312025549', N'YINYI, C.A. (YINYI, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (326, N'J095147401', N'DISTRIBUIDORA CAMPOS, C.A ("DISTRIBUIDORA CAMPOS, C.A.")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (327, N'J095169197', N'ABASTOS LOS CAMPOS S R L (ABASTOS LOS CAMPOS, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (328, N'J315958430', N'DISTRIBUIDORA BERMUDEZ-DIALLO, C.A. (DISTRIBUIDORA BERMUDEZ-DIALLO, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (329, N'J294754465', N'TREMENS, C.A (TREMENS, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (330, N'V114398612', N'ELVIRA CAROLINA LUGO BELLO  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (331, N'J311169946', N'IMPORTADORA AXCEL 212 C.A. (G)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (332, N'J312041803', N'INVERSIONES Y FRIGORIFICO CAPELINHA, C.A. (INVERSIONES Y FRIGORIFICO CAPELINHA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (333, N'J001668721', N'JOYERIA CLAVEL C.A. (JOYERIA CLAVEL C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (334, N'J002241748', N'HOTEL FRANCIA CA (HOTEL FRANCIA CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (335, N'J297040790', N'INVERSIONES BARVALENTINA 3.000, C.A. (INVERSIONES BARVALENTINA 3.000, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (336, N'J295411677', N'INVERSIONES CIBER MOVIL C.A. (INVERSIONES CIBER MOVIL C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (337, N'J316310620', N'SCRUPLES ALTA PELUQUERIA, C.A. (SCRUPLES ALTA PELUQUERIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (338, N'V157931535', N'CARMEN ZENAIDA DIAZ PARRA', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (339, N'J301931165', N'DISTRIBUIDORA DUTY FREE,C.A (DISTRIBUIDORA DUTY FREE,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (340, N'J295451466', N'"PERFUMES PRESTIGIO, C.A." (PERFUMES PRESTIGIO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (341, N'J312698470', N'INVERSIONES VIMENVI, C.A. (....)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (342, N'J303822410', N'INVERSIONES PELICANO MAR, C.A (INVERSIONES PELICANO MAR C A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (343, N'J316275590', N'AGROCRIA CHILI VELOZ, C.A. (X)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (344, N'V029476108', N'HALIME BAHKOS DE SAAD    ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (345, N'J308760820', N'INVERSIONES YUFAANAN, C.A. (INVERSIONES YUFAANAN, C.A.    )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (346, N'J002905239', N'FERRETERIA Y BAZAR MONTEMAR SRL (FERRETERIA Y BAZAR MONTEMAR, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (347, N'J295187297', N'INVERSIONES CREILYS DAYATAIMY,C.A (INVERSIONES CREILYS DAYATAIMY,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (348, N'J295694121', N'HOTEL LA GRAN VENECIA, C.A. (HOTEL LA GRAN VENECIA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (349, N'J314246488', N'INVERSIONES DIANA MDI, C.A. (INVERSIONES DIANA MDI, C.A.   )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (350, N'J295529953', N'AUTO REPUESTOS GALVIS  C.A. (AUTO REPUESTOS GALVIS  C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (351, N'J305690758', N'BAR RESTAURANT FUA FAI, C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (352, N'J302264529', N'AGENCIA DE LOTERIA CHABELA S.R.L (AGENCIA DE LOTERIAS CHABELA,S.R.L)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (353, N'J302383790', N'LAVADO ENGRASE Y SERVICIO VENEZUELA C.A. ("LAVADO, ENGRASE Y SERVICIO VENEZUELA C.A")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (354, N'J309609777', N'DISTRIBUIDORA VERDE-AZUL C.A (DISTRIBUIDORA VERDE-AZUL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (355, N'V135332379', N'MARIA A VALENCIA B ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (356, N'V142835920', N'LORENA CAROLINA CARBONELL BETANCOURT     ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (357, N'J316118703', N'DIVA DIVINA, C.A. (0)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (358, N'J295921608', N'INVERSIONES Y SERVICIOS 311, C.A. (INVERSIONES Y SERVICIOS 311)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (359, N'J308894478', N'LICORERIA EL METRO DE CARICUAO C.A. (LICORERIA EL METRO DE CARICUAO)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (360, N'J311500197', N'QUINCALLA Y ZAPATERIA MINI-BAZAR S.R.L. (QUINCALLA Y ZAPATERIA MINI-BAZAR, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (361, N'V062173102', N'SIMONE MILITE ROMANO     ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (362, N'J001943943', N'SALON DE BELLEZA MI NOMBRE SRL (SALON DE BELLEZA MI NOMBRE SRL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (363, N'J300809447', N'INVERSIONES MERRY CHRISTMAS SRL (INVERSIONES MERRY CHRISTMAS SRL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (364, N'V000211130', N'PEDRO CARRION  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (365, N'J305262900', N'ABASTOS COLOMBIA C.A (F)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (366, N'J305616760', N'DISTRIBUIDORA DONCHIQUI, C.A. (DISTRIBUIDORA DONCHIQUI, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (367, N'J302938694', N'DISTRIBUIDORA REICOLOR C A (DISTRIBUIDORA REICOLOR C A    )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (368, N'J308188921', N'PANADERIA Y PASTELERIA LA GRAN CALIFORNIA, C.A (PANADAERIA Y PASTELERIA LA GRAN CALIFORNIA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (369, N'V061654360', N'MARIA DE LOURDES ALBARRACIN RAMOS     ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (370, N'J296756406', N'INVERSIONES EL CALOR, C.A. (INVERSIONES EL CALOR, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (371, N'J294502776', N'SALON DE BELLEZA FRANCHESKA ESTILOS C.A (SALON DE BELLEZA FRANCHESKA ESTILOS C.A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (372, N'V068723600', N'LUCAS HERNANDEZ BERNAL   ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (373, N'J312626992', N'INVERSIONES DOU DOU SHOP, S.R.L. (INVERSIONES DOU DOU SHOP, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (374, N'V094982240', N'JOSEPH HAYEK SAYEK ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (375, N'E843953720', N'YADIHT YARLEY PARADA GUERRERO\r\n ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (376, N'J295228260', N'REPRESENTACIONES WILLY CENTER W.H. C.A. (REPRESENTACIONES WILLY CENTER W.H.C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (377, N'J314177494', N'COMIDAS AL INSTANTE NATURAL C.A (COMIDAS AL INSTANTE NATURAL C.A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (378, N'J294008119', N'CONSULTORIO OFTALMOLÓGICO POPULAR ALTAMAR C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (379, N'J296628807', N'TASCA RESTAURANT MAKUMBA, C.A. (X)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (380, N'J294727204', N'COMERCIALIZADORA RIO SANA 2027 C.A (COMERCIALIZADORA RIO SANA 2027, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (381, N'J294381707', N'INVERSIONES RAKSON 61 C.A (INVERSIONES RAKSON 61, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (382, N'V062805826', N'AMADORA GOMEZ DE MARIÑO  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (383, N'J312045469', N'INVERSIONES NISI 71, C.A. (INVERSIONES NISI 71, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (384, N'J302740215', N'NATURAL NEZZHEN S.R.L (NATURAL NEZZHEN SRL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (385, N'V197337717', N'SANDRA Y BARON G \r\n', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (386, N'J305090750', N'PANADERIA Y PASTELERIA PRODIGANA, C.A. (PANADERIA Y PASTELERIA PRODIGANA )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (387, N'J315598620', N'CAFE Y RESTAURANT LAZARETO,C.A (CAFE Y RESTAURANT LAZARETO, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (388, N'J294074553', N'BAZARES VIC CAR 2007 C.A. (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (389, N'J000623805', N'PANADERIA Y PASTELERIA LA CRIOLLA SRL (PANADERIA Y PASTELERIA LA CRIOLLA SR)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (390, N'J306839070', N'GLOBAL COM C.A (GLOBAL COM, CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (391, N'J307225980', N'MANSUR SHOP C.A (MANSUR SHOP)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (392, N'J308201936', N'SOLD C.A (SOLD, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (393, N'J300522016', N'ELIASTEX PALACE SHOP CA (ELIASTEX PALACE SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (394, N'J295569289', N'EL REY DEL HOGAR, C.A. (EL REY DEL HOGAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (395, N'J314966588', N'EL ALERTO C.A (EL ALERTO,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (396, N'J313909149', N'VANESSA FLOWERS LIFE, C.A. (VANESSA FLOWERS LIFE,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (397, N'J065097132', N'NABALA IMPORT, C.A. (NABALA IMPORT, C.A. )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (398, N'J295418337', N'FRANCIA HOGAR, C.A. (FRANCIA HOGAR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (399, N'J316618900', N'BURGOS 5, C.A. (U.E. JULIAN VISO, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (400, N'J313892572', N'CHOCOTITOS MARKET I C.A. (CHOCOTITOS MARKET I)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (401, N'J310558973', N'ELECTRONICA JOYAS DEL CARIBE, C.A. (ELECTRONICA JOYAS DEL CARIBE)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (402, N'J302514355', N'AZUCAR SPORT C.A (AZUCAR SPORT)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (403, N'E822786840', N'LISHA WU    ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (404, N'J308540943', N'BATTISTA CIMAGLIA DE DONATO ANTONIO', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (405, N'V081103484', N'ALEJANDRO CONTRERAS ARAQUE  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (406, N'V105610463', N'CARMELA AMIRANTE DE TORRES  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (407, N'J309887998', N'LA DOÑA DEL LLANO REPOSTERIA CAFE C.A (LA DOÑA DEL LLANO REPOSTERIA CAFÉ, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (408, N'V039147722', N'JOSE ELPIDIO VASQUEZ     ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (409, N'V161263946', N'CARLOS JOSE CUADROS GARCIA  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (410, N'J090356746', N'LICORERIA RON Y ALEGRIA, S.A. (LICORERIA RON Y ALEGRIA, S.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (411, N'J304734000', N'SALVADOR, C.A. (SALVADOR, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (412, N'V024790866', N'JUANA DEL CARMEN ORTEGA  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (413, N'J307398205', N'ZAPATERIA MI BOTA C.A. (ZAPATERIA MI BOTA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (414, N'J304427360', N'RETOÑITOS, C.A. (RETOÑITOS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
GO
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (415, N'J303850790', N'MERCADITO ALTO BARINAS C.A (MERCADITO ALTO BARINAS C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (416, N'J305187207', N'FABRICA D CALZADOS ZAPIVER C.A. (.,...)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (417, N'J316482499', N'BRYGA 325748 C.A. (BRYGA 325748 C.A. )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (418, N'J306961550', N'INVERSIONES MARIA 789, SRL (INVERSIONES MARIA 789, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (419, N'J301167058', N'PIZZERIA Y RESTAURANT PIE GRANDE C A (PIZZERIA RESTAURANT PIE GRANDE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (420, N'J308568767', N'DISTRIBUIDORA DIAZ, C.A (DISTRIBUIDORA DIAZ, CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (421, N'J001353852', N'ESTACIONAMIENTO PEREZ Y BAEZ, C.A. (.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (422, N'J002367156', N'ESTACIONAMIENTO BRESO, S.R.L. (.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (423, N'J303315135', N'PANADERIA Y PASTELERIA LA ORQUIEDEA, C.A (PANADERIA Y PASTELERIA LA ORQUIDEA, CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (424, N'J294860672', N'INVERSIONES LIZ  IRAN C.A. (X)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (425, N'J315103893', N'ANIME Z VALERY CA (ANIME Z VALERY CA )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (426, N'J001789006', N'INVERSIONES HIPOCAMPO -HIPO, CA (A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (427, N'J002105720', N'SUPERMERCADO OLTRE MARE C A (X)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (428, N'V012218490', N'CARMEN PARRA DE PEREZ    ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (429, N'J316772802', N'INVERSIONES NETEKIL, C.A. (,,,,,,)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (430, N'V106319797', N'JAIME ALBERTO BLANCO MEDINA ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (431, N'J308459119', N'LA PERFEZIONE C.A (LA PERFEZIONE C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (432, N'J002157399', N'DEPORTES CASTELO DOS, S.R.L. (DEPORTES CASTELO DOS, S.R.L. )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (433, N'J080255143', N'PLASTICOS COLASACCO C A (PLASCOCA    )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (434, N'J307718994', N'REPUESTOS KARIMAR C A (REPUESTOS KARIMAR C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (435, N'J309765191', N'REPUESTOS TERE C A (REPUESTOS TERE C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (436, N'J306909761', N'COMERCIALIZADORA EXCLUSIVA DE ORIENTE C A (COMERCIALIZADORA EXCLUSIVA DE ORIENTE C A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (437, N'J312827033', N'DISTRIBUIDORA JEANKO C A (DISTRIBUIDORA JEANKO, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (438, N'J316156060', N'CASA DE REPUESTOS LA COSTA C.A. (CASA DE REPUESTOS LA COSTA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (439, N'J310923310', N'ATLANTIC FOODS  DELICATESSES, C.A. (ATLANTIC FOODS  DELICATESSES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (440, N'J313661945', N'M.G.M. COMUNICACIONES C A (M.G.M. COMUNICACIONES C A     )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (441, N'J080154037', N'TALLER Y REPUESTOS ATLANTICO C A (TALLER Y REPUESTOS ATLANTICO C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (442, N'J295366035', N'MULTISERVICIOS LA SOLUCION AH 2008, C.A. (MULTISERVICIOS LA SOLUCION AH 2008, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (443, N'V044981153', N'ODEALDO GONZALEZ \r\n', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (444, N'J310313059', N'CONNECTING PEOPLE, S.A (CONNECTING PEOPLE, S.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (445, N'J310661251', N'CORPORACION KUMA C A (CORPORACION KUMA,CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (446, N'J296479828', N'AUTO PARTES GARCIA C A (AUTO PARTES GARCIA C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (447, N'J309681036', N'TECNICA DEL CAUCHO JESUS C A (TECNICA DEL CAUCHO JESUS C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (448, N'J303588948', N'AUTO SERVICIOS EL FRIO SA (AUTO SERVICIOS EL FRIO, CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (449, N'J316721914', N'LA CASA DEL KIT C A (LA CASA DEL KIT C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (450, N'J311845534', N'SU PINTURA C A (SU PINTURA C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (451, N'J308523275', N'"SERVICIOS MULTIPLES MONCHO" C A (SERVICIOS MULTIPLES MONCHO CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (452, N'J306530126', N'MULTISERVICIOS LAR C.A. (ENTONACION DE MOTORES LUIS)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (453, N'J080140702', N'ELECTRO AUTO REGULO C A (AGROPECUARIA ROMERO GOMEZ CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (454, N'J309843362', N'ALFA CAR CENTER C A (ALFA CAR CENTER, CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (455, N'J296000654', N'UNIWELL ZONA ORIENTE C A (UNIWELL ZONA ORIENTE C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (456, N'J301963180', N'INVERSIONES Y MANTENIMIENTOS FERRO-K,C.A. (INVERSIONES Y MANTENIMIENTOS FERRO-K)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (457, N'J306907769', N'COMERCIALIZADORA IRMA, C. A. (COMERCIALIZADORA IRMA,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (458, N'J315105110', N'"COMERCIAL SEÑOR PEPE C A" (COMERCIAL SEÑOR PEPE C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (459, N'J296533164', N'TALLER INSTAGAS ARAGUA,  C.A. (TALLER INSTAGAS ARAGUA,  C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (460, N'J309671340', N'LA CASA DEL TAXISTA KOREANO  C A (LA CASA DEL TAXISTA KOREANO C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (461, N'J310599181', N'FREN AUTO MILENIUM C A (COOPERATIVA DE TRANSPORTE EXCEL. R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (462, N'J295589352', N'WILLIAM EL OFERTON CA (WILLIAM EL OFERTON CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (463, N'J295134495', N'FERREPINTURAS LOS CUMANAGOTOS C A (FERREPINTURAS LOS CUMANAGOSOTOS, CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (464, N'J315820897', N'CHEA S STYLE C A (CHEA S STYLE CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (465, N'J315466660', N'LAMAS PHONE C A (LAMAS PHONE CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (466, N'J312635967', N'AUTO PART EL CUMANES C A (AUTO PART EL CUMANES, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (467, N'V139360776', N'ISABEL MARIA LOPEZ ALFARO', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (468, N'J296643776', N'LA ZONA 4X4 C A (LA ZONA 4X4 C A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (469, N'J309527924', N'SKALA C A (SKALA C A   )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (470, N'J297025685', N'FERRETERIA FARIAS SIGLO XXI CA (FERRETERIA FARIAS SIGLO XXI CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (471, N'J305891141', N'FARMACIA EL ROSAL C A (FARMACIA EL ROSAL C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (472, N'V119034007', N'GLORYS JOSE MARCANO DE CICCIARELLA    ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (473, N'J313219797', N'REPUESTOS ATLANTIC C A (REPUESTOS ATLANTIC C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (474, N'J080064500', N'FARMACIA MERIDA, C A (FARMACIA MERIDA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (475, N'J316241033', N'EL ANGEL DEL REPUESTO C A (EL ANGEL DEL REPUESTO CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (476, N'J297050124', N'GRUPO DON SIMON CA (GRUPO DON SIMON CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (477, N'J307254149', N'BICI SERVI ORIENTE C A (BICI SERVI ORIENTE C A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (478, N'J315370174', N'CAJETINES FRENOS Y SERVICIOS CEDEÑO,CA (CAJETINES FRENOS Y SERVICIOS CEDEÑO C A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (479, N'J308254908', N'TELEFONICA ORIENTAL S A (TELEFONICA ORIENTAL,S.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (480, N'J293797136', N'AUTOMOTRIZ SAMA C.A (SIN NOMBRE COMERCIAL)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (481, N'J311005285', N'REPUESTOS Y ACCESORIOS EL ZULIANO C A (REPUESTOS Y ACCESORIOS EL ZULIANO C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (482, N'J314017411', N'TELPHONE JM C A (TELPHONE JM CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (483, N'J306665757', N'COMERCIAL LA GRIFERIA, SRL (COMERCIAL LA GRIFERIA S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (484, N'J080285131', N'JOMAGA, C.A. (JOMAGA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (485, N'J080235517', N'OPTICA ROSS C A (OPTICA ROSS C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (486, N'J309357433', N'MERIENDITAS Y ALGO MAS C A (MERIENDITAS Y ALGO MAS C.A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (487, N'J295691572', N'MATERIALES HERSAN,C.A (MATERIALES HERSAN,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (488, N'J315868784', N'MIS PELITOS C A (MIS PELITOS C A   )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (489, N'J315890615', N'SUPPLY JEEP C A (SUPPLY JEEP C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (490, N'J308173223', N'FARMACIA Q-MANAGOTO XXI C A (FARMACIA Q-MANAGOTO XXI C A   )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (491, N'J295414897', N'PINTACRILICO, CA (PINTACRILICO CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (492, N'J316465209', N'INVERSIONES SUMI ORIENTE C A (INVERSIONES SUMI ORIENTE C A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (493, N'V177332786', N'MARIA FERNANDA PEREZ CABELLO', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (494, N'J307403233', N'PAPELERIA Y VARIEDADES MULTIAHORRO C A (PAPELERIA Y VARIEDADES MULTIAHORRO C A    ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (495, N'J294695043', N'CIBER CAFE UPATA C A (CIBER CAFE UPATA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (496, N'J296280924', N'INVERSIONES DIVINE FRUITS ORIENTE, C.A (INVERSIONES DIVINE FRUITS ORIENTE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (497, N'J294384919', N'MATERIALES DON CHEVO C A (MATERIALES DON CHEVO C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (498, N'J306226435', N'DIAGNOSTICO Y SERVICIO AUTOMOTRIZ  C A (DIAGNOSTICO Y SERVICIO AUTOMOTRIZ C A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (499, N'J316345173', N'FRENOS GABINO C A (FRENOS GABINO C A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (500, N'J316315967', N'COMUNICACIONES 416 PLAZA MAYOR C A (COMUNICACIONES 416 PLAZA MAYOR C A  )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (501, N'J296271046', N'INFODIARIO CA (INFODIARIO CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (502, N'J316712290', N'GRUPO BELFA C.A (GRUPO BELFA C.A   )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (503, N'J296463441', N'OCASO,C.A. (OCASO,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (504, N'J313955043', N'DIGI CELULAR C.A. (DIGI CELULAR, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (505, N'J308824216', N'MULTI OFERTAS DELTA 2005 C A (MULTI OFERTAS DELTA 2005 C A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (506, N'J080092007', N'LICORERIA LA PORTE$A C A (LICORERIA LA PORTEÑA, CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (507, N'J294356940', N'FLORISTERIA ESTRELLA DE BELEN, C.A. (FLORISTERIA ESTRELLA DE BELEN, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (508, N'J296361401', N'SUCCESS SHOP AC SA (SUCCESS SHOP AC SA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (509, N'J297106308', N'MASCOTAS REGINA XXI C A (MASCOTAS REGINA XXI C A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (510, N'J296295891', N'AGS INVERSIONES,C.A (AGS INVERSIONES,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (511, N'V136484768', N'ANA  LUCIA MARTINEZ PLAZAS  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (512, N'V037646632', N'NORA MARINA TELLES ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (513, N'J304407009', N'PRODUCTOS GENERICOS DE LIMPIEZA SIN ENVASE CARRERO C.A (PRODUCTOS GENERICOS DE LIMPIEZA SIN ENVASE C', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (514, N'J305035016', N'SALA ANDINA CA (SALA ANDINA CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
GO
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (515, N'J090388532', N'SERVICIOS AGROPECUARIAS JAJI, CA (SERVICIOS AGROPECUARIAS JAJI, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (516, N'J293830699', N'ZONA EXCLUSIVA C.A (ZONA EXCLUSIVA C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (517, N'J307828889', N'REPUESTOS SANTA CRUZ CA (REPUESTOS SANTA CRUZ CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (518, N'J304503962', N'FARMACIA SANTA ELENA S.A. (FARMACIA SANTA ELENA S.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (519, N'J310264902', N'PIZZA PIAZZA C A (PIZZA  PIAZZA  CA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (520, N'J295474326', N'INVERSIONES LUCEDI  DAC,C.A (INVERSIONES LUCEDI  DAC,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (521, N'E005322092', N'VICENZO PIACQUAIDIO GUGLIEMUCCI\r', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (522, N'J302272467', N'"BAR RESTAURANT PUERTO LIBRE, S.R.L." ("BAR RESTAURAN PUERTO LIBRE, S.R.L")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (523, N'J295481250', N'FOTO EXPRESS,C.A (FOTO EXPRESS,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (524, N'V159558726', N'LEIDY DIANA FARFAN GARCIA', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (525, N'J304883030', N'"INVERSIONES LEYDI, C.A." ("INVERSIONES LEYDI, C.A."   )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (526, N'J315976242', N'PA DONDE LOS MUCHACHOS, C.A. (PA DONDE LOS MUCHACHOS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (527, N'J065052457', N'EL BODEGON ITALIANO, C.A. (BODEGON ITALIANO, S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (528, N'J301094158', N'LA MARINA IMPORT, C.A. (LA MARINA IMPORT, C. A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (529, N'J294726356', N'FINISH LINE, C.A (FINISH LINE, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (530, N'J294284426', N'REPUESTOS  LAGUNA, C.A. (REPUESTOS LAGUNA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (531, N'J295689187', N'AUTOLAVADO FORMULA 1, C.A (AUTOLAVADO FORMULA 1,C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (532, N'J311299521', N'LA FERIA SHOES STORE,C.A (LA FERIA SHOES STORE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (533, N'J296773785', N'BAMBOO SHOP, C.A. (BAMBOO SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (534, N'J296183180', N'ARRECIFE, C.A. (ARRECIFE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (535, N'V138487080', N'REFAAT ILBEH OULBEH', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (536, N'J316348865', N'FRANLIST. COM C.A (FRANLIST. COM C.A )', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (537, N'J307829737', N'UNISEX INTERNACIONAL C.A (UNISEX INTERNACIONAL,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (538, N'J311814590', N'CORNER STORE C.A. (CORNER STORE C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (539, N'J065031727', N'CASTOR INTERNACIONAL C A (CASTOR INTERNACIONAL,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (540, N'V132820828', N'EIMAN EL YARAMANI FAHED  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (541, N'J313430129', N'REPRESENTACIONES ALTAGRACIA S.A (REPRESENTACIONES ALTAGARCIA C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (542, N'V135650478', N'YELITZA JOSEFINA (MOVIL - GAMES Y.J.O.M., F.P.) ORDAZ MILLAN  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (543, N'J310916756', N'MARGARITA STAR PC C.A. (MARGARITA STAR PC C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (544, N'J065036648', N'TECNI ALINEACION EL ESPINAL S.R.L. (TECNI ALINEACION EL ESPINAL S.R.L.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (545, N'E843110536', N'CRISTIAN ROLANDO BARROSO ARAQUE\r', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (546, N'J308233307', N'HIELO SAN JOSE C.A (HIELO SAN JOSE)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (547, N'J296988269', N'USCOMPUTER, C.A (USCOMPUTER,C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (548, N'J065110384', N'SHOE CENTER C.A. (SHOE CENTER, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (549, N'J310179069', N'INVERSIONES LAS 5A, C.A (INVERSIONES LAS 5 A, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (550, N'J300715531', N'FARMACIA PARAGUACHI C A (FARMACIA PARAGUACHI, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (551, N'J293752990', N'DAYRE SHOP, C.A. (DAYRE SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (552, N'J309785001', N'GORCRIS JEANS C.A. (GORCRIS JEANS)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (553, N'J309772163', N'XTREMO CAFE, C.A. (XTREMO CAFÈ)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (554, N'J312482540', N'INVERSIONES PIRMAR, C.A (INVERSIONES PIRMAR C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (555, N'J309492535', N'ANDI SHOP, C.A. (ANDI SHOP, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (556, N'J293907950', N'MG FASHION CAFE, C.A. (MG FASHION, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (557, N'J296487260', N'EL MUNDO DEL AMORTIGUADOR MARGARITA, C.A. (EL MUNDO DEL AMORTIGUADOR MARGARITA, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (558, N'V040480451', N'EMILIO RODRIGUEZ MILLAN  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (559, N'J294087191', N'GEMA GROUP, C.A (GEMA GROUP, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (560, N'V094254180', N'DANIEL JOSE MORENO SALAZAR  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (561, N'V083843930', N'SABINA DEL CARMEN MARIN  ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (562, N'V048866120', N'LUISA ELENA GIL \r\n ', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (563, N'J305853061', N'LICORERIA EL CORRECAMINOS GEORGE, C.A. (LICORERIA EL CORRE CAMINO GEORGE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (564, N'J314999770', N'YAQUE MARE, C.A. (YAQUE MARE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (565, N'J295476272', N'"PA´DANIEL CARS". C.A ("PA´DANIEL CARS". C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (566, N'J296316252', N'RAJI STORE, C.A. (RAJI STORE, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (567, N'J315150727', N'INVERSIONES Y DISTRIBUCIONES ROJAS, C.A. (INVERSIONES Y DISTRIBUCIONES ROJAS C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (568, N'J303828116', N'RESTAURANT LA CRIOLLADA C.A (RESTAURANT LA CRIOLLADA)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (569, N'J313139378', N'DISTRIBUIDORA A.B.P 2005 C.A (DISTRIBUIDORA A.B.P., 2005, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (570, N'J312022647', N'LENCERIA DAMASCO, C.A. (LENCERIA DAMASCO C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (571, N'J303828205', N'INVERSIONES RAMON MARIN C.A (URBANISMOS Y MOVIMIENTOS CARABOB, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (572, N'J304922680', N'AGENCIA DE FESTEJOS LAS AMERICAS C.A (AGENCIA DE FESTEJO LAS AMERICAS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (573, N'V080957790', N'ARVEL ARNALDO GUERRA DAZA', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (574, N'J305753458', N'ESTUDIO ESTETICO UNISEX ENMANUEL, C.A. (ESTUDIO ESTETICO UNISEX ENMANUEL, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (575, N'J313650846', N'"VIDEOXPLODE C.A." ("VIDEOXPLODE C.A.")', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (576, N'J312902892', N'RESTAURANT EL FRITIN, C.A. (RESTAURANT EL FRITIN C,A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (577, N'J312309156', N'SABRIN IMPORT, C.A. (SABRIN IMPORT, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (578, N'J295631880', N'EL MAGNIFICO KIDS,  C.A. (EL MAGNIFICO KIDS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (579, N'J301998065', N'CENTRAL SPORT TOURS, C.A. (CENTRAL SPORT TOURS, C.A.)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_FinalsClients] ([id], [rif], [description], [name], [lastName], [phone], [email], [fiscalAddress], [enable], [creation_date]) VALUES (580, N'J307485930', N'HADI SHOP, C.A. (HADI SHOP, C.A)', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2020-03-06T14:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_FinalsClients] OFF
SET IDENTITY_INSERT [dbo].[Sisg_FiscalsOperations] ON 

INSERT [dbo].[Sisg_FiscalsOperations] ([id], [fiscalOperation], [fiscalMode], [providerId], [distributorId], [technicianId], [finalClientId], [serial], [initSeal], [finalSeal], [fiscalAddress], [fiscalResult], [serialRetative], [codeOperation], [creation_date]) VALUES (1, N'FISCALIZACION', N'AUXILIAR', 1, 7, 2, 10, N'Z1B8100007', N'DA123', N'2324', N'Domicilio fiscal actual', 0, N'', N'699996388', CAST(N'2020-04-14T17:12:13.390' AS DateTime))
INSERT [dbo].[Sisg_FiscalsOperations] ([id], [fiscalOperation], [fiscalMode], [providerId], [distributorId], [technicianId], [finalClientId], [serial], [initSeal], [finalSeal], [fiscalAddress], [fiscalResult], [serialRetative], [codeOperation], [creation_date]) VALUES (4, N'DESBLOQUEO', N'REMOTO', 1, 9, 18, 10, N'Z1B1234567', N'45435', N'4545', N'Calle la Loma de Tamaritno', 0, N'', N'458011532', CAST(N'2020-11-20T12:27:51.653' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_FiscalsOperations] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Marks] ON 

INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (0, N'VARIAS', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (1, N'ACLAS', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (2, N'BIXOLON', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (3, N'CASIO', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (4, N'CUSTOM', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (5, N'GENERICO', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (6, N'OKI', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (7, N'STAR', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (8, N'UNIWELL', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (9, N'RIVAO', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (10, N'Generac', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (11, N'Imobile', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (13, N'DASCOM', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (14, N'HKA', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Marks] ([id], [name], [creation_date]) VALUES (15, N'PANTUM', CAST(N'2019-10-08T11:32:22.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Marks] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Menus] ON 

INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (1, N'Productos', 0, N'/', 1, 3, N'#', 1, N'', CAST(N'2019-12-26T18:38:37.1206350' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (2, N'Categorías', 1, N'Index', 2, 1, N'Category/', 1, N'Image/category.ico', CAST(N'2020-02-19T01:04:08.5201882' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (3, N'Repuestos', 1, N'Index', 2, 5, N'Replacement/', 1, N'Image/replacement/.ico', CAST(N'2019-12-27T14:09:08.0845497' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (4, N'Clientes', 0, N'/', 1, 2, N'#', 1, NULL, CAST(N'2019-05-03T17:45:47.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (5, N'Proveedores', 4, N'Index', 2, 1, N'Provider/', 1, N'Image/supplier.ico', CAST(N'2019-05-29T16:36:12.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (6, N'Distribuidores', 4, N'Index', 2, 2, N'Distributor/', 1, N'Image/distributor.ico', CAST(N'2019-06-17T16:05:38.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (7, N'Casas de Software', 4, N'Index', 2, 4, N'DeveloperClient/', 1, N'Image/develoment.ico', CAST(N'2019-12-27T14:16:05.5905969' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (8, N'Técnicos de Clientes', 4, N'Index', 2, 3, N'Technician/', 1, N'Image/technicians.ico', CAST(N'2019-06-26T17:42:57.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (9, N'Empleados', 0, N'/', 1, 1, N'#', 1, N'', CAST(N'2019-12-26T18:38:15.3402575' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (10, N'Empleados', 9, N'Index', 2, 1, N'Employee/', 1, N'Image/employees.ico', CAST(N'2019-12-26T18:40:52.4610971' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (11, N'Manejo de Cuentas', 0, N'/', 1, 0, N'#', 1, NULL, CAST(N'2019-05-03T17:45:47.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (12, N'Roles', 11, N'Index', 2, 1, N'Rol/', 1, N'Image/roles.ico', CAST(N'2019-05-14T12:44:51.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (13, N'Usuarios', 11, N'Index', 2, 2, N'User/', 1, N'Imagen/users.ico', CAST(N'2019-05-03T17:45:47.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (14, N'Menus', 11, N'Index', 2, 3, N'Menu/', 1, N'Image/menus.ico', CAST(N'2019-05-06T14:30:23.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (15, N'Perfiles', 0, N'/', 1, 4, N'#', 1, N'', CAST(N'2019-06-18T13:34:31.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (16, N'Personal', 15, N'/Index', 2, 1, N'Distributor/', 1, N'Image/nomina.ico', CAST(N'2019-06-18T15:30:41.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (17, N'Técnicos', 15, N'/Index', 2, 2, N'Technician/', 1, N'Image/tecnical.ico', CAST(N'2019-06-26T18:06:38.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (18, N'Marcas', 1, N'Index', 2, 2, N'Mark/', 1, N'', CAST(N'2019-12-27T14:10:08.3098367' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (19, N'Modelos', 1, N'Index', 2, 3, N'Model/', 1, N'', CAST(N'2019-12-27T14:11:27.5133353' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (20, N'Accesorios', 1, N'Index', 2, 4, N'Accessory/', 1, N'', CAST(N'2019-12-27T14:12:05.1695849' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (21, N'Departamentos', 9, N'Index', 2, 2, N'Departament/', 1, N'', CAST(N'2019-12-27T14:12:46.8962988' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (22, N'Cargos', 9, N'Index', 2, 3, N'Chargue/', 1, N'', CAST(N'2019-12-27T14:13:33.0006929' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (23, N'Clientes Finales', 4, N'Index', 2, 5, N'FinalClient/', 1, N'', CAST(N'2019-12-27T14:14:21.9736334' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (24, N'Programador', 15, N'Index', 2, 1, N'DeveloperClient/', 1, N'', CAST(N'2020-01-02T18:50:36.2292733' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (25, N'Datos y Grupo', 15, N'Index', 2, 1, N'Employee/', 1, N'', CAST(N'2020-01-02T19:03:32.3895132' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (26, N'Productos Terminados', 1, N'Index', 2, 6, N'Product/', 1, N'', CAST(N'2020-02-19T01:03:42.3375877' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (27, N'Prefijos', 1, N'Index', 2, 7, N'Prefix/', 1, N'', CAST(N'2020-02-19T00:54:17.2405101' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (28, N'Operaciones', 0, N'/', 1, 4, N'#', 1, N'', CAST(N'2020-04-07T20:38:02.7594788' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (29, N'Seriales Productos', 28, N'Index', 2, 1, N'SerialProduct/', 1, N'', CAST(N'2020-04-07T20:38:36.6431023' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (30, N'Seriales Repuestos', 28, N'Index', 2, 2, N'SerialReplacement/', 1, N'', CAST(N'2020-04-07T20:39:03.6780065' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (31, N'Enajenaciones', 28, N'Index', 2, 3, N'Alienation/', 1, N'', CAST(N'2020-04-14T19:19:37.7487953' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (32, N'Operaciones Fiscales', 28, N'Index', 2, 4, N'FiscalOperation/', 1, N'', CAST(N'2020-04-14T19:23:02.7614174' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (33, N'Operaciones Técnicas', 28, N'/Index', 2, 5, N'TechnicalOperation/', 0, N'', CAST(N'2020-04-27T19:05:54.8126702' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (34, N'Intervenciones Tecnicas', 28, N'Index', 2, 5, N'TechnicalOperation/', 1, N'', CAST(N'2020-04-29T23:33:35.8972851' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (35, N'Consolidacion XML', 28, N'Index', 2, 6, N'Consolidation/', 1, N'', CAST(N'2020-04-29T23:33:58.7767757' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (36, N'Registro de Eventos', 28, N'Index', 2, 7, N'Activity/', 1, N'', CAST(N'2020-06-19T20:17:34.9756144' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (37, N'Taller de Equipos', 0, N'/', 1, 5, N'#', 1, N'', CAST(N'2020-09-29T18:37:11.7150584' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (38, N'Ordenes de Taller', 37, N'Index', 2, 1, N'Workshop', 1, N'', CAST(N'2020-10-02T15:25:19.4534365' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (39, N'Cola de Ordenes', 37, N'RowOrders', 2, 2, N'Workshop', 1, N'', CAST(N'2020-09-29T18:39:03.7895066' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (40, N'Asignación de Ordenes', 37, N'AssignOrders', 2, 3, N'Workshop', 1, N'', CAST(N'2020-10-09T20:31:25.5399435' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (41, N'Revisión y Diagnostico', 37, N'ReviewOrders', 2, 4, N'Workshop', 1, N'', CAST(N'2020-11-26T14:15:24.9891553' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (42, N'Presupuesto', 37, N'Billing', 2, 5, N'Workshop', 1, N'', CAST(N'2020-11-26T14:16:33.1519836' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (43, N'Soporte', 0, N'/', 1, 6, N'#', 1, N'', CAST(N'2020-12-28T14:15:39.0619473' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (44, N'Casos de Integracion', 43, N'Index', 2, 1, N'CasesSoftwareHouse', 1, N'', CAST(N'2020-12-28T14:16:42.7639797' AS DateTime2))
INSERT [dbo].[Sisg_Menus] ([id], [name], [parentId], [view], [level], [order], [url], [visible], [path_icon], [creation_date]) VALUES (45, N'Reporte de Casas Software', 43, N'Index2', 2, 2, N'CasesSoftwareHouse', 1, N'', CAST(N'2021-01-19T17:41:21.1212103' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Menus] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Models] ON 

INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (0, 0, N'VARIOS', CAST(N'2020-02-19T19:41:30.3364742' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (1, 2, N'SRP-350', CAST(N'2019-10-17T11:24:16.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (2, 2, N'SRP-270', CAST(N'2019-10-17T11:24:38.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (3, 1, N'CR2300', CAST(N'2019-10-17T11:28:25.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (4, 13, N'TD-1140', CAST(N'2019-10-18T16:10:24.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (5, 2, N'SRP-350-IFA', CAST(N'2020-02-19T16:09:11.3860013' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (6, 1, N'CR2100', CAST(N'2020-02-19T19:30:12.0649928' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (7, 1, N'CR68AFJ', CAST(N'2020-02-19T19:35:04.1695221' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (8, 6, N'MICROLINE-1120', CAST(N'2020-02-19T19:36:00.4781486' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (9, 3, N'FE-5000', CAST(N'2020-02-19T19:36:26.7343167' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (10, 4, N'KUBE', CAST(N'2020-02-19T19:37:07.0572136' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (11, 1, N'PP1F3', CAST(N'2020-02-19T19:37:33.6867182' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (12, 15, N'P2506W', CAST(N'2020-02-19T19:38:10.1759209' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (13, 14, N'iSmart-W', CAST(N'2020-02-19T19:39:59.5131057' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (14, 14, N'iMobile', CAST(N'2020-02-19T19:40:43.5895022' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (15, 1, N'LS21530EC', CAST(N'2020-02-19T19:41:30.3364742' AS DateTime2))
INSERT [dbo].[Sisg_Models] ([id], [markId], [name], [creation_date]) VALUES (16, 13, N'TD-1125', CAST(N'2021-01-10T17:47:11.3692457' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Models] OFF
SET IDENTITY_INSERT [dbo].[Sisg_PhotographsOrder] ON 

INSERT [dbo].[Sisg_PhotographsOrder] ([id], [orderId], [imageUrl], [creation_date]) VALUES (1, 1, N'IMG_20170304_131605.jpg', CAST(N'2020-12-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_PhotographsOrder] ([id], [orderId], [imageUrl], [creation_date]) VALUES (2, 1, N'Business Model Canvas.jpg', CAST(N'2020-12-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_PhotographsOrder] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Prefixes] ON 

INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (0, N'000', N'NONE', CAST(N'2020-02-20T14:16:36.000' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (3, N'800', N'Z1B', CAST(N'2020-02-18T16:00:30.000' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (4, N'F01', N'F01', CAST(N'2020-02-18T16:00:30.000' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (5, N'700', N'DLA', CAST(N'2020-02-18T16:00:30.000' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (6, N'F12', N'F12', CAST(N'2020-02-18T16:00:30.000' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (8, N'9009', N'Z1D', CAST(N'2020-02-19T16:07:48.543' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (10, N'130', N'ZZF', CAST(N'2020-02-19T19:49:09.337' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (11, N'300', N'ZZB', CAST(N'2020-02-19T19:52:24.917' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (12, N'777', N'Z8A', CAST(N'2020-02-19T19:56:32.363' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (13, N'500', N'DED', CAST(N'2020-02-19T20:04:31.963' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (14, N'6006', N'ZZD', CAST(N'2020-02-19T22:03:22.950' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (16, N'280', N'280', CAST(N'2020-02-21T16:07:16.477' AS DateTime))
INSERT [dbo].[Sisg_Prefixes] ([id], [initCorrelative], [initAlphaNum], [creation_date]) VALUES (17, N'201', N'ZZA', CAST(N'2020-02-26T19:21:52.870' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_Prefixes] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Products] ON 

INSERT [dbo].[Sisg_Products] ([id], [prefixId], [categoryId], [modelId], [name], [description], [code], [state], [imageUrl], [creation_date]) VALUES (0, 0, 4, 0, N'Producto Generico', N'Representa un Equipo Generico', N'PT0000', 1, NULL, CAST(N'2020-12-10T01:02:11.927' AS DateTime))
INSERT [dbo].[Sisg_Products] ([id], [prefixId], [categoryId], [modelId], [name], [description], [code], [state], [imageUrl], [creation_date]) VALUES (1, 3, 1, 1, N'Impresora Fiscal Termica', N'Impresor Fiscal para imprimir en papel térmico con Memoria Auditoria interna y prerto USB 2.0', N'PT1001', 1, N'SRP-350.jpg', CAST(N'2020-02-19T01:02:11.927' AS DateTime))
INSERT [dbo].[Sisg_Products] ([id], [prefixId], [categoryId], [modelId], [name], [description], [code], [state], [imageUrl], [creation_date]) VALUES (2, 11, 1, 2, N'Impresora Fiscal Matrix de Cinta', N'Impresora con Cinta y matrix de puntos con doble rollo', N'PT1002', 1, N'SRP-270.jpg', CAST(N'2020-02-19T19:53:14.280' AS DateTime))
INSERT [dbo].[Sisg_Products] ([id], [prefixId], [categoryId], [modelId], [name], [description], [code], [state], [imageUrl], [creation_date]) VALUES (3, 10, 3, 3, N'Caja Registradora con Display', N'Caja con un solo Rollo, Display extra y una Memoria de Auditoria de 2 Mega', N'PT3001', 1, N'CR-2300.jpg', CAST(N'2020-02-19T19:50:07.700' AS DateTime))
INSERT [dbo].[Sisg_Products] ([id], [prefixId], [categoryId], [modelId], [name], [description], [code], [state], [imageUrl], [creation_date]) VALUES (4, 8, 2, 5, N'Impresora Fiscal de Apuesta', N'Impresor Fiscal para emitir ticket de lotería nacional', N'PT55443', 1, NULL, CAST(N'2020-02-19T16:10:48.617' AS DateTime))
INSERT [dbo].[Sisg_Products] ([id], [prefixId], [categoryId], [modelId], [name], [description], [code], [state], [imageUrl], [creation_date]) VALUES (5, 16, 5, 15, N'Balanza dos Display', N'Es una balanza elegante de robusto diseño, dos display y con batería.', N'B6547', 1, N'LS21530EC.jpg', CAST(N'2020-02-21T16:08:03.057' AS DateTime))
INSERT [dbo].[Sisg_Products] ([id], [prefixId], [categoryId], [modelId], [name], [description], [code], [state], [imageUrl], [creation_date]) VALUES (6, 12, 6, 14, N'iMobile Eternet', N'Es un dispositivo electrónico, que se conecta a una máquina fiscal, permitiendo extraer los reportes Z contenidos en la memoria fiscal y transmitirla', N'IM9000', 1, N'iMobile-E.jpg', CAST(N'2020-02-19T19:58:59.857' AS DateTime))
INSERT [dbo].[Sisg_Products] ([id], [prefixId], [categoryId], [modelId], [name], [description], [code], [state], [imageUrl], [creation_date]) VALUES (7, 0, 11, 12, N'Impresora Láser', N'Impresora Láser Monocromática Inalámbrica', N'PT43212', 1, NULL, CAST(N'2020-02-19T20:02:02.727' AS DateTime))
INSERT [dbo].[Sisg_Products] ([id], [prefixId], [categoryId], [modelId], [name], [description], [code], [state], [imageUrl], [creation_date]) VALUES (8, 13, 3, 9, N'Caja Registradora LCD', N'Caja Registradora con Display LCD', N'CS3322', 1, NULL, CAST(N'2020-02-19T20:05:28.040' AS DateTime))
INSERT [dbo].[Sisg_Products] ([id], [prefixId], [categoryId], [modelId], [name], [description], [code], [state], [imageUrl], [creation_date]) VALUES (9, 5, 1, 10, N'Impresora Italiana Fiscal', N'Laser corta', N'PT676722', 1, NULL, CAST(N'2020-11-24T14:59:40.540' AS DateTime))
INSERT [dbo].[Sisg_Products] ([id], [prefixId], [categoryId], [modelId], [name], [description], [code], [state], [imageUrl], [creation_date]) VALUES (12, 0, 1, 16, N'Impresora Fiscal Matrix II', N'Alta resolución', N'PT07676', 1, N'TD-1125.jpg', CAST(N'2021-01-10T17:51:25.030' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_Products] OFF
SET IDENTITY_INSERT [dbo].[Sisg_ProductsAccessories] ON 

INSERT [dbo].[Sisg_ProductsAccessories] ([id], [productId], [accessoryId]) VALUES (4, 1, 1)
INSERT [dbo].[Sisg_ProductsAccessories] ([id], [productId], [accessoryId]) VALUES (1, 1, 2)
INSERT [dbo].[Sisg_ProductsAccessories] ([id], [productId], [accessoryId]) VALUES (2, 3, 2)
INSERT [dbo].[Sisg_ProductsAccessories] ([id], [productId], [accessoryId]) VALUES (3, 3, 6)
SET IDENTITY_INSERT [dbo].[Sisg_ProductsAccessories] OFF
SET IDENTITY_INSERT [dbo].[Sisg_ProductsReplacements] ON 

INSERT [dbo].[Sisg_ProductsReplacements] ([id], [productId], [replacementId]) VALUES (1, 1, 1)
INSERT [dbo].[Sisg_ProductsReplacements] ([id], [productId], [replacementId]) VALUES (2, 1, 5)
INSERT [dbo].[Sisg_ProductsReplacements] ([id], [productId], [replacementId]) VALUES (3, 3, 3)
SET IDENTITY_INSERT [dbo].[Sisg_ProductsReplacements] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Profiles] ON 

INSERT [dbo].[Sisg_Profiles] ([id], [name], [description], [creation_date]) VALUES (1, N'Empleado Administrador', N'Empleado administrador del Sistema', CAST(N'2019-04-08T12:08:34.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Profiles] ([id], [name], [description], [creation_date]) VALUES (2, N'Empleado Supervisor', N'Empleado gerencial con personal a cargo', CAST(N'2019-04-08T12:08:34.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Profiles] ([id], [name], [description], [creation_date]) VALUES (3, N'Empleado Operativo', N'Empleado que ejecuta una función a cargo', CAST(N'2019-04-08T12:08:34.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Profiles] ([id], [name], [description], [creation_date]) VALUES (4, N'Cliente Principal', N'Cliente distribuidor que administra su cuenta y sus relaciones con tecnicos.', CAST(N'2019-04-08T12:08:34.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Profiles] ([id], [name], [description], [creation_date]) VALUES (5, N'Cliente Dependiente', N'Cliente que edepende de una relación de un cliente principal.', CAST(N'2019-04-08T12:08:34.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Profiles] ([id], [name], [description], [creation_date]) VALUES (6, N'Cliente Integrador', N'CLiente que hace la intgegración de un sistema con un producto.', CAST(N'2019-04-08T12:08:34.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Profiles] ([id], [name], [description], [creation_date]) VALUES (7, N'Cliente Mixto', N'Cliente principal e integrador a la vez.', CAST(N'2019-04-08T12:08:34.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Profiles] ([id], [name], [description], [creation_date]) VALUES (8, N'Cliente Final', N'Cliente final usuario de una maquina fiscal.', CAST(N'2019-04-08T12:08:34.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Profiles] OFF
SET IDENTITY_INSERT [dbo].[Sisg_ProgramLenguages] ON 

INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (1, N'A# .NET', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (2, N'A# (Axiom)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (3, N'A-0 System', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (4, N'A+', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (5, N'A++', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (6, N'ABAP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (7, N'ABC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (8, N'ABC ALGOL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (9, N'ABLE', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (10, N'ABSET', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (11, N'ABSYS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (12, N'Abundance', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (13, N'ACC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (14, N'Accent', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (15, N'Ace DASL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (16, N'ACT-III', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (17, N'Action!', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (18, N'ActionScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (19, N'Ada', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (20, N'Adenine', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (21, N'Agda', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (22, N'Agora', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (23, N'AIMMS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (24, N'Alef', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (25, N'ALF', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (26, N'ALGOL 58', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (27, N'ALGOL 60', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (28, N'ALGOL 68', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (29, N'Alice', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (30, N'Alma-0', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (31, N'AmbientTalk', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (32, N'Amiga E', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (33, N'AMOS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (34, N'AMPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (35, N'APL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (36, N'AppleScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (37, N'Arc', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (38, N'Arden Syntax[1]', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (39, N'ARexx', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (40, N'Argus', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (41, N'AspectJ', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (42, N'Assembly language', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (43, N'ATS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (44, N'Ateji PX', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (45, N'AutoHotkey', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (46, N'Autocoder', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (47, N'AutoIt', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (48, N'AutoLISP / Visual LISP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (49, N'Averest', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (50, N'AWK', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (51, N'Axum', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (52, N'B', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (53, N'Babbage', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (54, N'Bash', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (55, N'BASIC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (56, N'bc', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (57, N'BCPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (58, N'BeanShell', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (59, N'Batch (Windows/Dos)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (60, N'Bertrand', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (61, N'BETA', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (62, N'Bigwig', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (63, N'Bistro', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (64, N'BitC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (65, N'BLISS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (66, N'Blue', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (67, N'Bon', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (68, N'Boo', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (69, N'Boomerang', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (70, N'Bourne shell (including bash and ksh)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (71, N'BREW', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (72, N'BPEL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (73, N'BUGSYS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (74, N'BuildProfessional', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (75, N'C', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (76, N'C--', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (77, N'C++ - ISO/IEC 14882', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (78, N'C# - ISO/IEC 23270', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (79, N'C/AL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (80, N'Caché ObjectScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (81, N'C Shell', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (82, N'Caml', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (83, N'Candle', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (84, N'Cayenne', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (85, N'CDuce', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (86, N'Cecil', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (87, N'Cel', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (88, N'Cesil', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (89, N'Ceylon', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (90, N'CFML', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (91, N'Cg', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (92, N'Chapel', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (93, N'CHAIN', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (94, N'Charity', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (95, N'Charm', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (96, N'Chef', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (97, N'CHILL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (98, N'CHIP-8', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (99, N'chomski', 1)
GO
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (100, N'Chrome (now Oxygene)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (101, N'ChucK', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (102, N'CICS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (103, N'Cilk', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (104, N'CL (IBM)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (105, N'Claire', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (106, N'Clarion', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (107, N'Clean', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (108, N'Clipper', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (109, N'CLIST', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (110, N'Clojure', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (111, N'CLU', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (112, N'CMS-2', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (113, N'COBOL - ISO/IEC 1989', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (114, N'CobolScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (115, N'Cobra', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (116, N'CODE', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (117, N'CoffeeScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (118, N'Cola', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (119, N'ColdC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (120, N'ColdFusion', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (121, N'Cool', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (122, N'COMAL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (123, N'Combined Programming Language (CPL)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (124, N'Common Intermediate Language (CIL)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (125, N'Common Lisp (also known as CL)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (126, N'COMPASS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (127, N'Component Pascal', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (128, N'COMIT', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (129, N'Constraint Handling Rules (CHR)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (130, N'Converge', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (131, N'Coral 66', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (132, N'Corn', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (133, N'CorVision', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (134, N'Coq', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (135, N'COWSEL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (136, N'CPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (137, N'csh', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (138, N'CSP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (139, N'Csound', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (140, N'Curl', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (141, N'Curry', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (142, N'Cyclone', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (143, N'Cython', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (144, N'D', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (145, N'DASL (Datapoint''s Advanced Systems Language)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (146, N'DASL (Distributed Application Specification Language)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (147, N'Dart', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (148, N'DataFlex', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (149, N'Datalog', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (150, N'DATATRIEVE', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (151, N'dBase', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (152, N'dc', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (153, N'DCL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (154, N'Deesel (formerly G)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (155, N'Delphi', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (156, N'DinkC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (157, N'DIBOL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (158, N'DL/I', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (159, N'Draco', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (160, N'Dylan', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (161, N'DYNAMO', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (162, N'E', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (163, N'E#', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (164, N'Ease', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (165, N'EASY', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (166, N'Easy PL/I', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (167, N'EASYTRIEVE PLUS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (168, N'ECMAScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (169, N'Edinburgh IMP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (170, N'EGL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (171, N'Eiffel', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (172, N'ELAN', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (173, N'Emacs Lisp', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (174, N'Emerald', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (175, N'Epigram', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (176, N'Erlang', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (177, N'Escapade', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (178, N'Escher', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (179, N'ESPOL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (180, N'Esterel', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (181, N'Etoys', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (182, N'Euclid', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (183, N'Euler', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (184, N'Euphoria', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (185, N'EusLisp Robot Programming Language', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (186, N'CMS EXEC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (187, N'EXEC 2', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (188, N'F', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (189, N'F#', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (190, N'Factor', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (191, N'Falcon', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (192, N'Fancy', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (193, N'Fantom', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (194, N'FAUST', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (195, N'Felix', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (196, N'Ferite', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (197, N'FFP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (198, N'Fjölnir', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (199, N'FL', 1)
GO
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (200, N'Flavors', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (201, N'Flex', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (202, N'FLOW-MATIC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (203, N'FOCAL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (204, N'FOCUS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (205, N'FOIL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (206, N'FORMAC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (207, N'@Formula', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (208, N'Forth', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (209, N'Fortran - ISO/IEC 1539', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (210, N'Fortress', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (211, N'FoxBase', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (212, N'FoxPro', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (213, N'FP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (214, N'FPr', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (215, N'Franz Lisp', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (216, N'Frink', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (217, N'F-Script', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (218, N'FSProg', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (219, N'Fuxi', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (220, N'G', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (221, N'Game Maker Language', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (222, N'GameMonkey Script', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (223, N'GAMS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (224, N'GAP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (225, N'G-code', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (226, N'Genie', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (227, N'GDL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (228, N'Gibiane', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (229, N'GJ', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (230, N'GLSL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (231, N'GNU E', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (232, N'GM', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (233, N'Go', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (234, N'Go!', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (235, N'GOAL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (236, N'Gödel', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (237, N'Godiva', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (238, N'GOM (Good Old Mad)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (239, N'Goo', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (240, N'GOTRAN', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (241, N'GPSS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (242, N'GraphTalk', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (243, N'GRASS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (244, N'Groovy', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (245, N'HAL/S', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (246, N'Hamilton C shell', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (247, N'Harbour', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (248, N'Haskell', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (249, N'HaXe', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (250, N'High Level Assembly', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (251, N'HLSL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (252, N'Hop', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (253, N'Hope', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (254, N'Hugo', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (255, N'Hume', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (256, N'HyperTalk', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (257, N'IBM Basic assembly language', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (258, N'IBM HAScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (259, N'IBM Informix-4GL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (260, N'IBM RPG', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (261, N'ICI', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (262, N'Icon', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (263, N'Id', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (264, N'IDL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (265, N'IMP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (266, N'Inform', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (267, N'Io', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (268, N'Ioke', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (269, N'IPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (270, N'IPTSCRAE', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (271, N'ISLISP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (272, N'ISPF', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (273, N'ISWIM', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (274, N'J', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (275, N'J#', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (276, N'J++', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (277, N'JADE', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (278, N'Jako', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (279, N'JAL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (280, N'Janus', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (281, N'JASS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (282, N'Java', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (283, N'JavaScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (284, N'JCL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (285, N'JEAN', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (286, N'Join Java', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (287, N'JOSS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (288, N'Joule', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (289, N'JOVIAL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (290, N'Joy', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (291, N'Julia', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (292, N'JScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (293, N'JavaFX Script', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (294, N'K', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (295, N'Kaleidoscope', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (296, N'Karel', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (297, N'Karel++', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (298, N'Kaya', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (299, N'KEE', 1)
GO
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (300, N'KIF', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (301, N'KRC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (302, N'KRL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (303, N'KRL (KUKA Robot Language)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (304, N'KRYPTON', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (305, N'ksh', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (306, N'L', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (307, N'L# .NET', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (308, N'LabVIEW', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (309, N'Ladder', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (310, N'Lagoona', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (311, N'LANSA', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (312, N'Lasso', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (313, N'LaTeX', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (314, N'Lava', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (315, N'LC-3', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (316, N'Leadwerks Script', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (317, N'Leda', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (318, N'Legoscript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (319, N'LIL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (320, N'LilyPond', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (321, N'Limbo', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (322, N'Limnor', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (323, N'LINC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (324, N'Lingo', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (325, N'Linoleum', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (326, N'LIS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (327, N'LISA', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (328, N'Lisaac', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (329, N'Lisp - ISO/IEC 13816', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (330, N'Lite-C Lite-c', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (331, N'Lithe', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (332, N'Little b', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (333, N'Logo', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (334, N'Logtalk', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (335, N'LPC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (336, N'LSE', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (337, N'LSL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (338, N'LiveCode', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (339, N'Lua', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (340, N'Lucid', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (341, N'Lustre', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (342, N'LYaPAS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (343, N'Lynx', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (344, N'M', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (345, N'M2001', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (346, N'M4', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (347, N'Machine code', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (348, N'MAD (Michigan Algorithm Decoder)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (349, N'MAD/I', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (350, N'Magik', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (351, N'Magma', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (352, N'make', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (353, N'Maple', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (354, N'MAPPER (Unisys/Sperry) now part of BIS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (355, N'MARK-IV (Sterling/Informatics) now VISION:BUILDER of CA', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (356, N'Mary', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (357, N'MASM Microsoft Assembly x86', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (358, N'Mathematica', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (359, N'MATLAB', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (360, N'Maxima (see also Macsyma)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (361, N'Max (Max Msp - Graphical Programming Environment)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (362, N'MaxScript internal language 3D Studio Max', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (363, N'Maya (MEL)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (364, N'MDL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (365, N'Mercury', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (366, N'Mesa', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (367, N'Metacard', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (368, N'Metafont', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (369, N'MetaL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (370, N'Microcode', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (371, N'MicroScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (372, N'MIIS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (373, N'MillScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (374, N'MIMIC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (375, N'Mirah', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (376, N'Miranda', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (377, N'MIVA Script', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (378, N'ML', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (379, N'Moby', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (380, N'Model 204', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (381, N'Modelica', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (382, N'Modula', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (383, N'Modula-2', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (384, N'Modula-3', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (385, N'Mohol', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (386, N'MOO', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (387, N'Mortran', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (388, N'Mouse', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (389, N'MPD', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (390, N'MSIL - deprecated name for CIL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (391, N'MSL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (392, N'MUMPS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (393, N'Napier88', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (394, N'NASM', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (395, N'NATURAL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (396, N'Neko', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (397, N'Nemerle', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (398, N'NESL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (399, N'Net.Data', 1)
GO
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (400, N'NetLogo', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (401, N'NetRexx', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (402, N'NewLISP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (403, N'NEWP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (404, N'Newspeak', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (405, N'NewtonScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (406, N'NGL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (407, N'Nial', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (408, N'Nice', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (409, N'Nickle', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (410, N'NPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (411, N'Not eXactly C (NXC)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (412, N'Not Quite C (NQC)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (413, N'Nu', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (414, N'NSIS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (415, N'o:XML', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (416, N'Oak', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (417, N'Oberon', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (418, N'Obix', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (419, N'OBJ2', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (420, N'Object Lisp', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (421, N'ObjectLOGO', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (422, N'Object REXX', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (423, N'Object Pascal', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (424, N'Objective-C', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (425, N'Objective-J', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (426, N'Obliq', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (427, N'Obol', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (428, N'OCaml', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (429, N'occam', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (430, N'occam-p', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (431, N'Octave', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (432, N'OmniMark', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (433, N'Onyx', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (434, N'Opa', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (435, N'Opal', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (436, N'OpenEdge ABL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (437, N'OPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (438, N'OPS5', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (439, N'OptimJ', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (440, N'Orc', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (441, N'ORCA/Modula-2', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (442, N'Oriel', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (443, N'Orwell', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (444, N'Oxygene', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (445, N'Oz', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (446, N'P#', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (447, N'PARI/GP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (448, N'Pascal - ISO 7185', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (449, N'Pawn', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (450, N'PCASTL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (451, N'PCF', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (452, N'PEARL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (453, N'PeopleCode', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (454, N'Perl', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (455, N'PDL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (456, N'PHP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (457, N'Phrogram', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (458, N'Pico', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (459, N'Pict', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (460, N'Pike', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (461, N'PIKT', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (462, N'PILOT', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (463, N'Pizza', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (464, N'PL-11', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (465, N'PL/0', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (466, N'PL/B', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (467, N'PL/C', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (468, N'PL/I - ISO 6160', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (469, N'PL/M', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (470, N'PL/P', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (471, N'PL/SQL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (472, N'PL360', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (473, N'PLANC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (474, N'Plankalkül', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (475, N'PLEX', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (476, N'PLEXIL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (477, N'Plus', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (478, N'POP-11', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (479, N'PostScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (480, N'PortablE', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (481, N'Powerhouse', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (482, N'PowerBuilder - 4GL GUI appl. generator from Sybase', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (483, N'PPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (484, N'Processing', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (485, N'Processing.js', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (486, N'Prograph', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (487, N'PROIV', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (488, N'Prolog', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (489, N'Visual Prolog', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (490, N'Promela', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (491, N'PROTEL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (492, N'ProvideX', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (493, N'Pro*C', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (494, N'Pure', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (495, N'Python', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (496, N'Q (equational programming language)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (497, N'Q (programming language from Kx Systems)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (498, N'Qi', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (499, N'QtScript', 1)
GO
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (500, N'QuakeC', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (501, N'QPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (502, N'R', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (503, N'R++', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (504, N'Racket', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (505, N'RAPID', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (506, N'Rapira', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (507, N'Ratfiv', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (508, N'Ratfor', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (509, N'rc', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (510, N'REBOL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (511, N'Redcode', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (512, N'REFAL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (513, N'Reia', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (514, N'Revolution', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (515, N'rex', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (516, N'REXX', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (517, N'Rlab', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (518, N'ROOP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (519, N'RPG', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (520, N'RPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (521, N'RSL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (522, N'RTL/2', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (523, N'Ruby', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (524, N'Rust', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (525, N'S', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (526, N'S2', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (527, N'S3', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (528, N'S-Lang', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (529, N'S-PLUS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (530, N'SA-C', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (531, N'SabreTalk', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (532, N'SAIL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (533, N'SALSA', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (534, N'SAM76', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (535, N'SAS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (536, N'SASL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (537, N'Sather', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (538, N'Sawzall', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (539, N'SBL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (540, N'Scala', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (541, N'Scheme', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (542, N'Scilab', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (543, N'Scratch', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (544, N'Script.NET', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (545, N'Sed', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (546, N'Self', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (547, N'SenseTalk', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (548, N'SETL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (549, N'Shift Script', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (550, N'SiMPLE', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (551, N'SIMPOL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (552, N'SIMSCRIPT', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (553, N'Simula', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (554, N'Simulink', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (555, N'SISAL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (556, N'SLIP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (557, N'SMALL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (558, N'Smalltalk', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (559, N'Small Basic', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (560, N'SML', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (561, N'SNOBOL(SPITBOL)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (562, N'Snowball', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (563, N'SOL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (564, N'Span', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (565, N'SPARK', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (566, N'SPIN', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (567, N'SP/k', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (568, N'SPS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (569, N'Squeak', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (570, N'Squirrel', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (571, N'SR', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (572, N'S/SL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (573, N'Strand', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (574, N'STATA', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (575, N'Stateflow', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (576, N'Subtext', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (577, N'Suneido', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (578, N'SuperCollider', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (579, N'SuperTalk', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (580, N'SYMPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (581, N'SyncCharts', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (582, N'SystemVerilog', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (583, N'T', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (584, N'TACL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (585, N'TACPOL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (586, N'TADS', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (587, N'TAL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (588, N'Tcl', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (589, N'Tea', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (590, N'TECO', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (591, N'TELCOMP', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (592, N'TeX', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (593, N'TEX', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (594, N'TIE', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (595, N'Timber', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (596, N'TMG', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (597, N'Tom', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (598, N'TOM', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (599, N'Topspeed', 1)
GO
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (600, N'TPU', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (601, N'Trac', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (602, N'T-SQL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (603, N'TTCN', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (604, N'Turing', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (605, N'TUTOR', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (606, N'TXL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (607, N'Ubercode', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (608, N'UCSD Pascal', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (609, N'Unicon', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (610, N'Uniface', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (611, N'UNITY', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (612, N'Unix shell', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (613, N'UnrealScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (614, N'Vala', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (615, N'VBA', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (616, N'VBScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (617, N'Verilog', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (618, N'VHDL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (619, N'Visual Basic', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (620, N'Visual Basic .NET', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (621, N'Visual C#', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (622, N'Visual DataFlex', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (623, N'Visual DialogScript', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (624, N'Visual FoxPro', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (625, N'Visual J++', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (626, N'Visual J#', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (627, N'Visual Objects', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (628, N'VSXu', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (629, N'Vvvv', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (630, N'WATFIV, WATFOR', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (631, N'WebDNA', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (632, N'WebQL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (633, N'Winbatch', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (634, N'X++', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (635, N'X10', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (636, N'XBL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (637, N'XC (exploits XMOS architecture)', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (638, N'xHarbour', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (639, N'XL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (640, N'XOTcl', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (641, N'XPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (642, N'XPL0', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (643, N'XQuery', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (644, N'XSB', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (645, N'XSLT - See XPath', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (646, N'Yorick', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (647, N'YQL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (648, N'Yoix', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (649, N'Z notation', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (650, N'Zeno', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (651, N'ZOPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (652, N'ZPL', 1)
INSERT [dbo].[Sisg_ProgramLenguages] ([id], [name], [visible]) VALUES (653, N'ZZT-oop', 1)
SET IDENTITY_INSERT [dbo].[Sisg_ProgramLenguages] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Providers] ON 

INSERT [dbo].[Sisg_Providers] ([id], [rif], [description], [address], [phone], [email], [image], [creation_date]) VALUES (1, N'J312171197', N'Bits Americas SAS C.A', N'Calle Callejón Guitérrez, Av Fco Miranda. La California Norte. Caracas - Venezuela', N'+58 212 2375253', N'contac@bitsamericas.com', N'LogoTFHKA.jpg', CAST(N'2019-05-23T16:41:53.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Providers] ([id], [rif], [description], [address], [phone], [email], [image], [creation_date]) VALUES (2, N'J293987130', N'Impresoras Fiscales 421 C.A', N'La California Norte, Av. Fco. Miranda, Torre Profesional La California, piso 9.', N'582122354145', N'contac@impresoras421.com', N'LogoIF421.jpg', CAST(N'2019-05-23T16:44:43.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Providers] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Replacements] ON 

INSERT [dbo].[Sisg_Replacements] ([id], [prefixId], [modelId], [name], [description], [code], [parts], [state], [imageUrl], [creation_date]) VALUES (1, 0, 3, N'Cable de Batería', N'Cable a base de esmalte de goma y cobre de vinolo', N'CALATCRD81F', N'12121X00088', 1, N'img/cable_bat.jpeg', CAST(N'2020-02-20T20:26:48.580' AS DateTime))
INSERT [dbo].[Sisg_Replacements] ([id], [prefixId], [modelId], [name], [description], [code], [parts], [state], [imageUrl], [creation_date]) VALUES (2, 0, 3, N'Cable Plano de Impresores', NULL, N'CABXXCRI81F', N'MU-000045', 1, NULL, CAST(N'2020-02-20T22:22:38.007' AS DateTime))
INSERT [dbo].[Sisg_Replacements] ([id], [prefixId], [modelId], [name], [description], [code], [parts], [state], [imageUrl], [creation_date]) VALUES (3, 0, 3, N'Anillo Tornillo Fiscal ', N'81F -FJ/ 68AF -FJ', N'CABBXXCRD83G', N'S/P', 0, NULL, CAST(N'2020-01-23T11:01:21.000' AS DateTime))
INSERT [dbo].[Sisg_Replacements] ([id], [prefixId], [modelId], [name], [description], [code], [parts], [state], [imageUrl], [creation_date]) VALUES (4, 0, 2, N'Motor de Avance Cinta y Cabezal', N'Elemento a base de electro magnetigmo de 5V', N'CABCATCRD74F', N'MY000098', 0, NULL, CAST(N'2020-01-23T11:01:31.000' AS DateTime))
INSERT [dbo].[Sisg_Replacements] ([id], [prefixId], [modelId], [name], [description], [code], [parts], [state], [imageUrl], [creation_date]) VALUES (5, 0, 2, N'Motor de Avance de Papel', NULL, N'CABBXXCRI32F', N'M20033332', 1, N'img/motor_32.jpeg', CAST(N'2020-01-23T11:04:18.000' AS DateTime))
INSERT [dbo].[Sisg_Replacements] ([id], [prefixId], [modelId], [name], [description], [code], [parts], [state], [imageUrl], [creation_date]) VALUES (6, 0, 4, N'Selenoide ', N'Sensor para gaveta', N'CABBXXCRD00G', N'120L', 1, NULL, CAST(N'2020-01-23T11:00:10.000' AS DateTime))
INSERT [dbo].[Sisg_Replacements] ([id], [prefixId], [modelId], [name], [description], [code], [parts], [state], [imageUrl], [creation_date]) VALUES (7, 6, 4, N'Memoria Fiscal Ganesha', N'Memoria de Vinilo de 8 GB', N'MG3333', N'MS432X', 1, NULL, CAST(N'2020-02-19T03:25:02.307' AS DateTime))
INSERT [dbo].[Sisg_Replacements] ([id], [prefixId], [modelId], [name], [description], [code], [parts], [state], [imageUrl], [creation_date]) VALUES (8, 0, 6, N'Batería de 12 VDC', N'Pila de carbono de plástica', N'BT555433', N'52121X00033', 1, N'img/bate12_bat.jpeg', CAST(N'2020-02-26T20:22:50.763' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_Replacements] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Roles] ON 

INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (1, N'Administrador del Sistema', 1, 1, CAST(N'2019-05-20T13:00:01.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (2, N'Gerente de Servicios', 2, 2, CAST(N'2019-04-08T12:04:42.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (3, N'Supervisor Tecnico', 5, 2, CAST(N'2019-04-30T17:42:07.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (4, N'Gerente Técnologico', 3, 2, CAST(N'2019-04-08T12:04:42.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (5, N'Analista Tecnico', 4, 3, CAST(N'2019-04-30T09:46:52.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (6, N'Analista Administrativo', 5, 3, CAST(N'2019-04-08T12:04:42.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (7, N'Gerente Administrativo', 3, 2, CAST(N'2019-07-03T13:13:43.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (8, N'Técnico de Taller', 6, 3, CAST(N'2019-04-08T12:08:11.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (9, N'Cliente Centro de Servicios', 4, 4, CAST(N'2019-04-08T12:04:42.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (10, N'Técnico Centro de Servicios', 5, 5, CAST(N'2019-04-08T12:04:42.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (11, N'Programador Casa de Software', 5, 6, CAST(N'2019-04-08T12:04:42.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (12, N'Analista Operativo', 5, 3, CAST(N'2020-11-20T12:25:34.8881366' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (14, N'Receptor', 5, 3, CAST(N'2020-12-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Roles] ([id], [description], [accessId], [profileId], [creation_date]) VALUES (15, N'Invitado', 10, 8, CAST(N'2020-12-10T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Roles] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Rolesmenus] ON 

INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (1, 1, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (3, 2, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (5, 3, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (7, 4, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (9, 5, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (11, 6, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (13, 7, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (15, 8, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (17, 9, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (19, 10, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (21, 11, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (22, 12, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (23, 13, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (24, 14, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (31, 18, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (32, 19, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (33, 20, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (34, 21, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (35, 22, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (36, 23, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (39, 24, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (46, 25, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (56, 26, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (57, 27, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (58, 28, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (59, 29, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (60, 30, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (69, 31, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (70, 32, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (82, 33, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (84, 34, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (85, 35, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (90, 36, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (114, 37, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (115, 38, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (116, 39, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (117, 40, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (133, 41, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (134, 42, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (151, 43, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (152, 44, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (155, 45, 1)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (2, 1, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (6, 3, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (8, 4, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (10, 5, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (12, 6, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (98, 7, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (16, 8, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (18, 9, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (20, 10, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (68, 20, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (37, 23, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (47, 25, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (67, 26, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (61, 28, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (63, 29, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (65, 30, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (71, 31, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (78, 32, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (86, 34, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (118, 37, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (122, 38, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (128, 39, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (131, 40, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (148, 41, 2)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (91, 6, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (97, 7, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (41, 15, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (100, 23, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (48, 25, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (62, 28, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (64, 29, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (66, 30, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (72, 31, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (79, 32, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (87, 34, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (119, 37, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (123, 38, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (129, 39, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (132, 40, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (147, 41, 3)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (14, 7, 4)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (25, 14, 4)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (42, 15, 4)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (49, 25, 4)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (94, 4, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (93, 6, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (96, 7, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (95, 8, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (43, 15, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (101, 23, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (51, 25, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (108, 28, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (105, 29, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (110, 30, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (111, 31, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (112, 32, 5)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (113, 34, 5)
GO
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (44, 15, 6)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (52, 25, 6)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (120, 37, 6)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (141, 42, 6)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (55, 15, 7)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (53, 25, 7)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (138, 37, 7)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (140, 42, 7)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (4, 2, 8)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (45, 15, 8)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (54, 25, 8)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (121, 37, 8)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (125, 38, 8)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (150, 41, 8)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (26, 15, 9)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (28, 16, 9)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (29, 17, 9)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (76, 28, 9)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (73, 31, 9)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (80, 32, 9)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (88, 34, 9)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (127, 37, 9)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (126, 38, 9)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (27, 15, 10)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (30, 17, 10)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (77, 28, 10)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (81, 32, 10)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (83, 33, 10)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (89, 34, 10)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (38, 15, 11)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (40, 24, 11)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (153, 43, 11)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (154, 44, 11)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (143, 15, 12)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (145, 25, 12)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (142, 15, 14)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (144, 25, 14)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (135, 37, 14)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (136, 38, 14)
INSERT [dbo].[Sisg_Rolesmenus] ([id], [MenuId], [RolId]) VALUES (137, 39, 14)
SET IDENTITY_INSERT [dbo].[Sisg_Rolesmenus] OFF
SET IDENTITY_INSERT [dbo].[Sisg_SerialsProducts] ON 

INSERT [dbo].[Sisg_SerialsProducts] ([id], [serial], [productId], [distributorId], [providerId], [dateSale], [observations], [creation_date]) VALUES (1, N'Z1B8100007', 1, 7, 1, CAST(N'2020-03-09T14:52:00.000' AS DateTime), N'1 IMP SRP-350 / CLIENTE RETIRA', CAST(N'2020-03-09T18:20:33.000' AS DateTime))
INSERT [dbo].[Sisg_SerialsProducts] ([id], [serial], [productId], [distributorId], [providerId], [dateSale], [observations], [creation_date]) VALUES (2, N'Z1B1234567', 1, 9, 1, CAST(N'2020-11-20T11:55:12.207' AS DateTime), N'Serial de Pruebas Internas', CAST(N'2020-11-20T11:55:12.307' AS DateTime))
INSERT [dbo].[Sisg_SerialsProducts] ([id], [serial], [productId], [distributorId], [providerId], [dateSale], [observations], [creation_date]) VALUES (4, N'Z1B8100001', 1, 7, 1, CAST(N'2020-11-24T10:00:00.000' AS DateTime), N'Carga Manual', CAST(N'2020-11-24T10:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_SerialsProducts] ([id], [serial], [productId], [distributorId], [providerId], [dateSale], [observations], [creation_date]) VALUES (5, N'DLA7000001', 9, 4, 2, CAST(N'2020-11-24T15:02:02.633' AS DateTime), N'Nota Orden', CAST(N'2020-11-24T15:02:02.713' AS DateTime))
INSERT [dbo].[Sisg_SerialsProducts] ([id], [serial], [productId], [distributorId], [providerId], [dateSale], [observations], [creation_date]) VALUES (6, N'DLA7000002', 9, 4, 2, CAST(N'2020-11-26T13:30:47.040' AS DateTime), N'Test', CAST(N'2020-11-26T13:30:47.150' AS DateTime))
INSERT [dbo].[Sisg_SerialsProducts] ([id], [serial], [productId], [distributorId], [providerId], [dateSale], [observations], [creation_date]) VALUES (7, N'Z1D9999999', 4, 9, 1, CAST(N'2020-11-30T15:55:09.150' AS DateTime), N'Serial de Pruebas Internas', CAST(N'2020-11-30T15:55:09.290' AS DateTime))
INSERT [dbo].[Sisg_SerialsProducts] ([id], [serial], [productId], [distributorId], [providerId], [dateSale], [observations], [creation_date]) VALUES (8, N'Z1B8100008', 1, 7, 1, CAST(N'2020-11-09T14:52:00.000' AS DateTime), N'1 IMP SRP-350 - CLIENTE DELIVERY', CAST(N'2020-11-30T16:08:00.723' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_SerialsProducts] OFF
SET IDENTITY_INSERT [dbo].[Sisg_SerialsReplacements] ON 

INSERT [dbo].[Sisg_SerialsReplacements] ([id], [serial], [replacementId], [distributorId], [providerId], [dateSale], [observations], [creation_date]) VALUES (2, N'F02A8100DC7', 7, 8, 2, CAST(N'2020-03-09T14:52:00.000' AS DateTime), N'RPTO/P71792/RETIRA/CF', CAST(N'2020-03-09T18:20:33.000' AS DateTime))
INSERT [dbo].[Sisg_SerialsReplacements] ([id], [serial], [replacementId], [distributorId], [providerId], [dateSale], [observations], [creation_date]) VALUES (3, N'F05E8D00F45', 7, 1, 1, CAST(N'2020-03-09T14:52:00.000' AS DateTime), NULL, CAST(N'2020-03-09T18:20:33.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_SerialsReplacements] OFF
SET IDENTITY_INSERT [dbo].[Sisg_States] ON 

INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (1, N'Dtto Fed./Miranda', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (2, N'Amazonas', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (3, N'Anzoategui', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (4, N'Apure', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (5, N'Aragua', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (6, N'Barinas', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (7, N'Bolivar', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (8, N'Carabobo', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (9, N'Cojedes', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (10, N'Delta Amacuro', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (11, N'Falcon', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (12, N'Guarico', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (13, N'Lara', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (14, N'Merida', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (15, N'Miranda ', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (16, N'Monagas', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (17, N'Nueva Esparta', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (18, N'Portuguesa', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (19, N'Sucre', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (20, N'Tachira', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (21, N'Trujillo', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (22, N'Yaracuy', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (23, N'Zulia', 232)
INSERT [dbo].[Sisg_States] ([id], [description], [countryId]) VALUES (24, N'Vargas', 232)
SET IDENTITY_INSERT [dbo].[Sisg_States] OFF
SET IDENTITY_INSERT [dbo].[Sisg_StatesOrder] ON 

INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (1, N'Por Recibir', CAST(N'2020-08-06T10:27:39.000' AS DateTime))
INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (2, N'Recibido', CAST(N'2020-08-06T10:27:53.000' AS DateTime))
INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (3, N'Asignado', CAST(N'2020-08-06T10:28:02.000' AS DateTime))
INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (4, N'Revisión', CAST(N'2020-08-06T10:28:12.000' AS DateTime))
INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (5, N'Pendiente Aprobación', CAST(N'2020-08-06T10:28:22.000' AS DateTime))
INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (6, N'Presupuesto Aprobado', CAST(N'2020-08-06T10:28:31.000' AS DateTime))
INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (7, N'Presupuesto Rechazado', CAST(N'2020-08-06T10:28:41.000' AS DateTime))
INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (8, N'Reparando', CAST(N'2020-08-06T10:28:53.000' AS DateTime))
INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (9, N' Facturando', CAST(N'2020-08-06T10:29:04.000' AS DateTime))
INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (10, N'Por Entregar', CAST(N'2020-08-06T10:29:15.000' AS DateTime))
INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (11, N'Entregado', CAST(N'2020-08-06T10:29:26.000' AS DateTime))
INSERT [dbo].[Sisg_StatesOrder] ([id], [description], [creation_date]) VALUES (12, N'Anulado', CAST(N'2020-08-06T10:29:41.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_StatesOrder] OFF
SET IDENTITY_INSERT [dbo].[Sisg_StatesWarranty] ON 

INSERT [dbo].[Sisg_StatesWarranty] ([id], [description], [creation_date]) VALUES (0, N'Por validar', CAST(N'2020-11-23T18:19:08.000' AS DateTime))
INSERT [dbo].[Sisg_StatesWarranty] ([id], [description], [creation_date]) VALUES (1, N'Garantía doce(12) Meses', CAST(N'2020-11-23T18:19:08.000' AS DateTime))
INSERT [dbo].[Sisg_StatesWarranty] ([id], [description], [creation_date]) VALUES (2, N'Garantía seis (6) Meses ', CAST(N'2020-11-23T18:19:08.000' AS DateTime))
INSERT [dbo].[Sisg_StatesWarranty] ([id], [description], [creation_date]) VALUES (3, N'Sin garantía', CAST(N'2020-11-23T18:19:08.000' AS DateTime))
INSERT [dbo].[Sisg_StatesWarranty] ([id], [description], [creation_date]) VALUES (4, N'Reincidente', CAST(N'2020-11-23T18:19:08.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_StatesWarranty] OFF
SET IDENTITY_INSERT [dbo].[Sisg_StatusIntegrations] ON 

INSERT [dbo].[Sisg_StatusIntegrations] ([id], [name], [visible]) VALUES (1, N'Registrado', 1)
INSERT [dbo].[Sisg_StatusIntegrations] ([id], [name], [visible]) VALUES (2, N'Abierto', 1)
INSERT [dbo].[Sisg_StatusIntegrations] ([id], [name], [visible]) VALUES (3, N'Cerrado', 1)
INSERT [dbo].[Sisg_StatusIntegrations] ([id], [name], [visible]) VALUES (4, N'Por Integrar', 1)
INSERT [dbo].[Sisg_StatusIntegrations] ([id], [name], [visible]) VALUES (5, N'Integrado', 1)
INSERT [dbo].[Sisg_StatusIntegrations] ([id], [name], [visible]) VALUES (6, N'Anulado', 1)
SET IDENTITY_INSERT [dbo].[Sisg_StatusIntegrations] OFF
SET IDENTITY_INSERT [dbo].[Sisg_SystemOpers] ON 

INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (1, N'Windows 95 ', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (2, N'Windows 98', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (3, N'Windows 98 SE', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (4, N'Windows Me', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (5, N'Windows NT', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (6, N'Microsoft Windows 2000', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (7, N'Microsoft Windows XP', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (8, N'Windows Server 2003', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (9, N'Microsoft Windows Vista 32bits', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (10, N'Microsoft Windows Vista 64bits', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (11, N'Microsoft Windows 7 32bits', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (12, N'Microsoft Windows 7 64bits', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (13, N'Mac OS X v10.5 (Leopard) ', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (14, N'Mac OS X v10.4 (Tiger)', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (15, N'Mac OS X v10.3 (Panther)', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (16, N'Mac OS X v10.2 (Jaguar)', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (17, N'Mac OS X v10.1 (Puma)', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (18, N'Mac OS X v10.0 (Cheetah)', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (19, N'Mac OS 9', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (20, N'Mac OS 8', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (21, N'Mac OS X v10.6 (Snow Leopard)', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (22, N'Mac OS X v10.7 (Lion)', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (23, N'Mac OS X v10.8 (Mountain Lion)', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (24, N'Linux-Ubuntu 32bits', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (25, N'Linux-Ubuntu 64bits', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (26, N'Linux-Fedora 32bits', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (27, N'Linux-Fedora 64bits', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (28, N'Linux-Gentoo', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (29, N'Linux-Red Hat', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (30, N'Linux-Arch', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (31, N'Linux-Mandriva', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (32, N'Linux-Slackware', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (33, N'Linux-Canaima', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (34, N'Windows CE', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (35, N'Windows CE', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (36, N'Microsoft Windows 8 32bits', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (37, N'Microsoft Windows 8 64bits', 1)
INSERT [dbo].[Sisg_SystemOpers] ([id], [name], [visible]) VALUES (38, N'Microsoft Windows 10 64bits', 1)
SET IDENTITY_INSERT [dbo].[Sisg_SystemOpers] OFF
SET IDENTITY_INSERT [dbo].[Sisg_TechnicalsOperations] ON 

INSERT [dbo].[Sisg_TechnicalsOperations] ([id], [providerId], [distributorId], [finalClientId], [technicianId], [typeOperationTechId], [serial], [observation], [status], [operation_date], [creation_date]) VALUES (1, 1, 7, 38, 2, 3, N'Z1B8100007', N'', N'DECLARADO', CAST(N'2020-04-13T00:00:00.000' AS DateTime), CAST(N'2020-04-10T14:23:07.000' AS DateTime))
INSERT [dbo].[Sisg_TechnicalsOperations] ([id], [providerId], [distributorId], [finalClientId], [technicianId], [typeOperationTechId], [serial], [observation], [status], [operation_date], [creation_date]) VALUES (2, 1, 7, 8, 11, 2, N'Z1B1234567', N'No presento ninguna falla.', N'PROCESADO', CAST(N'2020-04-09T00:00:00.000' AS DateTime), CAST(N'2020-04-01T15:25:17.000' AS DateTime))
INSERT [dbo].[Sisg_TechnicalsOperations] ([id], [providerId], [distributorId], [finalClientId], [technicianId], [typeOperationTechId], [serial], [observation], [status], [operation_date], [creation_date]) VALUES (3, 2, 19, 52, 11, 6, N'DLA7005357', N'Se hizo Ramclear.', N'PROCESADO', CAST(N'2020-04-02T00:00:00.000' AS DateTime), CAST(N'2020-04-01T15:25:17.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_TechnicalsOperations] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Technicians] ON 

INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (1, N'V123456788', N'Duglas Méndez', N'Av. México', N'582123541160', N'rgudino11@bitsamericas.com', 1, CAST(N'2019-06-26T16:56:49.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (2, N'V145264614', N'Eugenio Dominguez', N'Av.Cl 80 con # 120, Milinos de Vientos, Bogota D.C.', N'+57-322-8491444', N'edominguez@bitsamericas.com', 1, CAST(N'2020-02-19T20:47:41.0470620' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (3, N'V888385359', N'Veronica Gomez', N'Av. Libertador, Edf. Riva, Local 3-1. Planta Baja. Los Cortijos. Caracas ? Venezuela', N'+58 212 3541161', N'vero2@tfhka.com', 1, CAST(N'2019-07-04T11:01:42.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (4, N'V205405662', N'Elena Noguera', N'Calle luna calle sol', N'0414 8542321', N'nogueragloria75@gmail.com', 1, CAST(N'2019-07-04T09:17:26.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (5, N'V223125397', N'Daniel Noguera', N'Calle luna calle sol', N'0414 8542321', N'noguera75@gmail.com', 1, CAST(N'2019-07-04T09:17:19.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (6, N'V150480775', N'Robert Bande', N'palo verde, caracas', N'04242543820', N'rgudino1@bitsamericas.com', 1, CAST(N'2019-07-02T16:34:36.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (7, N'V132533403', N'RAFAEL EDUARDO MARIN ORELLANA', N'Dtto Fed./Miranda', N' 04166121562', N'rgudino2@bitsamericas.com', 1, CAST(N'2019-07-02T09:37:00.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (8, N'V250346243', N'RICARDO JAVIER RONDON VILLAROEL', N'Portuguesa', N'0257-4115832/0416-4040597', N'rgudino3@bitsamericas.com', 1, CAST(N'2019-07-02T09:38:23.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (9, N'V252236003', N'CARLOS ADDBEL FERRER ISTURIZ', N'Dtto Fed./Miranda', N'04242320299', N'rgudino4@bitsamericas.com', 1, CAST(N'2019-07-02T09:40:05.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (10, N'V131358853', N'Nelida Salazar', N'Calle luna calle sol', N'0414 8542321', N'nsalazar@bitsamericas.com', 1, CAST(N'2019-07-04T09:31:34.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (11, N'V125973406', N'Hector Jose Jaramillo Sanchez', N'Dtto Fed./Miranda', N'0212-4009610/04143274839', N'robertjava.40@gmail.com', 0, CAST(N'2019-07-03T10:04:08.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (12, N'V241790726', N'ENMANUEL ALIEC BOSCAN OCANDO', N'Dtto Fed./Miranda', N'0414-905-4097', N'enmanuelboscan10@gmail.com', 1, CAST(N'2019-07-03T09:59:51.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (13, N'V205405667', N'Paulina Gomez', N'lecuna', N'+582514164071', N'gnoguera@bitsamericas.com', 1, CAST(N'2019-07-04T11:01:16.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (14, N'V187921739', N'JESSY ANDREINA PABON HERRERA', N'JESSY ANDREINA PABON HERRERA', N'Tachira', N'JESSY.ANDREINA1@GMAIL.COM', 1, CAST(N'2019-07-03T13:53:44.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (15, N'V231569444', N'JAVIER CANON MONTOYA', N'Tachira', N'0424256236', N'servicom.a22@gmail.com', 1, CAST(N'2019-07-03T13:55:20.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (16, N'V142642022', N'WILMER ALEXANDER VEGA RANGEL', N'Tachira', N'04165025014', N'enmanuelbo10@gmail.com', 1, CAST(N'2019-07-04T10:23:21.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (17, N'V120212644', N'MIGUEL ANGEL MACHADO LEON', N'Lara', N'0273-935-20-06', N'Tenmanuelboscan10@gmail.com', 1, CAST(N'2019-07-04T10:26:27.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (18, N'V777444222', N'Frankin Ruso', N'Calle luna calle sol', N'0414 8542327', N'pmmoyapablo@hotmail.com', 1, CAST(N'2019-07-04T14:22:11.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (19, N'V128461651', N'Manuel Rojas', N'Av Cl 78 con esquina 7', N'+57 315 8952823', N'mrojas@bitsamericas.com', 1, CAST(N'2019-07-04T18:58:41.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (20, N'V000999111', N'Pepito Romero', N'Cl 55 con Av Cali, Molinos de Vientos', N'0412 8542321', N'noguera753@gmail.com', 1, CAST(N'2019-07-05T13:19:07.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Technicians] ([id], [rif], [description], [address], [phone], [email], [enable], [creation_date]) VALUES (21, N'V123456789', N'Elvimar Moya', N'La California Norte, Av. Fco. Miranda, Torre Profesional La California, piso 9.', N'+57 332 4827785', N'elvimoya2312@gmail.com', 1, CAST(N'2019-07-06T01:41:58.6149448' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Technicians] OFF
SET IDENTITY_INSERT [dbo].[Sisg_TechniciansDistributors] ON 

INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (1, 1, 1)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (2, 1, 2)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (3, 1, 3)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (30, 2, 7)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (6, 2, 10)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (4, 2, 11)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (5, 2, 12)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (7, 2, 15)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (29, 2, 21)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (28, 3, 4)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (9, 3, 8)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (8, 3, 13)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (10, 8, 9)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (11, 8, 10)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (14, 11, 2)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (12, 11, 13)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (13, 11, 17)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (15, 12, 5)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (16, 15, 4)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (17, 18, 13)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (18, 18, 16)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (19, 20, 13)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (25, 21, 9)
INSERT [dbo].[Sisg_TechniciansDistributors] ([id], [techniciansId], [distributorsId]) VALUES (20, 21, 19)
SET IDENTITY_INSERT [dbo].[Sisg_TechniciansDistributors] OFF
SET IDENTITY_INSERT [dbo].[Sisg_TechniciansUsers] ON 

INSERT [dbo].[Sisg_TechniciansUsers] ([id], [techniciansId], [userId]) VALUES (1, 1, 12)
INSERT [dbo].[Sisg_TechniciansUsers] ([id], [techniciansId], [userId]) VALUES (2, 2, 17)
INSERT [dbo].[Sisg_TechniciansUsers] ([id], [techniciansId], [userId]) VALUES (3, 3, 3)
INSERT [dbo].[Sisg_TechniciansUsers] ([id], [techniciansId], [userId]) VALUES (8, 18, 32)
INSERT [dbo].[Sisg_TechniciansUsers] ([id], [techniciansId], [userId]) VALUES (9, 19, 33)
INSERT [dbo].[Sisg_TechniciansUsers] ([id], [techniciansId], [userId]) VALUES (10, 20, 24)
INSERT [dbo].[Sisg_TechniciansUsers] ([id], [techniciansId], [userId]) VALUES (18, 21, 35)
SET IDENTITY_INSERT [dbo].[Sisg_TechniciansUsers] OFF
SET IDENTITY_INSERT [dbo].[Sisg_TypeOperationsTechs] ON 

INSERT [dbo].[Sisg_TypeOperationsTechs] ([id], [description], [creation_date]) VALUES (1, N'ENAJENACION TECNICA', CAST(N'2020-04-15T19:09:09.000' AS DateTime))
INSERT [dbo].[Sisg_TypeOperationsTechs] ([id], [description], [creation_date]) VALUES (2, N'INSPECCIÓN ANUAL', CAST(N'2020-04-15T19:09:09.000' AS DateTime))
INSERT [dbo].[Sisg_TypeOperationsTechs] ([id], [description], [creation_date]) VALUES (3, N'REPARACIÓN', CAST(N'2020-04-15T19:09:09.000' AS DateTime))
INSERT [dbo].[Sisg_TypeOperationsTechs] ([id], [description], [creation_date]) VALUES (4, N'ADAPTACIÓN', CAST(N'2020-04-15T19:09:09.000' AS DateTime))
INSERT [dbo].[Sisg_TypeOperationsTechs] ([id], [description], [creation_date]) VALUES (5, N'SUSTITUCIÓN DE MEMORIA FISCAL', CAST(N'2020-04-15T19:09:09.000' AS DateTime))
INSERT [dbo].[Sisg_TypeOperationsTechs] ([id], [description], [creation_date]) VALUES (6, N'SUSTITUCIÓN DE MEMORIA DE AUDITORÍA', CAST(N'2020-04-15T19:09:09.000' AS DateTime))
INSERT [dbo].[Sisg_TypeOperationsTechs] ([id], [description], [creation_date]) VALUES (7, N'ALTERACIÓN Ó REMOCIÓN DE DISPOSITIVOS DE SEGURIDAD', CAST(N'2020-04-15T19:09:09.000' AS DateTime))
INSERT [dbo].[Sisg_TypeOperationsTechs] ([id], [description], [creation_date]) VALUES (8, N'REPORTE DE PÉRDIDA Ó ROBO POR PARTE DEL DISTRIBUIDOR', CAST(N'2020-04-15T19:09:09.000' AS DateTime))
INSERT [dbo].[Sisg_TypeOperationsTechs] ([id], [description], [creation_date]) VALUES (9, N'REPORTE PÉDIDA Ó ROBO POR PARTE DEL USUARIO', CAST(N'2020-04-15T19:09:09.000' AS DateTime))
INSERT [dbo].[Sisg_TypeOperationsTechs] ([id], [description], [creation_date]) VALUES (10, N'DESINCORPORACIÓN', CAST(N'2020-04-15T19:09:09.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_TypeOperationsTechs] OFF
SET IDENTITY_INSERT [dbo].[Sisg_TypesFailures] ON 

INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (0, N'POR DETERMINAR', CAST(N'2020-08-11T09:04:17.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (1, N'ERROR EN MEMORIA FISCAL', CAST(N'2020-08-11T08:45:14.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (2, N'ERROR DE MEMORIA DE AUDITORIA', CAST(N'2020-08-11T08:45:20.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (3, N'ERROR RAM CLEAR', CAST(N'2020-08-11T08:38:32.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (4, N'EQUIPO NO PRENDE', CAST(N'2020-08-11T08:38:45.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (5, N'FALLA DE COMUNICACIÓN', CAST(N'2020-08-11T08:38:55.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (6, N'ERROR  DE KIT FISCAL', CAST(N'2020-08-11T08:39:05.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (7, N'NO IMPRIME', CAST(N'2020-08-11T08:39:18.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (8, N'ERROR 114', CAST(N'2020-08-11T08:39:31.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (9, N'ERROR 140', CAST(N'2020-08-11T08:39:42.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (10, N'FALLA  EN MÓDULO FISCAL', CAST(N'2020-08-11T08:39:55.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (11, N'FALLA EN EL MECANISMO DE IMPRESIÓN', CAST(N'2020-08-11T08:40:05.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (12, N'FALLA DE SENSORES', CAST(N'2020-08-11T08:40:20.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (13, N'ERROR TAMPER', CAST(N'2020-08-11T08:40:29.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (14, N'VISOL CLIENTE NO FUNCIONA', CAST(N'2020-08-11T08:40:39.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (15, N'VISOR OPERADOR NO FUNCIONA', CAST(N'2020-08-11T08:40:49.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (16, N'FALLA DE TECLADOS', CAST(N'2020-08-11T08:40:58.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (17, N'ERROR BUS DE DATA EN CORTO', CAST(N'2020-08-11T08:41:09.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (18, N'CORTODOR AUTOMATICO NO FUNCIONA', CAST(N'2020-08-11T08:41:20.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (19, N'ERROR 78', CAST(N'2020-08-11T08:41:34.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (20, N'BALANZA NO PERMITE CALIBRAR', CAST(N'2020-08-11T08:41:43.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (21, N'BALANZA NO COMUNICA', CAST(N'2020-08-11T08:41:53.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (22, N'FALLA DE PANEL DE CONTROL', CAST(N'2020-08-11T08:42:04.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (23, N'EQUIPO BLOQUEADO', CAST(N'2020-08-11T08:42:16.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (24, N'ERROR MEMORIA DE TRABAJO', CAST(N'2020-08-11T08:42:25.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (25, N'ERROR BACKUP', CAST(N'2020-08-11T08:42:33.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (26, N'ERROR DE FECHA', CAST(N'2020-08-11T08:42:44.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (27, N'ERROR EN ACTUALIZACIÓN DE FIRMWARE', CAST(N'2020-08-11T08:43:00.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (28, N'RE-ENAJENACION', CAST(N'2020-08-11T08:43:09.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (29, N'ERROR EN HORA', CAST(N'2020-08-11T08:43:18.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (30, N'ERROR 01 FE', CAST(N'2020-08-11T08:43:27.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (31, N'ERROR 03 FE', CAST(N'2020-08-11T08:43:35.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (32, N'ERROR 76', CAST(N'2020-08-11T08:43:45.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (33, N'DETERIORO DE ETIQUETA FISCAL', CAST(N'2020-08-11T08:43:55.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (34, N'FISCALIZACIÓN', CAST(N'2020-08-11T08:44:05.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (35, N'CONFIGURACIÓN DE PARÁMETROS', CAST(N'2020-08-11T08:44:16.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (36, N'ERROR DE TRANSMISIÓN', CAST(N'2020-08-11T08:44:25.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (37, N'ERROR DE CONFIGURACIÓN DEL DISPOSITIVO', CAST(N'2020-08-11T08:44:35.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (38, N'FALLA DE SOLENOIDE', CAST(N'2020-08-11T08:47:07.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (39, N'GOLPEADA', CAST(N'2020-08-11T08:47:19.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (40, N'OTRA', CAST(N'2020-08-11T08:47:19.000' AS DateTime))
INSERT [dbo].[Sisg_TypesFailures] ([id], [description], [creation_date]) VALUES (41, N'Chasis deteriorado', CAST(N'2020-11-19T13:55:52.857' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_TypesFailures] OFF
SET IDENTITY_INSERT [dbo].[Sisg_Users] ON 

INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (1, 1, N'pmoya@bitsamericas.com', N'Bx906mEP88VPlVgslhJTWKfIxcQ=', 1, CAST(N'2019-07-05T13:23:52.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (2, 9, N'japonte@bitsamericas.com', N'vVmDqPro9Bh5WKqvCyfbOelcZA0=', 1, CAST(N'2019-06-18T15:12:11.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (3, 10, N'vero2@tfhka.com', N'iauuvhcmHk9TaC31wohRRIgxBU4=', 1, CAST(N'2019-07-01T15:55:53.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (4, 9, N'edominguez@bitsamericas.com', N'Dt1fVfnFfGL453xywxwSgQ88Fzs=', 1, CAST(N'2019-07-04T14:14:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (5, 2, N'rvalderrama@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-07-02T16:03:18.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (6, 1, N'gnoguera@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2020-02-17T18:36:37.4560430' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (8, 9, N'pmmoyapablo2@hotmail.com', N'bdfx1ZsOiFdVJUTUKQsumGaeRbc=', 1, CAST(N'2019-06-26T18:07:17.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (9, 9, N'rgudino8@bitsamericas.com', N'7MNu5M5TONXvlYZReTfvF7H6eYg=', 1, CAST(N'2019-06-28T11:23:13.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (10, 9, N'pmmoyapablo8@gmail.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-07-04T13:51:32.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (11, 9, N'rgudino16@bitsamericas.com', N'i5prf70UMR1cknVhVWtdgS1Mxvo=', 1, CAST(N'2019-07-02T09:32:28.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (12, 9, N'rgudino4@bitsamericas.com', N'7nynk5DJNzyXQE9aVx4b19JNDRI=', 1, CAST(N'2019-06-28T08:32:00.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (13, 9, N'rgudino@bitsamericas.com', N'Fq1dR4ZXa8tGmarM/ESrOzhIcOQ=', 1, CAST(N'2019-06-28T11:06:21.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (14, 9, N'rgudino15@bitsamericas.com', N'BZlD6hfe9uGV8ip317qnTve52rM=', 1, CAST(N'2019-07-01T16:36:30.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (15, 10, N'rgudino17@bitsamericas.com', N'hnVdfPcocYNVB8nbZAJiVYa6Ptg=', 1, CAST(N'2019-07-02T09:37:25.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (16, 10, N'rgudino18@bitsamericas.com', N'DOP9PUhj4GA9dxcWHS/SVz4WjGs=', 1, CAST(N'2019-07-02T09:38:52.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (17, 10, N'rgudino19@bitsamericas.com', N'XRPPEjWhEhcwip9SoZ+cjJaDoCo=', 1, CAST(N'2019-07-02T10:24:26.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (18, 9, N'rvalderrama2@bitsamericas.com', N'Bx906mEP88VPlVgslhJTWKfIxcQ=', 1, CAST(N'2019-07-02T16:02:45.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (19, 3, N'nsalazar@bitsamericas.com', N'Orx7NQtDbBA314hoVhez/txxbK8=', 1, CAST(N'2020-01-02T18:57:10.9438593' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (20, 2, N'robertjava.39@gmail.com', N'nUGN2zt6Wp9OvifKF6qalGgOcb0=', 1, CAST(N'2019-07-03T08:12:27.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (21, 1, N'ubvrobert.27@gmail.com', N'okJp9PlJ7ndwAH05KtamcoX7EbU=', 1, CAST(N'2019-07-04T13:59:36.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (22, 1, N'robertgb.27@gmail.com', N'/3k6eZE5rK/0HPiAQrss48hvtsU=', 1, CAST(N'2019-07-03T10:38:27.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (23, 10, N'robertjava.40@gmail.com', N'Muf/3Vk6WHppDYxYOZAmtgShti0=', 0, CAST(N'2019-07-03T10:04:08.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (24, 10, N'noguera75@gmail.com', N'OM166mBPk97T95lVfPYuBEqdyto=', 1, CAST(N'2019-07-03T09:59:51.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (25, 10, N'JESSY.ANDREINA1@GMAIL.COM', N'piQikpSF5rRk0sm4kcxT4gB6/ug=', 1, CAST(N'2019-07-03T13:53:44.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (26, 10, N'servicom.a22@gmail.com', N'KLOXyrkHZAdpKPpmqphy+blHedI=', 1, CAST(N'2019-07-03T13:55:20.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (27, 10, N'enmanuelbo10@gmail.com', N'Rhs4LFzSxpesRNqTgev7uiOuf5E=', 1, CAST(N'2019-07-04T10:23:22.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (28, 10, N'Tenmanuelboscan10@gmail.com', N'5/U2uUQTFlfbSnmWh0P4rUb+5kM=', 1, CAST(N'2019-07-04T10:26:27.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (29, 10, N'pmmoyapablo5@hotmail.com', N'9N3n2nkzZRTjNvkFMKqhFYj17RY=', 1, CAST(N'2019-07-04T12:08:59.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (30, 2, N'robertbande.27@gmail.com', N'cFxHH+enkFJCw6WJAj3+KnvBq5w=', 1, CAST(N'2019-07-04T14:06:06.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (31, 9, N'pmmoyapablo@gmail.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-07-05T11:34:40.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (32, 10, N'pmmoyapablo@hotmail.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-07-05T11:31:00.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (33, 10, N'mrojas@bitsamericas.com', N'o17pxvgcKmtQQ7k/tL8osEjuYgo=', 1, CAST(N'2019-07-04T18:58:41.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (34, 10, N'pmoya1@bitsamericas.com', N'TnWMhUXO7zgQrAILbxyvZheLn+k=', 1, CAST(N'2019-07-05T13:23:31.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (35, 10, N'elvimoya2312@gmail.com', N'/BrJc1mregOMPkpHyeS1izvGgE0=', 1, CAST(N'2019-07-06T01:42:02.9732596' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (43, 5, N'mramirez@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-08-14T17:37:45.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (44, 5, N'paguirre@bitsamericas.com', N'N33jVcFy8jS7QTim5jt5TxURLDk=', 1, CAST(N'2019-08-14T17:31:10.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (45, 3, N'jserrano@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-08-14T17:37:57.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (46, 4, N'rmoreno@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-08-14T17:38:09.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (47, 5, N'lmarchan@bitsamericas.com', N'wFTD2493jPkbdahV5GGeEJYJmf0=', 1, CAST(N'2019-08-14T17:35:46.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (48, 5, N'zbolivar@bitsamericas.com', N'KM9dwyj686+BSk6O21hK2lbSWzw=', 1, CAST(N'2019-08-15T09:26:20.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (49, 3, N'ycmartinez@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2020-01-02T19:51:02.9593172' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (50, 8, N'jlealz@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-08-15T09:34:57.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (51, 1, N'dmontilla@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-08-15T09:39:43.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (53, 14, N'ygil@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-08-15T09:46:46.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (54, 7, N'jcenteno@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-08-15T09:50:06.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (55, 6, N'pfanay@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2019-08-15T09:55:41.0000000' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (56, 11, N'dev54@tfhka.com', N'GIuRw59CRzG+PS/J7uedOPCtrbc=', 1, CAST(N'2019-12-27T19:17:51.0086798' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (57, 9, N'client06068@tfhka.com', N'1HBaSDneRNla9PlUSz8BO47xMfY=', 1, CAST(N'2019-12-27T20:03:43.5602249' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (58, 11, N'carloy77@tfhka.com', N'9BxJ1YvOX+VBFv1v7nxEeYCpOXs=', 1, CAST(N'2020-01-02T19:18:38.5472412' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (59, 7, N'vortega2@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2020-01-02T19:34:02.3821264' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (60, 6, N'chernandez123@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2020-01-02T19:37:51.9441314' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (61, 12, N'edaza@bitsamericas.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2020-01-02T19:42:33.2696891' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (62, 5, N'ktejada234@bitsamericas.com', N'sMtUT4zDqx9aIYKxQQd9bkS7iFM=', 1, CAST(N'2020-01-02T19:47:00.0270350' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (63, 11, N'sol76@tfhka.com', N'BTnOZWBhTMWuZAX7r3DGFBhWvKE=', 1, CAST(N'2020-01-22T16:43:58.3618058' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (64, 11, N'andrescamperos@gmail.com', N'uKeiY3ObuMV2gOrCTLxUAWiPYiM=', 1, CAST(N'2020-01-22T17:07:26.6910606' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (68, 11, N'sthec_23@tfhka.com', N'4Lii45KB9KKQFBxTjsm1BnlacSs=', 1, CAST(N'2020-01-22T21:26:10.2626381' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (79, 11, N'jenniferbordones2@gmail.com', N'ILC2lSoSs5xKjjn2QJU4P43LACo=', 1, CAST(N'2020-01-23T14:32:02.6830276' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (80, 11, N'str43@tfhka.com', N'lB6Rs6A73tJ1aCvKj9LaZvbREtg=', 1, CAST(N'2020-01-24T15:23:12.4533547' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (81, 11, N'decatech@tfhka.com', N'E0hu0epLZOR2R/CydxiSMD+R0vY=', 1, CAST(N'2020-01-24T16:39:43.5472284' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (82, 11, N'desaprueba@gmail.com', N'ms9Yp0/JlItCupccRfAUG+WvKdY=', 1, CAST(N'2020-01-27T15:37:41.2082261' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (83, 11, N'gagjsk@gmail.com', N'U0pI60+VuKbGAPRqE8H0TeXEeJM=', 1, CAST(N'2020-02-03T21:20:21.4541922' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (85, 9, N'client15584@tfhka.com', N'MSros/S0hHbeOGrJmy+tptJT7PI=', 1, CAST(N'2020-02-19T20:44:32.9407792' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (86, 15, N'sgove@tfhka.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2020-11-20T12:25:57.0812372' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (89, 11, N'gviloria@bitsamericas.com', N'ERplYRIsiksWl1QQupTDPBCcdcA=', 1, CAST(N'2020-12-28T14:48:49.5823910' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (90, 11, N'pepita43@tfhka.com', N'UDKnMzbwe1QGfrbJn+uHhwdyv/E=', 1, CAST(N'2021-01-07T14:20:59.0275792' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (91, 11, N'saa23@tfhka.com', N'Q3xXe1VnWaOMPh9BDUjzIoO6wWs=', 1, CAST(N'2021-01-07T15:40:53.5347061' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (93, 11, N'pablin23@tfhka.com', N'EnhK7KEmOp+72Fc8yc0BWFiMRXQ=', 1, CAST(N'2021-01-07T15:58:57.4919267' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (94, 11, N'isac_23@tfhka.com', N'5bD3tar+Eke6gtePwlZQl/OPLg0=', 1, CAST(N'2021-01-12T10:53:52.4916144' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (96, 11, N'ppaol76@tfhka.com', N'25rFsboKIAU60KrWwUyXa7WCHbk=', 1, CAST(N'2021-01-13T19:50:44.5965504' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (97, 11, N'a2consulting@tfhka.com', N'zuXIsN7z3CbcGus1bpCEtA7UX1k=', 1, CAST(N'2021-01-15T15:40:22.2675689' AS DateTime2))
INSERT [dbo].[Sisg_Users] ([id], [rolId], [username], [password], [enable], [creation_date]) VALUES (98, 11, N'enter54@tfhka.com', N'QRsRouAv0Es8+do+/zjRIkfCu6Q=', 1, CAST(N'2021-01-20T15:34:12.3729180' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Sisg_Users] OFF
SET IDENTITY_INSERT [dbo].[Sisg_WorkshopBinnacles] ON 

INSERT [dbo].[Sisg_WorkshopBinnacles] ([id], [orderId], [statusId], [userId], [creation_date], [observation]) VALUES (1, 2, 2, 1, CAST(N'2020-11-20T12:29:49.480' AS DateTime), N'NA')
INSERT [dbo].[Sisg_WorkshopBinnacles] ([id], [orderId], [statusId], [userId], [creation_date], [observation]) VALUES (3, 2, 3, 1, CAST(N'2020-11-20T13:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sisg_WorkshopBinnacles] ([id], [orderId], [statusId], [userId], [creation_date], [observation]) VALUES (8, 2, 3, 1, CAST(N'2020-11-20T15:00:00.000' AS DateTime), N'Cambio tecnico')
INSERT [dbo].[Sisg_WorkshopBinnacles] ([id], [orderId], [statusId], [userId], [creation_date], [observation]) VALUES (9, 4, 2, 1, CAST(N'2020-11-24T15:03:07.693' AS DateTime), N'')
INSERT [dbo].[Sisg_WorkshopBinnacles] ([id], [orderId], [statusId], [userId], [creation_date], [observation]) VALUES (10, 5, 2, 1, CAST(N'2020-11-26T13:36:39.530' AS DateTime), N'')
INSERT [dbo].[Sisg_WorkshopBinnacles] ([id], [orderId], [statusId], [userId], [creation_date], [observation]) VALUES (11, 6, 2, 1, CAST(N'2020-11-30T15:57:57.227' AS DateTime), N'Trajo bolsa')
SET IDENTITY_INSERT [dbo].[Sisg_WorkshopBinnacles] OFF
SET IDENTITY_INSERT [dbo].[Sisg_WorkshopOrders] ON 

INSERT [dbo].[Sisg_WorkshopOrders] ([id], [numerOrder], [kindEquipment], [equipment], [serial], [warrantyId], [distributorId], [typeFailurId], [stateOrderId], [deliveryOrderId], [employeeId], [firmwareVersion], [deliverDate], [receptionDate], [alienationDate], [expirationDate], [address], [contact], [phone], [insertionOrigin], [workDone], [customerReview], [observationTechnical], [extraObservation], [creation_date]) VALUES (1, N'00001', 1, 1, N'Z1B8100007', 1, 1, 0, 5, 0, 11, NULL, CAST(N'2020-09-30T00:00:00.000' AS DateTime), CAST(N'2020-10-03T00:00:00.000' AS DateTime), CAST(N'1753-01-01T00:00:00.000' AS DateTime), CAST(N'2020-10-15T00:00:00.000' AS DateTime), N'Calle luna', N'Paola Mendez', N'12123133', 0, NULL, N'Ram Clear', NULL, N'No trajo na', CAST(N'2020-09-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_WorkshopOrders] ([id], [numerOrder], [kindEquipment], [equipment], [serial], [warrantyId], [distributorId], [typeFailurId], [stateOrderId], [deliveryOrderId], [employeeId], [firmwareVersion], [deliverDate], [receptionDate], [alienationDate], [expirationDate], [address], [contact], [phone], [insertionOrigin], [workDone], [customerReview], [observationTechnical], [extraObservation], [creation_date]) VALUES (2, N'00002', 1, 1, N'Z1B1234567', 0, 9, 0, 2, 1, 10, NULL, CAST(N'2020-12-05T12:29:46.817' AS DateTime), CAST(N'2020-11-20T12:29:46.817' AS DateTime), CAST(N'2020-11-20T11:57:55.143' AS DateTime), CAST(N'2020-12-05T12:29:46.817' AS DateTime), N'Callejon Gutierrez', N'Pedro Perez', N'04148491448', 0, NULL, N'Limpieza', N'No furula', N'NA', CAST(N'2020-11-20T12:29:46.817' AS DateTime))
INSERT [dbo].[Sisg_WorkshopOrders] ([id], [numerOrder], [kindEquipment], [equipment], [serial], [warrantyId], [distributorId], [typeFailurId], [stateOrderId], [deliveryOrderId], [employeeId], [firmwareVersion], [deliverDate], [receptionDate], [alienationDate], [expirationDate], [address], [contact], [phone], [insertionOrigin], [workDone], [customerReview], [observationTechnical], [extraObservation], [creation_date]) VALUES (3, N'00003', 1, 1, N'Z1B8100001', 0, 1, 0, 3, 0, 11, NULL, CAST(N'2020-11-25T15:00:00.000' AS DateTime), CAST(N'2020-11-24T15:00:00.000' AS DateTime), CAST(N'1753-01-01T00:00:00.000' AS DateTime), CAST(N'2020-12-25T15:00:00.000' AS DateTime), N'Calle luna', N'Paola Mendez', N'12123133', 0, NULL, N'Reseet', NULL, N'No trajo un co', CAST(N'2020-09-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Sisg_WorkshopOrders] ([id], [numerOrder], [kindEquipment], [equipment], [serial], [warrantyId], [distributorId], [typeFailurId], [stateOrderId], [deliveryOrderId], [employeeId], [firmwareVersion], [deliverDate], [receptionDate], [alienationDate], [expirationDate], [address], [contact], [phone], [insertionOrigin], [workDone], [customerReview], [observationTechnical], [extraObservation], [creation_date]) VALUES (4, N'00004', 1, 9, N'DLA7000001', 0, 4, 0, 1, 2, 10, NULL, CAST(N'2020-12-09T15:03:06.927' AS DateTime), CAST(N'2020-11-24T15:03:06.927' AS DateTime), CAST(N'1753-01-01T00:00:00.000' AS DateTime), CAST(N'2020-12-09T15:03:06.927' AS DateTime), N'Callejon Gutierrez', N'Maria Morena', N'04148491448', 0, NULL, N'NA', N'No forola', NULL, CAST(N'2020-11-24T15:03:06.927' AS DateTime))
INSERT [dbo].[Sisg_WorkshopOrders] ([id], [numerOrder], [kindEquipment], [equipment], [serial], [warrantyId], [distributorId], [typeFailurId], [stateOrderId], [deliveryOrderId], [employeeId], [firmwareVersion], [deliverDate], [receptionDate], [alienationDate], [expirationDate], [address], [contact], [phone], [insertionOrigin], [workDone], [customerReview], [observationTechnical], [extraObservation], [creation_date]) VALUES (5, N'00005', 1, 9, N'DLA7000002', 0, 4, 0, 2, 3, 10, NULL, CAST(N'2020-12-11T13:36:37.107' AS DateTime), CAST(N'2020-11-26T13:36:37.107' AS DateTime), CAST(N'1753-01-01T00:00:00.000' AS DateTime), CAST(N'2020-12-11T13:36:37.107' AS DateTime), N'Callejon Gutierrez', N'Pedro Perez', N'04148491448', 0, NULL, N'NA', N'Nananana', NULL, CAST(N'2020-11-26T13:36:37.107' AS DateTime))
INSERT [dbo].[Sisg_WorkshopOrders] ([id], [numerOrder], [kindEquipment], [equipment], [serial], [warrantyId], [distributorId], [typeFailurId], [stateOrderId], [deliveryOrderId], [employeeId], [firmwareVersion], [deliverDate], [receptionDate], [alienationDate], [expirationDate], [address], [contact], [phone], [insertionOrigin], [workDone], [customerReview], [observationTechnical], [extraObservation], [creation_date]) VALUES (6, N'00006', 1, 4, N'Z1D9999999', 0, 9, 0, 1, 4, 10, NULL, CAST(N'2020-12-15T15:57:54.267' AS DateTime), CAST(N'2020-11-30T15:57:54.267' AS DateTime), CAST(N'1753-01-01T00:00:00.000' AS DateTime), CAST(N'2020-12-15T15:57:54.267' AS DateTime), N'Callejon Gutierrez', N'Pedro Perez', N'04128491448', 0, NULL, N'Reset', N'No furrulata', N'Trajo bolsa', CAST(N'2020-11-30T15:57:54.267' AS DateTime))
INSERT [dbo].[Sisg_WorkshopOrders] ([id], [numerOrder], [kindEquipment], [equipment], [serial], [warrantyId], [distributorId], [typeFailurId], [stateOrderId], [deliveryOrderId], [employeeId], [firmwareVersion], [deliverDate], [receptionDate], [alienationDate], [expirationDate], [address], [contact], [phone], [insertionOrigin], [workDone], [customerReview], [observationTechnical], [extraObservation], [creation_date]) VALUES (7, N'00007', 1, 1, N'Z1B8100008', 0, 1, 0, 3, 0, 11, NULL, CAST(N'2020-09-30T00:00:00.000' AS DateTime), CAST(N'2020-10-03T00:00:00.000' AS DateTime), CAST(N'1753-01-01T00:00:00.000' AS DateTime), CAST(N'2020-10-15T00:00:00.000' AS DateTime), N'Calle luna calle sol', N'Paola Mendez', N'12123133', 0, NULL, N'Ram Clear y Reset', NULL, N'No trajo un Co', CAST(N'2020-11-29T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sisg_WorkshopOrders] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Accename]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Accessories] ADD  CONSTRAINT [Uni_Accename] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Alienations]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Alienations] ADD  CONSTRAINT [Uni_Alienations] UNIQUE NONCLUSTERED 
(
	[serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Catname]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Categories] ADD  CONSTRAINT [Uni_Catname] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uni_DevelopersClientsIdUserId]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_DevelopersClientsUsers] ADD  CONSTRAINT [Uni_DevelopersClientsIdUserId] UNIQUE NONCLUSTERED 
(
	[developersclientsId] ASC,
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Rif33]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Distributors] ADD  CONSTRAINT [Uni_Rif33] UNIQUE NONCLUSTERED 
(
	[rif] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uni_ProvDistrId]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_DistributorsProviders] ADD  CONSTRAINT [Uni_ProvDistrId] UNIQUE NONCLUSTERED 
(
	[ProviderId] ASC,
	[DistributorsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uni_UserIdDistrId]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_DistributorsUsers] ADD  CONSTRAINT [Uni_UserIdDistrId] UNIQUE NONCLUSTERED 
(
	[DistributorsId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Sisg_EmployeesRifEmailCode]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Employees] ADD  CONSTRAINT [Uni_Sisg_EmployeesRifEmailCode] UNIQUE NONCLUSTERED 
(
	[rif] ASC,
	[code] ASC,
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uni_Sisg_EmployeesUsersIdUserId]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_EmployeesUsers] ADD  CONSTRAINT [Uni_Sisg_EmployeesUsersIdUserId] UNIQUE NONCLUSTERED 
(
	[employeeId] ASC,
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_FileSectiondescription]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_FileSection] ADD  CONSTRAINT [Uni_FileSectiondescription] UNIQUE NONCLUSTERED 
(
	[description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Descriptionname]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_FileStatus] ADD  CONSTRAINT [Uni_Descriptionname] UNIQUE NONCLUSTERED 
(
	[description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_FinalsClientsRif]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_FinalsClients] ADD  CONSTRAINT [Uni_FinalsClientsRif] UNIQUE NONCLUSTERED 
(
	[rif] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uni_FinalsClientsUsersIdUserId]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_FinalsClientsUsers] ADD  CONSTRAINT [Uni_FinalsClientsUsersIdUserId] UNIQUE NONCLUSTERED 
(
	[finalsclientsId] ASC,
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Idiomdescription]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Idiom] ADD  CONSTRAINT [Uni_Idiomdescription] UNIQUE NONCLUSTERED 
(
	[description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_File]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_InfoFile] ADD  CONSTRAINT [Uni_File] UNIQUE NONCLUSTERED 
(
	[description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Markname]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Marks] ADD  CONSTRAINT [Uni_Markname] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Modelname]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Models] ADD  CONSTRAINT [Uni_Modelname] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_PrefixAlfn]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Prefixes] ADD  CONSTRAINT [Uni_PrefixAlfn] UNIQUE NONCLUSTERED 
(
	[initAlphaNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_PrefixNum]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Prefixes] ADD  CONSTRAINT [Uni_PrefixNum] UNIQUE NONCLUSTERED 
(
	[initCorrelative] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uni_Products]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Products] ADD  CONSTRAINT [Uni_Products] UNIQUE NONCLUSTERED 
(
	[modelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Products2]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Products] ADD  CONSTRAINT [Uni_Products2] UNIQUE NONCLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uni_ProductsAccessories]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_ProductsAccessories] ADD  CONSTRAINT [Uni_ProductsAccessories] UNIQUE NONCLUSTERED 
(
	[productId] ASC,
	[accessoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uni_ProductsReplacements]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_ProductsReplacements] ADD  CONSTRAINT [Uni_ProductsReplacements] UNIQUE NONCLUSTERED 
(
	[productId] ASC,
	[replacementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Rif32]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Providers] ADD  CONSTRAINT [Uni_Rif32] UNIQUE NONCLUSTERED 
(
	[rif] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_ReplacementsOpetechs]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_ReplacementsOpetechs] ADD  CONSTRAINT [Uni_ReplacementsOpetechs] UNIQUE NONCLUSTERED 
(
	[serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uni_RolIdMenuId]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Rolesmenus] ADD  CONSTRAINT [Uni_RolIdMenuId] UNIQUE NONCLUSTERED 
(
	[RolId] ASC,
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Serial_Product]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_SerialsProducts] ADD  CONSTRAINT [Uni_Serial_Product] UNIQUE NONCLUSTERED 
(
	[serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Serial_Replacements]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_SerialsReplacements] ADD  CONSTRAINT [Uni_Serial_Replacements] UNIQUE NONCLUSTERED 
(
	[serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Rif]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Technicians] ADD  CONSTRAINT [Uni_Rif] UNIQUE NONCLUSTERED 
(
	[rif] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Rif22]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Technicians] ADD  CONSTRAINT [Uni_Rif22] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uni_TechIdDistrId]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_TechniciansDistributors] ADD  CONSTRAINT [Uni_TechIdDistrId] UNIQUE NONCLUSTERED 
(
	[techniciansId] ASC,
	[distributorsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Uni_TechIdUserId]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_TechniciansUsers] ADD  CONSTRAINT [Uni_TechIdUserId] UNIQUE NONCLUSTERED 
(
	[techniciansId] ASC,
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_TypeFiledescription]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_TypeFile] ADD  CONSTRAINT [Uni_TypeFiledescription] UNIQUE NONCLUSTERED 
(
	[description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_Username]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_Users] ADD  CONSTRAINT [Uni_Username] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Uni_WorkshopOrders]    Script Date: 25/02/2021 5:02:25 p. m. ******/
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  CONSTRAINT [Uni_WorkshopOrders] UNIQUE NONCLUSTERED 
(
	[numerOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Sisg_Alienations] ADD  DEFAULT (NULL) FOR [observations]
GO
ALTER TABLE [dbo].[Sisg_CasesProducts] ADD  DEFAULT (NULL) FOR [caseSoftwareHouseId]
GO
ALTER TABLE [dbo].[Sisg_CasesProducts] ADD  DEFAULT (NULL) FOR [productId]
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses] ADD  DEFAULT (NULL) FOR [contactShape]
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses] ADD  DEFAULT (NULL) FOR [page]
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses] ADD  DEFAULT (NULL) FOR [otherLanguage]
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses] ADD  DEFAULT (NULL) FOR [employeeId]
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses] ADD  DEFAULT (NULL) FOR [dateRegister]
GO
ALTER TABLE [dbo].[Sisg_DeliveryOrder] ADD  DEFAULT (NULL) FOR [liableId]
GO
ALTER TABLE [dbo].[Sisg_DeliveryOrder] ADD  DEFAULT (NULL) FOR [liableName]
GO
ALTER TABLE [dbo].[Sisg_DeliveryOrder] ADD  DEFAULT (NULL) FOR [liablePhone]
GO
ALTER TABLE [dbo].[Sisg_DeliveryOrder] ADD  DEFAULT (NULL) FOR [guideNumber]
GO
ALTER TABLE [dbo].[Sisg_DeliveryOrder] ADD  DEFAULT (NULL) FOR [companyName]
GO
ALTER TABLE [dbo].[Sisg_DeliveryOrder] ADD  DEFAULT (NULL) FOR [address]
GO
ALTER TABLE [dbo].[Sisg_DeliveryOrder] ADD  DEFAULT (NULL) FOR [observation]
GO
ALTER TABLE [dbo].[Sisg_DevelopersClients] ADD  DEFAULT (NULL) FOR [creation_date]
GO
ALTER TABLE [dbo].[Sisg_Employees] ADD  DEFAULT (NULL) FOR [creation_date]
GO
ALTER TABLE [dbo].[Sisg_FinalsClients] ADD  DEFAULT (NULL) FOR [name]
GO
ALTER TABLE [dbo].[Sisg_FinalsClients] ADD  DEFAULT (NULL) FOR [lastName]
GO
ALTER TABLE [dbo].[Sisg_FinalsClients] ADD  DEFAULT (NULL) FOR [phone]
GO
ALTER TABLE [dbo].[Sisg_FinalsClients] ADD  DEFAULT (NULL) FOR [email]
GO
ALTER TABLE [dbo].[Sisg_FinalsClients] ADD  DEFAULT (NULL) FOR [fiscalAddress]
GO
ALTER TABLE [dbo].[Sisg_FinalsClients] ADD  DEFAULT (NULL) FOR [creation_date]
GO
ALTER TABLE [dbo].[Sisg_Products] ADD  DEFAULT ((0)) FOR [prefixId]
GO
ALTER TABLE [dbo].[Sisg_Products] ADD  DEFAULT (NULL) FOR [description]
GO
ALTER TABLE [dbo].[Sisg_Products] ADD  DEFAULT (NULL) FOR [imageUrl]
GO
ALTER TABLE [dbo].[Sisg_Replacements] ADD  DEFAULT ((0)) FOR [prefixId]
GO
ALTER TABLE [dbo].[Sisg_Replacements] ADD  DEFAULT (NULL) FOR [description]
GO
ALTER TABLE [dbo].[Sisg_Replacements] ADD  DEFAULT (NULL) FOR [code]
GO
ALTER TABLE [dbo].[Sisg_Replacements] ADD  DEFAULT (NULL) FOR [imageUrl]
GO
ALTER TABLE [dbo].[Sisg_SerialsProducts] ADD  DEFAULT (NULL) FOR [observations]
GO
ALTER TABLE [dbo].[Sisg_SerialsReplacements] ADD  DEFAULT (NULL) FOR [observations]
GO
ALTER TABLE [dbo].[Sisg_TechnicalsOperations] ADD  DEFAULT (NULL) FOR [observation]
GO
ALTER TABLE [dbo].[Sisg_WorkshopBinnacles] ADD  DEFAULT (NULL) FOR [observation]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  DEFAULT (NULL) FOR [warrantyId]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  DEFAULT (NULL) FOR [deliveryOrderId]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  DEFAULT (NULL) FOR [firmwareVersion]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  DEFAULT (NULL) FOR [deliverDate]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  DEFAULT (NULL) FOR [receptionDate]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  DEFAULT (NULL) FOR [alienationDate]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  DEFAULT (NULL) FOR [expirationDate]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  DEFAULT (NULL) FOR [phone]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  DEFAULT (NULL) FOR [workDone]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  DEFAULT (NULL) FOR [observationTechnical]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] ADD  DEFAULT (NULL) FOR [extraObservation]
GO
ALTER TABLE [dbo].[Sisg_AccessoriesOrders]  WITH CHECK ADD  CONSTRAINT [Sisg_AccessoriesOrders_ibfk_1] FOREIGN KEY([orderId])
REFERENCES [dbo].[Sisg_WorkshopOrders] ([id])
GO
ALTER TABLE [dbo].[Sisg_AccessoriesOrders] CHECK CONSTRAINT [Sisg_AccessoriesOrders_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_AccessoriesOrders]  WITH CHECK ADD  CONSTRAINT [Sisg_AccessoriesOrders_ibfk_2] FOREIGN KEY([accesoryId])
REFERENCES [dbo].[Sisg_Accessories] ([id])
GO
ALTER TABLE [dbo].[Sisg_AccessoriesOrders] CHECK CONSTRAINT [Sisg_AccessoriesOrders_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_Activities]  WITH CHECK ADD  CONSTRAINT [Sisg_Activities_ibfk_1] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Sisg_Employees] ([id])
GO
ALTER TABLE [dbo].[Sisg_Activities] CHECK CONSTRAINT [Sisg_Activities_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_Alienations]  WITH CHECK ADD  CONSTRAINT [Sisg_Alienations_ibfk_1] FOREIGN KEY([distributorId])
REFERENCES [dbo].[Sisg_Distributors] ([id])
GO
ALTER TABLE [dbo].[Sisg_Alienations] CHECK CONSTRAINT [Sisg_Alienations_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_Alienations]  WITH CHECK ADD  CONSTRAINT [Sisg_Alienations_ibfk_2] FOREIGN KEY([providerId])
REFERENCES [dbo].[Sisg_Providers] ([id])
GO
ALTER TABLE [dbo].[Sisg_Alienations] CHECK CONSTRAINT [Sisg_Alienations_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_Alienations]  WITH CHECK ADD  CONSTRAINT [Sisg_Alienations_ibfk_3] FOREIGN KEY([finalclientId])
REFERENCES [dbo].[Sisg_FinalsClients] ([id])
GO
ALTER TABLE [dbo].[Sisg_Alienations] CHECK CONSTRAINT [Sisg_Alienations_ibfk_3]
GO
ALTER TABLE [dbo].[Sisg_CasesProducts]  WITH CHECK ADD  CONSTRAINT [Sisg_CasesProducts_ibfk_1] FOREIGN KEY([caseSoftwareHouseId])
REFERENCES [dbo].[Sisg_CasesSoftwareHouses] ([id])
GO
ALTER TABLE [dbo].[Sisg_CasesProducts] CHECK CONSTRAINT [Sisg_CasesProducts_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_CasesProducts]  WITH CHECK ADD  CONSTRAINT [Sisg_CasesProducts_ibfk_2] FOREIGN KEY([productId])
REFERENCES [dbo].[Sisg_Products] ([id])
GO
ALTER TABLE [dbo].[Sisg_CasesProducts] CHECK CONSTRAINT [Sisg_CasesProducts_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses]  WITH CHECK ADD  CONSTRAINT [Sisg_CasesSoftwareHouses_fk_1] FOREIGN KEY([developersClientsId])
REFERENCES [dbo].[Sisg_DevelopersClients] ([id])
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses] CHECK CONSTRAINT [Sisg_CasesSoftwareHouses_fk_1]
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses]  WITH CHECK ADD  CONSTRAINT [Sisg_CasesSoftwareHouses_fk_2] FOREIGN KEY([systemOperId])
REFERENCES [dbo].[Sisg_SystemOpers] ([id])
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses] CHECK CONSTRAINT [Sisg_CasesSoftwareHouses_fk_2]
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses]  WITH CHECK ADD  CONSTRAINT [Sisg_CasesSoftwareHouses_fk_3] FOREIGN KEY([statusId])
REFERENCES [dbo].[Sisg_StatusIntegrations] ([id])
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses] CHECK CONSTRAINT [Sisg_CasesSoftwareHouses_fk_3]
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses]  WITH CHECK ADD  CONSTRAINT [Sisg_CasesSoftwareHouses_fk_4] FOREIGN KEY([programLanguageId])
REFERENCES [dbo].[Sisg_ProgramLenguages] ([id])
GO
ALTER TABLE [dbo].[Sisg_CasesSoftwareHouses] CHECK CONSTRAINT [Sisg_CasesSoftwareHouses_fk_4]
GO
ALTER TABLE [dbo].[Sisg_Chargues]  WITH CHECK ADD  CONSTRAINT [sisg_chargues_ibfk_1] FOREIGN KEY([rolId])
REFERENCES [dbo].[Sisg_Roles] ([id])
GO
ALTER TABLE [dbo].[Sisg_Chargues] CHECK CONSTRAINT [sisg_chargues_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_DevelopersClientsUsers]  WITH CHECK ADD  CONSTRAINT [sisg_developersclientsusers_ibfk_1] FOREIGN KEY([developersclientsId])
REFERENCES [dbo].[Sisg_DevelopersClients] ([id])
GO
ALTER TABLE [dbo].[Sisg_DevelopersClientsUsers] CHECK CONSTRAINT [sisg_developersclientsusers_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_DevelopersClientsUsers]  WITH CHECK ADD  CONSTRAINT [sisg_developersclientsusers_ibfk_2] FOREIGN KEY([userId])
REFERENCES [dbo].[Sisg_Users] ([id])
GO
ALTER TABLE [dbo].[Sisg_DevelopersClientsUsers] CHECK CONSTRAINT [sisg_developersclientsusers_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_DistributorsProviders]  WITH CHECK ADD  CONSTRAINT [sisg_distributorsproviders_ibfk_1] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Sisg_Providers] ([id])
GO
ALTER TABLE [dbo].[Sisg_DistributorsProviders] CHECK CONSTRAINT [sisg_distributorsproviders_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_DistributorsProviders]  WITH CHECK ADD  CONSTRAINT [sisg_distributorsproviders_ibfk_2] FOREIGN KEY([DistributorsId])
REFERENCES [dbo].[Sisg_Distributors] ([id])
GO
ALTER TABLE [dbo].[Sisg_DistributorsProviders] CHECK CONSTRAINT [sisg_distributorsproviders_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_DistributorsUsers]  WITH CHECK ADD  CONSTRAINT [sisg_distributorsusers_ibfk_1] FOREIGN KEY([DistributorsId])
REFERENCES [dbo].[Sisg_Distributors] ([id])
GO
ALTER TABLE [dbo].[Sisg_DistributorsUsers] CHECK CONSTRAINT [sisg_distributorsusers_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_DistributorsUsers]  WITH CHECK ADD  CONSTRAINT [sisg_distributorsusers_ibfk_2] FOREIGN KEY([UserId])
REFERENCES [dbo].[Sisg_Users] ([id])
GO
ALTER TABLE [dbo].[Sisg_DistributorsUsers] CHECK CONSTRAINT [sisg_distributorsusers_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_Employees]  WITH CHECK ADD  CONSTRAINT [sisg_employees_ibfk_2] FOREIGN KEY([departamentId])
REFERENCES [dbo].[Sisg_Departaments] ([id])
GO
ALTER TABLE [dbo].[Sisg_Employees] CHECK CONSTRAINT [sisg_employees_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_Employees]  WITH CHECK ADD  CONSTRAINT [sisg_employees_ibfk_3] FOREIGN KEY([chargueId])
REFERENCES [dbo].[Sisg_Chargues] ([id])
GO
ALTER TABLE [dbo].[Sisg_Employees] CHECK CONSTRAINT [sisg_employees_ibfk_3]
GO
ALTER TABLE [dbo].[Sisg_EmployeesUsers]  WITH CHECK ADD  CONSTRAINT [sisg_employeesusers_ibfk_1] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Sisg_Employees] ([id])
GO
ALTER TABLE [dbo].[Sisg_EmployeesUsers] CHECK CONSTRAINT [sisg_employeesusers_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_EmployeesUsers]  WITH CHECK ADD  CONSTRAINT [sisg_employeesusers_ibfk_2] FOREIGN KEY([userId])
REFERENCES [dbo].[Sisg_Users] ([id])
GO
ALTER TABLE [dbo].[Sisg_EmployeesUsers] CHECK CONSTRAINT [sisg_employeesusers_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_File_ProgramLenguages]  WITH CHECK ADD  CONSTRAINT [Sisg_File_ProgramLenguages_fk_1] FOREIGN KEY([programLenguagesId])
REFERENCES [dbo].[Sisg_ProgramLenguages] ([id])
GO
ALTER TABLE [dbo].[Sisg_File_ProgramLenguages] CHECK CONSTRAINT [Sisg_File_ProgramLenguages_fk_1]
GO
ALTER TABLE [dbo].[Sisg_File_SystemOpers]  WITH CHECK ADD  CONSTRAINT [Sisg_File_SystemOpers_fk_1] FOREIGN KEY([systemOpersId])
REFERENCES [dbo].[Sisg_SystemOpers] ([id])
GO
ALTER TABLE [dbo].[Sisg_File_SystemOpers] CHECK CONSTRAINT [Sisg_File_SystemOpers_fk_1]
GO
ALTER TABLE [dbo].[Sisg_FinalsClientsUsers]  WITH CHECK ADD  CONSTRAINT [Sisg_FinalsClientsUsers_ibfk_1] FOREIGN KEY([finalsclientsId])
REFERENCES [dbo].[Sisg_FinalsClients] ([id])
GO
ALTER TABLE [dbo].[Sisg_FinalsClientsUsers] CHECK CONSTRAINT [Sisg_FinalsClientsUsers_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_FinalsClientsUsers]  WITH CHECK ADD  CONSTRAINT [Sisg_FinalsClientsUsers_ibfk_2] FOREIGN KEY([userId])
REFERENCES [dbo].[Sisg_Users] ([id])
GO
ALTER TABLE [dbo].[Sisg_FinalsClientsUsers] CHECK CONSTRAINT [Sisg_FinalsClientsUsers_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_FiscalsOperations]  WITH CHECK ADD  CONSTRAINT [Sisg_FiscalsOperations_ibfk_1] FOREIGN KEY([distributorId])
REFERENCES [dbo].[Sisg_Distributors] ([id])
GO
ALTER TABLE [dbo].[Sisg_FiscalsOperations] CHECK CONSTRAINT [Sisg_FiscalsOperations_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_FiscalsOperations]  WITH CHECK ADD  CONSTRAINT [Sisg_FiscalsOperations_ibfk_2] FOREIGN KEY([providerId])
REFERENCES [dbo].[Sisg_Providers] ([id])
GO
ALTER TABLE [dbo].[Sisg_FiscalsOperations] CHECK CONSTRAINT [Sisg_FiscalsOperations_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_FiscalsOperations]  WITH CHECK ADD  CONSTRAINT [Sisg_FiscalsOperations_ibfk_3] FOREIGN KEY([technicianId])
REFERENCES [dbo].[Sisg_Technicians] ([id])
GO
ALTER TABLE [dbo].[Sisg_FiscalsOperations] CHECK CONSTRAINT [Sisg_FiscalsOperations_ibfk_3]
GO
ALTER TABLE [dbo].[Sisg_FiscalsOperations]  WITH CHECK ADD  CONSTRAINT [Sisg_FiscalsOperations_ibfk_4] FOREIGN KEY([finalClientId])
REFERENCES [dbo].[Sisg_FinalsClients] ([id])
GO
ALTER TABLE [dbo].[Sisg_FiscalsOperations] CHECK CONSTRAINT [Sisg_FiscalsOperations_ibfk_4]
GO
ALTER TABLE [dbo].[Sisg_InfoFile]  WITH CHECK ADD  CONSTRAINT [Sisg_File_fk_1] FOREIGN KEY([userId])
REFERENCES [dbo].[Sisg_DevelopersClients] ([id])
GO
ALTER TABLE [dbo].[Sisg_InfoFile] CHECK CONSTRAINT [Sisg_File_fk_1]
GO
ALTER TABLE [dbo].[Sisg_InfoFile]  WITH CHECK ADD  CONSTRAINT [Sisg_File_fk_2] FOREIGN KEY([idiomId])
REFERENCES [dbo].[Sisg_Idiom] ([id])
GO
ALTER TABLE [dbo].[Sisg_InfoFile] CHECK CONSTRAINT [Sisg_File_fk_2]
GO
ALTER TABLE [dbo].[Sisg_InfoFile]  WITH CHECK ADD  CONSTRAINT [Sisg_File_fk_3] FOREIGN KEY([typefileId])
REFERENCES [dbo].[Sisg_TypeFile] ([id])
GO
ALTER TABLE [dbo].[Sisg_InfoFile] CHECK CONSTRAINT [Sisg_File_fk_3]
GO
ALTER TABLE [dbo].[Sisg_InfoFile]  WITH CHECK ADD  CONSTRAINT [Sisg_File_fk_4] FOREIGN KEY([productId])
REFERENCES [dbo].[Sisg_Products] ([id])
GO
ALTER TABLE [dbo].[Sisg_InfoFile] CHECK CONSTRAINT [Sisg_File_fk_4]
GO
ALTER TABLE [dbo].[Sisg_InfoFile]  WITH CHECK ADD  CONSTRAINT [Sisg_File_fk_5] FOREIGN KEY([markId])
REFERENCES [dbo].[Sisg_Marks] ([id])
GO
ALTER TABLE [dbo].[Sisg_InfoFile] CHECK CONSTRAINT [Sisg_File_fk_5]
GO
ALTER TABLE [dbo].[Sisg_InfoFile]  WITH CHECK ADD  CONSTRAINT [Sisg_File_fk_6] FOREIGN KEY([file_SystemOperId])
REFERENCES [dbo].[Sisg_File_SystemOpers] ([id])
GO
ALTER TABLE [dbo].[Sisg_InfoFile] CHECK CONSTRAINT [Sisg_File_fk_6]
GO
ALTER TABLE [dbo].[Sisg_InfoFile]  WITH CHECK ADD  CONSTRAINT [Sisg_File_fk_7] FOREIGN KEY([file_ProgramLenguageId])
REFERENCES [dbo].[Sisg_File_ProgramLenguages] ([id])
GO
ALTER TABLE [dbo].[Sisg_InfoFile] CHECK CONSTRAINT [Sisg_File_fk_7]
GO
ALTER TABLE [dbo].[Sisg_InfoFile]  WITH CHECK ADD  CONSTRAINT [Sisg_File_fk_8] FOREIGN KEY([fileSectionId])
REFERENCES [dbo].[Sisg_FileSection] ([id])
GO
ALTER TABLE [dbo].[Sisg_InfoFile] CHECK CONSTRAINT [Sisg_File_fk_8]
GO
ALTER TABLE [dbo].[Sisg_InfoFile]  WITH CHECK ADD  CONSTRAINT [Sisg_File_fk_9] FOREIGN KEY([fileStatusId])
REFERENCES [dbo].[Sisg_FileStatus] ([id])
GO
ALTER TABLE [dbo].[Sisg_InfoFile] CHECK CONSTRAINT [Sisg_File_fk_9]
GO
ALTER TABLE [dbo].[Sisg_Models]  WITH CHECK ADD  CONSTRAINT [sisg_models_ibfk_11] FOREIGN KEY([markId])
REFERENCES [dbo].[Sisg_Marks] ([id])
GO
ALTER TABLE [dbo].[Sisg_Models] CHECK CONSTRAINT [sisg_models_ibfk_11]
GO
ALTER TABLE [dbo].[Sisg_PhotographsOrder]  WITH CHECK ADD  CONSTRAINT [Sisg_PhotographsOrder_ibfk_1] FOREIGN KEY([orderId])
REFERENCES [dbo].[Sisg_WorkshopOrders] ([id])
GO
ALTER TABLE [dbo].[Sisg_PhotographsOrder] CHECK CONSTRAINT [Sisg_PhotographsOrder_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_Products]  WITH CHECK ADD  CONSTRAINT [sisg_products_ibfk_1] FOREIGN KEY([modelId])
REFERENCES [dbo].[Sisg_Models] ([id])
GO
ALTER TABLE [dbo].[Sisg_Products] CHECK CONSTRAINT [sisg_products_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_Products]  WITH CHECK ADD  CONSTRAINT [sisg_products_ibfk_2] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Sisg_Categories] ([id])
GO
ALTER TABLE [dbo].[Sisg_Products] CHECK CONSTRAINT [sisg_products_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_ProductsAccessories]  WITH CHECK ADD  CONSTRAINT [sisg_productsaccessories_ibfk_1] FOREIGN KEY([productId])
REFERENCES [dbo].[Sisg_Products] ([id])
GO
ALTER TABLE [dbo].[Sisg_ProductsAccessories] CHECK CONSTRAINT [sisg_productsaccessories_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_ProductsAccessories]  WITH CHECK ADD  CONSTRAINT [sisg_productsaccessories_ibfk_2] FOREIGN KEY([accessoryId])
REFERENCES [dbo].[Sisg_Accessories] ([id])
GO
ALTER TABLE [dbo].[Sisg_ProductsAccessories] CHECK CONSTRAINT [sisg_productsaccessories_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_ProductsReplacements]  WITH CHECK ADD  CONSTRAINT [sisg_productsreplacements_ibfk_1] FOREIGN KEY([productId])
REFERENCES [dbo].[Sisg_Products] ([id])
GO
ALTER TABLE [dbo].[Sisg_ProductsReplacements] CHECK CONSTRAINT [sisg_productsreplacements_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_ProductsReplacements]  WITH CHECK ADD  CONSTRAINT [sisg_productsreplacements_ibfk_2] FOREIGN KEY([replacementId])
REFERENCES [dbo].[Sisg_Replacements] ([id])
GO
ALTER TABLE [dbo].[Sisg_ProductsReplacements] CHECK CONSTRAINT [sisg_productsreplacements_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_Replacements]  WITH CHECK ADD  CONSTRAINT [sisg_replacements_ibfk_1] FOREIGN KEY([modelId])
REFERENCES [dbo].[Sisg_Models] ([id])
GO
ALTER TABLE [dbo].[Sisg_Replacements] CHECK CONSTRAINT [sisg_replacements_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_ReplacementsOpetechs]  WITH CHECK ADD  CONSTRAINT [Sisg_ReplacementsOpetechs_ibfk_1] FOREIGN KEY([operationTechId])
REFERENCES [dbo].[Sisg_TechnicalsOperations] ([id])
GO
ALTER TABLE [dbo].[Sisg_ReplacementsOpetechs] CHECK CONSTRAINT [Sisg_ReplacementsOpetechs_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_ReplacementsOpetechs]  WITH CHECK ADD  CONSTRAINT [Sisg_ReplacementsOpetechs_ibfk_2] FOREIGN KEY([replacementId])
REFERENCES [dbo].[Sisg_Replacements] ([id])
GO
ALTER TABLE [dbo].[Sisg_ReplacementsOpetechs] CHECK CONSTRAINT [Sisg_ReplacementsOpetechs_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_ReplacementsOrders]  WITH CHECK ADD  CONSTRAINT [fk_employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Sisg_Employees] ([id])
GO
ALTER TABLE [dbo].[Sisg_ReplacementsOrders] CHECK CONSTRAINT [fk_employee]
GO
ALTER TABLE [dbo].[Sisg_ReplacementsOrders]  WITH CHECK ADD  CONSTRAINT [Sisg_ReplacementsOrders_ibfk_1] FOREIGN KEY([orderId])
REFERENCES [dbo].[Sisg_WorkshopOrders] ([id])
GO
ALTER TABLE [dbo].[Sisg_ReplacementsOrders] CHECK CONSTRAINT [Sisg_ReplacementsOrders_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_ReplacementsOrders]  WITH CHECK ADD  CONSTRAINT [Sisg_ReplacementsOrders_ibfk_2] FOREIGN KEY([replacementId])
REFERENCES [dbo].[Sisg_Replacements] ([id])
GO
ALTER TABLE [dbo].[Sisg_ReplacementsOrders] CHECK CONSTRAINT [Sisg_ReplacementsOrders_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_Roles]  WITH CHECK ADD  CONSTRAINT [sisg_roles_ibfk_1] FOREIGN KEY([accessId])
REFERENCES [dbo].[Sisg_Accessroles] ([id])
GO
ALTER TABLE [dbo].[Sisg_Roles] CHECK CONSTRAINT [sisg_roles_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_Roles]  WITH CHECK ADD  CONSTRAINT [sisg_roles_ibfk_11] FOREIGN KEY([accessId])
REFERENCES [dbo].[Sisg_Accessroles] ([id])
GO
ALTER TABLE [dbo].[Sisg_Roles] CHECK CONSTRAINT [sisg_roles_ibfk_11]
GO
ALTER TABLE [dbo].[Sisg_Roles]  WITH CHECK ADD  CONSTRAINT [sisg_roles_ibfk_2] FOREIGN KEY([profileId])
REFERENCES [dbo].[Sisg_Profiles] ([id])
GO
ALTER TABLE [dbo].[Sisg_Roles] CHECK CONSTRAINT [sisg_roles_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_Roles]  WITH CHECK ADD  CONSTRAINT [sisg_roles_ibfk_22] FOREIGN KEY([profileId])
REFERENCES [dbo].[Sisg_Profiles] ([id])
GO
ALTER TABLE [dbo].[Sisg_Roles] CHECK CONSTRAINT [sisg_roles_ibfk_22]
GO
ALTER TABLE [dbo].[Sisg_Rolesmenus]  WITH CHECK ADD  CONSTRAINT [sisg_rolesmenus_ibfk_1] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Sisg_Menus] ([id])
GO
ALTER TABLE [dbo].[Sisg_Rolesmenus] CHECK CONSTRAINT [sisg_rolesmenus_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_Rolesmenus]  WITH CHECK ADD  CONSTRAINT [sisg_rolesmenus_ibfk_2] FOREIGN KEY([RolId])
REFERENCES [dbo].[Sisg_Roles] ([id])
GO
ALTER TABLE [dbo].[Sisg_Rolesmenus] CHECK CONSTRAINT [sisg_rolesmenus_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_SerialsProducts]  WITH CHECK ADD  CONSTRAINT [Sisg_SerialsProducts_ibfk_1] FOREIGN KEY([distributorId])
REFERENCES [dbo].[Sisg_Distributors] ([id])
GO
ALTER TABLE [dbo].[Sisg_SerialsProducts] CHECK CONSTRAINT [Sisg_SerialsProducts_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_SerialsProducts]  WITH CHECK ADD  CONSTRAINT [Sisg_SerialsProducts_ibfk_2] FOREIGN KEY([providerId])
REFERENCES [dbo].[Sisg_Providers] ([id])
GO
ALTER TABLE [dbo].[Sisg_SerialsProducts] CHECK CONSTRAINT [Sisg_SerialsProducts_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_SerialsProducts]  WITH CHECK ADD  CONSTRAINT [Sisg_SerialsProducts_ibfk_3] FOREIGN KEY([productId])
REFERENCES [dbo].[Sisg_Products] ([id])
GO
ALTER TABLE [dbo].[Sisg_SerialsProducts] CHECK CONSTRAINT [Sisg_SerialsProducts_ibfk_3]
GO
ALTER TABLE [dbo].[Sisg_SerialsReplacements]  WITH CHECK ADD  CONSTRAINT [Sisg_SerialsReplacements_ibfk_1] FOREIGN KEY([distributorId])
REFERENCES [dbo].[Sisg_Distributors] ([id])
GO
ALTER TABLE [dbo].[Sisg_SerialsReplacements] CHECK CONSTRAINT [Sisg_SerialsReplacements_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_SerialsReplacements]  WITH CHECK ADD  CONSTRAINT [Sisg_SerialsReplacements_ibfk_2] FOREIGN KEY([providerId])
REFERENCES [dbo].[Sisg_Providers] ([id])
GO
ALTER TABLE [dbo].[Sisg_SerialsReplacements] CHECK CONSTRAINT [Sisg_SerialsReplacements_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_SerialsReplacements]  WITH CHECK ADD  CONSTRAINT [Sisg_SerialsReplacements_ibfk_3] FOREIGN KEY([replacementId])
REFERENCES [dbo].[Sisg_Replacements] ([id])
GO
ALTER TABLE [dbo].[Sisg_SerialsReplacements] CHECK CONSTRAINT [Sisg_SerialsReplacements_ibfk_3]
GO
ALTER TABLE [dbo].[Sisg_TechnicalsOperations]  WITH CHECK ADD  CONSTRAINT [Sisg_TechnicalsOperations_ibfk_1] FOREIGN KEY([distributorId])
REFERENCES [dbo].[Sisg_Distributors] ([id])
GO
ALTER TABLE [dbo].[Sisg_TechnicalsOperations] CHECK CONSTRAINT [Sisg_TechnicalsOperations_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_TechnicalsOperations]  WITH CHECK ADD  CONSTRAINT [Sisg_TechnicalsOperations_ibfk_2] FOREIGN KEY([providerId])
REFERENCES [dbo].[Sisg_Providers] ([id])
GO
ALTER TABLE [dbo].[Sisg_TechnicalsOperations] CHECK CONSTRAINT [Sisg_TechnicalsOperations_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_TechnicalsOperations]  WITH CHECK ADD  CONSTRAINT [Sisg_TechnicalsOperations_ibfk_3] FOREIGN KEY([finalClientId])
REFERENCES [dbo].[Sisg_FinalsClients] ([id])
GO
ALTER TABLE [dbo].[Sisg_TechnicalsOperations] CHECK CONSTRAINT [Sisg_TechnicalsOperations_ibfk_3]
GO
ALTER TABLE [dbo].[Sisg_TechnicalsOperations]  WITH CHECK ADD  CONSTRAINT [Sisg_TechnicalsOperations_ibfk_4] FOREIGN KEY([technicianId])
REFERENCES [dbo].[Sisg_Technicians] ([id])
GO
ALTER TABLE [dbo].[Sisg_TechnicalsOperations] CHECK CONSTRAINT [Sisg_TechnicalsOperations_ibfk_4]
GO
ALTER TABLE [dbo].[Sisg_TechnicalsOperations]  WITH CHECK ADD  CONSTRAINT [Sisg_TechnicalsOperations_ibfk_5] FOREIGN KEY([typeOperationTechId])
REFERENCES [dbo].[Sisg_TypeOperationsTechs] ([id])
GO
ALTER TABLE [dbo].[Sisg_TechnicalsOperations] CHECK CONSTRAINT [Sisg_TechnicalsOperations_ibfk_5]
GO
ALTER TABLE [dbo].[Sisg_TechniciansDistributors]  WITH CHECK ADD  CONSTRAINT [sisg_techniciansdistributors_ibfk_1] FOREIGN KEY([techniciansId])
REFERENCES [dbo].[Sisg_Technicians] ([id])
GO
ALTER TABLE [dbo].[Sisg_TechniciansDistributors] CHECK CONSTRAINT [sisg_techniciansdistributors_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_TechniciansDistributors]  WITH CHECK ADD  CONSTRAINT [sisg_techniciansdistributors_ibfk_2] FOREIGN KEY([distributorsId])
REFERENCES [dbo].[Sisg_Distributors] ([id])
GO
ALTER TABLE [dbo].[Sisg_TechniciansDistributors] CHECK CONSTRAINT [sisg_techniciansdistributors_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_TechniciansUsers]  WITH CHECK ADD  CONSTRAINT [sisg_techniciansusers_ibfk_1] FOREIGN KEY([techniciansId])
REFERENCES [dbo].[Sisg_Technicians] ([id])
GO
ALTER TABLE [dbo].[Sisg_TechniciansUsers] CHECK CONSTRAINT [sisg_techniciansusers_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_TechniciansUsers]  WITH CHECK ADD  CONSTRAINT [sisg_techniciansusers_ibfk_2] FOREIGN KEY([userId])
REFERENCES [dbo].[Sisg_Users] ([id])
GO
ALTER TABLE [dbo].[Sisg_TechniciansUsers] CHECK CONSTRAINT [sisg_techniciansusers_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_Users]  WITH CHECK ADD  CONSTRAINT [sisg_users_ibfk_1] FOREIGN KEY([rolId])
REFERENCES [dbo].[Sisg_Roles] ([id])
GO
ALTER TABLE [dbo].[Sisg_Users] CHECK CONSTRAINT [sisg_users_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_WorkshopBinnacles]  WITH CHECK ADD  CONSTRAINT [Sisg_WorkshopBinnacles_ibfk_1] FOREIGN KEY([orderId])
REFERENCES [dbo].[Sisg_WorkshopOrders] ([id])
GO
ALTER TABLE [dbo].[Sisg_WorkshopBinnacles] CHECK CONSTRAINT [Sisg_WorkshopBinnacles_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_WorkshopBinnacles]  WITH CHECK ADD  CONSTRAINT [Sisg_WorkshopBinnacles_ibfk_2] FOREIGN KEY([statusId])
REFERENCES [dbo].[Sisg_StatesOrder] ([id])
GO
ALTER TABLE [dbo].[Sisg_WorkshopBinnacles] CHECK CONSTRAINT [Sisg_WorkshopBinnacles_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_WorkshopBinnacles]  WITH CHECK ADD  CONSTRAINT [Sisg_WorkshopBinnacles_ibfk_3] FOREIGN KEY([userId])
REFERENCES [dbo].[Sisg_Employees] ([id])
GO
ALTER TABLE [dbo].[Sisg_WorkshopBinnacles] CHECK CONSTRAINT [Sisg_WorkshopBinnacles_ibfk_3]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders]  WITH CHECK ADD  CONSTRAINT [Sisg_WorkshopOrders_ibfk_1] FOREIGN KEY([typeFailurId])
REFERENCES [dbo].[Sisg_TypesFailures] ([id])
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] CHECK CONSTRAINT [Sisg_WorkshopOrders_ibfk_1]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders]  WITH CHECK ADD  CONSTRAINT [Sisg_WorkshopOrders_ibfk_2] FOREIGN KEY([stateOrderId])
REFERENCES [dbo].[Sisg_StatesOrder] ([id])
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] CHECK CONSTRAINT [Sisg_WorkshopOrders_ibfk_2]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders]  WITH CHECK ADD  CONSTRAINT [Sisg_WorkshopOrders_ibfk_3] FOREIGN KEY([deliveryOrderId])
REFERENCES [dbo].[Sisg_DeliveryOrder] ([id])
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] CHECK CONSTRAINT [Sisg_WorkshopOrders_ibfk_3]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders]  WITH CHECK ADD  CONSTRAINT [Sisg_WorkshopOrders_ibfk_4] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Sisg_Employees] ([id])
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] CHECK CONSTRAINT [Sisg_WorkshopOrders_ibfk_4]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders]  WITH CHECK ADD  CONSTRAINT [Sisg_WorkshopOrders_ibfk_5] FOREIGN KEY([distributorId])
REFERENCES [dbo].[Sisg_Distributors] ([id])
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] CHECK CONSTRAINT [Sisg_WorkshopOrders_ibfk_5]
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders]  WITH CHECK ADD  CONSTRAINT [Sisg_WorkshopOrders_ibfk_6] FOREIGN KEY([warrantyId])
REFERENCES [dbo].[Sisg_StatesWarranty] ([id])
GO
ALTER TABLE [dbo].[Sisg_WorkshopOrders] CHECK CONSTRAINT [Sisg_WorkshopOrders_ibfk_6]
GO
