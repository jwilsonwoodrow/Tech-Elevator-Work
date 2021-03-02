USE assessment;
GO

-- Select all the columns from communities from rows that are live (note that "live" is a column in the communities table)
select * from communities
where live = 1

select * from properties
-- Select the name and address from properties where the latitude is less than 0 and were created in the month of June 2019
select name, address from properties
where latitude < 0 and Month(created) = 6 

-- Select the name, latitude, and longitude from communities ordered by the created date, oldest first
select name, latitude, longitude from communities
order by created  

-- Select created and a count of all the properties created on each date
select created, count(id) as Count from properties
group by created

-- Select a community name, live and the address of each property for every community created on or after Oct. 1st, 2019
select c.Name, live, address from communities c
join properties p on p.community_id = c.id
where c.created > '2019/8/1'
