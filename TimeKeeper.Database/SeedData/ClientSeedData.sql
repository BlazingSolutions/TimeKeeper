USE [TimeKeeper]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 
GO
INSERT [dbo].[Clients] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (1, N'Amazon', 1, NULL, NULL, CAST(N'2021-05-31T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Clients] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (2, N'Spotify', 1, NULL, NULL, CAST(N'2021-05-31T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Clients] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (3, N'Microsoft', 1, NULL, NULL, CAST(N'2021-05-31T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Clients] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (4, N'Google', 1, NULL, NULL, CAST(N'2021-05-31T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Clients] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (5, N'Sony', 1, NULL, NULL, CAST(N'2021-05-31T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO