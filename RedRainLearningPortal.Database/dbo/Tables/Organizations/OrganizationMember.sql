CREATE TABLE [dbo].[OrganizationMember]
(
	[Id] INT NOT NULL PRIMARY KEY CLUSTERED IDENTITY (1, 1),

	[UserId] INT NOT NULL REFERENCES [User](Id),
	
	[OrganizationId] INT NOT NULL REFERENCES [Organization](Id)
)
