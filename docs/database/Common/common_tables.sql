CREATE TABLE [dbo].[Category](
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
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Category_DbName] UNIQUE NONCLUSTERED 
(
	[DbName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Category_Code] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO

ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Seq]  DEFAULT ((10)) FOR [Seq]
GO

ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Enabled]  DEFAULT ((0)) FOR [Enabled]
GO

ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_IsGP]  DEFAULT ((0)) FOR [IsGP]
GO

ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Created]  DEFAULT (getdate()) FOR [Created]
GO