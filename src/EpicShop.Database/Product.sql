CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ShopId] INT NOT NULL,
	
	[Name] NVARCHAR(150) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,

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
    CONSTRAINT [FK_Product_Shop] FOREIGN KEY ([ShopId]) REFERENCES [Shop]([Id])

)
WITH (SYSTEM_VERSIONING = ON(HISTORY_TABLE=[dbo].[Products_HISTORY], DATA_CONSISTENCY_CHECK=ON))

GO

CREATE COLUMNSTORE INDEX [CStoreIX_Product] ON [dbo].[Product] ([ShopId], [IsDeleted])
