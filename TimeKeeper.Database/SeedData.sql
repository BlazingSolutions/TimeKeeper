USE [TimeKeeper]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (1, N'Meeting', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (3, N'Call', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (4, N'Documentation', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (5, N'Other', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 
GO
INSERT [dbo].[Clients] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (1, N'Amazon', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Clients] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (2, N'Apple', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Clients] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (3, N'Microsoft', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Clients] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (4, N'Samsung', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[RegionalOffices] ON 
GO
INSERT [dbo].[RegionalOffices] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (1, N'Dublin', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[RegionalOffices] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [RegionalOffice], [FirstName], [LastName], [EmailAddress], [IsActive], [IsManager], [IsExecutive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (1, 1, N'Francisco', N'Villena', N'francisco.dublin@gmail.com', 1, 0, 0, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[TimeEntries] ON 
GO
INSERT [dbo].[TimeEntries] ([Id], [User], [Client], [Category], [Hours], [Notes], [IsSubmitted], [IsAuthorised], [AuthorisedBy], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (1017, 1, 3, 1, CAST(2 AS Decimal(18, 0)), N'Purchase of Time Keeper', 0, 0, NULL, NULL, NULL, CAST(N'2021-05-14T11:40:32.410' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[TimeEntries] OFF
GO