
USE [PHONESTORE]
GO
/****** Object:  Table [dbo].[BASKET]    Script Date: 17.01.2021 19:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BASKET](
	[ID_B] [int] IDENTITY(1,1) NOT NULL,
	[ID_C] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_B] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BASKET_PHONE]    Script Date: 17.01.2021 19:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BASKET_PHONE](
	[ID_BP] [int] IDENTITY(1,1) NOT NULL,
	[ID_B] [int] NOT NULL,
	[ID_P] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_BP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 17.01.2021 19:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[ID_C] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [char](20) NOT NULL,
	[LNAME] [char](30) NOT NULL,
	[EMAIL] [char](50) NULL,
	[NUMBER] [char](20) NULL,
	[COUNTRY] [char](70) NULL,
	[CITY] [char](50) NULL,
	[LOGIN] [char](15) NULL,
	[PASSWORD] [char](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_C] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDER_PHONE]    Script Date: 17.01.2021 19:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDER_PHONE](
	[ID_OP] [int] IDENTITY(1,1) NOT NULL,
	[ID_O] [int] NOT NULL,
	[ID_P] [int] NOT NULL,
	[SALE] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_OP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDERS]    Script Date: 17.01.2021 19:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDERS](
	[ID_O] [int] IDENTITY(1,1) NOT NULL,
	[ID_C] [int] NOT NULL,
	[DATE_O] [datetime] NULL,
	[ADRESS] [char](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_O] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONE]    Script Date: 17.01.2021 19:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONE](
	[ID_P] [int] IDENTITY(1,1) NOT NULL,
	[MODEL] [char](50) NOT NULL,
	[MARKA] [char](100) NOT NULL,
	[CAMERA] [int] NULL,
	[MEMORY] [int] NULL,
	[battery] [int] NULL,
	[PRICE] [float] NULL,
	[DESCRIPTIONPHONE] [char](300) NULL,
	[COUNT_PHONE] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_P] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BASKET] ON 

INSERT [dbo].[BASKET] ([ID_B], [ID_C]) VALUES (2, 1005)
SET IDENTITY_INSERT [dbo].[BASKET] OFF
GO
SET IDENTITY_INSERT [dbo].[CUSTOMER] ON 

INSERT [dbo].[CUSTOMER] ([ID_C], [NAME], [LNAME], [EMAIL], [NUMBER], [COUNTRY], [CITY], [LOGIN], [PASSWORD]) VALUES (1, N'Daniil              ', N'Tovsolug                      ', N'daniil@gmail.com                                  ', N'0970658734          ', N'Ukraine                                                               ', N'Kharkiv                                           ', N'mastermagic    ', N'12345                         ')
INSERT [dbo].[CUSTOMER] ([ID_C], [NAME], [LNAME], [EMAIL], [NUMBER], [COUNTRY], [CITY], [LOGIN], [PASSWORD]) VALUES (1003, N'Vika                ', N'Petruk                        ', N'vikapetruk1234@gmail.com                          ', N'+38 (096) 011-47-95 ', N'Ukraine                                                               ', N'Kharkov                                           ', N'               ', N'1234                          ')
INSERT [dbo].[CUSTOMER] ([ID_C], [NAME], [LNAME], [EMAIL], [NUMBER], [COUNTRY], [CITY], [LOGIN], [PASSWORD]) VALUES (1005, N'Maria               ', N'Aksyonova                     ', N'maria1234@gmail.com                               ', N'0950071086          ', N'Ukraine                                                               ', N'Kharkov                                           ', N'maria1234      ', N'maria2002                     ')
SET IDENTITY_INSERT [dbo].[CUSTOMER] OFF
GO
SET IDENTITY_INSERT [dbo].[ORDER_PHONE] ON 

INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (2, 21, 1, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (3, 21, 5, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (4, 21, 14, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (5, 22, 14, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (7, 22, 18, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (8, 23, 5, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (9, 24, 5, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (10, 25, 1, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (1010, 1025, 1, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (2010, 2025, 16, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (2011, 2026, 16, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (2012, 2026, 5, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (2013, 2027, 1, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (2014, 2028, 1, 0)
INSERT [dbo].[ORDER_PHONE] ([ID_OP], [ID_O], [ID_P], [SALE]) VALUES (2015, 2028, 14, 0)
SET IDENTITY_INSERT [dbo].[ORDER_PHONE] OFF
GO
SET IDENTITY_INSERT [dbo].[ORDERS] ON 

INSERT [dbo].[ORDERS] ([ID_O], [ID_C], [DATE_O], [ADRESS]) VALUES (21, 1005, CAST(N'2020-12-15T00:00:00.000' AS DateTime), N'Kharkov. 610009                                                                                                                                       ')
INSERT [dbo].[ORDERS] ([ID_O], [ID_C], [DATE_O], [ADRESS]) VALUES (22, 1005, CAST(N'2020-12-15T00:00:00.000' AS DateTime), N'Kharkov. 610009                                                                                                                                       ')
INSERT [dbo].[ORDERS] ([ID_O], [ID_C], [DATE_O], [ADRESS]) VALUES (23, 1005, CAST(N'2020-12-15T00:00:00.000' AS DateTime), N'Kharkov. 610009 SunMall                                                                                                                               ')
INSERT [dbo].[ORDERS] ([ID_O], [ID_C], [DATE_O], [ADRESS]) VALUES (24, 1005, CAST(N'2020-12-15T00:00:00.000' AS DateTime), N'Kharkov. 610009                                                                                                                                       ')
INSERT [dbo].[ORDERS] ([ID_O], [ID_C], [DATE_O], [ADRESS]) VALUES (25, 1005, CAST(N'2020-12-17T00:00:00.000' AS DateTime), N'Kharkov. ??????                                                                                                                                       ')
INSERT [dbo].[ORDERS] ([ID_O], [ID_C], [DATE_O], [ADRESS]) VALUES (1025, 1005, CAST(N'2020-12-17T00:00:00.000' AS DateTime), N'Kharkov. 610009 SunMall                                                                                                                               ')
INSERT [dbo].[ORDERS] ([ID_O], [ID_C], [DATE_O], [ADRESS]) VALUES (2025, 1005, CAST(N'2020-12-17T00:00:00.000' AS DateTime), N'Kharkov. ??????                                                                                                                                       ')
INSERT [dbo].[ORDERS] ([ID_O], [ID_C], [DATE_O], [ADRESS]) VALUES (2026, 1005, CAST(N'2020-12-17T00:00:00.000' AS DateTime), N'Kharkov. Osnova                                                                                                                                       ')
INSERT [dbo].[ORDERS] ([ID_O], [ID_C], [DATE_O], [ADRESS]) VALUES (2027, 1005, CAST(N'2020-12-23T00:00:00.000' AS DateTime), N'Kharkov. 610009                                                                                                                                       ')
INSERT [dbo].[ORDERS] ([ID_O], [ID_C], [DATE_O], [ADRESS]) VALUES (2028, 1005, CAST(N'2020-12-23T00:00:00.000' AS DateTime), N'Kharkov. 610009 SunMall                                                                                                                               ')
SET IDENTITY_INSERT [dbo].[ORDERS] OFF
GO
SET IDENTITY_INSERT [dbo].[PHONE] ON 

INSERT [dbo].[PHONE] ([ID_P], [MODEL], [MARKA], [CAMERA], [MEMORY], [battery], [PRICE], [DESCRIPTIONPHONE], [COUNT_PHONE]) VALUES (1, N'samsung                                           ', N'a5                                                                                                  ', 32, 128, 5000, 9000, N'Convinient                                                                                                                                                                                                                                                                                                  ', 0)
INSERT [dbo].[PHONE] ([ID_P], [MODEL], [MARKA], [CAMERA], [MEMORY], [battery], [PRICE], [DESCRIPTIONPHONE], [COUNT_PHONE]) VALUES (5, N'xiaomi5                                           ', N'redmi 7s                                                                                            ', 16, 164, 4500, 5000, N'super fast                                                                                                                                                                                                                                                                                                  ', 2)
INSERT [dbo].[PHONE] ([ID_P], [MODEL], [MARKA], [CAMERA], [MEMORY], [battery], [PRICE], [DESCRIPTIONPHONE], [COUNT_PHONE]) VALUES (14, N'xiaomi                                            ', N'redmi note 9 pro                                                                                    ', 48, 128, 5100, 8000, N'Super fast                                                                                                                                                                                                                                                                                                  ', 2)
INSERT [dbo].[PHONE] ([ID_P], [MODEL], [MARKA], [CAMERA], [MEMORY], [battery], [PRICE], [DESCRIPTIONPHONE], [COUNT_PHONE]) VALUES (16, N'apple                                             ', N'iphone 12 pro                                                                                       ', 12, 128, 2800, 40000, N'It`s apple. Another dont nesessary.                                                                                                                                                                                                                                                                         ', 1)
INSERT [dbo].[PHONE] ([ID_P], [MODEL], [MARKA], [CAMERA], [MEMORY], [battery], [PRICE], [DESCRIPTIONPHONE], [COUNT_PHONE]) VALUES (18, N'xiaomi                                            ', N'mi 10t pro                                                                                          ', 108, 256, 4500, 15000, N'Super camera                                                                                                                                                                                                                                                                                                ', 9)
SET IDENTITY_INSERT [dbo].[PHONE] OFF
GO
ALTER TABLE [dbo].[BASKET]  WITH CHECK ADD FOREIGN KEY([ID_C])
REFERENCES [dbo].[CUSTOMER] ([ID_C])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BASKET_PHONE]  WITH CHECK ADD FOREIGN KEY([ID_B])
REFERENCES [dbo].[BASKET] ([ID_B])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BASKET_PHONE]  WITH CHECK ADD FOREIGN KEY([ID_P])
REFERENCES [dbo].[PHONE] ([ID_P])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ORDER_PHONE]  WITH CHECK ADD FOREIGN KEY([ID_O])
REFERENCES [dbo].[ORDERS] ([ID_O])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ORDER_PHONE]  WITH CHECK ADD FOREIGN KEY([ID_P])
REFERENCES [dbo].[PHONE] ([ID_P])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD  CONSTRAINT [FK_Orders_To_Customers] FOREIGN KEY([ID_C])
REFERENCES [dbo].[CUSTOMER] ([ID_C])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ORDERS] CHECK CONSTRAINT [FK_Orders_To_Customers]
GO
