-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.

insert into actor(first_name, last_name)
values 
	('Hampton', 'Avenue'),
	('Lisa','Byway')

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.

insert into film(title, description, release_year, language_id, length)
values
	('Euclidean PI'
	,'The epic story of Euclid as a pizza delivery boy in ancient Greece'
	, 2008
	, (select language_id from language where Name = 'english' )
	, 198)

select * from film where title = 'euclidean pi'

-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.

insert into film_actor (film_id, actor_id)
values 
	((select film_id from film where title = 'euclidean pi'), (select actor_id from actor where actor.first_name = 'lisa' and actor.last_name = 'byway')),
	((select film_id from film where title = 'euclidean pi'), (select actor_id from actor where actor.first_name = 'hampton' and actor.last_name = 'avenue'))


-- 4. Add Mathmagical to the category table.

insert into category(name)
values
	('Mathemagical')

select * from category
-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"

insert into film_category(film_id, category_id)
values
	((select film_id from film where title = 'euclidean pi'), (select category_id from category where name = 'Mathemagical')),
	((select film_id from film where title = 'egg igby'), (select category_id from category where name = 'Mathemagical')),
	((select film_id from film where title = 'karate moon'), (select category_id from category where name = 'Mathemagical')),
	((select film_id from film where title = 'random go'), (select category_id from category where name = 'Mathemagical')),
	((select film_id from film where title = 'young language'), (select category_id from category where name = 'Mathemagical'))

select * 
from film f
join film_category fc on f.film_id = fc.film_id
join category c on fc.category_id = c.category_id	
where c.name = 'Mathemagical'

-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)

update film
set film.rating = 'G'
from film f
join film_category fc on f.film_id = fc.film_id
join category c on fc.category_id = c.category_id	
where c.name = 'mathemagical'

-- 7. Add a copy of "Euclidean PI" to all the stores.

insert into inventory(film_id, store_id)
values
	((select film_id from film where title = 'euclidean pi'), 1),
	((select film_id from film where title = 'euclidean pi'), 2)  
	
	--seems smelly, what if there were 100s of stores?

	--[advanced technique]

insert into inventory (film_id, store_id)
	select 
		(select film_id from film where title = 'euclidean pi'), store_id
		from store
	

-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.

delete from film where title = 'euclidean pi'


-- (Did it succeed? Why?)
-- <No, it conflicted with a reference constraint. The ID cant be deleted because other tables rely on it>

-- 9. Delete Mathmagical from the category table.

delete from category where name = 'mathemagical'

-- (Did it succeed? Why?)
-- <No, same reason as the last time>

-- 10. Delete all links to Mathmagical in the film_category tale.

delete from film_category where category_id = (select category_id from category where name = 'mathemagical')

-- (Did it succeed? Why?)
-- <Yes, maybe because this table is not referenced by other tables>

-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".

delete from category where name = 'mathemagical'
delete from film where title = 'euclidean pi'

-- (Did either deletes succeed? Why?)
-- <first delete works now that the IDs are not referenced by film_category>

-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.



select * from INFORMATION_SCHEMA.TABLES
select * from INFORMATION_SCHEMA.COLUMNS
SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS