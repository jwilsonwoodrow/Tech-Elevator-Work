
--List the cities that are in the 5 smallest countries

		--find the 5 smallest countries

select top 5 *
from Country
order by SurfaceArea asc  --VAT, MCO, GIB, TKL, CCK

		--then find cities in those countries

select *
from city
where City.CountryCode in ('vat', 'mco', 'gib', 'tkl', 'cck')

		--or use a subquery 

select *
from City
where CountryCode in (select top 5 Code from Country order by SurfaceArea asc)

	--can we use a join?

select top 5 *
from City ci
join Country co on co.Code = ci.CountryCode
order by SurfaceArea

	--not really

-- *********** TRANSACTIONS *************

--swap cities between USA and GBR 


-- *********** UNION *************
-- I wonder how the world's largest cities stack up against entire countries?
-- Get the name, population, and whether it is a city or a country, order by population descending

Select Name, Population, '' as 'Is City?' from Country
--order by Population desc
union
Select Name, Population, 'Yes' from City
order by Population desc

-- *********** SELF-JOINS *************
/***
***** List every city, alongside the capital city for the country this city is in.
e.g.:
Los Angeles		USA		Washington
New York		USA		Washington
Barcelona		ESP		Madrid
Madrid			ESP		Madrid
***/ 
-- List the city, its country, and the capital city for that country.



-- ******** SELF-JOIN ***************
-- An Example of joining a table to itself, AND
-- An Example of joining to columns other than the PK

-- List each US city along with the other cities in that state.
select GETDATE()