-- use master so that we are not 'sitting' in the art database
use master 

go 
--drop (clear) the database if it already exists
drop database if exists ArtGallery

--create new empty database
create database ArtGallery

--place ourselves in the new database 
use ArtGallery

--start transaction so that it's all or nothing

begin transaction 

/********************************* Create Tables ********************************/
--first create tables with no foreign key 

--address
create table Address(
	AddressID int identity(0, 1),
	Street nvarchar(100),
	City nvarchar(50),
	State nvarchar(50),
	PostalCode nvarchar(10),
	constraint PK_Address Primary Key (AddressID)
)
--customer
create table Customer(
	CustomerID int identity(0,1),
	CustomerName nvarchar(100) not null,
	Phone varchar (20),
	constraint PK_Customer Primary Key (CustomerID)
)

--artist
create table Artist (
	ArtistID int Identity(0, 1), --0 is starting number, 1 is the increment
	Name nvarchar(50) not null, --nvarchar is universal, varchar for american english letters & numbers ... no special symbols
	AddressID int null,
	Phone varchar(20),
	constraint PK_Artist Primary Key(ArtistID),
	constraint PK_Artist_Adress Foreign Key(AddressID) References Address(AddressID)
)

--painting 
create table Painting(
	PaintingID int identity(0,1),
	ArtistID int not null,
	Title nvarchar(100) not null,
	AskingPrice money null,
	constraint PK_Painting Primary Key (PaintingID),
	constraint FK_Painting_Artist Foreign Key (ArtistID) References Artist(ArtistID)
)

--transaction
create table ArtTransaction(
	ArtTransactionID int identity(0, 1),
	TransactionType varchar(8) not null,
	CustomerID int not null,
	PaintingID int not null,
	TransactionDate datetime not null default(getdate()),
	Price money not null,
	Constraint PK_ArtTransaction Primary Key (ArtTransactionID),
	constraint FK_ArtTransaction_Customer Foreign Key (CustomerID) References Customer(CustomerID),
	constraint FK_ArtTransaction_Painting Foreign Key (PaintingID) References Painting(PaintingID),
	constraint CK_ArtTransaction_TransactionType check (TransactionType in('sale', 'purchase'))
)

--CustomerAddress
create table CustomerAddress(
	CustomerID int,
	AddressID int
	constraint PK_CustomerAdress Primary Key(CustomerID, AddressID)
	constraint FK_CustomerAdress_Customer Foreign Key (CustomerID) References Customer(CustomerID),
	constraint FK_CustomerAdress_Address Foreign Key (AddressID) References Address(AddressID)
)

--end transaction
commit transaction