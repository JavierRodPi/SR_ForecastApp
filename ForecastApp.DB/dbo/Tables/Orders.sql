CREATE TABLE [dbo].[Orders] (
    [OrderId]      NVARCHAR (255) NOT NULL,
    [OrderDate]    DATETIME       NULL,
    [ShipDate]     DATETIME       NULL,
    [ShipMode]     NVARCHAR (255) NULL,
    [CustomerId]   NVARCHAR (255) NULL,
    [CustomerName] NVARCHAR (255) NULL,
    [Segment]      NVARCHAR (255) NULL,
    [Country]      NVARCHAR (255) NULL,
    [City]         NVARCHAR (255) NULL,
    [State]        NVARCHAR (255) NULL,
    [Postal Code]  FLOAT (53)     NULL,
    [Region]       NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC)
);

