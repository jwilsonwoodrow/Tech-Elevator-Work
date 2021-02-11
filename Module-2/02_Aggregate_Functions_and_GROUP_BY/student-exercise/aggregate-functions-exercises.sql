-- The following queries utilize the "world" database.
-- Write queries for the following problems. 
-- Notes:
--   GNP is expressed in units of one million US Dollars
--   The value immediately after the problem statement is the expected number 
--   of rows that should be returned by the query.

-- 1. The name and state plus population of all cities in states that border Ohio 
-- (i.e. cities located in Pennsylvania, West Virginia, Kentucky, Indiana, and 
-- Michigan).  
-- The name and state should be returned as a single column called 
-- name_and_state and should contain values such as ‘Detroit, Michigan’.  
-- The results should be ordered alphabetically by state name and then by city 
-- name. 
-- (19 rows)

select Name + ',' + District as Name_and_State, Population
from City
where District in ('pennsylvania', 'west virginia', 'kentucky', 'indiana', 'michigan')
order by District, Name

-- 2. The name, country code, and region of all countries in Africa.  The name and
-- country code should be returned as a single column named country_and_code 
-- and should contain values such as ‘Angola (AGO)’ 
-- (58 rows)

select Name + ' (' + Code + ')' as country_and_code, Region
from Country
where Continent = 'africa'

-- 3. The per capita GNP (i.e. GNP multipled by 1000000 then divided by population) of all countries in the 
-- world sorted from highest to lowest. Recall: GNP is express in units of one million US Dollars 
-- (highest per capita GNP in world: 37459.26)

select Name, GNP * 1000000 / Population as PerCapitaGNP
from Country
where Population != 0
order by PerCapitaGNP desc


-- 4. The average life expectancy of countries in South America.
-- (average life expectancy in South America: 70.9461)

select avg(LifeExpectancy) as AvgLifeExpectancy_SA
from Country
where Continent = 'south america'

-- 5. The sum of the population of all cities in California.
-- (total population of all cities in California: 16716706)

select sum(Population) as CaliforniaPopulation
from City
where District = 'california'

-- 6. The sum of the population of all cities in China.
-- (total population of all cities in China: 175953614)

select sum(Population) as ChinaPop
from City
where CountryCode = 'CHN'


-- 7. The maximum population of all countries in the world.
-- (largest country population in world: 1277558000)

select max(Population) as MaxPop
from Country

-- 8. The maximum population of all cities in the world.
-- (largest city population in world: 10500000)

select max(Population) as MaxPop
from City

-- 9. The maximum population of all cities in Australia.
-- (largest city population in Australia: 3276207)

select max(Population) as MaxPop
from City
where CountryCode = 'aus'

-- 10. The minimum population of all countries in the world.
-- (smallest_country_population in world: 50)

select min(Population) as MinPop
from Country
where Population != 0

-- 11. The average population of cities in the United States.
-- (avgerage city population in USA: 286955.3795)

select avg(Cast(Population as numeric (11, 4))) as AvgPop
from city	
where CountryCode = 'usa'


-- 12. The average population of cities in China.
-- (average city population in China: 484720.6997 approx.)

select avg(Population) as AvgPop
from city	
where CountryCode = 'chn'

-- 13. The surface area of each continent ordered from highest to lowest.
-- (largest continental surface area: 31881000, "Asia")

select Continent, sum(SurfaceArea) as SurfaceAreaSum
from Country
group by Continent
order by SurfaceAreaSum


-- 14. The highest population density (population divided by surface area) of all 
-- countries in the world. 
-- (highest population density in world: 26277.7777)

select max(Population / SurfaceArea) as MaxPopDensity
from Country

-- 15. The population density and life expectancy of the top ten countries with the 
-- highest life expectancies in descending order. 
-- (highest life expectancies in world: 83.5, 166.6666, "Andorra")

select top 10 LifeExpectancy, Code
from Country
order by LifeExpectancy desc


select Name, Population / SurfaceArea as PopDensity, LifeExpectancy
from Country
where Code in ('and', 'mac', 'smr', 'jpn', 'sgp', 'aus', 'che', 'swe', 'hkg', 'can')
order by LifeExpectancy desc

-- 16. The difference between the previous and current GNP of all the countries in 
-- the world ordered by the absolute value of the difference. Display both 
-- difference and absolute difference.
-- (smallest difference: 1.00, 1.00, "Ecuador")

select Name, (GNP - GNPOld) as GNPDiff, abs(GNP - GNPOld) as GNPDiffAbs
from country
where (GNP - GNPOld) is not null
order by GNPDiffAbs

-- 17. The average population of cities in each country (hint: use city.countrycode)
-- ordered from highest to lowest.
-- (highest avg population: 4017733.0000, "SGP")

select CountryCode, avg(Population) as AvgPop
from City
group by CountryCode
order by AvgPop desc

-- 18. The count of cities in each state in the USA, ordered by state name.
-- (45 rows)

select District, Count(*) as NumberOfCities
from City
where CountryCode = 'usa'
group by District
order by District asc
	
-- 19. The count of countries on each continent, ordered from highest to lowest.
-- (highest count: 58, "Africa")

select Continent, Count(*) as NumberOfCountries
from Country
group by Continent
order by NumberOfCountries desc
	
-- 20. The count of cities in each country ordered from highest to lowest.
-- (largest number of  cities ib a country: 363, "CHN")

select CountryCode, Count(*) as NumberOfCities
from City
group by CountryCode
order by NumberOfCities desc

-- 21. The population of the largest city in each country ordered from highest to 
-- lowest.
-- (largest city population in world: 10500000, "IND")

select CountryCode, max(Population) as MaxPop
from City
group by CountryCode
order by MaxPop desc

-- 22. The average, minimum, and maximum non-null life expectancy of each continent 
-- ordered from lowest to highest average life expectancy. 
-- (lowest average life expectancy: 52.5719, 37.2, 76.8, "Africa")

select Continent, min(LifeExpectancy) as MinLifeExpectancty, avg(LifeExpectancy) as AvgLifeExpectancy, max(LifeExpectancy) as MaxLifeExpectancy
from Country
where LifeExpectancy is not null
group by Continent
order by AvgLifeExpectancy asc