-- ********* INNER JOIN ***********

-- Let's find out who made payment 16666:



-- Ok, that gives us a customer_id, but not the name. We can use the customer_id to get the name FROM the customer table

select *
from payment p
join customer c on c.customer_id = p.customer_id
where p.payment_id = 16666

-- We can see that the * pulls back everything from both tables. We just want everything from payment and then the first and last name of the customer:


select p.*, c.first_name, c.last_name
from payment p
join customer c on c.customer_id = p.customer_id
where p.payment_id = 16666

-- But when did they return the rental? Where would that data come from? From the rental table, so let’s join that.

select p.*, c.first_name, c.last_name, r.return_date
from payment p
join customer c on p.customer_id = c.customer_id
join rental r on p.rental_id = r.rental_id
where p.payment_id = 16666

-- What did they rent? Film id can be gotten through inventory.

-- What if we wanted to know who acted in that film?

-- What if we wanted a list of all the films and their categories ordered by film title

-- Show all the 'Comedy' films ordered by film title

-- Finally, let's count the number of films under each category

-- (There aren't any great examples of left joins in the "dvdstore" database, so go back to the "world" queries)

-- *********** UNION *************

-- Gathers a list of all first names used by actors and customers
-- By default removes duplicates

-- Gather the list, but this time note the source table with 'A' for actor and 'C' for customer
