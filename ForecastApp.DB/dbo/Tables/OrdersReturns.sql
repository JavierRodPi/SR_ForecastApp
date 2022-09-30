CREATE TABLE [dbo].[OrdersReturns] (
    [OrderId]  NVARCHAR (255) NOT NULL,
    [Comments] NVARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC)
);

