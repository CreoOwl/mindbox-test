BEGIN TRAN products_categories_transaction;
-- Создаем структуру БД.
CREATE TABLE categories(
	id int NOT NULL PRIMARY KEY IDENTITY(1,1), 
	name varchar(100) NOT NULL);

CREATE TABLE products(
	id int not null PRIMARY KEY IDENTITY(1,1), 
	name varchar(100) NOT NULL);

CREATE TABLE products_categories(
	id int NOT NULL PRIMARY KEY IDENTITY(1,1), 
	product int NOT NULL FOREIGN KEY REFERENCES products(id), 
	category int NOT NULL FOREIGN KEY REFERENCES categories(id));

CREATE INDEX IX_products_categories_product ON products_categories(product);
CREATE INDEX IX_products_categories_category ON products_categories(category);

-- Заполняем таблицы данными.
insert into categories(name) values ('Куклы');
insert into categories(name) values ('Игрушки');
insert into categories(name) values ('Конструкторы');
insert into categories(name) values ('Настольные игры');
insert into categories(name) values ('Спортивный инвентарь');

insert into products(name) values ('Барби');
insert into products(name) values ('Лего');
insert into products(name) values ('Монополия');
insert into products(name) values ('Кеды');
insert into products(name) values ('Миска');

insert into products_categories(product, category) values (1, 1), (1, 2), (2, 2), (2, 3), (3, 4);

-- Выбираем пары «Имя продукта - Имя категории».
select p.name product, c.name category
from products p
left join products_categories p_c on p_c.product = p.id
left join categories c on p_c.category = c.id
COMMIT TRAN products_categories_transaction;