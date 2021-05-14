CREATE TABLE [dbo].[RegionalOffices]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(200) NOT NULL, 
    [IsActive] BIT NOT NULL,
    [DateModified] DATETIME NULL, 
    [ModifiedBy] INT NULL, 
    [DateCreated] DATETIME NOT NULL, 
    [CreatedBy] INT NOT NULL
)
