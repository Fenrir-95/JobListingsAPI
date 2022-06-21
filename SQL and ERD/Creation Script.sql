USE [master]
GO

DROP DATABASE [listingsAPIDB]

IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases where name = N'listingsAPIDB')
BEGIN
	CREATE DATABASE [listingsAPIDB]
END


USE [listingsAPIDB]
GO

CREATE TABLE tbl_company	
(
	companyID INT PRIMARY KEY IDENTITY(1 ,1) NOT NULL,
	compName VARCHAR(50)  NOT NULL,
	compDescription VARCHAR(200)  NOT NULL,
	compLocation VARCHAR(20) NULL,
	compDateCreated DATETIME  NOT NULL,
	compDateModified DATETIME  NULL
)

CREATE TABLE tbl_Listings
(
	listingID INT PRIMARY KEY IDENTITY(1 ,1) NOT NULL,
	companyID INT  NOT NULL,
	listPositionName VARCHAR(50) NULL,
	listMinExperienceRequired INT NOT NULL,
	listMaxExperienceRequired INT NOT NULL,
	listAnnualSalary decimal NULL,
	listDateListed DATETIME  NOT NULL,
	listDateModified DATETIME NULL
)

CREATE TABLE tbl_RequiredSkills
(
	reqSkillID INT PRIMARY KEY IDENTITY(1 ,1) NOT NULL,
	listingID INT  NOT NULL,
	rsName VARCHAR(50)  NOT NULL,
	rsCreatedDate DATETIME NOT NULL
)

CREATE TABLE tbl_Applicants
(
	applicantID INT PRIMARY KEY IDENTITY(1 ,1) NOT NULL,
	appName VARCHAR(50)  NOT NULL,
	appSurname VARCHAR(50)  NOT NULL,
	appIdentityNumber VARCHAR(50)  NOT NULL,
	appYearsExperience INT  NOT NULL,
	appEmail VARCHAR(100)  NOT NULL,
	appContactNumber INT  NOT NULL,
	appLocation VARCHAR(200) NULL,
	appDateCreated DATETIME  NOT NULL,
	appDateModified DATETIME NULL
)

CREATE TABLE tbl_ApplicantSkills
(
	appSkillID INT PRIMARY KEY IDENTITY(1 ,1) NOT NULL,
	applicantID int  NOT NULL,
	asName VARCHAR(50)  NOT NULL,
	asCreatedDate DATETIME NOT NULL
)

CREATE TABLE tbl_Applications
(
	applicationID INT PRIMARY KEY IDENTITY(1 ,1) NOT NULL,
	listingID INT  NOT NULL,
	applicantID INT  NOT NULL,
	appDateCreated DATETIME NOT NULL
)

CREATE TABLE tbl_errorLogs
(
	logID INT PRIMARY KEY IDENTITY(1 ,1) NOT NULL,
	controller VARCHAR(100) NULL,
	exceptionMessage VARCHAR(MAX) NOT NULL,
	stackTrace VARCHAR(MAX) NULL,
	errorDate DATETIME NOT NULL
)

CREATE TABLE actionLogs
(
	logID INT PRIMARY KEY IDENTITY(1 ,1) NOT NULL,
	logController VARCHAR(100) NULL,
	logAction VARCHAR(10) NULL,
	logNewValue VARCHAR(MAX) NULL,
	logOldValue VARCHAR(MAX) NULL,
	logDateTime DATETIME
)

GO

INSERT INTO tbl_company
VALUES 
('MSI','Hardware manufacturer','USA',GETDATE(),getdate()),
('DELL','Hardware manufacturer','USA',GETDATE(),getdate()),
('LENOVO','Hardware manufacturer','USA',GETDATE(),getdate()),
('Microsoft','Multi National Corporation','GLOBAL',GETDATE(),getdate()),
('Tresorit','Cloud Backup Solution','SWEDEN',GETDATE(),getdate())


INSERT INTO tbl_Listings
VALUES
(1,'Intermediate Developer',3,5,200000.00,GETDATE(),GETDATE()),
(2,'Senior Developer',7,9,500000.00,GETDATE(),GETDATE()),
(3,'Intermediate Developer',2,3,200000.00,GETDATE(),GETDATE()),
(4,'Junior Developer',0,1,90000.00,GETDATE(),GETDATE()),
(2,'Junior Developer',0,1,80000.00,GETDATE(),GETDATE()),
(5,'Senior Developer',7,10,900000.00,GETDATE(),GETDATE())

INSERT INTO tbl_RequiredSkills
VALUES
(1,'Office',GETDATE()),
(1,'C#',GETDATE()),
(1,'Java',GETDATE()),
(2,'Java',GETDATE()),
(2,'SQL',GETDATE()),
(2,'GIT',GETDATE()),
(3,'JSP',GETDATE()),
(3,'MySQL',GETDATE()),
(4,'HTML',GETDATE()),
(4,'JavaScript',GETDATE()),
(4,'CSS',GETDATE()),
(5,'HTML',GETDATE()),
(5,'JavaScript',GETDATE()),
(5,'CSS',GETDATE()),
(6,'Encription',GETDATE()),
(6,'Java',GETDATE()),
(6,'C++',GETDATE()),
(6,'SQL',GETDATE())

INSERT INTO tbl_Applicants
VALUES 
('Rick','Sanchez','7894561230789',10,'rsanches@gmail.com',0123456789,'USA',GETDATE(),GETDATE()),
('Morty','Smith','7894561230789',2,'msmith@gmail.com',0123456789,'USA',GETDATE(),GETDATE()),
('Summer','Smith','7894561230789',1,'sum.smith@gmail.com',0123456789,'USA',GETDATE(),GETDATE()),
('Beth','Smith','7894561230789',2,'smithbeth@gmail.com',0123456789,'USA',GETDATE(),GETDATE()),
('Beth','Sanchez','7894561230789',5,'b.sanchez@gmail.com',0123456789,'USA',GETDATE(),GETDATE()),
('Jerry','Smith','7894561230789',0,'jersmi@gmail.com',0123456789,'USA',GETDATE(),GETDATE())

INSERT INTO tbl_ApplicantSkills
VALUES
(1,'SQL',GETDATE()),
(1,'C#',GETDATE()),
(1,'JAVA',GETDATE()),
(1,'HTML',GETDATE()),
(1,'CSS',GETDATE()),

(2,'SQL',GETDATE()),
(2,'C#',GETDATE()),
(2,'JAVA',GETDATE()),
(2,'HTML',GETDATE()),
(2,'CSS',GETDATE()),

(3,'SQL',GETDATE()),
(3,'C#',GETDATE()),
(3,'JAVA',GETDATE()),
(3,'HTML',GETDATE()),
(3,'CSS',GETDATE()),

(4,'SQL',GETDATE()),
(4,'C#',GETDATE()),
(4,'JAVA',GETDATE()),
(4,'HTML',GETDATE()),
(4,'CSS',GETDATE()),

(5,'SQL',GETDATE()),
(5,'C#',GETDATE()),
(5,'JAVA',GETDATE()),
(5,'HTML',GETDATE()),
(5,'CSS',GETDATE()),

(6,'SQL',GETDATE()),
(6,'C#',GETDATE()),
(6,'JAVA',GETDATE()),
(6,'HTML',GETDATE()),
(6,'CSS',GETDATE())



GO
