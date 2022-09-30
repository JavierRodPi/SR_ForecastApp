CREATE TABLE [dbo].[Products] (
    [OrderId]     NVARCHAR (255) NOT NULL,
    [ProductId]   NVARCHAR (255) NOT NULL,
    [Category]    NVARCHAR (255) NULL,
    [SubCategory] NVARCHAR (255) NULL,
    [ProductName] NVARCHAR (255) NULL,
    [Sales]       FLOAT (53)     NULL,
    [Quantity]    FLOAT (53)     NULL,
    [Discount]    FLOAT (53)     NULL,
    [Profit]      FLOAT (53)     NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([OrderId] ASC, [ProductId] ASC)
);

