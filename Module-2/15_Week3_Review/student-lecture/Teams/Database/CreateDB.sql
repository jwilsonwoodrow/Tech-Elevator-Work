-- create the tables for the teams database

use master
go

drop database if exists NFLDB
create database NFLDB
go

use NFLDB

-- create team table first

create table Team (
	TeamId int Primary Key Identity,
	Location varchar(25) not null,
	TeamName varchar(25) not null,
	Conference int not null,
	Division int not null,
	Wins int not null default 0,
	Losses int not null default 0,
	Constraint Check_TeamConference check (Conference between 1 and 2),
	Constraint Check_TeamDivision check (Division between 1 and 4)
);

create table Player(
	PlayerId int identity,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	TeamId int null,
	Position varchar(3) not null,
	Birthdate date not null,
	constraint PK_Player Primary Key (PlayerId),
	constraint FK_ Foreign Key (TeamId) References Team(TeamId)
);

