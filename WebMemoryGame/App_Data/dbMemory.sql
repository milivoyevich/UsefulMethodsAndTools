
GO
/****** Object:  Table [dbo].[mem_korisnici]    Script Date: 04.04.2018. 16:25:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mem_korisnici](
	[Id] [int] NOT NULL,
	[username] [nchar](20) NOT NULL,
	[password] [nchar](40) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[fullname] [nchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mem_rezultati]    Script Date: 04.04.2018. 16:25:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mem_rezultati](
	[Id] [bigint] NOT NULL,
	[idKorisnika] [int] NULL,
	[vreme] [int] NULL,
	[pocetak] [datetime2](7) NULL,
	[kraj] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
