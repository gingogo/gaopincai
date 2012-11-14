CREATE TABLE [dbo].[DwNumber](
	[P] [bigint] NOT NULL,
	[D1] [int] NOT NULL,
	[D2] [int] NOT NULL,
	[D3] [int] NOT NULL,
	[D4] [int] NOT NULL,
	[D5] [int] NOT NULL,
	[P2] [char](4) NOT NULL,
	[C2] [char](4) NOT NULL,
	[P3] [char](6) NOT NULL,
	[C3] [char](6) NOT NULL,
	[P5] [char](10) NOT NULL,
	[C5] [char](10) NOT NULL,
	[N] [int] NOT NULL,
	[Seq] [int] NOT NULL,
	[Date] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_DwNumber_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----------------------span tables----------------------------------

CREATE TABLE [dbo].[DwPeroidSpan](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL,
	[D2Spans] [int] NOT NULL,
	[D3Spans] [int] NOT NULL,
	[D4Spans] [int] NOT NULL,
	[D5Spans] [int] NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwPeroidSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DwDaXiaoSpan](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL,
	[D2Spans] [int] NOT NULL,
	[D3Spans] [int] NOT NULL,
	[D4Spans] [int] NOT NULL,
	[D5Spans] [int] NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwDaXiaoSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwDanShuangSpan](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL,
	[D2Spans] [int] NOT NULL,
	[D3Spans] [int] NOT NULL,
	[D4Spans] [int] NOT NULL,
	[D5Spans] [int] NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwDanShuangSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwZiHeSpan](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL,
	[D2Spans] [int] NOT NULL,
	[D3Spans] [int] NOT NULL,
	[D4Spans] [int] NOT NULL,
	[D5Spans] [int] NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwZiHeSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwLu012Span](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL,
	[D2Spans] [int] NOT NULL,
	[D3Spans] [int] NOT NULL,
	[D4Spans] [int] NOT NULL,
	[D5Spans] [int] NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwLu012Span_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwHeSpan](
	[P] [bigint]  NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwHeSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwHeWeiSpan](
	[P] [bigint]  NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwHeWeiSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwJiSpan](
	[P] [bigint]  NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwJiSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwJiWeiSpan](
	[P] [bigint]  NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwJiWeiSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwKuaDuSpan](
	[P] [bigint]  NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwKuaDuSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwACSpan](
	[P] [bigint]  NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwACSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwDaXiaoBiSpan](
	[P] [bigint]  NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwDaXiaoBiSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DwZiHeBiSpan](
	[P] [bigint]  NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwZiHeBiSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DwDanShuangBiSpan](
	[P] [bigint]  NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwDanShuangBiSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DwLu012BiSpan](
	[P] [bigint]  NOT NULL,
	[P2Spans] [int] NOT NULL,
	[C2Spans] [int] NOT NULL,
	[P3Spans] [int] NOT NULL,
	[C3Spans] [int] NOT NULL,
	[C5Spans] [int] NOT NULL
 CONSTRAINT [PK_DwLu012BiSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----------------------------------------------dimension tables ------------------------------------

CREATE TABLE [dbo].[DmDX](
	[Id] [char](2) NOT NULL,
	[NumberType] [char](2) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL,
	[DaXiaoBi] [char](3) NOT NULL,
	[ZiHeBi] [char](3) NOT NULL,
	[DanShuangBi] [char](3) NOT NULL,
	[Lu012Bi] [char](5) NOT NULL
 CONSTRAINT [PK_DmDx] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmP2](
	[Id] [char](4) NOT NULL,
	[NumberType] [char](2) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL,
	[DaXiaoBi] [char](3) NOT NULL,
	[ZiHeBi] [char](3) NOT NULL,
	[DanShuangBi] [char](3) NOT NULL,
	[Lu012Bi] [char](5) NOT NULL
 CONSTRAINT [PK_DmP2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC2](
	[Id] [char](4) NOT NULL,
	[NumberType] [char](2) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL,
	[DaXiaoBi] [char](3) NOT NULL,
	[ZiHeBi] [char](3) NOT NULL,
	[DanShuangBi] [char](3) NOT NULL,
	[Lu012Bi] [char](5) NOT NULL
 CONSTRAINT [PK_DmC2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmP3](
	[Id] [char](6) NOT NULL,
	[NumberType] [char](2) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL,
	[DaXiaoBi] [char](3) NOT NULL,
	[ZiHeBi] [char](3) NOT NULL,
	[DanShuangBi] [char](3) NOT NULL,
	[Lu012Bi] [char](5) NOT NULL
 CONSTRAINT [PK_DmP3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC3](
	[Id] [char](6) NOT NULL,
	[NumberType] [char](2) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL,
	[DaXiaoBi] [char](3) NOT NULL,
	[ZiHeBi] [char](3) NOT NULL,
	[DanShuangBi] [char](3) NOT NULL,
	[Lu012Bi] [char](5) NOT NULL
 CONSTRAINT [PK_DmC3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC4](
	[Id] [char](8) NOT NULL,
	[NumberType] [char](2) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL,
	[DaXiaoBi] [char](3) NOT NULL,
	[ZiHeBi] [char](3) NOT NULL,
	[DanShuangBi] [char](3) NOT NULL,
	[Lu012Bi] [char](5) NOT NULL
 CONSTRAINT [PK_DmC4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC5](
	[Id] [char](10) NOT NULL,
	[NumberType] [char](2) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL,
	[DaXiaoBi] [char](3) NOT NULL,
	[ZiHeBi] [char](3) NOT NULL,
	[DanShuangBi] [char](3) NOT NULL,
	[Lu012Bi] [char](5) NOT NULL
 CONSTRAINT [PK_DmC5] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC6](
	[Id] [char](12) NOT NULL,
	[NumberType] [char](2) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL,
	[DaXiaoBi] [char](3) NOT NULL,
	[ZiHeBi] [char](3) NOT NULL,
	[DanShuangBi] [char](3) NOT NULL,
	[Lu012Bi] [char](5) NOT NULL
 CONSTRAINT [PK_DmC6] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC7](
	[Id] [char](14) NOT NULL,
	[NumberType] [char](2) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL,
	[DaXiaoBi] [char](3) NOT NULL,
	[ZiHeBi] [char](3) NOT NULL,
	[DanShuangBi] [char](3) NOT NULL,
	[Lu012Bi] [char](5) NOT NULL
 CONSTRAINT [PK_DmC7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC8](
	[Id] [char](16) NOT NULL,
	[NumberType] [char](2) NOT NULL,
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
	[Ji] [int] NOT NULL,
	[JiWei] [int] NOT NULL,
	[KuaDu] [int] NOT NULL,
	[AC] [int] NOT NULL,
	[DaXiaoBi] [char](3) NOT NULL,
	[ZiHeBi] [char](3) NOT NULL,
	[DanShuangBi] [char](3) NOT NULL,
	[Lu012Bi] [char](5) NOT NULL
 CONSTRAINT [PK_DmC8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DmC5CX] (
[C5] char(10) NOT NULL ,
[CX] varchar(16) NOT NULL ,
[C5Number] char(14) NOT NULL ,
[CXNumber] varchar(23) NOT NULL ,
[NumberType] char(2) NOT NULL 
)
ALTER TABLE [dbo].[DmC5CX] ADD PRIMARY KEY ([CX], [C5])

GO

CREATE TABLE [dbo].[DwC5C2Span] (
[P] bigint NOT NULL ,
[C5] char(10) NOT NULL ,
[CX] char(4) NOT NULL ,
[Seq] int NOT NULL,
[PeroidSpans] int NOT NULL,
[HeSpans] int NOT NULL  
)
ALTER TABLE [dbo].[DwC5C2Span] ADD PRIMARY KEY ([CX], [C5], [P])
GO

CREATE TABLE [dbo].[DwC5C3Span] (
[P] bigint NOT NULL ,
[C5] char(10) NOT NULL ,
[CX] char(6) NOT NULL ,
[Seq] int NOT NULL,
[PeroidSpans] int NOT NULL,
[HeSpans] int NOT NULL  
)
ALTER TABLE [dbo].[DwC5C3Span] ADD PRIMARY KEY ([CX], [C5], [P])
GO

CREATE TABLE [dbo].[DwC5C4Span] (
[P] bigint NOT NULL ,
[C5] char(10) NOT NULL ,
[CX] char(8) NOT NULL ,
[Seq] int NOT NULL,
[PeroidSpans] int NOT NULL,
[HeSpans] int NOT NULL  
)
ALTER TABLE [dbo].[DwC5C4Span] ADD PRIMARY KEY ([CX], [C5], [P])
GO

CREATE TABLE [dbo].[DwC5C6Span] (
[P] bigint NOT NULL ,
[C5] char(10) NOT NULL ,
[CX] char(12) NOT NULL ,
[Seq] int NOT NULL,
[PeroidSpans] int NOT NULL,
[HeSpans] int NOT NULL  
)
ALTER TABLE [dbo].[DwC5C6Span] ADD PRIMARY KEY ([CX], [C5], [P])
GO


CREATE TABLE [dbo].[DwC5C7Span] (
[P] bigint NOT NULL ,
[C5] char(10) NOT NULL ,
[CX] char(14) NOT NULL ,
[Seq] int NOT NULL,
[PeroidSpans] int NOT NULL,
[HeSpans] int NOT NULL  
)
ALTER TABLE [dbo].[DwC5C7Span] ADD PRIMARY KEY ([CX], [C5], [P])
GO


CREATE TABLE [dbo].[DwC5C8Span] (
[P] bigint NOT NULL ,
[C5] char(10) NOT NULL ,
[CX] char(16) NOT NULL ,
[Seq] int NOT NULL,
[PeroidSpans] int NOT NULL,
[HeSpans] int NOT NULL 
)
ALTER TABLE [dbo].[DwC5C8Span] ADD PRIMARY KEY ([CX], [C5], [P])
GO
