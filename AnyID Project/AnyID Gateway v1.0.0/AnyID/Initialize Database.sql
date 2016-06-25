insert into Role(Code, EffectiveFrom, EffectiveTo)
values ('Maker', '2016-01-01', '2800-12-31')
,('Approver', '2016-01-01', '2800-12-31')
,('Viewer', '2016-01-01', '2800-12-31');

insert into Users(Discriminator, LoginName, BranchCode, EMailAddress, Name)
values(1, 'supoj', '0001', 'supojsu@yahoo.com', 'Supoj Sutanthavibul');
