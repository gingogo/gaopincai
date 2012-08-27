CREATE TABLE [dbo].[DwNumber](
	[P] [bigint] NOT NULL,
	[D5] [int] NOT NULL,
	[D4] [int] NOT NULL,
	[D3] [int] NOT NULL,
	[D2] [int] NOT NULL,
	[D1] [int] NOT NULL,
	[P2] [char](2) NOT NULL,
	[C2] [char](2) NOT NULL,
	[P3] [char](3) NOT NULL,
	[C3] [char](3) NOT NULL,
	[P4] [char](4) NOT NULL,
	[P5] [char](5) NOT NULL,
	[N] [int] NOT NULL,
	[Seq] [int] NOT NULL,
	[Date] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_DwNumber_P] PRIMARY KEY CLUSTERED 
(
	[P] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO