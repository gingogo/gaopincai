CREATE TABLE [dbo].[DwPeroidSpan](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL default -2,
	[F2Spans] [int] NOT NULL default -2,
	[F3Spans] [int] NOT NULL default -2,
	[C2Spans] [int] NOT NULL default -2,
	[C3Spans] [int] NOT NULL default -2,
	[A5Spans] [int] NOT NULL default -2
 CONSTRAINT [PK_DwPeroidSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DwHeSpan](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL default -2,
	[F2Spans] [int] NOT NULL default -2,
	[F3Spans] [int] NOT NULL default -2,
	[C2Spans] [int] NOT NULL default -2,
	[C3Spans] [int] NOT NULL default -2,
	[A5Spans] [int] NOT NULL default -2
 CONSTRAINT [PK_DwHeSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwHeWeiSpan](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL default -2,
	[F2Spans] [int] NOT NULL default -2,
	[F3Spans] [int] NOT NULL default -2,
	[C2Spans] [int] NOT NULL default -2,
	[C3Spans] [int] NOT NULL default -2,
	[A5Spans] [int] NOT NULL default -2
 CONSTRAINT [PK_DwHeWeiSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwDaXiaoSpan](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL default -2,
	[F2Spans] [int] NOT NULL default -2,
	[F3Spans] [int] NOT NULL default -2,
	[C2Spans] [int] NOT NULL default -2,
	[C3Spans] [int] NOT NULL default -2,
	[A5Spans] [int] NOT NULL default -2
 CONSTRAINT [PK_DwDaXiaoSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwDanShuangSpan](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL default -2,
	[F2Spans] [int] NOT NULL default -2,
	[F3Spans] [int] NOT NULL default -2,
	[C2Spans] [int] NOT NULL default -2,
	[C3Spans] [int] NOT NULL default -2,
	[A5Spans] [int] NOT NULL default -2
 CONSTRAINT [PK_DwDanShuangSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwZiHeSpan](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL default -2,
	[F2Spans] [int] NOT NULL default -2,
	[F3Spans] [int] NOT NULL default -2,
	[C2Spans] [int] NOT NULL default -2,
	[C3Spans] [int] NOT NULL default -2,
	[A5Spans] [int] NOT NULL default -2
 CONSTRAINT [PK_DwZiHeSpan_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DwLu012Span](
	[P] [bigint]  NOT NULL,
	[D1Spans] [int] NOT NULL default -2,
	[F2Spans] [int] NOT NULL default -2,
	[F3Spans] [int] NOT NULL default -2,
	[C2Spans] [int] NOT NULL default -2,
	[C3Spans] [int] NOT NULL default -2,
	[A5Spans] [int] NOT NULL default -2
 CONSTRAINT [PK_DwLu012Span_P] PRIMARY KEY CLUSTERED 
(
	[P] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

