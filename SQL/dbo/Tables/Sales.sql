﻿CREATE TABLE Sales

(

SaleID INT IDENTITY PRIMARY KEY,

ProductID TINYINT NOT NULL REFERENCES Products(ProductID),

CustomerID INT NOT NULL REFERENCES Customers(CustomerID),

SalePrice MONEY NOT NULL,

SaleDate SMALLDATETIME NOT NULL

)