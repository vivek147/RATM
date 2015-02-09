create table Bank_Detail(Card_Id  bigint not null primary key, Card_Type nvarchar(60) not null, 
                            Cvv bigint not null ,UserName nvarchar(80),Months int not null , Years int not null ,BankName_ID int not null
                             foreign key(BankName_ID) references Bank_Name(Id) )
                           
                             drop table Bank_Detail
                             
Insert into Bank_Name values('ICICI')
Insert into Bank_Name values('SBI')
Insert into Bank_Name values('AXIS')
Insert into Bank_Name values('HDFC')

Insert into Bank_Detail values(5949636323938989,'CREDIT',814,'vivek joshi',12,2018,1)
Insert into Bank_Detail values(5949636328938989,'DEBIT',814,'vivek joshi',1,2019,1)
Insert into Bank_Detail values(1449446143934899,'DEBIT',841,'vivek joshi',12,2018,2)
Insert into Bank_Detail values(94494465148934899,'DEBIT',802,'vivek joshi',11,2018,3)
Insert into Bank_Detail values(5949636623938989,'CREDIT',804,'vivek joshi',10,2019,4)
Insert into Bank_Detail values(5949665428938989,'DEBIT',804,'vivek joshi',7,2014,3)
Insert into Bank_Detail values(14677456143934899,'DEBIT',801,'vivek joshi',7,2017,4)
Insert into Bank_Detail values(9449445658934899,'DEBIT',802,'vivek joshi',6,2018,4)

select BankName,Card_Type,Card_Id,Cvv from Bank_Name join Bank_Detail on Bank_Name.Id = 1
select BankName,Card_Type,Card_Id,Cvv from Bank_Name join Bank_Detail on Bank_Name.Id =  Bank_Detail.BankName_ID and Bank_Detail.Card_Type = 'DEBIT'

select COUNT(Card_Type) as CN from Bank_Detail inner join Bank_Name on  Bank_Detail.Card_Type = 'CREDIT' and Bank_Name.Id = 3 

select Card_Type,Card_Id,Cvv from Bank_Detail where BankName_ID = 2 and Card_Type ='DEBIT'

select * from Bank_Name
select * from Bank_Detail
delete from Bank_Detail

create table Registration (Email  nvarchar(60) not null, Password nvarchar(60) not null)

select * from Registration