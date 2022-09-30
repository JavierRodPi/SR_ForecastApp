/****** Object:  Table [dbo].[Orders]    Script Date: 30/09/2022 09:11:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[OrderId] [nvarchar](255) NOT NULL,
	[OrderDate] [datetime] NULL,
	[ShipDate] [datetime] NULL,
	[ShipMode] [nvarchar](255) NULL,
	[CustomerId] [nvarchar](255) NULL,
	[CustomerName] [nvarchar](255) NULL,
	[Segment] [nvarchar](255) NULL,
	[Country] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[Postal Code] [float] NULL,
	[Region] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


