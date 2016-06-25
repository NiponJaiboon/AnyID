CREATE table [dbo].TB_T_Account_Proxy
(
	PK_Account_Proxy bigint NOT NULL identity(1,1) PRIMARY KEY,
    FK_AnyID bigint,
	Bank_Account_No nvarchar(20),
	Bank_Account_Name nvarchar(80),
	Bank_Code nvarchar(8),
	Branch_Code nvarchar(8),
	Bank_Account_Status tinyint,
	CIS_ID nvarchar(20),
    Current_State_Category tinyint,
	FK_Customer bigint,
	Display_Name nvarchar(40),
	Dummy_Account_No nvarchar(20),
    FK_Account_Proxy_State bigint,
    FK_Proxy_Transaction bigint,
	KKRequiredStateDescription nvarchar(20),
    Proxy_No bigint,
	Proxy_Type tinyint,
    Registering_Branch nvarchar(8),
    Registered_TS datetime2,
	Registration_ID nchar(12),
    Requested_TS datetime2,
	Status tinyint
)
go

CREATE INDEX IDX_Account_Proxy_1 ON [dbo].TB_T_Account_Proxy (CIS_ID)
go

CREATE INDEX IDX_Account_Proxy_2 ON [dbo].TB_T_Account_Proxy (Registration_ID)
go

