use NorthWind

select * from Products

select ProductName, QuantityPerUnit from Products

select ProductName Name_Of_Product, QuantityPerUnit as Quantity_Per_Unit from Products

select ProductName 'Name Of Product', QuantityPerUnit as Quantity_Per_Unit from Products

select * from products where UnitPrice>10

--Select all the products that are out of stock
select * from Products where UnitsInStock=0

--select the products that will no more be stocked
select * from products where Discontinued =1

--Select Products that will be in clearance
select * from products where Discontinued =1 and UnitsInStock>0



--select products that are in teh range of 10 to 30
select * from products where unitprice>10 and unitprice<30
select * from products where unitprice between 10 and 30
--(or)
select * from products where unitprice>=10 and unitprice<=30

select ProductName, UnitPrice Price, UnitsInStock, (UnitPrice*UnitsInStock) "Amount worth"
from products

select ProductName, UnitPrice Price, UnitsInStock, (UnitPrice*UnitsInStock) as "Amount worth"
from products where CategoryID =3

select * from products where QuantityPerUnit like '%boxes%'
select * from products where QuantityPerUnit like '__ Boxes'

--Stock of products in category 3

select sum(UnitsInStock) "Stock of products in category 3"
from Products where CategoryID =3

--Avreage price of products supplied by supplier 2
SELECT AVG(UnitPrice) AS Average_Price FROM Products WHERE SupplierID = 2;

--Worth of products in order
SELECT * ,(UnitPrice * UnitsInStock) "Worth"
FROM Products ORDER BY Worth DESC;

--Get the Average price of products supplied by every supplier
SELECT SupplierID, AVG(UnitPrice) AS AveragePrice
FROM Products
GROUP BY SupplierID;


select supplierID,
count(ProductName) NO_Of_Products,
sum(unitsinstock) 'Items in stock',
avg(unitprice) 'Average PRice'
from products
group by supplierID

select supplierID,
count(ProductName) Number_Of_Products,
sum(unitsinstock) 'Items in stock',
avg(unitprice) 'Average PRice'
from products
group by supplierID

--select sum(UnitPrice),ProductName from products--Non-Sense query

--get teh average price for every supplier for evry category of product
select SupplierId, CategoryId, Avg(UnitPrice) Average_Price
from Products
group by CategoryId,SupplierId


select SupplierId, CategoryId, Avg(UnitPrice) Average_Price
from Products
group by CategoryId,SupplierId
having avg(UnitPrice)>15


SELECT CategoryID, SUM(UnitsInStock) AS TotalStock
FROM Products
GROUP BY CategoryID
HAVING COUNT(ProductID) > 10;


--Get the products sorted by the price. Fetch only those products that will be discontiued
SELECT *
FROM Products
WHERE Discontinued = 1
ORDER BY UnitPrice;


--sort by category id and fetch the sum of unit price of products that will not be discontinued
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
order by categoryId

--sort by category id and fetch the sum of unit price of products that will not be discontinued
--select only if the category is having products total price greater than 200
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
Having sum(UnitPrice)>200
order by categoryId
--(or)
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId