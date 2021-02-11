-- The following queries utilize the "dvdstore" database.

-- 1. All of the films that Nick Stallone has appeared in
-- (30 rows)

select * 
from actor a 
join film_actor fa on a.actor_id = fa.actor_id
join film f on fa.film_id = f.film_id
where a.last_name = 'stallone'

-- 2. All of the films that Rita Reynolds has appeared in
-- (20 rows)

select * 
from actor a 
join film_actor fa on a.actor_id = fa.actor_id
join film f on fa.film_id = f.film_id
where a.last_name = 'reynolds'

-- 3. All of the films that Judy Dean or River Dean have appeared in
-- (46 rows)

select * 
from actor a 
join film_actor fa on a.actor_id = fa.actor_id
join film f on fa.film_id = f.film_id
where a.last_name = 'dean'

-- 4. All of the the ‘Documentary’ films
-- (68 rows)

select * 
from film f
join film_category fc on f.film_id = fc.film_id
join category c on c.category_id = fc.category_id
where c.name = 'documentary'


-- 5. All of the ‘Comedy’ films
-- (58 rows)

select * 
from film f
join film_category fc on f.film_id = fc.film_id
join category c on c.category_id = fc.category_id
where c.name = 'comedy'

-- 6. All of the ‘Children’ films that are rated ‘G’
-- (10 rows)

select * 
from film f
join film_category fc on f.film_id = fc.film_id
join category c on c.category_id = fc.category_id
where c.name = 'family' and f.rating = 'g'

-- 7. All of the ‘Family’ films that are rated ‘G’ and are less than 2 hours in length
-- (3 rows)

select * 
from film f
join film_category fc on f.film_id = fc.film_id
join category c on c.category_id = fc.category_id
where c.name = 'family' and f.rating = 'g'

-- 8. All of the films featuring actor Matthew Leigh that are rated ‘G’
-- (9 rows)

select * 
from actor a 
join film_actor fa on a.actor_id = fa.actor_id
join film f on fa.film_id = f.film_id
where a.last_name = 'leigh' and f.rating = 'g'


-- 9. All of the ‘Sci-Fi’ films released in 2006
-- (61 rows)

select * 
from film f
join film_category fc on f.film_id = fc.film_id
join category c on c.category_id = fc.category_id
where c.name = 'sci-fi' and f.release_year = '2006'

-- 10. All of the ‘Action’ films starring Nick Stallone
-- (2 rows)

select * 
from actor a 
join film_actor fa on a.actor_id = fa.actor_id
join film f on fa.film_id = f.film_id
where a.last_name = 'leigh' and f.rating = 'g'

-- 11. The address of all stores, including street address, city, district, and country
-- (2 rows)

select a.address, ci.city, a.district, co.country
from store s
join address a on s.address_id = a.address_id
join city ci on a.city_id = ci.city_id
join country co on ci.country_id = co.country_id

-- 12. A list of all stores by ID, the store’s street address, and the name of the store’s manager
-- (2 rows)

select s.Store_ID, a.Address, staff.first_name + ' ' + staff.last_name as Manager
from store s
join address a on s.address_id = a.address_id
join city ci on a.city_id = ci.city_id
join staff on s.manager_staff_id = staff.staff_id


-- 13. The first and last name of the top ten customers ranked by number of rentals
-- (#1 should be “ELEANOR HUNT” with 46 rentals, #10 should have 39 rentals)

select top 10 count(p.rental_id) as NumberOfRentals, c.last_name + ', ' + c.first_name as Customer_Name
from customer c
join payment p on c.customer_id = p.customer_id
group by c.last_name, c.first_name 
order by NumberOfRentals desc 


-- 14. The first and last name of the top ten customers ranked by dollars spent
-- (#1 should be “KARL SEAL” with 221.55 spent, #10 should be “ANA BRADLEY” with 174.66 spent)

select top 10 sum(p.amount) as Total_Spent, c.first_name + ' ' + c.last_name as Name
from payment p 
join customer c on c.customer_id = p.customer_id
group by c.last_name, c.first_name
order by sum(p.amount) desc


-- 15. The store ID, street address, total number of rentals, total amount of sales (i.e. payments), and average sale of each store.
-- (NOTE: Keep in mind that while a customer has only one primary store, they may rent from either store.)
-- (Store 1 has 7928 total rentals and Store 2 has 8121 total rentals)

select s.store_id, a.Address, count(r.rental_id) as TotalRentals, sum(p.amount) as TotalSales, avg(p.amount) as AvgSale
from store s
join address a on a.address_id = s.address_id
join inventory i on i.store_id = s.store_id
join rental r on r.inventory_id = i.inventory_id
join payment p on p.rental_id = r.rental_id
group by s.store_id, a.address
order by store_id 

-- 16. The top ten film titles by number of rentals
-- (#1 should be “BUCKET BROTHERHOOD” with 34 rentals and #10 should have 31 rentals)

select top 10 f.title, count(r.rental_date) as NumberOfRentals
from film f
join inventory i on i.film_id = f.film_id
join rental r on r.inventory_id = i.inventory_id
group by f.title
order by NumberOfRentals desc

-- 17. The top five film categories by number of rentals
-- (#1 should be “Sports” with 1179 rentals and #5 should be “Family” with 1096 rentals)

select top 5 c.name as Category, count(r.rental_date) as NumberOfRentals
from film f
join film_category fc on fc.film_id = f.film_id
join category c on fc.category_id = c.category_id
join inventory i on i.film_id = f.film_id
join rental r on r.inventory_id = i.inventory_id
group by c.name
order by NumberOfRentals desc

-- 18. The top five Action film titles by number of rentals
-- (#1 should have 30 rentals and #5 should have 28 rentals)

select top 5 f.title as FilmTitle, count(r.rental_date) as NumberOfRentals
from film f
join film_category fc on fc.film_id = f.film_id
join category c on fc.category_id = c.category_id
join inventory i on i.film_id = f.film_id
join rental r on r.inventory_id = i.inventory_id
where c.name = 'action'
group by f.title
order by NumberOfRentals desc

-- 19. The top 10 actors ranked by number of rentals of films starring that actor
-- (#1 should be “GINA DEGENERES” with 753 rentals and #10 should be “SEAN GUINESS” with 599 rentals)

select top 10 a.first_name + ' ' + a.last_name as Actor, count(r.rental_date) as NumberOfRentals
from film f
join film_actor fa on fa.film_id = f.film_id
join actor a on fa.actor_id = a.actor_id
join inventory i on i.film_id = f.film_id
join rental r on r.inventory_id = i.inventory_id
group by a.last_name, a.first_name, a.actor_id
order by NumberOfRentals desc

-- 20. The top 5 “Comedy” actors ranked by number of rentals of films in the “Comedy” category starring that actor
-- (#1 should have 87 rentals and #5 should have 72 rentals)

select top 5 a.first_name + ' ' + a.last_name as ActorName, count(r.rental_id) as NumberOfMovies
from film f
join film_actor fa on fa.film_id = f.film_id
join actor a on a.actor_id = fa.actor_id
join film_category fc on fc.film_id = f.film_id
join category c on fc.category_id = c.category_id
join inventory i on i.film_id = f.film_id
join rental r on r.inventory_id = i.inventory_id
where c.name = 'comedy'
group by a.first_name, a.last_name, a.actor_id
order by NumberOfMovies desc
