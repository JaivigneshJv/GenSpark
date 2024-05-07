-- 1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name

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

select * from sales
--samples
EXEC proc_GetBooksByAuthor @FirstName = 'Johnson';
EXEC proc_GetBooksByAuthor @FirstName = 'Marjorie';


-- 2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.

ALTER PROCEDURE proc_GetTitlesSoldByEmployee
    @FirstName VARCHAR(20)
AS
BEGIN
    SELECT t.title, s.qty, t.price, s.qty * t.price AS cost
    FROM sales s
    INNER JOIN titles t ON s.title_id = t.title_id
    INNER JOIN employee e ON t.pub_id = e.pub_id
    WHERE e.fname = @FirstName;
END

EXEC proc_GetTitlesSoldByEmployee @FirstName = 'Annette';

--(or)

CREATE PROCEDURE proc_GetTitlesSoldByEmployeeALT
    @Name VARCHAR(20)
AS
BEGIN
    SELECT t.title, s.qty, t.price, s.qty * t.price AS cost
    FROM sales s
    INNER JOIN titles t ON s.title_id = t.title_id
    INNER JOIN employee e ON t.pub_id = e.pub_id
    WHERE e.fname LIKE '%' + @Name + '%' OR e.lname LIKE '%' + @Name + '%';
END
EXEC proc_GetTitlesSoldByEmployeeALT @Name = 'Ar';

-- 3) Create a query that will print all names from authors and employees
SELECT au_fname AS 'First Name', au_lname AS 'Last Name' FROM authors
union
SELECT fname, lname  FROM employee;



-- 4) Create a  query that will float the data from sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
SELECT TOP 5 t.title AS Title, p.pub_name AS Publisher, CONCAT(a.au_fname, ' ', a.au_lname) AS AuthorFullName,
    s.qty AS QuantityOrdered, t.price AS Price
FROM sales s
INNER JOIN titles t ON s.title_id = t.title_id
INNER JOIN publishers p ON t.pub_id = p.pub_id
INNER JOIN titleauthor ta ON t.title_id = ta.title_id
INNER JOIN authors a ON ta.au_id = a.au_id







-- GRANT AND REVOKE

SELECT * FROM sys.database_principals
SELECT * FROM sys.fn_my_permissions(NULL, 'DATABASE');


-- GRANT AND REVOKE

-- Role for tester
CREATE ROLE TesterRole;
CREATE ROLE User1;
CREATE ROLE User2;
CREATE ROLE User3;


EXEC sp_setapprole 'User3','sysname';

GRANT IMPERSONATE ON USER::User3 TO YourCurrentLogin;


-- Execute the following as a database owner
GRANT EXECUTE ON proc_GetBooksByAuthor TO TesterRole WITH GRANT OPTION;

EXEC sp_addrolemember TesterRole, User1;

-- The following fails because User2 does not have the permission as the User1
GRANT EXECUTE ON proc_GetBooksByAuthor TO User3;

GRANT EXECUTE ON proc_GetBooksByAuthor TO User2 AS TesterRole;

EXECUTE AS USER = 'User3';


-- Check permissions granted to the User3 role
SELECT 
    dp.class_desc,
    OBJECT_NAME(dp.major_id) AS object_name,
    dp.permission_name,
    dp.state_desc,
    ISNULL(dpr.name, 'N/A') AS grantee_name
FROM 
    sys.database_permissions dp
LEFT JOIN 
    sys.database_principals dpr ON dp.grantee_principal_id = dpr.principal_id
WHERE 
    dpr.name = 'User1';

EXECUTE AS ROLE = 'User2';
EXEC proc_GetBooksByAuthor @FirstName = 'Johnson';

CREATE LOGIN jv   
    WITH PASSWORD = 'password';  
GO  

create user jv for login jv
GRANT SELECT ON dbo.authors TO jv;
GRANT EXECUTE ON proc_GetBooksByAuthor TO jv WITH GRANT OPTION;


EXEC proc_GetBooksByAuthor @FirstName = 'Marjorie';


SELECT * FROM sys.database_principals

-- Create two roles 'role1' and 'role2'
CREATE ROLE role1
CREATE ROLE role2

-- Create a user and assign it to 'role1'
CREATE USER user1 WITHOUT LOGIN
ALTER ROLE role1 ADD MEMBER user1
CREATE USER user2 WITHOUT LOGIN
ALTER ROLE role2 ADD MEMBER user2


-- Grant 'SELECT' permission on a sample table to 'role1'
CREATE TABLE SampleTable (id INT, name VARCHAR(50))
INSERT INTO SampleTable VALUES (1, 'Sample Data')
GRANT SELECT ON SampleTable TO role1

GRANT EXECUTE ON proc_GetBooksByAuthor TO role1 WITH GRANT OPTION;

--Demonstrate granting and revoking permissions from 'role1' perspective
EXECUTE AS USER = 'user1'
EXEC proc_GetBooksByAuthor @FirstName = 'Marjorie'; -- This should work
REVERT

EXECUTE AS USER = 'user2'
EXEC proc_GetBooksByAuthor @FirstName = 'Marjorie'; -- This shouldn't work