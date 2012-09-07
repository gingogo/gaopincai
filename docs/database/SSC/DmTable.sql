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
	[Id] [char](1) NOT NULL,
	[Number] [char](1) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL default 0
 CONSTRAINT [PK_DmF1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmP2](
	[Id] [char](2) NOT NULL,
	[Number] [char](3) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL default 0
 CONSTRAINT [PK_DmP2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC2](
	[Id] [char](2) NOT NULL,
	[Number] [char](3) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL default 0
 CONSTRAINT [PK_DmC2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmP3](
	[Id] [char](3) NOT NULL,
	[Number] [char](5) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL default 0
 CONSTRAINT [PK_DmP3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC3](
	[Id] [char](3) NOT NULL,
	[Number] [char](5) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL default 0
 CONSTRAINT [PK_DmC3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC33](
	[Id] [char](3) NOT NULL,
	[Number] [char](5) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL default 0
 CONSTRAINT [PK_DmC33] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC36](
	[Id] [char](3) NOT NULL,
	[Number] [char](5) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL default 0
 CONSTRAINT [PK_DmC36] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[DmP4](
	[Id] [char](4) NOT NULL,
	[Number] [char](7) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL default 0
 CONSTRAINT [PK_DmP4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmP5](
	[Id] [char](5) NOT NULL,
	[Number] [char](9) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL default 0
 CONSTRAINT [PK_DmP5] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO