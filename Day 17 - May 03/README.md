# SQL Queries Assignment

This assignment involves writing SQL queries to extract specific information from a database. The database is named 'pubs' [Database](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instpubs.sql) and contains several tables, including 'sales', 'stores', 'titles', 'publishers', 'authors', and 'titleauthor'.



## Queries

1. Print the store id and number of orders for the store

```SELECT s.stor_id, st.stor_name, COUNT(*) AS num_orders
FROM sales s
JOIN stores st ON s.stor_id = st.stor_id
GROUP BY s.stor_id, st.stor_name;
-- --
SELECT stor_id, COUNT(*) AS num_orders
FROM sales
GROUP BY stor_id;
```
2. Print the number of orders for every title
```SELECT t.title, COUNT(s.title_id) AS num_orders
FROM titles t
JOIN sales s ON t.title_id = s.title_id
GROUP BY t.title;   
```
3. Print the publisher name and book name
```SELECT p.pub_name, t.title
FROM publishers p
JOIN titles t ON p.pub_id = t.pub_id;
```
4. Print the author full name for all the authors
```SELECT CONCAT(au_fname, ' ', au_lname) AS full_name
FROM authors;
--(or)
SELECT FORMAT('%s %s', au_fname, au_lname) AS full_name
FROM authors;
```
5. Print the price for every book with tax (price+price*12.36/100)
```SELECT title, price, price + (price * 12.36 / 100) AS 'price(incl.tax)'
FROM titles;
```
6. Print the author name, title name
```SELECT CONCAT(a.au_fname, ' ', a.au_lname) AS author_name, t.title
FROM authors a
JOIN titleauthor ta ON a.au_id = ta.au_id
JOIN titles t ON ta.title_id = t.title_id;

```
7. Print the author name, title name and the publisher name
```SELECT CONCAT(a.au_fname, ' ', a.au_lname) AS author_name, t.title, p.pub_name AS publisher_name
FROM authors a
JOIN titleauthor ta ON a.au_id = ta.au_id
JOIN titles t ON ta.title_id = t.title_id
JOIN publishers p ON t.pub_id = p.pub_id;

```
8. Print the average price of books published by every publisher
```SELECT p.pub_name, AVG(t.price) AS average_price
FROM publishers p
JOIN titles t ON p.pub_id = t.pub_id
GROUP BY p.pub_name;
```
9. Print the books published by 'Marjorie'
```SELECT DISTINCT t.title
FROM titles t
JOIN titleauthor ta ON t.title_id = ta.title_id
JOIN authors a ON ta.au_id = a.au_id
WHERE a.au_fname = 'Marjorie' OR a.au_lname = 'Marjorie';
```
10. Print the order numbers of books published by 'New Moon Books'
```SELECT *, s.ord_num
FROM sales s
JOIN titles t ON s.title_id = t.title_id
JOIN publishers p ON t.pub_id = p.pub_id
WHERE p.pub_name = 'New Moon Books';
```
11. Print the number of orders for every publisher
```SELECT p.pub_name, COUNT(*) AS num_orders
FROM sales s
JOIN titles t ON s.title_id = t.title_id
JOIN publishers p ON t.pub_id = p.pub_id
GROUP BY p.pub_name;
```
12. Print the order number, book name, quantity, price and the total price for all orders
```SELECT s.ord_num, t.title, s.qty, t.price, s.qty * t.price AS "total price"
FROM sales s
JOIN titles t ON s.title_id = t.title_id;
```
13. Print the total order quantity for every book
```SELECT t.title, SUM(s.qty) AS total_quantity
FROM sales s
JOIN titles t ON s.title_id = t.title_id
GROUP BY t.title;
```
14. Print the total order value for every book
```SELECT t.title, SUM(s.qty * t.price) AS 'total order value'
FROM sales s
JOIN titles t ON s.title_id = t.title_id
GROUP BY t.title;
```
15. print the orders that are for the books published by the publisher for which 'Paolo' works for

```
SELECT orders.order_id FROM orders
JOIN titles ON orders.title_id = titles.title_id
JOIN publishers ON titles.pub_id = publishers.pub_id
JOIN authors ON publishers.pub_id = authors.pub_id
WHERE authors.au_fname = 'Paolo';
```


Please refer to the SQLSolutions.sql file for the SQL queries corresponding to each task.
