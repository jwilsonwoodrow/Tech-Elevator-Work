-- Show all cities with all the country information
select * from City
select * from Country

select * 
from City as ci
Join Country as co on ci.CountryCode = co.Code
where co.GovernmentForm like '%monarchy%'

-- List the "city name, country name" and city population, sorted by country and city population descending
 
 select ci.Name + ', ' + co.Name as City_Country, ci.Population 
	 from country co 
	 join City ci on ci.CountryCode = co.Code
	 order by co.name, ci.Population desc


-- List the city name, country name and the percentage of the country's population in the city

select ci.Name, co.Name, (ci.Population * 100.0) / co.Population as PopPercent
	from City ci
	join Country co on co.Code = ci.CountryCode

-- List the country name and its languages

select co.Name, l.LanguageName
	from Country co
	join CountryLanguage cl on co.Code = cl.CountryCode
	join language l on cl.LanguageId = l.LanguageId
	order by co.Name, cl.Percentage desc


-- List the country name and its official language

select Name, LanguageName
	from Country co
	join CountryLanguage cl on co.Code = cl.CountryCode
	join Language l on cl.LanguageId = l.LanguageId
	where cl.IsOfficial = 1
	order by Name

-- Let's display a list of all countries and their capitals.

select co.Name Country, ci.Name Captial
from country co
join city ci on co.Capital = ci.CityId
where Capital is null or Capital is not null


-- Only 232 rows. Where are the other 7 rows?
-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. If we want to show data FROM the left side table everytime, we can use a different join:

-- ********* LEFT JOIN ***********
-- A Left join selects all records from the "left" table and matches them with records from the "right" table if a matching record exists.

select co.Name Country, ci.Name Capital
from country co left outer join city ci on co.Capital = ci.CityId

-- List the countries and their capital cities, but make sure the country is listed even if it has no capital






-- (go play in the dvd store for a while...)



------------------------- More JOINs and UNION -------------------------------------

-- List the cities which are not capitals


-- Can we do this another way?


-- List the city and the country it's a capital of


-- *********** UNION *************

-- How does the population of the largest cities compare with entire countries?
-- Get the name, population, and whether it is a city or a country, order by population descending



-- ***** What if I want to list every city, alongside the capital city for the country this city is in?
-- List the city, its country, and the capital city for that country.



-- ******** SELF-JOIN ***************
-- An Example of joining a table to itself, AND
-- An Example of joining to columns other than the PK

-- List each US city along with the other cities in that state.

