CREATE TABLE [dbo].[OrganizationMemberRole]
(
	[Id] INT NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1,1),
	
	OrganizationMemberId INT REFERENCES OrganizationMember(Id),

	RoleId INT REFERENCES OrganizationRole(Id),

	[CreatedAtDateTimeUTC] DateTime NOT NULL DEFAULT GETUTCDATE(),

	[ExpireAtDateTimeUTC] DateTime NULL,

	[LastUpdatedDateTimeUTC] DateTime NULL,
)
