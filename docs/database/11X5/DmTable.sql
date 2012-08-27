CREATE TABLE [dbo].[DmCategory](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[DbName] [varchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Peroid] [nvarchar](20) NOT NULL,
	[Seq] [int] NOT NULL,
	[Enabled] [tinyint] NOT NULL,
	[IsGP] [tinyint] NOT NULL,
	[DownPageIndex] [int] NOT NULL,
	[DownIntervals] [nvarchar](10) NOT NULL,
	[DownPeroid] [nvarchar](2) NOT NULL,
	[DownUrl] [varchar](200) NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_DmCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_DmCategory_DbName] UNIQUE NONCLUSTERED 
(
	[DbName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UKCategoryCode] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[DmCategory] ADD  CONSTRAINT [DF_DmCategory_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO

ALTER TABLE [dbo].[DmCategory] ADD  CONSTRAINT [DF_DmCategory_Seq]  DEFAULT ((10)) FOR [Seq]
GO

ALTER TABLE [dbo].[DmCategory] ADD  CONSTRAINT [DF_DmCategory_Enabled]  DEFAULT ((0)) FOR [Enabled]
GO

ALTER TABLE [dbo].[DmCategory] ADD  CONSTRAINT [DF_DmCategory_IsGP]  DEFAULT ((0)) FOR [IsGP]
GO

ALTER TABLE [dbo].[DmCategory] ADD  CONSTRAINT [DF_DmCategory_Created]  DEFAULT (getdate()) FOR [Created]
GO

CREATE TABLE [dbo].[DmDate](
	[Date] [int] NOT NULL,
	[Year] [int] NULL,
	[Month] [int] NULL,
	[Day] [int] NULL,
	[Week] [int] NULL,
	[Quantum] [int] NULL,
 CONSTRAINT [PK_DmDate] PRIMARY KEY CLUSTERED 
(
	[Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmD1](
	[Id] [varchar](2) NOT NULL,
	[Number] [char](2) NOT NULL,
	[DaXiao] [char](1) NOT NULL,
	[DanShuang] [char](1) NOT NULL,
	[ZiHe] [char](1) NOT NULL,
	[Lu012] [char](1) NOT NULL,
	[He] [int] NOT NULL,
	[HeWei] [int] NOT NULL,
	[DaCnt] [int] NOT NULL,
	[XiaoCnt] [int] NOT NULL,
	[DanCnt] [int] NOT NULL,
	[ShuangCnt] [int] NOT NULL,
	[ZiCnt] [int] NOT NULL,
	[HeCnt] [int] NOT NULL,
	[Lu0Cnt] [int] NOT NULL,
	[Lu1Cnt] [int] NOT NULL,
	[Lu2Cnt] [int] NOT NULL,
 CONSTRAINT [PK_DmD1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmF2](
	[Id] [char](4) NOT NULL,
	[Number] [char](5) NOT NULL,
	[DaXiao] [char](3) NOT NULL,
	[DanShuang] [char](3) NOT NULL,
	[ZiHe] [char](3) NOT NULL,
	[Lu012] [char](3) NOT NULL,
	[He] [int] NOT NULL,
	[HeWei] [int] NOT NULL,
	[DaCnt] [int] NOT NULL,
	[XiaoCnt] [int] NOT NULL,
	[DanCnt] [int] NOT NULL,
	[ShuangCnt] [int] NOT NULL,
	[ZiCnt] [int] NOT NULL,
	[HeCnt] [int] NOT NULL,
	[Lu0Cnt] [int] NOT NULL,
	[Lu1Cnt] [int] NOT NULL,
	[Lu2Cnt] [int] NOT NULL,
 CONSTRAINT [PK_DmF2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC2](
	[Id] [char](4) NOT NULL,
	[Number] [char](5) NOT NULL,
	[DaXiao] [char](3) NOT NULL,
	[DanShuang] [char](3) NOT NULL,
	[ZiHe] [char](3) NOT NULL,
	[Lu012] [char](3) NOT NULL,
	[He] [int] NOT NULL,
	[HeWei] [int] NOT NULL,
	[DaCnt] [int] NOT NULL,
	[XiaoCnt] [int] NOT NULL,
	[DanCnt] [int] NOT NULL,
	[ShuangCnt] [int] NOT NULL,
	[ZiCnt] [int] NOT NULL,
	[HeCnt] [int] NOT NULL,
	[Lu0Cnt] [int] NOT NULL,
	[Lu1Cnt] [int] NOT NULL,
	[Lu2Cnt] [int] NOT NULL,
 CONSTRAINT [PK_DmC2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmF3](
	[Id] [char](6) NOT NULL,
	[Number] [char](8) NOT NULL,
	[DaXiao] [char](5) NOT NULL,
	[DanShuang] [char](5) NOT NULL,
	[ZiHe] [char](5) NOT NULL,
	[Lu012] [char](5) NOT NULL,
	[He] [int] NOT NULL,
	[HeWei] [int] NOT NULL,
	[DaCnt] [int] NOT NULL,
	[XiaoCnt] [int] NOT NULL,
	[DanCnt] [int] NOT NULL,
	[ShuangCnt] [int] NOT NULL,
	[ZiCnt] [int] NOT NULL,
	[HeCnt] [int] NOT NULL,
	[Lu0Cnt] [int] NOT NULL,
	[Lu1Cnt] [int] NOT NULL,
	[Lu2Cnt] [int] NOT NULL,
 CONSTRAINT [PK_DmF3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC3](
	[Id] [char](6) NOT NULL,
	[Number] [char](8) NOT NULL,
	[DaXiao] [char](5) NOT NULL,
	[DanShuang] [char](5) NOT NULL,
	[ZiHe] [char](5) NOT NULL,
	[Lu012] [char](5) NOT NULL,
	[He] [int] NOT NULL,
	[HeWei] [int] NOT NULL,
	[DaCnt] [int] NOT NULL,
	[XiaoCnt] [int] NOT NULL,
	[DanCnt] [int] NOT NULL,
	[ShuangCnt] [int] NOT NULL,
	[ZiCnt] [int] NOT NULL,
	[HeCnt] [int] NOT NULL,
	[Lu0Cnt] [int] NOT NULL,
	[Lu1Cnt] [int] NOT NULL,
	[Lu2Cnt] [int] NOT NULL,
 CONSTRAINT [PK_DmC3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmA4](
	[Id] [char](8) NOT NULL,
	[Number] [char](11) NOT NULL,
	[DaXiao] [char](7) NOT NULL,
	[DanShuang] [char](7) NOT NULL,
	[ZiHe] [char](7) NOT NULL,
	[Lu012] [char](7) NOT NULL,
	[He] [int] NOT NULL,
	[HeWei] [int] NOT NULL,
	[DaCnt] [int] NOT NULL,
	[XiaoCnt] [int] NOT NULL,
	[DanCnt] [int] NOT NULL,
	[ShuangCnt] [int] NOT NULL,
	[ZiCnt] [int] NOT NULL,
	[HeCnt] [int] NOT NULL,
	[Lu0Cnt] [int] NOT NULL,
	[Lu1Cnt] [int] NOT NULL,
	[Lu2Cnt] [int] NOT NULL,
 CONSTRAINT [PK_DmA4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmA5](
	[Id] [char](10) NOT NULL,
	[Number] [char](14) NOT NULL,
	[DaXiao] [char](9) NOT NULL,
	[DanShuang] [char](9) NOT NULL,
	[ZiHe] [char](9) NOT NULL,
	[Lu012] [char](9) NOT NULL,
	[He] [int] NOT NULL,
	[HeWei] [int] NOT NULL,
	[DaCnt] [int] NOT NULL,
	[XiaoCnt] [int] NOT NULL,
	[DanCnt] [int] NOT NULL,
	[ShuangCnt] [int] NOT NULL,
	[ZiCnt] [int] NOT NULL,
	[HeCnt] [int] NOT NULL,
	[Lu0Cnt] [int] NOT NULL,
	[Lu1Cnt] [int] NOT NULL,
	[Lu2Cnt] [int] NOT NULL,
 CONSTRAINT [PK_DmA5] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmA6](
	[Id] [char](12) NOT NULL,
	[Number] [char](17) NOT NULL,
	[DaXiao] [char](11) NOT NULL,
	[DanShuang] [char](11) NOT NULL,
	[ZiHe] [char](11) NOT NULL,
	[Lu012] [char](11) NOT NULL,
	[He] [int] NOT NULL,
	[HeWei] [int] NOT NULL,
	[DaCnt] [int] NOT NULL,
	[XiaoCnt] [int] NOT NULL,
	[DanCnt] [int] NOT NULL,
	[ShuangCnt] [int] NOT NULL,
	[ZiCnt] [int] NOT NULL,
	[HeCnt] [int] NOT NULL,
	[Lu0Cnt] [int] NOT NULL,
	[Lu1Cnt] [int] NOT NULL,
	[Lu2Cnt] [int] NOT NULL,
 CONSTRAINT [PK_DmA6] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmA7](
	[Id] [char](14) NOT NULL,
	[Number] [char](20) NOT NULL,
	[DaXiao] [char](13) NOT NULL,
	[DanShuang] [char](13) NOT NULL,
	[ZiHe] [char](13) NOT NULL,
	[Lu012] [char](13) NOT NULL,
	[He] [int] NOT NULL,
	[HeWei] [int] NOT NULL,
	[DaCnt] [int] NOT NULL,
	[XiaoCnt] [int] NOT NULL,
	[DanCnt] [int] NOT NULL,
	[ShuangCnt] [int] NOT NULL,
	[ZiCnt] [int] NOT NULL,
	[HeCnt] [int] NOT NULL,
	[Lu0Cnt] [int] NOT NULL,
	[Lu1Cnt] [int] NOT NULL,
	[Lu2Cnt] [int] NOT NULL,
 CONSTRAINT [PK_DmA7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmA8](
	[Id] [char](16) NOT NULL,
	[Number] [char](23) NOT NULL,
	[DaXiao] [char](15) NOT NULL,
	[DanShuang] [char](15) NOT NULL,
	[ZiHe] [char](15) NOT NULL,
	[Lu012] [char](15) NOT NULL,
	[He] [int] NOT NULL,
	[HeWei] [int] NOT NULL,
	[DaCnt] [int] NOT NULL,
	[XiaoCnt] [int] NOT NULL,
	[DanCnt] [int] NOT NULL,
	[ShuangCnt] [int] NOT NULL,
	[ZiCnt] [int] NOT NULL,
	[HeCnt] [int] NOT NULL,
	[Lu0Cnt] [int] NOT NULL,
	[Lu1Cnt] [int] NOT NULL,
	[Lu2Cnt] [int] NOT NULL,
 CONSTRAINT [PK_DmA8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO