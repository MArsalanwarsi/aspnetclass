Create Database ecom
use ecom
Create Table users(
id int primary key Identity,
email varchar(255),
password varchar(255),
role varchar(50) Default 'user'
)

create table category(
id int primary key identity,
name varchar(255),
img varchar(255)
)
Alter Table users Add name varchar(255);
Create Table product(
id int primary key identity,
name varchar(255),
img varchar(255),
price varchar(255),
description varchar(max),
category_id int,
Foreign Key (category_id) References category(id)
)
select * from users
Delete from users where id=1
