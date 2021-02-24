
--TABLE CREATION

--DROP TABLE Customer
CREATE TABLE Customer(
	CustomerId INT IDENTITY(1, 1) PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	StreetAddress1 NVARCHAR(100) NOT NULL,
	StreetAddress2 NVARCHAR(100) NULL,
	City NVARCHAR(50) NOT NULL,
	State NVARCHAR(2) NOT NULL,
	Zipcode NVARCHAR(5) NOT NULL,
	CustomerCreated DATETIME2(0) NOT NULL,
	DefaultStoreId INT NULL FOREIGN KEY REFERENCES Store(StoreId)
);
GO

--DROP TABLE Product
CREATE TABLE Product(
	ProductId INT IDENTITY(1, 1) PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL UNIQUE,
	Price MONEY NOT NULL
);
GO

--DROP TABLE Store
CREATE TABLE Store(
	StoreId INT IDENTITY(1, 1) PRIMARY KEY,
	Name NVARCHAR(50) UNIQUE NOT NULL,
	StreetAddress1 NVARCHAR(100) NOT NULL,
	StreetAddress2 NVARCHAR(100) NULL,
	City NVARCHAR(50) NOT NULL,
	State NVARCHAR(2) NOT NULL,
	Zipcode NVARCHAR(5) NOT NULL
);
GO

--Drop Table Orders
CREATE TABLE Orders(
	OrderId INT IDENTITY(1, 1) PRIMARY KEY,
	CustomerId INT FOREIGN KEY REFERENCES Customer(CustomerId),
	StoreId INT FOREIGN KEY REFERENCES Store(StoreId),
	NumberOfProducts INT NOT NULL,
	OrderTotal MONEY NOT NULL,
	DatePlaced DATETIME2(0)
);
GO

--DROP TABLE OrderDetails
CREATE TABLE OrderDetails(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
	ProductId INT FOREIGN KEY REFERENCES Product(ProductId),
	Quantity INT NOT NULL,
	TotalCost MONEY NOT NULL
);
GO

--DROP TABLE Inventory
CREATE TABLE Inventory(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	StoreId INT FOREIGN KEY REFERENCES Store(StoreId),
	ProductId INT FOREIGN KEY REFERENCES Product(ProductId),
	Quantity INT NOT NULL
);
	SELECT * FROM STORE

--INITIAL DATA FOR CUSTOMER TABLE
INSERT INTO CUSTOMER (FirstName, LastName, StreetAddress1, City, State, Zipcode, CustomerCreated, DefaultStoreId) VALUES ('JOHN', 'SMITH', '123 MAIN STREET', 'ATLANTA', 'GA', 30303, SYSDATETIME(), 1);
INSERT INTO CUSTOMER (FirstName, LastName, StreetAddress1, City, State, Zipcode, CustomerCreated, DefaultStoreId) VALUES ('ROBERT', 'CERENO', '87542 ALAMO DRIVE', 'DALLAS', 'TX', 74521, SYSDATETIME(), 2);
INSERT INTO CUSTOMER (FirstName, LastName, StreetAddress1, City, State, Zipcode, CustomerCreated, DefaultStoreId) VALUES ('STEVE', 'ROGERS', '555 AVENGERS DRIVE', 'NEW YORK', 'NY', 99999, SYSDATETIME(), 3);
INSERT INTO CUSTOMER (FirstName, LastName, StreetAddress1, City, State, Zipcode, CustomerCreated, DefaultStoreId) VALUES ('SANDRA', 'CLARK', '745 PONY EXPRESS BLVD', 'WICHITA', 'KS', 55842, SYSDATETIME(), 2);
INSERT INTO CUSTOMER (FirstName, LastName, StreetAddress1, City, State, Zipcode, CustomerCreated, DefaultStoreId) VALUES ('BUCKY', 'ROBERTS', '97642 EAST 84TH STREET', 'BOSTON', 'MA', 14965, SYSDATETIME(), 3);

--INITIAL DATA FOR PRODUCT TABLE
INSERT INTO PRODUCT (Name, Price) VALUES ('STRAWBERRY JELLY', $8.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('STRAWBERRY JAM', $8.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('GRAPE JELLY', $7.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('GRAPE JAM', $7.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('AVACADO JELLY', $15.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('AVACADO JAM', $15.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('DRAGONFRUIT JELLY', $11.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('DRAGONFRUIT JAM', $11.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('APPLE JELLY', $8.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('APPLE JAM', $8.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('ORANGE JELLY', $7.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('ORANGE JAM', $7.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('RASPBERRY JELLY', $9.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('RASPBERRY JAM', $9.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('BLACKBERRY JELLY', $9.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('BLACKBERRY JAM', $9.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('MANGO JELLY', $10.95);
INSERT INTO PRODUCT (Name, Price) VALUES ('MANGO JAM', $10.95);

--INITIAL DATA FOR STORE TABLE
INSERT INTO Store (Name, StreetAddress1, StreetAddress2, City, State, Zipcode) VALUES ('SOUTHEAST', '1101 COLUMBUS AVENUE', 'SUITE 101', 'ATHENS', 'SC', 65656);
INSERT INTO Store (Name, StreetAddress1, StreetAddress2, City, State, Zipcode) VALUES ('WEST', '9758 ROCKIES BLVD', 'SUITE 1395', 'DENVER', 'CO', 88754);
INSERT INTO Store (Name, StreetAddress1, StreetAddress2, City, State, Zipcode) VALUES ('NORTH', '664 POWER DRIVE', 'SUITE 5', 'COLUMBUS', 'OH', 65656);

--INITIAL DATA FOR INVENTORY
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 1, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 2, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 3, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 4, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 5, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 6, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 7, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 8, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 9, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 10, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 11, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 12, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 13, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 14, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 15, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 16, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 17, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (1, 18, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 1, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 2, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 3, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 4, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 5, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 6, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 7, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 8, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 9, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 10, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 11, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 12, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 13, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 14, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 15, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 16, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 17, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (2, 18, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 1, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 2, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 3, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 4, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 5, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 6, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 7, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 8, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 9, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 10, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 11, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 12, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 13, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 14, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 15, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 16, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 17, 100);
INSERT INTO Inventory (StoreId, ProductId, Quantity) VALUES (3, 18, 100);

INSERT INTO Orders (CustomerId, StoreId, NumberOfProducts, OrderTotal, DatePlaced) VALUES (6, 1, 1, 15.95, SYSDATETIME());
INSERT INTO Orders (CustomerId, StoreId, NumberOfProducts, OrderTotal, DatePlaced) VALUES (6, 1, 3, 26.77, SYSDATETIME());
INSERT INTO Orders (CustomerId, StoreId, NumberOfProducts, OrderTotal, DatePlaced) VALUES (7, 2, 5, 44.75, SYSDATETIME());
INSERT INTO Orders (CustomerId, StoreId, NumberOfProducts, OrderTotal, DatePlaced) VALUES (7, 2, 5, 43.75, SYSDATETIME());
INSERT INTO Orders (CustomerId, StoreId, NumberOfProducts, OrderTotal, DatePlaced) VALUES (8, 3, 5, 44.75, SYSDATETIME());
INSERT INTO Orders (CustomerId, StoreId, NumberOfProducts, OrderTotal, DatePlaced) VALUES (8, 3, 5, 43.75, SYSDATETIME());
INSERT INTO Orders (CustomerId, StoreId, NumberOfProducts, OrderTotal, DatePlaced) VALUES (9, 2, 5, 44.75, SYSDATETIME());
INSERT INTO Orders (CustomerId, StoreId, NumberOfProducts, OrderTotal, DatePlaced) VALUES (10, 3, 5, 43.75, SYSDATETIME());

INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (9, 1, 2, 17.90);
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (9, 2, 2, 17.90);
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (9, 3, 1, 7.95);
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (10, 1, 2, 17.90);
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (10, 2, 2, 17.90);
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (11, 3, 1, 7.95);
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (11, 1, 2, 17.90);
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (12, 2, 2, 17.90);
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (13, 3, 1, 7.95);
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (14, 1, 2, 17.90);
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (15, 2, 2, 17.90);
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, TotalCost) VALUES (15, 3, 1, 7.95);

