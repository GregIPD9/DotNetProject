CREATE TABLE [dbo].[Products]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [PruductName] NVARCHAR(50) NOT NULL, 
    [Catagory] NVARCHAR(50) NOT NULL, 
    [SupplierName] NVARCHAR(50) NOT NULL, 
    [Price] SMALLMONEY NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Location] NVARCHAR(50) NOT NULL
)
