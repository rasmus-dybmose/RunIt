/****** Object:  Table [dbo].[tblBeskeder]    Script Date: 02-09-2016 11:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblBeskeder](
	[fldID] [int] IDENTITY(1,1) NOT NULL,
	[fldNavn] [varchar](150) NOT NULL,
	[fldEmail] [varchar](150) NOT NULL,
	[fldEmne] [varchar](100) NOT NULL,
	[fldBesked] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_tblBeskeder] PRIMARY KEY CLUSTERED 
(
	[fldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEmailSys]    Script Date: 02-09-2016 11:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmailSys](
	[fldID] [int] IDENTITY(1,1) NOT NULL,
	[fldEmail] [varchar](100) NOT NULL,
	[fldPassword] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tblEmailSys] PRIMARY KEY CLUSTERED 
(
	[fldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEvents]    Script Date: 02-09-2016 11:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEvents](
	[fldID] [int] IDENTITY(1,1) NOT NULL,
	[fldTitle] [varchar](50) NOT NULL,
	[fldBeskrivelse] [varchar](5000) NOT NULL,
	[fldDistance] [float] NOT NULL,
	[fldPris] [smallint] NOT NULL,
	[fldImg] [varchar](50) NOT NULL,
	[fldPladser] [smallint] NOT NULL,
	[fldDato] [datetime] NULL,
	[fldTeaser] [varchar](1000) NULL,
	[fldRegionFK] [smallint] NULL,
 CONSTRAINT [PK_tblEvents] PRIMARY KEY CLUSTERED 
(
	[fldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblKategori]    Script Date: 02-09-2016 11:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblKategori](
	[fldID] [int] IDENTITY(1,1) NOT NULL,
	[fldKategori] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblKategori] PRIMARY KEY CLUSTERED 
(
	[fldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblKontakt]    Script Date: 02-09-2016 11:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblKontakt](
	[fldID] [int] IDENTITY(1,1) NOT NULL,
	[fldNavn] [varchar](50) NOT NULL,
	[fldBeskrivelse] [varchar](500) NOT NULL,
	[fldPost] [varchar](50) NOT NULL,
	[fldImg] [varchar](50) NOT NULL,
	[fldEmail] [varchar](50) NULL,
 CONSTRAINT [PK_tblKontakt] PRIMARY KEY CLUSTERED 
(
	[fldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblNyhedsbrev]    Script Date: 02-09-2016 11:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNyhedsbrev](
	[fldID] [int] IDENTITY(1,1) NOT NULL,
	[fldEmail] [varchar](150) NOT NULL,
	[fldEmailString] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tblNyhedsbrev] PRIMARY KEY CLUSTERED 
(
	[fldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblRegion]    Script Date: 02-09-2016 11:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRegion](
	[fldID] [int] IDENTITY(1,1) NOT NULL,
	[fldRegion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblRegion] PRIMARY KEY CLUSTERED 
(
	[fldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSponsore]    Script Date: 02-09-2016 11:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSponsore](
	[fldID] [int] IDENTITY(1,1) NOT NULL,
	[fldSponsore] [varchar](50) NOT NULL,
	[fldImg] [varchar](50) NOT NULL,
	[fldKatFk] [tinyint] NOT NULL,
 CONSTRAINT [PK_tblSponsore] PRIMARY KEY CLUSTERED 
(
	[fldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTilmeldte]    Script Date: 02-09-2016 11:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTilmeldte](
	[fldID] [int] IDENTITY(1,1) NOT NULL,
	[fldEmail] [varchar](150) NOT NULL,
	[fldEventFK] [int] NOT NULL,
 CONSTRAINT [PK_tblTilmeldte] PRIMARY KEY CLUSTERED 
(
	[fldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 02-09-2016 11:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
	[fldID] [int] IDENTITY(1,1) NOT NULL,
	[fldUserName] [nvarchar](100) NOT NULL,
	[fldPassword] [nvarchar](100) NOT NULL,
	[fldSalt] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[fldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tblBeskeder] ON 

INSERT [dbo].[tblBeskeder] ([fldID], [fldNavn], [fldEmail], [fldEmne], [fldBesked]) VALUES (1, N'Rasmus', N'rasmus.dybmose@hotmail.com', N'emne', N'testtest')
INSERT [dbo].[tblBeskeder] ([fldID], [fldNavn], [fldEmail], [fldEmne], [fldBesked]) VALUES (2, N'Rasmus', N'rasmus.dybmose@hotmail.com', N'emne', N'testtest')
SET IDENTITY_INSERT [dbo].[tblBeskeder] OFF
SET IDENTITY_INSERT [dbo].[tblEmailSys] ON 

INSERT [dbo].[tblEmailSys] ([fldID], [fldEmail], [fldPassword]) VALUES (1, N'groennegaard.developer@gmail.com', N'dybmose18')
SET IDENTITY_INSERT [dbo].[tblEmailSys] OFF
SET IDENTITY_INSERT [dbo].[tblEvents] ON 

INSERT [dbo].[tblEvents] ([fldID], [fldTitle], [fldBeskrivelse], [fldDistance], [fldPris], [fldImg], [fldPladser], [fldDato], [fldTeaser], [fldRegionFK]) VALUES (1, N'FOREST to THE BAY', N'KOM med til det mest fantastiske løb i GateWay Blokhus i Påsken! Du kommer til at løbe i det smukkeste og mest afvekslende løbeterræn i vel nok Danmarks bedste GateWay - vi garanterer, at du kan boltre dig i skovområder, ad snoede stier og på den smukke hvide strand på de lange distancer! Ta´ gerne familien med ud og løbe! Lad børnene boltre sig på den store naturlegeplads når de har løbet og mens du selv løber. Naturlegepladsen ligger i forlængelse af stævneområdet i skovens kuperede terræn og under susende trækroner!', 5.4, 250, N'FOREST to THE BAY.jpg', 70, CAST(N'2016-08-30T10:00:00.000' AS DateTime), N'KOM med til det mest fantastiske løb i GateWay Blokhus i Påsken! Du kommer til at løbe i det smukkeste og mest afvekslende løbeterræn i vel nok Danmarks bedste GateWay - vi garanterer, at du kan boltre dig i skovområder, ad snoede stier og på den smukke hvide strand på de lange distancer!', 2)
INSERT [dbo].[tblEvents] ([fldID], [fldTitle], [fldBeskrivelse], [fldDistance], [fldPris], [fldImg], [fldPladser], [fldDato], [fldTeaser], [fldRegionFK]) VALUES (2, N'Egå Engsø Løbet', N'Løb rundt om den smukke Egå Engsø påskemandag 28. marts 2016. Motionsløb for hygge- og hurtigløbere mulighed for PR! Familievenligt løb med påskeæg til de første 150 børn under 15 år over målstregen Elektronisk tidtagning Gratis buff tube til alle voksne tilmeldte', 10, 100, N'Egå Engsø Løbet.jpg', 30, CAST(N'2016-08-30T16:30:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[tblEvents] ([fldID], [fldTitle], [fldBeskrivelse], [fldDistance], [fldPris], [fldImg], [fldPladser], [fldDato], [fldTeaser], [fldRegionFK]) VALUES (3, N'Ultraløbet Fyr til Fyr', N'Danmarks smukkeste ultraløb på langs af Bornholm går fra Dueodde Fyr i syd til målet ved Hammer Fyr på øens nordende. Undervejs kommer løberne forbi Svaneke Fyr og Hammerodde Fyr samt de to depoter i Svaneke og Gudhjem. Ruten på 60 km følger den gamle redningssti langs med østkysten.', 60, 350, N'Ultraløbet Fyr til Fyr.jpg', 50, CAST(N'2016-09-04T09:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[tblEvents] ([fldID], [fldTitle], [fldBeskrivelse], [fldDistance], [fldPris], [fldImg], [fldPladser], [fldDato], [fldTeaser], [fldRegionFK]) VALUES (4, N'Skov løbet Skanderborg', N'Igen i år indbyder Skanderborg Løbeklub til en smuk og varieret løbetur på 7,5 km i Vestermølleskoven og Skvæt skoven søndag 10. april. En del af ruten løbes på smalle stier, skrappe stigninger og trapper og løberne kan blandt andet prøve kræfter med udfordringerne ', 7.5, 80, N'Skov løbet Skanderborg.jpg', 22, CAST(N'2016-10-10T13:00:00.000' AS DateTime), NULL, 3)
INSERT [dbo].[tblEvents] ([fldID], [fldTitle], [fldBeskrivelse], [fldDistance], [fldPris], [fldImg], [fldPladser], [fldDato], [fldTeaser], [fldRegionFK]) VALUES (20, N'tset', N'test', 22, 44, N'bg8_1609020954503714.jpg', 33, CAST(N'2016-09-22T07:30:00.000' AS DateTime), N'etst', 3)
SET IDENTITY_INSERT [dbo].[tblEvents] OFF
SET IDENTITY_INSERT [dbo].[tblKategori] ON 

INSERT [dbo].[tblKategori] ([fldID], [fldKategori]) VALUES (1, N'Guld')
INSERT [dbo].[tblKategori] ([fldID], [fldKategori]) VALUES (2, N'Sølv')
INSERT [dbo].[tblKategori] ([fldID], [fldKategori]) VALUES (3, N'Allmindelig')
SET IDENTITY_INSERT [dbo].[tblKategori] OFF
SET IDENTITY_INSERT [dbo].[tblKontakt] ON 

INSERT [dbo].[tblKontakt] ([fldID], [fldNavn], [fldBeskrivelse], [fldPost], [fldImg], [fldEmail]) VALUES (1, N'Jens Kr. Larsen', N'Hovedbestyrelsesmøder, Modtagelse/distribution af div. post, kataloger og blade,Annoncering/tilrettelæggelse af generalforsamling, Dagsorden til bestyrelsesmøder, Planlægning af møder', N'Formand', N'jens.png', N'jens@runit.dk')
INSERT [dbo].[tblKontakt] ([fldID], [fldNavn], [fldBeskrivelse], [fldPost], [fldImg], [fldEmail]) VALUES (2, N'Claus Jensen', N'Formandens højre hånd “stand-in”', N'Næstformand', N'claus.png', N'claus@runit.dk')
INSERT [dbo].[tblKontakt] ([fldID], [fldNavn], [fldBeskrivelse], [fldPost], [fldImg], [fldEmail]) VALUES (3, N'Christian Nielsen', N'Skriver referat af alle møder og sørger for udsendelse inden 8 dage ,Protokolføring ,Ajourføring af adresseliste over instruktører/bestyrelsesmedlemmer ,Udsendelse af mødeindkaldelser ', N'Sekretær', N'christian.png', N'christian@runit.dk')
INSERT [dbo].[tblKontakt] ([fldID], [fldNavn], [fldBeskrivelse], [fldPost], [fldImg], [fldEmail]) VALUES (4, N'Jørgen Svensen', N'Lønregnskab + udbetaling af løn Betaling af udgifter Bogføring af indtægter og udgifter Årsregnskab Revisorkontakt Løbende kontrol med økonomien Told og Skat', N'Kasserer', N'joergen.png', N'jørgen@runit.dk')
INSERT [dbo].[tblKontakt] ([fldID], [fldNavn], [fldBeskrivelse], [fldPost], [fldImg], [fldEmail]) VALUES (5, N'Karen Karlsen', N'Bestyrelsesmedlem', N'NULLBestyrelsesmedlem', N'karen.png', N'karen@runit.dk')
INSERT [dbo].[tblKontakt] ([fldID], [fldNavn], [fldBeskrivelse], [fldPost], [fldImg], [fldEmail]) VALUES (7, N'Lene Johansen', N'Bestyrelsesmedlem', N'Bestyrelsesmedlem', N'lene.png', N'lene@runit.dk')
SET IDENTITY_INSERT [dbo].[tblKontakt] OFF
SET IDENTITY_INSERT [dbo].[tblRegion] ON 

INSERT [dbo].[tblRegion] ([fldID], [fldRegion]) VALUES (1, N'MidtJylland')
INSERT [dbo].[tblRegion] ([fldID], [fldRegion]) VALUES (2, N'NordJylland')
INSERT [dbo].[tblRegion] ([fldID], [fldRegion]) VALUES (3, N'Bornholm')
SET IDENTITY_INSERT [dbo].[tblRegion] OFF
SET IDENTITY_INSERT [dbo].[tblSponsore] ON 

INSERT [dbo].[tblSponsore] ([fldID], [fldSponsore], [fldImg], [fldKatFk]) VALUES (1, N'Nike', N'Nike.png', 1)
INSERT [dbo].[tblSponsore] ([fldID], [fldSponsore], [fldImg], [fldKatFk]) VALUES (2, N'Fanta', N'Fanta.png', 2)
INSERT [dbo].[tblSponsore] ([fldID], [fldSponsore], [fldImg], [fldKatFk]) VALUES (3, N'Coca Cola', N'coca-cola-logo.jpg', 1)
INSERT [dbo].[tblSponsore] ([fldID], [fldSponsore], [fldImg], [fldKatFk]) VALUES (4, N'Hummel', N'hummel-logo.jpg', 1)
INSERT [dbo].[tblSponsore] ([fldID], [fldSponsore], [fldImg], [fldKatFk]) VALUES (6, N'SmukFest', N'smukfest.png', 1)
INSERT [dbo].[tblSponsore] ([fldID], [fldSponsore], [fldImg], [fldKatFk]) VALUES (7, N'LG', N'Lg.png', 3)
INSERT [dbo].[tblSponsore] ([fldID], [fldSponsore], [fldImg], [fldKatFk]) VALUES (8, N'Circle', N'Circle.jpg', 3)
INSERT [dbo].[tblSponsore] ([fldID], [fldSponsore], [fldImg], [fldKatFk]) VALUES (9, N'Intel', N'Intel.png', 2)
INSERT [dbo].[tblSponsore] ([fldID], [fldSponsore], [fldImg], [fldKatFk]) VALUES (10, N'Vikan', N'Vikan.jpg', 2)
INSERT [dbo].[tblSponsore] ([fldID], [fldSponsore], [fldImg], [fldKatFk]) VALUES (11, N'adidas', N'adidas-logo.jpg', 2)
INSERT [dbo].[tblSponsore] ([fldID], [fldSponsore], [fldImg], [fldKatFk]) VALUES (12, N'7up', N'7up.png', 2)
SET IDENTITY_INSERT [dbo].[tblSponsore] OFF
SET IDENTITY_INSERT [dbo].[tblTilmeldte] ON 

INSERT [dbo].[tblTilmeldte] ([fldID], [fldEmail], [fldEventFK]) VALUES (4, N'rasmus.dybmose@hotmail.com', 1)
INSERT [dbo].[tblTilmeldte] ([fldID], [fldEmail], [fldEventFK]) VALUES (5, N'rasmus.dybmose@hotmail.com', 1)
INSERT [dbo].[tblTilmeldte] ([fldID], [fldEmail], [fldEventFK]) VALUES (6, N'rasmus.dybmose@hotmail.com', 2)
INSERT [dbo].[tblTilmeldte] ([fldID], [fldEmail], [fldEventFK]) VALUES (7, N'rasmus.dybmose@hotmail.com', 1)
INSERT [dbo].[tblTilmeldte] ([fldID], [fldEmail], [fldEventFK]) VALUES (8, N'rasmus.dybmose@hotmail.com', 3)
INSERT [dbo].[tblTilmeldte] ([fldID], [fldEmail], [fldEventFK]) VALUES (9, N'rasmus.dybmose@hotmail.com', 3)
SET IDENTITY_INSERT [dbo].[tblTilmeldte] OFF
SET IDENTITY_INSERT [dbo].[tblUsers] ON 

INSERT [dbo].[tblUsers] ([fldID], [fldUserName], [fldPassword], [fldSalt]) VALUES (1, N'Rasmus', N'mEx4MeojxXucPSt1lTWjxyQ9JLPAbBIcOluDKprOH7Y=', N'LZB/Hc1Lav86wY2v')
INSERT [dbo].[tblUsers] ([fldID], [fldUserName], [fldPassword], [fldSalt]) VALUES (2, N'admin', N'bl6LybgL5bNi1j2+xANnJpgqpMe/KhvXJMF305ADuk8=', N'xIqm6XFigq8FYL/p')
SET IDENTITY_INSERT [dbo].[tblUsers] OFF
ALTER TABLE [dbo].[tblTilmeldte]  WITH CHECK ADD  CONSTRAINT [FK_tblTilmeldte_tblEvents] FOREIGN KEY([fldEventFK])
REFERENCES [dbo].[tblEvents] ([fldID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblTilmeldte] CHECK CONSTRAINT [FK_tblTilmeldte_tblEvents]
GO
