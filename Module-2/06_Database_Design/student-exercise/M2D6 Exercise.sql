use master

go 

drop database if exists M2D6Exercise

create database M2D6Exercise

use M2D6Exercise

begin transaction

--TABLES

create table Project(
	ProjectNumber int identity,
	ProjectName nvarchar(100) not null,
	StartDate datetime,
	ProjectWorkers int not null,
	constraint PK_Project Primary Key (ProjectNumber),
	constraint Project_Has_Workers check (ProjectWorkers > 0)
)

create table Department(
	DepartmentNumber int identity,
	DepartmentName nvarchar(100) not null,
	DepartmentWorkers int not null,
	constraint PK_Department Primary Key (DepartmentNumber),
	constraint Department_Has_Workers check (DepartmentWorkers > 1)
)

create table Employee(
	EmployeeNumber int identity,     --PK
	JobTitle nvarchar(100) not null,
	LastName nvarchar(50) not null,
	FirstName nvarchar(50) not null,
	Pronouns nvarchar(50),
	DateOfBirth datetime not null,
	DateOfHire datetime not null,
	DepartmentNumber int not null,  --FK
	ProjectNumber int not null,		--FK
	constraint PK_Employee Primary Key (EmployeeNumber),
	constraint FK_EmployeeDepartment Foreign Key(DepartmentNumber) references Department(DepartmentNumber),
	constraint FK_EmployeeProjects Foreign Key(ProjectNumber) references Project(ProjectNumber)
)

--VALUES

insert into Project (ProjectName, StartDate, ProjectWorkers)
values
	('Normal Project Name', '2000-02-12', 1),       --1
	('Edible Concrete', '1992-11-24', 2),           --2
	('Infinite Churro', '1999-01-20', 2),	        --3
	('Medium Sized Space Lazer', '2020-02-11', 3)	--4

insert into Department(DepartmentName, DepartmentWorkers)
values
	('Science Nerds', 4),   --1
	('Management', 2),	    --2
	('Security', 2)         --3

insert into Employee(JobTitle, LastName, FirstName, Pronouns, DateOfBirth, DateOfHire, DepartmentNumber, ProjectNumber)
values
	('Candy Scientist', 'Wonka', 'William',  'He/Him', '2000-02-02', '2000-02-02', 1, 2),
	('Science Guy', 'Nye', 'Billiam', 'He/Him', '2000-02-02', '2000-02-02', 1, 1),
	('Professor', 'Farnsworth', 'Hubert', 'He/Him','2000-02-02', '2000-02-02', 1, 4),
	('"Doctor"', 'Krieger', 'Algernop', 'He/Him', '2000-02-02', '2000-02-02', 1, 3),
	('Overseer', 'Gall', 'Cho', 'He/Him/He/Him', '2000-02-02', '2000-02-02', 2, 3), 
	('Director', 'Archer', 'Mallory', 'She/Her', '2000-02-02', '2000-02-02', 2, 4),
	('Master Rogue', 'Sanguinar', 'Valeera', 'She/Her', '2000-02-02', '2000-02-02', 3, 4),
	('Archmage', 'Proudmoore', 'Jaina', 'She/Her', '2000-02-02', '2000-02-02', 3, 2)

commit transaction 

/*
select e.JobTitle, e.FirstName, E.LastName, d.DepartmentName, p.ProjectName 
from Employee e
join Project p on p.ProjectNumber = e.ProjectNumber
join Department d on d.DepartmentNumber = e.DepartmentNumber
*/