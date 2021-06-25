CREATE DATABASE TimeKeeper;
GO
USE TimeKeeper;
GO

CREATE LOGIN TestUser WITH PASSWORD = 'T1meKeeper!';
GO
CREATE USER TestUser FOR LOGIN TestUser;
GO
ALTER SERVER ROLE sysadmin ADD MEMBER [TestUser];
GO

CREATE TABLE [dbo].[TimeEntries]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [User] INT NOT NULL,
    [Client] INT NOT NULL,
    [Category] INT NOT NULL,
    [Hours] DECIMAL NOT NULL,
    [Notes] NVARCHAR(200) NOT NULL,
    [IsSubmitted] BIT NOT NULL,
    [IsAuthorised] BIT NOT NULL,
    [AuthorisedBy] INT NULL,
    [DateModified] DATETIME NULL,
    [ModifiedBy] INT NULL,
    [DateCreated] DATETIME NOT NULL,
    [CreatedBy] INT NOT NULL
)
GO
