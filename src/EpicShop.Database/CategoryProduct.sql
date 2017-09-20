CREATE TABLE [dbo].[CategoryProduct]
(
	[Id] INT NOT NULL IDENTITY,
	[CategoryId] INT NOT NULL,
	[ProductId] INT NOT NULL,

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
	PERIOD FOR SYSTEM_TIME ([SysStart], [SysEnd]),

	--composite primary key
	PRIMARY KEY (Id, CategoryId,ProductId),

	--column constraints
    CONSTRAINT [FK_CategoryProduct_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]),
    CONSTRAINT [FK_CategoryProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
WITH (SYSTEM_VERSIONING = ON(HISTORY_TABLE=[dbo].[CategoryProduct_HISTORY], DATA_CONSISTENCY_CHECK=ON))

GO

CREATE NONCLUSTERED INDEX [IX_CategoryProduct] ON [dbo].[CategoryProduct] ([CategoryId], [ProductId], [IsDeleted])
