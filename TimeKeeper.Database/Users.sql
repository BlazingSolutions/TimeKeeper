CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[RegionalOffice] INT NOT NULL,
    [FirstName] NVARCHAR(200) NOT NULL, 
    [LastName] NVARCHAR(200) NOT NULL,
    [EmailAddress] NVARCHAR(200) NOT NULL,
    [IsActive] BIT NOT NULL,
    [IsManager] BIT NOT NULL,
    [IsExecutive] BIT NOT NULL,
    [DateModified] DATETIME NULL, 
    [ModifiedBy] INT NULL, 
    [DateCreated] DATETIME NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    CONSTRAINT [FK_Users_RegionalOffices] FOREIGN KEY ([RegionalOffice]) REFERENCES [RegionalOffices]([Id])
)
