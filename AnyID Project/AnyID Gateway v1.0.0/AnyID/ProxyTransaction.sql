CREATE TABLE [dbo].[TB_T_Proxy_Transaction]
(
	PK_Proxy_Transaction bigint NOT NULL identity(1,1) PRIMARY KEY,
	Discriminator tinyint not null,
    FK_Account_Proxy_1 bigint,
    FK_Account_Proxy_2 bigint,
	Branch_Code nvarchar(8),
	CIS_ID nvarchar(10),
    Current_State_Category tinyint,
    FK_Proxy_Transaction_State bigint,
    Document_ID bigint,
	Registration_ID nchar(12),
    Retry_Count int,
	Transaction_No nvarchar(12),
	Transaction_TS datetime2,
)
go

create index IDX_Proxy_Transaction_1 on [TB_T_Proxy_Transaction] (FK_Account_Proxy_1)
go

create index IDX_Proxy_Transaction_2 on [TB_T_Proxy_Transaction] (Registration_ID)
go

create index IDX_Proxy_Transaction_3 on [TB_T_Proxy_Transaction] (Current_State_Category)
go

create index IDX_Proxy_Transaction_4 on [TB_T_Proxy_Transaction] (Transaction_No)
go
