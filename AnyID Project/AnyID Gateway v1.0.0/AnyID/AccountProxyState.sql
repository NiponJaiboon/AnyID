CREATE TABLE [dbo].TB_T_Account_Proxy_State
(
	PK_Account_Proxy_State bigINT NOT NULL identity(1,1) PRIMARY KEY,
	FK_Account_Proxy bigint,
    FK_User bigint,
    Created_TS datetime2,
    Is_Final bit,
    Reference nvarchar(200),
    Remark nvarchar(200),
    State_Category tinyint
);
go

create index IDX_Account_Proxy_State_1 on TB_T_Account_Proxy_State
(
	FK_Account_Proxy asc
);