-- В базе данных MS SQL Server есть продукты и категории.
-- Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов.
-- Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории».
-- Если у продукта нет категорий, то его имя все равно должно выводиться.

-- Запрос
SELECT p.Name as ProductName, STRING_AGG(c.Name, ', ') as CategoryName
FROM Product p
         LEFT JOIN Product_Category pc ON p.Id = pc.ProductId
         LEFT JOIN Category c ON c.Id = pc.CategoryId
GROUP BY p.Name
ORDER BY CategoryName


-- Создание таблиц
create table Product
(
    Id   int NOT NULL PRIMARY KEY,
    Name varchar(255)
);

create table Category
(
    Id   int NOT NULL PRIMARY KEY,
    Name varchar(255)
);

create table Product_Category
(
    ProductId  int FOREIGN KEY REFERENCES Product(Id),
    CategoryId int FOREIGN KEY REFERENCES Category(Id),

    PRIMARY KEY (ProductId, CategoryId)
);

-- Заполнение таблиц данными
INSERT INTO Product
    (Id, Name)
VALUES ('1', 'Tomato'),
       ('2', 'Pear'),
       ('3', 'Apple'),
       ('4', 'Raspberry');

INSERT INTO Category
    (Id, Name)
VALUES ('1', 'Fruits'),
       ('2', 'Vegetable'),
       ('3', 'Seeds'),
       ('4', 'Buns');

INSERT INTO Product_Category
    (ProductId, CategoryId)
VALUES ('1', '2'),
       ('1', '3'),
       ('2', '3'),
       ('4', '1');

