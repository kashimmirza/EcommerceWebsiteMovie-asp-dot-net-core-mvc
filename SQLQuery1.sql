
-- Create the database
CREATE DATABASE Northwind;

-- Use the database
USE Northwind;

-- Create the Categories table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(255) NOT NULL,
    Description TEXT
);

-- Insert data into the Categories table
INSERT INTO Categories (CategoryID, CategoryName, Description)
VALUES
(1, 'Beverages', 'Soft drinks, coffees, teas, beers, and ales'),
(2, 'Condiments', 'Sweet and savory sauces, relishes, spreads, and seasonings'),
(3, 'Confections', 'Desserts, candies, and sweet breads');

-- Create the Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(255) NOT NULL,
    ContactName VARCHAR(255),
    Address VARCHAR(255),
    City VARCHAR(255),
    PostalCode VARCHAR(20),
    Country VARCHAR(255)
);

-- Insert data into the Customers table
INSERT INTO Customers (CustomerID, CustomerName, ContactName, Address, City, PostalCode, Country)
VALUES
(1, 'Alfreds Futterkiste', 'Maria Anders', 'Obere Str. 57', 'Berlin', '12209', 'Germany'),
(2, 'Ana Trujillo Emparedados y helados', 'Ana Trujillo', 'Avda. de la Constitución 2222', 'México D.F.', '05021', 'Mexico'),
(3, 'Antonio Moreno Taquería', 'Antonio Moreno', 'Mataderos 2312', 'México D.F.', '05023', 'Mexico'),
(4, 'Around the Horn', 'Thomas Hardy', '120 Hanover Sq.', 'London', 'WA1 1DP', 'UK'),
(5, 'Berglunds snabbköp', 'Christina Berglund', 'Berguvsvägen 8', 'Luleå', 'S-958 22', 'Sweden');

-- Create the Employees table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    LastName VARCHAR(255),
    FirstName VARCHAR(255),
    BirthDate DATE,
    Photo TEXT,
    Notes TEXT
);

-- Insert data into the Employees table
INSERT INTO Employees (EmployeeID, LastName, FirstName, BirthDate, Photo, Notes)
VALUES
(1, 'Davolio', 'Nancy', '1948-12-08', 'employee1.jpg', 'Sales Representative'),
(2, 'Fuller', 'Andrew', '1952-02-19', 'employee2.jpg', 'Vice President, Sales'),
(3, 'Leverling', 'Janet', '1963-08-30', 'employee3.jpg', 'Sales Representative');

-- Create the Shippers table
CREATE TABLE Shippers (
    ShipperID INT PRIMARY KEY,
    ShipperName VARCHAR(255),
    Phone VARCHAR(20)
);

-- Insert data into the Shippers table
INSERT INTO Shippers (ShipperID, ShipperName, Phone)
VALUES
(1, 'Speedy Express', '(503) 555-9831'),
(2, 'United Package', '(503) 555-3199'),
(3, 'Federal Shipping', '(503) 555-9931');

-- Create the Suppliers table
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY,
    SupplierName VARCHAR(255),
    ContactName VARCHAR(255),
    Address VARCHAR(255),
    City VARCHAR(255),
    PostalCode VARCHAR(20),
    Country VARCHAR(255),
    Phone VARCHAR(20)
);

-- Insert data into the Suppliers table
INSERT INTO Suppliers (SupplierID, SupplierName, ContactName, Address, City, PostalCode, Country, Phone)
VALUES
(1, 'Exotic Liquids', 'Charlotte Cooper', '49 Gilbert St.', 'London', 'EC1 4SD', 'UK', '(171) 555-2222'),
(2, 'New Orleans Cajun Delights', 'Shelley Burke', 'P.O. Box 78934', 'New Orleans', '70117', 'USA', '(100) 555-4822'),
(3, 'Grandma Kelly''s Homestead', 'Regina Murphy', '707 Oxford Rd.', 'Ann Arbor', '48104', 'USA', '(313) 555-5735');

-- Create the Products table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(255) NOT NULL,
    SupplierID INT,
    CategoryID INT,
    Unit VARCHAR(255),
    Price DECIMAL(10, 2),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

-- Insert data into the Products table
INSERT INTO Products (ProductID, ProductName, SupplierID, CategoryID, Unit, Price)
VALUES
(1, 'Chai', 1, 1, '10 boxes x 20 bags', 18.00),
(2, 'Chang', 1, 1, '24 - 12 oz bottles', 19.00),
(3, 'Aniseed Syrup', 1, 2, '12 - 550 ml bottles', 10.00);

-- Create the Orders table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    EmployeeID INT,
    OrderDate DATE,
    ShipperID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY (ShipperID) REFERENCES Shippers(ShipperID)
);

-- Insert data into the Orders table
INSERT INTO Orders (OrderID, CustomerID, EmployeeID, OrderDate, ShipperID)
VALUES
(10278, 5, 8, '1996-08-12', 2),
(10280, 5, 2, '1996-08-14', 1),
(10308, 2, 7, '1996-09-18', 3),
(10355, 4, 6, '1996-11-15', 1),
(10365, 3, 3, '1996-11-27', 2),
(10383, 4, 8, '1996-12-16', 3),
(10384, 5, 3, '1996-12-16', 3);

-- Create the Order Details table
CREATE TABLE [Order Details] (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Insert data into the Order Details table
INSERT INTO [Order Details] (OrderDetailID, OrderID, ProductID, Quantity)
VALUES
(1, 10278, 1, 10),
(2, 10280, 2, 5),
(3, 10308, 3, 15),
(4, 10355, 1, 7),
(5, 10365, 2, 2),
(6, 10383, 3, 1),
(7, 10384, 1, 3);


CREATE TABLE Employeess (
   employeeid int primary key,
   emp_name varchar not null,
   job_id int null,
   manager_id int null,
   hire_date date,
   salary float null,
   commission float null,
   dept_id int
);
ALTER TABLE Employeess
ALTER COLUMN emp_name VARCHAR(255) NOT NULL;

Create Table Department(

dep_id int primary key,
dep_name varchar not null,
dep_location varchar
);
ALTER TABLE Department
ALTER COLUMN dep_name VARCHAR(255) NOT NULL;
ALTER TABLE Department
ALTER COLUMN dep_location VARCHAR(255) NOT NULL;

Create Table salar_grade(
 grade int primary key,
min_sal int ,
max_sal int
);


-- Insert data into the Employeess table
INSERT INTO Employeess (employeeid, emp_name, job_id, manager_id, hire_date, salary, commission, dept_id)
VALUES
(2, 'Jane Smith', 102, 1002, '2019-03-23', 60000, 6000, 20),
(3, 'Emily Johnson', 103, 1003, '2018-07-11', 55000, 5500, 30),
(4, 'Michael Brown', 104, 1004, '2021-02-05', 45000, 4500, 40),
(5, 'Jessica Davis', 105, 1005, '2017-12-19', 70000, 7000, 10);

-- Insert data into the Department table
INSERT INTO Department (dep_id, dep_name, dep_location)
VALUES

(1, 'Saless', 'New York'),
(2, 'Marketingg', 'Chicago'),
(3, 'HRt', 'San Francisco'),
(4, 'ITt', 'Seattle');

-- Insert data into the salar_grade table
INSERT INTO salar_grade (grade, min_sal, max_sal)
VALUES
(1, 30000, 40000),
(2, 40001, 50000),
(3, 50001, 60000),
(4, 60001, 70000),
(5, 70001, 80000);

Select * from Employeess;
select * from salar_grade;
select emp_name from employeess
inner join Department
on Employeess.dept_id=Department.dep_id
where dep_name='Marketing' AND  salary in (select max(salary) from Employeess );
select * from Department;


select emp_name from employeess

where salary in(
 select Max(salary) from employeess
 where dept_id
 in(
 select dep_id
 from department
 where dep_name='Marketing'
 ));
