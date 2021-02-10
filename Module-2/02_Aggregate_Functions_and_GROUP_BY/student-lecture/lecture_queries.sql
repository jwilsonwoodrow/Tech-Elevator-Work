-- SELECT ... FROM
-- Selecting the names for all countries

select Name from Country 

-- Selecting the name and population of all countries

SELECT Name, Population FROM Country

-- Selecting all columns from the city table

SELECT * FROM City --convention: sql statements in all caps

-- SELECT ... FROM ... WHERE
-- Selecting the cities in Ohio

SELECT * 
FROM City 
WHERE District = 'Ohio' 

-- Selecting countries that gained independence in the year 1776

select *
from Country
where IndepYear = 1776

-- Selecting countries not in Asia

select *
from Country
where Continent != 'asia'


-- Selecting countries that do not have an independence year

select *
from country 
where IndepYear is null

-- Selecting countries that do have an independence year

select *
from country 
where IndepYear is not null

-- Selecting countries that have a population greater than 5 million



-- SELECT ... FROM ... WHERE ... AND/OR
-- Selecting cities in Ohio and Population greater than 400,000

-- Selecting country names on the continent North America or South America




-- SELECTING DATA w/arithmetic
-- Selecting the population, life expectancy, and population per area
--	note the use of the 'as' keyword



