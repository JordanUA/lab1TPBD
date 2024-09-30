-- Створення бази даних
CREATE DATABASE AdsDB;
GO

-- Використовуємо базу даних AdsDB
USE AdsDB;
GO

-- Створення таблиці Users
CREATE TABLE Users (
    ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    RegistrationDate DATE
);

-- Створення таблиці Categories
CREATE TABLE Categories (
    ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100)
);

-- Створення таблиці Ads
CREATE TABLE Ads (
    ID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255),
    Description NVARCHAR(MAX),
    Price DECIMAL(10, 2),
    PostDate DATE,
    UserID INT FOREIGN KEY REFERENCES Users(ID),
    CategoryID INT FOREIGN KEY REFERENCES Categories(ID)
);

-- Створення таблиці Comments
CREATE TABLE Comments (
    ID INT PRIMARY KEY IDENTITY,
    Content NVARCHAR(MAX),
    CommentDate DATE,
    UserID INT FOREIGN KEY REFERENCES Users(ID),
    AdID INT FOREIGN KEY REFERENCES Ads(ID)
);

-- Створення таблиці Cities
CREATE TABLE Cities (
    ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    UserID INT FOREIGN KEY REFERENCES Users(ID)
);

-- Вставка даних у таблицю Users
INSERT INTO Users (Name, Email, Phone, RegistrationDate) VALUES
('John Doe', 'john.doe@example.com', '1234567890', '2023-09-15'),
('Jane Smith', 'jane.smith@example.com', '0987654321', '2023-09-10');

-- Вставка даних у таблицю Categories
INSERT INTO Categories (Name) VALUES
('Electronics'),
('Furniture'),
('Cars');

-- Вставка даних у таблицю Ads
INSERT INTO Ads (Title, Description, Price, PostDate, UserID, CategoryID) VALUES
('iPhone 13 for sale', 'Brand new iPhone 13, never used.', 799.99, '2023-09-20', 1, 1),
('Used Sofa', 'Comfortable used sofa in great condition.', 120.00, '2023-09-18', 2, 2);

-- Вставка даних у таблицю Comments
INSERT INTO Comments (Content, CommentDate, UserID, AdID) VALUES
('Is this still available?', '2023-09-21', 2, 1),
('Can you provide more pictures?', '2023-09-22', 1, 2);

-- Вставка даних у таблицю Cities
INSERT INTO Cities (Name, UserID) VALUES
('Kyiv', 1),
('Lviv', 2);
