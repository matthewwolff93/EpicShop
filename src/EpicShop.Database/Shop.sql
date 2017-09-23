﻿CREATE TABLE [dbo].[Shop]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,
	[OwnerName] NVARCHAR(100) NOT NULL,
	[OwnerEmail] NVARCHAR(100) NOT NULL,

	--metadata properties
	[CreatedDateTime] DATETIME2 NOT NULL,
	[UpdatedDateTime] DATETIME2 NOT NULL,
	[DeletedDateTime] DATETIME2 NULL,

	[CreatedBy] NVARCHAR(30) NOT NULL,
	[UpdatedBy] NVARCHAR(30) NOT NULL,
	[IsDeleted] BIT NOT NULL,

	--temporal table properties
	[SysStart] DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
	[SysEnd] DATETIME2 (7) GENERATED ALWAYS AS ROW END NOT NULL, 
	PERIOD FOR SYSTEM_TIME ([SysStart], [SysEnd])
)
WITH (SYSTEM_VERSIONING = ON(HISTORY_TABLE=[dbo].[Shop_HISTORY], DATA_CONSISTENCY_CHECK=ON))

GO

CREATE NONCLUSTERED INDEX [IX_Shop] ON [dbo].[Shop] ([OwnerEmail])

GO

CREATE UNIQUE INDEX [IX_Shop_UNIQUE] ON [dbo].[Shop] ([Name],[IsDeleted],[DeletedDateTime])
