CREATE TABLE [dbo].TB_T_Transaction_Document
(
	PK_Transaction_Document bigINT NOT NULL identity(1,1) PRIMARY KEY,
	Document_Content ntext,
    Document_File_Name nvarchar(200),
    Document_Format nvarchar(200),
    Document_Type nvarchar(40),
	FK_Proxy_Transaction bigint,
    FK_User bigint,
    Uploaded_TS datetime2
);
go

create index IDX_Transaction_Document_1 on TB_T_Transaction_Document
(
	FK_Proxy_Transaction asc
)
go