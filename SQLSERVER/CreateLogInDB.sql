--CREATE DATABASE LogIn
--use LogIn
--CREATE TABLE [User] (
--    ID UNIQUEIDENTIFIER PRIMARY KEY default NewId(),
--    [Username] VARCHAR (50) NOT NULL,
--    [Password] VARCHAR (50) NOT NULL,
--    Email VARCHAR(20),
--);

--INSERT INTO [User] values(NEWID(), 'Yolo', 'hrt', '@yolo.com')
INSERT INTO [User] values(NEWID(), 'Hrt', 'hrt', '@yolo.com')
SELECT * FROM [User]
