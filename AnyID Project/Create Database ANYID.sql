SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankAccount](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountNameMLSID] [bigint] NULL,
	[AccountNo] [nvarchar](255) NULL,
	[AccountType] [int] NULL,
	[BankID] [int] NULL,
	[BranchID] [int] NULL,
	[BankCode] [nvarchar](255) NULL,
	[BranchCode] [nvarchar](255) NULL,
	[CategoryNodeID] [int] NULL,
	[CurrentBalanceID] [int] NULL,
	[ConsecutiveDebitRejects] [int] NULL,
	[CurrencyCode] [nvarchar](255) NULL,
	[DirectDebitStatus] [int] NULL,
	[EffectiveFrom] [datetime2](7) NULL,
	[EffectiveTo] [datetime2](7) NULL,
	[GrantRemark] [nvarchar](255) NULL,
	[IsEFTEnable] [bit] NULL,
	[PowerOfAttorneyGrantFrom] [datetime2](7) NULL,
	[PowerOfAttorneyGrantTo] [datetime2](7) NULL,
	[Status] [int] NULL,
	[StatusDate] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedTS] [datetime2](7) NULL,
	[UniqueAccountNo] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK__BankAcco__4FC8E741441C8608] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Configuration]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EffectiveFrom] [datetime2](7) NULL,
	[EffectiveTo] [datetime2](7) NULL,
	[SystemID] [int] NULL,
	[DefaultCountryCode] [nvarchar](3) NULL,
	[DefaultLanguageCode] [nchar](5) NULL,
	[DefaultNationalityNodeID] [bigint] NULL,
	[GeographicAddressCategoryRootNodeID] [bigint] NULL,
	[PositionAppointmentCategoryRootNodeID] [bigint] NULL,
	[HiringCategoryRootNodeID] [bigint] NULL,
	[OrganizationIdentityCategoryRootNodeID] [bigint] NULL,
	[InterOrgUnitRelationCategoryRootNodeID] [bigint] NULL,
	[OrgUnitPositionCategoryRootNodeID] [bigint] NULL,
	[OrganizationPersonRelationshipCategoryRootNodeID] [bigint] NULL,
	[AcademicProfessionCategoryID] [bigint] NULL,
	[BloodGroupRootNodeID] [bigint] NULL,
	[GenderRootNodeID] [bigint] NULL,
	[PersonIdentityCategoryRootNodeID] [bigint] NULL,
	[InterPersonRelationshipCategoryRootNodeID] [bigint] NULL,
	[PersonNamePrefixRootNodeID] [bigint] NULL,
	[PersonNameSuffixRootNodeID] [bigint] NULL,
	[NationalityRootNodeID] [bigint] NULL,
	[ReligionRootNodeID] [bigint] NULL,
	[MaxConsecutiveFailedLogonAttempts] [int] NULL,
	[MaxDaysOfInactivity] [int] NULL,
	[MinNumberOfSpecialCharsInPassword] [int] NULL,
	[MinNumberOfCapitalLettersInPassword] [int] NULL,
	[MinNumberOfSmallLettersInPassword] [int] NULL,
	[MinNumberOfDigitsInPassword] [int] NULL,
	[MaxPasswordLength] [int] NULL,
	[MinPasswordLength] [int] NULL,
	[MaxUsernameLength] [int] NULL,
	[MinUsernameLength] [int] NULL,
	[PasswordAgeInDays] [int] NULL,
	[PasswordHistoryDepth] [int] NULL,
	[WebSessionTimeoutValueInMinutes] [int] NULL,
	[EducationLevelRootNodeID] [bigint] NULL,
	[FirstMonthOfLeaveYear] [bigint] NULL,
	[PositionCategoryRootID] [bigint] NULL,
	[ProfessionCategoryRootID] [bigint] NULL,
	[AcademicRankRootNodeID] [bigint] NULL,
	[DefaultCurrencyCode] [nchar](3) NULL,
	[SystemOwnerOrgID] [bigint] NULL,
	[WorkCalendarID] [int] NULL,
	[EmployeeHiringCategoryRootNodeID] [bigint] NULL,
	[EmployeeTerminationCategoryRootNodeID] [bigint] NULL,
	[AddressCategoryRootNodeID] [bigint] NULL,
	[MaritalStatusRootNodeID] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[ISOAlpha3Code] [nchar](3) NOT NULL,
	[LevelCount] [int] NULL,
	[ISOAlpha2Code] [nchar](2) NULL,
	[ISONumericCode] [int] NULL,
	[Remark] [nvarchar](255) NULL,
	[IsActive] [bit] NULL,
	[OfficialLanguageCode] [nchar](5) NULL,
	[AltOfficialLanguageCode] [nchar](5) NULL,
	[NameMLSId] [bigint] NOT NULL,
	[AbbreviatedNameMLSID] [bigint] NULL,
	[NationalityNameMLSID] [bigint] NULL,
	[Level1RegionTitleID] [bigint] NULL,
	[Level2RegionTitleID] [bigint] NULL,
	[Level3RegionTitleID] [bigint] NULL,
	[Level4RegionTitleID] [bigint] NULL,
	[Level1RegionRootNodeID] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ISOAlpha3Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Currency]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[ISOCode] [nvarchar](255) NOT NULL,
	[CurrencySymbol] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[EffectiveFrom] [datetime] NULL,
	[EffectiveTo] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ISOCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Language]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Language](
	[LanguageCode] [nchar](5) NOT NULL,
	[SeqNo] [int] NULL,
	[ShortTitle] [nvarchar](255) NULL,
	[SmallImageBytes] [varbinary](max) NULL,
	[Title] [nvarchar](255) NULL,
 CONSTRAINT [PK__Language__8B8C8A35AC6D6CB3] PRIMARY KEY CLUSTERED 
(
	[LanguageCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Log]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [varchar](4000) NOT NULL,
	[Exception] [varchar](2000) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MLSValue]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MLSValue](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MLSID] [bigint] NULL,
	[LanguageCode] [nvarchar](255) NULL,
	[Value] [nvarchar](255) NULL,
	[UpdatedTS] [datetime] NULL,
 CONSTRAINT [PK__MLSValue__D058E75CCD44463B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MultilingualString]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MultilingualString](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Code] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Password]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Password](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NULL,
	[EncryptedPassword] [nvarchar](1024) NULL,
	[EffectiveFrom] [datetime2](7) NULL,
	[EffectiveTo] [datetime2](7) NULL,
 CONSTRAINT [PK__Password__EA7BF0E894EC9685] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NULL,
	[Code] [nvarchar](255) NULL,
	[TitleMLSID] [bigint] NULL,
	[DescriptionMLSID] [bigint] NULL,
	[IsBuiltin] [bit] NULL,
	[PrivilegeLevel] [int] NULL,
	[SeqNo] [int] NULL,
	[EffectiveFrom] [datetime2](7) NULL,
	[EffectiveTo] [datetime2](7) NULL,
	[OrgUnitID] [bigint] NULL,
	[IsDefault] [bit] NULL,
 CONSTRAINT [PK__Role__8AFACE3ACFDB42D6] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleUseCase]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUseCase](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[UseCaseID] [int] NULL,
	[CanDisplay] [bit] NOT NULL,
	[CanAddData] [bit] NOT NULL,
	[CanChangeData] [bit] NOT NULL,
	[CanDeleteData] [bit] NOT NULL,
	[CanPrintData] [bit] NOT NULL,
	[SeqNo] [int] NULL,
	[EffectiveTo] [datetime2](7) NULL,
	[EffectiveFrom] [datetime2](7) NULL,
	[Reference] [nvarchar](255) NULL,
	[Remark] [nvarchar](4000) NULL,
 CONSTRAINT [PK__RoleMenu__F862879680C9B8E7] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RunningNumber]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RunningNumber](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](255) NOT NULL,
	[Next] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SequenceNumbers]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SequenceNumbers](
	[SystemID] [int] NOT NULL,
	[SequenceType] [int] NOT NULL,
	[SubsequenceType] [bigint] NOT NULL,
	[SequenceNo] [bigint] NOT NULL,
	[Seed] [bigint] NOT NULL CONSTRAINT [DF_SequenceNumbers_Seed]  DEFAULT ((1)),
	[Increment] [bigint] NOT NULL CONSTRAINT [DF_SequenceNumbers_Increment]  DEFAULT ((1)),
	[Pattern] [nvarchar](20) NULL,
 CONSTRAINT [PK_SequenceNumbers] PRIMARY KEY CLUSTERED 
(
	[SystemID] ASC,
	[SequenceType] ASC,
	[SubsequenceType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SystemUser]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUser](
	[SystemUserID] [int] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NULL,
	[EffectiveFrom] [datetime] NULL,
	[EffectiveTo] [datetime] NULL,
	[IsDisable] [bit] NULL,
	[UserId] [bigint] NULL,
 CONSTRAINT [PK__SystemUs__8788C275F4322ABF] PRIMARY KEY CLUSTERED 
(
	[SystemUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_T_Account_Proxy]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_T_Account_Proxy](
	[PK_Account_Proxy] [bigint] IDENTITY(1,1) NOT NULL,
	[FK_AnyID] [bigint] NULL,
	[Bank_Account_No] [nvarchar](20) NULL,
	[CIS_ID] [nvarchar](20) NULL,
	[Current_State_Category] [tinyint] NULL,
	[FK_Account_Proxy_State] [bigint] NULL,
	[Display_Name] [nvarchar](255) NULL,
	[Dummy_Account_No] [nvarchar](20) NULL,
	[First_Name] [nvarchar](40) NULL,
	[Last_Name] [nvarchar](40) NULL,
	[Proxy_No] [bigint] NULL,
	[Proxy_Type] [tinyint] NULL,
	[Registering_Branch] [nvarchar](8) NULL,
	[Registered_TS] [datetime2](7) NULL,
	[Registration_ID] [nchar](12) NULL,
	[Requested_TS] [datetime2](7) NULL,
	[Status] [tinyint] NULL,
	[Bank_Account_Name] [nvarchar](80) NULL,
	[Bank_Code] [nvarchar](8) NULL,
	[Branch_Code] [nvarchar](8) NULL,
	[Bank_Account_Status] [tinyint] NULL,
	[FK_Proxy_Transaction] [bigint] NULL,
	[FK_Customer] [bigint] NULL,
	[KK_Required_State_Description] [nvarchar](40) NULL,
	[FK_Bank_Account] [bigint] NULL,
	[FK_User] [bigint] NULL,
 CONSTRAINT [PK__TB_T_Acc__58A0771015FFF8CD] PRIMARY KEY CLUSTERED 
(
	[PK_Account_Proxy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_T_Account_Proxy_State]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_T_Account_Proxy_State](
	[PK_Account_Proxy_State] [bigint] IDENTITY(1,1) NOT NULL,
	[FK_Account_Proxy] [bigint] NULL,
	[FK_User] [bigint] NULL,
	[Created_TS] [datetime2](7) NULL,
	[Is_Final] [bit] NULL,
	[Reference] [nvarchar](200) NULL,
	[Remark] [nvarchar](200) NULL,
	[State_Category] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_Account_Proxy_State] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_T_AnyID]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_T_AnyID](
	[PK_AnyID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_No] [nvarchar](20) NULL,
	[ID_Type] [tinyint] NULL,
	[Status] [tinyint] NULL,
	[Display_ID_No] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_AnyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_T_Customer]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_T_Customer](
	[PK_Customer] [bigint] IDENTITY(1,1) NOT NULL,
	[Birth_Date] [datetime2](7) NULL,
	[CIS_ID] [nvarchar](20) NULL,
	[Customer_Segment] [nvarchar](80) NULL,
	[FATCA] [nvarchar](80) NULL,
	[KYC_Level] [nvarchar](80) NULL,
	[First_Name] [nvarchar](40) NULL,
	[Gender] [nvarchar](40) NULL,
	[Home_Phone_No] [nvarchar](20) NULL,
	[ID_No] [nvarchar](20) NULL,
	[ID_Type] [tinyint] NULL,
	[Last_Name] [nvarchar](40) NULL,
	[Marital_Status] [nvarchar](40) NULL,
	[Mobile_Phone_No] [nvarchar](20) NULL,
	[Office_Phone_No] [nvarchar](20) NULL,
	[Sanction] [nvarchar](80) NULL,
	[Status] [tinyint] NULL,
	[Discriminator] [tinyint] NULL,
	[Customer_RM] [nvarchar](80) NULL,
	[Customer_Type] [nvarchar](80) NULL,
	[Email_Address] [nvarchar](80) NULL,
	[First_Name_Eng] [nvarchar](40) NULL,
	[Last_Name_Eng] [nvarchar](40) NULL,
 CONSTRAINT [PK__TB_T_Cus__A2B9FEE5E4E30C42] PRIMARY KEY CLUSTERED 
(
	[PK_Customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_T_Proxy_Transaction]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_T_Proxy_Transaction](
	[PK_Proxy_Transaction] [bigint] IDENTITY(1,1) NOT NULL,
	[Discriminator] [tinyint] NOT NULL,
	[FK_Account_Proxy_1] [bigint] NULL,
	[FK_Account_Proxy_2] [bigint] NULL,
	[CIS_ID] [nvarchar](20) NULL,
	[Current_State_Category] [tinyint] NULL,
	[FK_Proxy_Transaction_State] [bigint] NULL,
	[Registration_ID] [nchar](12) NULL,
	[Retry_Count] [int] NULL,
	[Transaction_No] [nvarchar](12) NULL,
	[Transaction_TS] [datetime2](7) NULL,
	[Branch_Code] [nvarchar](8) NULL,
	[Is_Not_Finalized] [bit] NULL,
	[FK_User] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_Proxy_Transaction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_T_Proxy_Transaction_State]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_T_Proxy_Transaction_State](
	[PK_Proxy_Transaction_State] [bigint] IDENTITY(1,1) NOT NULL,
	[FK_Proxy_Transaction] [bigint] NULL,
	[FK_User] [bigint] NULL,
	[Created_TS] [datetime2](7) NULL,
	[Is_Final] [bit] NULL,
	[Reference] [nvarchar](200) NULL,
	[Remark] [nvarchar](4000) NULL,
	[State_Category] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_Proxy_Transaction_State] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_T_Transaction_Document]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_T_Transaction_Document](
	[PK_Transaction_Document] [bigint] IDENTITY(1,1) NOT NULL,
	[Document_Content] [varbinary](max) NULL,
	[Document_File_Name] [nvarchar](200) NULL,
	[Document_Format] [nvarchar](200) NULL,
	[Document_Type] [nvarchar](40) NULL,
	[FK_Proxy_Transaction] [bigint] NULL,
	[FK_User] [bigint] NULL,
	[Uploaded_TS] [datetime2](7) NULL,
 CONSTRAINT [PK__TB_T_Tra__E702166ACCD8D177] PRIMARY KEY CLUSTERED 
(
	[PK_Transaction_Document] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TreeListNode]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TreeListNode](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](255) NULL,
	[DescriptionMLSID] [bigint] NULL,
	[EffectiveFrom] [datetime2](7) NULL,
	[EffectiveTo] [datetime2](7) NULL,
	[IsActive] [bit] NULL,
	[IsBuiltin] [bit] NULL,
	[IsCredit] [bit] NULL,
	[IsDebit] [bit] NULL,
	[IsDefault] [bit] NULL,
	[IsImmutable] [bit] NULL,
	[IsMandatory] [bit] NULL,
	[IsParent] [bit] NULL,
	[NodeLevel] [int] NOT NULL,
	[RelatedNodeID] [bigint] NULL,
	[RelatedNodeTitleMLSID] [bigint] NULL,
	[Remark] [nvarchar](255) NULL,
	[RootNodeID] [bigint] NULL,
	[ParentNodeID] [bigint] NULL,
	[SeqNo] [int] NOT NULL,
	[ShortTitleMLSID] [bigint] NULL,
	[TitleMLSID] [bigint] NULL,
	[ValueDate] [datetime2](7) NULL,
	[ValueNumber] [float] NULL,
	[ValueMLSID] [bigint] NULL,
	[ValueString] [nvarchar](255) NULL,
	[ValueTypes] [int] NULL,
	[Weight] [float] NULL,
 CONSTRAINT [PK__TreeList__6BAE224360EA15DD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UseCase]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseCase](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](40) NULL,
	[EffectiveFrom] [datetime2](7) NULL,
	[EffectiveTo] [datetime2](7) NULL,
	[TitleMLSID] [bigint] NULL,
	[DescriptionMLSID] [bigint] NULL,
	[Reference] [nvarchar](400) NULL,
	[Remark] [nvarchar](4000) NULL,
	[URL] [nvarchar](4000) NULL,
	[PageCode] [nvarchar](255) NULL,
	[ParentID] [bigint] NULL,
	[SeqNo] [int] NULL,
	[SystemID] [int] NULL,
 CONSTRAINT [PK__UseCase__3214EC2773A40330] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EffectiveFrom] [datetime2](7) NULL,
	[EffectiveTo] [datetime2](7) NULL,
	[UserID] [bigint] NULL,
	[RoleID] [bigint] NULL,
	[Reference] [nvarchar](255) NULL,
	[Remark] [nvarchar](4000) NULL,
 CONSTRAINT [PK__UserRole__3214EC277386B606] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Discriminator] [tinyint] NOT NULL,
	[SystemID] [int] NULL,
	[IsNotFinalized] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedTS] [datetime2](7) NULL,
	[ApprovedBy] [bigint] NULL,
	[ApprovedTS] [datetime2](7) NULL,
	[EffectiveFrom] [datetime2](7) NULL,
	[EffectiveTo] [datetime2](7) NULL,
	[ConsecutiveFailedLoginCount] [int] NULL,
	[IsBuiltin] [bit] NULL,
	[IsDisable] [bit] NULL,
	[LastLoginTimestamp] [datetime2](7) NULL,
	[LastFailedLoginTimestamp] [datetime2](7) NULL,
	[OrgID] [bigint] NULL,
	[PersonId] [bigint] NULL,
	[LoginName] [nvarchar](255) NULL,
	[EMailAddress] [nvarchar](255) NULL,
	[MobilePhoneNumber] [nvarchar](255) NULL,
	[CurrentPasswordID] [int] NULL,
	[IsReinstated] [bit] NULL,
	[MustChangePasswordAfterFirstLogon] [bit] NULL,
	[MustChangePasswordAtNextLogon] [bit] NULL,
	[PasswordAgeInDays] [int] NULL,
	[PasswordNeverExpires] [bit] NULL,
	[BranchCode] [nvarchar](10) NULL,
	[Name] [nvarchar](80) NULL,
 CONSTRAINT [PK__Users__1788CCACC52AC720] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSession]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSession](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ApplicationSessionID] [nvarchar](255) NULL,
	[FromIPAddress] [nvarchar](255) NULL,
	[IsTimeOut] [bit] NULL,
	[SigninTS] [datetime2](7) NULL,
	[SignoutTS] [datetime2](7) NULL,
	[SystemID] [int] NULL,
	[UserID] [bigint] NULL,
 CONSTRAINT [PK__UserSess__E73711851C6BDDE6] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSessionLog]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSessionLog](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FunctionID] [int] NULL,
	[PageID] [int] NULL,
	[MenuID] [int] NULL,
	[UserSessionID] [bigint] NULL,
	[Timestamp] [datetime2](7) NULL,
	[Message] [nvarchar](4000) NULL,
	[Action] [nvarchar](255) NULL,
 CONSTRAINT [PK__UserSess__3214EC276E1F0C7A] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Configuration] ON 

GO
INSERT [dbo].[Configuration] ([ID], [EffectiveFrom], [EffectiveTo], [SystemID], [DefaultCountryCode], [DefaultLanguageCode], [DefaultNationalityNodeID], [GeographicAddressCategoryRootNodeID], [PositionAppointmentCategoryRootNodeID], [HiringCategoryRootNodeID], [OrganizationIdentityCategoryRootNodeID], [InterOrgUnitRelationCategoryRootNodeID], [OrgUnitPositionCategoryRootNodeID], [OrganizationPersonRelationshipCategoryRootNodeID], [AcademicProfessionCategoryID], [BloodGroupRootNodeID], [GenderRootNodeID], [PersonIdentityCategoryRootNodeID], [InterPersonRelationshipCategoryRootNodeID], [PersonNamePrefixRootNodeID], [PersonNameSuffixRootNodeID], [NationalityRootNodeID], [ReligionRootNodeID], [MaxConsecutiveFailedLogonAttempts], [MaxDaysOfInactivity], [MinNumberOfSpecialCharsInPassword], [MinNumberOfCapitalLettersInPassword], [MinNumberOfSmallLettersInPassword], [MinNumberOfDigitsInPassword], [MaxPasswordLength], [MinPasswordLength], [MaxUsernameLength], [MinUsernameLength], [PasswordAgeInDays], [PasswordHistoryDepth], [WebSessionTimeoutValueInMinutes], [EducationLevelRootNodeID], [FirstMonthOfLeaveYear], [PositionCategoryRootID], [ProfessionCategoryRootID], [AcademicRankRootNodeID], [DefaultCurrencyCode], [SystemOwnerOrgID], [WorkCalendarID], [EmployeeHiringCategoryRootNodeID], [EmployeeTerminationCategoryRootNodeID], [AddressCategoryRootNodeID], [MaritalStatusRootNodeID]) VALUES (1, CAST(N'2010-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 10, N'THA', N'th-TH', NULL, NULL, 59, 78, NULL, NULL, 74, NULL, NULL, 6, 21, NULL, 25, NULL, NULL, NULL, 34, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, NULL, 1, 82, 1, N'THB', NULL, NULL, 63, 67, NULL, 29)
GO
INSERT [dbo].[Configuration] ([ID], [EffectiveFrom], [EffectiveTo], [SystemID], [DefaultCountryCode], [DefaultLanguageCode], [DefaultNationalityNodeID], [GeographicAddressCategoryRootNodeID], [PositionAppointmentCategoryRootNodeID], [HiringCategoryRootNodeID], [OrganizationIdentityCategoryRootNodeID], [InterOrgUnitRelationCategoryRootNodeID], [OrgUnitPositionCategoryRootNodeID], [OrganizationPersonRelationshipCategoryRootNodeID], [AcademicProfessionCategoryID], [BloodGroupRootNodeID], [GenderRootNodeID], [PersonIdentityCategoryRootNodeID], [InterPersonRelationshipCategoryRootNodeID], [PersonNamePrefixRootNodeID], [PersonNameSuffixRootNodeID], [NationalityRootNodeID], [ReligionRootNodeID], [MaxConsecutiveFailedLogonAttempts], [MaxDaysOfInactivity], [MinNumberOfSpecialCharsInPassword], [MinNumberOfCapitalLettersInPassword], [MinNumberOfSmallLettersInPassword], [MinNumberOfDigitsInPassword], [MaxPasswordLength], [MinPasswordLength], [MaxUsernameLength], [MinUsernameLength], [PasswordAgeInDays], [PasswordHistoryDepth], [WebSessionTimeoutValueInMinutes], [EducationLevelRootNodeID], [FirstMonthOfLeaveYear], [PositionCategoryRootID], [ProfessionCategoryRootID], [AcademicRankRootNodeID], [DefaultCurrencyCode], [SystemOwnerOrgID], [WorkCalendarID], [EmployeeHiringCategoryRootNodeID], [EmployeeTerminationCategoryRootNodeID], [AddressCategoryRootNodeID], [MaritalStatusRootNodeID]) VALUES (2, CAST(N'2010-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 20, N'THA', N'th-TH', NULL, 129, 59, 78, NULL, NULL, 74, NULL, NULL, 6, 21, NULL, 25, NULL, NULL, NULL, 34, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, NULL, 1, 82, 1, N'THB', NULL, NULL, 63, 67, NULL, 29)
GO
SET IDENTITY_INSERT [dbo].[Configuration] OFF
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ABW', 0, N'AW', 533, NULL, 0, NULL, NULL, 13, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'AFG', 0, N'AF', 4, NULL, 0, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'AGO', 0, N'AO', 24, NULL, 0, NULL, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'AIA', 0, N'AI', 660, NULL, 0, NULL, NULL, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ALA', 0, N'AX', 248, NULL, 0, NULL, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ALB', 0, N'AL', 8, NULL, 0, NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'AND', 0, N'AD', 20, NULL, 0, NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ANT', 0, N'AN', 530, NULL, 0, NULL, NULL, 157, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ARE', 0, N'AE', 784, NULL, 0, NULL, NULL, 233, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ARG', 0, N'AR', 32, NULL, 0, NULL, NULL, 11, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ARM', 0, N'AM', 51, NULL, 0, NULL, NULL, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ASM', 0, N'AS', 16, NULL, 0, NULL, NULL, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ATA', 0, N'AQ', 10, NULL, 0, NULL, NULL, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ATF', 0, N'TF', 260, NULL, 0, NULL, NULL, 80, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ATG', 0, N'AG', 28, NULL, 0, NULL, NULL, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'AUS', 0, N'AU', 36, NULL, 0, NULL, NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'AUT', 0, N'AT', 40, NULL, 0, NULL, NULL, 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'AZE', 0, N'AZ', 31, NULL, 0, NULL, NULL, 16, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BDI', 0, N'BI', 108, NULL, 0, NULL, NULL, 37, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BEL', 0, N'BE', 56, NULL, 0, NULL, NULL, 22, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BEN', 0, N'BJ', 204, NULL, 0, NULL, NULL, 24, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BFA', 0, N'BF', 854, NULL, 0, NULL, NULL, 36, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BGD', 0, N'BD', 50, NULL, 0, NULL, NULL, 19, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BGR', 0, N'BG', 100, NULL, 0, NULL, NULL, 35, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BHR', 0, N'BH', 48, NULL, 0, NULL, NULL, 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BHS', 0, N'BS', 44, NULL, 0, NULL, NULL, 17, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BIH', 0, N'BA', 70, NULL, 0, NULL, NULL, 28, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BLM', 0, N'BL', 652, NULL, 0, NULL, NULL, 185, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BLR', 0, N'BY', 112, NULL, 0, NULL, NULL, 21, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BLZ', 0, N'BZ', 84, NULL, 0, NULL, NULL, 23, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BMU', 0, N'BM', 60, NULL, 0, NULL, NULL, 25, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BOL', 0, N'BO', 68, NULL, 0, NULL, NULL, 27, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BRA', 0, N'BR', 76, NULL, 0, NULL, NULL, 31, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BRB', 0, N'BB', 52, NULL, 0, NULL, NULL, 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BRN', 0, N'BN', 96, NULL, 0, NULL, NULL, 34, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BTN', 0, N'BT', 64, NULL, 0, NULL, NULL, 26, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BVT', 0, N'BV', 74, NULL, 0, NULL, NULL, 30, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'BWA', 0, N'BW', 72, NULL, 0, NULL, NULL, 29, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CAF', 0, N'CF', 140, NULL, 0, NULL, NULL, 43, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CAN', 0, N'CA', 124, NULL, 0, NULL, NULL, 40, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CCK', 0, N'CC', 166, NULL, 0, NULL, NULL, 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CHE', 0, N'CH', 756, NULL, 0, NULL, NULL, 215, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CHL', 0, N'CL', 152, NULL, 0, NULL, NULL, 45, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CHN', 0, N'CN', 156, NULL, 0, NULL, NULL, 46, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CIV', 0, N'CI', 384, NULL, 0, NULL, NULL, 57, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CMR', 0, N'CM', 120, NULL, 0, NULL, NULL, 39, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'COD', 0, N'CD', 180, NULL, 0, NULL, NULL, 54, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'COG', 0, N'CG', 178, NULL, 0, NULL, NULL, 53, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'COK', 0, N'CK', 184, NULL, 0, NULL, NULL, 55, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'COL', 0, N'CO', 170, NULL, 0, NULL, NULL, 51, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'COM', 0, N'KM', 174, NULL, 0, NULL, NULL, 52, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CPV', 0, N'CV', 132, NULL, 0, NULL, NULL, 41, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CRI', 0, N'CR', 188, NULL, 0, NULL, NULL, 56, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CUB', 0, N'CU', 192, NULL, 0, NULL, NULL, 59, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CXR', 0, N'CX', 162, NULL, 0, NULL, NULL, 49, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CYM', 0, N'KY', 136, NULL, 0, NULL, NULL, 42, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CYP', 0, N'CY', 196, NULL, 0, NULL, NULL, 60, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'CZE', 0, N'CZ', 203, NULL, 0, NULL, NULL, 61, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'DEU', 0, N'DE', 276, NULL, 0, NULL, NULL, 84, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'DJI', 0, N'DJ', 262, NULL, 0, NULL, NULL, 63, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'DMA', 0, N'DM', 212, NULL, 0, NULL, NULL, 64, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'DNK', 0, N'DK', 208, NULL, 0, NULL, NULL, 62, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'DOM', 0, N'DO', 214, NULL, 0, NULL, NULL, 65, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'DZA', 0, N'DZ', 12, NULL, 0, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ECU', 0, N'EC', 218, NULL, 0, NULL, NULL, 66, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'EGY', 0, N'EG', 818, NULL, 0, NULL, NULL, 67, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ERI', 0, N'ER', 232, NULL, 0, NULL, NULL, 70, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ESH', 0, N'EH', 732, NULL, 0, NULL, NULL, 244, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ESP', 0, N'ES', 724, NULL, 0, NULL, NULL, 208, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'EST', 0, N'EE', 233, NULL, 0, NULL, NULL, 71, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ETH', 0, N'ET', 231, NULL, 0, NULL, NULL, 72, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'FIN', 0, N'FI', 246, NULL, 0, NULL, NULL, 76, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'FJI', 0, N'FJ', 242, NULL, 0, NULL, NULL, 75, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'FLK', 0, N'FK', 238, NULL, 0, NULL, NULL, 73, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'FRA', 0, N'FR', 250, NULL, 0, NULL, NULL, 77, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'FRO', 0, N'FO', 234, NULL, 0, NULL, NULL, 74, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'FSM', 0, N'FM', 583, NULL, 0, NULL, NULL, 144, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GAB', 0, N'GA', 266, NULL, 0, NULL, NULL, 81, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GBR', 0, N'GB', 826, NULL, 0, NULL, NULL, 234, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GEO', 0, N'GE', 268, NULL, 0, NULL, NULL, 83, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GGY', 0, N'GG', 831, NULL, 0, NULL, NULL, 93, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GHA', 0, N'GH', 288, NULL, 0, NULL, NULL, 85, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GIB', 0, N'GI', 292, NULL, 0, NULL, NULL, 86, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GIN', 0, N'GN', 324, NULL, 0, NULL, NULL, 94, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GLP', 0, N'GP', 312, NULL, 0, NULL, NULL, 90, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GMB', 0, N'GM', 270, NULL, 0, NULL, NULL, 82, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GNB', 0, N'GW', 624, NULL, 0, NULL, NULL, 95, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GNQ', 0, N'GQ', 226, NULL, 0, NULL, NULL, 69, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GRC', 0, N'GR', 300, NULL, 0, NULL, NULL, 87, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GRD', 0, N'GD', 308, NULL, 0, NULL, NULL, 89, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GRL', 0, N'GL', 304, NULL, 0, NULL, NULL, 88, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GTM', 0, N'GT', 320, NULL, 0, NULL, NULL, 92, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GUF', 0, N'GF', 254, NULL, 0, NULL, NULL, 78, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GUM', 0, N'GU', 316, NULL, 0, NULL, NULL, 91, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'GUY', 0, N'GY', 328, NULL, 0, NULL, NULL, 96, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'HKG', 0, N'HK', 344, NULL, 0, NULL, NULL, 47, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'HMD', 0, N'HM', 334, NULL, 0, NULL, NULL, 98, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'HND', 0, N'HN', 340, NULL, 0, NULL, NULL, 100, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'HRV', 0, N'HR', 191, NULL, 0, NULL, NULL, 58, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'HTI', 0, N'HT', 332, NULL, 0, NULL, NULL, 97, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'HUN', 0, N'HU', 348, NULL, 0, NULL, NULL, 101, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'IDN', 0, N'ID', 360, NULL, 0, NULL, NULL, 104, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'IMN', 0, N'IM', 833, NULL, 0, NULL, NULL, 108, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'IND', 0, N'IN', 356, NULL, 0, NULL, NULL, 103, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'IOT', 0, N'IO', 86, NULL, 0, NULL, NULL, 33, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'IRL', 0, N'IE', 372, NULL, 0, NULL, NULL, 107, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'IRN', 0, N'IR', 364, NULL, 0, NULL, NULL, 105, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'IRQ', 0, N'IQ', 368, NULL, 0, NULL, NULL, 106, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ISL', 0, N'IS', 352, NULL, 0, NULL, NULL, 102, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ISR', 0, N'IL', 376, NULL, 0, NULL, NULL, 109, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ITA', 0, N'IT', 380, NULL, 0, NULL, NULL, 110, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'JAM', 0, N'JM', 388, NULL, 0, NULL, NULL, 111, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'JEY', 0, N'JE', 832, NULL, 0, NULL, NULL, 113, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'JOR', 0, N'JO', 400, NULL, 0, NULL, NULL, 114, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'JPN', 0, N'JP', 392, NULL, 0, NULL, NULL, 112, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'KAZ', 0, N'KZ', 398, NULL, 0, NULL, NULL, 115, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'KEN', 0, N'KE', 404, NULL, 0, NULL, NULL, 116, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'KGZ', 0, N'KG', 417, NULL, 0, NULL, NULL, 121, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'KHM', 0, N'KH', 116, NULL, 0, NULL, NULL, 38, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'KIR', 0, N'KI', 296, NULL, 0, NULL, NULL, 117, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'KNA', 0, N'KN', 659, NULL, 0, NULL, NULL, 187, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'KOR', 0, N'KR', 410, NULL, 0, NULL, NULL, 119, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'KWT', 0, N'KW', 414, NULL, 0, NULL, NULL, 120, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'LAO', 0, N'LA', 418, NULL, 0, NULL, NULL, 122, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'LBN', 0, N'LB', 422, NULL, 0, NULL, NULL, 124, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'LBR', 0, N'LR', 430, NULL, 0, NULL, NULL, 126, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'LBY', 0, N'LY', 434, NULL, 0, NULL, NULL, 127, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'LCA', 0, N'LC', 662, NULL, 0, NULL, NULL, 188, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'LIE', 0, N'LI', 438, NULL, 0, NULL, NULL, 128, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'LKA', 0, N'LK', 144, NULL, 0, NULL, NULL, 209, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'LSO', 0, N'LS', 426, NULL, 0, NULL, NULL, 125, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'LTU', 0, N'LT', 440, NULL, 0, NULL, NULL, 129, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'LUX', 0, N'LU', 442, NULL, 0, NULL, NULL, 130, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'LVA', 0, N'LV', 428, NULL, 0, NULL, NULL, 123, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MAC', 0, N'MO', 446, NULL, 0, NULL, NULL, 48, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MAF', 0, N'MF', 663, NULL, 0, NULL, NULL, 189, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MAR', 0, N'MA', 504, NULL, 0, NULL, NULL, 150, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MCO', 0, N'MC', 492, NULL, 0, NULL, NULL, 146, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MDA', 0, N'MD', 498, NULL, 0, NULL, NULL, 145, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MDG', 0, N'MG', 450, NULL, 0, NULL, NULL, 132, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MDV', 0, N'MV', 462, NULL, 0, NULL, NULL, 135, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MEX', 0, N'MX', 484, NULL, 0, NULL, NULL, 143, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MHL', 0, N'MH', 584, NULL, 0, NULL, NULL, 138, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MKD', 0, N'MK', 807, NULL, 0, NULL, NULL, 131, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MLI', 0, N'ML', 466, NULL, 0, NULL, NULL, 136, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MLT', 0, N'MT', 470, NULL, 0, NULL, NULL, 137, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MMR', 0, N'MM', 104, NULL, 0, NULL, NULL, 152, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MNE', 0, N'ME', 499, NULL, 0, NULL, NULL, 148, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MNG', 0, N'MN', 496, NULL, 0, NULL, NULL, 147, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MNP', 0, N'MP', 580, NULL, 0, NULL, NULL, 165, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MOZ', 0, N'MZ', 508, NULL, 0, NULL, NULL, 151, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MRT', 0, N'MR', 478, NULL, 0, NULL, NULL, 140, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MSR', 0, N'MS', 500, NULL, 0, NULL, NULL, 149, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MTQ', 0, N'MQ', 474, NULL, 0, NULL, NULL, 139, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MUS', 0, N'MU', 480, NULL, 0, NULL, NULL, 141, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MWI', 0, N'MW', 454, NULL, 0, NULL, NULL, 133, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MYS', 0, N'MY', 458, NULL, 0, NULL, NULL, 134, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'MYT', 0, N'YT', 175, NULL, 0, NULL, NULL, 142, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NAM', 0, N'NA', 516, NULL, 0, NULL, NULL, 153, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NCL', 0, N'NC', 540, NULL, 0, NULL, NULL, 158, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NER', 0, N'NE', 562, NULL, 0, NULL, NULL, 161, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NFK', 0, N'NF', 574, NULL, 0, NULL, NULL, 164, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NGA', 0, N'NG', 566, NULL, 0, NULL, NULL, 162, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NIC', 0, N'NI', 558, NULL, 0, NULL, NULL, 160, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NIU', 0, N'NU', 570, NULL, 0, NULL, NULL, 163, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NLD', 0, N'NL', 528, NULL, 0, NULL, NULL, 156, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NOR', 0, N'NO', 578, NULL, 0, NULL, NULL, 166, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NPL', 0, N'NP', 524, NULL, 0, NULL, NULL, 155, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NRU', 0, N'NR', 520, NULL, 0, NULL, NULL, 154, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'NZL', 0, N'NZ', 554, NULL, 0, NULL, NULL, 159, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'OMN', 0, N'OM', 512, NULL, 0, NULL, NULL, 167, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PAK', 0, N'PK', 586, NULL, 0, NULL, NULL, 168, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PAN', 0, N'PA', 591, NULL, 0, NULL, NULL, 171, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PCN', 0, N'PN', 612, NULL, 0, NULL, NULL, 176, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PER', 0, N'PE', 604, NULL, 0, NULL, NULL, 174, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PHL', 0, N'PH', 608, NULL, 0, NULL, NULL, 175, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PLW', 0, N'PW', 585, NULL, 0, NULL, NULL, 169, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PNG', 0, N'PG', 598, NULL, 0, NULL, NULL, 172, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'POL', 0, N'PL', 616, NULL, 0, NULL, NULL, 177, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PRI', 0, N'PR', 630, NULL, 0, NULL, NULL, 179, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PRK', 0, N'KP', 408, NULL, 0, NULL, NULL, 118, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PRT', 0, N'PT', 620, NULL, 0, NULL, NULL, 178, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PRY', 0, N'PY', 600, NULL, 0, NULL, NULL, 173, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PSE', 0, N'PS', 275, NULL, 0, NULL, NULL, 170, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'PYF', 0, N'PF', 258, NULL, 0, NULL, NULL, 79, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'QAT', 0, N'QA', 634, NULL, 0, NULL, NULL, 180, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'REU', 0, N'RE', 638, NULL, 0, NULL, NULL, 181, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ROU', 0, N'RO', 642, NULL, 0, NULL, NULL, 182, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'RUS', 0, N'RU', 643, NULL, 0, NULL, NULL, 183, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'RWA', 0, N'RW', 646, NULL, 0, NULL, NULL, 184, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SAU', 0, N'SA', 682, NULL, 0, NULL, NULL, 195, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SDN', 0, N'SD', 736, NULL, 0, NULL, NULL, 210, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SEN', 0, N'SN', 686, NULL, 0, NULL, NULL, 196, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SGP', 0, N'SG', 702, NULL, 0, NULL, NULL, 200, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SGS', 0, N'GS', 239, NULL, 0, NULL, NULL, 206, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SHN', 0, N'SH', 654, NULL, 0, NULL, NULL, 186, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SJM', 0, N'SJ', 744, NULL, 0, NULL, NULL, 212, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SLB', 0, N'SB', 90, NULL, 0, NULL, NULL, 203, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SLE', 0, N'SL', 694, NULL, 0, NULL, NULL, 199, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SLV', 0, N'SV', 222, NULL, 0, NULL, NULL, 68, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SMR', 0, N'SM', 674, NULL, 0, NULL, NULL, 193, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SOM', 0, N'SO', 706, NULL, 0, NULL, NULL, 204, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SPM', 0, N'PM', 666, NULL, 0, NULL, NULL, 190, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SRB', 0, N'RS', 688, NULL, 0, NULL, NULL, 197, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SSD', 0, N'SS', 728, NULL, 0, NULL, NULL, 207, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'STP', 0, N'ST', 678, NULL, 0, NULL, NULL, 194, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SUR', 0, N'SR', 740, NULL, 0, NULL, NULL, 211, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SVK', 0, N'SK', 703, NULL, 0, NULL, NULL, 201, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SVN', 0, N'SI', 705, NULL, 0, NULL, NULL, 202, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SWE', 0, N'SE', 752, NULL, 0, NULL, NULL, 214, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SWZ', 0, N'SZ', 748, NULL, 0, NULL, NULL, 213, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SYC', 0, N'SC', 690, NULL, 0, NULL, NULL, 198, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'SYR', 0, N'SY', 760, NULL, 0, NULL, NULL, 216, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TCA', 0, N'TC', 796, NULL, 0, NULL, NULL, 229, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TCD', 0, N'TD', 148, NULL, 0, NULL, NULL, 44, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TGO', 0, N'TG', 768, NULL, 0, NULL, NULL, 222, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'THA', 0, N'TH', 764, NULL, 0, NULL, NULL, 220, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TJK', 0, N'TJ', 762, NULL, 0, NULL, NULL, 218, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TKL', 0, N'TK', 772, NULL, 0, NULL, NULL, 223, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TKM', 0, N'TM', 795, NULL, 0, NULL, NULL, 228, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TLS', 0, N'TL', 626, NULL, 0, NULL, NULL, 221, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TON', 0, N'TO', 776, NULL, 0, NULL, NULL, 224, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TTO', 0, N'TT', 780, NULL, 0, NULL, NULL, 225, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TUN', 0, N'TN', 788, NULL, 0, NULL, NULL, 226, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TUR', 0, N'TR', 792, NULL, 0, NULL, NULL, 227, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TUV', 0, N'TV', 798, NULL, 0, NULL, NULL, 230, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TWN', 0, N'TW', 158, NULL, 0, NULL, NULL, 217, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'TZA', 0, N'TZ', 834, NULL, 0, NULL, NULL, 219, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'UGA', 0, N'UG', 800, NULL, 0, NULL, NULL, 231, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'UKR', 0, N'UA', 804, NULL, 0, NULL, NULL, 232, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'UMI', 0, N'UM', 581, NULL, 0, NULL, NULL, 236, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'URY', 0, N'UY', 858, NULL, 0, NULL, NULL, 237, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'USA', 0, N'US', 840, NULL, 0, NULL, NULL, 235, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'UZB', 0, N'UZ', 860, NULL, 0, NULL, NULL, 238, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'VAT', 0, N'VA', 336, NULL, 0, NULL, NULL, 99, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'VCT', 0, N'VC', 670, NULL, 0, NULL, NULL, 191, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'VEN', 0, N'VE', 862, NULL, 0, NULL, NULL, 240, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'VGB', 0, N'VG', 92, NULL, 0, NULL, NULL, 32, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'VIR', 0, N'VI', 850, NULL, 0, NULL, NULL, 242, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'VNM', 0, N'VN', 704, NULL, 0, NULL, NULL, 241, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'VUT', 0, N'VU', 548, NULL, 0, NULL, NULL, 239, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'WLF', 0, N'WF', 876, NULL, 0, NULL, NULL, 243, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'WSM', 0, N'WS', 882, NULL, 0, NULL, NULL, 192, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'YEM', 0, N'YE', 887, NULL, 0, NULL, NULL, 245, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ZAF', 0, N'ZA', 710, NULL, 0, NULL, NULL, 205, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ZMB', 0, N'ZM', 894, NULL, 0, NULL, NULL, 246, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Country] ([ISOAlpha3Code], [LevelCount], [ISOAlpha2Code], [ISONumericCode], [Remark], [IsActive], [OfficialLanguageCode], [AltOfficialLanguageCode], [NameMLSId], [AbbreviatedNameMLSID], [NationalityNameMLSID], [Level1RegionTitleID], [Level2RegionTitleID], [Level3RegionTitleID], [Level4RegionTitleID], [Level1RegionRootNodeID]) VALUES (N'ZWE', 0, N'ZW', 716, NULL, 0, NULL, NULL, 247, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Currency] ([ISOCode], [CurrencySymbol], [Description], [EffectiveFrom], [EffectiveTo]) VALUES (N'THB', N'฿', NULL, NULL, NULL)
GO
INSERT [dbo].[Language] ([LanguageCode], [SeqNo], [ShortTitle], [SmallImageBytes], [Title]) VALUES (N'en-US', 2, NULL, NULL, N'English US')
GO
INSERT [dbo].[Language] ([LanguageCode], [SeqNo], [ShortTitle], [SmallImageBytes], [Title]) VALUES (N'th-TH', 1, NULL, NULL, N'Thai')
GO
SET IDENTITY_INSERT [dbo].[MLSValue] ON 

GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1, 1, N'th-TH', N'อัฟกานิสถาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (2, 1, N'en-US', N'Afghanistan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (3, 2, N'th-TH', N'หมู่เกาะโอลันด์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (4, 2, N'en-US', N'Aland Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (5, 3, N'th-TH', N'แอลเบเนีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (6, 3, N'en-US', N'Albania', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (7, 4, N'th-TH', N'แอลจีเรีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (8, 4, N'en-US', N'Algeria', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (9, 5, N'th-TH', N'อเมริกันซามัว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (10, 5, N'en-US', N'American Samoa', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (11, 6, N'th-TH', N'อันดอร์รา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (12, 6, N'en-US', N'Andorra', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (13, 7, N'th-TH', N'แองโกลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (14, 7, N'en-US', N'Angola', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (15, 8, N'th-TH', N'แองกวิลลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (16, 8, N'en-US', N'Anguilla', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (17, 9, N'th-TH', N'แอนตาร์กติกา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (18, 9, N'en-US', N'Antarctica', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (19, 10, N'th-TH', N'แอนติกาและบาร์บูดา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (20, 10, N'en-US', N'Antigua and Barbuda', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (21, 11, N'th-TH', N'อาร์เจนตินา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (22, 11, N'en-US', N'Argentina', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (23, 12, N'th-TH', N'ประเทศอาร์เมเนีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (24, 12, N'en-US', N'Armenia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (25, 13, N'th-TH', N'อารูบา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (26, 13, N'en-US', N'Aruba', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (27, 14, N'th-TH', N'ออสเตรเลีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (28, 14, N'en-US', N'Australia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (29, 15, N'th-TH', N'ออสเตรีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (30, 15, N'en-US', N'Austria', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (31, 16, N'th-TH', N'อาเซอร์ไบจาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (32, 16, N'en-US', N'Azerbaijan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (33, 17, N'th-TH', N'บาฮามาส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (34, 17, N'en-US', N'Bahamas', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (35, 18, N'th-TH', N'บาห์เรน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (36, 18, N'en-US', N'Bahrain', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (37, 19, N'th-TH', N'บังกลาเทศ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (38, 19, N'en-US', N'Bangladesh', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (39, 20, N'th-TH', N'บาร์เบโดส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (40, 20, N'en-US', N'Barbados', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (41, 21, N'th-TH', N'เบลารุส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (42, 21, N'en-US', N'Belarus', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (43, 22, N'th-TH', N'เบลเยียม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (44, 22, N'en-US', N'Belgium', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (45, 23, N'th-TH', N'เบลีซ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (46, 23, N'en-US', N'Belize', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (47, 24, N'th-TH', N'เบนิน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (48, 24, N'en-US', N'Benin', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (49, 25, N'th-TH', N'เบอร์มิวดา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (50, 25, N'en-US', N'Bermuda', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (51, 26, N'th-TH', N'ภูฏาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (52, 26, N'en-US', N'Bhutan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (53, 27, N'th-TH', N'โบลิเวีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (54, 27, N'en-US', N'Bolivia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (55, 28, N'th-TH', N'บอสเนียและเฮอร์เซโกวีนา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (56, 28, N'en-US', N'Bosnia and Herzegovina', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (57, 29, N'th-TH', N'บอตสวานา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (58, 29, N'en-US', N'Botswana', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (59, 30, N'th-TH', N'เกาะบูเวต์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (60, 30, N'en-US', N'Bouvet Island', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (61, 31, N'th-TH', N'บราซิล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (62, 31, N'en-US', N'Brazil', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (63, 32, N'th-TH', N'หมู่เกาะบริติชเวอร์จิน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (64, 32, N'en-US', N'British Virgin Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (65, 33, N'th-TH', N'บริติชอินเดียนโอเชียนเทร์ริทอรี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (66, 33, N'en-US', N'British Indian Ocean Territory', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (67, 34, N'th-TH', N'บรูไน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (68, 34, N'en-US', N'Brunei Darussalam', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (69, 35, N'th-TH', N'บัลแกเรีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (70, 35, N'en-US', N'Bulgaria', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (71, 36, N'th-TH', N'บูร์กินาฟาโซ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (72, 36, N'en-US', N'Burkina Faso', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (73, 37, N'th-TH', N'บุรุนดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (74, 37, N'en-US', N'Burundi', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (75, 38, N'th-TH', N'กัมพูชา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (76, 38, N'en-US', N'Cambodia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (77, 39, N'th-TH', N'แคเมอรูน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (78, 39, N'en-US', N'Cameroon', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (79, 40, N'th-TH', N'แคนาดา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (80, 40, N'en-US', N'Canada', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (81, 41, N'th-TH', N'เคปเวิร์ด', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (82, 41, N'en-US', N'Cape Verde', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (83, 42, N'th-TH', N'หมู่เกาะเคย์แมน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (84, 42, N'en-US', N'Cayman Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (85, 43, N'th-TH', N'สาธารณรัฐแอฟริกากลาง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (86, 43, N'en-US', N'Central African Republic', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (87, 44, N'th-TH', N'ชาด', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (88, 44, N'en-US', N'Chad', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (89, 45, N'th-TH', N'ชิลี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (90, 45, N'en-US', N'Chile', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (91, 46, N'th-TH', N'จีน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (92, 46, N'en-US', N'China', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (93, 47, N'th-TH', N'ฮ่องกง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (94, 47, N'en-US', N'Hong Kong, Special Administrative Region of China', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (95, 48, N'th-TH', N'มาเก๊า', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (96, 48, N'en-US', N'Macao, Special Administrative Region of China', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (97, 49, N'th-TH', N'เกาะคริสต์มาส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (98, 49, N'en-US', N'Christmas Island', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (99, 50, N'th-TH', N'หมู่เกาะโคโคส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (100, 50, N'en-US', N'Cocos (Keeling Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (101, 51, N'th-TH', N'โคลอมเบีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (102, 51, N'en-US', N'Colombia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (103, 52, N'th-TH', N'คอโมโรส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (104, 52, N'en-US', N'Comoros', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (105, 53, N'th-TH', N'สาธารณรัฐคองโก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (106, 53, N'en-US', N'Congo (Brazzaville', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (107, 54, N'th-TH', N'สาธารณรัฐประชาธิปไตยคองโก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (108, 54, N'en-US', N'Congo, Democratic Republic of the', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (109, 55, N'th-TH', N'หมู่เกาะคุก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (110, 55, N'en-US', N'Cook Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (111, 56, N'th-TH', N'คอสตาริกา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (112, 56, N'en-US', N'Costa Rica', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (113, 57, N'th-TH', N'โกตดิวัวร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (114, 57, N'en-US', N'Côte d''''Ivoire', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (115, 58, N'th-TH', N'โครเอเชีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (116, 58, N'en-US', N'Croatia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (117, 59, N'th-TH', N'คิวบา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (118, 59, N'en-US', N'Cuba', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (119, 60, N'th-TH', N'ไซปรัส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (120, 60, N'en-US', N'Cyprus', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (121, 61, N'th-TH', N'สาธารณรัฐเช็ก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (122, 61, N'en-US', N'Czech Republic', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (123, 62, N'th-TH', N'เดนมาร์ก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (124, 62, N'en-US', N'Denmark', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (125, 63, N'th-TH', N'จิบูตี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (126, 63, N'en-US', N'Djibouti', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (127, 64, N'th-TH', N'โดมินิกา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (128, 64, N'en-US', N'Dominica', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (129, 65, N'th-TH', N'สาธารณรัฐโดมินิกัน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (130, 65, N'en-US', N'Dominican Republic', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (131, 66, N'th-TH', N'เอกวาดอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (132, 66, N'en-US', N'Ecuador', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (133, 67, N'th-TH', N'อียิปต์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (134, 67, N'en-US', N'Egypt', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (135, 68, N'th-TH', N'เอลซัลวาดอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (136, 68, N'en-US', N'El Salvador', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (137, 69, N'th-TH', N'อิเควทอเรียลกินี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (138, 69, N'en-US', N'Equatorial Guinea', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (139, 70, N'th-TH', N'เอริเทรีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (140, 70, N'en-US', N'Eritrea', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (141, 71, N'th-TH', N'เอสโตเนีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (142, 71, N'en-US', N'Estonia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (143, 72, N'th-TH', N'เอธิโอเปีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (144, 72, N'en-US', N'Ethiopia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (145, 73, N'th-TH', N'หมู่เกาะฟอล์กแลนด์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (146, 73, N'en-US', N'Falkland Islands (Malvinas)', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (147, 74, N'th-TH', N'หมู่เกาะแฟโร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (148, 74, N'en-US', N'Faroe Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (149, 75, N'th-TH', N'ฟิจิ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (150, 75, N'en-US', N'Fiji', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (151, 76, N'th-TH', N'ฟินแลนด์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (152, 76, N'en-US', N'Finland', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (153, 77, N'th-TH', N'ฝรั่งเศส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (154, 77, N'en-US', N'France', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (155, 78, N'th-TH', N'เฟรนช์เกียนา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (156, 78, N'en-US', N'French Guiana', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (157, 79, N'th-TH', N'เฟรนช์โปลินีเซีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (158, 79, N'en-US', N'French Polynesia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (159, 80, N'th-TH', N'เฟรนช์เซาเทิร์นและแอนตาร์กติกแลนส์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (160, 80, N'en-US', N'French Southern Territories', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (161, 81, N'th-TH', N'กาบอง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (162, 81, N'en-US', N'Gabon', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (163, 82, N'th-TH', N'แกมเบีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (164, 82, N'en-US', N'Gambia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (165, 83, N'th-TH', N'จอร์เจีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (166, 83, N'en-US', N'Georgia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (167, 84, N'th-TH', N'เยอรมนี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (168, 84, N'en-US', N'Germany', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (169, 85, N'th-TH', N'กานา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (170, 85, N'en-US', N'Ghana', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (171, 86, N'th-TH', N'ยิบรอลตาร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (172, 86, N'en-US', N'Gibraltar', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (173, 87, N'th-TH', N'กรีซ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (174, 87, N'en-US', N'Greece', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (175, 88, N'th-TH', N'กรีนแลนด์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (176, 88, N'en-US', N'Greenland', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (177, 89, N'th-TH', N'เกรเนดา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (178, 89, N'en-US', N'Grenada', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (179, 90, N'th-TH', N'กัวเดอลุป', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (180, 90, N'en-US', N'Guadeloupe', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (181, 91, N'th-TH', N'กวม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (182, 91, N'en-US', N'Guam', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (183, 92, N'th-TH', N'กัวเตมาลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (184, 92, N'en-US', N'Guatemala', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (185, 93, N'th-TH', N'เกิร์นซีย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (186, 93, N'en-US', N'Guernsey', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (187, 94, N'th-TH', N'กินี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (188, 94, N'en-US', N'Guinea', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (189, 95, N'th-TH', N'กินี-บิสเซา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (190, 95, N'en-US', N'Guinea-Bissau', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (191, 96, N'th-TH', N'กายอานา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (192, 96, N'en-US', N'Guyana', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (193, 97, N'th-TH', N'เฮติ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (194, 97, N'en-US', N'Haiti', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (195, 98, N'th-TH', N'Heard Island and McDonald Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (196, 98, N'en-US', N'Heard Island and Mcdonald Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (197, 99, N'th-TH', N'นครรัฐวาติกัน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (198, 99, N'en-US', N'Holy See (Vatican City State', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (199, 100, N'th-TH', N'ฮอนดูรัส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (200, 100, N'en-US', N'Honduras', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (201, 101, N'th-TH', N'ฮังการี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (202, 101, N'en-US', N'Hungary', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (203, 102, N'th-TH', N'ไอซ์แลนด์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (204, 102, N'en-US', N'Iceland', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (205, 103, N'th-TH', N'อินเดีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (206, 103, N'en-US', N'India', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (207, 104, N'th-TH', N'อินโดนีเซีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (208, 104, N'en-US', N'Indonesia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (209, 105, N'th-TH', N'อิหร่าน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (210, 105, N'en-US', N'Iran, Islamic Republic of', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (211, 106, N'th-TH', N'อิรัก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (212, 106, N'en-US', N'Iraq', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (213, 107, N'th-TH', N'ไอร์แลนด์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (214, 107, N'en-US', N'Ireland', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (215, 108, N'th-TH', N'เกาะแมน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (216, 108, N'en-US', N'Isle of Man', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (217, 109, N'th-TH', N'อิสราเอล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (218, 109, N'en-US', N'Israel', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (219, 110, N'th-TH', N'อิตาลี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (220, 110, N'en-US', N'Italy', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (221, 111, N'th-TH', N'จาเมกา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (222, 111, N'en-US', N'Jamaica', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (223, 112, N'th-TH', N'ญี่ปุ่น', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (224, 112, N'en-US', N'Japan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (225, 113, N'th-TH', N'เจอร์ซีย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (226, 113, N'en-US', N'Jersey', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (227, 114, N'th-TH', N'จอร์แดน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (228, 114, N'en-US', N'Jordan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (229, 115, N'th-TH', N'คาซัคสถาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (230, 115, N'en-US', N'Kazakhstan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (231, 116, N'th-TH', N'เคนยา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (232, 116, N'en-US', N'Kenya', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (233, 117, N'th-TH', N'คิริบาส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (234, 117, N'en-US', N'Kiribati', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (235, 118, N'th-TH', N'เกาหลีเหนือ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (236, 118, N'en-US', N'Korea, Democratic People''''s Republic of', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (237, 119, N'th-TH', N'เกาหลีใต้', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (238, 119, N'en-US', N'Korea, Republic of', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (239, 120, N'th-TH', N'คูเวต', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (240, 120, N'en-US', N'Kuwait', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (241, 121, N'th-TH', N'คีร์กีซสถาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (242, 121, N'en-US', N'Kyrgyzstan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (243, 122, N'th-TH', N'ลาว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (244, 122, N'en-US', N'Lao PDR', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (245, 123, N'th-TH', N'ลัตเวีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (246, 123, N'en-US', N'Latvia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (247, 124, N'th-TH', N'เลบานอน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (248, 124, N'en-US', N'Lebanon', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (249, 125, N'th-TH', N'เลโซโท', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (250, 125, N'en-US', N'Lesotho', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (251, 126, N'th-TH', N'ไลบีเรีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (252, 126, N'en-US', N'Liberia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (253, 127, N'th-TH', N'ลิเบีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (254, 127, N'en-US', N'Libya', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (255, 128, N'th-TH', N'ลิกเตนสไตน์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (256, 128, N'en-US', N'Liechtenstein', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (257, 129, N'th-TH', N'ลิทัวเนีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (258, 129, N'en-US', N'Lithuania', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (259, 130, N'th-TH', N'ลักเซมเบิร์ก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (260, 130, N'en-US', N'Luxembourg', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (261, 131, N'th-TH', N'มาซิโดเนีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (262, 131, N'en-US', N'Macedonia, Republic of', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (263, 132, N'th-TH', N'มาดากัสการ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (264, 132, N'en-US', N'Madagascar', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (265, 133, N'th-TH', N'มาลาวี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (266, 133, N'en-US', N'Malawi', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (267, 134, N'th-TH', N'มาเลเซีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (268, 134, N'en-US', N'Malaysia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (269, 135, N'th-TH', N'มัลดีฟส์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (270, 135, N'en-US', N'Maldives', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (271, 136, N'th-TH', N'มาลี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (272, 136, N'en-US', N'Mali', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (273, 137, N'th-TH', N'มอลตา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (274, 137, N'en-US', N'Malta', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (275, 138, N'th-TH', N'หมู่เกาะมาร์แชลล์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (276, 138, N'en-US', N'Marshall Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (277, 139, N'th-TH', N'มาร์ตีนิก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (278, 139, N'en-US', N'Martinique', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (279, 140, N'th-TH', N'มอริเตเนีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (280, 140, N'en-US', N'Mauritania', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (281, 141, N'th-TH', N'มอริเชียส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (282, 141, N'en-US', N'Mauritius', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (283, 142, N'th-TH', N'มายอต', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (284, 142, N'en-US', N'Mayotte', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (285, 143, N'th-TH', N'เม็กซิโก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (286, 143, N'en-US', N'Mexico', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (287, 144, N'th-TH', N'ไมโครนีเซีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (288, 144, N'en-US', N'Micronesia, Federated States of', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (289, 145, N'th-TH', N'มอลโดวา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (290, 145, N'en-US', N'Moldova', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (291, 146, N'th-TH', N'โมนาโก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (292, 146, N'en-US', N'Monaco', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (293, 147, N'th-TH', N'มองโกเลีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (294, 147, N'en-US', N'Mongolia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (295, 148, N'th-TH', N'มอนเตเนโกร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (296, 148, N'en-US', N'Montenegro', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (297, 149, N'th-TH', N'มอนต์เซอร์รัต', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (298, 149, N'en-US', N'Montserrat', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (299, 150, N'th-TH', N'โมร็อกโก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (300, 150, N'en-US', N'Morocco', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (301, 151, N'th-TH', N'โมซัมบิก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (302, 151, N'en-US', N'Mozambique', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (303, 152, N'th-TH', N'พม่า', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (304, 152, N'en-US', N'Myanmar', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (305, 153, N'th-TH', N'นามิเบีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (306, 153, N'en-US', N'Namibia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (307, 154, N'th-TH', N'นาอูรู', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (308, 154, N'en-US', N'Nauru', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (309, 155, N'th-TH', N'เนปาล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (310, 155, N'en-US', N'Nepal', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (311, 156, N'th-TH', N'เนเธอร์แลนด์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (312, 156, N'en-US', N'Netherlands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (313, 157, N'th-TH', N'เนเธอร์แลนด์แอนทิลลิส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (314, 157, N'en-US', N'Netherlands Antilles', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (315, 158, N'th-TH', N'นิวแคลิโดเนีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (316, 158, N'en-US', N'New Caledonia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (317, 159, N'th-TH', N'นิวซีแลนด์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (318, 159, N'en-US', N'New Zealand', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (319, 160, N'th-TH', N'นิการากัว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (320, 160, N'en-US', N'Nicaragua', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (321, 161, N'th-TH', N'ไนเจอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (322, 161, N'en-US', N'Niger', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (323, 162, N'th-TH', N'ไนจีเรีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (324, 162, N'en-US', N'Nigeria', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (325, 163, N'th-TH', N'นีอูเอ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (326, 163, N'en-US', N'Niue', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (327, 164, N'th-TH', N'เกาะนอร์ฟอล์ก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (328, 164, N'en-US', N'Norfolk Island', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (329, 165, N'th-TH', N'หมู่เกาะนอร์เทิร์นมาเรียนา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (330, 165, N'en-US', N'Northern Mariana Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (331, 166, N'th-TH', N'นอร์เวย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (332, 166, N'en-US', N'Norway', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (333, 167, N'th-TH', N'โอมาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (334, 167, N'en-US', N'Oman', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (335, 168, N'th-TH', N'ปากีสถาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (336, 168, N'en-US', N'Pakistan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (337, 169, N'th-TH', N'ปาเลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (338, 169, N'en-US', N'Palau', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (339, 170, N'th-TH', N'ปาเลสไตน์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (340, 170, N'en-US', N'Palestinian Territory, Occupied', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (341, 171, N'th-TH', N'ปานามา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (342, 171, N'en-US', N'Panama', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (343, 172, N'th-TH', N'ปาปัวนิวกินี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (344, 172, N'en-US', N'Papua New Guinea', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (345, 173, N'th-TH', N'ปารากวัย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (346, 173, N'en-US', N'Paraguay', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (347, 174, N'th-TH', N'เปรู', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (348, 174, N'en-US', N'Peru', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (349, 175, N'th-TH', N'ฟิลิปปินส์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (350, 175, N'en-US', N'Philippines', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (351, 176, N'th-TH', N'หมู่เกาะพิตแคร์น', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (352, 176, N'en-US', N'Pitcairn', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (353, 177, N'th-TH', N'โปแลนด์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (354, 177, N'en-US', N'Poland', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (355, 178, N'th-TH', N'โปรตุเกส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (356, 178, N'en-US', N'Portugal', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (357, 179, N'th-TH', N'เปอร์โตริโก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (358, 179, N'en-US', N'Puerto Rico', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (359, 180, N'th-TH', N'กาตาร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (360, 180, N'en-US', N'Qatar', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (361, 181, N'th-TH', N'เรอูว์นียง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (362, 181, N'en-US', N'Réunion', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (363, 182, N'th-TH', N'โรมาเนีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (364, 182, N'en-US', N'Romania', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (365, 183, N'th-TH', N'รัสเซีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (366, 183, N'en-US', N'Russian Federation', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (367, 184, N'th-TH', N'รวันดา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (368, 184, N'en-US', N'Rwanda', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (369, 185, N'th-TH', N'แซงบาร์เตเลมี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (370, 185, N'en-US', N'Saint-Barthélemy', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (371, 186, N'th-TH', N'เซนต์เฮเลนา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (372, 186, N'en-US', N'Saint Helena', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (373, 187, N'th-TH', N'เซนต์คิตส์และเนวิส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (374, 187, N'en-US', N'Saint Kitts and Nevis', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (375, 188, N'th-TH', N'เซนต์ลูเซีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (376, 188, N'en-US', N'Saint Lucia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (377, 189, N'th-TH', N'แซงมาร์แตง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (378, 189, N'en-US', N'Saint-Martin (French part', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (379, 190, N'th-TH', N'แซงปีแยร์และมีเกอลง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (380, 190, N'en-US', N'Saint Pierre and Miquelon', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (381, 191, N'th-TH', N'เซนต์วินเซนต์และเกรนาดีนส์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (382, 191, N'en-US', N'Saint Vincent and Grenadines', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (383, 192, N'th-TH', N'ซามัว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (384, 192, N'en-US', N'Samoa', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (385, 193, N'th-TH', N'ซานมารีโน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (386, 193, N'en-US', N'San Marino', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (387, 194, N'th-TH', N'เซาตูเมและปรินซิปี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (388, 194, N'en-US', N'Sao Tome and Principe', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (389, 195, N'th-TH', N'ซาอุดีอาระเบีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (390, 195, N'en-US', N'Saudi Arabia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (391, 196, N'th-TH', N'เซเนกัล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (392, 196, N'en-US', N'Senegal', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (393, 197, N'th-TH', N'เซอร์เบีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (394, 197, N'en-US', N'Serbia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (395, 198, N'th-TH', N'เซเชลส์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (396, 198, N'en-US', N'Seychelles', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (397, 199, N'th-TH', N'เซียร์ราลีโอน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (398, 199, N'en-US', N'Sierra Leone', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (399, 200, N'th-TH', N'สิงคโปร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (400, 200, N'en-US', N'Singapore', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (401, 201, N'th-TH', N'สโลวาเกีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (402, 201, N'en-US', N'Slovakia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (403, 202, N'th-TH', N'สโลวีเนีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (404, 202, N'en-US', N'Slovenia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (405, 203, N'th-TH', N'หมู่เกาะโซโลมอน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (406, 203, N'en-US', N'Solomon Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (407, 204, N'th-TH', N'โซมาเลีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (408, 204, N'en-US', N'Somalia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (409, 205, N'th-TH', N'แอฟริกาใต้', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (410, 205, N'en-US', N'South Africa', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (411, 206, N'th-TH', N'เกาะเซาท์จอร์เจียและหมู่เกาะเซาท์แซนด์วิช', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (412, 206, N'en-US', N'South Georgia and the South Sandwich Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (413, 207, N'th-TH', N'ซูดานใต้', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (414, 207, N'en-US', N'South Sudan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (415, 208, N'th-TH', N'สเปน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (416, 208, N'en-US', N'Spain', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (417, 209, N'th-TH', N'ศรีลังกา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (418, 209, N'en-US', N'Sri Lanka', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (419, 210, N'th-TH', N'ซูดาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (420, 210, N'en-US', N'Sudan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (421, 211, N'th-TH', N'ซูรินาเม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (422, 211, N'en-US', N'Suriname *', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (423, 212, N'th-TH', N'สฟาลบาร์และยานไมเอน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (424, 212, N'en-US', N'Svalbard and Jan Mayen Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (425, 213, N'th-TH', N'สวาซิแลนด์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (426, 213, N'en-US', N'Swaziland', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (427, 214, N'th-TH', N'สวีเดน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (428, 214, N'en-US', N'Sweden', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (429, 215, N'th-TH', N'สวิตเซอร์แลนด์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (430, 215, N'en-US', N'Switzerland', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (431, 216, N'th-TH', N'ซีเรีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (432, 216, N'en-US', N'Syrian Arab Republic (Syria', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (433, 217, N'th-TH', N'ไต้หวัน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (434, 217, N'en-US', N'Taiwan, Republic of China', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (435, 218, N'th-TH', N'ทาจิกิสถาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (436, 218, N'en-US', N'Tajikistan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (437, 219, N'th-TH', N'แทนซาเนีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (438, 219, N'en-US', N'Tanzania, United Republic of', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (439, 220, N'th-TH', N'ไทย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (440, 220, N'en-US', N'Thailand', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (441, 221, N'th-TH', N'ติมอร์ตะวันออก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (442, 221, N'en-US', N'Timor-Leste', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (443, 222, N'th-TH', N'โตโก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (444, 222, N'en-US', N'Togo', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (445, 223, N'th-TH', N'โตเกเลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (446, 223, N'en-US', N'Tokelau', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (447, 224, N'th-TH', N'ตองกา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (448, 224, N'en-US', N'Tonga', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (449, 225, N'th-TH', N'ตรินิแดดและโตเบโก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (450, 225, N'en-US', N'Trinidad and Tobago', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (451, 226, N'th-TH', N'ตูนิเซีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (452, 226, N'en-US', N'Tunisia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (453, 227, N'th-TH', N'ตุรกี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (454, 227, N'en-US', N'Turkey', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (455, 228, N'th-TH', N'เติร์กเมนิสถาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (456, 228, N'en-US', N'Turkmenistan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (457, 229, N'th-TH', N'หมู่เกาะเติกส์และหมู่เกาะเคคอส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (458, 229, N'en-US', N'Turks and Caicos Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (459, 230, N'th-TH', N'ตูวาลู', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (460, 230, N'en-US', N'Tuvalu', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (461, 231, N'th-TH', N'ยูกันดา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (462, 231, N'en-US', N'Uganda', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (463, 232, N'th-TH', N'ยูเครน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (464, 232, N'en-US', N'Ukraine', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (465, 233, N'th-TH', N'สหรัฐอาหรับเอมิเรตส์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (466, 233, N'en-US', N'United Arab Emirates', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (467, 234, N'th-TH', N'สหราชอาณาจักร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (468, 234, N'en-US', N'United Kingdom', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (469, 235, N'th-TH', N'สหรัฐอเมริกา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (470, 235, N'en-US', N'United States of America', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (471, 236, N'th-TH', N'เกาะเล็กรอบนอกของสหรัฐอเมริกา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (472, 236, N'en-US', N'United States Minor Outlying Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (473, 237, N'th-TH', N'อุรุกวัย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (474, 237, N'en-US', N'Uruguay', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (475, 238, N'th-TH', N'อุซเบกิสถาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (476, 238, N'en-US', N'Uzbekistan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (477, 239, N'th-TH', N'วานูอาตู', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (478, 239, N'en-US', N'Vanuatu', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (479, 240, N'th-TH', N'เวเนซุเอลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (480, 240, N'en-US', N'Venezuela (Bolivarian Republic of)', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (481, 241, N'th-TH', N'เวียดนาม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (482, 241, N'en-US', N'Viet Nam', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (483, 242, N'th-TH', N'หมู่เกาะเวอร์จินของสหรัฐอเมริกา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (484, 242, N'en-US', N'Virgin Islands, US', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (485, 243, N'th-TH', N'หมู่เกาะวาลลิสและหมู่เกาะฟุตูนา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (486, 243, N'en-US', N'Wallis and Futuna Islands', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (487, 244, N'th-TH', N'ซาฮาราตะวันตก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (488, 244, N'en-US', N'Western Sahara', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (489, 245, N'th-TH', N'เยเมน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (490, 245, N'en-US', N'Yemen', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (491, 246, N'th-TH', N'แซมเบีย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (492, 246, N'en-US', N'Zambia', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (493, 247, N'th-TH', N'ซิมบับเว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (494, 247, N'en-US', N'Zimbabwe', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (495, 248, N'th-TH', N'ศาสตราจารย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (496, 248, N'en-US', N'Professor', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (497, 249, N'th-TH', N'ศ.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (498, 249, N'en-US', N'Prof.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (499, 250, N'th-TH', N'รองศาสตราจารย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (500, 250, N'en-US', N'Associate Professor', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (501, 251, N'th-TH', N'รศ.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (502, 251, N'en-US', N'Assoc. Prof.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (503, 252, N'th-TH', N'ผู้ช่วยศาสตราจารย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (504, 252, N'en-US', N'Assistant Professor', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (505, 253, N'th-TH', N'ผศ.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (506, 253, N'en-US', N'Asst. Prof.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (507, 254, N'th-TH', N'อาจารย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (508, 254, N'en-US', N'Lecturer', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (509, 255, N'th-TH', N'อ.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (510, 255, N'en-US', N'Lect.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (511, 256, N'th-TH', N'กลุ่ม A', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (512, 256, N'en-US', N'Group A', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (513, 257, N'th-TH', N'กลุ่ม B', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (514, 257, N'en-US', N'Group B', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (515, 258, N'th-TH', N'กลุ่ม AB', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (516, 258, N'en-US', N'Group AB', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (517, 259, N'th-TH', N'กลุ่ม O', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (518, 259, N'en-US', N'Group O', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (519, 260, N'th-TH', N'ไม่ทราบ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (520, 260, N'en-US', N'N/A', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (521, 261, N'th-TH', N'ปริญญาเอก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (522, 261, N'en-US', N'Doctor of Philosophy', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (523, 262, N'th-TH', N'ป.เอก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (524, 262, N'en-US', N'Ph.D.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (525, 263, N'th-TH', N'ปริญญาโท', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (526, 263, N'en-US', N'Master Degree', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (527, 264, N'th-TH', N'ป.โท', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (528, 264, N'en-US', N'MS/MA', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (529, 265, N'th-TH', N'ปริญญาตรี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (530, 265, N'en-US', N'Bachelor Degree', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (531, 266, N'th-TH', N'ป.ตรี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (532, 266, N'en-US', N'BS/BA', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (533, 267, N'th-TH', N'ประกาศนียบัตรวิชาชีพชั้นสูง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (534, 267, N'en-US', N'High Vocational Certificate', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (535, 268, N'th-TH', N'ปวส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (536, 268, N'en-US', N'HVC', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (537, 269, N'th-TH', N'ประกาศนียบัตรวิชาชีพ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (538, 269, N'en-US', N'Vocational Certificate', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (539, 270, N'th-TH', N'ปวช', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (540, 270, N'en-US', N'VC', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (541, 271, N'th-TH', N'มัธยมศึกษา 6', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (542, 271, N'en-US', N'Senior High School Certficate', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (543, 272, N'th-TH', N'ม.6', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (544, 272, N'en-US', N'HSC 6', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (545, 273, N'th-TH', N'มัธยมศึกษา 3', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (546, 273, N'en-US', N'High School Certficate', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (547, 274, N'th-TH', N'ม.6', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (548, 274, N'en-US', N'HSC 3', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (549, 275, N'th-TH', N'ประถมศึกษา 6', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (550, 275, N'en-US', N'Elementary School Certficate', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (551, 276, N'th-TH', N'ป.6', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (552, 276, N'en-US', N'EHC 6', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (553, 277, N'th-TH', N'หญิง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (554, 277, N'en-US', N'Female', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (555, 278, N'th-TH', N'ชาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (556, 278, N'en-US', N'Male', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (557, 279, N'th-TH', N'ไม่ทราบ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (558, 279, N'en-US', N'Unknown', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (559, 280, N'th-TH', N'บิดา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (560, 280, N'en-US', N'Father', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (561, 281, N'th-TH', N'มารดา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (562, 281, N'en-US', N'Mother', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (563, 282, N'th-TH', N'ผู้ปกครอง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (564, 282, N'en-US', N'Guardian', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (565, 283, N'th-TH', N'สถานะการสมรส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (566, 283, N'en-US', N'Marital Status', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (567, 284, N'th-TH', N'หม้าย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (568, 284, N'en-US', N'Divorced', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (569, 285, N'th-TH', N'สมรส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (570, 285, N'en-US', N'Married', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (571, 286, N'th-TH', N'โสด', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (572, 286, N'en-US', N'Single', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (573, 287, N'th-TH', N'หม้าย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (574, 287, N'en-US', N'Widowed', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (575, 288, N'th-TH', N'ศาสนา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (576, 288, N'en-US', N'Religion', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (577, 289, N'th-TH', N'ไม่นับถือศาสนา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (578, 289, N'en-US', N'Atheism', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (579, 290, N'th-TH', N'พุทธ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (580, 290, N'en-US', N'Buddhism', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (581, 291, N'th-TH', N'คริส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (582, 291, N'en-US', N'Christianity', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (583, 292, N'th-TH', N'ฮินดู', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (584, 292, N'en-US', N'Hinduism', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (585, 293, N'th-TH', N'อิสลาม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (586, 293, N'en-US', N'Islam', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (587, 294, N'th-TH', N'สิกข์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (588, 294, N'en-US', N'Sikism', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (589, 295, N'th-TH', N'ไม่ทราบ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (590, 295, N'en-US', N'Unknown', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (591, 296, N'th-TH', N'เครื่องราชอิสริยาภรณ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (592, 296, N'en-US', N'Royal Decorations', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (593, 297, N'th-TH', N'เหรียญเงินมงกุฎไทย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (594, 297, N'en-US', N'The Silver Medal (Seventh Class) of the Crown of Thailand', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (595, 298, N'th-TH', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (596, 298, N'en-US', N'S.M.C.T.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (597, 299, N'th-TH', N'1. เริ่มขอพระราชทาน บ.ม. \n2. ดำรงตำแหน่งระดับ 2 มาแล้วไม่ น้อยกว่า 5 ปีบริบูรณ์ ขอ บ.ช.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (598, 300, N'th-TH', N'เหรียญเงินช้างเผือก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (599, 300, N'en-US', N'The Silver Medal (Seventh Class) of the White Elephant', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (600, 301, N'th-TH', N'ร.ง.ช.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (601, 301, N'en-US', N'S.M.W.E.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (602, 302, N'th-TH', N'เหรียญทองมงกุฎไทย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (603, 302, N'en-US', N'The Gold Medal (Sixth Class) of the Crown of Thailand', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (604, 303, N'th-TH', N'ร.ท.ม.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (605, 303, N'en-US', N'G.M.C.T', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (606, 304, N'th-TH', N'เหรียญทองช้างเผือก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (607, 304, N'en-US', N'The Gold Medal (Sixth Class) of the White Elephant', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (608, 305, N'th-TH', N'ร.ท.ช.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (609, 305, N'en-US', N'G.M.W.E.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (610, 306, N'th-TH', N'เบญจมาภรณ์มงกุฎไทย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (611, 306, N'en-US', N'Member (Fifth Class) of the Most Noble Order of the Crown of Thailand', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (612, 307, N'th-TH', N'บ.ม.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (613, 307, N'en-US', N'M.M.N.O.C.T', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (614, 308, N'th-TH', N'เบญจมาภรณ์ช้างเผือก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (615, 308, N'en-US', N'Member (Fifth Class) of the Most Exalted Order of the White Elephant', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (616, 309, N'th-TH', N'บ.ช.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (617, 309, N'en-US', N'M.M.N.O.W.E.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (618, 310, N'th-TH', N'จัตุรถาภรณ์มงกุฎไทย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (619, 310, N'en-US', N'Companion (Fourth Class) of the Most Noble Order of the Crown of Thailand', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (620, 311, N'th-TH', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (621, 311, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (622, 312, N'th-TH', N'จัตุรถาภรณ์ช้างเผือก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (623, 312, N'en-US', N'Companion (Fourth Class) of the Most Exalted Order of the White Elephant', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (624, 313, N'th-TH', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (625, 313, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (626, 314, N'th-TH', N'ตริตาภรณ์มงกุฎไทย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (627, 314, N'en-US', N'Commander (Third Class) of the Most Noble Order of the Crown of Thailand', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (628, 315, N'th-TH', N'ต.ม.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (629, 315, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (630, 316, N'th-TH', N'ตริตาภรณ์ช้างเผือก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (631, 316, N'en-US', N'Commander (Third Class) of the Most Exalted Order of the White Elephant', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (632, 317, N'th-TH', N'ต.ช.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (633, 317, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (634, 318, N'th-TH', N'ทวีติยาภรณ์มงกุฎไทย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (635, 318, N'en-US', N'Knight Commander (Second Class) of the Most Noble Order of the Crown of Thailand', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (636, 319, N'th-TH', N'ท.ม.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (637, 319, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (638, 320, N'th-TH', N'ทวีติยาภรณ์ช้างเผือก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (639, 320, N'en-US', N'Knight Commander (Second Class) of the Most Exalted Order of the White Elephant', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (640, 321, N'th-TH', N'ท.ช.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (641, 321, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (642, 322, N'th-TH', N'ประถมาภรณ์มงกุฎไทย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (643, 322, N'en-US', N'Knight Grand Cross (First Class) of the Most Noble Order of the Crown of Thailand', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (644, 323, N'th-TH', N'ป.ม.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (645, 323, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (646, 324, N'th-TH', N'ประถมาภรณ์ช้างเผือก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (647, 324, N'en-US', N'Knight Grand Cross (First Class) of the Most Exalted Order of the White Elephant', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (648, 325, N'th-TH', N'ป.ช.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (649, 325, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (650, 326, N'th-TH', N'มหาวชิรมงกุฎ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (651, 326, N'en-US', N'Knight Grand Cordon (Special Class) of the Most Noble Order of the Crown of Thailand', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (652, 327, N'th-TH', N'ม.ว.ม.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (653, 327, N'en-US', N'K.G.C.C.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (654, 328, N'th-TH', N'มหาปรมาภรณ์ช้างเผือก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (655, 328, N'en-US', N'Knight Grand Cordon (Special Class) of the Most Exalted Order of the White Elephant', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (656, 329, N'th-TH', N'ม.ป.ช.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (657, 329, N'en-US', N'K.G.C.E.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (658, 330, N'th-TH', N'ประเภทการครองตำแหน่ง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (659, 330, N'en-US', N'Employee Appointment Category', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (660, 331, N'th-TH', N'แต่งตั้ง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (661, 331, N'en-US', N'Appoint', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (662, 332, N'th-TH', N'รักษาราชการแทน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (663, 332, N'en-US', N'Depute', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (664, 333, N'th-TH', N'เลือกตั้ง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (665, 333, N'en-US', N'Elected', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (666, 334, N'th-TH', N'ประเภทการบรรจุบุคลากร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (667, 334, N'en-US', N'Employee Hiring Category', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (668, 335, N'th-TH', N'ได้รับการคัดเลือก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (669, 335, N'en-US', N'Selected', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (670, 336, N'th-TH', N'สอบแข่งขันได้', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (671, 336, N'en-US', N'Examination', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (672, 337, N'th-TH', N'รับโอน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (673, 337, N'en-US', N'Transferred', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (674, 338, N'th-TH', N'ประเภทการสิ้นสุดบุคลากร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (675, 338, N'en-US', N'Employee Termination Category', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (676, 339, N'th-TH', N'ให้ลาออก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (677, 339, N'en-US', N'Quit', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (678, 340, N'th-TH', N'ให้ออก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (679, 340, N'en-US', N'Discharge', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (680, 341, N'th-TH', N'ปลดออก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (681, 341, N'en-US', N'Dismissal', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (682, 342, N'th-TH', N'ไล่ออก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (683, 342, N'en-US', N'Fired', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (684, 343, N'th-TH', N'เกษียณ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (685, 343, N'en-US', N'Retired', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (686, 344, N'th-TH', N'ให้โอน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (687, 344, N'en-US', N'Transfer Out', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (688, 345, N'th-TH', N'ประเภทการได้มาของอัตราตำแหน่ง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (689, 345, N'en-US', N'Position Acquisition Category', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (690, 346, N'th-TH', N'จัดสรร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (691, 346, N'en-US', N'Allocated', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (692, 347, N'th-TH', N'รับโอน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (693, 347, N'en-US', N'Transferred', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (694, 348, N'th-TH', N'สับเปลี่ยน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (695, 348, N'en-US', N'Exchanged', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (696, 349, N'th-TH', N'ประเภทบุคลากร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (697, 349, N'en-US', N'Personnel Classification', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (698, 350, N'th-TH', N'ข้าราชการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (699, 350, N'en-US', N'Government Officer', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (700, 351, N'th-TH', N'พนักงานมหาวิทยาลัย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (701, 351, N'en-US', N'University Employee', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (702, 352, N'th-TH', N'ลูกจ้าง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (703, 352, N'en-US', N'Temporary Employee', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (704, 353, N'th-TH', N'ประเภทวิชาชีพในมหาวิทยาลัย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (705, 353, N'en-US', N'University Profession Category', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (706, 354, N'th-TH', N'-', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (707, 354, N'en-US', N'-', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (708, 355, N'th-TH', N'สอนและวิจัย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (709, 355, N'en-US', N'Teach and Research', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (710, 356, N'th-TH', N'บริหาร อำนวยการ ธุรการ งานสถิติ งานนิติการ งานการทูตและต่างประเทศ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (711, 356, N'en-US', N'Administration', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (712, 357, N'th-TH', N'บริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (713, 357, N'en-US', N'Administration', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (714, 358, N'th-TH', N'วิทยาการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (715, 358, N'en-US', N'Computer Science', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (716, 359, N'th-TH', N'วิชาการเวชสถิติ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (717, 359, N'en-US', N'Medical Statistics', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (718, 360, N'th-TH', N'วิเคราะห์นโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (719, 360, N'en-US', N'Policy Analysis', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (720, 361, N'th-TH', N'นิติการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (721, 361, N'en-US', N'Jurisdiction', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (722, 362, N'th-TH', N'บริหารงานบุคคล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (723, 362, N'en-US', N'Human Resource Management', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (724, 363, N'th-TH', N'บริหารงานทั่วไป', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (725, 363, N'en-US', N'General Management', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (726, 364, N'th-TH', N'วิชาการพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (727, 364, N'en-US', N'Inventory Management', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (728, 365, N'th-TH', N'วิชาการสถิติ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (729, 365, N'en-US', N'Statistics', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (730, 366, N'th-TH', N'วิเทศสัมพันธ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (731, 366, N'en-US', N'Foreign Relation', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (732, 367, N'th-TH', N'ที่ปรึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (733, 367, N'en-US', N'Consulting', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (734, 368, N'th-TH', N'การคลัง เศรษฐกิจ พาณิชย์และอุตสาหกรรม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (735, 368, N'en-US', N'Finance, Economic, Commerce, and Industry', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (736, 369, N'th-TH', N'วิชาการการเงินและบัญชี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (737, 369, N'en-US', N'Accounting and Finance', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (738, 370, N'th-TH', N'ตรวจสอบภายใน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (739, 370, N'en-US', N'Internal Audit', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (740, 371, N'th-TH', N'คมนาคม ขนส่งและติดต่อสื่อสาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (741, 371, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (742, 372, N'th-TH', N'วิชาการโสตทัศนศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (743, 372, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (744, 373, N'th-TH', N'การประชาสัมพันธ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (745, 373, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (746, 374, N'th-TH', N'เกษตรกรรม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (747, 374, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (748, 375, N'th-TH', N'วิชาการเกษตร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (749, 375, N'en-US', N'Agriculture', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (750, 376, N'th-TH', N'วิชาการสัตวบาล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (751, 376, N'en-US', N'Animal Husbandry', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (752, 377, N'th-TH', N'วิชาการประมง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (753, 377, N'en-US', N'Fishery', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (754, 378, N'th-TH', N'วิทยศาสตร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (755, 378, N'en-US', N'Science', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (756, 379, N'th-TH', N'วิทยาศาสตร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (757, 379, N'en-US', N'Science', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (758, 380, N'th-TH', N'แพทย์ พยาบาล และสาธารณสุข', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (759, 380, N'en-US', N'Physician, Nurse, and Health-care', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (760, 381, N'th-TH', N'กายภาพบำบัด', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (761, 381, N'en-US', N'Physical Therapy', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (762, 382, N'th-TH', N'ทันตกรรม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (763, 382, N'en-US', N'Dentistry', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (764, 383, N'th-TH', N'พยาบาล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (765, 383, N'en-US', N'Nurse', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (766, 384, N'th-TH', N'แพทย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (767, 384, N'en-US', N'Physician', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (768, 385, N'th-TH', N'สัตวแพทย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (769, 385, N'en-US', N'Veterinary', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (770, 386, N'th-TH', N'นักเทคนิคการแพทย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (771, 386, N'en-US', N'Medical Techincian', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (772, 387, N'th-TH', N'เภสัชกรรม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (773, 387, N'en-US', N'Pharmacy', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (774, 388, N'th-TH', N'รังสีการแพทย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (775, 388, N'en-US', N'Radiology', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (776, 389, N'th-TH', N'กิจกรรมบำบัด', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (777, 389, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (778, 390, N'th-TH', N'เวชศาสตร์การสื่อความหมาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (779, 390, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (780, 391, N'th-TH', N'วิชาการโภชนา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (781, 391, N'en-US', N'Nutrition', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (782, 392, N'th-TH', N'จิตวิทยา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (783, 392, N'en-US', N'Phychology', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (784, 393, N'th-TH', N'วิชาการอาชีวบำบัด', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (785, 393, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (786, 394, N'th-TH', N'วิชาการวิทยาศาสตร์การแพทย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (787, 394, N'en-US', N'Medical Science', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (788, 395, N'th-TH', N'สุขศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (789, 395, N'en-US', N'Health', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (790, 396, N'th-TH', N'วิศวกรรม สถาปัตยกรรม และช่างเทคนิคต่าง ๆ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (791, 396, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (792, 397, N'th-TH', N'เครื่องกล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (793, 397, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (794, 398, N'th-TH', N'ไฟฟ้า', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (795, 398, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (796, 399, N'th-TH', N'การศึกษา ศิลปะ สังคม และการพัฒนาชุมชน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (797, 399, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (798, 400, N'th-TH', N'วิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (799, 400, N'en-US', N'Academic Position Category', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (800, 401, N'th-TH', N'ศาสตราจารย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (801, 401, N'en-US', N'Professor', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (802, 402, N'th-TH', N'รองศาสตราจารย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (803, 402, N'en-US', N'Associate Professor', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (804, 403, N'th-TH', N'ผู้ช่วยศาสตราจารย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (805, 403, N'en-US', N'Assistant Professor', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (806, 404, N'th-TH', N'อาจารย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (807, 404, N'en-US', N'Lecturer', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (808, 405, N'th-TH', N'บริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (809, 405, N'en-US', N'Administration Position Category', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (810, 406, N'th-TH', N'ผู้อำนวยการสำนักงานอธิการบดีหรือเทียบเท่า', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (811, 406, N'en-US', N'Director', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (812, 407, N'th-TH', N'ผู้อำนวยการกองหรือเทียบเท่า', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (813, 407, N'en-US', N'Division  Director', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (814, 408, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (815, 408, N'en-US', N'Section Head', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (816, 409, N'th-TH', N'อธิการบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (817, 409, N'en-US', N'President', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (818, 410, N'th-TH', N'รองอธิการบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (819, 410, N'en-US', N'Vice President', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (820, 411, N'th-TH', N'ผู้ช่วยอธิการบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (821, 411, N'en-US', N'Assistant to the Chancellor', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (822, 412, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (823, 412, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (824, 413, N'th-TH', N'รองคณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (825, 413, N'en-US', N'Associate Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (826, 414, N'th-TH', N'ผู้อำนวยการศูนย์ ผู้อำนวยการสถาบัน หรือผู้อำนวยการสำนัก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (827, 414, N'en-US', N'Director', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (828, 415, N'th-TH', N'รองผู้อำนวยการศูนย์ รองผู้อำนวยการสถาบัน หรือรองผู้อำนวยการสำนัก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (829, 415, N'en-US', N'Associate Director', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (830, 416, N'th-TH', N'ประธานสภาอาจารย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (831, 416, N'en-US', N'Faculty Council President', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (832, 417, N'th-TH', N'เลขานุการคณะ/สำนัก', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (833, 417, N'en-US', N'Secretary', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (834, 418, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (835, 418, N'en-US', N'Section Head', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (836, 419, N'th-TH', N'วิชาชีพเฉพาะหรือผู้เชี่ยวชาญเฉพาะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (837, 419, N'en-US', N'Specific Profession Category', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (838, 420, N'th-TH', N'เชี่ยวชาญพิเศษ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (839, 420, N'en-US', N'Senior Expert Level', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (840, 421, N'th-TH', N'เชี่ยวชาญ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (841, 421, N'en-US', N'Expert Level', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (842, 422, N'th-TH', N'ชำนาญการพิเศษ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (843, 422, N'en-US', N'Senior Professional Level', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (844, 423, N'th-TH', N'ชำนาญการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (845, 423, N'en-US', N'Professional Level', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (846, 424, N'th-TH', N'ปฏิบัติการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (847, 424, N'en-US', N'Practitioner Level', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (848, 425, N'th-TH', N'นักวิขาการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (849, 425, N'en-US', N'Computer Tecnical Officer', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (850, 426, N'th-TH', N'นักวิชาการเวชสถิติ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (851, 426, N'en-US', N'Medical Statistician', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (852, 427, N'th-TH', N'นักวิเคราะห์นโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (853, 427, N'en-US', N'Plan and Policy Analyst', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (854, 428, N'th-TH', N'นิติกร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (855, 428, N'en-US', N'Lawer', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (856, 429, N'th-TH', N'บุคลากร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (857, 429, N'en-US', N'Personnel', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (858, 430, N'th-TH', N'เจ้าหน้าที่บริหารงานทั่วไป', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (859, 430, N'en-US', N'General Admin', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (860, 431, N'th-TH', N'นักวิชาการพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (861, 431, N'en-US', N'Supply Analyst', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (862, 432, N'th-TH', N'นักวิชาการสถิติ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (863, 432, N'en-US', N'Statistician', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (864, 433, N'th-TH', N'นักวิเทศสัมพันธ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (865, 433, N'en-US', N'Public Relation', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (866, 434, N'th-TH', N'ที่ปรึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (867, 434, N'en-US', N'Consultant', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (868, 435, N'th-TH', N'นักวิชาการเงินและบัญชี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (869, 435, N'en-US', N'Financialist and Accountant', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (870, 436, N'th-TH', N'นักตรวจสอบภายใน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (871, 436, N'en-US', N'Internal Auditor', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (872, 437, N'th-TH', N'นักวิชาการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (873, 437, N'en-US', N'Academic Support', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (874, 438, N'th-TH', N'ทั่วไป', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (875, 438, N'en-US', N'General Position Category', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (876, 439, N'th-TH', N'ชำนาญงานพิเศษ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (877, 439, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (878, 440, N'th-TH', N'ชำนาญงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (879, 440, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (880, 441, N'th-TH', N'ปฏิบัติงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (881, 441, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (882, 442, N'th-TH', N'ผู้ปฏิบัติงานบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (883, 442, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (884, 443, N'th-TH', N'เจ้าหน้าที่บริหารงานธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (885, 443, N'en-US', N'General Service Officer', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (886, 444, N'th-TH', N'เจ้าหน้าที่บริหารงานพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (887, 444, N'en-US', N'Supply Officer', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (888, 445, N'th-TH', N'เจ้าหน้าที่บริหารงานการเงินและบัญชี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (889, 445, N'en-US', N'Finance and Accounting Officer', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (890, 446, N'th-TH', N'ผู้ปฏิบัติงานโสตทัศนศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (891, 446, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (892, 447, N'th-TH', N'ประเภทที่อยู่', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (893, 447, N'en-US', N'Address Category', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (894, 448, N'th-TH', N'ที่อยู่ในทะเบียน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (895, 448, N'en-US', N'Official Address', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (896, 449, N'th-TH', N'ที่อยู่ปัจจุบัน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (897, 449, N'en-US', N'Current Address', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (898, 450, N'th-TH', N'ที่รับไปรษณีย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (899, 450, N'en-US', N'Mailing Address', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (900, 451, N'th-TH', N'ตารางเวลาทำงาน 8:30-16:30 5 วันในคาบ 7 วัน วันแรกของคาบ (วัน 0) คือวันจันทร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (901, 451, N'en-US', N'Weekly schedule with 5 working day in which the first day is Monday', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (902, 453, N'th-TH', N'118', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (903, 453, N'en-US', N'118', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (904, 454, N'th-TH', N'ถนนเสรีไทย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (905, 454, N'en-US', N'Serithai Road', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (906, 455, N'th-TH', N'คลองจั่น บางกะปิ กรุงเทพฯ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (907, 455, N'en-US', N'Klongjan, Bangkapi, Bangkok', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (908, 456, N'th-TH', N'ตารางเวลาทำงาน 7:30-15:30 5 วันในคาบ 7 วัน วันแรกของคาบ (วัน 0) คือวันจันทร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (909, 456, N'en-US', N'Weekly schedule with 5 working day in which the first day is Monday', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (910, 457, N'th-TH', N'ตารางเวลาทำงาน 9:30-17:30 5 วันในคาบ 7 วัน วันแรกของคาบ (วัน 0) คือวันจันทร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (911, 457, N'en-US', N'Weekly schedule with 5 working day in which the first day is Monday', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (912, 452, N'th-TH', N'สถาบันบัณฑิตพัฒนบริหารศาสตร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (913, 452, N'en-US', N'National Institute of Development Administration', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (914, 458, N'th-TH', N'วันขึ้นปีใหม่', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (915, 458, N'en-US', N'New Year Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (916, 459, N'th-TH', N'วันหยุดตามมติ ครม.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (917, 459, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (918, 460, N'th-TH', N'วันมาฆบูชา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (919, 460, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (920, 461, N'th-TH', N'วันจักรี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (921, 461, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (922, 462, N'th-TH', N'วันสงกรานต์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (923, 462, N'en-US', N'Songkran Festival', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (924, 463, N'th-TH', N'วันสงกรานต์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (925, 463, N'en-US', N'Songkran Festival', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (926, 464, N'th-TH', N'วันสงกรานต์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (927, 464, N'en-US', N'Songkran Festival', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (928, 465, N'th-TH', N'วันหยุดตามมติ ครม.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (929, 465, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (930, 466, N'th-TH', N'วันฉัตรมงคล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (931, 466, N'en-US', N'Coronation Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (932, 467, N'th-TH', N'วันพืชมงคล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (933, 467, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (934, 468, N'th-TH', N'วันวิสาขบูชา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (935, 468, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (936, 469, N'th-TH', N'วันอาสาฬหบูชา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (937, 469, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (938, 470, N'th-TH', N'วันเข้าพรรษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (939, 470, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (940, 471, N'th-TH', N'วันแม่', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (941, 471, N'en-US', N'Mother Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (942, 472, N'th-TH', N'วันปิยมหาราช', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (943, 472, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (944, 473, N'th-TH', N'วันพ่อ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (945, 473, N'en-US', N'Father Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (946, 474, N'th-TH', N'วันหยุดชดเชยวันพ่อ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (947, 474, N'en-US', N'Observed Father Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (948, 475, N'th-TH', N'วันรัฐธรรมนูญ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (949, 475, N'en-US', N'Constitution Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (950, 476, N'th-TH', N'วันสิ้นปี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (951, 476, N'en-US', N'New Year Eve', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (952, 477, N'th-TH', N'วันขึ้นปีใหม่', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (953, 477, N'en-US', N'New Year Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (954, 478, N'th-TH', N'วันมาฆบูชา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (955, 478, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (956, 479, N'th-TH', N'วันจักรี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (957, 479, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (958, 480, N'th-TH', N'วันสงกรานต์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (959, 480, N'en-US', N'Songkran Festival', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (960, 481, N'th-TH', N'วันสงกรานต์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (961, 481, N'en-US', N'Songkran Festival', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (962, 482, N'th-TH', N'วันสงกรานต์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (963, 482, N'en-US', N'Songkran Festival', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (964, 483, N'th-TH', N'วันฉัตรมงคล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (965, 483, N'en-US', N'Coronation Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (966, 484, N'th-TH', N'วันพืชมงคล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (967, 484, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (968, 485, N'th-TH', N'วันวิสาขบูชา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (969, 485, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (970, 486, N'th-TH', N'วันอาสาฬหบูชา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (971, 486, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (972, 487, N'th-TH', N'วันเข้าพรรษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (973, 487, N'en-US', N'Buddhist Lent Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (974, 488, N'th-TH', N'วันแม่', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (975, 488, N'en-US', N'Mother Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (976, 489, N'th-TH', N'วันปิยมหาราช', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (977, 489, N'en-US', N'Chulalongkorn Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (978, 490, N'th-TH', N'ชดเชยวันปิยมหาราช', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (979, 490, N'en-US', N'Observed Chulalongkorn Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (980, 491, N'th-TH', N'วันพ่อ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (981, 491, N'en-US', N'Father Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (982, 492, N'th-TH', N'วันรัฐธรรมนูญ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (983, 492, N'en-US', N'Constitution Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (984, 493, N'th-TH', N'หยุดชดเชยวันรัฐธรรมนูญ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (985, 493, N'en-US', N'Observed Constitution Day', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (986, 494, N'th-TH', N'วันสิ้นปี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (987, 494, N'en-US', N'New Year Eve', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (988, 495, N'th-TH', N'นิด้า', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (989, 495, N'en-US', N'NIDA', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (990, 496, N'th-TH', N'สำนักงานอธิการบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (991, 496, N'en-US', N'Office of the President', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (992, 497, N'th-TH', N'สภาคณาจารย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (993, 497, N'en-US', N'Office of the Faculty Senate', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (994, 498, N'th-TH', N'ประธานสภาคณาจารย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (995, 498, N'en-US', N'President of Faculty Council', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (996, 499, N'th-TH', N'กองกลาง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (997, 499, N'en-US', N'General Affairs Division', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (998, 500, N'th-TH', N'กองบริการการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (999, 500, N'en-US', N'Education Service Division', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1000, 501, N'th-TH', N'กองแผนงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1001, 501, N'en-US', N'Planning Division', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1002, 502, N'th-TH', N'กองคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1003, 502, N'en-US', N'Finance and Procurement Division', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1004, 503, N'th-TH', N'กองบริหารทรัพยากรบุคคล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1005, 503, N'en-US', N'Human Resource Management Division', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1006, 504, N'th-TH', N'กลุ่มงานบริหารทรัพยากรบุคคล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1007, 504, N'en-US', N'Human Resource Management Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1008, 505, N'th-TH', N'บุคลากร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1009, 505, N'en-US', N'Human Resource', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1010, 506, N'th-TH', N'บุคลากร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1011, 506, N'en-US', N'Human Resource', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1012, 507, N'th-TH', N'บุคลากร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1013, 507, N'en-US', N'Human Resource', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1014, 508, N'th-TH', N'กลุ่มงานพัฒนาทรัพยากรบุคคล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1015, 508, N'en-US', N'Human Resource Development Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1016, 509, N'th-TH', N'กลุ่มงานส่งเสริมพัฒนาความก้าวหน้าในอาชีพ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1017, 509, N'en-US', N'Career Path Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1018, 510, N'th-TH', N'กลุ่มงานแผนกลยุทธ์ทรัพยากรบุคคล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1019, 510, N'en-US', N'Strategic Plan Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1020, 511, N'th-TH', N'กลุ่มงานทะเบียนประวัติและค่าตอบแทน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1021, 511, N'en-US', N'Personnel Record and Compensation Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1022, 512, N'th-TH', N'กลุ่มงานวิจัยและประเมินผลการปฏิบัติงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1023, 512, N'en-US', N'Research and Assessment Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1024, 513, N'th-TH', N'กลุ่มงานบริหารธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1025, 513, N'en-US', N'Admininstration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1026, 514, N'th-TH', N'กลุ่มงานสวัสดิการและบุคลากรสัมพันธ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1027, 514, N'en-US', N'Benefits and Personnel Relation Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1028, 515, N'th-TH', N'บุคลากร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1029, 515, N'en-US', N'Human Resource', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1030, 516, N'th-TH', N'Director', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1031, 516, N'en-US', N'ผู้อำนวยการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1032, 517, N'th-TH', N'กองงานผู้บริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1033, 517, N'en-US', N'Executive Affair Division', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1034, 518, N'th-TH', N'กลุ่มงานนโยบายสถาบันและการประชุม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1035, 518, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1036, 519, N'th-TH', N'กลุ่มงานสื่อสารองค์การและกิจกรรมเพื่อสังคม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1037, 519, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1038, 520, N'th-TH', N'กลุ่มงานกิจการนักศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1039, 520, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1040, 521, N'th-TH', N'กลุ่มงานกิจการนานาชาติ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1041, 521, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1042, 522, N'th-TH', N'กลุ่มงานติดตามการดำเนินงานศูนย์พัฒนาวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1043, 522, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1044, 523, N'th-TH', N'กลุ่มงานวินัยและนิติการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1045, 523, N'en-US', N'', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1046, 524, N'th-TH', N'สำนักงานตรวจสอบภายใน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1047, 524, N'en-US', N'Office of Internal Audit ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1048, 525, N'th-TH', N'สำนักงานสภาสถาบัน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1049, 525, N'en-US', N'Office of NIDA Council', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1050, 526, N'th-TH', N'ผู้อำนวยการสำนักงานอธิการบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1051, 526, N'en-US', N'Director of the Office of the President', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1052, 527, N'th-TH', N'เลขานุการสำนักงานอธิการบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1053, 527, N'en-US', N'Secretary of the Office of the President', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1054, 528, N'th-TH', N'คณะรัฐประศาสนศาสตร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1055, 528, N'en-US', N'Graduate School of Public Administration', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1056, 529, N'th-TH', N'รศ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1057, 529, N'en-US', N'GSPA', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1058, 530, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1059, 530, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1060, 531, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1061, 531, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1062, 532, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1063, 532, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1064, 533, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1065, 533, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1066, 534, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1067, 534, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1068, 535, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1069, 535, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1070, 536, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1071, 536, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1072, 537, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1073, 537, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1074, 538, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1075, 538, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1076, 539, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1077, 539, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1078, 540, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1079, 540, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1080, 541, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1081, 541, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1082, 542, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1083, 542, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1084, 543, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1085, 543, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1086, 544, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1087, 544, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1088, 545, N'th-TH', N'คณะบริหารธุรกิจ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1089, 545, N'en-US', N'Graduate School of Business Administration', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1090, 546, N'th-TH', N'บธ.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1091, 546, N'en-US', N'GSBA', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1092, 547, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1093, 547, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1094, 548, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1095, 548, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1096, 549, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1097, 549, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1098, 550, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1099, 550, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1100, 551, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1101, 551, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1102, 552, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1103, 552, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1104, 553, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1105, 553, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1106, 554, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1107, 554, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1108, 555, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1109, 555, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1110, 556, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1111, 556, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1112, 557, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1113, 557, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1114, 558, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1115, 558, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1116, 559, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1117, 559, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1118, 560, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1119, 560, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1120, 561, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1121, 561, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1122, 562, N'th-TH', N'คณะพัฒนาการเศรษฐกิจ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1123, 562, N'en-US', N'Graduate School of Development Economic', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1124, 563, N'th-TH', N'พศ.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1125, 563, N'en-US', N'GSDE', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1126, 564, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1127, 564, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1128, 565, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1129, 565, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1130, 566, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1131, 566, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1132, 567, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1133, 567, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1134, 568, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1135, 568, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1136, 569, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1137, 569, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1138, 570, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1139, 570, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1140, 571, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1141, 571, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1142, 572, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1143, 572, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1144, 573, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1145, 573, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1146, 574, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1147, 574, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1148, 575, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1149, 575, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1150, 576, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1151, 576, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1152, 577, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1153, 577, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1154, 578, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1155, 578, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1156, 579, N'th-TH', N'คณะสถิติประยุกต์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1157, 579, N'en-US', N'Graduate School of Applied Statistics', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1158, 580, N'th-TH', N'สป.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1159, 580, N'en-US', N'GSAS', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1160, 581, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1161, 581, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1162, 582, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1163, 582, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1164, 583, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1165, 583, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1166, 584, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1167, 584, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1168, 585, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1169, 585, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1170, 586, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1171, 586, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1172, 587, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1173, 587, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1174, 588, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1175, 588, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1176, 589, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1177, 589, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1178, 590, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1179, 590, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1180, 591, N'th-TH', N'โครงการศูนย์คอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1181, 591, N'en-US', N'Computer Center Project', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1182, 592, N'th-TH', N'หัวหน้ากลุ่มงานโครงการศูนย์คอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1183, 592, N'en-US', N'Head of Computer Center Project Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1184, 593, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1185, 593, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1186, 594, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1187, 594, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1188, 595, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1189, 595, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1190, 596, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1191, 596, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1192, 597, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1193, 597, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1194, 598, N'th-TH', N'คณะพัฒนาสังคมและสิ่งแวดล้อม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1195, 598, N'en-US', N'Graduate School of Social and Environmental Development', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1196, 599, N'th-TH', N'พส.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1197, 599, N'en-US', N'GSSSED', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1198, 600, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1199, 600, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1200, 601, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1201, 601, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1202, 602, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1203, 602, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1204, 603, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1205, 603, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1206, 604, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1207, 604, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1208, 605, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1209, 605, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1210, 606, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1211, 606, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1212, 607, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1213, 607, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1214, 608, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1215, 608, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1216, 609, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1217, 609, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1218, 610, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1219, 610, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1220, 611, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1221, 611, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1222, 612, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1223, 612, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1224, 613, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1225, 613, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1226, 614, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1227, 614, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1228, 615, N'th-TH', N'คณะพัฒนาทรัพยากรมนุษย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1229, 615, N'en-US', N'Graduate School of Human Resource Development', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1230, 616, N'th-TH', N'พม.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1231, 616, N'en-US', N'GSHRD', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1232, 617, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1233, 617, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1234, 618, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1235, 618, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1236, 619, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1237, 619, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1238, 620, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1239, 620, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1240, 621, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1241, 621, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1242, 622, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1243, 622, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1244, 623, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1245, 623, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1246, 624, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1247, 624, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1248, 625, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1249, 625, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1250, 626, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1251, 626, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1252, 627, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1253, 627, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1254, 628, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1255, 628, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1256, 629, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1257, 629, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1258, 630, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1259, 630, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1260, 631, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1261, 631, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1262, 632, N'th-TH', N'คณะภาษาและการสื่อสาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1263, 632, N'en-US', N'Graduate School of Language and Communication', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1264, 633, N'th-TH', N'ภส.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1265, 633, N'en-US', N'GSLC', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1266, 634, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1267, 634, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1268, 635, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1269, 635, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1270, 636, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1271, 636, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1272, 637, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1273, 637, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1274, 638, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1275, 638, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1276, 639, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1277, 639, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1278, 640, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1279, 640, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1280, 641, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1281, 641, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1282, 642, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1283, 642, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1284, 643, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1285, 643, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1286, 644, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1287, 644, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1288, 645, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1289, 645, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1290, 646, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1291, 646, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1292, 647, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1293, 647, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1294, 648, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1295, 648, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1296, 649, N'th-TH', N'คณะนิติศาสตร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1297, 649, N'en-US', N'Graduate School of Law', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1298, 650, N'th-TH', N'นศ.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1299, 650, N'en-US', N'GSL', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1300, 651, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1301, 651, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1302, 652, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1303, 652, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1304, 653, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1305, 653, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1306, 654, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1307, 654, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1308, 655, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1309, 655, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1310, 656, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1311, 656, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1312, 657, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1313, 657, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1314, 658, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1315, 658, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1316, 659, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1317, 659, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1318, 660, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1319, 660, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1320, 661, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1321, 661, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1322, 662, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1323, 662, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1324, 663, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1325, 663, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1326, 664, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1327, 664, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1328, 665, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1329, 665, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1330, 666, N'th-TH', N'คณะการจัดการการท่องเที่ยว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1331, 666, N'en-US', N'Graduate School of Tourism Management', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1332, 667, N'th-TH', N'จท.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1333, 667, N'en-US', N'GSTM', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1334, 668, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1335, 668, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1336, 669, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1337, 669, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1338, 670, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1339, 670, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1340, 671, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1341, 671, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1342, 672, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1343, 672, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1344, 673, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1345, 673, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1346, 674, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1347, 674, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1348, 675, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1349, 675, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1350, 676, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1351, 676, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1352, 677, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1353, 677, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1354, 678, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1355, 678, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1356, 679, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1357, 679, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1358, 680, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1359, 680, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1360, 681, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1361, 681, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1362, 682, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1363, 682, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1364, 683, N'th-TH', N'คณะนิเทศศาสตร์และนวัตกรรมการจัดการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1365, 683, N'en-US', N'Graduate School of Communication Arts and Management Innovation', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1366, 684, N'th-TH', N'นน.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1367, 684, N'en-US', N'GSCM', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1368, 685, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1369, 685, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1370, 686, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1371, 686, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1372, 687, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1373, 687, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1374, 688, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1375, 688, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1376, 689, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1377, 689, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1378, 690, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1379, 690, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1380, 691, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1381, 691, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1382, 692, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1383, 692, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1384, 693, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1385, 693, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1386, 694, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1387, 694, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1388, 695, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1389, 695, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1390, 696, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1391, 696, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1392, 697, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1393, 697, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1394, 698, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1395, 698, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1396, 699, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1397, 699, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1398, 700, N'th-TH', N'คณะบริหารการพัฒนาสิ่งแวดล้อม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1399, 700, N'en-US', N'Graduate School of Environmental Development Administration', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1400, 701, N'th-TH', N'บพว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1401, 701, N'en-US', N'GSEDA', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1402, 702, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1403, 702, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1404, 703, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1405, 703, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1406, 704, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1407, 704, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1408, 705, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1409, 705, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1410, 706, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1411, 706, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1412, 707, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1413, 707, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1414, 708, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1415, 708, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1416, 709, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1417, 709, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1418, 710, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1419, 710, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1420, 711, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1421, 711, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1422, 712, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1423, 712, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1424, 713, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1425, 713, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1426, 714, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1427, 714, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1428, 715, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1429, 715, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1430, 716, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1431, 716, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1432, 717, N'th-TH', N'วิทยาลัยนานาชาติ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1433, 717, N'en-US', N'International College of National Institute of Development Administration', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1434, 718, N'th-TH', N'วนช.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1435, 718, N'en-US', N'ICO DA', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1436, 719, N'th-TH', N'กลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1437, 719, N'en-US', N'Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1438, 720, N'th-TH', N'หัวหน้ากลุ่มงานบริหารและธุรการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1439, 720, N'en-US', N'Head of Administration Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1440, 721, N'th-TH', N'กลุ่มงานคลังและพัสดุ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1441, 721, N'en-US', N'Finance Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1442, 722, N'th-TH', N'หัวหน้ากลุ่มงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1443, 722, N'en-US', N'Head of  Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1444, 723, N'th-TH', N'กลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1445, 723, N'en-US', N'Education Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1446, 724, N'th-TH', N'หัวหน้ากลุ่มงานการศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1447, 724, N'en-US', N'Head of Education Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1448, 725, N'th-TH', N'กลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1449, 725, N'en-US', N'Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1450, 726, N'th-TH', N'หัวหน้ากลุ่มงานนโยบายและแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1451, 726, N'en-US', N'Head of Planning & Policy Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1452, 727, N'th-TH', N'กลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1453, 727, N'en-US', N'Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1454, 728, N'th-TH', N'หัวหน้ากลุ่มงานบริการและปฏิบัติการคอมพิวเตอร์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1455, 728, N'en-US', N'Head of Service Section', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1456, 729, N'th-TH', N'คณบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1457, 729, N'en-US', N'Dean', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1458, 730, N'th-TH', N'รองคณบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1459, 730, N'en-US', N'Associate Dean for Administrative Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1460, 731, N'th-TH', N'รองคณบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1461, 731, N'en-US', N'Associate Dean for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1462, 732, N'th-TH', N'รองคณบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1463, 732, N'en-US', N'Associate Dean of Planning and Development Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1464, 733, N'th-TH', N'เลขานุการคณะ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1465, 733, N'en-US', N'Secretary of the School', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1466, 734, N'th-TH', N'สำนักวิจัย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1467, 734, N'en-US', N'Research Center', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1468, 735, N'th-TH', N'สำนักสิริพัฒนา (สำนักฝึกอบรม)', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1469, 735, N'en-US', N'Siripattana Training Center', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1470, 736, N'th-TH', N'สำนักบรรณสารการพัฒนา (ห้องสมุด)', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1471, 736, N'en-US', N'Library and Information Center', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1472, 737, N'th-TH', N'สำนักเทคโนโลยีสารสนเทศ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1473, 737, N'en-US', N'Information Technology Center', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1474, 738, N'th-TH', N'ศูนย์บริการวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1475, 738, N'en-US', N'Consulting Service Center', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1476, 739, N'th-TH', N'ศูนย์อาเซียนและเอเชียศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1477, 739, N'en-US', N'Asian and Asia Studies Center', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1478, 740, N'th-TH', N'ศูนย์สาธารณประโยชน์และประชาสังคม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1479, 740, N'en-US', N'Center for Philantropy and Civil Society', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1480, 741, N'th-TH', N'ศูนย์วิจัยและพัฒนาการป้องกันและจัดการภัยพิบัติ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1481, 741, N'en-US', N'Disaster Prevention and Management Research and Development Center', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1482, 742, N'th-TH', N'ศูนย์ศึกษาเศรษฐกิจพอเพียง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1483, 742, N'en-US', N'Center of the Study of Sufficiency Economy', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1484, 743, N'th-TH', N'ศูนย์สำรวจความคิดเห็น', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1485, 743, N'en-US', N'NIDA Poll Center', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1486, 744, N'th-TH', N'ศูนย์ประสานราชการใสสะอาด', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1487, 744, N'en-US', N'Center for Enhancing Competitiveness', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1488, 745, N'th-TH', N'ศูนย์เพิ่มศักยภาพในการแข่งขัน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1489, 745, N'en-US', N'Center for Business Innovation', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1490, 746, N'th-TH', N'ศูนย์นวัตกรรมทางธุรกิจ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1491, 746, N'en-US', N'NIDA Saving Cooperative', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1492, 747, N'th-TH', N'รองอธิการบดีฝ่ายบริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1493, 747, N'en-US', N'Vice President for Administration', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1494, 748, N'th-TH', N'รองอธิการบดีฝ่ายวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1495, 748, N'en-US', N'Vice President for Acadmic Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1496, 749, N'th-TH', N'รองอธิการบดีฝ่ายวางแผน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1497, 749, N'en-US', N'Vice President of Planning', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1498, 750, N'th-TH', N'รองอธิการบดีฝ่ายวิจัยและบริการวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1499, 750, N'en-US', N'Vice President of Research and Consulting Services', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1500, 751, N'th-TH', N'ผู้ช่วยอธิการบดีฝ่ายกิจการนานาชาติ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1501, 751, N'en-US', N'Assistant to The President for International Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1502, 752, N'th-TH', N'ผู้ช่วยอธิการบดีฝ่ายกิจการนักศึกษา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1503, 752, N'en-US', N'Assistant to The President for Student Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1504, 753, N'th-TH', N'ผู้ช่วยอธิการบดีฝ่ายกิจกรรมเพื่อสังคม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1505, 753, N'en-US', N'Assistant to The President for Social Affairs', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1506, 754, N'th-TH', N'ผู้ช่วยอธิการบดีฝ่ายสื่อสารองค์กร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1507, 754, N'en-US', N'Assistant to The President for Corporate Commmunications', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1508, 755, N'th-TH', N'ผู้ช่วยอธิการบดีฝ่ายรับรองงมาตราฐานสากล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1509, 755, N'en-US', N'Assistant to The President for International Accreditation', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1510, 756, N'th-TH', N'อธิการบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1511, 756, N'en-US', N'President', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1512, 757, N'th-TH', N'บุคลากรทุกคน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1513, 757, N'en-US', N'All personnel', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1514, 758, N'th-TH', N'บค. ผู้ดูแลระบบ HRMS', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1515, 758, N'en-US', N'HRD - System Administrator', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1516, 759, N'th-TH', N'บค. จัดการการลาของอธิการบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1517, 759, N'en-US', N'HRD - Manage President''s Leave Requests', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1518, 760, N'th-TH', N'บค. จัดการเวลาเข้าออกงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1519, 760, N'en-US', N'HRD - Manage Work Attendance', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1520, 761, N'th-TH', N'สป. อนุมัติคำสั่งแต่งตั้งผู้รักษาราชการแทน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1521, 761, N'en-US', N'GSAS - Deputation Order Approver', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1522, 762, N'th-TH', N'สป. ทำคำสั่งแต่งตั้งผู้รักษาราชการแทน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1523, 762, N'en-US', N'GSAS - Deputation Order Submitter', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1524, 763, N'th-TH', N'สป. อนุมัติเวลาเข้าออกงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1525, 763, N'en-US', N'GSAS - Approve Employee Attendance', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1526, 764, N'th-TH', N'สป. นำเข้าเวลาเข้าออกงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1527, 764, N'en-US', N'GSAS - Submit Employee Attendance', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1528, 765, N'th-TH', N'สป. อนุมัติเวลาทำงานนอกสถานที่', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1529, 765, N'en-US', N'GSAS - Approve Off-Site Activities', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1530, 766, N'th-TH', N'สป. บันทึกการทำงานนอกสถานที่', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1531, 766, N'en-US', N'GSAS - Submit Off-Site Event Participation', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1532, 767, N'th-TH', N'สป. ส่งใบลาแทนบุคลากรในหน่วยงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1533, 767, N'en-US', N'GSAS - Request Leave for Others in the Org Unit', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1534, 768, N'th-TH', N'สอธ. ทำคำสั่งแต่งผู้บริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1535, 768, N'en-US', N'OOTP - Submit Executive Appointment Order', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1536, 769, N'th-TH', N'สอธ. อนุมัติคำสั่งแต่งผู้บริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1537, 769, N'en-US', N'OOTP - Approve Executive Appointment Order', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1538, 770, N'th-TH', N'สอธ. อนุมัติเวลาเข้าออกงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1539, 770, N'en-US', N'OOTP - Approve Employee Attendance', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1540, 771, N'th-TH', N'สอธ. นำเข้าเวลาเข้าออกงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1541, 771, N'en-US', N'OOTP - Submit Employee Attendance', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1542, 772, N'th-TH', N'สอธ. บันทึกเวลาทำงานนอกสถานที่', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1543, 772, N'en-US', N'OOTP - Submit Off-Site Activities', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1544, 773, N'th-TH', N'สอธ. ส่งใบลาแทนพนักงานในหน่วยงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1545, 773, N'en-US', N'OOTP - Request Leave for Others in the Org Unit', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1546, 774, N'th-TH', N'บริหารระบบ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1547, 774, N'en-US', N'Administer HRMS', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1548, 775, N'th-TH', N'อนุมัติคำสั่งแต่งตั้งผู้บริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1549, 775, N'en-US', N'Approve Revocation of Executive Order', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1550, 776, N'th-TH', N'ทำคำสั่งแต่งตั้งผู้บริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1551, 776, N'en-US', N'Create Revocation of Executive Order', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1552, 777, N'th-TH', N'ทำคำสั่งแต่งตั้งผู้รักษาราชการแทน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1553, 777, N'en-US', N'Create Deputation Order', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1554, 778, N'th-TH', N'อนุมัติคำสั่งแต่งตั้งผู้รักษาราชการแทน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1555, 778, N'en-US', N'Approve Deputation Order', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1556, 779, N'th-TH', N'ทำคำสั่งแต่งตั้งผู้บริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1557, 779, N'en-US', N'Create Executive Appointment Order', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1558, 780, N'th-TH', N'อนุมัติคำสั่งแต่งตั้งผู้บริหาร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1559, 780, N'en-US', N'Approve Executive Appointment Order', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1560, 781, N'th-TH', N'บันทึกใบลาของอธิการบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1561, 781, N'en-US', N'Create a Leave Transaction of the President', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1562, 782, N'th-TH', N'ยืนยันการบันทึกใบลาของอธิการบดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1563, 782, N'en-US', N'Approve a Leave Transaction of the President', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1564, 783, N'th-TH', N'อนุมัติการลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1565, 783, N'en-US', N'Approve Leave Request', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1566, 784, N'th-TH', N'ยื่นใบลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1567, 784, N'en-US', N'Submit Leave Request', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1568, 785, N'th-TH', N'อนุมัติการลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1569, 785, N'en-US', N'Approve Leave Request', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1570, 786, N'th-TH', N'ยื่นใบลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1571, 786, N'en-US', N'Submit Leave Request', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1572, 787, N'th-TH', N'อนุมัติการลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1573, 787, N'en-US', N'Approve Leave Request', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1574, 788, N'th-TH', N'ยื่นใบลา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1575, 788, N'en-US', N'Submit Leave Request', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1576, 789, N'th-TH', N'ยื่นใบลาแทน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1577, 789, N'en-US', N'Submit leave request for others', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1578, 790, N'th-TH', N'นำเข้าเวลาเข้าออกงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1579, 790, N'en-US', N'Import Employee Attendance', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1580, 791, N'th-TH', N'แก้ไขเวลาเข้าออกงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1581, 791, N'en-US', N'Edit Employee Attendance', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1582, 792, N'th-TH', N'อนุมัติเวลาเข้าออกงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1583, 792, N'en-US', N'Approve Employee Attendance', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1584, 793, N'th-TH', N'บันทึกเวลาทำงานนอกสถานที่', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1585, 793, N'en-US', N'Enter Employee''s Off-site Event Participation', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1586, 794, N'th-TH', N'อนุมัติเวลาทำงานนอกสถานที่', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1587, 794, N'en-US', N'Approve Employee''s Off-site Participation', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1588, 795, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1589, 795, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1590, 796, N'th-TH', N'ประดิษฐ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1591, 796, N'en-US', N'Pradit', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1592, 797, N'th-TH', N'วรรณรัตน์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1593, 797, N'en-US', N'Wanarat', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1594, 798, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1595, 798, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1596, 799, N'th-TH', N'เกษมศานต์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1597, 799, N'en-US', N'Kasemsarn', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1598, 800, N'th-TH', N'โชติชาครพันธุ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1599, 800, N'en-US', N'Chotchakornpant', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1600, 801, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1601, 801, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1602, 802, N'th-TH', N'ธวัชชัย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1603, 802, N'en-US', N'Tawadchai', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1604, 803, N'th-TH', N'ศุภดิษฐ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1605, 803, N'en-US', N'Suppadit', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1606, 804, N'th-TH', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1607, 804, N'en-US', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1608, 805, N'th-TH', N'พหลโยธิน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1609, 805, N'en-US', N'Phonyothin Road', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1610, 806, N'th-TH', N'เสนานิคม จตุจักร กรุงเทพฯ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1611, 806, N'en-US', N'senanikhom jtujak, Bangkok', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1612, 807, N'th-TH', N'นาง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1613, 807, N'en-US', N'Mrs.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1614, 808, N'th-TH', N'ระวีวรรณ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1615, 808, N'en-US', N'Raweewan', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1616, 809, N'th-TH', N'เอื้อพันธ์วิริยะกุล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1617, 809, N'en-US', N'Auepanwiriyakul', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1618, 810, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1619, 810, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1620, 811, N'th-TH', N'กำพล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1621, 811, N'en-US', N'Kampol', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1622, 812, N'th-TH', N'ปัญญาโกเมศ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1623, 812, N'en-US', N'Panyagometh', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1624, 813, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1625, 813, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1626, 814, N'th-TH', N'ทวีศักดิ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1627, 814, N'en-US', N'Thaweesak', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1628, 815, N'th-TH', N'สูทกวาทิน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1629, 815, N'en-US', N'Suthagawatin', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1630, 816, N'th-TH', N'นางสาว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1631, 816, N'en-US', N'Ms.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1632, 817, N'th-TH', N'กนกกานต์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1633, 817, N'en-US', N'Kanokkarn', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1634, 818, N'th-TH', N'แก้วนุช', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1635, 818, N'en-US', N'Kaewnuch', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1636, 819, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1637, 819, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1638, 820, N'th-TH', N'ปราโมทย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1639, 820, N'en-US', N'Pramote', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1640, 821, N'th-TH', N'กั่วเจริญ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1641, 821, N'en-US', N'Kuacharoen', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1642, 822, N'th-TH', N'นางสาว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1643, 822, N'en-US', N'Ms.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1644, 823, N'th-TH', N'จุฑารัตน์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1645, 823, N'en-US', N'Chutarat', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1646, 824, N'th-TH', N'ชมพันธุ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1647, 824, N'en-US', N'Chompunth', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1648, 825, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1649, 825, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1650, 826, N'th-TH', N'วิรัชญ์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1651, 826, N'en-US', N'Warat', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1652, 827, N'th-TH', N'ครุจิต', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1653, 827, N'en-US', N'Karuchit', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1654, 828, N'th-TH', N'นาง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1655, 828, N'en-US', N'Mrs.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1656, 829, N'th-TH', N'จิรประภา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1657, 829, N'en-US', N'Chiraprapha', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1658, 830, N'th-TH', N'อัครบวร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1659, 830, N'en-US', N'Akaraborworn', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1660, 831, N'th-TH', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1661, 831, N'en-US', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1662, 832, N'th-TH', N'พหลโยธิน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1663, 832, N'en-US', N'Phonyothin Road', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1664, 833, N'th-TH', N'เสนานิคม จตุจักร กรุงเทพฯ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1665, 833, N'en-US', N'senanikhom jtujak, Bangkok', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1666, 834, N'th-TH', N'นาง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1667, 834, N'en-US', N'Ms.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1668, 835, N'th-TH', N'ศิวิกา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1669, 835, N'en-US', N'Siwiga', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1670, 836, N'th-TH', N'ดุษฎีโหนด', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1671, 836, N'en-US', N'Dusadenode', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1672, 837, N'th-TH', N'นางสาว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1673, 837, N'en-US', N'Ms.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1674, 838, N'th-TH', N'วัชรีพร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1675, 838, N'en-US', N'Watchareeporn', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1676, 839, N'th-TH', N'ชัยมงคล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1677, 839, N'en-US', N'Chaimongkol', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1678, 840, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1679, 840, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1680, 841, N'th-TH', N'วรเทพ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1681, 841, N'en-US', N'Worathep', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1682, 842, N'th-TH', N'จันทกนกากร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1683, 842, N'en-US', N'Chantakanakakorn', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1684, 843, N'th-TH', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1685, 843, N'en-US', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1686, 844, N'th-TH', N'พหลโยธิน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1687, 844, N'en-US', N'Phonyothin Road', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1688, 845, N'th-TH', N'เสนานิคม จตุจักร กรุงเทพฯ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1689, 845, N'en-US', N'senanikhom jtujak, Bangkok', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1690, 846, N'th-TH', N'นาง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1691, 846, N'en-US', N'Ms.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1692, 847, N'th-TH', N'ประทีป', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1693, 847, N'en-US', N'Prateep', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1694, 848, N'th-TH', N'อินทร์อ่ำ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1695, 848, N'en-US', N'Inam', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1696, 849, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1697, 849, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1698, 850, N'th-TH', N'ชาญยุทธ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1699, 850, N'en-US', N'Charnyut', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1700, 851, N'th-TH', N'แสงแก้ว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1701, 851, N'en-US', N'Saengkaew', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1702, 852, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1703, 852, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1704, 853, N'th-TH', N'สุระ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1705, 853, N'en-US', N'Sura', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1706, 854, N'th-TH', N'ขันทีท้าว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1707, 854, N'en-US', N'Khunteetao', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1708, 855, N'th-TH', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1709, 855, N'en-US', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1710, 856, N'th-TH', N'พหลโยธิน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1711, 856, N'en-US', N'Phonyothin Road', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1712, 857, N'th-TH', N'เสนานิคม จตุจักร กรุงเทพฯ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1713, 857, N'en-US', N'senanikhom jtujak, Bangkok', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1714, 858, N'th-TH', N'นาง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1715, 858, N'en-US', N'Ms.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1716, 859, N'th-TH', N'สุภาภร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1717, 859, N'en-US', N'Supaporn', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1718, 860, N'th-TH', N'ตรีนภา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1719, 860, N'en-US', N'Treenapa', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1720, 861, N'th-TH', N'นางสาว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1721, 861, N'en-US', N'Ms.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1722, 862, N'th-TH', N'ดุษฏี ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1723, 862, N'en-US', N'Dussadee', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1724, 863, N'th-TH', N'กองเพิ่มพูล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1725, 863, N'en-US', N'Kongpermpoon', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1726, 864, N'th-TH', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1727, 864, N'en-US', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1728, 865, N'th-TH', N'พหลโยธิน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1729, 865, N'en-US', N'Phonyothin Road', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1730, 866, N'th-TH', N'เสนานิคม จตุจักร กรุงเทพฯ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1731, 866, N'en-US', N'senanikhom jtujak, Bangkok', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1732, 867, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1733, 867, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1734, 868, N'th-TH', N'สุพจน์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1735, 868, N'en-US', N'Supoj', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1736, 869, N'th-TH', N'สุตัณฑวิบูลย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1737, 869, N'en-US', N'Sutanthavibul', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1738, 870, N'th-TH', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1739, 870, N'en-US', N'2/37', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1740, 871, N'th-TH', N'พหลโยธิน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1741, 871, N'en-US', N'Phonyothin Road', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1742, 872, N'th-TH', N'เสนานิคม จตุจักร กรุงเทพฯ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1743, 872, N'en-US', N'senanikhom jtujak, Bangkok', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1744, 873, N'th-TH', N'นาง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1745, 873, N'en-US', N'Ms.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1746, 874, N'th-TH', N'สุกรรญา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1747, 874, N'en-US', N'Sukanya', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1748, 875, N'th-TH', N'สมมุติ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1749, 875, N'en-US', N'Sommoot', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1750, 876, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1751, 876, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1752, 877, N'th-TH', N'ยุทธนา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1753, 877, N'en-US', N'Yuthana', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1754, 878, N'th-TH', N'สุจริต', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1755, 878, N'en-US', N'Sutjarit', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1756, 879, N'th-TH', N'นาง', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1757, 879, N'en-US', N'Ms.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1758, 880, N'th-TH', N'ประจิม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1759, 880, N'en-US', N'Prajim', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1760, 881, N'th-TH', N'ทองแสนดี', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1761, 881, N'en-US', N'Thongsaendee', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1762, 882, N'th-TH', N'นางสาว', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1763, 882, N'en-US', N'Ms.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1764, 883, N'th-TH', N'อาภาพร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1765, 883, N'en-US', N'Apaporn', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1766, 884, N'th-TH', N'บุนนาค', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1767, 884, N'en-US', N'Boonnak', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1768, 885, N'th-TH', N'นาย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1769, 885, N'en-US', N'Mr.', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1770, 886, N'th-TH', N'อิษฎา', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1771, 886, N'en-US', N'Itsada', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1772, 887, N'th-TH', N'จิตรโชติ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1773, 887, N'en-US', N'Jitchote', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1774, 888, N'th-TH', N'ลาป่วย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1775, 888, N'en-US', N'Sick Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1776, 889, N'th-TH', N'ลาพักผ่อน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1777, 889, N'en-US', N'Vacation Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1778, 890, N'th-TH', N'ลากิจ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1779, 890, N'en-US', N'Personal Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1780, 891, N'th-TH', N'ลาคลอด', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1781, 891, N'en-US', N'Religious Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1782, 892, N'th-TH', N'ลากิจเพื่อเลี้ยงดูบุตรต่อเนื่องจากการลาคลอดบุตร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1783, 892, N'en-US', N'Continual Maternity Leave following a maternity leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1784, 893, N'th-TH', N'ลาช่วยเหลือภริยาที่คลอดบุตร', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1785, 893, N'en-US', N'Paternity Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1786, 894, N'th-TH', N'ลาอุปสมบท', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1787, 894, N'en-US', N'Buddhist Ordination Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1788, 895, N'th-TH', N'ลาไปประกอบพิธีฮัจย์', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1789, 895, N'en-US', N'Hajj Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1790, 896, N'th-TH', N'ลาเพื่อเพิ่มพูนความรู้ทางวิชาการ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1791, 896, N'en-US', N'Sabbatical Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1792, 897, N'th-TH', N'ลาเพื่อพัฒนาคุณธรรมและจริยธรรม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1793, 897, N'en-US', N'Virtue Improvement Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1794, 898, N'th-TH', N'ลาเข้ารับการตรวจเลือกหรือเข้ารับการเตรียมพล', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1795, 898, N'en-US', N'Military Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1796, 899, N'th-TH', N'ลาไปดูงาน', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1797, 899, N'en-US', N'Site Visit Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1798, 900, N'th-TH', N'ลาไปศึกษาเพิ่มเติม', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1799, 900, N'en-US', N'Study Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1800, 901, N'th-TH', N'ลาไปปฏิบัติการวิจัย', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1801, 901, N'en-US', N'Research Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1802, 902, N'th-TH', N'ลาติดตามคู่สมรส', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1803, 902, N'en-US', N'Spouse Accompanying Leave', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1804, 903, N'th-TH', N'ลาไปปฏิบัติงานในองค์การระหว่างประเทศ', NULL)
GO
INSERT [dbo].[MLSValue] ([ID], [MLSID], [LanguageCode], [Value], [UpdatedTS]) VALUES (1805, 903, N'en-US', N'Working for International Organization Leave', NULL)
GO
SET IDENTITY_INSERT [dbo].[MLSValue] OFF
GO
SET IDENTITY_INSERT [dbo].[MultilingualString] ON 

GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (1, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (2, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (3, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (4, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (5, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (6, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (7, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (8, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (9, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (10, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (11, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (12, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (13, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (14, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (15, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (16, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (17, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (18, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (19, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (20, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (21, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (22, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (23, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (24, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (25, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (26, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (27, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (28, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (29, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (30, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (31, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (32, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (33, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (34, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (35, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (36, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (37, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (38, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (39, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (40, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (41, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (42, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (43, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (44, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (45, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (46, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (47, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (48, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (49, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (50, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (51, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (52, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (53, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (54, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (55, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (56, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (57, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (58, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (59, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (60, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (61, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (62, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (63, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (64, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (65, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (66, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (67, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (68, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (69, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (70, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (71, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (72, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (73, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (74, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (75, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (76, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (77, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (78, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (79, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (80, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (81, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (82, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (83, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (84, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (85, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (86, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (87, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (88, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (89, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (90, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (91, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (92, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (93, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (94, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (95, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (96, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (97, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (98, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (99, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (100, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (101, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (102, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (103, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (104, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (105, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (106, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (107, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (108, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (109, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (110, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (111, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (112, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (113, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (114, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (115, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (116, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (117, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (118, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (119, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (120, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (121, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (122, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (123, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (124, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (125, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (126, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (127, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (128, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (129, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (130, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (131, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (132, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (133, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (134, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (135, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (136, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (137, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (138, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (139, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (140, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (141, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (142, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (143, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (144, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (145, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (146, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (147, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (148, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (149, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (150, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (151, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (152, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (153, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (154, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (155, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (156, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (157, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (158, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (159, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (160, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (161, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (162, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (163, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (164, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (165, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (166, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (167, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (168, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (169, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (170, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (171, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (172, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (173, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (174, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (175, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (176, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (177, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (178, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (179, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (180, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (181, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (182, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (183, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (184, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (185, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (186, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (187, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (188, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (189, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (190, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (191, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (192, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (193, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (194, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (195, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (196, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (197, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (198, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (199, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (200, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (201, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (202, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (203, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (204, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (205, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (206, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (207, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (208, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (209, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (210, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (211, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (212, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (213, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (214, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (215, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (216, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (217, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (218, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (219, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (220, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (221, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (222, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (223, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (224, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (225, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (226, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (227, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (228, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (229, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (230, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (231, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (232, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (233, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (234, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (235, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (236, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (237, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (238, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (239, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (240, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (241, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (242, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (243, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (244, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (245, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (246, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (247, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (248, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (249, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (250, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (251, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (252, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (253, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (254, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (255, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (256, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (257, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (258, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (259, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (260, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (261, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (262, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (263, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (264, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (265, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (266, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (267, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (268, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (269, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (270, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (271, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (272, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (273, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (274, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (275, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (276, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (277, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (278, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (279, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (280, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (281, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (282, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (283, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (284, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (285, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (286, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (287, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (288, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (289, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (290, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (291, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (292, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (293, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (294, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (295, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (296, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (297, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (298, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (299, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (300, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (301, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (302, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (303, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (304, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (305, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (306, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (307, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (308, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (309, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (310, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (311, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (312, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (313, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (314, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (315, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (316, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (317, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (318, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (319, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (320, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (321, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (322, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (323, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (324, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (325, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (326, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (327, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (328, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (329, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (330, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (331, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (332, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (333, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (334, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (335, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (336, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (337, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (338, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (339, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (340, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (341, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (342, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (343, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (344, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (345, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (346, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (347, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (348, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (349, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (350, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (351, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (352, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (353, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (354, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (355, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (356, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (357, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (358, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (359, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (360, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (361, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (362, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (363, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (364, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (365, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (366, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (367, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (368, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (369, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (370, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (371, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (372, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (373, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (374, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (375, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (376, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (377, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (378, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (379, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (380, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (381, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (382, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (383, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (384, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (385, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (386, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (387, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (388, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (389, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (390, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (391, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (392, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (393, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (394, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (395, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (396, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (397, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (398, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (399, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (400, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (401, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (402, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (403, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (404, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (405, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (406, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (407, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (408, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (409, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (410, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (411, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (412, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (413, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (414, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (415, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (416, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (417, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (418, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (419, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (420, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (421, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (422, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (423, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (424, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (425, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (426, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (427, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (428, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (429, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (430, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (431, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (432, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (433, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (434, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (435, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (436, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (437, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (438, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (439, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (440, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (441, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (442, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (443, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (444, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (445, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (446, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (447, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (448, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (449, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (450, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (451, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (452, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (453, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (454, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (455, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (456, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (457, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (458, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (459, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (460, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (461, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (462, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (463, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (464, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (465, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (466, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (467, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (468, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (469, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (470, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (471, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (472, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (473, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (474, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (475, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (476, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (477, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (478, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (479, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (480, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (481, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (482, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (483, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (484, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (485, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (486, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (487, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (488, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (489, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (490, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (491, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (492, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (493, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (494, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (495, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (496, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (497, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (498, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (499, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (500, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (501, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (502, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (503, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (504, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (505, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (506, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (507, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (508, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (509, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (510, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (511, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (512, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (513, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (514, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (515, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (516, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (517, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (518, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (519, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (520, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (521, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (522, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (523, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (524, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (525, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (526, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (527, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (528, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (529, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (530, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (531, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (532, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (533, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (534, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (535, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (536, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (537, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (538, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (539, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (540, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (541, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (542, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (543, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (544, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (545, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (546, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (547, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (548, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (549, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (550, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (551, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (552, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (553, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (554, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (555, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (556, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (557, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (558, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (559, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (560, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (561, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (562, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (563, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (564, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (565, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (566, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (567, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (568, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (569, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (570, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (571, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (572, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (573, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (574, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (575, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (576, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (577, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (578, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (579, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (580, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (581, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (582, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (583, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (584, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (585, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (586, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (587, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (588, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (589, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (590, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (591, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (592, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (593, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (594, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (595, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (596, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (597, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (598, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (599, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (600, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (601, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (602, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (603, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (604, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (605, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (606, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (607, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (608, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (609, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (610, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (611, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (612, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (613, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (614, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (615, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (616, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (617, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (618, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (619, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (620, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (621, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (622, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (623, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (624, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (625, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (626, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (627, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (628, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (629, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (630, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (631, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (632, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (633, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (634, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (635, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (636, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (637, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (638, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (639, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (640, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (641, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (642, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (643, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (644, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (645, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (646, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (647, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (648, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (649, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (650, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (651, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (652, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (653, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (654, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (655, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (656, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (657, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (658, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (659, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (660, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (661, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (662, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (663, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (664, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (665, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (666, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (667, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (668, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (669, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (670, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (671, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (672, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (673, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (674, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (675, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (676, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (677, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (678, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (679, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (680, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (681, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (682, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (683, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (684, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (685, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (686, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (687, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (688, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (689, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (690, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (691, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (692, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (693, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (694, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (695, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (696, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (697, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (698, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (699, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (700, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (701, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (702, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (703, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (704, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (705, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (706, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (707, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (708, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (709, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (710, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (711, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (712, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (713, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (714, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (715, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (716, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (717, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (718, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (719, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (720, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (721, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (722, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (723, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (724, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (725, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (726, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (727, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (728, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (729, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (730, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (731, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (732, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (733, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (734, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (735, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (736, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (737, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (738, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (739, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (740, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (741, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (742, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (743, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (744, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (745, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (746, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (747, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (748, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (749, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (750, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (751, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (752, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (753, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (754, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (755, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (756, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (757, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (758, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (759, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (760, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (761, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (762, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (763, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (764, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (765, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (766, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (767, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (768, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (769, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (770, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (771, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (772, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (773, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (774, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (775, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (776, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (777, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (778, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (779, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (780, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (781, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (782, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (783, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (784, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (785, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (786, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (787, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (788, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (789, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (790, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (791, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (792, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (793, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (794, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (795, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (796, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (797, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (798, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (799, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (800, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (801, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (802, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (803, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (804, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (805, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (806, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (807, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (808, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (809, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (810, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (811, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (812, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (813, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (814, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (815, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (816, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (817, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (818, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (819, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (820, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (821, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (822, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (823, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (824, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (825, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (826, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (827, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (828, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (829, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (830, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (831, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (832, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (833, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (834, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (835, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (836, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (837, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (838, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (839, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (840, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (841, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (842, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (843, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (844, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (845, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (846, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (847, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (848, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (849, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (850, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (851, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (852, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (853, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (854, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (855, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (856, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (857, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (858, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (859, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (860, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (861, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (862, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (863, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (864, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (865, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (866, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (867, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (868, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (869, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (870, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (871, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (872, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (873, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (874, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (875, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (876, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (877, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (878, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (879, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (880, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (881, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (882, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (883, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (884, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (885, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (886, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (887, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (888, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (889, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (890, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (891, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (892, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (893, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (894, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (895, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (896, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (897, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (898, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (899, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (900, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (901, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (902, NULL, N'')
GO
INSERT [dbo].[MultilingualString] ([ID], [Description], [Code]) VALUES (903, NULL, N'')
GO
SET IDENTITY_INSERT [dbo].[MultilingualString] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

GO
INSERT [dbo].[Role] ([ID], [SystemID], [Code], [TitleMLSID], [DescriptionMLSID], [IsBuiltin], [PrivilegeLevel], [SeqNo], [EffectiveFrom], [EffectiveTo], [OrgUnitID], [IsDefault]) VALUES (1, NULL, N'Maker', NULL, NULL, NULL, NULL, NULL, CAST(N'2016-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2800-12-31 00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Role] ([ID], [SystemID], [Code], [TitleMLSID], [DescriptionMLSID], [IsBuiltin], [PrivilegeLevel], [SeqNo], [EffectiveFrom], [EffectiveTo], [OrgUnitID], [IsDefault]) VALUES (2, NULL, N'Approver', NULL, NULL, NULL, NULL, NULL, CAST(N'2016-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2800-12-31 00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Role] ([ID], [SystemID], [Code], [TitleMLSID], [DescriptionMLSID], [IsBuiltin], [PrivilegeLevel], [SeqNo], [EffectiveFrom], [EffectiveTo], [OrgUnitID], [IsDefault]) VALUES (3, NULL, N'Viewer', NULL, NULL, NULL, NULL, NULL, CAST(N'2016-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2800-12-31 00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[SequenceNumbers] ([SystemID], [SequenceType], [SubsequenceType], [SequenceNo], [Seed], [Increment], [Pattern]) VALUES (1, 20, 16, 1, 1, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[TreeListNode] ON 

GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (1, N'AcademicRank', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 1, NULL, 0, NULL, NULL, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (2, N'Prof', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 1, 1, 0, 249, 248, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (3, N'AssocProf', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 1, 1, 0, 251, 250, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (4, N'AsstProf', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 1, 1, 0, 253, 252, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (5, N'Lect', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 1, 1, 0, 255, 254, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (6, N'BloodGroup', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 6, NULL, 0, NULL, NULL, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (7, N'A', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 6, 6, 0, NULL, 256, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (8, N'B', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 6, 6, 0, NULL, 257, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (9, N'AB', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 6, 6, 0, NULL, 258, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (10, N'O', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 6, 6, 0, NULL, 259, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (11, N'U', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 6, 6, 0, NULL, 260, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (12, N'EducationLevel', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 12, NULL, 0, NULL, NULL, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (13, NULL, NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, 12, 12, 0, 262, 261, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (14, NULL, NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, 12, 12, 0, 264, 263, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (15, NULL, NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, 12, 12, 0, 266, 265, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (16, NULL, NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 4, NULL, NULL, NULL, 12, 12, 0, 268, 267, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (17, NULL, NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 5, NULL, NULL, NULL, 12, 12, 0, 270, 269, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (18, NULL, NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 5, NULL, NULL, NULL, 12, 12, 0, 272, 271, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (19, NULL, NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 6, NULL, NULL, NULL, 12, 12, 0, 274, 273, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (20, NULL, NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 7, NULL, NULL, NULL, 12, 12, 0, 276, 275, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (21, N'Gender', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 21, NULL, 0, NULL, NULL, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (22, N'Female', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 21, 21, 0, NULL, 277, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (23, N'Male', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 21, 21, 0, NULL, 278, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (24, N'Unknown', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 21, 21, 0, NULL, 279, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (25, N'PPRCategory', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 25, NULL, 0, NULL, NULL, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (26, N'Father', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 25, 25, 0, NULL, 280, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (27, N'Mother', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 25, 25, 0, NULL, 281, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (28, N'Guardian', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 25, 25, 0, NULL, 282, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (29, N'MaritalStatus', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 29, NULL, 0, NULL, 283, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (30, N'Divorced', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 29, 29, 0, NULL, 284, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (31, N'Married', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 29, 29, 0, NULL, 285, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (32, N'Single', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 29, 29, 0, NULL, 286, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (33, N'Widowed', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 29, 29, 0, NULL, 287, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (34, N'Religion', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 34, NULL, 0, NULL, 288, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (35, N'Atheism', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 34, 34, 0, NULL, 289, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (36, N'Buddhism', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 34, 34, 0, NULL, 290, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (37, N'Christianity', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 34, 34, 0, NULL, 291, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (38, N'Hinduism', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 34, 34, 0, NULL, 292, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (39, N'Islam', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 34, 34, 0, NULL, 293, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (40, N'Sikism', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 34, 34, 0, NULL, 294, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (41, N'Unknown', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 34, 34, 0, NULL, 295, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (42, N'RoyalDecoration', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 42, NULL, 0, NULL, 296, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (43, N'', 299, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 7, NULL, NULL, NULL, 42, 42, 15, 298, 297, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (44, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 7, NULL, NULL, NULL, 42, 42, 14, 301, 300, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (45, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 6, NULL, NULL, NULL, 42, 42, 13, 303, 302, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (46, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 6, NULL, NULL, NULL, 42, 42, 12, 305, 304, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (47, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 5, NULL, NULL, NULL, 42, 42, 11, 307, 306, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (48, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 5, NULL, NULL, NULL, 42, 42, 10, 309, 308, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (49, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 4, NULL, NULL, NULL, 42, 42, 9, 311, 310, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (50, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 4, NULL, NULL, NULL, 42, 42, 8, 313, 312, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (51, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, 42, 42, 7, 315, 314, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (52, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, 42, 42, 6, 317, 316, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (53, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, 42, 42, 5, 319, 318, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (54, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 2, NULL, NULL, NULL, 42, 42, 4, 321, 320, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (55, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, 42, 42, 3, 323, 322, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (56, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, 42, 42, 2, 325, 324, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (57, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 42, 42, 1, 327, 326, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (58, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 42, 42, 0, 329, 328, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (59, N'EmpAppointmentCategory', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 59, NULL, 0, NULL, 330, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (60, N'Appoint', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 59, 59, 0, NULL, 331, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (61, N'Acting', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 59, 59, 0, NULL, 332, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (62, N'Elected', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 59, 59, 0, NULL, 333, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (63, N'EmpHiringCategory', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 63, NULL, 0, NULL, 334, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (64, N'Selected', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 63, 63, 0, NULL, 335, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (65, N'Exam', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 63, 63, 0, NULL, 336, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (66, N'Transferred', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 63, 63, 0, NULL, 337, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (67, N'EmpTerminationCategory', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 67, NULL, 0, NULL, 338, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (68, N'Quit', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 67, 67, 0, NULL, 339, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (69, N'Discharge', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 67, 67, 0, NULL, 340, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (70, N'Dismissal', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 67, 67, 0, NULL, 341, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (71, N'Fired', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 67, 67, 0, NULL, 342, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (72, N'Retired', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 67, 67, 0, NULL, 343, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (73, N'TransferOut', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 67, 67, 0, NULL, 344, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (74, N'PosCategory', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 74, NULL, 0, NULL, 345, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (75, N'Allocated', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 74, 74, 0, NULL, 346, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (76, N'Transferred', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 74, 74, 0, NULL, 347, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (77, N'Exchanged', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 74, 74, 0, NULL, 348, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (78, N'EmpCategory', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 78, NULL, 0, NULL, 349, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (79, N'GovOfficer', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 78, 78, 0, NULL, 350, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (80, N'UnivEmployee', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 78, 78, 0, NULL, 351, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (81, N'TempEmployee', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 78, 78, 0, NULL, 352, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (82, N'UnivProfessionCategory', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, NULL, 0, NULL, 353, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (83, N'0', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 82, 0, NULL, 354, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (84, N'1', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 83, 0, NULL, 355, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (85, N'1', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 82, 0, NULL, 356, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (86, N'00', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 85, 0, NULL, 357, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (87, N'01', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 85, 0, NULL, 358, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (88, N'02', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 85, 0, NULL, 359, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (89, N'03', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 85, 0, NULL, 360, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (90, N'04', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 85, 0, NULL, 361, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (91, N'05', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 85, 0, NULL, 362, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (92, N'06', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 85, 0, NULL, 363, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (93, N'07', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 85, 0, NULL, 364, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (94, N'08', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 85, 0, NULL, 365, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (95, N'09', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 85, 0, NULL, 366, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (96, N'10', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 85, 0, NULL, 367, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (97, N'2', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 82, 0, NULL, 368, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (98, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 97, 0, NULL, 369, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (99, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 97, 0, NULL, 370, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (100, N'3', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 82, 0, NULL, 371, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (101, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 100, 0, NULL, 372, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (102, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 100, 0, NULL, 373, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (103, N'4', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 82, 0, NULL, 374, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (104, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 103, 0, NULL, 375, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (105, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 103, 0, NULL, 376, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (106, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 103, 0, NULL, 377, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (107, N'5', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 82, 0, NULL, 378, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (108, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 107, 0, NULL, 379, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (109, N'6', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 82, 0, NULL, 380, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (110, N'01', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 381, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (111, N'02', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 382, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (112, N'03', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 383, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (113, N'04', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 384, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (114, N'05', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 385, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (115, N'06', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 386, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (116, N'07', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 387, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (117, N'08', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 388, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (118, N'09', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 389, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (119, N'10', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 390, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (120, N'11', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 391, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (121, N'12', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 392, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (122, N'13', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 393, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (123, N'14', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 394, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (124, N'15', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 109, 0, NULL, 395, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (125, N'7', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 82, 0, NULL, 396, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (126, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 125, 0, NULL, 397, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (127, N'', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 125, 0, NULL, 398, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (128, N'8', NULL, CAST(N'1800-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 82, 82, 0, NULL, 399, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (129, N'AddressCategory', NULL, CAST(N'2010-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 129, NULL, 0, NULL, 447, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (130, N'OfficialAddr', NULL, CAST(N'2010-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 129, 129, 0, NULL, 448, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (131, N'CurrentAddr', NULL, CAST(N'2010-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 129, 129, 0, NULL, 449, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[TreeListNode] ([ID], [Code], [DescriptionMLSID], [EffectiveFrom], [EffectiveTo], [IsActive], [IsBuiltin], [IsCredit], [IsDebit], [IsDefault], [IsImmutable], [IsMandatory], [IsParent], [NodeLevel], [RelatedNodeID], [RelatedNodeTitleMLSID], [Remark], [RootNodeID], [ParentNodeID], [SeqNo], [ShortTitleMLSID], [TitleMLSID], [ValueDate], [ValueNumber], [ValueMLSID], [ValueString], [ValueTypes], [Weight]) VALUES (132, N'MailingAddr', NULL, CAST(N'2010-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2300-12-31 23:59:59.9990000' AS DateTime2), 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 129, 129, 0, NULL, 450, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[TreeListNode] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([ID], [Discriminator], [SystemID], [IsNotFinalized], [CreatedBy], [CreatedTS], [ApprovedBy], [ApprovedTS], [EffectiveFrom], [EffectiveTo], [ConsecutiveFailedLoginCount], [IsBuiltin], [IsDisable], [LastLoginTimestamp], [LastFailedLoginTimestamp], [OrgID], [PersonId], [LoginName], [EMailAddress], [MobilePhoneNumber], [CurrentPasswordID], [IsReinstated], [MustChangePasswordAfterFirstLogon], [MustChangePasswordAtNextLogon], [PasswordAgeInDays], [PasswordNeverExpires], [BranchCode], [Name]) VALUES (1, 1, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, N'supoj', N'supojsu@yahoo.com', NULL, NULL, 0, 0, 0, 0, 0, N'0001', N'Supoj Sutanthavibul')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [MLSValue_MLSID]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [MLSValue_MLSID] ON [dbo].[MLSValue]
(
	[MLSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Password_UserEffectivePeriod]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [Password_UserEffectivePeriod] ON [dbo].[Password]
(
	[UserID] ASC,
	[EffectiveFrom] ASC,
	[EffectiveTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Role_System_EffectivePeriod]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [Role_System_EffectivePeriod] ON [dbo].[Role]
(
	[SystemID] ASC,
	[EffectiveFrom] ASC,
	[EffectiveTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [RoleUseCase_Role]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [RoleUseCase_Role] ON [dbo].[RoleUseCase]
(
	[RoleID] ASC,
	[EffectiveFrom] ASC,
	[EffectiveTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_Account_Proxy_1]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Account_Proxy_1] ON [dbo].[TB_T_Account_Proxy]
(
	[CIS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_Account_Proxy_2]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Account_Proxy_2] ON [dbo].[TB_T_Account_Proxy]
(
	[Registration_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_Account_Proxy_3]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Account_Proxy_3] ON [dbo].[TB_T_Account_Proxy]
(
	[Branch_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_Account_Proxy_4]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Account_Proxy_4] ON [dbo].[TB_T_Account_Proxy]
(
	[Registering_Branch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IDX_Account_Proxy_State_1]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Account_Proxy_State_1] ON [dbo].[TB_T_Account_Proxy_State]
(
	[FK_Account_Proxy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_AnyID_1]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_AnyID_1] ON [dbo].[TB_T_AnyID]
(
	[ID_No] ASC,
	[ID_Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_Customer_1]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IDX_Customer_1] ON [dbo].[TB_T_Customer]
(
	[CIS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_Customer_2]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Customer_2] ON [dbo].[TB_T_Customer]
(
	[First_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_Customer_3]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Customer_3] ON [dbo].[TB_T_Customer]
(
	[Last_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_Customer_4]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Customer_4] ON [dbo].[TB_T_Customer]
(
	[ID_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IDX_Proxy_Transaction_1]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Proxy_Transaction_1] ON [dbo].[TB_T_Proxy_Transaction]
(
	[FK_Account_Proxy_1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_Proxy_Transaction_2]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Proxy_Transaction_2] ON [dbo].[TB_T_Proxy_Transaction]
(
	[Registration_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IDX_Proxy_Transaction_3]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Proxy_Transaction_3] ON [dbo].[TB_T_Proxy_Transaction]
(
	[Current_State_Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_Proxy_Transaction_4]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Proxy_Transaction_4] ON [dbo].[TB_T_Proxy_Transaction]
(
	[Transaction_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IDX_Proxy_Transaction_5]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Proxy_Transaction_5] ON [dbo].[TB_T_Proxy_Transaction]
(
	[Branch_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IDX_Proxy_Transaction_State_1]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Proxy_Transaction_State_1] ON [dbo].[TB_T_Proxy_Transaction_State]
(
	[FK_Proxy_Transaction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IDX_Transaction_Document_1]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Transaction_Document_1] ON [dbo].[TB_T_Transaction_Document]
(
	[FK_Proxy_Transaction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [TreeListNode_EffectivePeriod]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [TreeListNode_EffectivePeriod] ON [dbo].[TreeListNode]
(
	[EffectiveFrom] ASC,
	[EffectiveTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [TreeListNode_Parent]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [TreeListNode_Parent] ON [dbo].[TreeListNode]
(
	[ParentNodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [TreeListNode_Root]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [TreeListNode_Root] ON [dbo].[TreeListNode]
(
	[RootNodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UseCase_Code]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UseCase_Code] ON [dbo].[UseCase]
(
	[SystemID] ASC,
	[Code] ASC,
	[EffectiveFrom] ASC,
	[EffectiveTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UserRole_UserEffectivePeriod]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [UserRole_UserEffectivePeriod] ON [dbo].[UserRole]
(
	[UserID] ASC,
	[EffectiveFrom] ASC,
	[EffectiveTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [User_LoginName]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [User_LoginName] ON [dbo].[Users]
(
	[LoginName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [User_SystemEffectivePeriod]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [User_SystemEffectivePeriod] ON [dbo].[Users]
(
	[SystemID] ASC,
	[EffectiveFrom] ASC,
	[EffectiveTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UserSession_User]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [UserSession_User] ON [dbo].[UserSession]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UserSessionLog_UserSession]    Script Date: 17/6/2016 11:02:32 PM ******/
CREATE NONCLUSTERED INDEX [UserSessionLog_UserSession] ON [dbo].[UserSessionLog]
(
	[UserSessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_GenSequenceNo]    Script Date: 17/6/2016 11:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author: Supoj Sutanthavibul
-- Create date: 2012-12-20
-- Description: Generate unique running sequence no.
-- =============================================
create procedure [dbo].[usp_GenSequenceNo] 
@systemID int,
@sequenceType int,
@subsequenceType bigint,
@seed bigint,
@increment bigint,
@sequenceNo bigint output
AS
BEGIN
	set nocount on
	set @sequenceNo = null
	set transaction isolation level serializable
	
	Begin Transaction
	SELECT @sequenceNo = SequenceNo
		from SequenceNumbers
		where [SystemID] = @systemID and SequenceType = @sequenceType and SubsequenceType = @subsequenceType 

	if (@sequenceNo is null)
		begin
			set @sequenceNo = @seed
			INSERT INTO [dbo].[SequenceNumbers] ([SystemID],[SequenceType],[SubsequenceType],[SequenceNo],[Seed],[Increment]) 
				VALUES(@systemID, @sequenceType, @subsequenceType, @seed, @seed, @increment)
		end
	else
		begin
			set @sequenceNo = @sequenceNo + @increment
			update SequenceNumbers 
				set SequenceNo = @sequenceNo 
				where [SystemID] = @systemID and SequenceType = @sequenceType and SubsequenceType = @subsequenceType
		end
	Commit Transaction
END

GO
