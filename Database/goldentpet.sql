CREATE DATABASE goldenpet
GO
USE goldenpet

--DROP DATABASE goldenpet


--------------------- CREATE TABLE ----------------------


----- PAGE DATA ----------
CREATE TABLE dbo.tb_Menu (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,        
    name NVARCHAR(50) NULL,              
    link NVARCHAR(MAX) NULL,
	
	-- 4 truong ko the thieu
    meta NVARCHAR(MAX) NULL,             
    hide BIT NULL,                       
    [order] INT NULL,                    
    datebegin SMALLDATETIME NULL,         
);
GO


CREATE TABLE dbo.tb_Advertisement (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    title NVARCHAR(150) NULL,
    description NTEXT NULL,
    img NVARCHAR(100) NULL,
	img2 NVARCHAR(100) NULL,
	img3 NVARCHAR(100) NULL,
	meta NVARCHAR(MAX) NULL,             
    hide BIT NULL,                       
    [order] INT NULL,                    
    createdDate SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,    
	createdBy NVARCHAR(150) NULL,
	modifidedDate SMALLDATETIME NULL,
	modifidedBy NVARCHAR(150) NULL,
);
GO
drop table dbo.tb_Img
CREATE TABLE dbo.tb_Img (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	link NVARCHAR(100) NOT NULL,
    type NVARCHAR(100) NOT NULL,
	title NVARCHAR(150) NULL,
    description NTEXT NULL,
	meta NVARCHAR(MAX) NULL,             
    hide BIT NULL,                       
    [order] INT NULL,                    
    createdDate SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,    
	createdBy NVARCHAR(150) NULL,
	modifidedDate SMALLDATETIME NULL,
	modifidedBy NVARCHAR(150) NULL,
);

INSERT INTO dbo.tb_Img (link, type, title, description, meta, hide, [order], createdBy, modifidedDate, modifidedBy)
VALUES
('about-1.jpg', 'about', Null, Null, null, 1, 1, null, NULL, NULL),
('team-1.jpg', 'team', 'Huy Dương', 'CEO', null, 1, 1, 'Huy', NULL, NULL)
('carousel-1.jpg', 'carousel', 'HHA', 'Huy dep trai vai o', null, 1, 1, 'User1', NULL, NULL),


select * from dbo.tb_Img
CREATE TABLE dbo.tb_ProductCategory(
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,        
    name NVARCHAR(150) NULL,  
	description NTEXT NULL,
    link NVARCHAR(MAX) NULL,              
    meta NVARCHAR(MAX) NULL,             
    hide BIT NULL,                       
    [order] INT NULL,                    
    createdDate SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,         
);
GO


CREATE TABLE dbo.tb_Product(
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,        
    name NVARCHAR(150) NULL,  
	price DECIMAL(18, 2) NULL,
	priceSale DECIMAL(18, 2) NULL,
	img NVARCHAR(100) NULL,
	img2 NVARCHAR(100) NULL,
	img3 NVARCHAR(100) NULL,
	img4 NVARCHAR(100) NULL,
	categoryID INT NULL,
	description NTEXT NULL,
    link NVARCHAR(MAX) NULL,              
    meta NVARCHAR(MAX) NULL,             
    hide BIT NULL,                       
    [order] INT NULL,                    
    createdDate SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY (categoryID) REFERENCES tb_ProductCategory(id),
);
GO


CREATE TABLE dbo.tb_Service (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    name NVARCHAR(150) NULL,
    description NTEXT NULL,
    price DECIMAL(18, 2) NULL,
    duration INT, -- In minutes
    img NVARCHAR(100) NULL, 
	img2 NVARCHAR(100) NULL,
	img3 NVARCHAR(100) NULL,
	img4 NVARCHAR(100) NULL,
	link NVARCHAR(MAX) NULL, 
	meta NVARCHAR(MAX) NULL,             
    hide BIT NULL,                       
    [order] INT NULL,                    
    createdDate SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,    
	createdBy NVARCHAR(150) NULL,
	-- Co the xem xet
	modifidedDate SMALLDATETIME NULL,
	modifidedBy NVARCHAR(150) NULL,
);
GO


CREATE TABLE dbo.tb_Contact (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    name NVARCHAR(150) NULL,
    email NVARCHAR(150) NULL,
	subject NVARCHAR(MAX) NULL,
	message NTEXT NULL, 
	isRead BIT NULL,                  
    createdDate SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,    
	createdBy NVARCHAR(150) NULL,
	-- Co the xem xet
	modifidedDate SMALLDATETIME NULL,
	modifidedBy NVARCHAR(150) NULL,
);
GO


CREATE TABLE dbo.tb_Package (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,           -- Name of the package (e.g., Basic, Standard, Premium)
    price DECIMAL(18, 2) NOT NULL,        -- Package price
    duration VARCHAR(50),                 -- Duration of the package (e.g., per month)                       -- List of services included in the package
    createdAt SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt SMALLDATETIME DEFAULT NULL,
);
GO 


CREATE TABLE dbo.tb_PackageFeature (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    packageId INT,
    feature_name VARCHAR(100) NOT NULL,
    isIncluded BIT NULL,
    createdAt SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,
    
    -- Foreign key relationship
    FOREIGN KEY (packageId) REFERENCES tb_Package(id) --ON DELETE CASCADE
);
GO

/*

INSERT INTO dbo.tb_Package (name, price, duration)
VALUES
('Basic', 49.00, '/ Mo', 'Feeding, Boarding'),
('Standard', 99.00, '/ Mo', 'Feeding, Boarding, Spa & Grooming'),
('Premium', 149.00, '/ Mo', 'Feeding, Boarding, Spa & Grooming, Veterinary Medicine');
GO

INSERT INTO dbo.tb_PackageFeature (packageId, feature_name, isIncluded)
VALUES
(1, 'Feeding', TRUE),
(1, 'Boarding', TRUE),
(1, 'Spa & Grooming', FALSE),
(1, 'Veterinary Medicine', FALSE);
GO

INSERT INTO dbo.tb_PackageFeature (packageId, feature_name, isIncluded)
VALUES
(2, 'Feeding', TRUE),
(2, 'Boarding', TRUE),
(2, 'Spa & Grooming', TRUE),
(2, 'Veterinary Medicine', FALSE);
GO


INSERT INTO dbo.tb_PackageFeature (packageId, feature_name, isIncluded)
VALUES
(3, 'Feeding', TRUE),
(3, 'Boarding', TRUE),
(3, 'Spa & Grooming', TRUE),
(3, 'Veterinary Medicine', TRUE);
GO

*/

-------------- CUSTOMER DATA --------------
CREATE TABLE dbo.tb_Customer (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    customerName NVARCHAR(150) NOT NULL,
	email VARCHAR(150) UNIQUE,
    phone VARCHAR(15) UNIQUE,
    createdDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
GO

CREATE TABLE dbo.tb_Pet(
	id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	name NVARCHAR(100) NOT NULL,
	customerId INT NOT NULL,
	FOREIGN KEY (customerId) REFERENCES tb_Customer(id),
);
GO


CREATE TABLE dbo.tb_Booking (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    customerID INT,
    serviceID INT,
	petName NVARCHAR(100) NULL,
    bookingDate SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,
	appoINTmentDate date,
	appoINTmentTime time, 
    status NVARCHAR(50) DEFAULT 'Pending' , -- e.g., 'Pending', 'Confirmed', 'Cancelled'
    FOREIGN KEY (customerID) REFERENCES tb_Customer(id),
    FOREIGN KEY (serviceID) REFERENCES tb_Service(id)
);
GO


-------------------------  INSERT DATA ---------------------

INSERT INTO dbo.tb_Menu (name, link, meta, hide, [order], datebegin) 
VALUES 
    (N'Home', NULL, N'Home', 1, 1, CAST(N'2024-09-17T00:00:00' AS SMALLDATETIME)),
    (N'About', NULL, N'About', 1, 2, CAST(N'2024-09-17T00:00:00' AS SMALLDATETIME)),
    (N'Service', NULL, N'Service', 1, 3, CAST(N'2024-09-18T00:00:00' AS SMALLDATETIME)),
    (N'Package', NULL, N'Package', 1, 4, CAST(N'2024-09-18T00:00:00' AS SMALLDATETIME));
GO