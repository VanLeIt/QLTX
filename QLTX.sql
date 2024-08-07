USE [QLTXD]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25/07/2024 4:50:15 CH ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdationTime] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IdDocument] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdationTime] [datetime2](7) NULL,
	[TypeDocument] [int] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMotorbikes]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMotorbikes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeMotorbikeId] [int] NOT NULL,
	[VinNumber] [nvarchar](20) NOT NULL,
	[License] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Status] [int] NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdationTime] [datetime2](7) NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_EMotorbikes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalDetails]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalDetails](
	[RentalId] [int] NOT NULL,
	[EMotorbileId] [int] NOT NULL,
 CONSTRAINT [PK_RentalDetails] PRIMARY KEY CLUSTERED 
(
	[RentalId] ASC,
	[EMotorbileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DateRetalFrom] [datetime2](7) NOT NULL,
	[DateRetalTo] [datetime2](7) NOT NULL,
	[RetalTime] [real] NULL,
	[Service] [int] NOT NULL,
	[Price] [real] NOT NULL,
	[Status] [int] NOT NULL,
	[Total] [real] NOT NULL,
	[Note] [nvarchar](255) NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdationTime] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdationTime] [datetime2](7) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stores]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
 CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeMotorbikes]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeMotorbikes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Power] [nvarchar](100) NULL,
	[Speed] [nvarchar](100) NULL,
	[Distance] [nvarchar](100) NULL,
	[Charging] [nvarchar](100) NULL,
	[CompanyId] [int] NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdationTime] [datetime2](7) NULL,
	[IsDelete] [bit] NOT NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_TypeMotorbikes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdationTime] [datetime2](7) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 25/07/2024 4:50:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240711120713_updateRenald', N'7.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240713080826_updateTypeMotor', N'7.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240713152724_updateFloat', N'7.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240714012020_updateStore', N'7.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240715134855_updateStores', N'7.0.17')
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([Id], [Name], [Description], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete]) VALUES (1, N'Vinfast', N'Hãng xe vinfast', N'admin@gmail.com', CAST(N'2024-05-15T01:04:13.1873885' AS DateTime2), N'admin@gmail.com', CAST(N'2024-05-15T01:04:25.9053745' AS DateTime2), 0)
INSERT [dbo].[Companies] ([Id], [Name], [Description], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete]) VALUES (4, N'Yadea', N'Hãng xe điện Yadea', N'admin@gmail.com', CAST(N'2024-06-05T19:43:16.8007804' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-22T22:59:56.6427729' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Name], [IdDocument], [PhoneNumber], [Email], [Address], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [TypeDocument], [IsDelete]) VALUES (1, N'Lê Văn Văn', N'03820103975', N'0989888777', N'vanle16032001@gmail.com', N'Thanh Hóa', N'admin@gmail.com', CAST(N'2024-05-21T00:23:19.5845553' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-23T22:33:11.2116760' AS DateTime2), 0, 0)
INSERT [dbo].[Customers] ([Id], [Name], [IdDocument], [PhoneNumber], [Email], [Address], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [TypeDocument], [IsDelete]) VALUES (3, N'admin', N'03820103975', N'088889999', N'admin@gmail.com', N'Hà Nội', N'levan@gmail.com', CAST(N'2024-07-07T08:23:06.3979777' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-11T10:47:14.2597977' AS DateTime2), 0, 0)
INSERT [dbo].[Customers] ([Id], [Name], [IdDocument], [PhoneNumber], [Email], [Address], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [TypeDocument], [IsDelete]) VALUES (4, N'Lê Anh Minh', N'03820100935', N'0705430519', N'leminh@gmail.com', N'Bắc Từ Liêm, Hà Nội', N'admin@gmail.com', CAST(N'2024-07-23T21:44:02.1565841' AS DateTime2), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[EMotorbikes] ON 

INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (1, 1, N'VN897347623642662', N'29B4-13682', N'Hãng xe vinfast ádas', 0, N'admin@gmail.com', CAST(N'2024-05-15T01:05:31.0272193' AS DateTime2), N'admin@gmail.com', CAST(N'2024-05-30T00:15:46.9815229' AS DateTime2), N'/images/vinfastevo200.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (2, 1, N'VN897347623642663', N'29B4-136877', N'Website quản lý thuê xe máy điện edit', 0, N'admin@gmail.com', CAST(N'2024-05-29T22:04:53.1287761' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-11T11:49:14.9897583' AS DateTime2), N'/images/vinfastevo200.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (3, 1, N'VN897347623642664', N'29B4-13685', N'ádasdasda', 0, N'admin@gmail.com', CAST(N'2024-05-29T22:18:00.1051250' AS DateTime2), NULL, NULL, N'/images/vinfastevo200.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (4, 1, N'VN897347623642665', N'29B4-136875', N'Hãng xe vinfast ádas', 0, N'admin@gmail.com', CAST(N'2024-05-29T22:19:32.4341904' AS DateTime2), N'admin@gmail.com', CAST(N'2024-05-29T23:25:54.2893075' AS DateTime2), N'/images/vinfastevo200.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (5, 1, N'VN897347623642666', N'29B4-136878', N'Website quản lý thuê xe máy điện', 0, N'admin@gmail.com', CAST(N'2024-05-29T23:59:24.6485759' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-20T01:37:51.2164063' AS DateTime2), N'/images/vinfastevo200.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (6, 1, N'VN897347623642667', N'29B4-136879', NULL, 0, N'admin@gmail.com', CAST(N'2024-05-30T00:03:41.2803705' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-02T00:30:37.1020248' AS DateTime2), N'/images/vinfastevo200.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (7, 2, N'VN897347623642666', N'29B4-13689', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-11T10:50:46.4165963' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-23T20:57:47.8443977' AS DateTime2), N'/images/vinfast-feliz-s-5-jpg.png', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (8, 3, N'VN8973477385932', N'29B5 24684', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:03:11.1541130' AS DateTime2), NULL, NULL, N'/images/1676115023_avt-evo-200.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (9, 3, N'VN897347623645832', N'29B5 39558', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:03:49.4964517' AS DateTime2), NULL, NULL, N'/images/1676115023_avt-evo-200.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (10, 4, N'VN897347623698798', N'29B4 47268', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:07:17.2069703' AS DateTime2), NULL, NULL, N'/images/battery-tech-sp.png', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (11, 4, N'VN893642663734762', N'29B4 24653', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:10:57.2059855' AS DateTime2), NULL, NULL, N'/images/battery-tech-sp.png', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (12, 6, N'VN897347623642664', N'29B4 36877', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:14:47.3894746' AS DateTime2), NULL, NULL, N'/images/img-top-ventos-yellow.png', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (13, 6, N'VN897347642662623', N'29B4 13732', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:16:03.8144296' AS DateTime2), NULL, NULL, N'/images/image-color-3-sp.png', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (14, 6, N'VN897347642667236', N'29B4 56337', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:19:14.9967621' AS DateTime2), NULL, NULL, N'/images/43ea8f6e7763806c4cec448f9d3553f7.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (15, 7, N'VN897347623642444', N'29B4 77635', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:24:11.4759640' AS DateTime2), NULL, NULL, N'/images/xe-may-dien-yadea-ocean_29bcea8e.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (16, 7, N'VN897347623642232', N'29B5 73762', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:25:41.6972444' AS DateTime2), NULL, NULL, N'/images/xe-may-dien-yadea-ocean-kem.png', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (17, 10, N'97397347623643443', N'29B8 73731', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:27:11.3378712' AS DateTime2), NULL, NULL, N'/images/xe-may-dien-yadea-ossy-thumbnail-vuong.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (18, 10, N'VN897347623642622', N'29B2 8374', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:40:02.9116185' AS DateTime2), NULL, NULL, N'/images/anh-sp-ossy1.png', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (19, 11, N'VN897236434762663', N'29B4 88374', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:41:58.3837389' AS DateTime2), NULL, NULL, N'/images/xe-may-dien-yadea-voltguard.jpg', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (20, 11, N'VN892364734762663', N'29B3 66574', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-23T21:42:53.1099332' AS DateTime2), NULL, NULL, N'/images/xe-may-dien-yadea-voltguard.png', 0)
INSERT [dbo].[EMotorbikes] ([Id], [TypeMotorbikeId], [VinNumber], [License], [Description], [Status], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [ImageUrl], [IsDelete]) VALUES (21, 1, N'VN897347623683444', N'29B5 73645', NULL, 0, N'admin@gmail.com', CAST(N'2024-07-25T11:38:18.3612646' AS DateTime2), NULL, NULL, N'/images/1676115023_avt-evo-200.jpg', 0)
SET IDENTITY_INSERT [dbo].[EMotorbikes] OFF
GO
INSERT [dbo].[RentalDetails] ([RentalId], [EMotorbileId]) VALUES (65, 3)
INSERT [dbo].[RentalDetails] ([RentalId], [EMotorbileId]) VALUES (65, 5)
INSERT [dbo].[RentalDetails] ([RentalId], [EMotorbileId]) VALUES (66, 5)
INSERT [dbo].[RentalDetails] ([RentalId], [EMotorbileId]) VALUES (66, 6)
INSERT [dbo].[RentalDetails] ([RentalId], [EMotorbileId]) VALUES (64, 8)
INSERT [dbo].[RentalDetails] ([RentalId], [EMotorbileId]) VALUES (64, 9)
INSERT [dbo].[RentalDetails] ([RentalId], [EMotorbileId]) VALUES (63, 19)
INSERT [dbo].[RentalDetails] ([RentalId], [EMotorbileId]) VALUES (67, 19)
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([Id], [CustomerId], [DateRetalFrom], [DateRetalTo], [RetalTime], [Service], [Price], [Status], [Total], [Note], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete]) VALUES (63, 4, CAST(N'2024-07-23T21:44:00.0000000' AS DateTime2), CAST(N'2024-07-24T21:44:00.0000000' AS DateTime2), 1, 2, 250000, 1, 250000, NULL, N'admin@gmail.com', CAST(N'2024-07-23T21:45:59.3549820' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Rentals] ([Id], [CustomerId], [DateRetalFrom], [DateRetalTo], [RetalTime], [Service], [Price], [Status], [Total], [Note], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete]) VALUES (64, 1, CAST(N'2024-07-23T22:35:00.0000000' AS DateTime2), CAST(N'2024-07-25T11:35:00.0000000' AS DateTime2), 2, 2, 26000, 1, 312000, NULL, N'admin@gmail.com', CAST(N'2024-07-23T22:36:50.6104713' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-25T10:07:19.0913136' AS DateTime2), 0)
INSERT [dbo].[Rentals] ([Id], [CustomerId], [DateRetalFrom], [DateRetalTo], [RetalTime], [Service], [Price], [Status], [Total], [Note], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete]) VALUES (65, 1, CAST(N'2024-07-23T22:37:00.0000000' AS DateTime2), CAST(N'2024-07-23T23:37:00.0000000' AS DateTime2), 1, 1, 30000, 1, 30000, NULL, N'admin@gmail.com', CAST(N'2024-07-23T22:38:35.6577403' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Rentals] ([Id], [CustomerId], [DateRetalFrom], [DateRetalTo], [RetalTime], [Service], [Price], [Status], [Total], [Note], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete]) VALUES (66, 4, CAST(N'2024-07-25T11:40:00.0000000' AS DateTime2), CAST(N'2024-07-25T22:40:00.0000000' AS DateTime2), 1, 2, 300000, 1, 300000, NULL, N'admin@gmail.com', CAST(N'2024-07-25T11:45:24.5837258' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-25T16:25:18.1694079' AS DateTime2), 0)
INSERT [dbo].[Rentals] ([Id], [CustomerId], [DateRetalFrom], [DateRetalTo], [RetalTime], [Service], [Price], [Status], [Total], [Note], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete]) VALUES (67, 1, CAST(N'2024-07-25T15:27:00.0000000' AS DateTime2), CAST(N'2024-07-25T15:30:00.0000000' AS DateTime2), 1, 1, 25000, 1, 25000, NULL, N'admin@gmail.com', CAST(N'2024-07-25T15:28:15.9731667' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-25T15:28:50.5442310' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
INSERT [dbo].[Roles] ([Id], [Description], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [Name], [NormalizedName], [ConcurrencyStamp], [IsDelete]) VALUES (N'12d644a1-bf64-46fa-b71e-c2a3003a44a3', N'admin ', N'admin', CAST(N'2024-05-15T00:38:10.0000000' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-01T23:11:05.8669650' AS DateTime2), N'admin', NULL, NULL, 0)
INSERT [dbo].[Roles] ([Id], [Description], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [Name], [NormalizedName], [ConcurrencyStamp], [IsDelete]) VALUES (N'd5a1e482-def4-4bf4-85ce-a1b305e9af27', N'nhân viên', N'admin@gmail.com', CAST(N'2024-05-15T01:36:25.9707117' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-01T23:11:13.6742255' AS DateTime2), N'staff', NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Stores] ON 

INSERT [dbo].[Stores] ([Id], [Name], [Description], [PhoneNumber], [Email], [Address]) VALUES (9, N'Cửa hàng Thuê xe máy điện E-Motorbike', N'Cho thuê các loại xe máy điện giá tốt nhất Hà Nội', N'0944888333', N'thuexe@gmail.com', N'Bắc Từ Liêm, Hà Nội')
SET IDENTITY_INSERT [dbo].[Stores] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeMotorbikes] ON 

INSERT [dbo].[TypeMotorbikes] ([Id], [Name], [Description], [Power], [Speed], [Distance], [Charging], [CompanyId], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete], [Price]) VALUES (1, N'Vinfast evo200 (2023)', N'Hãng xe điện Vinfast', N'1500W', N'70 km/h', N'203 km', N'8-10h', 1, N'admin@gmail.com', CAST(N'2024-05-15T01:05:09.6734155' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-22T23:20:57.2232954' AS DateTime2), 0, 15000)
INSERT [dbo].[TypeMotorbikes] ([Id], [Name], [Description], [Power], [Speed], [Distance], [Charging], [CompanyId], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete], [Price]) VALUES (2, N'Vinfast Feliz S (2023)', N'Hãng xe điện Vinfast', N'1800W', N'78 km/h', N'198 km', N'6-8 h', 1, N'admin@gmail.com', CAST(N'2024-07-01T23:56:33.0292246' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-23T08:06:16.8405687' AS DateTime2), 0, 20000)
INSERT [dbo].[TypeMotorbikes] ([Id], [Name], [Description], [Power], [Speed], [Distance], [Charging], [CompanyId], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete], [Price]) VALUES (3, N'Vinfast evo200 lite (2023)', N'Xe máy điện Vinfast evo200 lite (2023) ', N'1500 W', N'49 km/h', N'205 km', N'10h', 1, N'admin@gmail.com', CAST(N'2024-07-22T23:23:53.5190431' AS DateTime2), NULL, NULL, 0, 13000)
INSERT [dbo].[TypeMotorbikes] ([Id], [Name], [Description], [Power], [Speed], [Distance], [Charging], [CompanyId], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete], [Price]) VALUES (4, N'VinFast Klara S (2022)', N'Xe máy điện VinFast Klara S (2022)', N'1800 W', N'78 km/h', N'194 km', N'6h', 1, N'admin@gmail.com', CAST(N'2024-07-22T23:32:04.9940202' AS DateTime2), NULL, NULL, 0, 20000)
INSERT [dbo].[TypeMotorbikes] ([Id], [Name], [Description], [Power], [Speed], [Distance], [Charging], [CompanyId], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete], [Price]) VALUES (5, N'VinFast Theon S (2023)', N'Xe máy điện VinFast Theon S', N'3500 W', N'99 km/h', N'150 km', N'6h', 1, N'admin@gmail.com', CAST(N'2024-07-22T23:33:35.9444340' AS DateTime2), N'admin@gmail.com', CAST(N'2024-07-22T23:38:31.0112760' AS DateTime2), 0, 30000)
INSERT [dbo].[TypeMotorbikes] ([Id], [Name], [Description], [Power], [Speed], [Distance], [Charging], [CompanyId], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete], [Price]) VALUES (6, N'VinFast Vento S (2023)', N'Xe máy điện VinFast Vento S', N'2600 W', N'89 km/h', N'160 km', N'6h', 1, N'admin@gmail.com', CAST(N'2024-07-22T23:38:08.2373613' AS DateTime2), NULL, NULL, 0, 25000)
INSERT [dbo].[TypeMotorbikes] ([Id], [Name], [Description], [Power], [Speed], [Distance], [Charging], [CompanyId], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete], [Price]) VALUES (7, N'YADEA OCEAN (2023)', N'Xe máy điện YADEA OCEAN', N'800 W', N'46 km/h', N'80km', N'7-8 h', 4, N'admin@gmail.com', CAST(N'2024-07-22T23:54:51.6667537' AS DateTime2), NULL, NULL, 0, 15000)
INSERT [dbo].[TypeMotorbikes] ([Id], [Name], [Description], [Power], [Speed], [Distance], [Charging], [CompanyId], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete], [Price]) VALUES (8, N'Yadea ORLA (2024)', N'Xe máy điện Yadea ORLA (2024)', N'800 W', N'48 km/h', N'80km', N'8- 10 h', 4, N'admin@gmail.com', CAST(N'2024-07-23T00:00:13.7273691' AS DateTime2), NULL, NULL, 0, 15000)
INSERT [dbo].[TypeMotorbikes] ([Id], [Name], [Description], [Power], [Speed], [Distance], [Charging], [CompanyId], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete], [Price]) VALUES (9, N'Yadea Oris (2024)', N'Xe máy điện Yadea Oris (2024)', N'1200 W', N'49 km/h', N'90km', N'7-8 h', 4, N'admin@gmail.com', CAST(N'2024-07-23T00:04:09.0439077' AS DateTime2), NULL, NULL, 0, 20000)
INSERT [dbo].[TypeMotorbikes] ([Id], [Name], [Description], [Power], [Speed], [Distance], [Charging], [CompanyId], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete], [Price]) VALUES (10, N'Yadea Ossy (2024)', N'Xe máy điện Yadea Ossy (2024)', N'1200 W', N'46 km/h', N'80km', N'7-8 h', 4, N'admin@gmail.com', CAST(N'2024-07-23T00:07:22.9094497' AS DateTime2), NULL, NULL, 0, 20000)
INSERT [dbo].[TypeMotorbikes] ([Id], [Name], [Description], [Power], [Speed], [Distance], [Charging], [CompanyId], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [IsDelete], [Price]) VALUES (11, N'YADEA Voltguard (2024)', N'Xe máy điện YADEA Voltguard (2024)', N'1500W', N'50 km/h', N'71 km', N'7-8 h', 1, N'admin@gmail.com', CAST(N'2024-07-23T00:12:13.2517743' AS DateTime2), NULL, NULL, 0, 25000)
SET IDENTITY_INSERT [dbo].[TypeMotorbikes] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'4c33e503-c8a7-4b2a-88fe-4e649c7f90df', N'12d644a1-bf64-46fa-b71e-c2a3003a44a3')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'4c33e503-c8a7-4b2a-88fe-4e649c7f90df', N'd5a1e482-def4-4bf4-85ce-a1b305e9af27')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'b59886f0-ee70-4708-9357-cf35e679f400', N'd5a1e482-def4-4bf4-85ce-a1b305e9af27')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'e2df95db-b026-4ebf-ab5a-160cea4a1d35', N'd5a1e482-def4-4bf4-85ce-a1b305e9af27')
GO
INSERT [dbo].[Users] ([Id], [FullName], [Address], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsDelete]) VALUES (N'4c33e503-c8a7-4b2a-88fe-4e649c7f90df', N'admin', N'Hà Nội', N'system', CAST(N'2024-04-01T00:42:33.9216677' AS DateTime2), NULL, NULL, N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAENxfQHL5DPVSqDpY+dydiYws7Ps+3FpYtoElbzKyXqZucf5YnZVeK+x6P9dA1lggAA==', N'6EZN7ASH6MD4OSDQEREFCTXNJ3EFKC4O', N'786c2314-833b-4017-aeb2-0b8a2339e337', N'0989888777', 0, 0, NULL, 1, 0, 0)
INSERT [dbo].[Users] ([Id], [FullName], [Address], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsDelete]) VALUES (N'5781949a-0c63-464a-ab54-e55bd2cf3af9', N'Nguyễn Hải', N'Thanh Hóa', N'admin@gmail.com', CAST(N'2024-06-29T15:35:18.7706250' AS DateTime2), NULL, NULL, N'hai@gmail.com', N'HAI@GMAIL.COM', N'hai@gmail.com', N'HAI@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEBZB6t6ZAucRrcj9z4/yStg1fEAsasNOeq8O+ov21GdDEDg868w9CAogXOOvXMfdzQ==', N'NUAUFB4LBUWFPLAFQ3NMWKRZH7EQQOGT', N'eea9b882-3e12-42d7-b1b3-2747e617f25a', N'0989888777', 0, 0, NULL, 1, 0, 1)
INSERT [dbo].[Users] ([Id], [FullName], [Address], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsDelete]) VALUES (N'b59886f0-ee70-4708-9357-cf35e679f400', N'Lê Văn Minh', N'Hà Nội', N'admin@gmail.com', CAST(N'2024-05-19T00:42:33.9216677' AS DateTime2), NULL, NULL, N'levan@gmail.com', N'LEVAN@GMAIL.COM', N'levan@gmail.com', N'LEVAN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEPnIGCeKIZdsweYfLVklROPNFH1cSFU+MyZGeg45zy1PEEuD8A1Q988TffHrLsNqyw==', N'5Y335ZKNH26IHJVH3Y5XLEM4DVPNVM2L', N'342f91e6-37c8-4868-bf22-498c16168e38', N'0989888777', 0, 0, NULL, 1, 0, 0)
INSERT [dbo].[Users] ([Id], [FullName], [Address], [CreatedBy], [CreationTime], [UpdatedBy], [UpdationTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsDelete]) VALUES (N'e2df95db-b026-4ebf-ab5a-160cea4a1d35', N'nhân viên', N'Thanh hóa', N'admin@gmail.com', CAST(N'2024-07-25T16:45:01.5067364' AS DateTime2), NULL, NULL, N'staff@gmail.com', N'STAFF@GMAIL.COM', N'staff@gmail.com', N'STAFF@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEFgt3jzf6AXLGH8e+cu81euVOpZAGaywoljp5NauPkuRWJ4vwK0c3vx1CwgUrAK2Kg==', N'IJL746QE54JBIPALOS5ZISHQSZDHZ32K', N'703ce081-3931-4ea7-8966-721ef528c75e', N'0989888777', 0, 0, NULL, 1, 0, 0)
GO
ALTER TABLE [dbo].[Companies] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [TypeDocument]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDelete]
GO
ALTER TABLE [dbo].[EMotorbikes] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Rentals] ADD  CONSTRAINT [DF__Rentals__IsDelet__634EBE90]  DEFAULT (CONVERT([bit],(0))) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDelete]
GO
ALTER TABLE [dbo].[TypeMotorbikes] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDelete]
GO
ALTER TABLE [dbo].[EMotorbikes]  WITH CHECK ADD  CONSTRAINT [FK_EMotorbikes_TypeMotorbikes_TypeMotorbikeId] FOREIGN KEY([TypeMotorbikeId])
REFERENCES [dbo].[TypeMotorbikes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMotorbikes] CHECK CONSTRAINT [FK_EMotorbikes_TypeMotorbikes_TypeMotorbikeId]
GO
ALTER TABLE [dbo].[RentalDetails]  WITH CHECK ADD  CONSTRAINT [FK_RentalDetails_EMotorbikes_EMotorbileId] FOREIGN KEY([EMotorbileId])
REFERENCES [dbo].[EMotorbikes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RentalDetails] CHECK CONSTRAINT [FK_RentalDetails_EMotorbikes_EMotorbileId]
GO
ALTER TABLE [dbo].[RentalDetails]  WITH CHECK ADD  CONSTRAINT [FK_RentalDetails_Rentals_RentalId] FOREIGN KEY([RentalId])
REFERENCES [dbo].[Rentals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RentalDetails] CHECK CONSTRAINT [FK_RentalDetails_Rentals_RentalId]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Customers_CustomerId]
GO
ALTER TABLE [dbo].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [dbo].[TypeMotorbikes]  WITH CHECK ADD  CONSTRAINT [FK_TypeMotorbikes_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TypeMotorbikes] CHECK CONSTRAINT [FK_TypeMotorbikes_Companies_CompanyId]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
