CREATE TABLE [dbo].[OrganizationRole]
(
	[Id] INT NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),

	[OrganizationId] INT NOT NULL REFERENCES Organization(Id),
	
	[Name] NVARCHAR(MAX) NOT NULL, 
	
	[AllowedUserActionIds] NVARCHAR(MAX) NULL
)
