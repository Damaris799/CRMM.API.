﻿CREATE DATABASE CRMDB
GO

USE CRMDB
GO

CREATE TABLE Customers 
(
Id INT IDENTITY (1,1) PRIMARY KEY,
Name VARCHAR (50) NOT NULL,
LastName VARCHAR (50) NOT NULL,
Address VARCHAR (255)
)
GO