-- INSERT
-- 1. Add a city to the City table, district 'Ohio'

insert into City(Name, CountryCode, District, Population)
	values('Richfield', 'USA', 'Ohio', 12000)

-- 1a. What is the @@Identity? (4081)

select @@IDENTITY

-- 2. Add 2 more cities to Ohio using one insert statement

insert into City(Name, CountryCode, District, Population)
	values
	('Cleveland Heights', 'USA', 'Ohio', 43000),
	('Lakewood', 'USA', 'Ohio', 50000)

-- 2a. What is the @@Identity? (4083)

select @@IDENTITY

-- 0. Add Klingon to the Language table

insert Language (LanguageName)
values ('Klingon')

-- 0a. What is the @@Identity? (458)

select @@IDENTITY


-- 1. Add Klingon as a spoken language in the USA
insert CountryLanguage(CountryCode, LanguageId, IsOfficial, Percentage)
values('USA', 458, 0, 2.00) 

-- 2. Add Klingon as a spoken language in Great Britain


-- UPDATE

-- 0. Update the population of Cleveland to 2020 values (379,233)
-- 1. Update the capital of the USA to Houston
-- 2. Update the capital of the USA to Washington DC and the head of state


-- DELETE

-- 0. Delete the newly added Ohio cities
-- 1. Delete English as a spoken language in the USA
-- 2. Delete all occurrences of the Klingon language 


-- REFERENTIAL INTEGRITY

-- 1. Add a city to the City table in the country 'ZZZ'

-- 1. Try just adding Elvish to the country language table.

-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?

-- 3. Try deleting the country USA. What happens?


-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA

-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'


-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.

-- 2. Try updating all of the cities to be in the USA and roll it back

-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.