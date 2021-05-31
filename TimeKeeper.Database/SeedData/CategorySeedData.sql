USE [TimeKeeper]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (1, N'Meeting', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (2, N'Call', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (3, N'Documentation', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [IsActive], [DateModified], [ModifiedBy], [DateCreated], [CreatedBy]) VALUES (4, N'Other', 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-13T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO