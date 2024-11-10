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

CREATE TABLE dbo.tb_MenuCategory (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,        
    name NVARCHAR(50) NULL,              
    link NVARCHAR(MAX) NULL,
	menuId INT NULL,

	-- 4 truong ko the thieu
    meta NVARCHAR(MAX) NULL,             
    hide BIT NULL,                       
    [order] INT NULL,                    
    datebegin SMALLDATETIME NULL,  
	FOREIGN KEY (menuId) REFERENCES tb_Menu(id),
);
GO

CREATE TABLE dbo.tb_Logo (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,        
    name NVARCHAR(50) NULL,              
	img NVARCHAR(100) NULL,

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

-- drop table dbo.tb_Img

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
GO

INSERT INTO dbo.tb_Img (link, type, title, description, meta, hide, [order], createdBy, modifidedDate, modifidedBy)
VALUES
('about-1.jpg', 'about', Null, Null, null, 1, 1, null, NULL, NULL),
('team-1.jpg', 'team', 'Huy Dương', 'CEO', null, 1, 1, 'Huy', NULL, NULL),
('carousel-1.jpg', 'carousel', 'HHA', 'Huy dep trai vai o', null, 1, 1, 'User1', NULL, NULL);
GO

select * from dbo.tb_Img


--drop table dbo.tb_Product

CREATE TABLE dbo.tb_Product(
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,        
    name NVARCHAR(150) NULL,  
	brand NVARCHAR(150) NULL,
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
--drop table tb_Product

select * from dbo.tb_Service

CREATE TABLE dbo.tb_Service (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    name NVARCHAR(150) NULL,
	title NTEXT NULL,
    description NTEXT NULL,
	description_1 NTEXT NULL,
    description_2 NTEXT NULL,
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
drop table dbo.tb_Service
select * from dbo.tb_ImgService

CREATE TABLE dbo.tb_ImgService (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    title NVARCHAR(150) NULL,
    description NTEXT NULL,
    img NVARCHAR(MAX) NULL, 
	id_Service INT NULL,
	link NVARCHAR(150) NULL, 
	meta NVARCHAR(100) NULL,             
    hide BIT NULL,                       
    [order] INT NULL,                    
    createdDate SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,    
	createdBy NVARCHAR(150) NULL,
	FOREIGN KEY (id_Service) REFERENCES tb_Service(id),
);
GO



--drop table dbo.tb_Service

CREATE TABLE dbo.tb_Contact (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    name NVARCHAR(150) NULL,
	phonenumber NVARCHAR(10),
	location NVARCHAR(150),
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
--drop table dbo.tb_Contact

select * from dbo.tb_Contact

CREATE TABLE dbo.tb_Package (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,           -- Name of the package (e.g., Basic, Standard, Premium)
	img VarChar(200) Not null,
    price DECIMAL(18, 2) NULL,        -- Package price
	description NTEXT NULL,
    duration VARCHAR(50),                 -- Duration of the package (e.g., per month)                       -- List of services included in the package
    createdAt SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt SMALLDATETIME DEFAULT NULL,
);
GO 


CREATE TABLE dbo.tb_PackageFeature (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    packageId INT,
    featureName NVARCHAR(150) NULL,
    isIncluded BIT NULL,
    createdAt SMALLDATETIME DEFAULT CURRENT_TIMESTAMP,
    
    -- Foreign key relationship
    FOREIGN KEY (packageId) REFERENCES tb_Package(id) --ON DELETE CASCADE
);
GO
--drop table dbo.tb_PackageFeature,dbo.tb_Package


INSERT INTO dbo.tb_Package (name,img, price, description, duration, createdAt)
VALUES    (N'Gói cơ bản','price-1.jpg', 49.00, N'Gói cơ bản bảo gồm cho bé ăn và trông nội trú', N'/Tháng', GETDATE()),
    (N'Gói tiêu chuẩn','price-2.jpg', 99.00, N'Gói tiêu chuẩn bao gồm cho ăn, trông nội trú, spa & grooming.', N'/Tháng', GETDATE()),
    (N'Gói cao cấp','price-3.jpg', 149.00, N'Gói cao cấp bao gồm cho ăn, trông nội trú, spa & grooming và huẩn luyện', N'/Tháng', GETDATE()),
	(N'Đây là phần mô tả','about-1.jpg', null, null, null, null);
GO

-- Insert data for 'Basic' package
INSERT INTO dbo.tb_PackageFeature (packageId, featureName, isIncluded, createdAt)
VALUES
 (4, N'Đỉnh Nóc', 0, GETDATE()),
  (4, N'Kịch Trần', 0, GETDATE()),
 (4, N'Bay Phấp Phới', 0, GETDATE()),

    (1, 'Feeding', 1, GETDATE()),
    (1, 'Boarding', 1, GETDATE()),
    (1, 'Spa & Grooming', 0, GETDATE()),
    (1, 'Veterinary Medicine', 0, GETDATE());
GO


CREATE TABLE dbo.tb_News
(
    NewsID INT IDENTITY(1,1) PRIMARY KEY,       -- Unique identifier for each news article
    Title NVARCHAR(255) NOT NULL,               -- Title of the news article
    Content NVARCHAR(MAX) NOT NULL,             -- Main content of the news article
    Slug NVARCHAR(255),                         -- URL-friendly version of the title
    AuthorName NVARCHAR(50),                               -- ID of the author
    CategoryName NVARCHAR(50),                             -- ID of the category
    PublishedDate DATETIME,                     -- The date the article was published
    LastModifiedDate DATETIME,                  -- The date the article was last updated
    Status NVARCHAR(50),                        -- Draft, Published, or Archived
    Summary NVARCHAR(500),                      -- Short summary of the news
    ThumbnailImageURL NVARCHAR(500),            -- URL of the main thumbnail image
	 hide BIT NULL,                       
    [order] INT NULL
    -- Meta fields for SEO
    MetaTitle NVARCHAR(255),                    -- Custom meta title for SEO
);
GO

-- Create NewsImages Table
CREATE TABLE dbo.tb_NewsImages
(
    ImageID INT IDENTITY(1,1) PRIMARY KEY,       -- Unique identifier for each image
    NewsID INT,                                  -- Reference to the NewsID in the News table
    ImageURL NVARCHAR(500) NOT NULL,             -- URL or file path of the image
    Caption NVARCHAR(255),                       -- Optional caption for the image
    [Order] INT,                                 -- Order of the image in the article
    IsPrimary BIT,                               -- Indicates if this image is the main image
    UploadedDate DATETIME DEFAULT GETDATE(),     -- Date and time the image was uploaded
    FOREIGN KEY (NewsID) REFERENCES dbo.tb_News(NewsID)  -- Foreign key constraint to link to the News table
);
GO

CREATE TABLE Carts (
    CartID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    CreatedAt Datetime DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserID) REFERENCES dbo.tb_Customer(id) ON DELETE CASCADE
);

-- Create the CartItems table
CREATE TABLE CartItems (
    CartItemID INT IDENTITY(1,1) PRIMARY KEY,
    CartID INT,
    ProductID INT,
    Quantity INT NOT NULL,
    AddedAt Datetime DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (CartID) REFERENCES Carts(CartID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES dbo.tb_Product(id) ON DELETE CASCADE
);

-- Create the Orders table
CREATE TABLE Orders (
    OrderID INT  IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    OrderDate Datetime DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    Status VARCHAR(20) DEFAULT 'Pending',
    FOREIGN KEY (UserID) REFERENCES dbo.tb_Customer(id) ON DELETE SET NULL
);

-- Create the OrderItems table
CREATE TABLE OrderItems (
    OrderItemID INT  IDENTITY(1,1) PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,  -- Price at the time of order
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES dbo.tb_Product(id) ON DELETE SET NULL
);
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
--drop table dbo.tb_NewsImages,dbo.tb_News
/*
-- Insert data for 'Standard' package
INSERT INTO dbo.tb_PackageFeature (packageId, featureName, isIncluded, createdAt)
VALUES
    (2, 'Feeding', 1, GETDATE()),
    (2, 'Boarding', 1, GETDATE()),
    (2, 'Spa & Grooming', 1, GETDATE()),
    (2, 'Veterinary Medicine', 0, GETDATE());
GO

-- Insert data for 'Premium' package
INSERT INTO dbo.tb_PackageFeature (packageId, featureName, isIncluded, createdAt)
VALUES
    (3, 'Feeding', 1, GETDATE()),
    (3, 'Boarding', 1, GETDATE()),
    (3, 'Spa & Grooming', 1, GETDATE()),
    (3, 'Veterinary Medicine', 1, GETDATE());

*/

-------------- CUSTOMER DATA --------------
CREATE TABLE dbo.tb_Customer (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	password Varchar(50),
    customerName NVARCHAR(150) NOT NULL,
	email VARCHAR(150) UNIQUE,
    phone VARCHAR(15) UNIQUE,
    createdDate Datetime DEFAULT CURRENT_TIMESTAMP
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
    (N'Trang chủ', NULL, N'trang-chu', 1, 1, CAST(N'2024-09-17T00:00:00' AS SMALLDATETIME)),
    (N'Thông tin', NULL, N'thong-tin-ve-chung-toi', 1, 2, CAST(N'2024-09-17T00:00:00' AS SMALLDATETIME)),
    (N'Dịch vụ', NULL, N'dich-vu', 1, 3, CAST(N'2024-09-18T00:00:00' AS SMALLDATETIME)),
	(N'Sản phẩm', NULL, N'san-pham', 1, 4, CAST(N'2024-09-24T00:00:00' AS SMALLDATETIME)),
    (N'Gói dịch vụ', NULL, N'goi-dich-vu', 1, 5, CAST(N'2024-09-18T00:00:00' AS SMALLDATETIME)),
	(N'Tin tức', NULL, N'tin-tuc', 1, 6, GETDATE());
GO

--DBCC CHECKIDENT ('tb_Menu', RESEED, 0);
--Delete from tb_Menu


INSERT INTO dbo.tb_MenuCategory (name, link, menuId, meta, hide, [order], datebegin) 
VALUES
	(N'Thức ăn', NULL, 4, N'thuc-an-thu-cung', 1, 1, GETDATE()),
	(N'Đồ chơi', NULL, 4, N'do-choi-thu-cung', 1, 2, GETDATE()),
	(N'Phụ kiện', NULL, 4, N'phu-kien-thu-cung', 1, 3, GETDATE()),
	(N'Sản phẩm chăm sóc sức khỏe', NULL, 4, N'san-pham-cham-soc-suc-khoe-thu-cung', 1, 4, GETDATE()),
	(N'Nhà và chuồng', NULL, 4, N'nha-va-chuong-cho-thu-cung', 1, 5, GETDATE());
GO


INSERT INTO dbo.tb_ProductCategory (name, description, link, meta, hide, [order], createdDate)
VALUES 
	(N'Thức ăn', NULL, NULL, N'thuc-an-thu-cung', 1, 1, GETDATE()),
    (N'Đồ chơi',NULL , NULL, N'do-choi-thu-cung', 1, 2,GETDATE()),
    (N'Phụ kiện',NULL , NULL, N'phu-kien-thu-cung', 1, 3,GETDATE()),
    (N'Sản phẩm chăm sóc sức khỏe', NULL, NULL, N'san-pham-cham-soc-suc-khoe-thu-cung', 1, 4,GETDATE()),
    (N'Nhà và chuồng', NULL, NULL, N'nha-va-chuong-thu-cung', 1, 5,GETDATE());
GO

-- DBCC CHECKIDENT ('tb_ProductCategory', RESEED, 0);
--Delete from tb_ProductCategory

-- THUC AN ------
INSERT INTO dbo.tb_Product (name, brand, price, priceSale, img, img2, img3, img4, categoryID, description, link, meta, hide, [order], createdDate)
VALUES 
(N'Pate cho chó vị thịt bò trộn rau củ IRIS OHYAMA Chicken Beef Vegetable', N'IRIS OHYAMA', 100000, 80000, 'product-1.jpg', 'product-2.jpg', 'product3.jpg', 'product-4.jpg', 1, 
N'Pate cho chó vị thịt bò trộn rau củ IRIS OHYAMA Chicken Beef Vegetable là sản phẩm dành cho tất cả giống chó. Sản phẩm sẽ làm hài lòng những chú chó kén ăn nhất.', 
NULL, 'san-pham/pate-cho-cun', 1, 1, GETDATE()),

(N'Thức ăn cho chó con hạt mềm ZENITH Puppy Chicken Potato', N'ZENITH',240000, NULL, 'product-5.jpg', NULL, NULL, NULL, 1, 
N'Thức ăn cho chó con hạt mềm ZENITH Puppy Chicken & Potato được chế biến từ các nguyên liệu tươi sạch như thịt cừu, thịt nạc gà rút xương, gạo lứt, yến mạch và dầu cá hồi, cung cấp độ ẩm cao và lượng muối thấp. Sản phẩm không chỉ thơm ngon, dễ nhai và dễ tiêu hóa mà còn đặc biệt tốt cho sức khỏe và sự phát triển của chó con dưới 1 tuổi.', 
NULL, 'san-pham/hat-cho-cun-con', 1, 2, GETDATE()),

(N'Xương gặm sạch răng cho chó VEGEBRAND Orgo Freshening Peppermint', N'VEGEBRAND' ,200000, NULL, 'product-6.jpg',NULL ,NULL , NULL, 1, 
N'Xương gặm sạch răng cho chó VEGEBRAND Orgo Freshening Peppermint là sản phẩm dinh dưỡng dành cho chó trên 5 tháng tuổi.', 
NULL, 'san-pham/xuong-gam-cho-cun', 1, 3, GETDATE()),

(N'Pate cho mèo vị nước sốt thịt bò WHISKAS Beef Flavour Sauce',N'WHISKAS', 25000, NULL, 'product-7.jpg', NULL, NULL, NULL, 1, 
N'Pate cho mèo vị nước sốt thịt bò WHISKAS Beef Flavour Sauce, thơm ngon đặc trưng dành riêng cho mèo, giúp mèo cưng ăn uống ngon miệng hơn. Tăng miễn dịch, hỗ trợ tiêu hóa. Chăm sóc lông mềm mượt và hạn chế tối đa tỷ lệ rụng lông hàng năm của mèo cưng.', 
NULL, 'san-pham/pate-cho-meo', 1, 4, GETDATE()),

(N'Thức ăn cho mèo con vị cá hồi cá ngừ PURINA PRO PLAN Kitten Starter', N'PURINA PRO PLAN',500000, NULL, 'product-8.jpg', NULL, NULL, NULL, 1, 
N'Thức ăn cho mèo con từ 1 tháng tuổi trở lên, vị cá hồi cá ngừ PURINA PRO PLAN Kitten Starter là sản phẩm kết hợp tất cả các dưỡng chất thiết yếu bao gồm DHA hỗ trợ phát triển trí não và vitamin C, D cùng sữa non để phát triển hệ miễn dịch khỏe mạnh trong chế độ ăn giàu protein dành riêng cho mèo con.

Mèo con nên được cho ăn khi được 3 đến 4 tuần tuổi. Nên ngâm sản phẩm với nước ấm để giữ nguyên chất dinh dưỡng và dễ ăn hơn. Khi được 5-6 tuần, bắt đầu giảm lượng nước bổ sung cho đến khi mèo con có thể ăn thức ăn khô. Khi mèo con của bạn đã được 6 tháng tuổi, hãy chuyển sang thức ăn dành cho độ tuổi lớn hơn.', 
NULL, 'san-pham/thuc-an-cho-meo', 1, 5, GETDATE());
GO

--delete  from dbo.tb_News

--NEWS
INSERT INTO dbo.tb_News 
(Title, Content, Slug, AuthorName, CategoryName, PublishedDate, LastModifiedDate, Status, Summary, ThumbnailImageURL, MetaTitle)
VALUES 
(N'Các Dịch Vụ Chăm Sóc Thú Cưng Tốt Nhất', 
 N'Chúng tôi cung cấp các dịch vụ chăm sóc thú cưng chuyên nghiệp, bao gồm cắt tỉa lông, tắm rửa, và kiểm tra sức khỏe định kỳ cho thú cưng của bạn.', 
 'cac-dich-vu-cham-soc-thu-cung-tot-nhat', 
 N'Nguyễn Văn A', 
 N'Dịch Vụ', 
 GETDATE(), 
 GETDATE(), 
 'Published', 
 N'Các dịch vụ chăm sóc thú cưng của chúng tôi giúp thú cưng luôn khỏe mạnh và sạch sẽ.', 
 'new-1.jpg', 
 N'Dịch Vụ Chăm Sóc Thú Cưng'),

(N'Sản Phẩm Dành Cho Chó Mèo Chất Lượng Cao', 
 N'Khám phá các sản phẩm dành riêng cho chó mèo như thức ăn, đồ chơi, và vật dụng chăm sóc với chất lượng hàng đầu.', 
 'san-pham-danh-cho-cho-meo-chat-luong-cao', 
 N'Trần Thị B', 
 N'Sản Phẩm', 
  GETDATE(), 
 GETDATE(),  
 'Published', 
 N'Các sản phẩm chất lượng cao dành riêng cho thú cưng của bạn.', 
 'new-2.jpg', 
 N'Sản Phẩm Cho Chó Mèo'),

(N'Tư Vấn Sức Khỏe Cho Thú Cưng', 
 N'Đội ngũ chuyên gia của chúng tôi luôn sẵn sàng hỗ trợ và tư vấn sức khỏe cho thú cưng, từ chế độ ăn uống đến phòng ngừa bệnh tật.', 
 'tu-van-suc-khoe-cho-thu-cung', 
 N'Lê Văn C', 
 N'Tư Vấn', 
  GETDATE(), 
 GETDATE(),  
 'Published', 
 N'Dịch vụ tư vấn sức khỏe và chế độ dinh dưỡng tốt nhất cho thú cưng.', 
 'new-3.jpg', 
 N'Tư Vấn Sức Khỏe Thú Cưng');
 GO

--IMG NEWS
INSERT INTO dbo.tb_NewsImages 
(NewsID, ImageURL, Caption, [Order], IsPrimary) 
VALUES 
(1, 'new-1.jpg', 'Dịch Vụ Cắt Tỉa Lông Cho Mèo', 1, 1),
(2, 'new-2.jpg', 'Thức Ăn Dành Cho Chó', 1, 1),
(3, 'new-3.jpg', 'Bác Sĩ Thú Y Tư Vấn Sức Khỏe', 1, 1);

GO

--IMG FOR PARTALVIEW
INSERT INTO dbo.tb_Img (link, type, title, description, meta, hide, [order], createdBy, modifidedDate, modifidedBy)
VALUES
('about-1.jpg', 'about', null, null, null, 1, 1, 'Huy', NULL, NULL),
('about-3.jpg', 'about', null, null, null, 1, 3, 'Huy', NULL, NULL),
('about-2.jpg', 'about', null, null, null, 1, 2, 'Huy', NULL, NULL),
('team-1.jpg', 'team', 'Huy Dương', 'CEO', null, 1, 1, 'Huy', NULL, NULL),
('carousel-1.jpg', 'carousel', 'HHA', 'Huy dep trai vai o', null, 1, 1, 'User1', NULL, NULL)
--drop table dbo.tb_News,
-- DBCC CHECKIDENT ('tb_Product', RESEED, 0);
--Delete from tb_Product

GO

INSERT INTO dbo.tb_Contact(phonenumber,location,email,createdDate)
values
('0961305436', N'Quận 7, Tp.HCM','Huyduong110082004@gmail.com',GETDATE())
GO

INSERT INTO dbo.tb_Logo (name, img, meta, hide, [order], datebegin) VALUES
('GoldentPet', 'LogoPet.png', NULL, 1, 1, GETDATE());
GO

INSERT INTO dbo.tb_Service (name,title, description, description_1, description_2, price, duration, img, img2, img3, img4, link, meta, hide, [order], createdBy, modifidedDate, modifidedBy)
VALUES
    (N'Grooming', N'Chúng tôi tự hào mang đến dịch vụ grooming toàn diện cho thú cưng, giúp chúng không chỉ trông xinh đẹp mà còn khỏe mạnh và thoải mái. Đội ngũ chuyên gia yêu thú cưng của chúng tôi sẽ chăm sóc từng chi tiết, đảm bảo rằng mỗi lần ghé thăm là một trải nghiệm thú vị cho bạn và thú cưng.',
	N'<div class="col-lg-6 mb-5">
    <h2 class=" des-text mb-3">PET SPA VÀ GROMMING</h2>
    <p>Bộ lông và da không chỉ giúp cho thú cưng có ngoại hình ưa nhìn mà còn đóng vai trò quan trọng đối với sức khỏe của thú cưng.</p>
    <p>Việc vệ sinh bộ lông thường xuyên và cắt tỉa bớt sẽ giúp cho thú cưng giảm nguy cơ mắc các bệnh về da, vận động một cách thoải mái và dạo phố trông thật đáng yêu và sành điệu.</p>
    <p>Dịch vụ Spa &amp; Grooming của GoldenPet sẽ thay bạn chăm sóc và bảo vệ những người bạn nhỏ.</p>
    <p>Với các bước chăm sóc chu đáo, tận tình, tạo cho các bé thú cưng cảm giác thư thái.</p>
    <p>Để đảm bảo chất lượng trải nghiệm dịch vụ tốt nhất, Quý khách hàng có thể đặt lịch hẹn với GoldenPet trước.</p>
</div>',  N'<div class="col-lg-6 mb-5">
    <h2 class=" des-text mb-4">QUY TRÌNH LÀM ĐẸP THÚ CƯNG TẠI GoldenPet</h2>
    <p>Với mong muốn đem lại sự tận hưởng và hạnh phúc cho các bé cưng trong quá trình làm đẹp và một chất lượng xứng đáng với sự tin tưởng của các chủ Pet. Quy trình cho các bé sẽ diễn ra theo từng bước và có những quy tắc riêng. Điều này sẽ giúp Vpet’s dễ dàng hơn trong việc và đảm bảo sự an toàn cho những chú chó, mèo khác đang được chăm sóc tại đây. Quy trình làm đẹp cho Pet yêu sẽ diễn ra theo thứ tự:</p>
    <ul>
        <li>Thú cưng sẽ được kiểm tra tình trạng da lông và chọn loại dầu tắm phù hợp</li>
        <li>Vệ sinh và nhổ lông tai</li>
        <li>Cạo lông vùng bụng, bàn chân và hậu môn</li>
        <li>Cắt dũa móng</li>
        <li>Vắt tuyến hôi</li>
        <li>Tắm spa kết hợp massage giúp bé thư giãn</li>
        <li>Cắt tỉa/ cạo tạo kiểu theo yêu cầu</li>
        <li>Sấy khô, chải lông</li>
        <li>Thoa dưỡng lông và xịt nước hoa</li>
        <li>Sau khi hoàn thành, các bé sẽ được bác sĩ kiểm tra lại tình trang da lông lần nữa và hướng dẫn cách chăm sóc bé tại nhà</li>
    </ul>
</div>', Null, 49.99, 90, 'grooming1.png', 'grooming2.png', N'<h3 class="flaticon-house display-3 font-weight-normal text-secondary mb-3"></h3>', NULL, NULL, 'dich-vu-grooming', 1, 1, 'Admin', NULL, NULL); 
GO


INSERT INTO dbo.tb_Service (name, title, description, description_1, description_2, price, duration, img, img2, img3, img4, link, meta, hide, [order], createdBy, modifidedDate, modifidedBy)
VALUES
    (N'Tư vấn dinh dưỡng và sức khỏe', 
     N'Chúng tôi hiểu rằng chế độ dinh dưỡng là yếu tố quan trọng hàng đầu trong việc duy trì sức khỏe và sự phát triển của thú cưng. Đội ngũ chuyên gia dinh dưỡng của chúng tôi sẵn sàng cung cấp những lời khuyên hữu ích để giúp bạn chăm sóc tốt nhất cho người bạn bốn chân của mình.', 
     N'<div class="col-lg-6 mb-5">
        <h2 class=" des-text mb-3">TƯ VẤN DINH DƯỠNG VÀ SỨC KHỎE CHO THÚ CƯNG</h2>
        <p>Chế độ dinh dưỡng ảnh hưởng lớn đến sức khỏe tổng thể và sự phát triển của thú cưng. Việc cung cấp dinh dưỡng hợp lý không chỉ giúp thú cưng có vẻ ngoài tươi tắn mà còn tăng cường hệ miễn dịch và sức bền.</p>
        <p>Với dịch vụ tư vấn dinh dưỡng của GoldenPet, bạn sẽ nhận được những lời khuyên chuyên sâu về chế độ ăn uống phù hợp với từng giống loài, độ tuổi và tình trạng sức khỏe của thú cưng.</p>
        <p>Chúng tôi giúp bạn lựa chọn thức ăn, bổ sung dinh dưỡng hợp lý để thú cưng có thể phát triển khỏe mạnh, phòng tránh các bệnh lý và duy trì năng lượng trong suốt cuộc sống hàng ngày.</p>
        <p>Để đảm bảo thú cưng của bạn có chế độ dinh dưỡng tối ưu, bạn có thể đặt lịch hẹn tư vấn với đội ngũ chuyên gia của GoldenPet ngay hôm nay.</p>
     </div>',  
     N'<div class="col-lg-6 mb-5">
        <h2 class=" des-text mb-4">CHUYÊN GIA TƯ VẤN DINH DƯỠNG CHO THÚ CƯNG</h2>
        <p>Đội ngũ chuyên gia của GoldenPet luôn tận tâm giúp bạn hiểu rõ hơn về nhu cầu dinh dưỡng của thú cưng. Chúng tôi cung cấp các dịch vụ tư vấn từ cơ bản đến chuyên sâu, nhằm mang lại chế độ ăn uống tốt nhất cho từng loại thú cưng.</p>
        <p>Bằng cách đánh giá toàn diện tình trạng sức khỏe của thú cưng, chúng tôi sẽ đề xuất những thực phẩm phù hợp nhất, giúp cải thiện sức khỏe và nâng cao chất lượng sống cho thú cưng của bạn.</p>
        <p>Đến với dịch vụ tư vấn của GoldenPet, bạn có thể hoàn toàn yên tâm rằng thú cưng của mình sẽ nhận được sự chăm sóc tốt nhất và chế độ dinh dưỡng hợp lý nhất.</p>
     </div>',  
     NULL, 39.99, 60, 'nutrition1.png', 'nutrition2.png', N'<h3 class="flaticon-food display-3 font-weight-normal text-secondary mb-3"></h3>', NULL, NULL, 'tu-van-dinh-duong-suc-khoe', 1, 2, 'Admin', NULL, NULL);
GO
delete from tb_ImgService
 DBCC CHECKIDENT ('tb_ImgService', RESEED, 0);

INSERT INTO dbo.tb_ImgService (
    title,
    description,
    img,
    id_Service,
    link,
    meta,
    hide,
    [order],
    createdBy
) VALUES 
(N'Hình ảnh Pet yêu làm đẹp tại GoldenPet', N'<div class="row">
        <div class="col-md-2 mb-3">
            <img class="img-fluid" src="https://vpets.vn/wp-content/uploads/2024/05/Anh-pet-yeu-lam-dep-tai-vpet-spa-1.jpg.webp" alt="Grooming 1">
        </div>
        <div class="col-md-2 mb-3">
            <img class="img-fluid" src="https://vpets.vn/wp-content/uploads/2024/05/Anh-pet-yeu-lam-dep-tai-vpet-spa-3s.jpg.webp" alt="Grooming 2">
        </div>
        <div class="col-md-2 mb-3">
            <img class="img-fluid" src="https://vpets.vn/wp-content/uploads/2024/05/spa-poodle-1.png.webp" alt="Grooming 3">
        </div>
        <div class="col-md-2 mb-3">
            <img class="img-fluid" src="https://vpets.vn/wp-content/uploads/2024/05/spa-phoc-soc.png.webp" alt="Grooming 4">
        </div>
        <div class="col-md-2 mb-3">
            <img class="img-fluid" src="https://vpets.vn/wp-content/uploads/2024/05/spa-meo.png.webp" alt="Grooming 5">
        </div>
        <div class="col-md-2 mb-3">
            <img class="img-fluid" src="https://vpets.vn/wp-content/uploads/2024/05/Anh-pet-yeu-lam-dep-tai-vpet-spa-13.jpg" alt="Grooming 6">
        </div>
    </div>',NULL , 1, NULL, NULL, 1, 1, 'Admin');


