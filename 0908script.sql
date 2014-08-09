

/****** Object:  Table [dbo].[tblOders]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOders](
	[OID] [bigint] IDENTITY(1,1) NOT NULL,
	[Membership_No] [bigint] NULL,
	[SHP_ID] [int] NULL,
	[BILL_ID] [int] NULL,
	[ONET_AMT] [decimal](8, 2) NULL,
	[OTAX_AMT] [decimal](8, 2) NULL,
	[ODISCOUNT_AMT] [decimal](8, 2) NULL,
	[OSHIP_DETAILS_ID] [int] NULL,
	[OPOINT_REDEEM] [int] NULL,
	[OPOINT_VALUE] [decimal](8, 2) NULL,
	[OPOINT_REDEEM_AMT]  AS ([opoint_redeem]*[opoint_value]),
	[OSHIP_AMT]  AS ([onet_amt]-[opoint_redeem]*[opoint_value]),
	[OCURRENCY_CODE] [nvarchar](3) NULL,
	[OEXCHANGE_RATE] [nvarchar](50) NULL,
	[Checksum] [nvarchar](10) NULL,
	[CheckSumPayment] [nvarchar](10) NULL,
	[AuthDesc] [nvarchar](1) NULL,
	[newChecksum] [nvarchar](50) NULL,
	[DATETIME] [datetime] NOT NULL,
	[IP] [nvarchar](30) NULL,
	[ISDELETED] [bit] NULL,
	[SHP_FLAG] [varchar](50) NULL,
	[SessionID] [nvarchar](100) NULL,
 CONSTRAINT [PK_TBL_RT_ORDER] PRIMARY KEY CLUSTERED 
(
	[OID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblITEMS_ORDER]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblITEMS_ORDER](
	[OIID] [bigint] IDENTITY(1,1) NOT NULL,
	[OID] [bigint] NULL,
	[SHP_PROD_ID] [int] NULL,
	[SHP_PROD_CAT_ID] [int] NULL,
	[SHP_PROD_SUB_CAT_ID] [int] NULL,
	[PROD_TABALE_NAME] [nvarchar](100) NULL,
	[SHP_PROD_CODE] [nvarchar](50) NULL,
	[SHP_PROD_NAME] [nvarchar](1000) NULL,
	[SHP_PROD_DISC_PRICE] [decimal](8, 2) NULL,
	[SHP_PROD_ACTULE_PRICE] [decimal](8, 2) NULL,
	[SHP_PROD_TAX] [decimal](8, 2) NULL,
	[SHP_PROD_PERCENT] [decimal](8, 2) NULL,
	[SHP_PROD_QTY] [int] NULL,
	[SHP_PROD_SIZE] [nvarchar](30) NULL,
	[DATE] [datetime] NOT NULL,
	[IP] [nvarchar](30) NULL,
	[ISDELETED] [bit] NOT NULL,
 CONSTRAINT [PK_TBL_RT_ITEMS_ORDER] PRIMARY KEY CLUSTERED 
(
	[OIID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDeliveryModes]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDeliveryModes](
	[DeliveryModeId] [int] IDENTITY(1,1) NOT NULL,
	[DeliveryModeName] [varchar](50) NULL,
	[DeliveryModeDesc] [varchar](200) NULL,
	[DeliveryCharge] [float] NULL,
 CONSTRAINT [PK_tblDeliveryModes] PRIMARY KEY CLUSTERED 
(
	[DeliveryModeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCategory](
	[categoryId] [int] IDENTITY(1,1) NOT NULL,
	[pId] [int] NOT NULL,
	[categoryName] [varchar](200) NOT NULL,
	[description] [varchar](500) NOT NULL,
	[categoryImageURL] [varchar](500) NULL,
	[seqorder] [int] NULL,
	[modifiedBy] [int] NULL,
	[createdBy] [int] NULL,
	[createdDate] [datetime] NULL,
	[modifiedDate] [datetime] NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblAttributeValues]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAttributeValues](
	[attributeValId] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NOT NULL,
	[attributeId] [int] NOT NULL,
	[attributeValue] [varchar](200) NULL,
	[isAvailableFor] [tinyint] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblAttributes]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAttributes](
	[attributeId] [int] IDENTITY(1,1) NOT NULL,
	[attributeTitle] [varchar](200) NOT NULL,
 CONSTRAINT [PK_tblProductAttributes] PRIMARY KEY CLUSTERED 
(
	[attributeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblAddToShoppingCart]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAddToShoppingCart](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SHP_SESSION_ID] [nvarchar](100) NULL,
	[SHP_PROD_ID] [int] NULL,
	[SHP_PROD_CAT_ID] [int] NULL,
	[SHP_PROD_SUB_CAT_ID] [int] NULL,
	[SHP_PROD_CODE] [nvarchar](50) NULL,
	[SHP_PROD_NAME] [nvarchar](1000) NULL,
	[SHP_PROD_DISC_PRICE] [decimal](8, 2) NULL,
	[SHP_PROD_ACTULE_PRICE] [decimal](8, 2) NULL,
	[SHP_PROD_TAX] [decimal](8, 2) NULL,
	[SHP_PROD_PERCENT] [decimal](8, 2) NULL,
	[SHP_PROD_QTY] [int] NULL,
	[SHP_PROD_SIZE] [nvarchar](30) NULL,
	[SHP_PROD_IMG] [nvarchar](500) NULL,
	[SHP_PROD_DESC] [nvarchar](2000) NULL,
	[PROD_DETAIL_URL] [nvarchar](500) NULL,
	[SHP_FLAG] [char](10) NULL,
	[DATE] [datetime] NOT NULL,
	[IP] [nvarchar](30) NULL,
	[ISDELETED] [bit] NULL,
 CONSTRAINT [PK_TBL_RT_SHOPPINGCART] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[states]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[states](
	[stateID] [int] NOT NULL,
	[stateName] [varchar](50) NOT NULL,
	[countryID] [varchar](3) NOT NULL,
	[latitude] [float] NOT NULL,
	[longitude] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[stateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[countryID] ASC,
	[stateName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[PasswordEncryption]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[PasswordEncryption]
(@Str nvarchar(1000)
)
RETURNS varBinary(1000)
AS
BEGIN
	-- Declare the return variable here
	DECLARE  @EcrPwd varBinary(1000)

	set @EcrPwd=ENCRYPTBYPASSPHRASE('RedTapePAssword',@Str)
	
	RETURN @EcrPwd

END
GO
/****** Object:  UserDefinedFunction [dbo].[PasswordDecryption]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[PasswordDecryption]
(@EcrPwd  varBinary(1000)
)
RETURNS nvarchar(1000)
AS
BEGIN
	-- Declare the return variable here
	DECLARE   @Str  nvarchar(1000)

	set @Str=DECRYPTBYPASSPHRASE('RedTapePAssword',@EcrPwd)
	
	RETURN @Str

END
GO
/****** Object:  Table [dbo].[countries]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[countries](
	[countryID] [varchar](3) NOT NULL,
	[countryName] [varchar](52) NOT NULL,
	[localName] [varchar](45) NOT NULL,
	[webCode] [varchar](2) NOT NULL,
	[region] [varchar](26) NOT NULL,
	[continent] [varchar](15) NOT NULL,
	[latitude] [float] NOT NULL,
	[longitude] [float] NOT NULL,
	[surfaceArea] [float] NOT NULL,
	[population] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[countryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[countryName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[webCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cities]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cities](
	[cityID] [int] NOT NULL,
	[cityName] [varchar](50) NOT NULL,
	[stateID] [int] NOT NULL,
	[countryID] [varchar](3) NOT NULL,
	[latitude] [float] NOT NULL,
	[longitude] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[countryID] ASC,
	[stateID] ASC,
	[cityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserViewProducts]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserViewProducts](
	[viewId] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NOT NULL,
	[Membership_No] [nvarchar](100) NOT NULL,
	[viewType] [int] NOT NULL,
	[qty] [int] NULL,
	[browserId] [varchar](50) NULL,
	[createdDate] [datetime] NOT NULL,
	[modifiedDate] [datetime] NOT NULL,
	[SessionID] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblUserViewProducts] PRIMARY KEY CLUSTERED 
(
	[viewId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserShippingDetails]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserShippingDetails](
	[shipAddressId] [int] IDENTITY(1,1) NOT NULL,
	[Membership_No] [bigint] NOT NULL,
	[firstName] [varchar](20) NULL,
	[lastName] [varchar](20) NULL,
	[contactNo] [varchar](20) NULL,
	[emailId] [varchar](50) NULL,
	[street1] [varchar](500) NULL,
	[street2] [varchar](500) NULL,
	[country] [varchar](20) NULL,
	[state] [varchar](20) NULL,
	[city] [varchar](20) NULL,
	[pincode] [varchar](10) NULL,
	[createdBy] [bigint] NULL,
	[createdDate] [datetime] NULL,
	[modifiedBy] [bigint] NULL,
	[modifiedDate] [datetime] NULL,
 CONSTRAINT [PK_tblUserShippingDetails] PRIMARY KEY CLUSTERED 
(
	[shipAddressId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserDetails]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserDetails](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[Membership_No] [bigint] NOT NULL,
	[userfbId] [varchar](50) NULL,
	[firstName] [varchar](50) NULL,
	[lastName] [varchar](50) NULL,
	[gender] [varchar](10) NULL,
	[emailAddress] [varchar](50) NOT NULL,
	[password] [nvarchar](100) NULL,
	[salt] [nvarchar](100) NULL,
	[dob] [date] NULL,
	[mobileNo] [varchar](20) NULL,
	[telePhoneNo] [varchar](20) NULL,
	[fax] [varchar](20) NULL,
	[active] [bit] NULL,
	[userType] [varchar](50) NULL,
	[createdBy] [bigint] NULL,
	[creationDate] [datetime] NOT NULL,
	[modifiedBy] [bigint] NULL,
	[modifiedDate] [datetime] NULL,
 CONSTRAINT [PK_tblUserDetails_1] PRIMARY KEY CLUSTERED 
(
	[Membership_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUserBillingDetails]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUserBillingDetails](
	[bilingAddressId] [int] IDENTITY(1,1) NOT NULL,
	[Membership_No] [bigint] NOT NULL,
	[firstName] [varchar](20) NULL,
	[lastName] [varchar](20) NULL,
	[contactNo] [varchar](20) NULL,
	[emailId] [varchar](50) NULL,
	[street1] [varchar](500) NULL,
	[street2] [varchar](500) NULL,
	[country] [varchar](20) NULL,
	[state] [varchar](20) NULL,
	[city] [varchar](20) NULL,
	[pincode] [varchar](10) NULL,
	[createdBy] [bigint] NOT NULL,
	[createdDate] [datetime] NOT NULL,
	[modifiedBy] [bigint] NULL,
	[modifiedDate] [datetime] NULL,
 CONSTRAINT [PK_tblUserBillingDetails] PRIMARY KEY CLUSTERED 
(
	[bilingAddressId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSubscribeUsers]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSubscribeUsers](
	[newsletterId] [int] IDENTITY(1,1) NOT NULL,
	[emailAddress] [varchar](50) NOT NULL,
	[active] [bit] NOT NULL,
	[subscribeDate] [datetime] NOT NULL,
	[subscribeEndDate] [datetime] NULL,
 CONSTRAINT [PK_tblSubscribeUsers] PRIMARY KEY CLUSTERED 
(
	[newsletterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProductsGroup]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProductsGroup](
	[groupId] [int] NOT NULL,
	[groupName] [varchar](200) NULL,
	[productId] [int] NULL,
	[groupTypeId] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPAYMENT_GATWAY]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPAYMENT_GATWAY](
	[PID] [bigint] IDENTITY(1,1) NOT NULL,
	[OID] [bigint] NULL,
	[Checksum] [nvarchar](50) NULL,
	[CheckSumPayment] [nvarchar](50) NULL,
	[AuthDesc] [nvarchar](1) NULL,
	[newChecksum] [nvarchar](50) NULL,
	[Error] [ntext] NULL,
	[DATETIME] [datetime] NULL,
	[IP] [nvarchar](30) NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_TBL_RT_PAYMENT_GATWAY] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrderStatusMaster]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOrderStatusMaster](
	[ordStId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblOrderStatusMaster] PRIMARY KEY CLUSTERED 
(
	[ordStId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblORDER_SHIP_BILL_Address]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblORDER_SHIP_BILL_Address](
	[SBID] [int] IDENTITY(1,1) NOT NULL,
	[OID] [int] NOT NULL,
	[S_OR_B] [char](1) NOT NULL,
	[Membership_No] [bigint] NOT NULL,
	[First_Name] [nvarchar](50) NULL,
	[Last_Name] [nvarchar](50) NULL,
	[Street1] [nvarchar](100) NULL,
	[Street2] [nvarchar](100) NULL,
	[City_Name] [nvarchar](30) NULL,
	[State_Name] [nvarchar](100) NULL,
	[Country] [nvarchar](50) NULL,
	[Pin_Code] [nvarchar](10) NULL,
	[Mobile_No] [nvarchar](20) NULL,
	[EMail] [nvarchar](50) NULL,
	[insertdatetime] [datetime] NULL,
 CONSTRAINT [PK_TBL_RT_ORDER_SHIP_BILL_ADDRESS] PRIMARY KEY CLUSTERED 
(
	[SBID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProductMetarials]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProductMetarials](
	[metarialId] [int] NOT NULL,
	[metarialName] [varchar](50) NULL,
 CONSTRAINT [PK_tblProductMetarials] PRIMARY KEY CLUSTERED 
(
	[metarialId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_ChkProductAvailable]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ChkProductAvailable]
as

--update TBL_RT_SHOPPINGCART
--set ISDELETED=1
--where SHP_PROD_CAT_ID = 1 and ISDELETED=0 and SHP_PROD_ID in
--(select PROD_SHOES_ID from TBL_RT_PROD_FOOTWEAR where isAvailable=0 or isDeleted=1 or SoldOut=1)


--update TBL_RT_SHOPPINGCART
--set ISDELETED=1
--where SHP_PROD_CAT_ID = 2 and ISDELETED=0 and SHP_PROD_ID in
--(select PROD_APPARELS_ID from TBL_RT_PROD_APPARELS where isAvailable=0 or isDeleted=1 or SoldOut=1)
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveUserBillingDetails]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<30-07-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveUserBillingDetails] ---sp_SaveUserBillingDetails
    @bilingAddressId int,
	@memebershipId bigint,
	@firstName varchar(20),
	@lastName varchar(20),
	@contactNo varchar(20),
	@emailId varchar(50),
	@street1 varchar(50),
	@street2 varchar(50),
	@country varchar(20),
	@state varchar(20),
	@city varchar(20),
	@pincode varchar(10)
AS

BEGIN 
SET NOCOUNT ON;

IF ( @bilingAddressId = 0 )
	BEGIN        
				INSERT INTO tblUserBillingDetails
				(Membership_No,firstName,lastName,contactNo,emailId,street1,street2,country,state,city,pincode,createdBy,createdDate)
				Values
				(@memebershipId,@firstName,@lastName,@contactNo,@emailId,@street1,@street2,@country,@state,@city,@pincode,@memebershipId,GETDATE())
			
				 SET @bilingAddressId=SCOPE_IDENTITY()			 								
			    
	END	
ELSE
	BEGIN
		UPDATE  tblUserBillingDetails
		SET		firstName=@firstName,
				lastName=@lastName,
				contactNo=@contactNo,
				emailId=@emailId,
				street1=@street1,
		        street2=@street2,
				country= @country,
				state=@state,
			    city=@city,
				pincode=@pincode,			
				ModifiedBy=@memebershipId,
				ModifiedDate=GETDATE()
		WHERE bilingAddressId=@bilingAddressId
						
	END		
	SELECT  @bilingAddressId UId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveSubscribeUserDetail]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<31-07-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveSubscribeUserDetail] --sp_SaveSubscribeUserDetail ''
@emailAddress VARCHAR(50)
AS
BEGIN   
IF  EXISTS( SELECT 1 FROM tblSubscribeUsers WHERE emailAddress=@emailAddress)
        BEGIN
		UPDATE tblSubscribeUsers SET active=1 WHERE emailAddress=@emailAddress
		END
  ELSE
		BEGIN
		INSERT INTO tblSubscribeUsers (emailAddress,active,subscribeDate) VALUES (@emailAddress,1,GETDATE())
		END	
		
	SELECT 'Successfully Subscribed to our Newsletter';		
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveOrderDetails]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<06-08-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveOrderDetails] ---sp_SaveOrderDetails
	@referenceNo VARCHAR(5),
	@userId INT,
	     
	--@shipDate DATETIME,
	@paymentType VARCHAR(50),
	@paid INT,
	@transactStatus VARCHAR(50),
	@transactDescription VARCHAR(200),
	@orderDate DATETIME,  
	   
	@RedeemPoint	int	,
	@PointValue	float,
	@TotalRedeemAmount float,
	@CurrencyCode varchar(50),
	@totalAmount FLOAT, 

	@blngfirstName varchar(20),
	@blnglastName varchar(20),
	@blngcontactNo varchar(20),
	@blngemailId varchar(50),
	@blngStreet1 VARCHAR(500),
	@blngStreet2 VARCHAR(500),
	@blngCountry VARCHAR(50),
	@blngState VARCHAR(50),
	@blngCity VARCHAR(50),
	@blngPincode VARCHAR(10),

	@shngfirstName varchar(20),
	@shnglastName varchar(20),
	@shngcontactNo varchar(20),
	@shngemailId varchar(50),
	@shngStreet1 VARCHAR(500),
	@shngStreet2 VARCHAR(500),
	@shngCountry VARCHAR(50),
	@shngState VARCHAR(50),
	@shngCity VARCHAR(50),
	@shngPincode VARCHAR(10),
	-----------------------------      

	@productIdsxml VARCHAR(1000)
      
AS
SET NOCOUNT ON;
BEGIN 
DECLARE @orderId INT

	INSERT INTO tblOders (userId,totalAmount,paymentType,paid,transactStatus,transactDescription,orderDate,blngfirstName,blnglastName,blngcontactNo,blngemailId,blngStreet1,blngStreet2,blngCountry,blngState,blngCity,blngPincode,
	                             shngfirstName,shnglastName,shngcontactNo,shngemailId,shngStreet1,shngStreet2,shngCountry,shngState,shngCity,shngPincode)
	                             VALUES
	                     (@userId,@totalAmount,@paymentType,@paid,@transactStatus,@transactDescription,GETDATE(),@blngfirstName,@blnglastName,@blngcontactNo,@blngemailId,@blngStreet1,@blngStreet2,@blngCountry,@blngState,@blngCity,@blngPincode,
	                             @shngfirstName,@shnglastName,@shngcontactNo,@shngemailId,@shngStreet1,@shngStreet2,@shngCountry,@shngState,@shngCity,@shngPincode)    
	                             
	                             
	  SET @orderId=SCOPE_IDENTITY()                              
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ResetUserPassword]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<30-07-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ResetUserPassword] --sp_ResetUserPassword 1,'anand@123'
@userId int,
@newpassword varchar(10)
AS
BEGIN
       
			UPDATE tblUserDetails SET password=dbo.[PasswordEncryption](@newpassword) 
			WHERE userId=@userId 
	        
			SELECT 'Password Reseted Successfully'			
		
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetValidLoginUserDetails]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<30-07-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetValidLoginUserDetails] --sp_GetValidLoginUserDetails 'anand@unikove.com','iWkUGccj1X9cSua/HcgYPeZz+U8=','1TJjgr75iJruDoKv0mkf',''
@emailAddress varchar(50)
--@password nvarchar(100),
--@salt nvarchar(100),
--@userfbId varchar(50)
AS
BEGIN
DECLARE @MembershipId BIGINT
SELECT @MembershipId=userId from tblUserDetails WHERE emailAddress=@emailAddress

	    SELECT Membership_No,password,salt,emailAddress,firstName,lastName,gender, CONVERT(VARCHAR(10),ISNULL(dob,getdate()), 105) AS dob,mobileNo,telePhoneNo,fax,
	    (SELECT COUNT(*)  FROM tblUserViewProducts WHERE Membership_No=@MembershipId AND viewType=2) AddToCartCount,
	    (SELECT COUNT(*)  FROM tblUserViewProducts WHERE Membership_No=@MembershipId AND viewType=3) WishListCount
	    FROM tblUserDetails
		WHERE emailAddress=@emailAddress  AND active=1 
		
		SELECT bilingAddressId,street1,street2,country,state,city,pincode FROM tblUserBillingDetails WHERE Membership_No=@MembershipId
		
		SELECT shipAddressId,street1,street2,country,state,city,pincode FROM tblUserShippingDetails WHERE Membership_No=@MembershipId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckUserEmailAddress]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<30-07-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CheckUserEmailAddress] --sp_CheckUserEmailAddress 'anand@unikove.com'
@emailAddress varchar(50)
AS
BEGIN
        IF EXISTS( SELECT 1 FROM tblUserDetails  WHERE emailAddress=@emailAddress AND active=1)
		BEGIN
		SELECT Membership_No from tblUserDetails
			WHERE emailAddress=@emailAddress  AND active=1 
		END
    ELSE
        RAISERROR('Email provided by you does not exists, Please enter another email id.',16,1) 
					
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductsCategory]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sheeloo UNIKOVE>
-- Create date: <29 July 14>
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductsCategory]---[sp_GetProductsCategory] 0
@CategoryId int=0
AS
BEGIN

	
	SELECT cat1.categoryId,cat1.pId,cat2.categoryName category,cat1.categoryName subCategory,cat1.description  
	FROM tblCategory cat1 
	left JOIN dbo.tblCategory cat2 ON cat1.pId=cat2.categoryId 
	where cat1.pId=case when @CategoryId=0 then cat1.pId else @CategoryId end
	order by cat1.seqorder

	
END
GO
/****** Object:  Table [dbo].[tblProducts]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProducts](
	[productId] [int] IDENTITY(1,1) NOT NULL,
	[categoryId] [int] NOT NULL,
	[skuID] [varchar](50) NOT NULL,
	[ProductCode] [varchar](100) NULL,
	[productTitle] [varchar](300) NULL,
	[description] [varchar](1000) NULL,
	[shortDescription] [varchar](100) NULL,
	[MSRP] [float] NOT NULL,
	[salePrice] [float] NOT NULL,
	[colourCode] [varchar](50) NULL,
	[colour] [varchar](50) NULL,
	[weight] [float] NULL,
	[groupId] [int] NULL,
	[taxAppliedPercentage] [float] NULL,
	[quantity] [int] NULL,
	[IsNewArrival] [bit] NOT NULL,
	[rating] [int] NOT NULL,
	[noviewed] [int] NULL,
	[rewardPoints] [int] NULL,
	[createdBy] [int] NULL,
	[createdDate] [datetime] NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedDate] [datetime] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_tblProducts] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserDetails]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<30-07-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserDetails] --sp_GetUserDetails 1
@memebershipId bigint
AS
BEGIN
	    SELECT Membership_No,emailAddress,firstName,lastName,gender,emailAddress, CONVERT(VARCHAR(10), ISNULL(dob,getdate()), 105) AS dob,mobileNo,telePhoneNo,fax,userType,
	    (SELECT COUNT(*)  FROM tblUserViewProducts WHERE Membership_No=@memebershipId AND viewType=2) AddToCartCount,
	    (SELECT COUNT(*)  FROM tblUserViewProducts WHERE Membership_No=@memebershipId AND viewType=3) WishListCount
	    FROM tblUserDetails
		WHERE Membership_No=@memebershipId
		
		SELECT bilingAddressId,firstName,lastName,contactNo,emailId,street1,street2,country,state,city,pincode FROM tblUserBillingDetails WHERE Membership_No=@memebershipId
		
		SELECT shipAddressId,firstName,lastName,contactNo,emailId,street1,street2,country,state,city,pincode FROM tblUserShippingDetails WHERE Membership_No=@memebershipId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStates]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetStates] --sp_GetStates
@CountryId VARCHAR(10)='IND'
AS
BEGIN
       SELECT stateID,stateName FROM states WHERE countryID in(@CountryId)
        UNION 
       SELECT 0 stateID,'Select State' stateName order by stateID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCountries]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCountries] --sp_GetCountries
AS
BEGIN
       SELECT countryID,countryName FROM countries WHERE countryID in('IND')
      
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCities]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCities] --sp_GetCities
@countryID VARCHAR(10)='IND'
AS
BEGIN
       SELECT cityID,cityName FROM cities WHERE countryID =case when @countryID='' then countryID else @countryID end
       UNION 
       SELECT 0 cityID,'Select City'cityName 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCategoryListByCateId]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sheeloo UNIKOVE>
-- Create date: <05 July 14>
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetCategoryListByCateId]---[sp_GetCategoryListByCateId] 0
@CategoryId int=0
AS
BEGIN

    WITH CTE AS(
    SELECT cat1.categoryId,cat1.pId,cat2.categoryName category,cat1.categoryName subCategory  
	FROM tblCategory cat1 
	left JOIN dbo.tblCategory cat2 ON cat1.pId=cat2.categoryId 
	where cat1.pId=case when @CategoryId=0 then cat1.pId else @CategoryId end	 
	--order by cat1.seqorder
	)
	select * from CTE 
	 
	--select * from tblCategory
 
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUserPassword]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateUserPassword] --sp_UpdateUserPassword 1,'ujkhk@123','anand@123'
@MembershipId BIGINT,
@newpassword nvarchar(1000),
@salt nvarchar(100)
AS
BEGIN
        IF EXISTS( SELECT 1 FROM tblUserDetails WHERE Membership_No=@MembershipId)
        BEGIN
			UPDATE tblUserDetails SET password=@newpassword,salt=@salt, userType='Registered' 
			where Membership_No=@MembershipId 
	        SELECT 'Password Updated Successfully'
		END
        ELSE      
		SELECT 'Old Password Not Matched'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SHOPPINGCART]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_SHOPPINGCART]
(
@parm char(1) = null,
@ID bigint = null,
@SHP_SESSION_ID nvarchar(100) = NULL,
@SHP_PROD_ID int = NULL,
@SHP_PROD_CAT_ID INT = NULL,
@SHP_PROD_SUB_CAT_ID INT = NULL,
--@PROD_TABALE_NAME nvarchar(100) = NULL,
@SHP_PROD_CODE nvarchar(50) = NULL,
@SHP_PROD_NAME nvarchar(1000) = NULL,
@SHP_PROD_DISC_PRICE decimal(8,2) = NULL,
@SHP_PROD_ACTULE_PRICE decimal(8,2) = NULL,
@SHP_PROD_TAX decimal(8,2) = NULL,
@SHP_PROD_PERCENT int = NULL,
@SHP_PROD_QTY INT = NULL,
@SHP_PROD_SIZE nvarchar(30) = NULL,
@SHP_PROD_IMG nvarchar(300) = NULL,
@SHP_PROD_DESC nvarchar(2000) = NULL,
@PROD_DETAIL_URL nvarchar (500) = NULL,
@SHP_FLAG CHAR(10) = NULL,
@IP nvarchar(30) = NULL
)
AS              
BEGIN   

-- For disable product which is sold out or and not available
 exec [sp_ChkProductAvailable]
 
 	if (@parm = 'i')
		BEGIN
			IF EXISTS (SELECT * FROM tblAddToShoppingCart with(nolock) WHERE SHP_SESSION_ID = @SHP_SESSION_ID and SHP_PROD_ID = @SHP_PROD_ID and SHP_PROD_CAT_ID = @SHP_PROD_CAT_ID and SHP_PROD_CODE = @SHP_PROD_CODE and SHP_PROD_SIZE = @SHP_PROD_SIZE and ISDELETED <> 1 and IP = @IP)
				BEGIN
					declare @count int					
					SELECT @count=SHP_PROD_QTY FROM tblAddToShoppingCart with(nolock) WHERE @SHP_SESSION_ID = @SHP_SESSION_ID and SHP_PROD_ID = @SHP_PROD_ID and SHP_PROD_CAT_ID = @SHP_PROD_CAT_ID and SHP_PROD_CODE = @SHP_PROD_CODE and SHP_PROD_SIZE = @SHP_PROD_SIZE and ISDELETED <> 1 and IP = @IP

					update tblAddToShoppingCart set SHP_PROD_QTY =@count+@SHP_PROD_QTY
					WHERE SHP_SESSION_ID = @SHP_SESSION_ID and SHP_PROD_ID = @SHP_PROD_ID and SHP_PROD_CAT_ID = @SHP_PROD_CAT_ID and SHP_PROD_CODE = @SHP_PROD_CODE and SHP_PROD_SIZE = @SHP_PROD_SIZE and ISDELETED <> 1
					
				END
			ELSE
				BEGIN
					insert into tblAddToShoppingCart (SHP_SESSION_ID,SHP_PROD_ID,SHP_PROD_CAT_ID,SHP_PROD_SUB_CAT_ID,SHP_PROD_CODE,SHP_PROD_NAME,SHP_PROD_DISC_PRICE,SHP_PROD_ACTULE_PRICE,SHP_PROD_TAX,SHP_PROD_PERCENT,SHP_PROD_QTY,SHP_PROD_SIZE,SHP_PROD_IMG,SHP_PROD_DESC,PROD_DETAIL_URL,SHP_FLAG,DATE,IP,ISDELETED)
					values
					(@SHP_SESSION_ID,@SHP_PROD_ID,@SHP_PROD_CAT_ID,@SHP_PROD_SUB_CAT_ID,@SHP_PROD_CODE,@SHP_PROD_NAME,@SHP_PROD_DISC_PRICE,@SHP_PROD_ACTULE_PRICE,@SHP_PROD_TAX,@SHP_PROD_PERCENT,@SHP_PROD_QTY,@SHP_PROD_SIZE,@SHP_PROD_IMG,@SHP_PROD_DESC,@PROD_DETAIL_URL,@SHP_FLAG,GETDATE(),@IP,0)

					
				END
			
		END
		
	if(@parm = 's')
		BEGIN
			SELECT ID,SHP_PROD_CODE,SHP_PROD_NAME,SHP_PROD_DISC_PRICE,SHP_PROD_ACTULE_PRICE,SHP_PROD_TAX,SHP_PROD_PERCENT,SHP_PROD_QTY,(SHP_PROD_DISC_PRICE * SHP_PROD_QTY) as SHP_TOTAL_PRICE,SHP_PROD_SIZE,SHP_PROD_IMG,SHP_PROD_DESC,PROD_DETAIL_URL FROM TBL_RT_SHOPPINGCART with(nolock) WHERE ISDELETED <> 1 AND SHP_SESSION_ID=@SHP_SESSION_ID and IP = @IP order by ID
			SELECT sum(( SHP_PROD_DISC_PRICE * SHP_PROD_QTY)) as SUMTOTAL FROM tblAddToShoppingCart with(nolock) WHERE ISDELETED <> 1 AND SHP_SESSION_ID=@SHP_SESSION_ID and IP = @IP
		END
	if(@parm = 'd')
		BEGIN
			delete tblAddToShoppingCart WHERE ID =@ID			
		END	
	if(@parm = 'u')
		BEGIN
			update tblAddToShoppingCart SET SHP_PROD_QTY = @SHP_PROD_QTY WHERE ID = @ID			
		END	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveUserViewProducts]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<31-07-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveUserViewProducts] --sp_SaveUserViewProducts 3,1,1
@productId INT,
@userId INT,
@viewType INT, -- 0-delete,1-recentview,2-addtocart,3-wishlist
@qty INT
AS
BEGIN   
IF  EXISTS( SELECT 1 FROM tblUserViewProducts WHERE productId=@productId AND userId=@userId)
        BEGIN
		UPDATE tblUserViewProducts SET viewType=@viewType,qty=@qty,modifiedDate=GETDATE()  WHERE userId=@userId AND productId=@productId
		END
  ELSE
		BEGIN
		INSERT INTO tblUserViewProducts (productId,userId,viewType,qty ,createdDate,ModifiedDate) VALUES (@productId,@userId,@viewType,@qty,GETDATE(),GETDATE())
		END	
		
	SELECT COUNT(*) AS ViewCount FROM tblUserViewProducts WHERE userId=@userId AND viewType=@viewType AND viewType<>0		
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveUserShippingDetails]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<30-07-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveUserShippingDetails] ---sp_SaveUserShippingDetails
    @shipAddressId int,
	@MembershipId Bigint,
	@firstName varchar(20),
	@lastName varchar(20),
	@contactNo varchar(20),
	@emailId varchar(50),
	@street1 varchar(50),
	@street2 varchar(50),
	@country varchar(20),
	@state varchar(20),
	@city varchar(20),
	@pincode varchar(10)
AS

BEGIN 
SET NOCOUNT ON;

IF ( @shipAddressId = 0 )
	BEGIN        
				INSERT INTO tblUserShippingDetails
				(Membership_No,firstName,lastName,contactNo,emailId,street1,street2,country,state,city,pincode,createdBy,createdDate)
				Values
				(@MembershipId,@firstName,@lastName,@contactNo,@emailId,@street1,@street2,@country,@state,@city,@pincode,@MembershipId,GETDATE())
			
				 SET @shipAddressId=SCOPE_IDENTITY()			 								
			    
	END	
ELSE
	BEGIN
		UPDATE  tblUserShippingDetails
		SET		firstName=@firstName,
				lastName=@lastName,
				contactNo=@contactNo,
				emailId=@emailId,
		        street1=@street1,
		        street2=@street2,
				country= @country,
				state=@state,
			    city=@city,
				pincode=@pincode,			
				ModifiedBy=@MembershipId,
				ModifiedDate=GETDATE()
		WHERE shipAddressId=@shipAddressId
						
	END		
	SELECT  @shipAddressId UId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveUsers]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<30-07-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveUsers] ---sp_SaveUsers
	@memebershipId bigint,
	@userfbId varchar(50),
	@firstName varchar(50),
	@lastName varchar(50),
	@gender varchar(10),
	@emailAddress varchar(100),
	@password nvarchar(100),
	@salt nvarchar(100),
	@dob Date ='',
	@mobileNo varchar(15),
	@telePhoneNo varchar(15)='',
	@fax VARCHAR(100)='', 
	--@active BIT =1 ,--1 For Active,0 -Dective	
	@userType varchar(15),-- Guest/Registered
	@isSubscribe bit --0=No,1=Yes
	--@createdBy int=0
AS

BEGIN 
SET NOCOUNT ON;
DECLARE @CurrentUserType VARCHAR(20)
IF ( @memebershipId = 0)
	BEGIN   
			SELECT @CurrentUserType=userType FROM tblUserDetails WHERE  emailAddress=@eMailAddress
			IF(@CurrentUserType='Registered')
			BEGIN
			RAISERROR('Email address already exists',16,1)
			END
			
			ELSE IF(@CurrentUserType='FBUser')
			BEGIN
			SELECT @memebershipId=Membership_No FROM tblUserDetails WHERE emailAddress=@eMailAddress			
			UPDATE  tblUserDetails
		     SET 		       
		        firstName=@firstName,
				lastName= @lastName,
				gender=@gender,
				password=@password,
				salt=@salt,			
			    userType='Registered',
				ModifiedBy=@memebershipId,
				ModifiedDate=GETDATE()
		        WHERE Membership_No=@memebershipId  
			END
			
           ELSE IF(@CurrentUserType='')
			BEGIN    
			    SELECT @memebershipId= MAX(Membership_No+1) from tblUserDetails 
			    
				INSERT INTO tblUserDetails
				(Membership_No,userfbId,firstName,lastName,emailAddress,password,salt,dob,mobileNo,telePhoneNo, fax, active,userType,createdBy,creationDate)
				Values
				(@memebershipId,@userfbId,@firstName,@lastName,@emailAddress,@password,@salt,@dob,@mobileNo,@telePhoneNo, @fax, 1,@userType,@memebershipId,GETDATE())
				IF(@isSubscribe=1)
				BEGIN
			    INSERT INTO tblSubscribeUsers (emailAddress,active,subscribeDate) VALUES(@emailAddress,1,GETDATE())
			    END			    
			    
				SELECT @memebershipId

			END
	END	
ELSE
	BEGIN
		UPDATE  tblUserDetails
		SET		userfbId=@userfbId,
		        firstName=@firstName,
				lastName= @lastName,
				gender=@gender,
				emailAddress=@emailAddress,
				dob=@dob,
			    mobileNo=@mobileNo,
				telePhoneNo=@telePhoneNo,
				fax=@fax,
				ModifiedBy=@memebershipId,
				ModifiedDate=GETDATE()
		WHERE Membership_No=@memebershipId
				
	END		
	exec sp_GetUserDetails @memebershipId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_FBLogin]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<30-07-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_FBLogin] ---sp_FBLogin
	@userfbId varchar(50),
	@firstName varchar(50),
	@lastName varchar(50),	
	@emailAddress varchar(100),
	@gender varchar(10)	
AS

BEGIN 
SET NOCOUNT ON;


DECLARE @memebershipId nvarchar(100)
        IF NOT EXISTS(SELECT 1 FROM tblUserDetails WHERE  emailAddress=@emailAddress)
			BEGIN
			SELECT @memebershipId= MAX(Membership_No+1) from tblUserDetails 
			    
				INSERT INTO tblUserDetails
				(Membership_No,userfbId,firstName,lastName,emailAddress,gender,active,userType,createdBy,creationDate)
				Values
				(@memebershipId,@userfbId,@firstName,@lastName,@emailAddress,@gender,1,'FBUser',@memebershipId,GETDATE())			    
	   END
	   ELSE
			BEGIN
			SELECT @memebershipId=Membership_No FROM tblUserDetails WHERE  emailAddress=@emailAddress
	   END


	exec sp_GetUserDetails @memebershipId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductsListing]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sheeloo UNIKOVE>
-- Create date: <29 July 14>
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductsListing]--sp_GetProductsListing 2,'','',0,0,'',0,0,''
@CategoryId INT=0,
@varAttrXML nvarchar(1000),
@PriceRangeMin INT,
@PriceRangeMax INT,
@OfferTypeId VARCHAR(50),
@StartIndex INT, --start from 0
@EndIndex INT,
@SortBy VARCHAR(50)
AS
BEGIN
WITH CTE AS (
	SELECT 
	 ROW_NUMBER() OVER ( ORDER BY  prd.productId) SNo,
	 prd.productId,prd.categoryId,prd.productTitle,prd.skuID,prd.description,prd.Shortdescription,
	 prd.MSRP,prd.salePrice,prd.colour,prd.colourCode,prd.weight 
	 ,'mat' as  metarialName,cat.categoryName,prd.createdDate,prd.noviewed,'1' as groupId,prd.quantity,
	 '4' as availableFor,'1' as newArrival,prd.rating
	 FROM tblProducts AS prd 	  
	 LEFT JOIN tblCategory cat ON cat.categoryId=prd.categoryId	 
	 --WHERE prd.categoryId=CASE WHEN @CategoryId=0 THEN prd.categoryId ELSE @CategoryId END 
	-- AND prd.productId IN(SELECT ATTR.productId FROM tblProductAttributes ATTR WHERE ATTR.size IN (@Sizes))
	-- AND  prd.productId IN(SELECT Ofr.productId FROM tblOffers Ofr WHERE Ofr.offerId IN (@OfferTypeId))
	-- AND prd.colourCode IN (@ColorCode)
	-- AND salePrice>=@PriceRangeMin 
	-- AND salePrice<=@PriceRangeMax	  
	  )	  	  
	 
	 SELECT  * FROM CTE  WHERE SNo >=@StartIndex AND SNo<=@EndIndex
	-- ORDER BY  
	-- CASE WHEN @SortBy='POPULARITY' THEN noviewed END DESC,
	-- CASE WHEN @SortBy='NEW' THEN   createdDate END DESC,
	-- CASE WHEN @SortBy='PRICE LOW' THEN salePrice END ASC,
	-- CASE WHEN @SortBy='PRICE HIGH' THEN salePrice END DESC 
	 
 
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductsListByCat]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sheeloo UNIKOVE>
-- Create date: <29 July 14>
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductsListByCat]--sp_GetProductsList 2,'','',0,0,'',0,0,''
@CategoryId INT=0,
@StartIndex int=0,
@EndIndex int=10
AS
BEGIN
WITH CTE AS (
	SELECT 
	 ROW_NUMBER() OVER ( ORDER BY  prd.productId) SNo,
	 prd.productId,prd.categoryId,prd.productTitle,prd.skuID,prd.description,prd.Shortdescription,
	 prd.MSRP,prd.salePrice,prd.colour,prd.colourCode,prd.weight 
	 ,'mat' as  metarialName,cat.categoryName,prd.createdDate,prd.noviewed,'1' as groupId,prd.quantity,
	 '4' as availableFor,'1' as newArrival,prd.rating
	 FROM tblProducts AS prd 	  
	 LEFT JOIN tblCategory cat ON cat.categoryId=prd.categoryId	 
	 --WHERE prd.categoryId=CASE WHEN @CategoryId=0 THEN prd.categoryId ELSE @CategoryId END 
	-- AND prd.productId IN(SELECT ATTR.productId FROM tblProductAttributes ATTR WHERE ATTR.size IN (@Sizes))
	-- AND  prd.productId IN(SELECT Ofr.productId FROM tblOffers Ofr WHERE Ofr.offerId IN (@OfferTypeId))
	-- AND prd.colourCode IN (@ColorCode)
	-- AND salePrice>=@PriceRangeMin 
	-- AND salePrice<=@PriceRangeMax	  
  )	  	  
	 
	 SELECT * FROM CTE  WHERE SNo >=@StartIndex AND SNo<=@EndIndex
	-- ORDER BY  
	-- CASE WHEN @SortBy='POPULARITY' THEN noviewed END DESC,
	-- CASE WHEN @SortBy='NEW' THEN   createdDate END DESC,
	-- CASE WHEN @SortBy='PRICE LOW' THEN salePrice END ASC,
	-- CASE WHEN @SortBy='PRICE HIGH' THEN salePrice END DESC 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductsList]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sheeloo UNIKOVE>
-- Create date: <29 July 14>
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductsList]--sp_GetProductsList 2,'','',0,0,'',0,0,''
@CategoryId INT=0,
@ColorCode VARCHAR(50),  --0 for all
@Sizes VARCHAR(50), --0 for all 
@PriceRangeMin INT,
@PriceRangeMax INT,
@OfferTypeId VARCHAR(50),
@StartIndex INT, --start from 0
@EndIndex INT,
@SortBy VARCHAR(50)
AS
BEGIN
WITH CTE AS (
	SELECT 
	 ROW_NUMBER() OVER ( ORDER BY  prd.productId) SNo,
	 prd.productId,prd.categoryId,prd.productTitle,prd.skuID,prd.description,prd.Shortdescription,
	 prd.MSRP,prd.salePrice,prd.colour,prd.colourCode,prd.weight 
	 ,'mat' as  metarialName,cat.categoryName,prd.createdDate,prd.noviewed,'1' as groupId,prd.quantity,
	 '4' as availableFor,'1' as newArrival,prd.rating
	 FROM tblProducts AS prd 	  
	 LEFT JOIN tblCategory cat ON cat.categoryId=prd.categoryId	 
	 --WHERE prd.categoryId=CASE WHEN @CategoryId=0 THEN prd.categoryId ELSE @CategoryId END 
	-- AND prd.productId IN(SELECT ATTR.productId FROM tblProductAttributes ATTR WHERE ATTR.size IN (@Sizes))
	-- AND  prd.productId IN(SELECT Ofr.productId FROM tblOffers Ofr WHERE Ofr.offerId IN (@OfferTypeId))
	-- AND prd.colourCode IN (@ColorCode)
	-- AND salePrice>=@PriceRangeMin 
	-- AND salePrice<=@PriceRangeMax	  
	  )	  	  
	 
	 SELECT  * FROM CTE  WHERE SNo >=@StartIndex AND SNo<=@EndIndex
	-- ORDER BY  
	-- CASE WHEN @SortBy='POPULARITY' THEN noviewed END DESC,
	-- CASE WHEN @SortBy='NEW' THEN   createdDate END DESC,
	-- CASE WHEN @SortBy='PRICE LOW' THEN salePrice END ASC,
	-- CASE WHEN @SortBy='PRICE HIGH' THEN salePrice END DESC 
	 
 
	
END
GO
/****** Object:  Table [dbo].[tblProductImages]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProductImages](
	[imgId] [int] NOT NULL,
	[productId] [int] NULL,
	[imgUrl] [varchar](200) NULL,
	[groupId] [int] NULL,
	[createdBy] [int] NULL,
	[createdDate] [datetime] NULL,
	[modifiedBy] [int] NULL,
	[modifiedDate] [datetime] NULL,
 CONSTRAINT [PK_tblProductImages] PRIMARY KEY CLUSTERED 
(
	[imgId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOffers]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOffers](
	[offerId] [int] IDENTITY(1111,1) NOT NULL,
	[offerTitle] [varchar](100) NOT NULL,
	[percentage] [float] NULL,
	[productId] [int] NOT NULL,
	[validFrom] [datetime] NULL,
	[validTill] [datetime] NULL,
	[createdDate] [datetime] NULL,
 CONSTRAINT [PK_tblOffers] PRIMARY KEY CLUSTERED 
(
	[offerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductDetails]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sheeloo UNIKOVE>
-- Create date: <29 July 14>
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductDetails]--sp_GetProductDetails 2,1
@CategoryId INT=0,
@ProductId INT=0
AS
BEGIN
 
	 SELECT 
	 prd.productId,prd.categoryId,prd.productTitle,prd.skuID,prd.description,prd.Shortdescription,
	 prd.MSRP,prd.salePrice,prd.colour,prd.colourCode,prd.weight 
	 ,'mat' as  metarialName,cat.categoryName,prd.createdDate,prd.noviewed,'1' as groupId,prd.quantity,
	 '4' as availableFor,'1' as newArrival,prd.rating
	 FROM tblProducts AS prd 	  
	 LEFT JOIN tblCategory cat ON cat.categoryId=prd.categoryId	
	 WHERE productId=@ProductId
	
	
	select attributeValue from tblAttributeValues 
	where attributeId=1 and productId=@ProductId and isAvailableFor=1
	 
	  	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserStatusList]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Anand Jaiswal>
-- Date:<30-07-2014>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserStatusList] --sp_GetUserStatusList 2,2
@membershipId nvarchar(100),
@viewType INT,
@sessionId nvarchar(100)
AS
BEGIN       
		SELECT viewId,U.productId,p.productTitle,p.productTitle AS productName,U.qty,p.salePrice,(U.qty * p.salePrice) AS subTotal,IM.imgUrl AS imgUrl,
		(SELECT sum(U.qty * p.salePrice) FROM tblUserViewProducts U JOIN tblProducts P ON p.productId=u.productId
		LEFT JOIN tblProductImages IM ON im.productId=p.productId WHERE Membership_No=@membershipId AND viewType=@viewType)	AS totalAmount	
		  FROM tblUserViewProducts U
		JOIN tblProducts P ON p.productId=u.productId
		LEFT JOIN tblProductImages IM ON im.productId=p.productId		
		WHERE Membership_No=@membershipId AND viewType=@viewType ORDER BY  U.modifiedDate DESC		
			
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductsleftMenu]    Script Date: 08/09/2014 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sheeloo UNIKOVE>
-- Create date: <04 aug 14>
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductsleftMenu]---[sp_GetProductsleftMenu] 2,4
@CategoryId int=0,
@subCategoryId int=0 
AS
BEGIN

	
	SELECT cat1.categoryId,cat1.pId,cat1.description, cat2.categoryName category,cat1.categoryName subCategory  
	FROM tblCategory cat1 
	left JOIN dbo.tblCategory cat2 ON cat1.pId=cat2.categoryId 
	where cat1.pId=CASE WHEN @CategoryId=0 THEN cat1.pId ELSE @CategoryId END
	ORDER BY cat1.seqorder 
	
    --select distinct cprd.colourCode from tblProducts cprd

  select distinct tblAttributes.attributeId,tblAttributes.attributeTitle   from tblAttributeValues
left JOIN tblProducts ON tblAttributeValues.ProductId=tblProducts.ProductId
left join tblAttributes on  tblAttributeValues.attributeId=tblAttributes.attributeId
where CategoryId=4
 
 
 select distinct tblAttributes.attributeId, attributeValue,tblAttributes.attributeTitle   from tblAttributeValues
left JOIN tblProducts ON tblAttributeValues.ProductId=tblProducts.ProductId
left join tblAttributes on  tblAttributeValues.attributeId=tblAttributes.attributeId
where CategoryId=4
and tblAttributeValues.attributeId in ( select Distinct ta.attributeId from tblAttributes ta
 right join tblAttributeValues AttrVal 
 on ta.attributeId=AttrVal.attributeId)
 
SELECT  MIN(salePrice) minvalue,MAX(salePrice) maxvalue FROM tblProducts
WHERE categoryId=@subCategoryId

select offerId,offerTitle,percentage from tblOffers where validFrom<=GETDATE()
 
END
GO
/****** Object:  Default [DF_tblProducts_IsNewArrival]    Script Date: 08/09/2014 15:25:02 ******/
ALTER TABLE [dbo].[tblProducts] ADD  CONSTRAINT [DF_tblProducts_IsNewArrival]  DEFAULT ((1)) FOR [IsNewArrival]
GO
/****** Object:  Default [DF_tblProducts_createdDate]    Script Date: 08/09/2014 15:25:02 ******/
ALTER TABLE [dbo].[tblProducts] ADD  CONSTRAINT [DF_tblProducts_createdDate]  DEFAULT (getdate()) FOR [createdDate]
GO
/****** Object:  Default [DF_tblUserViewProducts_qty]    Script Date: 08/09/2014 15:25:02 ******/
ALTER TABLE [dbo].[tblUserViewProducts] ADD  CONSTRAINT [DF_tblUserViewProducts_qty]  DEFAULT ((0)) FOR [qty]
GO
/****** Object:  ForeignKey [FK_tblOffers_tblProducts]    Script Date: 08/09/2014 15:25:02 ******/
ALTER TABLE [dbo].[tblOffers]  WITH CHECK ADD  CONSTRAINT [FK_tblOffers_tblProducts] FOREIGN KEY([productId])
REFERENCES [dbo].[tblProducts] ([productId])
GO
ALTER TABLE [dbo].[tblOffers] CHECK CONSTRAINT [FK_tblOffers_tblProducts]
GO
/****** Object:  ForeignKey [FK_tblProductImages_tblProducts]    Script Date: 08/09/2014 15:25:02 ******/
ALTER TABLE [dbo].[tblProductImages]  WITH CHECK ADD  CONSTRAINT [FK_tblProductImages_tblProducts] FOREIGN KEY([productId])
REFERENCES [dbo].[tblProducts] ([productId])
GO
ALTER TABLE [dbo].[tblProductImages] CHECK CONSTRAINT [FK_tblProductImages_tblProducts]
GO
/****** Object:  ForeignKey [FK_tblProducts_tblCategory]    Script Date: 08/09/2014 15:25:02 ******/
ALTER TABLE [dbo].[tblProducts]  WITH CHECK ADD  CONSTRAINT [FK_tblProducts_tblCategory] FOREIGN KEY([categoryId])
REFERENCES [dbo].[tblCategory] ([categoryId])
GO
ALTER TABLE [dbo].[tblProducts] CHECK CONSTRAINT [FK_tblProducts_tblCategory]
GO
