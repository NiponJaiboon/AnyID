CREATE TABLE [dbo].TB_T_AnyID
(
	PK_AnyID bigint NOT NULL identity(1,1) PRIMARY KEY,
	ID_No nvarchar(20),
	ID_Type tinyint,
    Status tinyint,
)
go

create index IDX_AnyID_1 on TB_T_AnyID (ID_No)

