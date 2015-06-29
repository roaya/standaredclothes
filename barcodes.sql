USE [StandardClothes]
GO

/****** Object:  Table [dbo].[BarCodes]    Script Date: 21/06/2015 04:43:56 ã ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BarCodes](
	[Bar_Id] [int] IDENTITY(1,1) NOT NULL,
	[Bar_Item_id] [int] NOT NULL,
	[Bar_Code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BarCodes] PRIMARY KEY CLUSTERED 
(
	[Bar_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BarCodes]  WITH CHECK ADD  CONSTRAINT [FK_BarCodes_Items] FOREIGN KEY([Bar_Item_id])
REFERENCES [dbo].[Items] ([Item_ID])
GO

ALTER TABLE [dbo].[BarCodes] CHECK CONSTRAINT [FK_BarCodes_Items]
GO


