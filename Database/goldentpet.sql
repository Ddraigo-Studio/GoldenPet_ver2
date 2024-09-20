CREATE DATABASE goldenpet
GO
USE goldenpet

--DROP DATABASE goldenpet
CREATE TABLE dbo.tb_Menu (
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY,        
    name nvarchar(50) NULL,              
    link nvarchar(max) NULL,              
    meta nvarchar(max) NULL,             
    hide bit NULL,                       
    [order] int NULL,                    
    datebegin smalldatetime NULL,         
);
GO

INSERT INTO dbo.tb_Menu (name, link, meta, hide, [order], datebegin) 
VALUES 
    (N'Home', NULL, N'Home', 1, 1, CAST(N'2024-09-17T00:00:00' AS SmallDateTime)),
    (N'About', NULL, N'About', 1, 2, CAST(N'2024-09-17T00:00:00' AS SmallDateTime)),
    (N'Service', NULL, N'Service', 1, 3, CAST(N'2024-09-18T00:00:00' AS SmallDateTime)),
    (N'Package', NULL, N'Package', 1, 4, CAST(N'2024-09-18T00:00:00' AS SmallDateTime));
GO