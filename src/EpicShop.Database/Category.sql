CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ParentId] INT NULL,
	[ShopId] INT NOT NULL,

	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,

	--metadata properties
	[CreatedDateTime] DATETIME2 NOT NULL,
	[UpdatedDateTime] DATETIME2 NOT NULL,

	[CreatedBy] NVARCHAR(30) NOT NULL,
	[UpdatedBy] NVARCHAR(30) NOT NULL,
	[IsDeleted] BIT NOT NULL,

	--temporal table properties
	[SysStart] DATETIME2 (7) GENERATED ALWAYS AS ROW START NOT NULL,
	[SysEnd] DATETIME2 (7) GENERATED ALWAYS AS ROW END NOT NULL,
	PERIOD FOR SYSTEM_TIME ([SysStart], [SysEnd]),

	--column constraints
    CONSTRAINT [FK_Category_Category] FOREIGN KEY ([ParentId]) REFERENCES [Category]([Id]),
    CONSTRAINT [FK_Category_Shop] FOREIGN KEY ([ShopId]) REFERENCES [Shop]([Id])
)
WITH (SYSTEM_VERSIONING = ON(HISTORY_TABLE=[dbo].[Category_HISTORY], DATA_CONSISTENCY_CHECK=ON))

GO

CREATE NONCLUSTERED INDEX [IX_Category] ON [dbo].[Category] ([ParentId], [ShopId], [IsDeleted])
