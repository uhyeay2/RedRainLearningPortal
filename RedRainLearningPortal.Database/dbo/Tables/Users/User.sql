CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1, 1),

	[Guid] UniqueIdentifier NOT NULL UNIQUE DEFAULT NEWID(),

	[AccountName] NVARCHAR(100) NOT NULL,

	[Email] NVARCHAR(MAX) NOT NULL,

	[FirstName] NVARCHAR(100) NOT NULL,

	[LastName] NVARCHAR(100) NOT NULL,

	[CreatedAtDateTimeUTC] DateTime NOT NULL DEFAULT GETUTCDATE(),

	[LastUpdatedDateTimeUTC] DateTime NULL
)
