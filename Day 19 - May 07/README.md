# SQL Stored Procedures and Queries

This document contains SQL stored procedures and queries for a book sales database. The database includes tables for authors, titles, sales, publishers, and employees.

## Questions

1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name

2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.

3) Create a query that will print all names from authors and employees

4) Create a  query that will float the data from sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders, print first 5 orders after sorting them based on the price of order

5) Please learn grant and revoke (refer SQL file)



## Stored Procedures





1. **proc_GetBooksByAuthor**: This stored procedure takes an author's first name as input and returns all the books published by that author along with the publisher's name.

```sql
CREATE PROCEDURE proc_GetBooksByAuthor(@FirstName VARCHAR(50))
AS
BEGIN
    SELECT t.title AS 'Book Title', p.pub_name AS 'Publisher'
    FROM titles t
    INNER JOIN titleauthor ta ON t.title_id = ta.title_id
    INNER JOIN authors a ON ta.au_id = a.au_id
    INNER JOIN publishers p ON t.pub_id = p.pub_id
    WHERE a.au_fname = @FirstName;
END

```
2. **proc_GetTitlesSoldByEmployee**: This stored procedure takes an employee's first name as input and returns all the titles sold by that employee, along with the quantity, price, and total cost.

```sql
CREATE PROCEDURE proc_GetTitlesSoldByEmployee
    @FirstName VARCHAR(20)
AS
BEGIN
    SELECT t.title, s.qty, t.price, s.qty * t.price AS cost
    FROM sales s
    INNER JOIN titles t ON s.title_id = t.title_id
    INNER JOIN employee e ON t.pub_id = e.pub_id
    WHERE e.fname = @FirstName;
END
```

## Queries

1. This query prints all names from authors and employees.

```sql
SELECT au_fname AS 'First Name', au_lname AS 'Last Name' FROM authors
union
SELECT fname, lname  FROM employee;
```
2.This query joins data from the sales, titles, publisher, and authors tables to print the title name, publisher's name, author's full name, quantity ordered, and price for all orders.

```sql
SELECT TOP 5 t.title AS Title, p.pub_name AS Publisher, CONCAT(a.au_fname, ' ', a.au_lname) AS AuthorFullName,
    s.qty AS QuantityOrdered, t.price AS Price
FROM sales s
INNER JOIN titles t ON s.title_id = t.title_id
INNER JOIN publishers p ON t.pub_id = p.pub_id
INNER JOIN titleauthor ta ON t.title_id = ta.title_id
INNER JOIN authors a ON ta.au_id = a.au_id;
```