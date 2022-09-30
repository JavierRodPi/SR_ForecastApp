/****** Object:  Table [dbo].[OrdersReturns]    Script Date: 30/09/2022 09:12:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrdersReturns](
	[OrderId] [nvarchar](255) NOT NULL,
	[Comments] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


