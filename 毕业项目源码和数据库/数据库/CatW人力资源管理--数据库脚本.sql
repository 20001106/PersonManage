USE [master]
GO
/****** Object:  Database [PersonManagement]    Script Date: 2020/7/21 22:43:03 ******/
CREATE DATABASE [PersonManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PersonManagement.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PersonManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PersonManagement_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PersonManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PersonManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PersonManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [PersonManagement] SET  MULTI_USER 
GO
ALTER DATABASE [PersonManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PersonManagement', N'ON'
GO
USE [PersonManagement]
GO
/****** Object:  Table [dbo].[A_P_Message]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_P_Message](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Message] [nvarchar](100) NOT NULL,
	[Reason] [nvarchar](50) NOT NULL,
	[SendTime] [datetime] NOT NULL,
	[State] [int] NOT NULL,
	[ReplyMessage] [nvarchar](100) NULL,
	[ReplyTime] [datetime] NULL,
	[ReplyAdmin] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[A_U_Message]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_U_Message](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EpmID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Topic] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdminT]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[LoginPwd] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[TadayTime] [date] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Board]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdminID] [int] NOT NULL,
	[PublishTime] [datetime] NOT NULL,
	[Topic] [nvarchar](20) NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(100,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Remark] [nvarchar](200) NULL,
	[BasicPay] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employment]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sex] [nvarchar](20) NOT NULL,
	[Age] [int] NOT NULL,
	[IDCard] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Native_place] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DptID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Diploma] [nvarchar](50) NOT NULL,
	[Major] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](200) NULL,
	[WorkExper] [nvarchar](50) NOT NULL,
	[State] [int] NOT NULL,
	[DeleteRecord] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pay]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pay](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[OverTime] [date] NOT NULL,
	[AttPay] [money] NOT NULL,
	[OtherPay] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Sex] [nvarchar](20) NOT NULL,
	[Age] [int] NOT NULL,
	[IDCard] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Native_place] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DptID] [int] NOT NULL,
	[Diploma] [nvarchar](50) NOT NULL,
	[Major] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reward]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reward](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Topic] [nvarchar](50) NOT NULL,
	[RewardType] [nvarchar](20) NOT NULL,
	[RewardTime] [datetime] NOT NULL,
	[RewardGift] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Train]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Train](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Topic] [nvarchar](50) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Site] [nvarchar](50) NOT NULL,
	[Number] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserT]    Script Date: 2020/7/21 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPwd] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[A_P_Message] ON 

INSERT [dbo].[A_P_Message] ([ID], [PersonID], [Message], [Reason], [SendTime], [State], [ReplyMessage], [ReplyTime], [ReplyAdmin]) VALUES (1, 1002, N'申请更换部门，更换至人事部。', N'提升这方面的技术。', CAST(0x0000ABC700A4CB80 AS DateTime), 1, N'准许，已批准，继续努力。', CAST(0x0000ABC800A4CB80 AS DateTime), N'sansan')
INSERT [dbo].[A_P_Message] ([ID], [PersonID], [Message], [Reason], [SendTime], [State], [ReplyMessage], [ReplyTime], [ReplyAdmin]) VALUES (2, 1001, N'申请更换部门，更换至技术部。', N'提升这方面的技术。', CAST(0x0000ABC900A4CB80 AS DateTime), 0, N'', CAST(0x0000000000000000 AS DateTime), N'')
SET IDENTITY_INSERT [dbo].[A_P_Message] OFF
SET IDENTITY_INSERT [dbo].[A_U_Message] ON 

INSERT [dbo].[A_U_Message] ([ID], [EpmID], [UserID], [Topic]) VALUES (1, 3, 8, N'恭喜你，已通过录用')
SET IDENTITY_INSERT [dbo].[A_U_Message] OFF
SET IDENTITY_INSERT [dbo].[AdminT] ON 

INSERT [dbo].[AdminT] ([ID], [LoginName], [LoginPwd]) VALUES (1, N'sansan', N'123321')
INSERT [dbo].[AdminT] ([ID], [LoginName], [LoginPwd]) VALUES (2, N'admin', N'111111')
SET IDENTITY_INSERT [dbo].[AdminT] OFF
SET IDENTITY_INSERT [dbo].[Attendance] ON 

INSERT [dbo].[Attendance] ([ID], [PersonID], [TadayTime], [StartTime], [EndTime]) VALUES (1, 1000, CAST(0x1E410B00 AS Date), CAST(0x0000ABC3009450C0 AS DateTime), CAST(0x0000ABC3016A8C80 AS DateTime))
INSERT [dbo].[Attendance] ([ID], [PersonID], [TadayTime], [StartTime], [EndTime]) VALUES (2, 1001, CAST(0x1E410B00 AS Date), CAST(0x0000ABC30083D600 AS DateTime), CAST(0x0000ABC3016A8C80 AS DateTime))
INSERT [dbo].[Attendance] ([ID], [PersonID], [TadayTime], [StartTime], [EndTime]) VALUES (3, 1004, CAST(0x1E410B00 AS Date), CAST(0x0000ABC3009450C0 AS DateTime), CAST(0x0000ABC301499700 AS DateTime))
INSERT [dbo].[Attendance] ([ID], [PersonID], [TadayTime], [StartTime], [EndTime]) VALUES (4, 1003, CAST(0x1F410B00 AS Date), CAST(0x0000ABC4009450C0 AS DateTime), CAST(0x0000ABC3016A8C80 AS DateTime))
INSERT [dbo].[Attendance] ([ID], [PersonID], [TadayTime], [StartTime], [EndTime]) VALUES (5, 1000, CAST(0x4B410B00 AS Date), CAST(0x0000ABF00111D87F AS DateTime), CAST(0x0000ABF0016A8C80 AS DateTime))
INSERT [dbo].[Attendance] ([ID], [PersonID], [TadayTime], [StartTime], [EndTime]) VALUES (6, 1001, CAST(0x4B410B00 AS Date), CAST(0x0000ABF0011416BD AS DateTime), CAST(0x0000ABF0016A8C80 AS DateTime))
SET IDENTITY_INSERT [dbo].[Attendance] OFF
SET IDENTITY_INSERT [dbo].[Board] ON 

INSERT [dbo].[Board] ([ID], [AdminID], [PublishTime], [Topic], [Content]) VALUES (1, 1, CAST(0x0000ABC1016A8C80 AS DateTime), N'培训', N'现针对公司技术问题，对员工进行技术上的培训，如：Java、js、Bootatrsp。望员工们积极报名。')
INSERT [dbo].[Board] ([ID], [AdminID], [PublishTime], [Topic], [Content]) VALUES (2, 2, CAST(0x0000ABC7016A8C80 AS DateTime), N'奖惩', N'有个别员工上班不积极，迟到问题常有，具体姓名不公布，给予警告，望各位员工积极向上，互相督促，互相进步。')
SET IDENTITY_INSERT [dbo].[Board] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([ID], [Name], [CreateTime], [Remark], [BasicPay]) VALUES (100, N'技术部', CAST(0x0000ABB700000000 AS DateTime), N'管理技术', 30.0000)
INSERT [dbo].[Department] ([ID], [Name], [CreateTime], [Remark], [BasicPay]) VALUES (101, N'财务部', CAST(0x0000ABBC00000000 AS DateTime), N'管理财务', 20.0000)
INSERT [dbo].[Department] ([ID], [Name], [CreateTime], [Remark], [BasicPay]) VALUES (102, N'人事部', CAST(0x0000ABC100000000 AS DateTime), N'管理人员', 10.0000)
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Employment] ON 

INSERT [dbo].[Employment] ([ID], [Name], [Sex], [Age], [IDCard], [Address], [Native_place], [Phone], [Email], [DptID], [UserID], [Diploma], [Major], [Remark], [WorkExper], [State], [DeleteRecord]) VALUES (1, N'张思', N'男', 19, N'400000200103123230', N'虚拟市虚拟区虚拟路01号', N'湖南省怀化市', N'15273572262', N'15273572262@163.com', 102, 6, N'大专', N'资源管理', N'结交朋友', N'无', 0, 0)
INSERT [dbo].[Employment] ([ID], [Name], [Sex], [Age], [IDCard], [Address], [Native_place], [Phone], [Email], [DptID], [UserID], [Diploma], [Major], [Remark], [WorkExper], [State], [DeleteRecord]) VALUES (2, N'李前', N'女', 18, N'400000200207113231', N'虚拟市虚拟区虚拟路08号', N'湖南省衡阳市', N'15273572268', N'15273572268@163.com', 101, 7, N'大专', N'会计', N'听歌', N'一年会计管理', 0, 0)
INSERT [dbo].[Employment] ([ID], [Name], [Sex], [Age], [IDCard], [Address], [Native_place], [Phone], [Email], [DptID], [UserID], [Diploma], [Major], [Remark], [WorkExper], [State], [DeleteRecord]) VALUES (3, N'王七', N'男', 20, N'400000200011043232', N'虚拟市虚拟区虚拟路10号', N'湖南省湘潭市', N'15273572222', N'15273572222@163.com', 100, 8, N'本科', N'软件技术', N'敲代码', N'两年编程', 1, 0)
SET IDENTITY_INSERT [dbo].[Employment] OFF
SET IDENTITY_INSERT [dbo].[Pay] ON 

INSERT [dbo].[Pay] ([ID], [PersonID], [OverTime], [AttPay], [OtherPay]) VALUES (1, 1000, CAST(0x1E410B00 AS Date), 10.0000, 20.0000)
INSERT [dbo].[Pay] ([ID], [PersonID], [OverTime], [AttPay], [OtherPay]) VALUES (2, 1001, CAST(0x1E410B00 AS Date), 10.0000, 20.0000)
INSERT [dbo].[Pay] ([ID], [PersonID], [OverTime], [AttPay], [OtherPay]) VALUES (3, 1002, CAST(0x1E410B00 AS Date), 0.0000, 20.0000)
INSERT [dbo].[Pay] ([ID], [PersonID], [OverTime], [AttPay], [OtherPay]) VALUES (4, 1003, CAST(0x1E410B00 AS Date), 0.0000, 20.0000)
INSERT [dbo].[Pay] ([ID], [PersonID], [OverTime], [AttPay], [OtherPay]) VALUES (5, 1004, CAST(0x1E410B00 AS Date), 10.0000, 20.0000)
INSERT [dbo].[Pay] ([ID], [PersonID], [OverTime], [AttPay], [OtherPay]) VALUES (6, 1000, CAST(0x1F410B00 AS Date), 0.0000, 20.0000)
INSERT [dbo].[Pay] ([ID], [PersonID], [OverTime], [AttPay], [OtherPay]) VALUES (7, 1001, CAST(0x1F410B00 AS Date), 0.0000, 20.0000)
INSERT [dbo].[Pay] ([ID], [PersonID], [OverTime], [AttPay], [OtherPay]) VALUES (8, 1002, CAST(0x1F410B00 AS Date), 0.0000, 20.0000)
INSERT [dbo].[Pay] ([ID], [PersonID], [OverTime], [AttPay], [OtherPay]) VALUES (9, 1003, CAST(0x1F410B00 AS Date), 0.0000, 20.0000)
INSERT [dbo].[Pay] ([ID], [PersonID], [OverTime], [AttPay], [OtherPay]) VALUES (10, 1004, CAST(0x1F410B00 AS Date), 0.0000, 20.0000)
SET IDENTITY_INSERT [dbo].[Pay] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([ID], [Name], [Sex], [Age], [IDCard], [Address], [Native_place], [Phone], [Email], [DptID], [Diploma], [Major], [Remark]) VALUES (1000, N'张三', N'男', 20, N'400000200002023320', N'虚拟市虚拟区虚拟路22号', N'湖南省永州市', N'15273572761', N'15273572761@163.com', 101, N'大专', N'会计', N'喜欢打球')
INSERT [dbo].[Person] ([ID], [Name], [Sex], [Age], [IDCard], [Address], [Native_place], [Phone], [Email], [DptID], [Diploma], [Major], [Remark]) VALUES (1001, N'李琼', N'女', 19, N'400000200106013321', N'虚拟市虚拟区虚拟路55号', N'湖南省长沙市', N'15273572762', N'15273572762@163.com', 101, N'大专', N'会计', N'听歌')
INSERT [dbo].[Person] ([ID], [Name], [Sex], [Age], [IDCard], [Address], [Native_place], [Phone], [Email], [DptID], [Diploma], [Major], [Remark]) VALUES (1002, N'王五', N'男', 18, N'400000200212023322', N'虚拟市虚拟区虚拟路33号', N'湖南省岳阳市', N'15273572763', N'15273572763@163.com', 102, N'本科', N'软件技术', N'交朋友')
INSERT [dbo].[Person] ([ID], [Name], [Sex], [Age], [IDCard], [Address], [Native_place], [Phone], [Email], [DptID], [Diploma], [Major], [Remark]) VALUES (1003, N'赵茜', N'女', 21, N'400000199911113323', N'虚拟市虚拟区虚拟路11号', N'湖南省益阳市', N'15273572764', N'15273572764@163.com', 100, N'本科', N'软件技术', N'跳舞，敲代码')
INSERT [dbo].[Person] ([ID], [Name], [Sex], [Age], [IDCard], [Address], [Native_place], [Phone], [Email], [DptID], [Diploma], [Major], [Remark]) VALUES (1004, N'陈七', N'男', 20, N'400000200008153324', N'虚拟市虚拟区虚拟路44号', N'湖南省郴州市', N'15273572765', N'15273572765@163.com', 102, N'大专', N'资源管理', N'无')
INSERT [dbo].[Person] ([ID], [Name], [Sex], [Age], [IDCard], [Address], [Native_place], [Phone], [Email], [DptID], [Diploma], [Major], [Remark]) VALUES (1005, N'王七', N'男', 20, N'400000200011043232', N'虚拟市虚拟区虚拟路10号', N'湖南省湘潭市', N'15273572222', N'15273572222@163.com', 100, N'本科', N'软件技术', N'无')
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Reward] ON 

INSERT [dbo].[Reward] ([ID], [PersonID], [Topic], [RewardType], [RewardTime], [RewardGift]) VALUES (1, 1003, N'拾金不昧', N'奖励', CAST(0x0000ABC500A4CB80 AS DateTime), N'奖励：布娃娃一个')
INSERT [dbo].[Reward] ([ID], [PersonID], [Topic], [RewardType], [RewardTime], [RewardGift]) VALUES (2, 1000, N'上班迟到', N'惩罚', CAST(0x0000ABC600A4CB80 AS DateTime), N'惩罚：100元，充公')
INSERT [dbo].[Reward] ([ID], [PersonID], [Topic], [RewardType], [RewardTime], [RewardGift]) VALUES (3, 1004, N'帮助其他人收拾桌面', N'奖励', CAST(0x0000ABC500A4CB80 AS DateTime), N'奖励：大份零食')
SET IDENTITY_INSERT [dbo].[Reward] OFF
SET IDENTITY_INSERT [dbo].[Train] ON 

INSERT [dbo].[Train] ([ID], [Topic], [StartTime], [EndTime], [Site], [Number]) VALUES (1, N'提升相关技术', CAST(0x0000ABC200C5C100 AS DateTime), CAST(0x0000ABC3016A8C80 AS DateTime), N'虚拟室101号', N'王五,赵茜')
INSERT [dbo].[Train] ([ID], [Topic], [StartTime], [EndTime], [Site], [Number]) VALUES (2, N'人员的相关管理', CAST(0x0000ABC1009450C0 AS DateTime), CAST(0x0000ABC1016A8C80 AS DateTime), N'虚拟室101号', N'陈七')
SET IDENTITY_INSERT [dbo].[Train] OFF
SET IDENTITY_INSERT [dbo].[UserT] ON 

INSERT [dbo].[UserT] ([ID], [PersonID], [UserName], [UserPwd]) VALUES (1, 1000, N'san', N'112233')
INSERT [dbo].[UserT] ([ID], [PersonID], [UserName], [UserPwd]) VALUES (2, 1001, N'qiong', N'111111')
INSERT [dbo].[UserT] ([ID], [PersonID], [UserName], [UserPwd]) VALUES (3, 1002, N'wu', N'333333')
INSERT [dbo].[UserT] ([ID], [PersonID], [UserName], [UserPwd]) VALUES (4, 1003, N'qian', N'222222')
INSERT [dbo].[UserT] ([ID], [PersonID], [UserName], [UserPwd]) VALUES (5, 1004, N'qi', N'666666')
INSERT [dbo].[UserT] ([ID], [PersonID], [UserName], [UserPwd]) VALUES (6, 0, N'si', N'222222')
INSERT [dbo].[UserT] ([ID], [PersonID], [UserName], [UserPwd]) VALUES (7, 0, N'liqian', N'888888')
INSERT [dbo].[UserT] ([ID], [PersonID], [UserName], [UserPwd]) VALUES (8, 0, N'wangqi', N'999999')
INSERT [dbo].[UserT] ([ID], [PersonID], [UserName], [UserPwd]) VALUES (9, 0, N'kaidi', N'696969')
SET IDENTITY_INSERT [dbo].[UserT] OFF
ALTER TABLE [dbo].[A_P_Message] ADD  DEFAULT ('0') FOR [State]
GO
ALTER TABLE [dbo].[Employment] ADD  DEFAULT ('0') FOR [State]
GO
ALTER TABLE [dbo].[Employment] ADD  DEFAULT ('0') FOR [DeleteRecord]
GO
ALTER TABLE [dbo].[A_P_Message]  WITH CHECK ADD FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[A_U_Message]  WITH CHECK ADD FOREIGN KEY([EpmID])
REFERENCES [dbo].[Employment] ([ID])
GO
ALTER TABLE [dbo].[A_U_Message]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[UserT] ([ID])
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[Board]  WITH CHECK ADD FOREIGN KEY([AdminID])
REFERENCES [dbo].[AdminT] ([ID])
GO
ALTER TABLE [dbo].[Pay]  WITH CHECK ADD FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD FOREIGN KEY([DptID])
REFERENCES [dbo].[Department] ([ID])
GO
ALTER TABLE [dbo].[Reward]  WITH CHECK ADD FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
USE [master]
GO
ALTER DATABASE [PersonManagement] SET  READ_WRITE 
GO
