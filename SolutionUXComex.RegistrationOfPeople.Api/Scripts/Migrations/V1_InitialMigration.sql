USE [rodrigofurlaneti3108_Finance]

CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](20) NULL,
	[Cpf] [nvarchar](14) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Persons] ADD  DEFAULT (getdate()) FOR [CreatedAt]

ALTER TABLE [dbo].[Persons] ADD  DEFAULT (getdate()) FOR [UpdatedAt]

ALTER TABLE [dbo].[Persons] ADD  DEFAULT ((1)) FOR [Active]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[ZipCode] [nvarchar](10) NULL,
	[Address] [nvarchar](255) NULL,
	[Number] [nvarchar](10) NULL,
	[Complement] [nvarchar](255) NULL,
	[Neighborhood] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[State] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Persons]