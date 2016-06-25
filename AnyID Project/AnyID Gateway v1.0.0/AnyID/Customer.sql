CREATE table [dbo].TB_T_Customer
(
	PK_Customer bigint NOT NULL identity(1,1) PRIMARY KEY,
	Discriminator tinyint,
    Birth_Date datetime2,
	CIS_ID nvarchar(10),
	Customer_RM nvarchar(20),
    Customer_Segment nvarchar(20),
	Customer_Type nvarchar(40),
	Email_Address nvarchar(20),
	FATCA nvarchar(20),
    KYC_Level nvarchar(12),
	First_Name nvarchar(40),
	Gender nvarchar(40),
	Home_Phone_No nvarchar(20),
	ID_No nvarchar(20),
	ID_Type tinyint,
	Last_Name nvarchar(40),
    Marital_Status nvarchar(8),
	Mobile_Phone_No nvarchar(20),
	Office_Phone_No nvarchar(20),
	Sanction nchar(12),
    EmailAddress datetime2,
	Status tinyint
)
go

CREATE INDEX IDX_Customer_1 ON [dbo].TB_T_Customer (CIS_ID)
go

CREATE INDEX IDX_Customer_2 ON [dbo].TB_T_Customer (First_Name)
go

CREATE INDEX IDX_Customer_3 ON [dbo].TB_T_Customer (Last_Name)
go

CREATE INDEX IDX_Customer_4 ON [dbo].TB_T_Customer (ID_No)
go

