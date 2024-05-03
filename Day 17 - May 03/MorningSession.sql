SELECT * FROM Products WHERE SupplierID = (SELECT SupplierID FROM Suppliers WHERE CompanyName = 'Tokyo Traders');

Select * from Categories

SELECT * FROM Products 
WHERE CategoryID IN (
    SELECT CategoryID 
    FROM Categories 
    WHERE Description LIKE '%ea%'
);

select productID,Quantity from [Order Details] where OrderID in(
select OrderID from Orders where CustomerID in 
(select CustomerID from customers where Country='France'))


select ProductID,ProductName from Products where UnitPrice>
(select avg(UnitPrice) from Products)

select * from Products p1
where UnitPrice = (select max(UnitPrice) 
from Products p2 where p1.CategoryID=p2.CategoryID)


--cross join
select * from Categories,customers

--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)

select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and teh productname
select CategoryId,ProductName from products

--Get teh categoryname and the productname
select categoryName,ProductName from Categories

--Get the products that are priced above the average price of all the products
select ProductID, ProductName, UnitPrice
from Products where 
UnitPrice>(select AVG(UnitPrice) from Products)

select * from Orders

--Select the lastet order by every employee
--select * from Orders where orderdate in 
--(select distinct Max(OrderDate) from orders group by Employeeid)
select * from orders o1
where orderdate = 
(select max(orderdate) from orders o2
where o2.EmployeeID = o1.employeeid)
order by o1.EmployeeID

--Select the maximum priced product in every category
select * from products p1 where UnitPrice =
(select max(UnitPrice) from Products p2 where p1.CategoryID = p2.CategoryID)

select * from orders

--select the order number for the maximum fright paid by every customer
select * from orders o1 
where Freight=
(select max(Freight) from Orders o2 where o1.EmployeeID=o2.EmployeeID) 
order by o1.EmployeeID

--cross join
select * from Categories,customers

--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)

select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and teh productname
select CategoryId,ProductName from products

--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID

select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID

select categoryName,ProductName from Categories, Products 
where Categories.CategoryID = Products.CategoryID

--Get the Supplier company name, contact person name, Product name and the stock ordered
select companyname,ContactName,ProductName,UnitsOnOrder
 from Suppliers s join Products p
 on s.SupplierID = p.SupplierID
 order by UnitsOnOrder desc

select  o.OrderID, c.CustomerID,c.ContactName, o.Freight
from Orders o JOIN Customers c 
ON o.CustomerID = c.CustomerID
order by o.Freight desc;

select c.ContactName 'Customer Name',
p.ProductName 'Product Name',
od.Quantity 'Quantity Sold',
o.Freight,
((p.UnitPrice*od.Quantity)+o.Freight) 'Total Price'
from Products p 
join [Order Details] od on p.ProductID=od.ProductID 
join Orders o on o.OrderID=od.OrderID
join Customers c on c.CustomerID = o.CustomerID



select c.ContactName, o.OrderId, count(*) as "No. of Products per Order"
from customers c join orders o on c.customerid = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
group by c.ContactName,o.OrderID

select e.FirstName , c.ContactName , p.ProductName, sum(od.UnitPrice* od.Quantity) as totalPrict from 
Employees e join Orders o on o.EmployeeID=e.EmployeeID 
join Customers c on c.CustomerID= o.CustomerID join 
[Order Details] od on o.OrderID=od.OrderID join 
Products p on p.ProductID=od.ProductID group by p.ProductName, c.ContactName,e.FirstName;