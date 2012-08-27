CREATE TABLE [dbo].[DwNumber](
	[P] [bigint] NOT NULL,
	[D1] [int] NOT NULL,
	[D2] [int] NOT NULL,
	[D3] [int] NOT NULL,
	[D4] [int] NOT NULL,
	[D5] [int] NOT NULL,
	[F2] [char](4) NOT NULL,
	[C2] [char](4) NOT NULL,
	[F3] [char](6) NOT NULL,
	[C3] [char](6) NOT NULL,
	[F5] [char](10) NOT NULL,
	[A5] [char](10) NOT NULL,
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