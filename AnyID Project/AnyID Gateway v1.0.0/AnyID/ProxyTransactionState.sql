CREATE TABLE [dbo].TB_T_Proxy_Transaction_State
(
	PK_Proxy_Transaction_State bigINT NOT NULL identity(1,1) PRIMARY KEY,
	FK_Proxy_Transaction bigint,
    FK_User bigint,
    Created_TS datetime2,
    Is_Final bit,
    Reference nvarchar(200),
    Remark nvarchar(200),
    State_Category tinyint
);
go

create index IDX_Proxy_Transaction_State_1 on TB_T_Proxy_Transaction_State
(
	FK_Proxy_Transaction asc
)
go