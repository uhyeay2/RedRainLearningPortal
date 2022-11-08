﻿CREATE TABLE [dbo].[Organization]
(
	[Id] INT NOT NULL PRIMARY KEY CLUSTERED IDENTITY (1, 1),

	[Guid] UNIQUEIDENTIFIER NOT NULL UNIQUE DEFAULT NEWID(),
	
	[Name] NVARCHAR(MAX) NOT NULL,

	[Description] NVARCHAR(MAX) NULL,

	[CreatedAtDateTimeUTC] DATETIME NOT NULL DEFAULT GETUTCDATE(),

	[LastUpdatedDateTimeUTC] DATETIME NULL
)
